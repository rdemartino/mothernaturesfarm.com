$(document).foundation()

$(document).ready(function () {
    $('#calendar').fullCalendar({
        googleCalendarApiKey: 'AIzaSyBTWyqDSnCYLq13LDKyk0D7zCLlYEJw-vA',
        events: {
            googleCalendarId: '1rbbvflkj20qog42qoh6re92a8@group.calendar.google.com'
        }

    });
});