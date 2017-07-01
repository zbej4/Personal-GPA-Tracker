$(document).ready(function () {
    //Retrieve Data when Calculate is clicked and output response
    $("#gpaBtn").on("click", function (e) {
        e.preventDefault();
        var desiredGPA = $("#desiredGPA").val();
        var currentCreditHours = $("#currentCreditHours").val();
        var previousHours = $("#previousHours").val();
        var previousQuality = $("#previousQuality").val();
        var neededGPA = calculateGPA(desiredGPA, currentCreditHours, previousHours, previousQuality);
        $("#futureOutput").html(neededGPA);
    });

    //Calculate GPA needed for current semester in order to achieve desired GPA
    var calculateGPA = function (desiredGPA, currentCreditHours, previousHours, previousQuality) {
        var neededGPA = 0.0;
        var totalHours = parseFloat(previousHours) + parseFloat(currentCreditHours);
        var qualityHoursNeeded = (totalHours * parseFloat(desiredGPA)) - parseFloat(previousQuality);
        var neededGPA = qualityHoursNeeded / currentCreditHours;
        if (neededGPA > 4.0) { neededGPA = "Not possible in given hours."; }
        return neededGPA;
    };
});