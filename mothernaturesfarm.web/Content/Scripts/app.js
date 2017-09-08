$(document).foundation();

$(document).ready(function() {
	// Mobile Nav
	$('#menuToggle').click(function(event) {
	    event.preventDefault();
		$('body').toggleClass('main-nav-open');
		$(this).toggleClass('open');
	});
});