<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveApplicationAll.aspx.cs" Inherits="Leave_LeaveApplicationAll" %>
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
                                        <a class="nav-link active" href="LeaveApplicationAll.aspx">
                                           Leave Application All
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="LeaveApplicationCl.aspx">
                                          Leave Application Cl
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="LeaveApplicationChildCare.aspx">
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
                                    <h6 class="text-dark font-weight-bold mt-0 text-center">FORM 1(See Rule 13)</h6>
                                   <h5 class="text-brown font-weight-bold mt-0 text-center">Application for leave or for extension of leave</h5>
                                   </div>
                                   <table class="table table-borderless">
                                         <tbody>
                                                <tr>
                                                    <td class="font-weight-bolder" width="25%">Name of Applicant</td>
                                                    <td class="">Dummy Text</td>
                                                     <td class="font-weight-bolder">Leave Rule Applicable</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td class="font-weight-bolder">Post Held</td>
                                                    <td class="">Dummy Text</td>
                                                    <td class="font-weight-bolder">Office and section</td>
                                                    <td class="">Dummy Text</td>
                                                    
                                                </tr>
                                                 <tr>
                                                    <td class="font-weight-bolder" width="25%">Leave address, if granted</td>
                                                    <td class="">Dummy Text</td>
                                                    <td class="font-weight-bolder">Pay</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                
                                              
                                                
                                         </tbody>
                                   </table>
                                   <table class="table table-borderless">
                                         <tbody>
                                         <tr>
                                                    
                                                     <td class="font-weight-bolder" width="55%">House rent allowance,Conveyance allwance or other compensatory allowances drawn in the present post</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                <tr>
                                                    <td class="font-weight-bolder">Nature and period of leave applied for and date from which required</td>
                                                    <td class="">Dummy Text</td>
                                                    
                                                </tr>
                                                <tr>
                                                   
                                                     <td class="font-weight-bolder">Sunday and holidays, if any, proposed to be prefixed/suffixed to leave</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                <tr>
                                                    <td class="font-weight-bolder">Ground on which leave is applied for</td>
                                                    <td class="">Dummy Text</td>
                                                     
                                                </tr>
                                                 <tr>
                                                    
                                                     <td class="font-weight-bolder">Date of return from last leave, and the nature and period of that leave</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                         </tbody>
                                   </table>
                                   <table class="table table-borderless">
                                         <tbody>
                                                 <tr>
                                                    
                                                     <td class="font-weight-bolder text-brown">I propose/do not propose to avail myself of leave travel concession for the block years during the ensuing leave :</td>
                                                     
                                                </tr>
                                         </tbody>
                                   </table>
                                   <table class="table table-borderless">
                                         <tbody>
                                                 <tr>
                                                     <td width="30%" class="font-weight-bolder ">Signature of applicant(with date) and Designation</td>
                                                     <td class="">Signature</td>
                                                </tr>
                                         </tbody>
                                   </table> 
                                   <table class="table table-borderless">
                                         <tbody>
                                                 <tr>
                                                    
                                                     <td class="font-weight-bolder text-brown">Remark and/or recommendation of the controlling officer :</td>
                                                     
                                                </tr>
                                         </tbody>
                                   </table>
                                   <table class="table table-borderless">
                                         <tbody>
                                                 <tr>
                                                     <td class="font-weight-bolder"  width="30%">Signature of applicant(with date) and Designation</td>
                                                     <td class="">Signature</td>
                                                </tr>
                                         </tbody>
                                   </table>
                                    <table class="table table-borderless">
                                         <tbody>
                                                 <tr>
                                                    
                                                     <td class="font-weight-bolder text-brown">Orders of the sanctioning authority :</td>
                                                     
                                                </tr>
                                         </tbody>
                                   </table>
                                   <table class="table table-borderless">
                                         <tbody>
                                                 <tr>
                                                     <td class="font-weight-bolder"  width="30%">Signature (with date)</td>
                                                    <td class="">Signature</td>
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
            loadNavigation('LeaveApplicationAll', 'glholiday', 'plleaveapp', 'tl', 'Leave', 'Apply Application ', ' ');
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




