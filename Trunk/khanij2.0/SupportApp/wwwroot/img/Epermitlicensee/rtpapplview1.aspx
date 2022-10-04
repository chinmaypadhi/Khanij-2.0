<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rtpapplview1.aspx.cs" Inherits="Epermitlicensee_rtpapplview1" %>



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
                                                                    <a class="nav-link active" href="#">
                                                                      Generated RTP Application
                                                                    </a>
                                                                </li>
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                        
                                                            <div class="content-body pt-0">
                                                            <div id="viewtable" >
                                                            <h5 class=" text-brown font-weight-bold pt-3">Application for Railway Transit Pass</h5>
                                                            <div class="table-responsive">
                                                                    <table class="table table-bordered">
                                 <tbody>
                                <tr>
                                    <td class="font-weight-bold">Name and address of mineral sender</td>
                                    <td colspan="3">M/s Phil Coal Beneficiation Pvt. Ltd (2072055202)
                                        Phil Coal Benefication Pvt. Ltd. Villege- Ghutku , Tehsil- Takhatpur Dist-Bilashpur Chhatissgarh.495001</td>
                                    
                                </tr>
                                <tr>
                                <td class="font-weight-bold">Name and address of mineral receiver</td>
                                    <td colspan="3">Jaiprakash Power Ventures Limited, (Unit. Jaypee Bina Thermal Power Plant) (35570001546)
                                        RAJIV NAGAR, POST BOX NO.1 (Sub P.O.:AGASOD TEHSIL & P.O. BINA DISTRICT; SAGAR (M.P.) PIN CODE:470113</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">E-Permit Number</td>
                                    <td>BL_RPTP_0021706</td>
                                    <td class="font-weight-bold">Name of the mineral</td>
                                    <td>Coal</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">EDRM Number</td>
                                    <td>CMP/BSP/CORE(ELC)/MP/PCPB/PCPB/LNK/09-2020/61(A)</td>
                                    <td class="font-weight-bold">EDRM Date</td>
                                    <td>10/11/2020</td>
                                </tr>
                              
                               
                                <tr>
                                    <td class="font-weight-bold">EDRM Copy(Upload Scanned Copy)</td>
                                    <td></td>
                                    <td class="font-weight-bold">Quantity of Mineral (Tonne) in EDRM</td>
                                    <td>4014.20 </td>
                                </tr>
                                
                                <tr>
                                    <td class="font-weight-bold">Quantity of Mineral (Tonne)</td>
                                    <td>4014.20</td>
                                    <td class="font-weight-bold">Name and address of railway siding from where the mineral will be loaded</td>
                                    <td>PMBG-PHIL MINERALS BENIFICATION AND ENERGY PVT. LTD.</td>
                                </tr>

                                <tr>
                                    <td class="font-weight-bold">Name and address of destination railway siding</td>
                                    <td>JBTS-JAIPRAKASH ASSOCIATE BINA</td>
                                    <td class="font-weight-bold">Date</td>
                                    <td>19-05-2021</td>
                                </tr>
                                
                                 
                                <tr>
                                    <td class="font-weight-bold">Time</td>
                                    <td>17:30</td>
                                     <td class="font-weight-bold">Place</td>
                                    <td>Phil Coal Benefication Pvt. Ltd. Villege- Ghutku , Tehsil- Takhatpur Dist-Bilashpur Chhatissgarh.495001</td>
                                </tr>

                                 <tr>
                                     <td class="font-weight-bold">Signature</td>
                                     <td colspan="3"></td>
                                </tr>
                                
                               
                                
                               
                                </tbody>
                                </table>
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
    printMe = "yes"
    backMe = "yes"
    $(document).ready(function () {
       
        loadNavigation('rtpapplview1', 'glepermitlicensee', 'applyrtp', 'tl', 'e-permit', 'Apply e-permit', ' ');

    });
</script>
</body>

</html>





