$(document).ready(function () {
    //Process Edit Submission
    $("#editBtn").on("click", function (e) {
        $("#formEditCourse").submit();
    });

    $("#formEditCourse").on("submit", function (event) {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (response) {
            $("#editCourseModal").modal("hide");
            $("#editCourseContainer").empty();
            $("#courseList").html(response);
            $("#courseList").effect("bounce", "fast");
        });

        event.preventDefault();
    });


});