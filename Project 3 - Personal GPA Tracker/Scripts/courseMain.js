$(document).ready(function () {
    //Process Create Submission
    $("#createBtn").on("click", function (e) {
        $("#formCreateCourse").submit();
    });

    $("#formCreateCourse").on("submit", function (event) {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            async: true
        };

        $.ajax(options).done(function (response) {
            $("#courseList").html(response);
            $("#courseList").effect("bounce", "fast");
        });

        event.preventDefault();
    });

    //Display Edit Modal when edit is clicked
    $('.editCourseLink').click(function () {
        var options = {
            url: $(this).attr("href"),
            type: "GET"
        };
        var request = $.ajax(options);
        request.done(function (response) {
            $('#editCourseContainer').html(response);
            $('#editCourseModal').modal('show');
        });
    });

    //Display Delete Modal when delete is clicked
    $('.deleteCourseLink').click(function () {
        var options = {
            url: $(this).attr("href"),
            type: "GET"
        }
        var request = $.ajax(options);
        request.done(function (response) {
            $('#deleteCourseContainer').html(response);
            $('#deleteCourseModal').modal('show');
        });
    });

});