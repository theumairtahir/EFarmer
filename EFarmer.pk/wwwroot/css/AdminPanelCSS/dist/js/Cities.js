$(document).ready(function () {
    loadDatatable();
    $('#btnSave').on('click', function () {
        if (true) {
            $('#cityForm').submit();
        }
    });
    $('#btnCreateNew').on('click', function () {
        resetForm();
        $('#titleCityModal').html('Create');
        $('#editModal').modal('show');
    });
});
$(window).resize(function () {
});
var citiesTable;
var loadDatatable = function () {
    citiesTable = $('#dtCities').DataTable({
        // Design Assets
        stateSave: true,
        autoWidth: false,
        // ServerSide Setups
        processing: false,
        serverSide: true,
        contentType: 'application/json; charset=utf-8',
        // Paging Setups
        paging: true,
        // Searching Setups
        searching: { regex: true },
        ajax: {
            url: citiesDataUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            error: function (response) {
                ShowErrorMessage('Failed to load Cities Data');
            }
        },
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }, width: '10%',
                searchable: false

            },
            { "data": "actionButtons", width: '10%', searchable: false, sortable: false },
            { "data": "name", width: '80%' }
        ],

        lengthMenu: [[5, 10, 25], [5, 10, 25]],
        pageLength: 5,
        fixedHeader: {
            header: true,
            footer: true
        },
        initComplete: function () {
            $('#dtCities_filter input').unbind();
            $('#dtCities_filter input').bind('keyup', function (e) {
                if (e.keyCode == 13) {
                    citiesTable.search(this.value).draw();
                }
            });
        },
        language: {
            "search": "Search:",
            "searchPlaceholder": "Type any word...."
        },
    });
};

var EditCity = function (id) {
    if (id) {
        resetForm();
        loadFormData(id, formDataUrl, function (response) {
            $('#Id').val(response.id);
            $('#Name').val(response.name);
        });
        $('#editModal').modal('show');
    }
    else {
        ShowWarningMessage("Please select a record to edit");
    }
}
var resetForm = function () {
    //$("input,textarea").val('');
    $('#cityForm').trigger('reset');
}

var DeleteCity = function (id) {
    createConfirmationAlert("Want to delete this record!", function () {
        deleteData(id, deleteCityUrl, function (response) {
            createSuccessAlert(response);
            reloadDataTable(citiesTable);
        });
    });
};
var CityInsights = function (id) {
    loadPieChart(id);
    loadMonthlyReportChart(id);
    $('#insightsModal').modal('show');
}
var loadPieChart = function (id) {
    var pieChart = echarts.init(document.getElementById('pie-chart'));
    var data = { id: id }
    $.ajax({
        async: true,
        type: "POST",
        data: data,
        url: pieChartUrl,
        success: function (result) {
            // specify chart configuration item and data
            option = {

                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    x: 'center',
                    y: 'bottom',
                    data: result.labels
                },
                toolbox: {
                    show: true,
                    feature: {

                        //dataView: { show: true, readOnly: false },
                        magicType: {
                            show: true,
                            type: ['pie', 'funnel']
                        },
                        restore: { show: true },
                        saveAsImage: { show: true }
                    }
                },
                color: result.colors,
                calculable: true,
                series: [
                    {
                        name: 'Crop Distribution',
                        type: 'pie',
                        radius: [30, 110],
                        center: ['50%', 200],
                        roseType: 'area',
                        x: '50%',               // for funnel
                        max: 40,                // for funnel
                        sort: 'ascending',     // for funnel
                        data: result.data,
                        hoverAnimation: true
                    }
                ]
            };
            // use configuration item and data specified to show chart
            pieChart.setOption(option, true), $(function () {
                function resize() {
                    setTimeout(function () {
                        pieChart.resize()
                    }, 500)
                }
                setTimeout(function () {
                    pieChart.resize()
                }, 100)
                $(window).on("resize", resize), $(".sidebartoggler").on("click", resize)
            });
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Distribution Pie Chart');
        }
    });

}

var loadMonthlyReportChart = function (id) {
    var myChart = echarts.init(document.getElementById('bar-chart'));
    var data = { id: id }
    $.ajax({
        async: true,
        type: "POST",
        data: data,
        url: barChartUrl,
        success: function (result) {
            var seriesArr = [];
            $.each(result.data, function (i, e) {
                var seriesObj = {
                    name: e.name,
                    type: 'bar',
                    data: e.data,
                    markPoint: {
                        data: [
                            { type: 'max', name: 'Max' },
                            { type: 'min', name: 'Min' }
                        ]
                    },
                    markLine: {
                        data: [
                            { type: 'average', name: 'Average' }
                        ]
                    }
                }
                seriesArr.push(seriesObj);
            });
            option = {
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: result.labels
                },
                toolbox: {
                    show: true,
                    feature: {

                        magicType: { show: true, type: ['line', 'bar'] },
                        restore: { show: true },
                        saveAsImage: { show: true }
                    }
                },
                color: result.colors,
                calculable: true,
                xAxis: [
                    {
                        type: 'category',
                        data: result.categories
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: seriesArr
            };

            myChart.setOption(option, true), $(function () {
                function resize() {
                    setTimeout(function () {
                        myChart.resize()
                    }, 500)
                }
                $(window).on("resize", resize), $(".sidebartoggler").on("click", resize);
            });
            setTimeout(function () {
                myChart.resize()
            }, 100)
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Monthly Chart');
        }
    });
}


