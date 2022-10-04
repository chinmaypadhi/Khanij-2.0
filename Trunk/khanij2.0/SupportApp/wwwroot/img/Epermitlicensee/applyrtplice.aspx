<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyrtplice.aspx.cs" Inherits="Epermitlicensee_applyrtplice" %>
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
                                                                    <a class="nav-link active" href="applyrtplice.aspx">
                                                                     Apply New Application
                                                                    </a>
                                                                </li>
                                                                 <li class="nav-item">
                                                                    <a class="nav-link" href="generlicen.aspx">
                                                                      Generated RTP Application
                                                                    </a>
                                                                </li>
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                            <div class="content-body">
                                                            <div class="message-highlighter">
                                                       <div class="row">
                                                                
                                                                    <label class="col-lg-3 col-md-4 col-sm-12 col-form-label">Mineral Name</label>
                                                                    <div class="col-lg-9 col-md-8 col-sm-12">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Coal</label>
                                                                    </div>
                                                                   <label class="col-lg-3 col-md-4 col-sm-12 col-form-label">Mineral sender Name</label>
                                                                    <div class="col-lg-9 col-md-8 col-sm-12">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>M/s Phil Coal Beneficiation  Pvt. Ltd</label>
                                                                    </div>
                                                          
                                                                    
                                                                     <label class="col-lg-3 col-md-4 col-sm-12 col-form-label">Mineral sender Address</label>
                                                                    <div class="col-lg-9 col-md-8 col-sm-12">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> Phil Coal Benefication Pvt. Ltd.  Village- Ghutku , Tehsil- Takhatpur Dist-Bilashpur Chhatissgarh.495001</label>
                                                                    </div>
                                                                    
                                                                     <label class="col-lg-3 col-md-4 col-sm-12 col-form-label">Mineral Receiver Address</label>
                                                                    <div class="col-lg-9 col-md-8 col-sm-12">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>  Village - Barela , Tehsil - Ghansour , Dist. - Seoni M.P</label>
                                                                    </div>

                                                                    <label class="col-lg-3 col-md-4 col-sm-12 col-form-label">Quantity of Mineral (Tonne) in EDRM</label>
                                                                    <div class="col-lg-9 col-md-8 col-sm-12">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> 0.00</label>
                                                                    </div>

                                                                     <label class="col-lg-3 col-md-4 col-sm-12 col-form-label">Quantity of Mineral (Tonne)</label>
                                                                    <div class="col-lg-9 col-md-8 col-sm-12">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> 0.00</label>
                                                                    </div>
                                                               
                                                       </div>
                                                      </div>
                                                            <div class="row">
                                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                                    <h5 class="text-brown font-weight-bold mt-0">Application for Railway Transit Pass</h5>
                                                                </div>

                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                               <label class="col-form-label font-weight-bolder">E-Permit Number<span class="text-danger">*</span></label>
                                                               <select class="form-control form-control-sm searchableselect ">
                                                                    <option>Select</option>
                                                                 </select>
                                                            </div>
                                                           
                                                     
                                                            
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                                 <label class="col-form-label font-weight-bolder">Mineral Receiver Name<span class="text-danger">*</span></label>
                                                                  <select class="form-control form-control-sm searchableselect ">
                                                                    <option>Select</option>
                                                                 </select>
                                                            </div>
                                                           
                                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                               <label class="col-form-label font-weight-bolder">Name & address of railway siding<small> (where the mineral will be loaded)</small> <span class="text-danger">*</span></label>
                                                                 <select class="form-control form-control-sm searchableselect ">
                                                                    <option>Select</option>
                                                                 </select>
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                                 <label class="col-form-label font-weight-bolder">EDRM No. / e-Demand Reference Id<span class="text-danger">*</span></label>
                                                                  <input type="text" class="form-control">
                                                                  <small class="text-danger">Provide EDRM details for major minerals & e-Demand details for minor minerals</small>
                                                            </div>
                                                       
                                                           
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                                <label class="col-form-label font-weight-bolder">EDRM / e-Demand Date<span class="text-danger">*</span></label>
                                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                            </div>
                                                       
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                               <label class="col-form-label font-weight-bolder">Upload EDRM / e-Demand Copy<span class="text-danger">*</span></label>
                                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File1" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                                            </div>
                                                           
                                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                                <label class="col-form-label font-weight-bolder">Name & address of destination railway siding<span class="text-danger">*</span></label>
                                                                <select class="form-control form-control-sm searchableselect ">
                                                                    <option>Select</option>
                                                                 </select>
                                                            </div>
                                                      
                                                           <div class="col-lg-12 mt-4">
                                            
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Apply RTP</a>
                                                <a href="#" class="btn btn-danger btn-md waves-effect waves-light" >Reset</a>
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
                            
 <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
  <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>                           

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
    indicateMe = "yes";
    $(document).ready(function () {
        loadNavigation('applyrtplice', 'glepermitlicensee', 'applyrtp', 'tl', 'e-permit', 'Apply e-permit', ' ');
        $('.searchableselect').searchableselect();
    });
</script>
</body>

</html>



