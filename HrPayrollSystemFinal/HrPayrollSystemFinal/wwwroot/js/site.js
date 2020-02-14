// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Custom LoadMore JS
var numberOfWorkersTaken = 10;
var totalCount = +$("#workerCount").val();

$("#load_more").click(function () {
    $.ajax({
        url: "/Worker/LoadWorkers?skip=" + numberOfWorkersTaken,
        type: "GET",
        success: function (res) {
            $(".main-body").append(res);
            numberOfWorkersTaken += 10;

            if (numberOfWorkersTaken >= totalCount) {
                $("#load_more").remove();
            }
        }
    })
})

//sirket idsine uygun departmentler getirir
$(document).on("change", "#companies", function () {
    var data = $("#companies").val();

    if (data) {
        $.ajax({
            url: "/Ajax/LoadDepartments",
            data: { companyId: data },
            type: "POST",
            success: function (res) {
                $("#depData").html(res)
            }
        })
    }
});

//sirket Id uygun shoplar getirir
$(document).on("change", "#companies", function () {
    var data = $("#companies").val();

    if (data) {
        $.ajax({
            url: "/Ajax/LoadShops",
            data: { companyId: data },
            type: "POST",
            success: function (res) {
                $("#ShopId").html(res)
            }
        })
    }
});

//departmentlere uygun positionlar getirir
$(document).on("change", "#depData", function () {
    var data = $("#depData").val();

    if (data) {
        $.ajax({
            url: "/Ajax/LoadPositions",
            data: { departmentId: data },
            type: "POST",
            success: function (res) {
                $("#PositionId").html(res)
            }
        })
    }
});

//Search Jquery
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#myTable tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

//Alert for worker attendance
$(document).ready(function () {
    $(".confirm").click(function () {
        alert("Təsdiq edildi və əgər qaib sayı 5'dən çoxdursa email göndəriləcək!");
    });
});