$(document).ready(function () {
    var currentTimeString;

    function updateClock() {
        var currentTime = new Date();

        var currentYear = currentTime.getFullYear();
        var currentMonth = currentTime.getMonth() + 1;
        var currentDay = currentTime.getDate();
        var currentHours = currentTime.getHours();
        var currentMinutes = currentTime.getMinutes();
        var currentSeconds = currentTime.getSeconds();

        currentMonth = (currentMonth < 10 ? "0" : "") + currentMonth;
        currentDay = (currentDay < 10 ? "0" : "") + currentDay;

        currentHours = (currentHours < 10 ? "0" : "") + currentHours;
        currentMinutes = (currentMinutes < 10 ? "0" : "") + currentMinutes;
        currentSeconds = (currentSeconds < 10 ? "0" : "") + currentSeconds;

        currentTimeString = currentYear + "-" + currentMonth + "-" + currentDay + "  " + currentHours + ":" + currentMinutes + ":" + currentSeconds;

        document.getElementById("currentDateTime").innerHTML = currentTimeString;
    }

    updateClock();
    setInterval(updateClock, 1000);
    

    $('.table tbody tr').each(function () {
        var removeTime = $(this).find('#removeDateTime').text().trim();
        
        if (removeTime.length != 0) {
            var date1 = new Date(removeTime).getTime();
            var date2 = new Date(currentTimeString).getTime();

            var msec = date2 - date1;
            var min = Math.floor(msec / 60000);
            
            if (min > 2)
                $(this).find('td#removeDateTime').css("text-indent", "");
        }

    });

    $('.table tbody tr').each(function () {
        var createTime = $(this).find('#createDateTime').text().trim();
        
        if (createTime.length != 0) {
            var date1 = new Date(createTime).getTime();
            var date2 = new Date(currentTimeString).getTime();

            var msec = date2 - date1;
            var min = Math.floor(msec / 60000);
            
            if (min > 4)
                $(this).show();
        }
    });

});