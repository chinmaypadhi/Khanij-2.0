<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakePaymentE-permit.aspx.cs" Inherits="Epermit_MakePaymentE_permit" %>
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
                                                                    <a class="nav-link active" href="javascript:void(0);">
                                                                      Make Payment
                                                                    </a>
                                                                </li>
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                            <div class="content-body">
                                                            
                                                       
                                                       
                                                       
                                                      
                                                       
                                                      
                                                        
                                                       
                                                       <h5 class="text-brown font-weight-bold mt-0 text-center">Calculation</h5>
                                                       <h6 class="text-brown font-weight-bold">Payable Online</h6>
                                                       <div class="table-responsive">
                                                       <table class="table table-bordered">
                                                          <thead>
    <tr>
      <th class="font-weight-bolder">Classification</th>
      <th class="font-weight-bolder">Total Amount</th>
      <th class="font-weight-bolder">Total Wallet Amount</th>
      <th class="font-weight-bolder">Pay by Wallet Amount</th>
      <th class="font-weight-bolder"></th>
      <th class="font-weight-bolder">Payable Amount</th>    
    </tr>
  </thead>
                                                          <tbody>
    <tr>
      <td class="font-weight-bolder">Royalty</td>
      <td>9000.00</td>
      <td>0.00</td>
      <td>0.00</td>
      <td>=</td>
      <td>90000.00</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">DMF</td>
      <td>27000.00</td>
      <td>0.00</td>
      <td>0.00</td>
      <td>=</td>
      <td>27000.00</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">Environmental Cess</td>
      <td>11250</td>
      <td>0.00</td>
      <td>0.00</td>
      <td>=</td>
      <td>11250.00</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">Infrastructure & Development Cess</td>
       <td>11250</td>
      <td>0.00</td>
      <td>0.00</td>
      <td>=</td>
      <td>11250.00</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">Total Payable Amount</td>
     <td class="font-weight-bold">139500</td>
      <td class="font-weight-bold">0</td>
      <td class="font-weight-bold">0</td>
      <td>=</td>
      <td class="font-weight-bold">139500</td>
    </tr> 
  </tbody>
                                                       </table>
                                                       </div>
                                                       <h6 class="text-brown font-weight-bold">Shall be paid separately</h6>
                                                       <div class="table-responsive">
                                                       <table class="table table-bordered">
                                                          <thead>
                                                             <tr>
      <th class="font-weight-bolder">Classification</th>
      <th class="font-weight-bolder">Total Amount</th>
      <th class="font-weight-bolder">Total Wallet Amount</th>
      <th class="font-weight-bolder">Pay by Wallet Amount</th>
      <th class="font-weight-bolder"></th>
      <th class="font-weight-bolder">Payable Amount</th>    
    </tr>
                                                          </thead>
                                                          <tbody>
    <tr>
      <td class="font-weight-bolder">TCS</td>
      <td>1800.00</td>
      <td>0.00</td>
      <td>0.00</td>
      <td>=</td>
      <td>1800.00</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">Total Payable Amount</td>
      <td class="font-weight-bold">1800</td>
      <td class="font-weight-bold">0.00</td>
      <td class="font-weight-bold">0.00</td>
      <td>=</td>
      <td class="font-weight-bold">1800</td>
    </tr> 
  </tbody>
                                                       </table>
                                                       </div>
                                                       
     
                                                       <div class="row mt-3">
                                                           <div class="col-sm-12 text-center">
                                                           <a class="btn btn-dark btn-md ml-0 waves-effect waves-light " data-toggle="modal" data-target="#leaseinformation">Lease/License Information</a>
                                                               <a class="btn btn-primary btn-md ml-0 waves-effect waves-light ">Make Payment</a>
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
    <div class="modal fade" id="leaseinformation" aria-modal="true">
  <div class="modal-dialog modal-dialog-centered modal-lg">
    <div class="modal-content">
      <div class="modal-header p-2">
        <h5 class="modal-title m-0">Lease/License Information</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">×</span>
        </button>
      </div>
      <div class="modal-body pt-2">
      <div class="row">
                                                            <div class="col-sm-12">
                                                               
                                                   
                                                       <div class="row">
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Name of lessee/ licensee</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Hirri Dolomite Mines</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Address</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Hiri Dolomite Mines, post - Hirri mines Bilaspur (C.G.) </label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Grant Order No.</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>f-3-2/2019/12</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Grant Order Date</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>28-01-2021</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Period of Lease</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>70 Years</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Name</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dolomite</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Form</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Not Applicable</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Grade</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Industrial Use (Mgo&gt;18% or SiO2&lt;6%)</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">By End use plant inside the lease area</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Quantity<small><i class="fas fa-rupee-sign ml-1"></i></small></label>
                                                                    <div class="col-sm-6">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>1000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Unit</label>
                                                                    <div class="col-sm-6">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Metric Tonne</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-6 col-form-label font-weight-bolder">Royalty Rate</label>
                                                                    <div class="col-sm-6">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                       </div>
                                                       
                                                                </div>
                                                            </div>
        
      </div>
      
    </div>
  </div>
</div>                        
  <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>                           

                            
<script>
    backMe = "yes"
    $(document).ready(function () {
       
        loadNavigation('MakePaymentE-permit', 'glepermit', 'Epermit', 'tl', 'E-Permit', 'Apply e-permit', ' ');
        $('.searchableselect').searchableselect();
        
    });
</script>
</body>

</html>



