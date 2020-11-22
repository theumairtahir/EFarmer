$(document).ready(function () {
    loadDatatable();
    $('#btnSave').on('click', function () {
        if (true) {
            $('#userForm').submit();
        }
    });
});
$(window).resize(function () {

});

var usersTable;
var loadDatatable = function () {
    usersTable = $('#dtUsers').DataTable({
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
            url: usersDataUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            error: function (response) {
                ShowErrorMessage('Failed to load User Data');
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
            { "data": "name", width: '20%' },
            { "data": "city", width: '20%', searchable: true, sortable: true },
            { "data": "phone", width: '20%', searchable: true, sortable: false },
            { "data": "address", width: '40%', searchable: false, sortable: false }
        ],

        lengthMenu: [[5, 10, 25, 50], [5, 10, 25, 50]],
        pageLength: 5,
        fixedHeader: {
            header: true,
            footer: true
        },
        initComplete: function () {
            $('#dtUsers_filter input').unbind();
            $('#dtUsers_filter input').bind('keyup', function (e) {
                if (e.keyCode == 13) {
                    usersTable.search(this.value).draw();
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
        deleteData(id, deleteUserUrl, function (response) {
            createSuccessAlert(response);
            reloadDataTable(usersTable);
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
    $('#userForm').trigger('reset');
}

var UserInsights = function (id) {
    //loadPieChart(id);
    loadWeeklyReportChart(id);
    $('#insightsModal').modal('show');
};

var BlockUser = function (id) {
    createConfirmationAlert("Want to block this user!", function () {
        deleteData(id, blockUserUrl, function (response) {
            createSuccessAlert(response);
            reloadDataTable(advertisementsTable);
        });
    });
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