function showErrorMessage(errorMessage) {
    var indexOfNewArray = errorMessage.indexOf('new Array(');
    if (indexOfNewArray == -1 || indexOfNewArray > 0)
        errorMessage = 'new Array("' + errorMessage + '")';

    if (parent.ShowErrorList)
        parent.ShowErrorList(eval(errorMessage));
}

$(
    function () {
        if (parent.CloseErrorList)
            parent.CloseErrorList();
    }

);

function deleteRecordConfirm() {
    return confirm('Are you sure want to delete this record?');
}

window.onclick = function () {
    if (parent.formClick)
        parent.formClick();
}

function resizeUCRightPanel() {
    var htmlheight = document.body.parentNode.clientHeight - 90;
    $('.rightPanelContent').height(htmlheight);
    $('.rightPanelFrame').height(htmlheight);
}

//function pageLoad() {
$(document).ready(function () {
    Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(cancelPostBack);
});

function cancelPostBack(sender, args) {
    if (Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()) {
        alert('Your request is being processed. Please wait a moment');
        args.set_cancel(true);
    }
} 