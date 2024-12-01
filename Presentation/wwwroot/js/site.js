$(document).ready(function () {
    // Verifica si la URL actual es la página de inicio
    if (window.location.pathname === '/' || window.location.pathname === '/Home/Index') {
        $('#go-back').addClass('hide');
    }
    else {
        $('#go-back').removeClass('hide');
    }
});