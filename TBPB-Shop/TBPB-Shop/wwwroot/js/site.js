﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

function showDescription(description) {
    $('#modal-content').text(description)
    $('.modal').modal({
        show: true
    });
}
function loadServerPartialView(container, baseUrl) {
    $.get(baseUrl, function (responseData) {
        $(container).html(responseData);
    });
}