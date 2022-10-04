<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWork.aspx.cs" Inherits="Geology_AddWork" %>
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
                                        <a class="nav-link active" href="AddWork.aspx">
                                           Add Monthly Progress Reports
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="ViewWork.aspx">
                                           View Monthly Progress Reports
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                    <li class="startstep activestep1 active">
                                      <a  id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="false">Expenditure Incurred</a>
                                    </li>
                                    <li>
                                        <a id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Exploration Data</a>
                                    </li>
                                    <li>
                                         <a id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Hault at camps for officers</a>
                                    </li>
                                    <li>
                                    <a id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="true">Enclosers</a>
                                    </li>
                                   
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                    <div class="row">
                                    <div class="col-xl-12">
                                        <h5 class="text-brown font-weight-bold mt-0">Expenditure Incurred</h5>
                                    </div>
                                    <div class="col-xl-12">
                                        
                                        <div class="row">
                                       <div class="col-xl-4">
                                        <label class="col-form-label font-weight-bolder">(A) Up to the last month</label>
                                       
                                              <input type="text" class="form-control mb-lg-0 mb-3"">
                                         
                                       </div>
                                       <div class="col-xl-4">
                                        <label class="col-form-label font-weight-bolder">(B) During the month</label>
                                            
                                            
                                              <input type="text" class="form-control mb-lg-0 mb-3"">
                                           
                                      </div>
                                      </div>
                                     
                                        
                                        
                                        <label class="col-form-label font-weight-bolder">Detail of B</label>
                                            <div class="row">
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Labor (Rs.)">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="P.O.L (Rs.)">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control mb-lg-0 mb-3"  type="text" placeholder="Repairs And Maintenance (Rs.)">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                              <input class="form-control mb-lg-0 mb-3"  type="text" placeholder="Others (Rs.)">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                              <input class="form-control mb-lg-0 mb-0"  type="text" placeholder="Total (Rs.)">
                                            </div>
                                       </div>
                                  </div>

                                   
                              
                                 </div> 
                                    <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a>
                                        </div>
                                     </div>
                                       
                                    
                                   
                                  </div>
                                  <div class="tab-pane fade" id="second" role="tabpanel" aria-labelledby="second-tab">
                                <div class="row">
                                        <div class="col-xl-12">
                                <h5 class="text-brown font-weight-bold mt-0">Exploration Data <small>(In metric units)</small></h5>
                                </div>
                                  </div>
                                
                                
                                <div class="row">
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(A) Reconn. Geological Survey (Scale - 1:50,000)</label>
                                        <br />
                                        <label class="col-form-label font-weight-bolder  pt-0">Area (sq. km.)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(B) Detailed Geological Mapping (Scale - 1:4,000)</label>
                                        <br />
                                        <label class="col-form-label font-weight-bolder  pt-0">Area (sq. km.)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(C) Pitting</label>
                                        <br />
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) Nos.</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii) Volume (cu. m.).</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(D) Trenching</label>
                                        <br />
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) Nos.</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii) Volume (cu. m.).</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(E) Drilling</label>
                                        <br />
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) B.h. Completed</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii) Metrage</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(iii)  B.H. Under Progress</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3"  placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                        <label class="col-form-label font-weight-bolder  pt-0">(iv)  Metrage</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3"  placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(v)  Total Metrage</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(F) Geochemical Sampling</label>
                                      
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       
                                       </div>
                                  </div>
                                 
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(G) Geophysical Survey</label>
                                      
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                              <input type="number" class="form-control"  placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(H) Photogeological Survey</label>
                                        <br>
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) Prefield Interpretation (sq. km. on scale)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii) Post field Interpretation (sq. km. on scale)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(iii)  Field Check (sq. km. on scale)</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       
                                       
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(I) Sampling (Surface/Core Sample)</label>
                                        <br>
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) Samples Drawn</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii)  Samples Prepared</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(iii)  Samples Sent For Chemical Analysis</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                        <label class="col-form-label font-weight-bolder  pt-0">(iv) Samples Sent For Petrography</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       
                                       
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(J) Reserves</label>
                                        <br>
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) Inferred (Million Tonnes)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii) Estimated (Million Tonnes)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(iii)  Proved (Million Tonnes)</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       
                                       
                                       
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0 text-brown">(K) Topographical Survey</label>
                                        <br>
                                        <label class="col-form-label font-weight-bolder  pt-0">(i) Laying Of Base Line (km.) 1:10000</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(ii) Laying Of Grids (sq. km.)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                           
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(iii)  No. Of Pits/B.H. Point Located</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                        <label class="col-form-label font-weight-bolder  pt-0">(iv)  R.L./Co-ordinates Of Pits/B.H.</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(v)  Contouring (sq. km.)</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(vi)  Plotting Of Permanent Features</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                       <label class="col-form-label font-weight-bolder  pt-0">(vii) Plotting Of Road/Nala (k.m.)</label>
                                         <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Target">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-3 mb-3" placeholder="Work done up to the last month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="text" class="form-control mb-lg-0 mb-3" placeholder="Work done during the month">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Total work done end of current month">
                                            </div>
                                       </div>
                                      
                                       
                                       
                                       
                                       </div>
                                  </div>
                                  </div>
                                  <div class="row">
                                  <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-lg-3 col-md-6 col-sm-12 col-form-label font-weight-bolder">Other Information, If Any <span class="text-danger">*</span></label>
                                                <div class="col-lg-3 col-md-6 col-sm-12">
                                                    <input type="text" class="form-control">                                                   
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                       
                                        
                                         
                                 
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            
                                            <a class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                    
                                  </div>
                                  <div class="tab-pane fade" id="third" role="tabpanel" aria-labelledby="third-tab">
                                  <div class="row">
                                   <div class="col-xl-12">
                                    <h5 class="text-brown font-weight-bold mt-4">Hault at camps for officers <small>(for staffs attach separate leaf)</small></h5>
                                  </div>
                                  <div class="col-lg-12 col-md-12 col-sm-12">
                                                <div class="table-responsive">
                                              <table class="table table-sm border">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder" width="80px">Sl#</th>
                                                   <th class="font-weight-bolder">Name</th>
                                                   <th class="font-weight-bolder">Designation</th>
                                                   <th class="font-weight-bolder">From</th>
                                                   <th class="font-weight-bolder">To</th>
                                                   <th class="font-weight-bolder">No. of Days at Camps</th>
                                                   <th class="font-weight-bolder">Remarks, If Any</th>
                                                   <th width="100px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                <td>
                                                         <input type="text" class="form-control" value="1" disabled="">
                                                    </td>
                                                    <td>
                                                         <input type="text" class="form-control" >
                                                    </td>

                                                    <td>
                                                       <input type="text" class="form-control">
                                                    </td>
                                                    <td>
                                                       <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </td>
                                                    <td>
                                                       <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </td>
                                                    <td>
                                                       <input type="number" class="form-control" >
                                                    </td>
                                                    <td>
                                                       <textarea class="form-control" rows="1"></textarea>
                                                    </td>
                               
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                        </div>
                                    </div>
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>

                                    
                                  </div>
                                  <div class="tab-pane fade" id="four" role="tabpanel" aria-labelledby="four-tab">
                                  <div class="row">
                                  <div class="col-xl-12">
                                    <h5 class="text-brown font-weight-bold mt-0">Enclosers</h5>
                                  </div>
                                  <div class="col-xl-12">
                                        
                                        <div class="row form-group">
                                       <div class="col-xl-3">
                                        <label class="col-form-label font-weight-bolder pt-0">Maps</label>
                                       
                                              <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="customFile" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                         
                                       </div>
                                       <div class="col-xl-3">
                                        <label class="col-form-label font-weight-bolder pt-0">Borehole Logs</label>
                                            
                                            
                                            <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File1" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                           
                                      </div>
                                      <div class="col-xl-3">
                                        <label class="col-form-label font-weight-bolder pt-0">Geological Description/Synopsis</label>
                                            
                                            
                                             <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File2" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                           
                                      </div>
                                      <div class="col-xl-3">
                                        <label class="col-form-label font-weight-bolder pt-0">Any Other Information</label>
                                            
                                            
                                             <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File3" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                           
                                      </div>
                                      </div>
                                     
                                        
                                        
                                        
                                

                                   
                                </div>
                                   </div>
                                        
                                     <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-success btn-md ml-0 waves-effect waves-light" href="ViewWork.aspx">Save &amp; Update</a> 
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
    <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>







    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('AddWork', 'glgeology', 'plmonprorep', 'tl', 'Geology', 'Monthly Progress Reports', ' ');
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




