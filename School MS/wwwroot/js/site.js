// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#myTable').DataTable();
});
$("#subject").change(function () {
    var subId = $(this).val();
    $.ajax({
        method: "POST",
        url: "/Question/GetChapters",
        data: {
            id: subId
        },
        success: function (response) {
            debugger;
            let _html = "";
            for (var i = 0; i < response.chapter.length; i++) {
                _html += '<option value=' + response.chapter[i].value + '>' + response.chapter[i].text + '</option>';
            }

            $('#chapter').html(_html);
        },
        error: function () { }
    });
});

$(".getQues").click(function () {

    var subjectName = $("#subject").val();
    var chapterName = $("#chapter").val();



    $.ajax({
        method: "POST",
        url: "/Question/GetQuestions",
        data: {
            subName: subjectName,
            chapterNam: chapterName

        },
        success: function (result) {
            for (var i = 0; i <= result.chapter.length; i++) {
                $("#result").append(result.chapter[i] + ": " + result.chapter[i] + '<br>');
            }



        },
        error: function (result) {
            alert("error");
        }

    });
});