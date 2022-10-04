<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnCopperPart1.aspx.cs" Inherits="EReturn_YearlyReturnCopperPart1" %>

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
                                        <a class="nav-link active" href="YearlyReturnCopperPart1.aspx">
                                         Part 1
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnCopperPart2.aspx">
                                         Part 2
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="YearlyReturnCopperPart3.aspx">
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
                                 <h6 class="font-weight-bold">General<small> (Part – I)</small></h6>
                                
                                </div>

                               
                                

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1">
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Details of mine</a>
                                  </li>
                                  <li >
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Mine other details</a>
                                  </li>
                                  <li >
                                    <a id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Particulars of area operated/Lease</a>
                                  </li>
                                   <li >
                                    <a  id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">Lease area (surface area) utilisation</a>
                                  </li>
                                   
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                    <h5 class="text-brown font-weight-bold">Details of  mine</h5>
                                       
                                        <div class="form-group row">
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Registration No. <small> (allotted by IBM)</small></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                 <label  class="col-form-label font-weight-bolder">Mine Code <small> (allotted by IBM)</small></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of the Mineral</label>
                                                <input type="text" class="form-control">
                                            </div>
                                       </div>

                                        <div class="form-group row">
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Name of Mine</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Name(s) of other mineral(s), if any,produced from the same mine</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            
                                             
                                       </div>

                                      <h5 class="text-brown font-weight-bold">Location of the mine</h5>

                                        <div class="form-group row">
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Village</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                                 <label class="col-form-label font-weight-bolder">Post Office</label>
                                                <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Tahsil/Taluk</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">District</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">State</label>
                                                <input type="text" class="form-control">
                                            </div>
                                       </div>

                                        <div class="form-group row">
                                            
                                            
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">PIN Code</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Fax No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">E-mail Id</label>
                                                <input type="email" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Mobile No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Phone No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                       </div>

                                      
                                       <h5 class="text-brown font-weight-bold">Name and address of lessee/owner (along with fax No. and e-mail)</h5>
                                      
                                       <div class="form-group row">
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of Lessee/Owner</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Address</label>
                                                 <textarea class="form-control" rows="1"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">District</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                       </div>
                                        <div class="row">
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">State</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">PIN Code</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Fax No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">E-mail Id</label>
                                                <input type="email" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Mobile No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Phone No.</label>
                                                 <input type="number" class="form-control">
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

                                  <h5 class="text-brown font-weight-bold">Mine other details</h5>
                                  
                                        <div class="form-group row">
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Registered Office of the Lessee</label>
                                               <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                 <label  class="col-form-label font-weight-bolder">Director in charge</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label class="col-form-label font-weight-bolder"> Agent</label>
                                                <input type="text" class="form-control">
                                            </div>
                                             
                                       </div>

                                        <div class="form-group row">
                                        
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Manager</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Mining Engineer in charge</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Geologist in charge</label>
                                               <input type="text" class="form-control">
                                            </div>
                                            
                                       </div>

                                        <div class="row">
                                        
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Transferor (previous owner), if any</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                 <label class="col-form-label font-weight-bolder">Date of Transfer</label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
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

                                  <h5 class="text-brown font-weight-bold">Particulars of area operated/Lease</h5>
                                  
                                       <div class="form-group row">
                                            <div class="col-sm-12">
                                                  <div class="table-responsive">
                                              <table class="table table-sm table-bordered mb-0" id="insert">
                                              <thead>
                                            <tr>
                                          <th class="font-weight-bolder" rowspan="2">Lease number allotted by the State Government</th>
                                          <th class="font-weight-bolder text-center" colspan="3">Area under lease (hectares)</th>
                                          <th class="font-weight-bolder" rowspan="2">Date of execution of mining lease deed</th>
                                          <th class="font-weight-bolder" rowspan="2">Period of lease</th>
                                          <th class="font-weight-bolder text-center" colspan="3">Area for which surface rights are held (hectares)</th>
                                          <th class="font-weight-bolder text-center" colspan="2">Date and period of renewal (if applicable)</th> 
                                          <th width="130px" class="font-weight-bolder" rowspan="2">Actions</th>
                                           </tr>
                                           <tr>
                                          
                                          <th class="font-weight-bolder">Under Forest</th>
                                          <th class="font-weight-bolder">Outside Forest</th>
                                          <th class="font-weight-bolder">Total</th>
                                           <th class="font-weight-bolder">Under Forest</th>
                                          <th class="font-weight-bolder">Outside Forest</th>
                                          <th class="font-weight-bolder">Total</th>
                                          <th class="font-weight-bolder" width="200px">Date (if applicable)</th>
                                          <th class="font-weight-bolder"  width="200px">Period of renewal</th>
                                           </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="t1">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t2">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t3">
                                                       <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t4">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t5">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t6">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t7">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t8">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t9">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="t10">
                                                        <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </td>
                                                    <td id="t11">
                                                        <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </td>
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                            </div>
                                             
                                       </div>

                                    <div class="form-group row">
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">In case there is more than one mine in the same lease area, indicate name of mine</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                                 <label class="col-form-label font-weight-bolder"> In case there is more than one mine in the same lease area, indicate name of mineral produced</label>
                                                  <input type="text" class="form-control">
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
                                  <div class="tab-pane fade" id="four" role="tabpanel" aria-labelledby="four-tab">
                               <h5 class="text-brown font-weight-bold">Lease area (surface area) utilisation</h5>
                                 <div class="row mt-3">
                                 <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(i) Already exploited & abandoned by opencast (O/C) mining</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(ii) Covered under current (O/C) Workings</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">((iii) Reclaimed/rehabilitated</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(iv) Used for waste disposal</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(v) Occupied by plant, buildings, residential, welfare buildings & roads</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(vi) Used for any other purpose (specify)</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(vii) Work done under progressive mine closure plan during the year</label>
                                            <div class="row">
                                             
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Under Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input type="number" class="form-control mb-lg-0 mb-3" placeholder="Outside Forest">
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                              <input class="form-control" readonly="readonly" type="text"  placeholder="Total">
                                            </div>
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                            <div class="form-group row">
                                                <label class="col-lg-5 col-md-12 col-sm-12 col-form-label font-weight-bolder">Ownership/exploiting Agency of the mine</label>
                                                <div class="col-lg-5 col-md-12 col-sm-12" >
                                                   <select class="form-control form-control-sm searchableselect" >
                                                          <option>Select</option>
                                                          <option>xxx</option>
                                                    </select>
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
            loadNavigation('YearlyReturnCopperPart1', 'glereturn', 'plyearetcop', 'tl', 'E-Return Non-coal', 'Yearly Return Copper', ' ');
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
        var add = '<tr><td id="t1"><input type="text" class="form-control"></td><td id="t2"><input type="text" class="form-control"></td><td id="t3"><input type="text" class="form-control"></td><td id="t4"><input type="text" class="form-control"></td><td id="t5"><input type="text" class="form-control"></td><td id="t6"><input type="text" class="form-control"></td><td id="t7"><input type="text" class="form-control"></td><td id="t8"><input type="text" class="form-control"></td><td id="t9"><input type="text" class="form-control"></td><td id="t10"><div class="input-group"><input type="text" class="form-control datepicker" id="Text3"><div class="input-group-prepend"><label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label></div></td><td id="t11"><div class="input-group"><input type="text" class="form-control datepicker" id="Text3"><div class="input-group-prepend"><label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label></div></td><td><button class="btn btn-danger btn-md remove  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Remove Row"><i class="fa fa-times" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-md add-btn  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

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


