var form = document.getElementById('login');

var urlParams = new URLSearchParams(window.location.search);
if (urlParams.has('loginresult') && urlParams.get('loginresult') === "false") {
    showError()
}

function showError() {
    form.classList.add('error_1');
    setTimeout(function () {
        form.classList.remove('error_1');
    }, 6000);
}