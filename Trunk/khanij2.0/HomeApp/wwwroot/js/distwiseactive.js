hovertooltip();
$('div#distNameod h3').hide();
//Map mousehover script 
function hovertooltip() {
    for (i = 0; i < districtdetails.length; i++) {
        $('#' + districtdetails[i].district_Id).data('district', districtdetails[i]);
    }
    $('.state-map .dist-block').mouseover(function(e) {
        $('div#pop-up').show();
        $('div#distNameod .dist-name').show();
        var distid = $(this).data('district');
        $('div#distNameod .dist-name').text(distid.district_name);
        //$('div#pop-up .lesseeData').text(distid.lesseeval);
        //$('div#pop-up .dist-name span.distNm').text(distid.district_name);
        //$('div#pop-up .licenseeData').text(distid.licenseeval);
        $.ajax({
            url: '/Website/Website/ViewMineralMap',
            dataType: 'json',
            type: 'post',
            data: {
                "DistrictName": distid.district_name,
            },
            success: function (data) {
                debugger;
                $('div#distNameod .dist-name').text(data.districtName);
                $('div#pop-up .lesseeData').text(data.lesseeTotal);
                $('div#pop-up .licenseeData').text(data.licenseeTotal);
            },
            error: function (err) {
            }
        });   
    });
    $('.state-map .dist-block').mouseout(function(e) {
        $('div#distNameod .dist-name').hide();
        $('div#pop-up .lesseeData').text('0');
        $('div#pop-up .dist-name span.distNm').text('All Districts');
        $('div#pop-up .licenseeData').text('0');
    });
}