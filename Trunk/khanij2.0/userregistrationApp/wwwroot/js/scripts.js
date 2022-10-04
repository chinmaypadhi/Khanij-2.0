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
var publishedMe
var unpublishedMe
var archiveMe
var refreshMe

function goBack() {
    window.history.back();
}

$('.nav-toggle-btn').on('click', function () {

    $('.page-container').toggleClass('full')
    $('.breadcrumb').toggleClass('full')
})

/*Hide show logic of module sec start*/
/*$('.menu-section').on('click', function () {
    $(this).addClass('d-none');
})

.find('#module-click-exclude').on('click', function (e) {
    e.stopPropagation();
});

$(document).on('click', ".module-icon", function () {
    $('.menu-section').toggleClass('d-none');
})*/
/*END*/


var windowWidth = $(window).width();

if (windowWidth < 800) {
    $(document).on("click", function (event) {
        var $trigger = $(".nav-toggle-btn");
        if ($trigger !== event.target && !$trigger.has(event.target).length) {
            $('.page-container').removeClass('full');
            
        }
    });
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
$("#publishedIcon").hide();
$("#unpublishedIcon").hide();
$("#archiveIcon").hide();
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
    if (publishedMe == "yes") {
        $('#publishedIcon').show();
        $("#publishedIcon").tooltip();
    }
    if (unpublishedMe == "yes") {
        $('#unpublishedIcon').show();
        $("#unpublishedIcon").tooltip();
    }
    if (archiveMe == "yes") {
        $('#archiveIcon').show();
        $("#archiveIcon").tooltip();
    }
    if (refreshMe == "yes") {
        $('#refreshIcon').show();
        $("#refreshIcon").tooltip();
    }
    
}


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
            $('.' + gLink).addClass('show');
        } else {
            $('.' + gLink).addClass('show');
        }
    $('.' + pLink).addClass('active show').parent('.dropdown-menu').addClass('active').parent('.dropdown').addClass('active');
    if (tLink != '') {
        $('.' + pLink).addClass('show');
    } else {
        $('.' + pLink).addClass('show');
    }
    $('.' + tLink).addClass('show');
    if (lLink != '')
        totLink = "<li class='breadcrumb-item'>" + fLink + " </li><li class='breadcrumb-item'>" + lLink + "</li>";
    else
        totLink = " <li class='breadcrumb-item active'> " + fLink + "</li>";
    //$('#navigation').html(totLink);
    $('#navigation').html('<li class="breadcrumb-item"><a href="javascript:void(0);" title="Home"><i class="icon-home-solid"></i></a></li>' + totLink);
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
    wWinPrint.document.write("<html><head><script type='text/javascript' src='../../../js/jquery.min.js'></script><link href='../../../CMScss/bootstrap.min.css' rel='stylesheet'><link href='../../../CMScss/print.css' rel='stylesheet'><title>Mineral Resources Department</title></head><body>");
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

    CMPLTADMIN_SETTINGS.windowBasedLayout = function() {
        var width = window.innerWidth;
       

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

   
   /* CMPLTADMIN_SETTINGS.chatAPI = function() {
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

    };*/
    /*--------------------------------
         Main Menu Scroll
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuScroll = function() {

        //console.log("expand scroll menu");

       /* var topbar = $(".page-topbar").height();
        //console.log(topbar);
        var projectinfo = 0; // $(".project-info").innerHeight();
        //console.log(projectinfo);

        var height = window.innerHeight - topbar - projectinfo;

        *//*$('.fixedscroll #main-menu-wrapper').height(height).perfectScrollbar({
            suppressScrollX: true
        });*//*
        if ($('.fixedscroll #main-menu-wrapper').length) {

            $('.fixedscroll #main-menu-wrapper').height(height);
            //console.log(height);
            const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {
                suppressScrollX: true
            });

        }
        $("#main-menu-wrapper .wraplist").height('auto');*/


        /*show first sub menu of open menu item only - opened after closed*/
        // > in the selector is used to select only immediate elements and not the inner nested elements.
        $(".dropdown-menu").attr("style", "display:block;");

       

    };

    $(function () {
$('a').tooltip('enable')

});

// table-responsive class adding in the parent div because of scrolling issue
$(function() {
    $("#datatable").addClass('table-responsive');
});
//end

    /*--------------------------------
         Collapsed Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuCollapsed = function() {
            
            if ($('.fixedscroll #main-menu-wrapper').length) {

                const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {});
                ps.destroy();
            }

    };




    /*--------------------------------
         Main Menu
     --------------------------------*/
    /*CMPLTADMIN_SETTINGS.mainMenu = function() {
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

    };*/


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


    CMPLTADMIN_SETTINGS.otherScripts = function() {

    if ($.isFunction($.fn.autosize)) {
        $(".autogrow").autosize();
    }

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

});


$(window).scroll(function () {
    var scroll = $(window).scrollTop();

    if (scroll > 0) {
        $(".page-topbar ").addClass("active");
    } else {
        $(".page-topbar ").removeClass("active");
    }
});