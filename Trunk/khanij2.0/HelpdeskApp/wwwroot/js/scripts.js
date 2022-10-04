var host = window.location.host;
var pathInfo = window.location.pathname;
var FN1 = pathInfo.split('/')[1];
var FN2 = pathInfo.split('/')[2];
if (FN1 != '') {
    var appURL = "http://" + host + "/" + FN1;
} else {
    var appURL = "http://" + host;
}

var printMe
var backMe
var deleteMe
var downloadMe
var indicateMe
var excelMe
var pdfMe
var activetMe
var inactivetMe
var refreshMe
    // util function
function goBack() {
    window.history.back();
}

$("#printIcon").hide();
$("#backIcon").hide();
$("#deleteIcon").hide();
$("#indicate").hide();
$("#downloadIcon").hide();
$("#excelIcon").hide();
$("#pdfIcon").hide();
$("#activeIcon").hide();
$("#inactiveIcon").hide();
$("#refreshIcon").hide();

function checkStatus() {
    if (backMe == "yes") {
        $('#backIcon').show();
        $("#backIcon").tooltip();
    }
    if (printMe == "yes") {
        $('#printIcon').show();
        $("#printIcon").tooltip();
    }
    if (deleteMe == "yes") {
        $('#deleteIcon').show();
        $("#deleteIcon").tooltip();
    }

    if (indicateMe == "yes") {
        $('#indicate').show();
        $("#indicate").tooltip();
    }

    if (downloadMe == "yes") {
        $('#downloadIcon').show();
        $("#downloadIcon").tooltip();
    }
    if (excelMe == "yes") {
        $('#excelIcon').show();
        $("#excelIcon").tooltip();
    }
    if (pdfMe == "yes") {
        $('#pdfIcon').show();
        $("#pdfIcon").tooltip();
    }
    if (activetMe == "yes") {
        $('#activeIcon').show();
        $("#activeIcon").tooltip();
    }
    if (inactivetMe == "yes") {
        $('#inactiveIcon').show();
        $("#inactiveIcon").tooltip();
    }
    if (refreshMe == "yes") {
        $('#refreshIcon').show();
        $("#refreshIcon").tooltip();
    }
}

// $(window).scroll(function() {
//     alert(0)
//     if ($(this).scrollTop() > 80) {
//         $('.head-sec').addClass('fix-header');
//     } else {
//         $('.head-sec').removeClass('fix-header');
//     }
// });

$(document).ready(function() {
    $(".input-effect .form-control").val("");
    $(".input-effect .form-control").focusout(function() {
        if ($(this).val() != "") {
            $(this).addClass("has-content");
        } else {
            $(this).removeClass("has-content");
        }
    })

    checkStatus();

    // $('.form-container')
    var winHeight = $(window).height();
    if ($('.form-container').height() < winHeight) {
        $('.form-container').css({ "min-height": winHeight - 207 })
    }
    if ($(window).width() < 991) {

    }


//    $('.advancesearch').hide();
//    $('.searchbtn').click(function() {
//        $('.advancesearch').slideToggle();
//        $('.searchbtn .fas').toggleClass('fa-chevron-up fa-chevron-down');
//        if ($('.searchbtn span').text() == "Less search")
//            $('.searchbtn span').text("Advance Search")
//        else
//            $('.searchbtn span').text("Less search");
//    });
     $('.searchform').hide();
    $("<div class='text-center '><a href='#' class='btn btn-sm shadow-sm searchbtn rounded-0 waves-effect waves-light'><i class='fas fa-filter'></i><span >More Filter</span></a></div>").insertAfter(".searchform");

	$('.searchbtn').click(function(){
		$('.searchform').slideToggle();
		$('.searchbtn .fas').toggleClass('fa-times fa-filter ');
		if ($('.searchbtn span').text() == "Hide Filter")
		   $('.searchbtn span').text("More Filter")
		else
		   $('.searchbtn span').text("Hide Filter");		
	});
     
    //notification-menu start 
    $('.notification-btn .fa-times ').click(function () {
        $('.notification-menu').removeClass('active');
        $(this).hide();
        $('.notification-btn .fa-info ').show();
    });
    $('.notification-btn .fa-info ').click(function () {
        $('.notification-menu').addClass('active');
        $(this).hide();
        $('.notification-btn .fa-times ').show();
    });
    $('.feedback-btn').click(function () {
        $('.notification-menu').removeClass('active');
        $('.notification-btn .fa-info').show();
        $('.notification-btn .fa-times ').hide();
    });
//notification-menu end

//log-report start 
              $('.log-box').hide();
              $('.log-btn').click(function () {
                  $(this).find('.filter-box').slideToggle();
              });

              $('.log-btn').click(function () {
                  var collapse_content_selector = $(this).attr('data-val');
                  $('#' + collapse_content_selector).slideToggle();
              });

              $('.log-btn').click(function () {
                  $('.log-btn .fas').toggleClass('fa-chevron-down fa-times');
                  if ($('.log-btn').text() == "Close Log Report")
                      $('.log-btn').text("Log Report")
               });
//log-report end 
});

function loadNavigation(pgName, gLink, pLink, tLink, fLink, lLink, title) {
    var totLink = '';
    var pathName = window.location.pathname;
    var fileName = pathName.split('/').reverse()[0].split('.').reverse()[1];
    if (pgName == fileName)
        if (pLink != '') {
            $('.' + gLink).addClass('open').find('.arrow').addClass('open');
        } else {
            $('.' + gLink).addClass('open').find('.arrow').addClass('open');
        }
    $('.' + pLink).addClass('active');
    if (tLink != '') {
        $('.' + pLink).addClass('open');
    } else {
        $('.' + pLink).addClass('open');
    }
    $('.' + tLink).addClass('active');
    if (lLink != '')
        totLink = "<li class='breadcrumb-item'>" + fLink + " </li><li class='breadcrumb-item font-weight-bold'>" + lLink + "</li>";
    else
        totLink = " <li class='breadcrumb-item active'> " + fLink + "</li>";
    $('#navigation').html('<li class="breadcrumb-item"><a href="../Dashboard/Dashboard.aspx" title="Home" ><i class="fa fa-home"></i></a></li>' + totLink);
    $('#title').append(title);
    printHeader = title;

}
// print function
function PrintPage() {
    var windowName = "PrintPage";
    var wOption = "width=1000,height=600,menubar=yes,scrollbars=yes,location=no,left=100,top=100";
    var cloneTable = $("#viewtable").clone();
    var head = $('#viewtable thead tr');

    cloneTable.find('input[type=text],select,textarea').each(function() {
        var elementType = $(this).prop('tagName');
        if (elementType == 'SELECT') {

            if ($(this).val() > 0)
                var textVal = $(this).find("option:selected").text();
            else
                textVal = '';
        } else
            var textVal = $(this).val();
        $(this).replaceWith('<label>' + textVal + '</label>');
    });
    cloneTable.find('a').each(function() {
        var anchorVal = $(this).html();
        $(this).replaceWith('<label>' + anchorVal + '</label>');
    });

    var pageTitle = $("#title").text();
    var wWinPrint = window.open("", windowName, wOption);
    wWinPrint.document.write("<html><head><script type='text/javascript' src='../../../js/jquery.min.js'></script><link href='../../../css/bootstrap.min.css' rel='stylesheet'><link href='../../../css/print.css' rel='stylesheet'><title>Mineral Resources Department</title></head><body>");
    wWinPrint.document.write("<div id='header' class='mb-2 d-flex align-items-center justify-content-center'><h4 class='d-flex align-items-center'><img src='../../../img/print-logo.png' alt='Mineral Resources Department ' width='50' class='mr-2'> <p class='mb-0'>Mineral Resources Department<small class='d-block'>Government of Chhattisgarh</small></p> </h4><div class='ml-3 text_logo'><h4 class='logo'><a href='javascript:void(0)' class='btn btn-success btn-sm pull-right' style='float:right;' title='Print' onclick='$(this).hide();window.print();$(this).show();'>Print</a></h4></div></div>")
        //wWinPrint.document.write("<div id='printHeader'>" + pageTitle + "</div>");
    wWinPrint.document.write("<div id='printContent'>" + cloneTable.html() + "</div>");
    // wWinPrint.document.write("<div id='printFooter' class='text-center'>&copy; 2019 - GO SKILL</div>");
    wWinPrint.document.write("</body></html>");
    wWinPrint.document.close();
    wWinPrint.focus();
    return wWinPrint;
}

jQuery(function($) {

    'use strict';

    var CMPLTADMIN_SETTINGS = window.CMPLTADMIN_SETTINGS || {};

    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CMPLTADMIN_SETTINGS.windowBasedLayout = function() {
        var width = window.innerWidth;
        //console.log(width);

        if ($("body").hasClass("sidebar-collapse")) {

            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else if (width <= 1024) {

            // small window
            // $(".page-topbar").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-sidebar").addClass("collapseit").removeClass("expandit");
            $("#main-content").addClass("sidebar_shift").removeClass("chat_shift");
            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else {

            // large window
            //$(".page-topbar").removeClass("sidebar_shift chat_shift");
            $(".page-sidebar").removeClass("collapseit chat_shift");
            $("#main-content").removeClass("sidebar_shift chat_shift");
            CMPLTADMIN_SETTINGS.mainmenuScroll();
        }


    }

    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.onLoadTopBar = function() {

    //     $(".page-topbar .message-toggle-wrapper").addClass("showopacity");
    //     $(".page-topbar .notify-toggle-wrapper").addClass("showopacity");
    //     //$(".page-topbar .advancesearch").addClass("showopacity");
    //     $(".page-topbar li.profile").addClass("showopacity");
    // }


    /*--------------------------------
         CHAT API
     --------------------------------*/

    $('.setting-show').on('click', function() {
        $('.page-setting').toggleClass('hideit showit');
    });
    $('.setting-close').on('click', function() {
        $('.page-setting').toggleClass('hideit showit');
    });
    $('.page-topbar').mousedown(function() {
        if ($(".page-setting").hasClass("showit")) {
            $(".page-setting").toggleClass('hideit showit');
        }
    });

   
    CMPLTADMIN_SETTINGS.chatAPI = function() {
        $('.page-topbar .sidebar_toggle').on('click', function() {
            var topbar = $(".page-topbar");
            var mainarea = $("#main-content");
            var menuarea = $(".page-sidebar");

            if (menuarea.hasClass("collapseit")) {
                menuarea.addClass("expandit").removeClass("collapseit");
                //topbar.removeClass("sidebar_shift");
                mainarea.removeClass("sidebar_shift");
                CMPLTADMIN_SETTINGS.mainmenuScroll();
            } else {
                menuarea.addClass("collapseit").removeClass("expandit");
                //topbar.addClass("sidebar_shift");
                mainarea.addClass("sidebar_shift");
                CMPLTADMIN_SETTINGS.mainmenuCollapsed();
            }
        });

    };
    /*--------------------------------
         Main Menu Scroll
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuScroll = function() {

        //console.log("expand scroll menu");

        var topbar = $(".page-topbar").height();
        //console.log(topbar);
        var projectinfo = 0; // $(".project-info").innerHeight();
        //console.log(projectinfo);

        var height = window.innerHeight - topbar - projectinfo;

        /*$('.fixedscroll #main-menu-wrapper').height(height).perfectScrollbar({
            suppressScrollX: true
        });*/
        if ($('.fixedscroll #main-menu-wrapper').length) {

            $('.fixedscroll #main-menu-wrapper').height(height);
            //console.log(height);
            const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {
                suppressScrollX: true
            });

        }
        $("#main-menu-wrapper .wraplist").height('auto');


        /*show first sub menu of open menu item only - opened after closed*/
        // > in the selector is used to select only immediate elements and not the inner nested elements.
        $("li.open > .sub-menu").attr("style", "display:block;");


    };

    $(function () {
$('a').tooltip('enable')

});

// table-responsive class adding in the parent div because of scrolling issue
$(function() {
    $("#datatable").parent().addClass('table-responsive');
});
//end

 



    /*--------------------------------
         Collapsed Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuCollapsed = function() {

        if ($(".page-sidebar.chat_shift #main-menu-wrapper").length > 0 || $(".page-sidebar.collapseit #main-menu-wrapper").length > 0) {
            //console.log("collapse menu");
            var topbar = $(".page-topbar").height();
            var windowheight = window.innerHeight;
            var minheight = windowheight - topbar;
            var fullheight = $(".page-container #main-content .wrapper").height();

            var height = fullheight;

            if (fullheight < minheight) {
                height = minheight;
            }

            //$('.fixedscroll #main-menu-wrapper').perfectScrollbar('destroy');
            if ($('.fixedscroll #main-menu-wrapper').length) {

                const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {});
                ps.destroy();
            }

            $('.page-sidebar.chat_shift #main-menu-wrapper .wraplist, .page-sidebar.collapseit #main-menu-wrapper .wraplist').height(height);

            /*hide sub menu of open menu item*/
            $("li.open .sub-menu").attr("style", "");

        }

    };




    /*--------------------------------
         Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainMenu = function() {
        $('#main-menu-wrapper li a').click(function(e) {

            if ($(this).next().hasClass('sub-menu') === false) {
                return;
            }

            var parent = $(this).parent().parent();
            var sub = $(this).next();

            parent.children('li.open').children('.sub-menu').slideUp(200);
            parent.children('li.open').children('a').children('.arrow').removeClass('open');
            parent.children('li').removeClass('open');

            if (sub.is(":visible")) {
                $(this).find(".arrow").removeClass("open");
                sub.slideUp(200);
            } else {
                $(this).parent().addClass("open");
                $(this).find(".arrow").addClass("open");
                sub.slideDown(200);
            }

        });

        $("body").click(function(e) {
            $(".page-sidebar.collapseit .wraplist li.open .sub-menu").attr("style", "");
            $(".page-sidebar.collapseit .wraplist li.open").removeClass("open");
            $(".page-sidebar.chat_shift .wraplist li.open .sub-menu").attr("style", "");
            $(".page-sidebar.chat_shift .wraplist li.open").removeClass("open");
        });

    };



    




   

    /*--------------------------------
             Section Box Actions
         --------------------------------*/
    CMPLTADMIN_SETTINGS.sectionBoxActions = function() {

        $('.card-toggle .actions .box_toggle').on('click', function() {

            var content = $(this).parent().parent().parent().find(".card-body");
            if (content.hasClass("collapsed")) {
                content.removeClass("collapsed").slideDown(500);
                $(this).removeClass("fa-chevron-up").addClass("fa-chevron-down");
            } else {
                content.addClass("collapsed").slideUp(500);
                $(this).removeClass("fa-chevron-down").addClass("fa-chevron-up");
            }

        });

        $('.card-toggle .actions .box_close').on('click', function() {
            content = $(this).parent().parent().parent().remove();
        });



    };
   



    /*--------------------------------
         Tooltips & Popovers
     --------------------------------*/
    CMPLTADMIN_SETTINGS.tooltipsPopovers = function() {

        $('[data-toggle="tooltip"]').each(function() {
            var animate = $(this).attr("data-animate");
            var colorclass = $(this).attr("data-color-class");
            $(this).tooltip({
                template: '<div class="tooltip ' + animate + ' ' + colorclass + '"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>'
            });
        });

        $('[data-toggle="popover"]').each(function() {
            var animate = $(this).attr("data-animate");
            var colorclass = $(this).attr("data-color-class");
            $(this).popover({
                template: '<div  role="tooltip" class="popover ' + animate + ' ' + colorclass + '"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
            });
        });

    };


    /*--------------------------------
         Other Form component Scripts
     --------------------------------*/
    CMPLTADMIN_SETTINGS.otherScripts = function() {



        /*--------------------------------*/


        if ($.isFunction($.fn.autosize)) {
            $(".autogrow").autosize();
        }



         /*Steeper start*/
         $('.btnNext').click(function () {
               
            });

           

//            var $currStep = $(".startstep");
//            var activecount=1;
//            $currStep.addClass("active");
//            $(".btnNext").click(function () {
//            var obj = $('.activestep'+activecount);
//             activecount=activecount+1;
//                  $currStep = $('.activestep'+activecount).next();
//                   $currStep.addClass("activestep"+activecount);
//                    $currStep.addClass("active");
//                $('.activestep'+(activecount)).find('a').trigger('click');
//              
//               
//            });

//             $('.btnPrevious').click(function (e) {
//               var obj = $('.activestep'+activecount);
//                 $('.activestep'+(activecount-1)).find('a').trigger('click');alert('.activestep'+activecount);
//                $(obj).removeClass('active');
//                
//                
//                $(obj).removeClass('activestep'+activecount);
//                activecount=activecount-1;
//            });

 $('.btnNext').click(function() {
    $('.nav-tabs .active').parent().next('li').find('a').trigger('click');
  });

  $('.btnPrevious').click(function() {
    $('.nav-tabs .active').parent().prev('li').find('a').trigger('click');
  });	
	
	var $currStep = $(".startstep");
	$currStep .addClass("active");
	$(".btnNext").click(function() {
	  $currStep  = $currStep .next();
	  $currStep .addClass("active");
	});
	$(".btnPrevious").click(function() {
	  $currStep  .prev();
	  $currStep .removeClass("active");
	});		
           
    /*Steeper end*/
       

    };



    /*--------------------------------
        Widgets
     --------------------------------*/
    CMPLTADMIN_SETTINGS.cmpltadminWidgets = function() {

        /*notification widget*/
        if ($(".notification-widget").length) {
            var notif_widget = $(".notification-widget").height();
            /*$('.notification-widget').height(notif_widget).perfectScrollbar({
                suppressScrollX: true
            });*/
            $('.notification-widget').height(notif_widget);
            const psnotifwidget = new PerfectScrollbar('.notification-widget', {
                suppressScrollX: true
            });
        }
    };

    /*--------------------------------
        IOS7 Switchery
     --------------------------------*/
    CMPLTADMIN_SETTINGS.ios7Switchery = function() {

        if ($(".js-switch").length > 0) {

            var elems = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
            var defaults = {
                color: '#17a0d9',
                secondaryColor: '#dfdfdf',
                jackColor: '#fff',
                jackSecondaryColor: null,
                className: 'switchery',
                disabled: false,
                disabledOpacity: 0.5,
                speed: '0.5s',
                size: 'large'
            }
            var count = 0;
            var colors = ['#f44336', '#e91e63', '#9c27b0', '#673ab7', '#3f51b5', '#2196f3', '#03a9f4', '#00bcd4', '#009688', '#4caf50', '#8bc34a', '#cddc39', '#ffeb3b', '#ffc107', '#ff9800', '#ff5722', '#795548', '#9e9e9e', '#607d8b', '#000000'];
            elems.forEach(function(html) {
                count = count + 1;
                var size = 'default';
                var color = colors[count];
                if (count > 20) {
                    var size = 'large';
                    var color = colors[count - 20];
                }
                if (count > 40) {
                    var size = 'small';
                    var color = colors[count - 40];
                }
                var defaults = {
                    color: color,
                    secondaryColor: '#dfdfdf',
                    jackColor: '#fff',
                    jackSecondaryColor: null,
                    className: 'switchery',
                    disabled: false,
                    disabledOpacity: 0.5,
                    speed: '0.5s',
                    size: size
                }

                var switchery = new Switchery(html, defaults);
            });
        }


    };





    // Element Attribute Helper
    function getValue($el, data_var, default_val) {
        if (typeof $el.data(data_var) != 'undefined') {
            return $el.data(data_var);
        }

        return default_val;
    }
    /******************************
         initialize respective scripts 
         *****************************/
    $(document).ready(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
        CMPLTADMIN_SETTINGS.mainmenuScroll();
        CMPLTADMIN_SETTINGS.mainMenu();
        CMPLTADMIN_SETTINGS.mainmenuCollapsed();
        CMPLTADMIN_SETTINGS.sectionBoxActions();
        // CMPLTADMIN_SETTINGS.pageTopBar();
        CMPLTADMIN_SETTINGS.otherScripts();
        //CMPLTADMIN_SETTINGS.breadcrumbAutoHidden();
        CMPLTADMIN_SETTINGS.chatAPI();
        CMPLTADMIN_SETTINGS.cmpltadminWidgets();
        // CMPLTADMIN_SETTINGS.onLoadTopBar();
    });

    $(window).resize(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
    });

});