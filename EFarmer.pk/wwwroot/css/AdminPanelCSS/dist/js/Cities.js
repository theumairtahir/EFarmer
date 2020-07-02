$(document).ready(function () {
    loadDatatable();
});
$(window).resize(function () {
    //loadDatatable.columns.adjust().draw();
});
var citiesTable;
var loadDatatable = function () {
    //$.fn.dataTable.ext.legacy.ajax = true;
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