<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveApplicationChildCare.aspx.cs" Inherits="Leave_LeaveApplicationChildCare" %>
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
                                        <a class="nav-link" href="LeaveApplicationCl.aspx">
                                          Leave Application Cl
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="LeaveApplicationChildCare.aspx">
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
                                    <h6 class="text-dark font-weight-bold mt-0 text-center">FORM 1A(See Rule 13)</h6>
                                   <h5 class="text-brown font-weight-bold mt-0 text-center">Application for child care leave</h5>
                                   </div>
                                    <table class="table table-borderless mb-0">
                                         <tbody>
                                                <tr>
                                                    <td class="font-weight-bolder">1. Name of Applicant</td>
                                                    <td class="">Dummy Text</td>
                                                   
                                                </tr>
                                                <tr>
                                                    
                                                     <td class="font-weight-bolder">2. Designation</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td class="font-weight-bolder">3. Department/Office/section</td>
                                                    <td class="">Dummy Text</td>
                                                    
                                                    
                                                </tr>
                                                <tr>
                                                    
                                                    <td class="font-weight-bolder">4. Name of child for whome child care leave is applied for</td>
                                                    <td class="">Dummy Text</td>
                                                    
                                                </tr>
                                                 <tr>
                                                    <td class="font-weight-bolder">5. Date of Birth of the child(Attach birth certificate)</td>
                                                    <td class="">Dummy Text</td>
                                                   
                                                </tr>
                                                 <tr>
                                                    
                                                    <td class="font-weight-bolder">6. Date on which child will be attainning 18 years</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                
                                              
                                         
                                              <tr>
                                                    
                                                     <td class="font-weight-bolder">7. Is the child among the two eldest children</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                <tr>
                                                    <td class="font-weight-bolder">8. EL in credit(as on date of application)</td>
                                                    <td class="">Dummy Text</td>
                                                    
                                                </tr>
                                                <tr>
                                                   
                                                     <td class="font-weight-bolder">9. Period of Leave Days(Prefix/Suffixof holiday, if any)</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                <tr>
                                                    <td class="font-weight-bolder">10. Reasons for leave applied for</td>
                                                    <td class="">Dummy Text</td>
                                                     
                                                </tr>
                                                 <tr>
                                                    
                                                     <td class="font-weight-bolder">11. Total child care Leave availed till date</td>
                                                    <td class="">Dummy Text</td>
                                                </tr>
                                                <tr>
                                                    
                                                     <td class="font-weight-bolder">12. (a) Wether Permission to leave headquaters is required</td>
                                                     <td class="">Yes/No</td>
                                                </tr>
                                                <tr>
                                                     <td class="font-weight-bolder">12. (b)If, Yes Address during leave period</td>
                                                     <td class="">Dummy Text</td>
                                                </tr>
                                                <tr>
                                                     <td class="font-weight-bolder">13. Date of return from last leave, nature and period of that leave</td>
                                                     <td class="">Dummy Text</td>
                                                </tr>
                                         </tbody>
                                   
                                  
                                   
                                  
                                   <table class="table table-borderless mb-0">
                                         <tbody>
                                                 <tr>
                                                     <td class="font-weight-bolder" width="32%" >Date:</td>
                                                     <td class="">Dummy Text</td>
                                                
                                                     <td class="font-weight-bolder" >Signature of applicant:</td>
                                                     <td class="">Dummy Text</td>
                                                     
                                                </tr>
                                                <tr>
                                                 
                                                     <td class="font-weight-bolder">Employee Code No.:</td>
                                                     <td class="">Dummy Text</td>
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
            loadNavigation('LeaveApplicationChildCare', 'glholiday', 'plleaveapp', 'tl', 'Leave', 'Apply Application ', ' ');
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





