<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnpartfive.aspx.cs" Inherits="EReturn_YearlyReturnpartfive" %>
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
                                        <a class="nav-link " href="YearlyReturnpartone.aspx">
                                         Part 1
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnparttwo.aspx">
                                         Part 2
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnpartthree.aspx">
                                         Part 3
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnpartfour.aspx">
                                         Part 4
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="YearlyReturnpartfive.aspx">
                                         Part 5
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnpartsix.aspx">
                                         Part 6
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnpartseven.aspx">
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
                                 <h6 class="font-weight-bold">General Geology and Mining<small> (Part – V)</small></h6>
                                </div>
                                
                                

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li  class="startstep activestep1" >
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Exploration</a>
                                  </li>
                                  <li>
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Reserves and Resources estimated</a>
                                  </li>
                                  <li>
                                    <a  id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Reject, Waste, Trees planted/ survival </a>
                                  </li>
                                   <li>
                                    <a  id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">Type of Machinery</a>
                                  </li>
                                  <li>
                                    <a  id="five-tab" data-toggle="tab" href="#five" role="tab" aria-controls="five" aria-selected="false">Details of mineral Treatment Plant</a>
                                  </li>
                                   
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">

                                  <div class="row">
                                   <div class="col-xl-12">
                                   <h5 class="text-brown font-weight-bold">Drilling</h5>
                                   </div>
                                    <div class="col-xl-6">
                                    
                                         <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) No. of holes</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                       
                                    </div>
                                    <div class="col-xl-6">
                                    <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Metrage</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                    </div>
                                  </div>

                                  <div class="row">
                                  <div class="col-xl-12">
                                   <h5 class="text-brown font-weight-bold">Pitting</h5>
                                   </div>
                                       
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) No of Pits</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-xl-6">
                                       <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Excavation (in m3)</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                   </div>

                                  <div class="row">
                                   <div class="col-xl-12">
                                   <h5 class="text-brown font-weight-bold">Trenching</h5>
                                   </div>
                                       
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) No. of trenches</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-xl-4">
                                       <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Excavation (in m3)</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-xl-4">
                                       <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Length covered (in metre)</label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-3" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-md-0 mb-3" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                   </div>

                                  <div class="row ">
                                    <div class="col-xl-4">
                                    <h5 class="text-brown font-weight-bold">Expenditure on (Rs)</h5>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-6">
                                              <input  class="form-control mb-3" type="number" placeholder="Beginning of year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input  class="form-control mb-3" type="number" placeholder="During the year">
                                            </div>
                                            <div class="col-sm-6">
                                              <input  class="form-control mb-md-0 mb-3" type="number" placeholder="Cumulative">
                                            </div>
                                            <div class="col-sm-6">
                                              <input  class="form-control" type="number" placeholder="Grid Dimension">
                                            </div>
                                       </div>
                                       </div>
                                    </div>
                                    <div class="col-xl-4">
                                      <h5 class="text-brown font-weight-bold">Any other exploration activity during the year</h5>
                                       <div class="bg-light p-2 form-group border">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                     <input class="form-control" type="text" placeholder="Type other exploration activity">
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
                                  
                                       <div class="table-responsive">
                                        <table class="table table-sm table-bordered mt-3">
                                    <tbody>
                                    <tr>
                                    <th class="font-weight-bold">Classification</th>
                                    <th class="font-weight-bold">Code</th>                                               
                                    <th class="font-weight-bold">At the beginning of the year 1.4.2020 </th>
                                    <th class="font-weight-bold">Assessed during the year</th>
                                    <th class="font-weight-bold">Depletion of reserves during the year</th>
                                    <th class="font-weight-bold">Balance  as on 31.3.2021</th>
                                    
                                    <tr>
                                    <td colspan="6" class="font-weight-bold">A. Mineral Reserve</td>
                                    </tr>
                                    <tr>
                                    <td>1. Proved Mineral Reserve</td>
                                    <td>111</td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class=" form-control" type="Number" ></td>
                                    <td><input class=" form-control" type="Number" ></td>
                                    <td><input class=" form-control" readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td rowspan="2">2. Probable mineral Reserve</td>
                                    <td>121</td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td>122</td>
                                    <td><input class=" form-control"  type="Number"></td>
                                    <td><input class=" form-control"  type="Number"></td>
                                    <td><input class=" form-control"  type="Number"></td>
                                    <td><input class=" form-control"  readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td>3. Total Reserves</td>
                                    <td></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    </tr>
                                    <tr>
                                    <td colspan="6" class="font-weight-bold">B. Remaining </td>
                                    </tr>
                                    <tr>
                                    <td>1. Feasibility mineral Resource</td>
                                    <td>211</td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class=" form-control" type="Number" ></td>
                                    <td><input class=" form-control" type="Number" ></td>
                                    <td><input class=" form-control"  readonly="readonly" type="Number" ></td>
                                    </tr>
                                    <tr>
                                    <td rowspan="2">2. Prefeasibility mineral resource</td>
                                    <td>221</td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  readonly="readonly" type="Number" ></td>
                                    </tr>
                                    <tr>
                                    <td>222</td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  type="Number" ></td>
                                    <td><input class=" form-control"  readonly="readonly" type="Number" ></td>
                                    </tr>
                                    <tr>
                                    <td>3. Measured mineral resource</td>
                                    <td>331</td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td>4. Indicated mineral resource</td>
                                    <td>332</td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td>5. Inferred mineral resource</td>
                                    <td>333</td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  type="Number" ></td>
                                    <td><input class="form-control"  readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td>6. Reconnaissance mineral resource</td>
                                    <td>334</td>
                                    <td><input class="form-control" type="Number"></td>
                                    <td><input class="form-control" type="Number"></td>
                                    <td><input class="form-control" type="Number"></td>
                                    <td><input class="form-control" readonly="readonly" type="Number"></td>
                                    </tr>
                                    <tr>
                                    <td>7. Total remaining </td>
                                    <td></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    </tr>
                                    <tr>
                                    <td class="font-weight-bold">Total (A+B)</td>
                                    <td></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    <td><input class="form-control"  readonly="readonly" type="text"></td>
                                    </tr>
                                    </tbody></table>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                    
                                  </div>
                                  <div class="tab-pane fade" id="third" role="tabpanel" aria-labelledby="third-tab">
                                  <h5 class="text-brown font-weight-bold">Subgrade / Mineral Reject (in tonnes)</h5>
                                  <p>(Information to be given in respect of mineral fractions generated and stacked/ dumped below cut-off grade and above threshold value, if prescribed, having no immediate sale value)</p>
                                  <div class="table-responsive">
                                         <table class="table table-sm table-bordered">
                                             <tbody>
                                <tr>
                                    <th class="font-weight-bold">Generation Sub-grade Mineral Reject (in tounes)</th>
                                    <th class="font-weight-bold">At the beginning of the year</th>
                                    <th class="font-weight-bold">Generated during the year</th>
                                    <th class="font-weight-bold">Disposed during the year</th>
                                    <th class="font-weight-bold">Total stacked at the end of the year</th>
                                    <th class="font-weight-bold">Average grade of the mineral reject generated.</th>
                                </tr>
                                <tr>
    <td class="font-weight-bold">from unprocessed ore</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="text"></td>
</tr>
                                <tr>
    <td class="font-weight-bold">from processed ore</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="text"></td>
</tr>
                                           </tbody>
                                         </table>
                                         
                                    </div>
                                    <h5 class="text-brown font-weight-bold">Overburden and Waste (in m3)</h5>
                                    <p>(Information to be given in respect of overburden/ waste and mineral fractions generated below threshold value, if prescribed) </p>
                                  <div class="table-responsive">
                                        <table class="table table-sm table-bordered">
                                        <tbody>
                                        <tr>
                                            <th class="font-weight-bold">At the beginning of the year</th>
                                            <th class="font-weight-bold">Generated during the year</th>
                                            <th class="font-weight-bold">Disposed in dumps during the year</th>
                                            <th class="font-weight-bold">Backfilled during the year</th>
                                            <th class="font-weight-bold">Total at the end of the year</th>
                                        </tr>
                                        <tr>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                        </tr>

                                        </tbody></table>
                                        </div>
                                        <h5 class="text-brown font-weight-bold">Trees planted/ survival rate</h5>
                                    <div class="table-responsive">
                                     <table class="table table-sm table-bordered">
                                    <tbody>
<tr>
<th class="font-weight-bold">Description</th>
<th class="font-weight-bold">Within lease area</th>
<th class="font-weight-bold">Outside lease area</th>
</tr>
<tr>
<td class="font-weight-bold">Number of trees planted during the year</td>
<td><input class="form-control"  type="number"></td>
<td><input class="form-control"  type="number"></td>
</tr>
<tr>
<td class="font-weight-bold">Survival rate in percentage</td>
<td><input class="form-control"  type="number"></td>
<td><input class=" form-control" type="number"></td>
</tr>
<tr>
<td class="font-weight-bold">Total No. of trees at the end of the year</td>
<td><input class=" form-control" type="number"></td>
<td><input class=" form-control" type="number"></td>
</tr>
</tbody>
                                    </table>
                                   </div>
                                   <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                  </div>
                                  <div class="tab-pane fade" id="four" role="tabpanel" aria-labelledby="four-tab">
                                 
                                       <div class="col-sm-12 mt-3">
                                            <div class="table-responsive">
                                                <table id="datatable" class="table table-sm table-bordered ">
                                                    <thead>
                                                        <tr>
                                                            <th width="30">Sl#</th>
                                                            <th>Type of Machinery</th>
                                                            <th>Capacity</th>
                                                            <th>Unit</th>
                                                            <th>Number of Machinery</th>
                                                            <th>Type</th>
                                                            <th>Used Area</th>
                                                            <th width="100px" class="noprint">Actions</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>xx</td>
                                                            <td>xx</td>
                                                            <td>xx</td>
                                                            <td>xx</td>
                                                            <td>xx</td>
                                                            <td>xx</td>
                                                            <td class="noprint"><a data-toggle="modal"
                                                data-target=".alert-modal"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                   data-placement="top" title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    data-placement="top"  title="Delete"><i class="far fa-trash-alt"></i></a>
                                                                    <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-success btn-sm"
                                                                     data-toggle="modal"
                                                data-target=".alert-modal" data-placement="top" title="Add New"><i class="fas fa-plus"></i></a>
                                                            </td>
                                                        </tr>
                                                        
                                                    </tbody>
                                                </table>
                                            </div>
                                            
                                            
                                        </div> 
                                        <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                      
                                        
                                   </div>
                                   <div class="tab-pane fade" id="five" role="tabpanel" aria-labelledby="five-tab">
                                 <div class="row">
                                <div class="col-sm-12">
                                    <label class="col-form-label font-weight-bolder">Details of mineral Treatment Plant, if any</label>
                                    <textarea class="form-control" rows="2"></textarea>
                                    <p class="text-danger">Give a brief description of the process capacity of the machinery deployed and its availability. (Submit Flow Sheet and Material Balance of the Plant separately).</p>
                                </div>
                                
                                </div>

                                <div class="row">
                                  <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Furnish following information</h5>
                                     </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(i) Feed</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Tonnage">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Average Grade">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(ii) Concentrates/processed products : (mention name with comma(,) separate)</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                              <input type="text" class="form-control" >
                                            </div>
                                             <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Tonnage">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="text" class="form-control" placeholder="Average Grade">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                         <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iii) By-products/Co-products : (mention name with comma(,) separate)</label>
                                            <div class="row">
                                             <div class="col-sm-4">
                                              <input type="text" class="form-control" >
                                            </div>
                                             <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Tonnage">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="text" class="form-control" placeholder="Average Grade">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iv) Tailings</label>
                                            <div class="row">
                                             <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Tonnage">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Average Grade">
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
    <!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
            <div class="modal-header p-2">
        <h5 class="modal-title m-0">Add Machinery Detail</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">×</span>
        </button>
      </div>
                <div class="modal-body">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-6 col-form-label font-weight-bolder">Type of machinery</label>
                            <div class="col-sm-6">
                                <select class="form-control form-control-sm searchableselect">
                                    <option>Select Type of machinery</option>
                                    <option></option>
                                 </select>
                            </div>
                        </div>
                    </div>
                     <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-6 col-form-label font-weight-bolder">Capacity of Machinery<span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-6 col-form-label font-weight-bolder">Unit (in which capacity)<span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                               <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-6 col-form-label font-weight-bolder">No of machinery<span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-6 col-form-label font-weight-bolder">Electrical/Non-Electrical<span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiop" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radiop">Electrical</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiopro" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radiopro">Non-Electrical</label>
                                                      </div>
                                                    </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-6 col-form-label font-weight-bolder">Used in opencast/underground<span class="text-danger">*</span></label>
                            <div class="col-sm-6">
                                <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radiop">opencast</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radiopro">underground</label>
                                                      </div>
                                                    </div>
                            </div>
                        </div>
                    </div>
                        </div>
                    <a class="btn btn-primary btn-md ml-0" href="#">Submit</a>
                   
                </div>
               
            </div>
        </div>
    </div>
    <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet"href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
<script src="../js/dataTables.bootstrap4.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>
        
        $(document).ready(function () {
            loadNavigation('YearlyReturnpartfive', 'glereturn', 'plyearet', 'tl', 'E-Return Non-coal', 'Yearly Return Iron Ore', ' ');
            $('.searchableselect').searchableselect();
            $('#datatable').DataTable();
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
        var add = '<tr><td id="t1"><input type="text" class="form-control"></td><td id="t2"><input type="text" class="form-control"></td><td id="t3"><input type="text" class="form-control"></td><td id="t4"><input type="text" class="form-control"></td><td id="t5"><input type="text" class="form-control"></td><td id="t6"><input type="text" class="form-control"></td><td id="t7"><input type="text" class="form-control"></td><td id="t8"><input type="text" class="form-control"></td><td id="t9"><input type="text" class="form-control"></td><td id="t10"><div class="input-group"><input type="text" class="form-control datepicker" id="Text3"><div class="input-group-prepend"><label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label></div></td><td id="t11"><div class="input-group"><input type="text" class="form-control datepicker" id="Text3"><div class="input-group-prepend"><label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label></div></td><td><button class="btn btn-danger btn-sm remove  m-0 mr-1"><i class="fa fa-minus" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-sm add-btn  m-0 mr-1"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

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



