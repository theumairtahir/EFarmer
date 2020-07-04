$(document).ready(function () {
    loadCategoriesTable();
    $('#btnSave').on('click', function () {
        if (true) {
            $('#categoryForm').submit();
        }
    });
    $('#btnCreateNew').on('click', function () {
        resetForm();
        $('#titleCategoryModal').html('Create');
        $('#editModal').modal('show');
    });
});
$(window).resize(function () {

});
var categoriesTable;
var loadCategoriesTable = function () {
    categoriesTable = $('#dtCategories').DataTable({
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
            url: categoriesDataUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            error: function (response) {
                ShowErrorMessage('Failed to load Categories Data');
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
            $('#dtCategories_filter input').unbind();
            $('#dtCategories_filter input').bind('keyup', function (e) {
                if (e.keyCode == 13) {
                    categoriesTable.search(this.value).draw();
                }
            });
        },
        language: {
            "search": "Search:",
            "searchPlaceholder": "Type any word...."
        },
    });
}
var DeleteCategory = function (id) {
    createConfirmationAlert("Want to delete this record!", function () {
        deleteData(id, deleteCategoryUrl, function (response) {
            createSuccessAlert(response);
        });
    });
};
var EditCategory = function (id) {
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
    $('#categoryForm').trigger('reset');
}