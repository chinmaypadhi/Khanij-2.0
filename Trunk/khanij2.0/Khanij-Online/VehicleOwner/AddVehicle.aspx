<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddVehicle.aspx.vb" Inherits="VehicleOwner_AddVehicle" %>

<!DOCTYPE html>

<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" media="screen" />
    <%--    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />--%>
    <link rel="stylesheet" href="../css/pace-theme-flash.css" media="screen" />
    <link rel="stylesheet" href="../css/all.min.css" />
    <link rel="stylesheet" href="../css/perfect-scrollbar.css" />
    <link rel="stylesheet" href="../css/style.css" type="text/css" />
    <link rel="alternate stylesheet" media="screen" title="infotheme" href="../css/theme-info.css" />
    <link rel="alternate stylesheet" media="screen" title="greentheme" href="../css/theme-success.css" />
    <link rel="alternate stylesheet" media="screen" title="orangetheme" href="../css/theme-warning.css" />
    <link rel="alternate stylesheet" media="screen" title="purpletheme" href="../css/theme-secondary.css" />
    <link rel="alternate stylesheet" media="screen" title="redtheme" href="../css/theme-danger.css" />
    <script src="../js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:navbar runat="server" ID="navbar" />
        <!-- END TOPBAR -->
        <!-- START CONTAINER -->
        <div class="page-container row-fluid container-fluid">
            <!-- SIDEBAR - START -->
            <div class="page-sidebar fixedscroll">
                <!-- MAIN MENU - START -->
                <uc1:leftsider runat="server" ID="leftsider" />
                <!-- MAIN MENU - END -->
            </div>
            <!--  SIDEBAR - END -->
            <!-- START CONTENT -->
            <div id="main-content">
                <section class="wrapper main-wrapper row">
                    <div class="col-12">
                        <uc1:navigation runat="server" ID="navigation" />
                        <!-- MAIN CONTENT AREA STARTS -->
                        <div class="row">
                            <div class="col-12">
                                <div class="main-tab">
                                    <ul class="nav nav-tabs">
                                        <li class="nav-item">
                                            <a class="nav-link active" href="javascript:void(0);">Vehicle Registration Form
                                            </a>
                                        </li>
                                    </ul>
                                    <uc1:util runat="server" ID="util" />
                                </div>

                                <section class="box form-container">
                                    <div class="content-body">

                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Type<span class="text-danger">*</span></label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control form-control-sm searchableselect">
                                                            <option>Select VehicleType</option>
                                                        </select>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Number <span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <input type="text" value="" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Carrying Capacity <span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <input type="text" value="" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Carrying Capacity Unit<span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <input type="text" value="" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Tare Weight<span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <input type="text" value="1234567890" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label class="col-sm-4 col-form-label font-weight-bolder">Vehicle Tare Unit<span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <select class="form-control form-control-sm searchableselect">
                                                            <option>Select Unit</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="dropdownDepart" class="col-sm-4 col-form-label font-weight-bolder">RC Book Copy (RC card copy is not valid)<span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <input type="file" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Permit Copy<span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <input type="file" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="form-group row">
                                                    <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">GPS Enabled<span class="text-danger">*</span></label>
                                                    <div class="col-sm-7">
                                                        <div class="custom-control custom-radio custom-control-inline">
                                                            <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1" />
                                                            <label class="custom-control-label" for="radio1">Yes</label>
                                                        </div>
                                                        <div class="custom-control custom-radio custom-control-inline">
                                                            <input type="radio" class="custom-control-input" id="radio2" checked="checked" name="radio-iRequirement" value="2" />
                                                            <label class="custom-control-label" for="radio2">No</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div style="color: red;">
                                                    Note :1)Tare weight captured here will be used while generation of e-transit pass.
2)Please upload certified paper (RC) showing the tare weight & carrying capacity.
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="form-group row">

                                                    <div class="col-sm-12">
                                                        <input type="checkbox" />घोषणा - में यह घोषणा करता हु की ऊपर दी गयी समस्त जानकारी मेरी जानकारी एवं विश्वास के अनुसार सत्य है। मुझे ज्ञात है की उक्त कोई जानकारी गलत अथवा असत्य पाए जाने पर उपयुक्त नियमो के तहत जुर्माना /दण्ड हो सकता है
खनिज संसाधन विभाग उपर्युक्त किसी भी जानकारी की प्रमाणिकता के लिए उत्तरदायी नहीं होगा !
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6"></div>
                                            <div class="col-sm-6">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Save</a>
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Save & Add Another Vehicle</a>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                    <!-- MAIN CONTENT AREA ENDS -->
                </section>
                <uc1:footer runat="server" ID="footer" />
            </div>
            <!-- END CONTENT -->
        </div>
        <!-- END CONTAINER -->
    </form>


    <!-- alert 1-->






    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('Addstate', 'glTMng', 'plstate', 'tl', 'Masters', 'State', '');


        });
    </script>
</body>
</html>
