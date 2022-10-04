<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveApplicationCl.aspx.cs" Inherits="Leave_LeaveApplicationCl" %>
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
                                        <a class="nav-link " href="LeaveApplicationAll.aspx">
                                           Leave Application All
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link active" href="LeaveApplicationCl.aspx">
                                          Leave Application Cl
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link " href="LeaveApplicationChildCare.aspx">
                                          Leave Application Child Care
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div id="viewtable">
                                    <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                   
                                   <h5 class="text-brown font-weight-bold mt-0 text-center">Application for CL leave</h5>
                                   </div>
                                   <table class="table table-borderless">
                                         <tbody>
                                                <tr>
                                                    <td class="font-weight-bolder">To,</td>
                                                </tr>
                                                <tr> 
                                                     <td class="font-weight-bolder pt-0 pr-0 pb-0 pl-5">Address,</td>
                                                </tr>
                                                 <tr> 
                                                     <td class="font-weight-bolder pt-0 pr-0 pb-0 pl-5">Address Address Address,</td>
                                                </tr>
                                                 <tr> 
                                                     <td class="font-weight-bolder pt-0 pr-0 pb-0 pl-5">Address Address Address Address Address</td>
                                                </tr>
                                                
                                         </tbody>
                                   </table>
                                   <table class="table table-borderless">
                                         <tbody>
                                                
                                                 <tr> 
                                                     <td class="font-weight-bolder pb-0">Subject:- Application For Leave</td>
                                                </tr>
                                                <tr>
                                                    <td class="font-weight-bolder pb-0">Dear,</td>
                                                </tr>
                                                <tr> 
                                                     <td class="pl-5">I am <span style="border-bottom:2px dotted #ddd;font-weight:600;">Your Name</span>,
                                                      student of <span style="border-bottom:2px dotted #ddd;font-weight:600;">Class And Section</span>.
                                                       I would like to bring to your kind attention that due to  
                                                       <span style="border-bottom:2px dotted #ddd;font-weight:600;">Mention your reason</span>
                                                        I will unable to come to school for next <span style="border-bottom:2px dotted #ddd;font-weight:600;">(Number Of Days)</span>.
                                                     </td>
                                                </tr>
                                         </tbody>
                                   </table>
                                  
                                    <table class="table table-borderless">
                                         <tbody>
                                                <tr>
                                                    <td class="font-weight-bolder">Date :-</td>
                                                    <td width="70%">Dummy Text</td>
                                                    <td class="font-weight-bolder">Signature :-</td>
                                                    <td>Dummy Text</td>
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
   
    <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>






    <script>
        printMe = "yes"

        $(document).ready(function () {
            loadNavigation('LeaveApplicationCl', 'glholiday', 'plleaveapp', 'tl', 'Leave', 'Apply Application ', ' ');
            $('.searchableselect').searchableselect();


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






