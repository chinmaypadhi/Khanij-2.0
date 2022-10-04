<%@ Page Language="C#" AutoEventWireup="true" CodeFile="savgenerate.aspx.cs" Inherits="Epermitlicensee_savgenerate" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta content="khanij mineral automation system" name="description" />
    <meta content="khanij mineral automation system" name="author" />
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
                                    <li class="nav-item">
                                        <a class="nav-link active" href="newapplication.aspx">
                                            Generate
                                        </a>
                                    </li>
                                  
                                   
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                               
                                    
<div class="content-body pt-0">
                                                            <div id="viewtable" >
                                                             <h5 class=" text-brown font-weight-bold pt-3">e-Permit for the Coal</h5>

                                <table class="table table-bordered">
                                 <tbody>
                                <tr>
                                    <td class="font-weight-bold">Name of License</td>
                                    <td>M/s Phil Coal Beneficiation Pvt. Ltd</td>
                                    <td class="font-weight-bold">Address</td>
                                    <td>Phil Coal Benefication Pvt. Ltd. Villege- Ghutku , Tehsil- Takhatpur Dist-Bilashpur Chhatissgarh.495001</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Grant Order Number</td>
                                    <td>517/22.08.2018</td>
                                    <td class="font-weight-bold">Grant Order Date</td>
                                    <td>22/08/2019</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">e-Permit No.</td>
                                    <td></td>
                                   
                                </tr>
                              
                               
                              
                                
                                
                               
                              
                                
                                
                                
                                 <tr>
                                    <td class="text-brown h5" colspan="4">Licensee Information</td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">Village</td>
                                    <td>Chhatauna</td>
                                     <td class="font-weight-bold">Tehsil</td>
                                    <td>Takhatpur</td>
                                </tr>
                                 <tr>
                                     <td class="font-weight-bold">  Police Station</td>
                                    <td>chakarbhatha </td>
                                    <td class="font-weight-bold">Panchayat</td>
                                    <td>Chhatauna</td>
                                </tr>
                                <tr>
                                     <td class="font-weight-bold">District</td>
                                    <td>Bilaspur </td>
                               
                                     <td class="font-weight-bold">Mineral Name</td>
                                    <td>Coal </td>
                                </tr>
                                 <tr>
                                     <td class="font-weight-bold">Mineral Grade</td>
                                    <td>ROM- G10 (Above 4301 to 4600 GCV/Killo Calories)</td>
                                
                                     <td class="font-weight-bold">Mineral Form</td>
                                    <td>Non Coking-ROM</td>
                                </tr>
                                
                                 <tr>
                                     <td class="font-weight-bold">Available Quantity in Stock (MT)</td>
                                    <td>60.15</td>
                                
                                     <td class="font-weight-bold">Quantity to be Dispatched (MT)</td>
                                    <td>10.00</td>
                                </tr>
                                 <tr>
                                     <td class="font-weight-bold">   Generated Date and Time</td>
                                    <td>28-05-2021 04:11:14 PM</td>
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
   
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
<script src="../js/dataTables.bootstrap4.min.js"></script>
<link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <script>

        pdfMe = "yes"
        backMe = "yes"

        $(document).ready(function () {

            loadNavigation('savgenerate', 'glepermitlicensee', 'apply', 'tl', 'e-permit', 'Apply e-permit', ' ');
            $('.searchableselect').searchableselect();

            $('#datatable').DataTable();


            $('.shorting-lnk').click(function () {
                $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
            });

        });
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
</body>
</html>









