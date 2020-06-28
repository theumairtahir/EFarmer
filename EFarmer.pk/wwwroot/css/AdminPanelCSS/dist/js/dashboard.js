$(function () {

    setInterval(function () {
        RefreshDashboard();
    }, 2000);
    $(window).resize(function () {
        RefreshDashboard();
    });
    RefreshDashboard();
});
var RefreshDashboard = function () {
    //load details
    $.ajax({
        async: true,
        type: "GET",
        url: detailsUrl,
        success: function (result) {
            $('#totalAdsPosted').html(result.totalAds);
            $('#totalUsers').html(result.totalUsers);
            $('#newUsersPercent').html(result.newUsersPercent);
            if (result.isNewUsersUp) {
                $('#newUsersPercent').removeClass('text-danger');
                $('#newUsersPercent').addClass('text-success');
                $('#newUsersIcon').removeClass('ti-arrow-down text-danger');
                $('#newUsersIcon').addClass('ti-arrow-up text-success');

            }
            else {
                $('#newUsersPercent').removeClass('text-success');
                $('#newUsersPercent').addClass('text-danger');
                $('#newUsersIcon').removeClass('ti-arrow-up text-success');
                $('#newUsersIcon').addClass('ti-arrow-down text-danger');
            }
            $('#newAdsPosted').html(result.newAdsPercent);
            if (result.isNewAdsUp) {
                $('#newAdsPosted').removeClass('text-danger');
                $('#newAdsPosted').addClass('text-success');
                $('#newAdsIcon').removeClass('ti-arrow-down text-danger');
                $('#newAdsIcon').addClass('ti-arrow-up text-success');
            }
            else {
                $('#newAdsPosted').removeClass('text-success');
                $('#newAdsPosted').addClass('text-danger');
                $('#newAdsIcon').removeClass('ti-arrow-up text-success');
                $('#newAdsIcon').addClass('ti-arrow-down text-danger');
            }
            $('#buyersCount').html(result.buyersCount);
            $('#sellersCount').html(result.sellersCount);
            $('#cropsCount').html(result.cropsCount);
            $('#citiesCount').html(result.citiesCount);
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Dashboard Details');
        }
    });
    //loads ad chart data
    $.ajax({
        async: true,
        type: "GET",
        url: adChartUrl,
        success: function (result) {
            $('#AdMonthlyChart').html('');
            Morris.Area({
                element: 'AdMonthlyChart',
                lineColors: ['#fb9678', '#01c0c8', '#8698b7'],
                data: result,
                xkey: 'month',
                ykeys: ['lahore', 'bahawalpur', 'faisalabad'],
                labels: ['Lahore', 'Bahawalpur', 'Faisalabad'],
                pointSize: 0,
                lineWidth: 0,
                resize: true,
                fillOpacity: 0.8,
                behaveLikeLine: true,
                gridLineColor: '#e0e0e0',
                hideHover: 'auto'
            });
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Advertisement Chart');
        }
    });
    //details timeline chart
    $.ajax({
        async: true,
        type: "GET",
        url: timelineChartUrl,
        success: function (result) {
            $.each(result, function (i, e) {
                $('#' + e.elementId).sparkline(e.values, {
                    type: 'bar',
                    height: '30',
                    barWidth: '4',
                    resize: true,
                    barSpacing: '10',
                    barColor: e.color
                });
            });
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Timeline Bar Chart');
        }
    });
    //seasonal chart
    $.ajax({
        async: true,
        type: "GET",
        url: overviewChartUrl,
        success: function (result) {
            var seasons = '';
            $.each(result.labels, function (i, e) {
                seasons += '<li><i class="fa fa-circle" style="color: ' + e.color + ';"></i> ' + e.label + '</li>';
            });
            $('#seasonalOverviewChartLabels').html(seasons);
            $('#' + result.elementId).html('');
            Morris.Bar({
                element: result.elementId,
                data: result.data,
                xkey: 'crop',
                ykeys: ['season1', 'season2', 'season3', 'season4'],
                labels: ['Winter', 'Spring', 'Summer', 'Autumn'],
                barColors: result.colors,
                hideHover: 'auto',
                gridLineColor: '#eef0f2',
                resize: true
            });
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Timeline Bar Chart');
        }
    });
    //popularity chart
    $.ajax({
        async: true,
        type: "GET",
        url: popularityChartUrl,
        success: function (result) {
            var seasons = '';
            $.each(result.labels, function (i, e) {
                seasons += `<li><i class="fa fa-circle m-r-5" style="color: ` + e.color + `;"></i>` + e.label + `</li>`;
            });
            $('#popularityChartLabels').html(seasons);
            $('#popularityChart').html('');
            Morris.Area({
                element: 'popularityChart',
                data: result.data,
                xkey: 'day',
                ykeys: ['currentMonth', 'prevMonth'],
                labels: result.labels,
                pointSize: 0,
                fillOpacity: 0.4,
                pointStrokeColors: result.colors,
                behaveLikeLine: true,
                gridLineColor: '#e0e0e0',
                lineWidth: 0,
                smooth: false,
                hideHover: 'auto',
                lineColors: result.colors,
                resize: true
            });
        },
        error: function () {
            ShowErrorMessage('Something went wrong while loading Progress Chart');
        }
    });

};
