$(document).ready(function () {
    loadDatatable();
    $('#btnSave').on('click', function () {
        if (true) {
            $('#agroItemForm').submit();
        }
    });
    $('#btnCreateNew').on('click', function () {
        resetForm();
        $('#titleAgroItemModal').html('Create');
        $('#editModal').modal('show');
    });
});
$(window).resize(function () {

});

var agroItemsTable;
var loadDatatable = function () {
    agroItemsTable = $('#dtAgroItems').DataTable({
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
            url: agroItemsDataUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            error: function (response) {
                ShowErrorMessage('Failed to load Agro Items Data');
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
            { "data": "name", width: '40%' },
            { "data": "category", width: '20%', searchable: true, sortable: true },
            { "data": "weightScale", width: '20%', searchable: true, sortable: false }
        ],

        lengthMenu: [[5, 10, 25, 50], [5, 10, 25, 50]],
        pageLength: 5,
        fixedHeader: {
            header: true,
            footer: true
        },
        initComplete: function () {
            $('#dtAgroItems_filter input').unbind();
            $('#dtAgroItems_filter input').bind('keyup', function (e) {
                if (e.keyCode == 13) {
                    agroItemsTable.search(this.value).draw();
                }
            });
        },
        language: {
            "search": "Search:",
            "searchPlaceholder": "Type any word...."
        },
    });
};

var DeleteItem = function (id) {
    createConfirmationAlert("Want to delete this record!", function () {
        deleteData(id, deleteAgroItemUrl, function (response) {
            createSuccessAlert(response);
            reloadDataTable(agroItemsTable);
        });
    });
};
var EditItem = function (id) {
    if (id) {
        resetForm();
        loadFormData(id, formDataUrl, function (response) {
            $('#Id').val(response.id);
            $('#Name').val(response.name);
            $('#WeightScale').val(response.weightScale);
            $('#Category').val(response.category);
        });
        $('#editModal').modal('show');
    }
    else {
        ShowWarningMessage("Please select a record to edit");
    }
}
var resetForm = function () {
    //$("input,textarea").val('');
    $('#agroItemForm').trigger('reset');
}

var ItemInsights = function (id) {
    //loadPieChart(id);
    loadWeeklyReportChart(id);
    $('#insightsModal').modal('show');
};

var loadWeeklyReportChart = function (id) {
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
            ShowErrorMessage('Something went wrong while loading Weekly Chart');
        }
    });
};