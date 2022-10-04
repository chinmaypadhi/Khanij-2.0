
//Start code: Add font size
var min = 12;
var max = 18;
var reset = 15;

function increaseFontSize() {
    var p = document.getElementsByTagName('body');
    for (i = 0; i < p.length; i++) {
        if (p[i].style.fontSize) {
            var s = parseInt(p[i].style.fontSize.replace("px", ""));
        } else {
            var s = 15;
        }
        if (s != max) {
            s += 1;
        }
        p[i].style.fontSize = s + "px"
    }
}

function decreaseFontSize() {
    var p = document.getElementsByTagName('body');
    for (i = 0; i < p.length; i++) {
        if (p[i].style.fontSize) {
            var s = parseInt(p[i].style.fontSize.replace("px", ""));
        } else {
            var s = 15;
        }
        if (s != min) {
            s -= 1;
        }
        p[i].style.fontSize = s + "px"
    }
}

function reSetFontSize() {
    var p = document.getElementsByTagName('body');
    for (i = 0; i < p.length; i++) {
        if (p[i].style.fontSize) {
            var s = parseInt(p[i].style.fontSize.replace("px", ""));
        } else {
            var s = 15;
        }
        if (s != reset) {
            s = 15;
        }
        p[i].style.fontSize = s + "px"
    }
}
//End code: Add font size	

//activate wow.js
new WOW().init();


//activate lightGallery.js
$('.lightgallery').lightGallery();

//common for all pages(inner content height , header fix)
$(document).ready(function () {
    $('.head-sec .navbar-nav li.dropdown,.top-link li.dropdown').hover(function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(500);
    }, function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
    });

    var hdrHeight = $('header').height();
    $('body').css('padding-top', hdrHeight - 2);
    var winHeight = $(window).height();
    if ($('.main-content').height() < winHeight) {
        $('.main-content').css({
           
        })
    }
    if ($(window).width() < 992) {
        $('.main-content').css({
           
        })
        $('.top-link').hide();
        $('.toplnk-mobile').click(function () {
            $('.top-link').fadeToggle();
        });
    }

       //tolltip calling
        $('[data-toggle="tooltip"]').each(function() {
            var animate = $(this).attr("data-animate");
            var colorclass = $(this).attr("data-color-class");
            $(this).tooltip({
                template: '<div class="tooltip ' + animate + ' ' + colorclass + '"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>'
            });
        });

        //datepicker calling
        $('.datepicker').datetimepicker({
		    format: 'DD-MM-YYYY',
	    });
});

//add and remove class according to resolution in staff directory down aroow and up arrow
$(window).scroll(function () {
    if ($(this).scrollTop() > 80) {
        $('.head-sec').addClass('fix-header');
        if ($(window).width() < 992) {
            $('.contact-dtls').hide();
        }
    } 
    else 
    {
        $('.head-sec').removeClass('fix-header');

        if ($(window).width() < 992) {
            $('.contact-dtls').show();
        }
    }
});


	   
     
      
        