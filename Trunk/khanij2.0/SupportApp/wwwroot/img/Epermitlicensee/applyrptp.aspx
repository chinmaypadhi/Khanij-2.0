<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyrptp.aspx.cs" Inherits="Epermitlicensee_applyrptp" %>
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
                                                                    <a class="nav-link active" href="newapplication.aspx">
                                                                    Apply RPTP
                                                                    </a>
                                                                </li>
                                                                
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>
                                                         <section class="box form-container">
                                                            <div class="content-body">
                                                            <div class="row">
                                                            
                                                                <div class="col-lg-9 col-md-12 col-sm-12">
                                                                 <h5 class="text-brown font-weight-bold mt-0">New Application</h5>
                                                       <div class="row">
                                                           
                                                           
                                                            <div class="col-lg-4 col-md-6 col-sm-12  form-group">
                                                                 <label class="col-form-label font-weight-bolder">Mineral Name<span class="text-danger">*</span></label>
                                                                 <select class="form-control  searchableselect ">
                                                                    <option>Select</option>
                                                                    <option>Agate</option>
                                                                    <option>Dolomite</option>
                                                                 </select>
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                                <label class="col-form-label font-weight-bolder">Mineral Form<span class="text-danger">*</span></label>
                                                                <select class="form-control  searchableselect ">
                                                                    <option>Select</option>
                                                                    <option>ROM</option>
                                                                    <option>Fines</option>
                                                                    <option>Lumps</option>
                                                                 </select>
                                                            </div>
                                                      
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                               <label class="col-form-label font-weight-bolder">Mineral Grade<span class="text-danger">*</span></label>
                                                                 <select class="form-control  searchableselect">
                                                                        <option>Select</option>
                                                                        <option>Industrial Use (Mgo&gt;18% or SiO2&lt;6%) </option>
                                                                        
                                                                 </select>
                                                            </div>
                                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Quantity<span class="text-danger">*</span> </label>
                                                                  <input type="text" class="form-control form-group">
                                                            </div>
                                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                                <label class="col-form-label font-weight-bolder">Unit<span class="text-danger">*</span></label>
                                                                 <select class="form-control ">
                                                                    <option>Select</option>
                                                                    <option>Metric Tonne</option>
                                                                 </select>
                                                               
                                                            </div>
                                                            
                                                       
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Available Quantity in Stock (MT)</label>
                                                                  <input type="text" class="form-control form-group" value="60.150" readonly>
                                                            </div>
                                                       </div>
                                                       <div class="row ">
                                                           <div class="col-sm-12 mt-4">
                                                             
                                                               <a href="savgenerate.aspx" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit And Preview</a>
                                                                <a class="btn btn-success btn-md ml-0 waves-effect waves-light">Save</a>
                                                             
                                                           </div>
                                                    </div>
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
                            
   <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
<script src="../js/dataTables.bootstrap4.min.js"></script>
<link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
                            
<script>
    
    backMe = "yes"
    $(document).ready(function () {
        loadNavigation('applyrptp', 'glepermitlicensee', 'apply', 'tl', 'e-permit', 'Apply e-permit', ' ');
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




