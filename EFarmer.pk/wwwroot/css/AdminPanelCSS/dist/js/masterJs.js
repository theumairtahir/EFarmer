
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
};


var createBasicAlert = function (message, title = null) {
    title = title == null || title == '' ? appName : title + ' says';
    swal(title, message);
};

var createSuccessAlert = function (message) {
    swal("Good job!", message, "success");
}

var createConfirmationAlert = function (question, callback) {
    swal({
        title: "Are you sure?",
        text: question,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, do it!"
    }).then(result => {
        if (result.value) {
            //action callback
            callback();
        } else if (result.dismiss === swal.DismissReason.cancel) {
            createErrorAlert("Canceled", "Your action has been canceled");
        }
        //swal.closeModal();
    });
};

var createErrorAlert = function (title, message) {
    swal(title, message, "error");
};

var createAutoCloseAlert = function (title, message, timmer = 2) {
    swal({
        title: title,
        text: message,
        timer: (timmer * 1000),
        showConfirmButton: false
    });
};
var createImageAlert = function (title, message, imageUrl) {
    swal({
        title: title,
        text: message,
        imageUrl: imageUrl
    });
}