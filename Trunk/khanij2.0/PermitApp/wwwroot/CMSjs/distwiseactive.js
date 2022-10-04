// function BindColorheatmap() {

//     for (j = 0; j < districtdetails.length; j++) {
//         $('#' + districtdetails[j].district_Id).data('district', districtdetails[j]);
//         if (districtdetails[j].positival == 0) {

//             $('.heatmap #' + districtdetails[j].district_Id).addClass("bg-scale1");
//             $('.heatmap .distpj_' + districtdetails[j].district_Id).text("");
//         } else if (districtdetails[j].positival > 0 && districtdetails[j].positival <= 10) {
//             $('.heatmap #' + districtdetails[j].district_Id).addClass("bg-scale2");
//             $('.heatmap .distpj_' + districtdetails[j].district_Id).text(districtdetails[j].positival);
//         } else if (districtdetails[j].positival > 10 && districtdetails[j].positival <= 30) {
//             $('.heatmap #' + districtdetails[j].district_Id).addClass("bg-scale3");
//             $('.heatmap .distpj_' + districtdetails[j].district_Id).text(districtdetails[j].positival);
//         } else {
//             $('.heatmap #' + districtdetails[j].district_Id).addClass("bg-scale4");
//             $('.heatmap .distpj_' + districtdetails[j].district_Id).text(districtdetails[j].positival);

//         }



//     }


// }

// setTimeout(function() {

//     BindColorheatmap()

// }, 100);

hovertooltip();

$('div#distNameod h3').hide();
//Map mousehover script 

function hovertooltip() {
    //$(function () {
    //alert('ok');

    for (i = 0; i < districtdetails.length; i++) {
        $('#' + districtdetails[i].district_Id).data('district', districtdetails[i]);
    }





    //alert(distid);
    //alert('ok1');
    $('.state-map .dist-block').mouseover(function(e) {
        //alert(0)
        $('div#pop-up').show();
        $('div#distNameod .dist-name').show();
        //alert('ok2'); 
        var distid = $(this).data('district');
        //$('div#distNameod h3').text(distid.district_name+" District");
        $('div#distNameod .dist-name').text(distid.district_name);
        //$('div#pop-up h3').text('District -' + distid.district_name);
        $('div#pop-up .lesseeData').text(distid.lesseeval);
        $('div#pop-up .dist-name span.distNm').text(distid.district_name);
        // $('div#pop-up h3 span.distNm').text(distid.district_name+" District");
        $('div#pop-up .licenseeData').text(distid.licenseeval);
        //$('div#pop-up h4.recoverCase').text(distid.curedvalue);
        //$('div#pop-up h4.deceasedCase').text(distid.deceasedvalue);
        //$(this).parent().find('.dist-block').removeClass('.active');
        //$(this).addClass('.active');

    });

    //$('.state-map .dist-block').click(function(e) {
    $('.state-map .dist-block').mouseout(function(e) {
        //alert(1)
        //$('div#pop-up').hide();
        $('div#distNameod .dist-name').hide();
        //$('div#pop-up .dist-name').text('District ');
        $('div#pop-up .lesseeData').text('0');
        $('div#pop-up .dist-name span.distNm').text('All Districts');
        $('div#pop-up .licenseeData').text('0');
        // $('div#pop-up h4.recoverCase').text('18 ');
        // $('div#pop-up h4.deceasedCase').text('01');
        //$(this).removeClass('.active');

    });



}