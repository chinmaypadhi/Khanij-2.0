<%@ Page Language="C#" AutoEventWireup="true" CodeFile="preview.aspx.cs" Inherits="Geology_preview" %>
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
                                        <a class="nav-link active" href="#">
                                          Preview
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div id="viewtable">
                                <table class="table table-bordered">
                            <tbody>
                            <tr>
                                <th class="font-weight-bold">FPO Code</th>
                                <th class="font-weight-bold">FPO Address</th>
                                <th class="font-weight-bold">Mineral Name</th>
                                <th class="font-weight-bold">Submition Date</th>
                                <th class="font-weight-bold">MPR Number</th>
                               
                               
                            </tr>
                                <tr>
                                     <td>Test</td>
                                    <td>Directorate of geology & mining(c.G)</td>
                                    <td>Korba</td>
                                    <td>2019-2020 (June 2021)</td>
                                     <td>201920206</td>
                                  
                                  
                                    
                                </tr>
                        </tbody>
                        </table>
                                <table class="table table-bordered">
                            <tbody>
                            <tr>
                                <th class="font-weight-bold">Assignment and its object</th>
                                <th class="font-weight-bold">Camp Address</th>
                                <th class="font-weight-bold">Village</th>
                                <th class="font-weight-bold">District</th>
                                <th class="font-weight-bold">Pin code</th>
                                <th class="font-weight-bold">Telephone No.</th>
                                <th class="font-weight-bold">Name of the Camp incharge</th>
                                 <th class="font-weight-bold">Designation</th>
                                 <th class="font-weight-bold">Date Of Commencement of the investigation</th>
                               
                            </tr>
                                <tr>
                                     <td>Dummy Text</td>
                                    <td>Dummy Text</td>
                                    <td>Dummy Text</td>
                                    <td>Dummy Text</td>
                                     <td>Dummy Text</td>
                                    <td>Dummy Text</td>
                                     <td>Dummy Text</td>
                                    <td>Dummy Text</td>
                                     <td>Dummy Text</td>
                                  
                                    
                                </tr>
                        </tbody>
                        </table>
                                <h5 class="text-brown font-weight-bold mt-0">Expenditure Incurred</h5>
                                <table class="table table-bordered">
                            <tbody>
                            <tr>
                                <th ></th>
                                <th class="font-weight-bold">(A) Up To The Last Month</th>
                                <th class="font-weight-bold">(B) During The month</th>
                               
                            </tr>
                                <tr>
                                    <td class="font-weight-bold">Expenditure Incurred</td>
                                    <td>Dummy Text</td>
                                    <td>Dummy Text</td>
                                    
                                </tr>
                        </tbody>
                        </table>
                        <h6 class="text-brown font-weight-bold mt-0">Detail of B</h6>
                        <table class="table table-bordered">
                         <thead>
                         <tr>
                         <th class="font-weight-bold">Labor (Rs.)</th>  
                          <th class="font-weight-bold">P.O.L (Rs.)</th>  
                           <th class="font-weight-bold">Repairs And Maintenance (Rs.)</th> 
                            <th class="font-weight-bold">Others (Rs.)</th> 
                             <th class="font-weight-bold">Total (Rs.)</th>  
                              </tr>  
                               </thead>                       
                                <tbody>
                                <tr> 
                                 <td></td>
                                 <td></td>                           
                                 <td></td>                           
                                 <td></td>
                                 <td></td>                      
                                 </tr>
                                 </tbody>
                                 </table>
                                <h5 class="text-brown font-weight-bold mt-0">Exploration Data <small>(In metric units)</small></h5>
                                <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th class="font-weight-bold">Progress in respect of</th>
                                    <th class="font-weight-bold">Target</th>
                                    <th class="font-weight-bold">Work done up to the last month</th>
                                    <th class="font-weight-bold">Work done during the month</th>
                                    <th class="font-weight-bold">Total work done at the end of current month</th>

                                </tr>
                            </thead>

                            <tbody><tr>
                                <td class="font-weight-bold" colspan="5"><b>A. Reconn. Geological Survey (Scale - 1:50,000)</b></td>
                            </tr>
                            <tr>
                                <td>1. Area (sq. km.)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>B. Detailed Geological Mapping (Scale - 1:4,000)</b></td>
                            </tr>
                            <tr>
                                <td >1. Area (sq. km.)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>C. Pitting</b></td>

                            </tr>
                            <tr>
                                <td>1. Nos.</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Volume (cu. m.)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>D. Trenching</b></td>

                            </tr>
                            <tr>
                                <td>1. Nos.</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Volume (cu. m.)</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>E. Drilling</b></td>

                            </tr>
                            <tr>
                                <td>1. B.h. Completed</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Metrage</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>3. B.H. Under Progress</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>4. Metrage</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>5 Total Metrage </td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold"><b>F. Geochemical Sampling</b></td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            
                            <tr>
                                <td class="font-weight-bold"><b>G. Geophysical Survey</b></td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>

                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>H. Photogeological Survey</b></td>

                            </tr>
                            <tr>
                                <td>1. Prefield Interpretation (sq. km. on scale)</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Post field Interpretation (sq. km. on scale)</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>3. Field Check (sq. km. on scale)</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>I. Sampling (Surface/Core Sample)</b></td>

                            </tr>
                            <tr>
                                <td>1. Samples Drawn</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Samples Prepared</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>3. Samples Sent For Chemical Analysis</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>4. Samples Sent For Petrography</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>J. Reserves</b></td>

                            </tr>
                            <tr>
                                <td>1. Inferred (Million Tonnes)</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Estimated (Million Tonnes)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>3. Proved (Million Tonnes)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold" colspan="5"><b>K. Topographical Survey</b></td>

                            </tr>
                            <tr>
                                <td>1. Laying Of Base Line (km.) 1:10000</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>2. Laying Of Grids (sq. km.)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td >3. No. Of Pits/B.H. Point Located</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>4. R.L./Co-ordinates Of Pits/B.H.</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>

                            <tr>
                                <td>5. Contouring (sq. km.)</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                            <tr>
                                <td>6. Plotting Of Permanent Features</td>
                                 <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>

                            <tr>
                                <td>7. Plotting Of Road/Nala (k.m.)</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                                <td>Dummy Text</td>
                            </tr>
                        </tbody></table>
                                   <h5 class="text-brown font-weight-bold mt-4">Hault at camps for officers <small>(for staffs attach separate leaf)</small></h5>    
                                   <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th class="font-weight-bold">Sl#</th>
                                    <th class="font-weight-bold">Name</th>
                                    <th class="font-weight-bold">Designation</th>
                                    <th class="font-weight-bold">From</th>
                                    <th class="font-weight-bold">To</th>
                                    <th class="font-weight-bold">No. of Days at Camps</th>
                                    <th class="font-weight-bold">Remarks, If Any</th>
                                </tr>
                            </thead>
                                <tbody>
                                <tr>
                                    <td>1</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                        </tbody></table>  
                        <h5 class="text-brown font-weight-bold mt-0">Enclosers</h5>   
                                       <table class="table table-bordered">
                            <tbody>
                            <tr>
                                <th class="font-weight-bold">Sl#</th>
                                <th class="font-weight-bold">Maps</th>
                                <th class="font-weight-bold">Borehole Logs</th>
                                <th class="font-weight-bold">Geological Description/Synopsis</th>
                                <th class="font-weight-bold">Other Information</th>
                            </tr>
                                <tr>
                                    <td>1</td>
                                    <td><a href="/KhanijTest/Geology/GeologyOperation/DowuloadMPRs" class="">N/A</a></td>
                                    <td><a href="/KhanijTest/Geology/GeologyOperation/DowuloadMPRs" class="">N/A</a></td>
                                    <td><a href="/KhanijTest/Geology/GeologyOperation/DowuloadMPRs" class="">N/A</a></td>
                                    <td><a href="/KhanijTest/Geology/GeologyOperation/DowuloadMPRs" class="">N/A</a></td>
                                </tr>
                        </tbody></table>
                                           
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
        indicateMe = "yes"
        printMe = "yes"

        $(document).ready(function () {
            loadNavigation('preview', 'glgeology', 'plmonprorep', 'tl', 'Geology', 'Monthly Progress Reports', ' ');
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



