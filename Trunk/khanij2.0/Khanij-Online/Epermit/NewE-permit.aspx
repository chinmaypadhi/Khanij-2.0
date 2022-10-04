<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewE-permit.aspx.cs" Inherits="Epermit_NewE_permit" %>
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
                                                                      Apply e-permit
                                                                    </a>
                                                                </li>
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                            <div class="content-body">
                                                            <div class="row">
                                                                <div class="col-lg-6 col-md-12 col-sm-12">
                                                                 <h5 class="text-brown font-weight-bold mt-0">New Application</h5>
                                                       <div class="row">
                                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                               <label class="col-form-label font-weight-bolder">Name of Lessee </label>
                                                                <input type="text" class="form-control form-group" value="Hirri Dolomite Mines" readonly>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Address</label>
                                                                  <input type="text" class="form-control form-group" value="Hiri Dolomite Mines, post - Hirri mines Bilaspur (C.G.) " readonly>
                                                                  
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <label class="col-form-label font-weight-bolder">Grant Order No.</label>
                                                                <input type="text" class="form-control form-group" value="f-3-2/2019/12" readonly>
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                               <label class="col-form-label font-weight-bolder">Grant Order Date </label>
                                                                <input type="text" class="form-control form-group" value="28-01-2021" readonly>
                                                            </div>
                                                       
                                                            
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Period of Lease</label>
                                                                  <input type="text" class="form-control form-group" value="70 Years" readonly>
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <label class="col-form-label font-weight-bolder">Village</label>
                                                                <input type="text" class="form-control form-group" value="CHHATAUNA" readonly>
                                                            </div>
                                                             <div class="col-lg-4 col-md-6 col-sm-12">
                                                               <label class="col-form-label font-weight-bolder">Panchayat</label>
                                                                <input type="text" class="form-control form-group" value="chhatauna" readonly>
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Tehsil</label>
                                                                  <input type="text" class="form-control form-group" value="Takhatpur" readonly>
                                                            </div>
                                                       
                                                           
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <label class="col-form-label font-weight-bolder">Police Station</label>
                                                                <input type="text" class="form-control form-group" value="chakarbhatha" readonly>
                                                            </div>
                                                       
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                               <label class="col-form-label font-weight-bolder">District</label>
                                                                <input type="text" class="form-control form-group" value="Bilaspur" readonly>
                                                            </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Mineral Name</label>
                                                                  <input type="text" class="form-control form-group" value="Dolomite" readonly>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
                                                                <label class="col-form-label font-weight-bolder">Mineral Form</label>
                                                                <select class="form-control form-control-sm searchableselect ">
                                                                    <option>Select Mineral Form</option>
                                                                    <option>ROM</option>
                                                                    <option>Fines</option>
                                                                    <option>Lumps</option>
                                                                 </select>
                                                            </div>
                                                      
                                                            <div class="col-lg-6 col-md-6 col-sm-12 form-group">
                                                               <label class="col-form-label font-weight-bolder">Mineral Grade</label>
                                                                 <select class="form-control form-control-sm searchableselect">
                                                                        <option>Select Mineral Grade</option>
                                                                        <option>Industrial Use (Mgo&gt;18% or SiO2&lt;6%) </option>
                                                                        
                                                                 </select>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Quantity<small><i class="fas fa-rupee-sign ml-1"></i></small></label>
                                                                  <input type="text" class="form-control form-group">
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                                <label class="col-form-label font-weight-bolder">Unit</label>
                                                                <input type="text" class="form-control form-group" value="Metric Tonne" readonly>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                               <label class="col-form-label font-weight-bolder">Royalty Rate</label>
                                                                <input type="text" class="form-control form-group" value="0" readonly>
                                                            </div>
                                                       
                                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                                 <label class="col-form-label font-weight-bolder">Total Payable Amount<small><i class="fas fa-rupee-sign ml-1"></i></small></label>
                                                                  <input type="text" class="form-control form-group" value="0" readonly>
                                                            </div>
                                                       </div>
                                                       <div class="row">
                                                           <div class="col-sm-12">
                                                               <a class="btn btn-dark btn-md ml-0 waves-effect waves-light "data-toggle="modal" data-target="#viewcalculation">View Calculation</a>
                                                               <a class="btn btn-success btn-md ml-0 waves-effect waves-light">Save</a>
                                                               <a class="btn btn-primary btn-md ml-0 waves-effect waves-light " href="MakePaymentE-permit.aspx">Make Payment</a>
                                                           </div>
                                                    </div>
                                                                </div>
                                                                 <div class="col-lg-6 col-md-12 col-sm-12">
                                                                 <h5 class="text-brown font-weight-bold mt-0">Details</h5>
                                                    <div class="bg-light p-2 shadow-sm">
                                                       <div class="row">
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">EC Approved Qty + Opening Stock</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>2000000.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">Mining Plan Qty</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>1235000.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">Lease Validity</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> 06-05-1959 to 05-05-2029 <small> (70 yr)</small></label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By Road</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>141168.160</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By Road-Rail</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By Inside Railway Siding</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By Conveyor Belt</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By MGR/Own Wagon</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By End use plant inside the lease area</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">By Ropeway</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>0.000</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">Total Dispatched (e-Pass)</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>141168.160</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                                <div class="row">
                                                                    <label class="col-sm-7 col-form-label font-weight-bolder">Total Dispatched</label>
                                                                    <div class="col-sm-5">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>141168.160</label>
                                                                    </div>
                                                                </div>
                                                           </div>
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
                            <div class="modal fade" id="viewcalculation">
  <div class="modal-dialog modal-dialog-centered modal-lg" >
    <div class="modal-content">
      <div class="modal-header p-2">
        <h5 class="modal-title m-0">View Calculation</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
      <div class="row">
      <div class="col-xl-12">
      <h6 class="text-brown font-weight-bold mt-0">Payable Online</h6>
                <div class="table-responsive">
 <table class="table table-bordered">
 <thead>
    <tr>
      <th class="font-weight-bolder">Classification</th>
      <th class="font-weight-bolder">Payment Amount</th>
      <th class="font-weight-bolder">Calculation</th>
      <th class="font-weight-bolder">Head of Account</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td class="font-weight-bolder">Royalty</td>
      <td>90000.00</td>
      <td>90.00 Rs / Unit</td>
      <td>0853-00-102-0278</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">DMF</td>
      <td>27000.00</td>
      <td>30.00 %</td>
      <td>35428070064</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">Environmental Cess</td>
      <td>11250.00</td>
      <td>11.25 Rs / Unit</td>
      <td>0029-00-103-0062</td>
    </tr>
     <tr>
      <td class="font-weight-bolder">Infrastructure &amp; Development Cess</td>
       <td>11250.00</td>
      <td>11.25 Rs / Unit</td>
      <td>0029-00-103-0063</td>
    </tr>
  </tbody>
  </table>
</div>
         <h6 class="text-brown font-weight-bold mt-0">Shall be paid separately</h6>
         <div class="table-responsive">
 <table class="table table-bordered mb-0">
 <thead>
    <tr>
      <th class="font-weight-bolder">Classification</th>
      <th class="font-weight-bolder">Payment Amount</th>
      <th class="font-weight-bolder">Calculation</th>
      <th class="font-weight-bolder">Head of Account</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td class="font-weight-bolder">TCS</td>
      <td>1800.00</td>
      <td>2.00 %</td>
      <td></td>
    </tr>
  </tbody>
  </table>
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
    $(document).ready(function () {
        loadNavigation('NewE-permit', 'glepermit', 'Epermit', 'tl', 'E-Permit', 'Apply e-permit', ' ');
        $('.searchableselect').searchableselect();
    });
</script>
</body>

</html>


