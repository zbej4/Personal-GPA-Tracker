$(document).ready(function () {
    //Process Delete Submission
    $("#deleteBtn").on("click", function (e) {
        $("#formDeleteCourse").submit();
    });

    $("#formDeleteCourse").on("submit", function (event) {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (response) {
            $("#deleteCourseModal").modal("hide");
            $("#deleteCourseContainer").empty();
            $("#courseList").html(response);
            $("#courseList").effect("bounce", "fast");
        });

        event.preventDefault();
    });
});