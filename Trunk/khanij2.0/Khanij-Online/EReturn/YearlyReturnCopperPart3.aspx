<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnCopperPart3.aspx.cs" Inherits="EReturn_YearlyReturnCopperPart3" %>

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
                                        <a class="nav-link " href="YearlyReturnCopperPart1.aspx">
                                         Part 1
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link " href="YearlyReturnCopperPart2.aspx">
                                         Part 2
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="YearlyReturnCopperPart3.aspx">
                                         Part 3
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnCopperPart4.aspx">
                                         Part 4
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnCopperPart5.aspx">
                                         Part 5
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnCopperPart6.aspx">
                                         Part 6
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnCopperPart7.aspx">
                                         Part 7
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                               <div class="text-center text-dark">
                                <h6 class="font-weight-bold">Annual Return <small>(Form G-1)</small></h6>
                                <p class="font-weight-normal mb-0">To be used for minerals other than Copper, Gold, Lead, Pyrites, Tin, Tungsten, Zinc and precious and semi-precious stones
                                </p>
                                 <h6 class="font-weight-bold">Consumption of Materials<small> (Part – III)</small></h6>
                                
                                </div>
                                

                                  <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1" >
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Quantity and cost of material consumed</a>
                                  </li>
                                  <li>
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Royalty, Rents and Payments</a>
                                  </li>
                                  
                                   
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                    <div class="row">
                                    <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Fuel</h5>
                                     </div>
                                    <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Coal</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Tonnes" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                     <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Diesel Oil</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Ltrs." readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                       <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c) Petrol</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Ltrs." readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(d) Kerosene</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Ltrs." readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(e) Gas</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="CUM." readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Lubricant</h5>
                                     </div>
                                    <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Lubricant oil</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Tonnes" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                     <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Grease</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Kgs." readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>

                                        <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Electricity</h5>
                                     </div>
                                    <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Consumed</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Kwh" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                     <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Generated</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Kwh" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                         <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c) Sold</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Kwh" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                    <div class="col-xl-4">
                                    <h5 class="text-brown font-weight-bold">Explosives (furnish full details in part IV)</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                    <div class="col-xl-4">
                                    <h5 class="text-brown font-weight-bold">Tyres</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Nos" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                    <div class="col-xl-4">
                                    <h5 class="text-brown font-weight-bold">Timber & Supports</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                    <div class="col-xl-4">
                                     <h5 class="text-brown font-weight-bold">Drill rods & kits</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label">Tonnes</label>
                                              <input type="text" class="form-control" value="Nos" readonly>
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Quantity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                       
                                    <div class="col-xl-4">
                                     <h5 class="text-brown font-weight-bold">Other spares & stores</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label">Value (Rs)</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>

                                    </div>
                                    
                                     <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                           
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                    
                                
                                  </div>
                                  <div class="tab-pane fade" id="second" role="tabpanel" aria-labelledby="second-tab">
                                  <div class="row">
                                  <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Royalty, rents and payments made to DMF & NMET (Rs)</h5>
                                     </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Royalty</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Paid for current year</label>
                                              <input type="text" class="form-control"  readonly="">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Dead rent</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Paid for current year</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c)Surface rent</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Paid for current year</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(d) Payment made to DMF</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Paid for current year</label>
                                              <input type="number" class="form-control" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(e) Payment made to NMET</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Paid for current year</label>
                                              <input type="number" class="form-control" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        
                                  </div>


                                  <div class="row">
                                  <div class="col-xl-6">
                                    <h5 class="text-brown font-weight-bold">Compensation paid for felling trees during the year (Rs)</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                    <h5 class="text-brown font-weight-bold">Depreciation on fixed assets (Rs)</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label">Paid towards past arrears</label>
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                  </div>

                                  <div class="row">
                                  <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Taxes and cesses</h5>
                                     </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(i) Sales Tax</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Central Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(ii) Welfare cesses</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Central Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        
                                        
                                  </div>

                                  <div class="row">
                                  <div class="col-xl-12">
                                  <label class="col-form-label font-weight-bolder pt-0">(iii) Other Taxes and cesses</label>
                                     </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Mineral cesses</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Central Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) cess on deed rent</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Central Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                         <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c) Others (Please specify)</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                             <label class="col-form-label active">Central Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        
                                        
                                  </div>

                                  <div class="row">
                                  <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Other expenses (Rs)</h5>
                                     </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(i) Overheads</label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(ii) Maintenance</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-12">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iii) Money value of other benefits paid to workmen</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-12">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iv) Payment made to professional agencies</label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(e) Payment made to NMET</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-12">
                                            <label class="col-form-label">State Govt</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        
                                  </div>
                                  
                                  
                                <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-success btn-md ml-0 waves-effect waves-light">Save & Update</a> 
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
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>

        $(document).ready(function () {
            loadNavigation('YearlyReturnCopperPart3', 'glereturn', 'plyearetcop', 'tl', 'E-Return Non-coal', 'Yearly Return Copper', ' ');
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
    
 <script>
     var add = '<tr> <td id="t1"><input type="text" class="form-control"></td><td id="t2"><input type="text" class="form-control"></td><td><button class="btn btn-danger btn-sm remove  m-0 mr-1"><i class="fa fa-minus" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-sm add-btn  m-0 mr-1"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

     $(document).ready(function () {
         $(document).on('click', '.add-btn', function () {
             $("#insert").find('tbody').append(add);
         });

         $("#insert").on('click', '.remove', function () {
             $(this).parents('tr').remove();
         });
     }); 
</script>
    
</body>
</html>





