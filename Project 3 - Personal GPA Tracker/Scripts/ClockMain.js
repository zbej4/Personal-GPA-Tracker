function GetClock() {
    var d = new Date();
    var hour = d.getHours(), min = d.getMinutes(), sec = d.getSeconds(), meridiem;

    if (hour == 0) { meridiem = " AM"; hour = 12; }
    else if (hour < 12) { meridiem = " AM"; }
    else if (hour == 12) { meridiem = " PM"; }
    else if (hour > 12) { meridiem = " PM"; hour -= 12; }

    if (min <= 9) min = "0" + min;
    if (sec <= 9) sec = "0" + sec;

    document.getElementById('clockContainer').innerHTML = "" + hour + ":" + min + ":" + sec + meridiem + "";
}

window.onload = function () {
    GetClock();
    setInterval(GetClock, 1000);
}