﻿(function() {
    $(document).ready(function() {
        var windowsize = $(window).width(),
            calendarView = '';

        if ($(window).width() > 420) {
            calendarView = 'month';
        } else {
            calendarView = 'listYear';
        }
        $(window).resize(function () {
            if ($(window).width() > 420) {
                $('#calendar').fullCalendar('changeView', 'month');
            } else {
                $('#calendar').fullCalendar('changeView', 'listYear');
            }
        });
        $('#calendar').fullCalendar({
            defaultView: calendarView,
            googleCalendarApiKey: 'AIzaSyBTWyqDSnCYLq13LDKyk0D7zCLlYEJw-vA',
            events: {
                googleCalendarId: '1rbbvflkj20qog42qoh6re92a8@group.calendar.google.com'
            }
        });
    });
}());