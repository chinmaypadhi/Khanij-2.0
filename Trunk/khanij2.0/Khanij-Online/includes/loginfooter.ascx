<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loginfooter.ascx.cs" Inherits="includes_loginfooter" %>
<footer class="sticky-footer">
    <div class="container my-auto">
        <div class="copyright text-center my-auto"> <span>Copyright <script> document.write(new Date().getFullYear());</script> All rights reserved. Khanij Online </span> </div>
    </div>
</footer>


<script src="js/popper.min.js" ></script>
<script src="js/bootstrap.min.js" ></script>
<script src="js/districtDetails.js"></script>
<script src="js/distwiseactive.js"></script>
<script src="js/styleswitch.js"></script>
<script src="js/bootstrap-select.min.js"></script>
<script src="js/moment.min.js"></script> 
<script src="js/bootstrap-datetimepicker.min.js"></script>
<script src="js/searchable-select.min.js"></script>
<script>
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
                    "min-height": winHeight - 200
                })
                       
            }
            if ($(window).width() < 992) {
                $('.main-content').css({
                    "min-height": "100%"
                })
                $('.top-link').hide();
                $('.toplnk-mobile').click(function () {
                    $('.top-link').fadeToggle();
                });
            }

            $('.selectpicker').selectpicker();
            $('.searchableselect').searchableselect();
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 80) {
            $('.head-sec').addClass('fix-header');
            if ($(window).width() < 992) {
                $('.contact-dtls').hide();
            }
        } else {
            $('.head-sec').removeClass('fix-header');

            if ($(window).width() < 992) {
                $('.contact-dtls').show();
            }
        }
    });
</script>

 <script>
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
</script>

<script>
    $(document).ready(function () {
	    $('.datepicker').datetimepicker({
		    format: 'LT',
		    format: 'DD-MM-YYYY',
		    daysOfWeekDisabled: [0, 6],
	    });	
    });
    </script>
        