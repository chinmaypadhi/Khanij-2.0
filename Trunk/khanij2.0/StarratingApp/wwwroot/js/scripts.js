
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
        
    }
    if ($(window).width() < 991) {

    }


    $('.advancesearch').hide();
    $('.searchbtn').click(function() {
        $('.advancesearch').slideToggle();
        $('.searchbtn .fas').toggleClass('fa-chevron-up fa-chevron-down');
        if ($('.searchbtn span').text() == "Less search")
            $('.searchbtn span').text("Advance Search")
        else
            $('.searchbtn span').text("Less search");
    });
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
    $('#navigation').html('<li class="breadcrumb-item"><a href="../Dashboard/dashboard.aspx" title="Home" ><i class="fa fa-home"></i></a></li>' + totLink);
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
    wWinPrint.document.write("<html><head><script type='text/javascript' src='../js/jquery.min.js'></script><link href='../css/bootstrap.min.css' rel='stylesheet'><link href='../css/print.css' rel='stylesheet'><title>Mineral Resources Department</title></head><body>");
    wWinPrint.document.write("<div id='header' class='mb-2 d-flex align-items-center justify-content-between'><h4 class='d-flex align-items-center'><img src='../img/print-logo.png' alt='Chief Minister's Grievance Cell' width='50' class='mr-2'> <p class='mb-0'>Chief Minister's Grievance Cell <small class='d-block'>Government of Chhattisgarh</small></p> </h4><div class='pull-left text_logo'><h4 class='logo'><a href='javascript:void(0)' class='btn btn-success btn-sm pull-right' style='float:right;' title='Print' onclick='$(this).hide();window.print();$(this).show();'>Print</a></h4></div></div>")
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

        } else if (width < 767) {

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

    // CMPLTADMIN_SETTINGS.chatAPI = function() {

    //     $('.page-sidebar .sidebar_toggle').on('click', function() {
    //         var topbar = $(".page-topbar");
    //         var mainarea = $("#main-content");
    //         var menuarea = $(".page-sidebar");

    //         if (menuarea.hasClass("collapseit")) {
    //             menuarea.addClass("expandit").removeClass("collapseit");
    //             topbar.removeClass("sidebar_shift");
    //             mainarea.removeClass("sidebar_shift");
    //             CMPLTADMIN_SETTINGS.mainmenuScroll();
    //         } else {
    //             menuarea.addClass("collapseit").removeClass("expandit");
    //             topbar.addClass("sidebar_shift");
    //             mainarea.addClass("sidebar_shift");
    //             CMPLTADMIN_SETTINGS.mainmenuCollapsed();
    //         }
    //     });

    // };
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
         Mailbox
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.mailboxInbox = function() {

    //     $('.mail_list table .star i').click(function(e) {
    //         $(this).toggleClass("fa-star fa-star-o");
    //     });

    //     $('.mail_list .open-view').click(function(e) {
    //         window.location = 'mail-view.html';
    //     });

    //     $('.mail_view_info .labels .cc').click(function(e) {
    //         var ele = $(".mail_compose_cc");
    //         if (ele.is(":visible")) {
    //             ele.hide();
    //         } else {
    //             ele.show();
    //         }
    //     });

    //     $('.mail_view_info .labels .bcc').click(function(e) {
    //         var ele = $(".mail_compose_bcc");
    //         if (ele.is(":visible")) {
    //             ele.hide();
    //         } else {
    //             ele.show();
    //         }
    //     });

    // };




    /*--------------------------------
         Top Bar
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.pageTopBar = function() {
    //     $('.page-topbar li.advancesearch .input-group-addon').click(function(e) {
    //         $(this).parent().parent().parent().toggleClass("focus");
    //         $(this).parent().parent().find("input").focus();
    //     });

    //     /*$('.page-topbar li .dropdown-menu .list').perfectScrollbar({
    //         suppressScrollX: true
    //     });*/
    //     // const pstopbar = new PerfectScrollbar('.page-topbar li .dropdown-menu .list', {
    //     //     suppressScrollX: true
    //     // });

    // };

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
         Extra form settings
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.extraFormSettings = function() {

    //     // transparent input group focus/blur
    //     $('.input-group .form-control').focus(function(e) {
    //         $(this).parent().find(".input-group-addon").addClass("input-focus");
    //         $(this).parent().find(".input-group-btn").addClass("input-focus");
    //     });

    //     $('.input-group .form-control').blur(function(e) {
    //         $(this).parent().find(".input-group-addon").removeClass("input-focus");
    //         $(this).parent().find(".input-group-btn").removeClass("input-focus");
    //     });

    // };





    /*--------------------------------
         Vector maps
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.jvectorMaps = function() {

    //     if ($.isFunction($.fn.vectorMap)) {

    //         if ($("#world-map-markers").length) {
    //             //@code_start
    //             $(function() {
    //                 $('#world-map-markers').vectorMap({
    //                     map: 'world_mill_en',
    //                     scaleColors: ['#3F51B5', '#3F51B5'],
    //                     normalizeFunction: 'polynomial',
    //                     hoverOpacity: 0.7,
    //                     hoverColor: false,
    //                     regionsSelectable: true,
    //                     markersSelectable: true,
    //                     markersSelectableOne: true,

    //                     onRegionOver: function(event, code) {
    //                         //console.log('region-over', code);
    //                     },
    //                     onRegionOut: function(event, code) {
    //                         //console.log('region-out', code);
    //                     },
    //                     onRegionClick: function(event, code) {
    //                         //console.log('region-click', code);
    //                     },
    //                     onRegionSelected: function(event, code, isSelected, selectedRegions) {
    //                         //console.log('region-select', code, isSelected, selectedRegions);
    //                         if (window.localStorage) {
    //                             window.localStorage.setItem(
    //                                 'jvectormap-selected-regions',
    //                                 JSON.stringify(selectedRegions)
    //                             );
    //                         }
    //                     },

    //                     panOnDrag: true,

    //                     focusOn: {
    //                         x: 1.5,
    //                         y: 1.5,
    //                         scale: 1,
    //                         animate: true
    //                     },


    //                     regionStyle: {
    //                         initial: {
    //                             fill: '#cccccc',
    //                             'fill-opacity': 1,
    //                             stroke: 'none',
    //                             'stroke-width': 0,
    //                             'stroke-opacity': 1
    //                         },
    //                         hover: {
    //                             fill: '#E91E63',
    //                             'fill-opacity': 1,
    //                             cursor: 'pointer'
    //                         },
    //                         selected: {
    //                             fill: '#E91E63'
    //                         },
    //                         selectedHover: {}
    //                     },



    //                     markerStyle: {
    //                         initial: {
    //                             fill: '#673AB7',
    //                             stroke: '#ffffff',
    //                             "stroke-width": 2,
    //                             r: 10
    //                         },
    //                         hover: {
    //                             stroke: '#FFC107',
    //                             "stroke-width": 2,
    //                             cursor: 'pointer'
    //                         },
    //                         selected: {
    //                             fill: '#FFC107',
    //                             "stroke-width": 0,
    //                         },
    //                     },
    //                     backgroundColor: '#ffffff',
    //                     markers: [{
    //                         latLng: [41.90, 12.45],
    //                         name: 'Vatican City'
    //                     }, {
    //                         latLng: [43.73, 7.41],
    //                         name: 'Monaco'
    //                     }, {
    //                         latLng: [-0.52, 166.93],
    //                         name: 'Nauru'
    //                     }, {
    //                         latLng: [-8.51, 179.21],
    //                         name: 'Tuvalu'
    //                     }, {
    //                         latLng: [43.93, 12.46],
    //                         name: 'San Marino'
    //                     }, {
    //                         latLng: [47.14, 9.52],
    //                         name: 'Liechtenstein'
    //                     }, {
    //                         latLng: [7.11, 171.06],
    //                         name: 'Marshall Islands'
    //                     }, {
    //                         latLng: [17.3, -62.73],
    //                         name: 'Saint Kitts and Nevis'
    //                     }, {
    //                         latLng: [3.2, 73.22],
    //                         name: 'Maldives'
    //                     }, {
    //                         latLng: [35.88, 14.5],
    //                         name: 'Malta'
    //                     }, {
    //                         latLng: [12.05, -61.75],
    //                         name: 'Grenada'
    //                     }, {
    //                         latLng: [13.16, -61.23],
    //                         name: 'Saint Vincent and the Grenadines'
    //                     }, {
    //                         latLng: [13.16, -59.55],
    //                         name: 'Barbados'
    //                     }, {
    //                         latLng: [17.11, -61.85],
    //                         name: 'Antigua and Barbuda'
    //                     }, {
    //                         latLng: [-4.61, 55.45],
    //                         name: 'Seychelles'
    //                     }, {
    //                         latLng: [7.35, 134.46],
    //                         name: 'Palau'
    //                     }, {
    //                         latLng: [42.5, 1.51],
    //                         name: 'Andorra'
    //                     }, {
    //                         latLng: [14.01, -60.98],
    //                         name: 'Saint Lucia'
    //                     }, {
    //                         latLng: [6.91, 158.18],
    //                         name: 'Federated States of Micronesia'
    //                     }, {
    //                         latLng: [1.3, 103.8],
    //                         name: 'Singapore'
    //                     }, {
    //                         latLng: [1.46, 173.03],
    //                         name: 'Kiribati'
    //                     }, {
    //                         latLng: [-21.13, -175.2],
    //                         name: 'Tonga'
    //                     }, {
    //                         latLng: [15.3, -61.38],
    //                         name: 'Dominica'
    //                     }, {
    //                         latLng: [-20.2, 57.5],
    //                         name: 'Mauritius'
    //                     }, {
    //                         latLng: [26.02, 50.55],
    //                         name: 'Bahrain'
    //                     }, {
    //                         latLng: [0.33, 6.73],
    //                         name: 'São Tomé and Príncipe'
    //                     }]
    //                 });
    //             });
    //             //@code_end
    //         }

    //         var mapid = "";
    //         mapid = $('#europe_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'europe_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 1,
    //                     animate: true
    //                 },
    //             });
    //         } // Europe 
    //         mapid = $('#in_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'in_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // India
    //         mapid = $('#us_aea_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'us_aea_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // USA
    //         mapid = $('#pt_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'pt_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Portugal
    //         mapid = $('#cn_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'cn_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // China
    //         mapid = $('#nz_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'nz_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // New Zealand
    //         mapid = $('#no_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'no_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Norway
    //         mapid = $('#es_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'es_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Spain
    //         mapid = $('#au_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'au_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Australia
    //         mapid = $('#fr_regions_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'fr_regions_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // France - Regions
    //         mapid = $('#th_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'th_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Thailand
    //         mapid = $('#co_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'co_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Colombia
    //         mapid = $('#be_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'be_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Belgium
    //         mapid = $('#ar_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'ar_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Argentina
    //         mapid = $('#ve_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 've_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Venezuela
    //         mapid = $('#it_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'it_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Italy
    //         mapid = $('#dk_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'dk_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Denmark
    //         mapid = $('#at_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'at_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Austria
    //         mapid = $('#ca_lcc_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'ca_lcc_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Canada
    //         mapid = $('#nl_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'nl_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Netherlands
    //         mapid = $('#se_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'se_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Sweden
    //         mapid = $('#pl_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'pl_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Poland
    //         mapid = $('#de_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'de_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Germany
    //         mapid = $('#fr_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'fr_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // France - Departments
    //         mapid = $('#za_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'za_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // South Africa
    //         mapid = $('#ch_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'ch_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Switzerland
    //         mapid = $('#us-ny-newyork_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'us-ny-newyork_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // New York City
    //         mapid = $('#us-il-chicago_mill_en-map');
    //         if (mapid.length) {
    //             mapid.vectorMap({
    //                 map: 'us-il-chicago_mill_en',
    //                 regionsSelectable: true,
    //                 backgroundColor: '#3F51B5',
    //                 regionStyle: {
    //                     initial: {
    //                         fill: 'white',
    //                         stroke: 'none',
    //                     },
    //                     hover: {
    //                         fill: '#E91E63',
    //                         'fill-opacity': 1,
    //                         cursor: 'pointer'
    //                     },
    //                     selected: {
    //                         fill: '#E91E63'
    //                     }
    //                 },
    //                 focusOn: {
    //                     x: 0,
    //                     y: 0,
    //                     scale: 5,
    //                     animate: true
    //                 },
    //             });
    //         } // Chicago

    //     }

    // };


    /*--------------------------------
         DataTables
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.dataTablesInit = function() {


    //     if ($.isFunction($.fn.dataTable)) {

    //         /*--- start ---*/

    //         var tableex1 = $("#example-1").dataTable({
    //             responsive: true,
    //             aLengthMenu: [
    //                 [10, 25, 50, 100, -1],
    //                 [10, 25, 50, 100, "All"]
    //             ]
    //         });

    //         /*--- end ---*/

    //         /*--- start ---*/

    //         var tableex1 = $("#example-11").dataTable({
    //             dom: 'Bfrtip',
    //             buttons: [
    //                 'copy', 'csv', 'excel', 'pdf', 'print'
    //             ]
    //         });

    //         /*--- end ---*/


    //         /*--- start ---*/

    //         $('#example-4').dataTable();

    //         /*--- end ---*/

    //         /*--- start ---*/

    //         // Setup - add a text input to each footer cell
    //         $('#example-3 tfoot th').each(function() {
    //             var title = $(this).text();
    //             $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    //         });

    //         // DataTable
    //         var table = $('#example-3').DataTable();

    //         // Apply the search
    //         table.columns().every(function() {
    //             var that = this;

    //             $('input', this.footer()).on('keyup change', function() {
    //                 if (that.search() !== this.value) {
    //                     that
    //                         .search(this.value)
    //                         .draw();
    //                 }
    //             });
    //         });
    //         /*--- end ---*/
    //         /*--- start ---*/
    //         var table = $('#example-2').DataTable();

    //         $('#example-2 tbody')
    //             .on('mouseenter', 'td', function() {
    //                 var colIdx = table.cell(this).index().column;

    //                 $(table.cells().nodes()).removeClass('highlight');
    //                 $(table.column(colIdx).nodes()).addClass('highlight');
    //             });
    //         /*--- end ---*/



    //         var table5 = $('#example-5').DataTable();

    //         $('button.example-5-submit').click(function() {
    //             var data = table5.$('input, select').serialize();
    //             alert(
    //                 "The following data would have been submitted to the server: \n\n" +
    //                 data.substr(0, 120) + '...'
    //             );
    //             return false;
    //         });




    //     }
    // };



    /*--------------------------------
         Pretty Photo
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.loadPrettyPhoto = function() {

    //     if ($.isFunction($.fn.prettyPhoto)) {
    //         //Pretty Photo
    //         $("a[rel^='prettyPhoto']").prettyPhoto({
    //             social_tools: false
    //         });
    //     }
    // };




    /*--------------------------------
         Gallery
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.isotopeGallery = function() {
    //     if ($.isFunction($.fn.isotope)) {

    //         var $portfolio_selectors = $('.portfolio-filter >li>a');
    //         var $portfolio = $('.portfolio-items');
    //         $portfolio.isotope({
    //             itemSelector: '.portfolio-item',
    //             layoutMode: 'sloppyMasonry'
    //         });

    //         $portfolio_selectors.on('click', function() {
    //             $portfolio_selectors.removeClass('active');
    //             $(this).addClass('active');
    //             var selector = $(this).attr('data-filter');
    //             $portfolio.isotope({
    //                 filter: selector
    //             });
    //             return false;
    //         });


    //     }
    // };


    /*--------------------------------
         Full Calendar
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.uiCalendar = function() {


    //     if ($.isFunction($.fn.fullCalendar)) {

    //         /* initialize the external events
    //              -----------------------------------------------------------------*/

    //         $('#external-events .fc-event').each(function() {

    //             // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
    //             // it doesn't need to have a start or end
    //             var eventObject = {
    //                 title: $.trim($(this).text()) // use the element's text as the event title
    //             };

    //             // store the Event Object in the DOM element so we can get to it later
    //             $(this).data('eventObject', eventObject);

    //             // make the event draggable using jQuery UI
    //             $(this).draggable({
    //                 zIndex: 999,
    //                 revert: true, // will cause the event to go back to its
    //                 revertDuration: 0 //  original position after the drag
    //             });

    //         });


    //         /* initialize the calendar
    //          -----------------------------------------------------------------*/

    //         var date = new Date();
    //         var d = date.getDate();
    //         var m = date.getMonth();
    //         var y = date.getFullYear();

    //         $('#calendar').fullCalendar({
    //             header: {
    //                 left: 'prev,next today',
    //                 center: 'title',
    //                 right: 'month,basicWeek,basicDay'
    //             },
    //             editable: true,
    //             eventLimit: true, // allow "more" link when too many events
    //             droppable: true, // this allows things to be dropped onto the calendar !!!
    //             drop: function(date, allDay) { // this function is called when something is dropped

    //                 // retrieve the dropped element's stored Event Object
    //                 var originalEventObject = $(this).data('eventObject');

    //                 // we need to copy it, so that multiple events don't have a reference to the same object
    //                 var copiedEventObject = $.extend({}, originalEventObject);

    //                 // assign it the date that was reported
    //                 copiedEventObject.start = date;
    //                 copiedEventObject.allDay = allDay;

    //                 // render the event on the calendar
    //                 // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
    //                 $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

    //                 // is the "remove after drop" checkbox checked?
    //                 if ($('#drop-remove').is(':checked')) {
    //                     // if so, remove the element from the "Draggable Events" list
    //                     $(this).remove();
    //                 }

    //             },
    //             events: [{
    //                 title: 'All Day Event',
    //                 start: new Date(y, m, 1)
    //             }, {
    //                 title: 'Long Event',
    //                 start: new Date(y, m, d - 5),
    //                 end: new Date(y, m, d - 2)
    //             }, {
    //                 id: 999,
    //                 title: 'Repeating Event',
    //                 start: new Date(y, m, d - 3, 16, 0),
    //                 allDay: false
    //             }, {
    //                 id: 999,
    //                 title: 'Repeating Event',
    //                 start: new Date(y, m, d + 4, 16, 0),
    //                 allDay: false
    //             }, {
    //                 title: 'Meeting',
    //                 start: new Date(y, m, d, 10, 30),
    //                 allDay: false
    //             }, {
    //                 title: 'Lunch',
    //                 start: new Date(y, m, d, 12, 0),
    //                 end: new Date(y, m, d, 14, 0),
    //                 allDay: false
    //             }, {
    //                 title: 'Conference',
    //                 start: new Date(y, m, d + 1, 19, 0),
    //                 end: new Date(y, m, d + 1, 22, 30),
    //                 allDay: false
    //             }, {
    //                 title: 'Staff Meeting',
    //                 start: new Date(y, m, 28),
    //                 end: new Date(y, m, 29),
    //                 url: 'http://google.com/'
    //             }]
    //         });





    //         /*Add new event*/
    //         // Form to add new event

    //         $("#add_event_form").on('submit', function(ev) {
    //             ev.preventDefault();

    //             var $event = $(this).find('.new-event-form'),
    //                 event_name = $event.val();

    //             if (event_name.length >= 3) {

    //                 var newid = "new" + "" + Math.random().toString(36).substring(7);
    //                 // Create Event Entry
    //                 $("#external-events").append(
    //                     '<div id="' + newid + '" class="fc-event bg-accent">' + event_name + '</div>'
    //                 );


    //                 var eventObject = {
    //                     title: $.trim($("#" + newid).text()) // use the element's text as the event title
    //                 };

    //                 // store the Event Object in the DOM element so we can get to it later
    //                 $("#" + newid).data('eventObject', eventObject);

    //                 // Reset draggable
    //                 $("#" + newid).draggable({
    //                     revert: true,
    //                     revertDuration: 0,
    //                     zIndex: 999
    //                 });

    //                 // Reset input
    //                 $event.val('').focus();
    //             } else {
    //                 $event.focus();
    //             }
    //         });



    //     }

    // };



    /*--------------------------------
         Sortable (Nestable) List
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.nestableList = function() {

    //     $("#nestableList-1").on('stop.uk.nestable', function(ev) {
    //         var serialized = $(this).data('nestable').serialize(),
    //             str = '';

    //         str = nestableIterate(serialized, 0);

    //         $("#nestableList-1-ev").val(str);
    //     });


    //     function nestableIterate(items, depth) {
    //         var str = '';

    //         if (!depth)
    //             depth = 0;

    //         //console.log(items);

    //         jQuery.each(items, function(i, obj) {
    //             str += '[ID: ' + obj.itemId + ']\t' + nestableRepeat('—', depth + 1) + ' ' + obj.item;
    //             str += '\n';

    //             if (obj.children) {
    //                 str += nestableIterate(obj.children, depth + 1);
    //             }
    //         });

    //         return str;
    //     }

    //     function nestableRepeat(s, n) {
    //         var a = [];
    //         while (a.length < n) {
    //             a.push(s);
    //         }
    //         return a.join('');
    //     }
    // };









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

        /*--------------------------------*/




        // Input Mask
        // if ($.isFunction($.fn.inputmask)) {
        //     $("[data-mask]").each(function(i, el) {
        //         var $this = $(el),
        //             mask = $this.data('mask').toString(),
        //             opts = {
        //                 numericInput: getValue($this, 'numeric', false),
        //                 radixPoint: getValue($this, 'radixPoint', ''),
        //                 rightAlign: getValue($this, 'numericAlign', 'left') == 'right'
        //             },
        //             placeholder = getValue($this, 'placeholder', ''),
        //             is_regex = getValue($this, 'isRegex', '');

        //         if (placeholder.length) {
        //             opts[placeholder] = placeholder;
        //         }


        //         if (mask.toLowerCase() == "phone") {
        //             mask = "(999) 999-9999";
        //         }

        //         if (mask.toLowerCase() == "email") {
        //             mask = 'Regex';
        //             opts.regex = "[a-zA-Z0-9._%-]+@[a-zA-Z0-9-]+\\.[a-zA-Z]{2,4}";
        //         }

        //         if (mask.toLowerCase() == "fdecimal") {
        //             mask = 'decimal';
        //             $.extend(opts, {
        //                 autoGroup: true,
        //                 groupSize: 3,
        //                 radixPoint: getValue($this, 'rad', '.'),
        //                 groupSeparator: getValue($this, 'dec', ',')
        //             });
        //         }


        //         if (mask.toLowerCase() == "currency" || mask.toLowerCase() == "rcurrency") {

        //             var sign = getValue($this, 'sign', '$');;

        //             mask = "999,999,999.99";
        //             if (mask.toLowerCase() == 'rcurrency') {
        //                 mask += ' ' + sign;
        //             } else {
        //                 mask = sign + ' ' + mask;
        //             }

        //             opts.numericInput = true;
        //             opts.rightAlignNumerics = false;
        //             opts.radixPoint = '.';

        //         }

        //         if (is_regex) {
        //             opts.regex = mask;
        //             mask = 'Regex';
        //         }

        //         $this.inputmask(mask, opts);
        //     });
        // }


        /*---------------------------------*/

        // autoNumeric
        // if ($.isFunction($.fn.autoNumeric)) {
        //     $('.autoNumeric').autoNumeric('init');
        // }

        /*---------------------------------*/

        // Slider
        // if ($.isFunction($.fn.slider)) {
        //     $(".slider").each(function(i, el) {
        //         var $this = $(el),
        //             $label_1 = $('<span class="ui-label"></span>'),
        //             $label_2 = $label_1.clone(),

        //             orientation = getValue($this, 'vertical', 0) != 0 ? 'vertical' : 'horizontal',

        //             prefix = getValue($this, 'prefix', ''),
        //             postfix = getValue($this, 'postfix', ''),

        //             fill = getValue($this, 'fill', ''),
        //             $fill = $(fill),

        //             step = getValue($this, 'step', 1),
        //             value = getValue($this, 'value', 5),
        //             min = getValue($this, 'min', 0),
        //             max = getValue($this, 'max', 100),
        //             min_val = getValue($this, 'min-val', 10),
        //             max_val = getValue($this, 'max-val', 90),

        //             is_range = $this.is('[data-min-val]') || $this.is('[data-max-val]'),

        //             reps = 0;


        //         // Range Slider Options
        //         if (is_range) {
        //             $this.slider({
        //                 range: true,
        //                 orientation: orientation,
        //                 min: min,
        //                 max: max,
        //                 values: [min_val, max_val],
        //                 step: step,
        //                 slide: function(e, ui) {
        //                     var min_val = (prefix ? prefix : '') + ui.values[0] + (postfix ? postfix : ''),
        //                         max_val = (prefix ? prefix : '') + ui.values[1] + (postfix ? postfix : '');

        //                     $label_1.html(min_val);
        //                     $label_2.html(max_val);

        //                     if (fill)
        //                         $fill.val(min_val + ',' + max_val);

        //                     reps++;
        //                 },
        //                 change: function(ev, ui) {
        //                     if (reps == 1) {
        //                         var min_val = (prefix ? prefix : '') + ui.values[0] + (postfix ? postfix : ''),
        //                             max_val = (prefix ? prefix : '') + ui.values[1] + (postfix ? postfix : '');

        //                         $label_1.html(min_val);
        //                         $label_2.html(max_val);

        //                         if (fill)
        //                             $fill.val(min_val + ',' + max_val);
        //                     }

        //                     reps = 0;
        //                 }
        //             });

        //             var $handles = $this.find('.ui-slider-handle');

        //             $label_1.html((prefix ? prefix : '') + min_val + (postfix ? postfix : ''));
        //             $handles.first().append($label_1);

        //             $label_2.html((prefix ? prefix : '') + max_val + (postfix ? postfix : ''));
        //             $handles.last().append($label_2);
        //         }
        //         // Normal Slider
        //         else {

        //             $this.slider({
        //                 range: getValue($this, 'basic', 0) ? false : "min",
        //                 orientation: orientation,
        //                 min: min,
        //                 max: max,
        //                 value: value,
        //                 step: step,
        //                 slide: function(ev, ui) {
        //                     var val = (prefix ? prefix : '') + ui.value + (postfix ? postfix : '');

        //                     $label_1.html(val);


        //                     if (fill)
        //                         $fill.val(val);

        //                     reps++;
        //                 },
        //                 change: function(ev, ui) {
        //                     if (reps == 1) {
        //                         var val = (prefix ? prefix : '') + ui.value + (postfix ? postfix : '');

        //                         $label_1.html(val);

        //                         if (fill)
        //                             $fill.val(val);
        //                     }

        //                     reps = 0;
        //                 }
        //             });

        //             var $handles = $this.find('.ui-slider-handle');
        //             //$fill = $('<div class="ui-fill"></div>');

        //             $label_1.html((prefix ? prefix : '') + value + (postfix ? postfix : ''));
        //             $handles.html($label_1);

        //             //$handles.parent().prepend( $fill );

        //             //$fill.width($handles.get(0).style.left);
        //         }

        //     })
        // }

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





    /*--------------------------------
        Sparkline Chart - Widgets
     --------------------------------*/
    // CMPLTADMIN_SETTINGS.widgetSparklineChart = function() {

    //     if ($.isFunction($.fn.sparkline)) {

    //         $('.wid_dynamicbar').sparkline([8.4, 9, 8.8, 8, 9.5, 9.2, 9.9, 9, 9, 8, 7, 8, 9, 8, 7, 9, 9, 9.5, 8, 9.5, 9.8], {
    //             type: 'bar',
    //             barColor: '#f5f5f5',
    //             height: '60',
    //             barWidth: '12',
    //             barSpacing: 1,
    //         });

    //         $('.wid_linesparkline').sparkline([2000, 3454, 5454, 2323, 3432, 4656, 2897, 3545, 4232, 4656, 2897, 3545, 4232, 5434, 4656, 3567, 4878, 3676, 3787], {
    //             type: 'line',
    //             width: '100%',
    //             height: '60',
    //             lineWidth: 2,
    //             lineColor: '#f5f5f5',
    //             fillColor: 'rgba(255,255,255,0.2)',
    //             highlightSpotColor: '#ffffff',
    //             highlightLineColor: '#ffffff',
    //             spotRadius: 3,
    //         });


    //         // Bar + line composite charts
    //         $('.wid_compositebar').sparkline([4, 6, 7, 7, 4, 3, 2, 4, 6, 7, 7, 8, 8, 4, 4, 3, 1, 4, 6, 5, 9], {
    //             type: 'bar',
    //             barColor: '#f5f5f5',
    //             height: '60',
    //             barWidth: '12',
    //             barSpacing: 1,
    //         });

    //         $('.wid_compositebar').sparkline([4, 1, 5, 7, 9, 9, 8, 8, 4, 7, 8, 4, 7, 9, 9, 8, 8, 4, 2, 5, 6, 7], {
    //             composite: true,
    //             fillColor: 'rgba(103,58,183,0)',
    //             type: 'line',
    //             width: '100%',
    //             height: '40',
    //             lineWidth: 2,
    //             lineColor: '#673AB7',
    //             highlightSpotColor: '#E91E63',
    //             highlightLineColor: '#673AB7',
    //             spotRadius: 3,
    //         });



    //     }

    // };








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
        //CMPLTADMIN_SETTINGS.loginPage();
    });

    // $(window).on('load', function() {
    //     CMPLTADMIN_SETTINGS.loginPage();
    // });

});