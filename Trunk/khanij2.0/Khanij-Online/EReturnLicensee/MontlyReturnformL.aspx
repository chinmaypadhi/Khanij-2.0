<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MontlyReturnformL.aspx.cs" Inherits="EReturnLicensee_MontlyReturnView" %>
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
                                         Form L
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="text-center text-dark">
                                <h6 class="font-weight-bold">Monthly Return</h6>
                                <p class="font-weight-normal mb-0">Form L [See rule 45(6)(a)]</p>
                                </div>

                            
                                
                                   
                               
                                
                                       
                                        <div class="form-group row">
                                         <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Registration No.<small>( allotted by IBM)</small></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Name</label>
                                                  <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                 <label  class="col-form-label font-weight-bolder">Address</label>
                                                  <textarea name="textAddress" rows="1" cols="20" id="Textarea1" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            
                                           
                                       </div>

                                        <div class="form-group row">
                                         <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Plant Name/Storage location, if available</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Latitude and Longitude</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Name of activity(s) reported</label>
                                                <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input " id="radio1a" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label mr-md-2" for="radio1a">Trading</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1b" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label mr-md-2" for="radio1b">Export</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1c" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio1c">Storage</label>
                                                      </div>
                                                     
                                                    </div>
                                            </div>
                                            
                                             
                                       </div>

                                      

                                       <div class="row">
                                    <div class="col-sm-12">
                                        <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Save &amp; Update</a>
                                      
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
    
    
    <script>
        backMe = "yes"
     
        $(document).ready(function () {
            loadNavigation('MontlyReturnformL', 'glereturnlicensee', 'pleretlienmon', 'tl', 'E-Return Licensee', 'Monthly Return', ' ');

            $('.searchableselect').searchableselect();
            $('#datatable').DataTable();
           
        });
    </script>

   
    
    
</body>
</html>


