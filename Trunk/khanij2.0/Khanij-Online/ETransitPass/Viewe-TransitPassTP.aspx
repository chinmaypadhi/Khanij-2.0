<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewe-TransitPassTP.aspx.cs" Inherits="ETransitPass_Viewe_TransitPassTP" %>

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
                                         View Transit Pass-TP
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="row" id="viewtable">
                                <table class="table table-bordered">
                                <%--<thead>
                                <tr>
                                    <th></th>
                                    <th></th>
                                </tr>
                                </thead>--%>
                                 <tbody>
                                <tr>
                                    <td class="font-weight-bold">FORM-1 See Rule 4 (1) Mineral Transit Pass (for Mineral Concession Holders)</td>
                                    <td></td>
                                </tr>
                                 <tr>
                                    <td class="font-weight-bold"> District </td>
                                    <td>Bilaspur</td>
                                </tr>
                                 <tr>
                                    <td class="font-weight-bold">Issue Date Of Mineral</td>
                                    <td>19-01-2021</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Issue Time Of Mineral</td>
                                    <td> 11:50:30 AM</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">E-Permit Number</td>
                                    <td>EP_No_0017186</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">D.O.Number/Date (If Applicable)</td>
                                    <td> </td>
                                </tr>
                                 <tr>
                                    <td class="font-weight-bold">Vehicle Type</td>
                                    <td>Truck</td>
                                </tr>
                                 <tr>
                                    <td class="font-weight-bold">Vehicle No.</td>
                                    <td>CGO7CA8341</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Portal Registration No. of Vehicle</td>
                                    <td>VP63642</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">License/Lessee's Name</td>
                                    <td>Hirri Dolomite Mines , SAIL Bhilai Steel Plant Bilaspur- Area:128.770
(Pendridih(tehsil-bilha)Chtoun-2075077501 (Within State) </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">License/Mining Area Details</td>
                                    <td>CHHATAUNA / Takhatpur / Bilaspur </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Area in Hectare</td>
                                    <td>128.77 </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Lease Validity Period</td>
                                    <td>06/05/1959 to 05/05/2029 (70 Years )</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Mineral Name</td>
                                    <td>Dolomite </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Category of the Mineral being transported (Mineral form viz. lump/fines/steam/slack etc.)</td>
                                    <td>Not Applicable </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Grade</td>
                                    <td>Industrial Use (Mgo>18% or SiO2<6%) </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Sale value of the mineral (in Rs per Metric Tonne)</td>
                                    <td>Rs 1000.00 / Metric Tonne</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Tare Weight of the Vehicle</td>
                                    <td>10.48 Metric Tonne</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Gross Weight of the Vehicle</td>
                                    <td>42.00 Metric Tonne</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Net Weight of the Mineral being transported</td>
                                    <td>31.52 Metric Tonne</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Mineral Purchase/Recipient's Name</td>
                                    <td>M/s Shourya Minerals Pvt. Ltd. Unit-1Shourya Minerals pvt.ltd. Unit-2
Dy. Shree Goutam Agrawal S/o Shree Roshan Agrawal Kirodimal
Raigarh- 2222061402 (Within State) </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Owner (Vehicle) Name & Contact Number</td>
                                    <td>ANJALI LAKHOTIA (8817834905) </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Driver Name & Contact Number</td>
                                    <td>xyz ( 9658828089 ) </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Mode of Transportation</td>
                                    <td>Road </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Route</td>
                                    <td>N/A </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Destination</td>
                                    <td>Chhote Haldi Teh. pusour dist raigarh,Raigarh,Chhattisgarh - </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Other (Remarks)</td>
                                    <td>adfsdfs </td>
                                </tr>
                                </tbody>
                                </table>
                                       
                                        
                                       
                                           
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
            loadNavigation('Viewe-TransitPassTP', 'gletransitpass', 'pletrapas', 'tl', 'E-Transit pass', 'E-Transit Pass - TP', '');

        });
    </script>
    
</body>
</html>


