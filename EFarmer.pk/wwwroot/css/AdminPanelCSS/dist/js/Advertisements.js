$(document).ready(function () {
    loadDatatable();
    $('#btnSave').on('click', function () {
        if (true) {
            $('#advertisementForm').submit();
        }
    });
    $('#btnCreateNew').on('click', function () {
        resetForm();
        $('#titleAdvertisementModal').html('Create');
        $('#editModal').modal('show');
    });
});
$(window).resize(function () {

});

var advertisementsTable;
var loadDatatable = function () {
    advertisementsTable = $('#dtAdvertisements').DataTable({
        // Design Assets
        stateSave: true,
        autoWidth: false,
        scrollX: true,
        // ServerSide Setups
        processing: false,
        serverSide: true,
        contentType: 'application/json; charset=utf-8',
        // Paging Setups
        paging: true,
        // Searching Setups
        searching: { regex: true },
        ajax: {
            url: advertisementsDataUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            error: function (response) {
                ShowErrorMessage('Failed to load Agro Advertisements Data');
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
            { "data": "picture", width: '10%', searchable: false, sortable: false },
            { "data": "itemName", width: '40%', searchable: true, sortable: true },
            { "data": "bids", width: '20%', searchable: false, sortable: true },
            { "data": "quantity", width: '20%', searchable: false, sortable: true },
            { "data": "price", width: '20%', searchable: true, sortable: true },
            { "data": "sellerName", width: '20%', searchable: true, sortable: true },
            { "data": "city", width: '20%', searchable: false, sortable: true },
            { "data": "postedTime", width: '20%', searchable: false, sortable: false }
        ],

        lengthMenu: [[5, 10, 25, 50], [5, 10, 25, 50]],
        pageLength: 5,
        fixedHeader: {
            header: true,
            footer: true
        },
        initComplete: function () {
            $('#dtAdvertisements_filter input').unbind();
            $('#dtAdvertisements_filter input').bind('keyup', function (e) {
                if (e.keyCode == 13) {
                    advertisementsTable.search(this.value).draw();
                }
            });
        },
        language: {
            "search": "Search:",
            "searchPlaceholder": "Type any word...."
        },
    });
};

var BlockAdvertisement = function (id) {
    createConfirmationAlert("Want to block this advertisement!", function () {
        deleteData(id, blockAdvertisementUrl, function (response) {
            createSuccessAlert(response);
            reloadDataTable(advertisementsTable);
        });
    });
};
var EditAdvertisement = function (id) {
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
    $('#advertisementForm').trigger('reset');
}

var AdvertisementInsights = function (id) {
    //loadPieChart(id);
    loadBidsChart(id);
    $('#insightsModal').modal('show');
};
var loadBidsChart = function (id) {
    var data = { id: id }
    $.ajax({
        async: true,
        type: "POST",
        data: data,
        url: bidChartUrl,
        success: function (result) {
            var line = new Morris.Line({
                element: 'bid-chart',
                resize: true,
                data: result,
                //[
                //    { date: '2019-02-05', noOfBids: 5 },
                //    { date: '2019-03-05', noOfBids: 3 },
                //    { date: '2019-04-05', noOfBids: 10 },
                //    { date: '2019-05-05', noOfBids: 2 },
                //    { date: '2019-06-05', noOfBids: 15 },
                //    { date: '2019-07-05', noOfBids: 1 },
                //    { date: '2019-08-05', noOfBids: 8 },
                //    { date: '2019-09-05', noOfBids: 5 },
                //    { date: '2019-12-05', noOfBids: 5 },
                //    { date: '2020-01-05', noOfBids: 8 },
                //],
                xkey: 'date',
                ykeys: ['noOfBids'],
                labels: ['Number of Bids'],
                gridLineColor: '#eef0f2',
                lineColors: ['#009efb', '#cc0000'],
                lineWidth: 2,
                hideHover: 'auto'
            });
            setTimeout(function () {
                $(window).trigger('resize');
            }, 100)
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Bids Report Chart');
        }
    });
    
}
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