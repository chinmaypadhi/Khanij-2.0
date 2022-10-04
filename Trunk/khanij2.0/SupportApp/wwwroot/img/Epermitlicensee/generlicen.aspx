<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generlicen.aspx.cs" Inherits="Epermitlicensee_generlicen" %>
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
                                                                    <a class="nav-link " href="applyrtplice.aspx">
                                                                     Apply New Application
                                                                    </a>
                                                                </li>
                                                                 <li class="nav-item">
                                                                    <a class="nav-link active" href="generlicen.aspx">
                                                                      Generated RTP Application
                                                                    </a>
                                                                </li>
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                         <div class="searchform ">
                                       <div class="row">
                                                    <label  class="col-lg-2 col-md-5 col-sm-12 col-form-label form-group">e-permit Number</label>
                                                    <div class="col-lg-2 col-md-5 col-sm-12 form-group">
                                                      <input type="text" class="form-control">
                                                    </div>
                                               
                                               
                                                    <label  class="col-lg-2 col-md-5 col-sm-12 col-form-label form-group">Mineral Form </label>
                                                    <div class="col-lg-2 col-md-5 col-sm-12 form-group">
                                                       <select class="form-control">
                                                           <option>Select</option>
                                                       </select>
                                                    </div>
                                               
                                           
                                                    <div class="col-md-2 mt-md-0 mt-3">
                                                        <a href="#" class="btn btn-md btn-success m-0 waves-effect waves-light" data-original-title="" title=""> Show </a>
                                                    </div>
                                    
                                        </div>
                                      
                                  </div>
                                  
                                                            <div class="content-body">
                                  
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive" id="viewtable">
                                                <table id="datatable" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                            
                                                            <th>E-Permit No.</th>
                                                            <th>RTP Application</th>
                                                            <th>Mineral Name</th>
                                                            <th>Mineral Form</th>
                                                            <th>Mineral Grade</th>
                                                            <th>RTP Application Qty (MT)</th>
                                                            <th>Dispatched Qty (MT)</th>
                                                            <th>RTP Generated Qty (MT)</th>
                                                            <th>Transportation Mode</th>
                                                            <th>Purchaser/Consignee</th>
                                                            <th>EDRM</th>
                                                            <th width="200px" class="text-center" >Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr >
                                                           
                                                            <td>BL_RPTP_0021706</td>
                                                            <td>
                                                                <a href="rtpapplview1.aspx">RTP_APP_0020446</a> <br />
                                                                <span><i class="far fa-calendar-alt mr-2"></i> 24/11/2020</span> <br />
                                                                 <span><i class="fas fa-clock mr-2"></i>01:05:47</span>
                                                            </td>
                                                            <td>Coal</td>
                                                            <td>Fines</td>
                                                            <td>Washed- G11(Above 4001 to 4300 GCV/Killo Calories)</td>
                                                            <td class="text-right">4014.2</td>
                                                            <td class="text-right">4014.2</td>
                                                            <td class="text-right">4014.2</td>
                                                            <td>	Inside Railway Siding</td>
                                                            <td>Jaiprakash Power Ventures Limited, (Unit. Jaypee Bina Thermal Power Plant)</td>
                                                            <td>CMP/BSP/CORE(ELC)/MP/PCPB/PCPB/LNK/09-2020/61(A)
                                                            <a href="javascript:void(0);" class="btn-floating btn-outline-primary btn-sm waves-effect waves-light" data-original-title="" title=""><i class="fas fa-download"></i></a> <br />
                                                             <span><i class="far fa-calendar-alt mr-2"></i> 10/11/2020</span> </td>
                                                           <td class="text-center">
                                                                    <a href="#"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    title="close">Close RTP</a>
                                                            </td>
                                                           
                                                        </tr>
                                                      
                                                        
                                                    </tbody>
                                                </table>
                                            </div>
                                            
                                            
                                        </div>
                                    </div>
                                     </div>
                                                      
                                                           
                                                         </section>
                                                        </div>
                                                        </div>
                                                        </div>
                                                        </section>
                                                    </div>
                                                </div>
                                            
                                         
                                       
                                        <uc1:footer runat="server" ID="footer" />
                                  
                                  
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
    $(document).ready(function () {
	    $('.datepicker').datetimepicker({
		    format: 'LT',
		    format: 'DD-MM-YYYY',
		    daysOfWeekDisabled: [0, 6],
	    });
        	
    });
    </script>                        
<script>
    $(document).ready(function () {
        loadNavigation('generlicen', 'glepermitlicensee', 'applyrtp', 'tl', 'e-permit', 'Apply e-permit', ' ');
        $('.searchableselect').searchableselect();
        $('.searchableselect').searchableselect();

        $('#datatable').DataTable();

        $('.shorting-lnk').click(function () {
            $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
        });
    });
</script>
</body>

</html>




