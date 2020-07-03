
$(document).ready(function () {
    if (successMessage != '') {
        ShowSuccessMessage(successMessage);
    }
    if (warningMessage != '') {
        ShowWarningMessage(warningMessage);
    }
    if (errorMessage != '') {
        ShowErrorMessage(errorMessage);
    }
});
var ShowLoader = function () {
    $('#preloader').show();
}
var HideLoader = function () {
    $('#preloader').hide();
}
var ShowWarningMessage = function (text) {
    CreateToast(appName, text, 'Warning', 'bottom-left');
};
var ShowSuccessMessage = function (text) {
    CreateToast(appName, text, 'Success', 'bottom-left');
};
var ShowErrorMessage = function (text) {
    CreateToast(appName, text, 'error', 'bottom-left');
};
var ShowInfoMessage = function (text) {
    CreateToast(appName, text, 'Info', 'bottom-left');
};
var ChangeNotficationNotify = function (flag) {
    var ele = $('#notification-notify');
    if (!flag) {
        ele.removeClass('notify');
    }
    else {
        ele.addClass('notify');
    }
}
var CreateToast = function (header, text, toastType, position) {
    $.toast({
        heading: header,
        text: text,
        position: position,
        loaderBg: '#f58936',
        icon: toastType.toLowerCase(),
        hideAfter: 3000,
        stack: 6
    });
};

var loadFormData = function (id, url, successCallback) {
    var data = { id: id };
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        async: false,
        success: successCallback,
        error: function (response) {
            ShowErrorMessage("Failed to load data");
        }
    })
}