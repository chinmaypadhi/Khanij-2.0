<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnparttwo.aspx.cs" Inherits="EReturn_YearlyReturnparttwo" %>
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
                                        <a class="nav-link active" href="YearlyReturnparttwo.aspx">
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
                                        <a class="nav-link" href="YearlyReturnpartfive.aspx">
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
                                 <h6 class="font-weight-bold">Employment and Wages<small> (Part – II)</small></h6>
                                
                                </div>
                                
                                

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li  class="startstep activestep1">
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Staff Details</a>
                                  </li>
                                  <li>
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Work Deatils</a>
                                  </li>
                                  <li>
                                    <a  id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Salary/Wages Paid</a>
                                  </li>
                                   <li>
                                    <a  id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">PART-II A (Capital Structure)</a>
                                  </li>
                                  <li>
                                    <a  id="five-tab" data-toggle="tab" href="#five" role="tab" aria-controls="five" aria-selected="false">PART-II A (Source of Finance/Interest & Rent)</a>
                                  </li>
                                   
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                   <h5 class="text-brown font-weight-bold">Number of supervisory staff employed at the mine</h5>
                                   <div class="row">
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(i) Graduate Mining Engineer</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Wholly employed">
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Partly employed">
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(ii) Diploma Mining Engineer</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Wholly employed">
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control " placeholder="Partly employed">
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iii) Geologist</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Wholly employed">
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Partly employed">
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iv) Surveyor</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Wholly employed">
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control " placeholder="Partly employed">
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(v) Other administrative and technical supervisory staff</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Wholly employed">
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                              <input type="number" class="form-control" placeholder="Partly employed">
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Total (i) to (v)</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Wholly employed">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Partly employed">
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
                                  
                                        <div class="row mt-md-3">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-5 col-form-label font-weight-bolder">No. of days the mine worked</label>
                                                <div class="col-sm-4">
                                                    <input type="number" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-5 col-form-label font-weight-bolder">No. of shifts per day</label>
                                                <div class="col-sm-4">
                                                    <input type="number" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                  
                                       </div>
                                       <div class="row">
                                       <div class="col-sm-12"> <label class="col-form-label pt-0 font-weight-bolder">Indicate reasons for work stoppage in the mine during the year (due to strike, lockout, heavy rain, non-availability of labour, transport bottleneck, lack of demand, uneconomic operations,etc)and the number of days of work stoppage for each of the factors separately.</label></div>
                                       <div class="col-sm-12">
                                                  <div class="table-responsive">
                                              <table class="table table-sm border" id="insert">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">Reasons</th>
                                                   <th class="font-weight-bolder" width="250px">No. Of days Work Stop</th> 
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="td1">
                                                        <textarea class="form-control" rows="1"></textarea>
                                                    </td>
                                                    <td id="td2" >
                                                       <input type="number" class="form-control">
                                                    </td>
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn waves-effect waves-light" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
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
                                  <div class="tab-pane fade" id="third" role="tabpanel" aria-labelledby="third-tab">
                                  
                                    <h5 class="text-brown font-weight-bold">Maximum number of persons employed on any one day during the year</h5>
                                    <div class="form-group row">

                                    <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-7">
                                               <label class="col-form-label font-weight-bolder">In workings below ground on (date)</label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-5">
                                                 <label class="col-form-label font-weight-bolder">Number</label>
                                                  <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                             <div class="col-sm-7">
                                                <label class="col-form-label font-weight-bolder">In all in the mine on (date)</label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <label class="col-form-label font-weight-bolder">Number</label>
                                                <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                            
                                            
                                       </div>

                                       <div class="table-responsive">
                                            <table class="table table-sm table-bordered">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">Classification</th>
                                                <th colspan="3" class="text-center font-weight-bold">Total No. of man days worked during the year</th>
                                                <th rowspan="2" class="font-weight-bold">No. of days worked during the year</th>
                                                <th colspan="3" class="text-center font-weight-bold">Average daily number of persons employed</th>
                                                <th rowspan="2" class="font-weight-bold">Total Wes/Salary for the year (Rs)</th>
                                            </tr>
                                            <tr>
                                                <th>Direct</th>
                                                <th>Contract</th>
                                                <th>Total</th>
                                                <th>Male</th>
                                                <th>Female</th>
                                                <th>Total</th>
                                            </tr>
                                            
                                            <tr>
                                                <td>Below Ground</td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  readonly="readonly" type="number" ></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  readonly="readonly" type="number" ></td>
                                                <td><input class="form-control"  type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>Opencast</td>
                                                <td><input class="form-control"  type="number" ></td>
                                                <td><input class="form-control"  type="number" ></td>
                                                <td><input class="form-control"  readonly="readonly" type="number" ></td>
                                                <td><input class="form-control"  type="number" ></td>
                                                <td><input class="form-control"  type="number" ></td>
                                                <td><input class="form-control"  type="number" ></td>
                                                <td><input class="form-control"  readonly="readonly" type="number" ></td>
                                                <td><input class="form-control"  type="number" ></td>
                                            </tr>
                                            <tr>
                                                <td>Above Ground</td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  readonly="readonly" type="number" ></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  type="number"></td>
                                                <td><input class="form-control"  readonly="readonly" type="number" ></td>
                                                <td><input class="form-control"  type="number"></td>
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
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

                                 <div class="form-group row mt-3">
                                            <div class="col-sm-6">
                                               <label class="col-form-label font-weight-bolder">Value of Fixed Assets* (Rs) (in respect of the mine, beneficiation plant, mine work-shop, power and water installation)</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-6">
                                                 <label class="col-form-label font-weight-bolder">In case this information is furnished as combined information in another mine's return please specify Mine Code/Mine Name</label>
                                                  <input type="text" class="form-control">
                                            </div>
                                           
                                       </div>
                                        
                                        <div class="table-responsive">
                                         <table class="table table-sm table-bordered">
                                             <tbody>
                                        <tr>
        <th class="font-weight-bold">Description</th>
        <th class="font-weight-bold">At the beginning of the year(Rs)</th>
        <th class="font-weight-bold">Additions during the Year(Rs)</th>
        <th class="font-weight-bold">Sold or discarded during the year(Rs)</th>
        <th class="font-weight-bold">Depreciation during the year(Rs)</th>
        <th class="font-weight-bold">Net closing Balance (Rs) (2+3)-(4+5)</th>
        <th class="font-weight-bold">Estimated market value**(Rs)</th>
    </tr>
                                        
                                        <tr>
        <td>(i) Land</td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  readonly="readonly" type="number"></td>
        <td><input class="form-control"  type="number"></td>

    </tr>
                                        <tr>
                                            <td colspan="7">(ii) Building:</td>
                                        </tr>
                                        <tr>
        <td>Industrial</td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" readonly="readonly" type="number"></td>
        <td><input class="form-control" type="number"></td>
    </tr>
                                        <tr>
        <td>Residential</td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" type="number"></td>
        <td><input class="form-control" readonly="readonly" type="number"></td>
        <td><input class="form-control" type="number"></td>
    </tr>
                                        <tr>
        <td>(iii) Plant and Machinery including transport equipment</td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  readonly="readonly" type="number"></td>
        <td><input class="form-control"  type="number"></td>
    </tr>
                                        <tr>
        <td>(iv) Capitalised Expenditure such as pre-production exploration, development,major overhaul and repair to machinery etc (As prescribed under Income Tax Act)</td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  type="number"></td>
        <td><input class="form-control"  readonly="readonly" type="number" ></td>
        <td><input class="form-control"  type="number"></td>
    </tr>
                                        <tr>
        <td class="font-weight-bold">Total</td>
        <td><input class="form-control"  readonly="readonly" type="text"></td>
        <td><input class="form-control"  readonly="readonly" type="text"></td>
        <td><input class="form-control"  readonly="readonly" type="text"></td>
        <td><input class="form-control"  readonly="readonly" type="text"></td>
        <td><input class="form-control" readonly="readonly" type="text"></td>
        <td><input class="form-control" readonly="readonly" type="text"></td>
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
                                   <div class="tab-pane fade" id="five" role="tabpanel" aria-labelledby="five-tab">
                                   <p class="text-danger"><span class=" font-weight-bold">Note</span><br>
                                      Indicate the names of the lending institutions such as State Finance Corporation, 
                                       Industrial Development and other Public Corporations, Co-operative Banks, Nationalised Banks
                                        and other sources along with the amount of loan from each source and the rate of interest at 
                                        which loan has been taken.</p>
                                        <h5 class="text-brown font-weight-bold">Source of finance ( at the end of the year)</h5>
                                    <div class="form-group row">
                                            <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder">Paid up Share Capital (Rs)</label>
                                                <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label class="col-form-label font-weight-bolder">Own Capital (Rs)</label>
                                                  <input type="number" class="form-control">
                                            </div>
                                             <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder">Reserve & Surplus (All Types)( Rs)</label>
                                                <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       <div class="form-group row">
                                            <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder">Name of the Institution/Source</label>
                                                <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label class="col-form-label font-weight-bolder">Amount of Loan (Rs)</label>
                                                  <input type="number" class="form-control">
                                            </div>
                                             <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder">Rate of Interest</label>
                                                <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       <h5 class="text-brown font-weight-bold">Interest and rent (Rs)</h5>
                                        <div class="form-group row">
                                            <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder">Interest paid during the year</label>
                                                <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label class="col-form-label font-weight-bolder">Rents (excluding surface rent) paid during the year</label>
                                                  <input type="number" class="form-control">
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
            loadNavigation('YearlyReturnparttwo', 'glereturn', 'plyearet', 'tl', 'E-Return Non-coal', 'Yearly Return Iron Ore', ' ');
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
     var add = '<tr> <td id="t1"><textarea class="form-control" rows="1"></textarea></td><td id="t2"><input type="number" class="form-control"></td><td><button class="btn btn-danger btn-md remove  m-0 mr-1" data-placement="top" title="Remove Row"><i class="fa fa-times" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-md add-btn  m-0 mr-1" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

     $(document).ready(function () {
         $(document).on('click', '.add-btn', function () {
             $("#insert").find('tbody').append(add);
         });

         $("#insert").on('click', '.remove', function () {
             $(this).parents('tr').remove();
         });


         $(function () {
             $("body").tooltip({
                 selector: '[data-toggle="tooltip"]',
                 container: 'body'
             });
         })
     }); 
</script>
    
</body>
</html>



