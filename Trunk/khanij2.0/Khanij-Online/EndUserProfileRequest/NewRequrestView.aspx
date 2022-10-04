<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewRequrestView.aspx.cs" Inherits="EndUserProfileRequest_NewRequrestView" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" media="screen" />
    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />
    <link rel="stylesheet" href="../css/pace-theme-flash.css" media="screen" />
    <link rel="stylesheet" href="../css/all.min.css" />
    <link rel="stylesheet" href="../css/perfect-scrollbar.css" />   
    <link rel="stylesheet" href="../css/style.css"  type="text/css" />
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
                                    <li class="nav-item mr-md-1">
                                        <a class="nav-link active" href="#">
                                          User Request For Profile Verification
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label class="col-sm-5 col-form-label font-weight-bolder">Registration Type</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Industry</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-5 col-form-label font-weight-bolder">Industry Type</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Sponge Iron Plant</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-5 col-form-label font-weight-bolder">Registration No</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>EUP20201210001</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">User Type</label>
                                                <div class="col-sm-7">
                                                   <label class="form-control-plaintext"><span class="colon">:</span>Company</label>                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-5 col-form-label font-weight-bolder">Company as</label>
                                                <div class="col-sm-7">
                                                     <label class="form-control-plaintext"><span class="colon">:</span>Private</label>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-5 col-form-label font-weight-bolder">Applicant's Name</label>
                                                <div class="col-sm-7">
                                                     <label class="form-control-plaintext"><span class="colon">:</span>SUMITRA SHAH</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="dropdownState" class="col-sm-5 col-form-label font-weight-bolder">E-mail ID</label>
                                                <div class="col-sm-7">
                                                     <label class="form-control-plaintext"><span class="colon">:</span>ngipljsg@gmail.com</label>                                                  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-5 col-form-label font-weight-bolder">Mobile Number</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>9937561934</label>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMobile" class="col-sm-5 col-form-label font-weight-bolder">Designation</label>
                                                <div class="col-sm-7">
                                                       <label class="form-control-plaintext"><span class="colon">:</span>DIRECTOR</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Mineral Name</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Coal,Dolomite</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Use Of The Mineral</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>For self consumption</label>
                                                </div>
                                            </div>
                                        </div>
                                       
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Purpose</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Captive</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">PAN Card Number</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>AABCJ2835N</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Upload PAN Card</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span><a href="#" class="text-decoration-underline">View</a></label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Tin Number</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>21451705011</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Upload Document for Tin</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span><a href="#" class="text-decoration-underline">View</a></label>
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">GST Number</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>21AABCJ2835N1ZM</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Upload Document for GST</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span><a href="#" class="text-decoration-underline">View</a></label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder"> Firm / Company registration copy</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span><a href="#" class="text-decoration-underline">View</a></label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Name of the Individual/Firm/Society/Partnership/Company</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>JAI HANUMAN UDYOG LIMITED</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Excise Duty Registration Number</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>AABCJ2835NXM001</label>
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Electricity Bill of last 3 months</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span><a href="#" class="text-decoration-underline">View</a></label>
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO (Consent To Operate) Letter</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>AABCJ2835NXM001</label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Approval Number</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>3497/IND-I-CON-5137</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Order Date</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>19-03-2020 00:00:00</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Validity From</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>01-04-2020 00:00:00</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-4">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Validity To</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>31-03-2021 00:00:00</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">IBM Registration No</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>IBM/6438/2011</label>
                                                </div>
                                            </div>
                                        </div>
                                        

                                   <h5 class="w-100 pl-3 text-primary">Plant Details</h5>

                                    <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-1 col-form-label font-weight-bolder">Address</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>AT-RAGHUNATHPALI P/S-KOLABIRA DIST-JHARSUGUDA</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class=" row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">State</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Odisha</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class=" row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">District</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Jharsuguda</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class=" row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Pincode</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>768213</label>
                                                </div>
                                            </div>
                                        </div>

                                        <h5 class="w-100 pl-3 text-primary">Office Details</h5>

                                         <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-1 col-form-label font-weight-bolder">Address</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>AT-RAGHUNATHPALI P/S-KOLABIRA DIST-JHARSUGUDA</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">State</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Odisha</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">District</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Jharsuguda</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Pincode</label>
                                                <div class="col-sm-7">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>768213</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-1 col-form-label font-weight-bolder">Mineral Form</label>
                                                <div class="col-sm-11">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Non Coking-ROM,Non Coking-ROM,Non Coking-ROM,Non Coking-ROM,Non Coking-ROM,Not Applicable,Non Coking-ROM,Non Coking-ROM,Non Coking-ROM,Non Coking-ROM,Non Coking-ROM,Non Coking-ROM</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-1 col-form-label font-weight-bolder">Mineral Grade</label>
                                                <div class="col-sm-11">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>ROM- G4 (Above 6101 to 6400 GCV/Killo Calories),ROM- G11 (Above 4001 to 4300 GCV/Killo Calories),ROM- G8 (Above 4901 to 5200 GCV/Killo Calories),ROM- G10 (Above 4301 to 4600 GCV/Killo Calories),ROM- G5 (Above 5801 to 6100 GCV/Killo Calories),Industrial Use (Mgo>18% or SiO2<6%) ,ROM- G12 (Above 3701 to 4000 GCV/Killo Calories),ROM- G13 (Above 3401 to 3700 GCV/Killo Calories),ROM- G14 (Above 3101 to 3400 GCV/Killo Calories),ROM - G7 (Above 5201 to 5500 GCV/Killo Calories),ROM- G6 (Above 5501 to 5800 GCV/Killo Calories),ROM- G9 (Above 4601 to 4900 GCV/Killo Calories)</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-1 col-form-label font-weight-bolder">Enter Remarks</label>
                                                <div class="col-sm-11">
                                                    <textarea class="form-control" rows="2"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        
                                       
                                            <div class="col-sm-6 offset-sm-1">
                                                <a href="javascript:void(0);" class="btn btn-success btn-md ml-0 waves-effect waves-light" data-toggle="modal" data-target=".alert-modal">Approve</a>
                                                <a href="#" class="btn btn-danger btn-md waves-effect waves-light">Reject</a>
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

    <script>

        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"
        downloadMe = "yes"
        backMe = "yes"

        $(document).ready(function () {
            loadNavigation('NewRequrestView', 'gldashboard', 'pl', 'tl', 'Dashboard', 'End User Profile Request', '');

        });
    </script>
    
</body>
</html>


