$(
    function () {
        if (parent.parent.CloseErrorList)
            parent.parent.CloseErrorList();
    }
);

window.onclick = function () {
    if (parent.parent.formClick)
        parent.parent.formClick();
}

function showErrorMessage(errorMessage) {
    var indexOfNewArray = errorMessage.indexOf('new Array(');
    if (indexOfNewArray == -1 || indexOfNewArray > 0)
        errorMessage = 'new Array("' + errorMessage + '")';

    if (parent.parent.ShowErrorList)
        parent.parent.ShowErrorList(eval(errorMessage));
}