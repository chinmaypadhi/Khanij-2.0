<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MontlyReturnFormTwo.aspx.cs" Inherits="EReturnCoal_MontlyReturnFormTwo" %>
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
                                        <a class="nav-link active" href="MontlyReturnpartone.aspx">
                                         Form II
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="text-center text-dark">
                                <h6 class="font-weight-bold">First Schedule</h6>
                                <p class="font-weight-normal mb-0">Form II</p>
                                </div>
                               
                                

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1">
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Details of the Mine</a>
                                  </li>
                                  <li>
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Table A</a>
                                  </li>
                                  <li>
                                    <a  data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Table B</a>
                                  </li>
                                   <li>
                                    <a id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">Table C</a>
                                  </li>
                                   <li>
                                    <a  id="five-tab" data-toggle="tab" href="#five" role="tab" aria-controls="five" aria-selected="false">Table D</a>
                                  </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                
                                       
                                        <div class="form-group row">
                                         <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Name of Mine</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Postal address of mine</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea1" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label  class="col-form-label font-weight-bolder">Situation of Mine/Place</label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">District</label>
                                                <input type="text" class="form-control">
                                            </div>
                                           
                                       </div>

                                        <div class="form-group row">
                                            
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">State</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Name of Owner</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label class="col-form-label font-weight-bolder">Postal address of owner</label>
                                                <textarea name="textAddress" rows="1" cols="20" id="Textarea3" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                             <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Name of managing agents, if any</label>
                                                <input type="text" class="form-control">
                                            </div>
                                             
                                       </div>

                                      

                                        <div class="form-group row">
                                            
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Postal address of managing agents</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea4" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of agents, if any</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Postal address of agents</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea5" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of manager<span class="text-danger">*</span></label>
                                                 <input type="number" class="form-control">
                                            </div>
                                       </div>

                                       

                                       <div class="row">
                                            
                                            <div class="col-lg-3 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder ">Postal address of manager<span class="text-danger">*</span></label>
                                               <textarea name="textAddress" rows="1" cols="20" id="Textarea6" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="custom-control custom-checkbox">
                                                         <input type="checkbox" class="custom-control-input" id="customCheck1">
                                                         <label class="custom-control-label" for="customCheck1">
                                                        Certified that the information given above and in Tables A to C below is correct to the best of my knowledge</label>
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
                                    <div class="col-sm-12 mt-3">
                                            <div class="table-responsive">
                                                <table id="datatable" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                           
                                                            <th rowspan="3">Name OF Colliery Siding</th>
                                                            <th rowspan="3">Mineral Nature</th>
                                                            <th rowspan="3">Mineral Grade</th>
                                                            <th rowspan="3">Size Of Coal</th>
                                                            <th rowspan="3">Opening Stock</th>
                                                            <th colspan="3" class="text-center">Coal Raised</th>
                                                            <th rowspan="3">Colliery Consumption</th>
                                                            <th rowspan="3">Coalused Makingcoke Colliery</th>
                                                            <th rowspan="3">Coke Produced</th>
                                                            <th colspan="4" class="text-center">Coal Despatched</th>
                                                            <th class="noprint" rowspan="3">Actions</th>
                                                        </tr>
                                                        <tr>
                                                            <th rowspan="2">Open cast working</th>
                                                            <th colspan="2" class="text-center">Workings below ground</th>
                                                            <th  rowspan="2" >By Rail</th>
                                                            <th  rowspan="2">By Road</th>
                                                            <th  rowspan="2">By Other</th>
                                                            <th  rowspan="2">Stock at the end of month</th>
                                                            
                                                        </tr>
                                                        <tr> 
                                                            <th>Development Districts</th>
                                                            <th>Depillaring District</th>

                                                        </tr>
                                                      
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            
                                                            <td>xxx</td>
                                                            <td>xxx</td>
                                                            <td>xxx</td>
                                                           <td>xxx</td>
                                                            <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                            <td class="noprint"><a data-toggle="modal"
                                                data-target=".alert-modal"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    data-toggle="tooltip" data-placement="top" title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    data-toggle="tooltip" data-placement="top" title="Delete"><i class="far fa-trash-alt"></i></a>
                                                                    <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-success btn-sm"
                                                                     data-toggle="modal"
                                                data-target=".alert-modal" data-toggle="tooltip" data-placement="top" title="Add New"><i class="fas fa-plus"></i></a>
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
                                  
                                       <div class="row">
                                    <div class="col-sm-12 mt-3">
                                            <div class="table-responsive">
                                                <table id="datatable2" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                           
                                                            <th rowspan="2">Workings Background Type</th>
                                                            <th rowspan="2">Number in use</th>
                                                            <th colspan="4" class="text-center">Coal-cutting machines</th>
                                                            <th colspan="3" class="text-center">Mechanical Loaders</th>
                                                            <th colspan="3" class="text-center">Conveyors</th>
                                                            <th class="noprint" rowspan="2">Actions</th>
                                                        </tr>
                                                        <tr>
                                                            <th>Number in use</th>
                                                            <th>Type</th>
                                                            <th>Square metres cut</th>
                                                            <th>coal cut (tonnes)</th>
                                                            <th>Number in use</th>
                                                            <th>Type</th>
                                                            <th>coal loaded (tonnes)</th>
                                                            <th>Type</th>
                                                            <th>Length (metres)</th>
                                                            <th>coal loaded (tonnes)</th>
                                                            
                                                        </tr>
                                                        
                                                      
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            
                                                            <td>Development Districts</td>
                                                            <td>2</td>
                                                            <td>2</td>
                                                           <td>2</td>
                                                            <td>2</td>
                                                           <td>3</td>
                                                           <td>3</td>
                                                           <td>2</td>
                                                           <td>2</td>
                                                           <td>2</td>
                                                           <td>2</td>
                                                           <td>2</td>
                                                           
                                                            <td class="noprint"><a data-toggle="modal"
                                                data-target=".alert-modal2"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    data-toggle="tooltip" data-placement="top" title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    data-toggle="tooltip" data-placement="top" title="Delete"><i class="far fa-trash-alt"></i></a>
                                                                    <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-success btn-sm"
                                                                     data-toggle="modal"
                                                data-target=".alert-modal2" data-toggle="tooltip" data-placement="top" title="Add New"><i class="fas fa-plus"></i></a>
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
                                  <div class="tab-pane fade" id="four" role="tabpanel" aria-labelledby="four-tab">
                                   
                                     <h5 class="text-brown font-weight-bold text-center">Maximum number of persons employed on any one day during the month</h5>
                                     <div class="form-group row">

                                    <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-7">
                                               <label class="col-form-label font-weight-bolder ">In workings below ground on<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-5">
                                                 <label class="col-form-label font-weight-bolder">No. of employee<span class="text-danger">*</span></label>
                                                  <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                             <div class="col-sm-7">
                                                <label class="col-form-label font-weight-bolder">In all in the mine on<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <label class="col-form-label font-weight-bolder">No. of employee<span class="text-danger">*</span></label>
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
                                                <th colspan="2" class="text-center font-weight-bold">Aggregate number of mandays worked (b)(c)</th>
                                                <th colspan="5" class="text-center font-weight-bold">Aggregate number of man-days lost on account of absence (d)(e)</th>
                                                
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Men</th>
                                                <th class="text-center font-weight-bold">Women</th>
                                                <th class="text-center font-weight-bold">Sickness</th>
                                                <th class="text-center font-weight-bold">Accident</th>
                                                <th class="text-center font-weight-bold">Leave</th>
                                                <th class="text-center font-weight-bold">Other Cause</th>
                                                <th class="text-center font-weight-bold">Total</th>
                                            </tr>
                                            
                                            <tr>
                                                <td class="font-weight-bold">Belowground :(i) Mines & Loaders</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" readonly="readonly" type="number"></td>
                                               
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Belowground :(ii) Otherst</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" readonly="readonly" type="number"></td>
                                                
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Opencast Workings :(i) Mines & Loaders</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" readonly="readonly" type="number"></td>
                                               
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Opencast Workings :(ii) Others</td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                             <tr>
                                                <td class="font-weight-bold">Aboveground:</td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control"  type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
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
                                        <div class="table-responsive">
                                        <table class="table table-sm table-bordered mt-3">
                                             <tbody>
                                             <tr>
                                                <th rowspan="2" class="font-weight-bolder">Classification</th>
                                                <th rowspan="2" class="font-weight-bolder text-center">Average daily attendance during the week</th>
                                                <th rowspan="2" class="font-weight-bolder text-center">Aggregate number of manhours worked during the week</th>
                                                <th colspan="4" class="font-weight-bolder text-center">Total cash payments for work dobe during week</th>
                                               
                                            </tr>
                                             <tr>
                                                <th class="font-weight-bolder text-center">Basic Wages</th>
                                                <th class="font-weight-bolder text-center">Dearness allwance</th>
                                                <th class="font-weight-bolder text-center">Other cash payments</th>
                                                <th class="font-weight-bolder text-center">Total</th>
                                            </tr>
                                            <tr>
                                            <td class="font-weight-bolder">Below Ground:(i)Overman and Sirdars</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                                                                     
                                                                                     
                                            <tr>
                                            <td class="font-weight-bolder">Below Ground:(ii)Miners and Loaders</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>

                                             <tr>
                                            <td class="font-weight-bolder">Below Ground:(iii)Others</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Opencast Workings:(i)Overman and Sirdars</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Opencast Workings:(ii)Miners and Loaders</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Opencast Workings:(iii)Others</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Above Ground:(i) Clerical and Supervisory staff</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Above Ground:(ii) Others - men women</td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control"  type="number"></td>
                                            <td><input class="form-control" readonly  type="number"></td>
                                            </tr>
                                            </tbody>
                                        </table>
                                       </div>
                                       <div class="table-responsive">
                                        <table class="table table-sm table-bordered mt-3">
                                             <tbody>
                                             <tr>
                                                <th  class="font-weight-bolder">Classification</th>
                                                <th  width="400px" class="font-weight-bolder text-center">Total cash payments for work dobe during week</th>
                                               
                                            </tr>
                                            
                                            <tr>
                                            <td class="font-weight-bolder">Total estimated value of concessions in kind (g) given during the week : Rs.</td>
                                            <td ><input class="form-control" type="number"></td>
                                            
                                            </tr>
                                                                                     
                                                                                     
                                            <tr>
                                            <td class="font-weight-bolder">Normal hours of production shifts</td>
                                            <td ><input class="form-control" type="number"></td>
                                           
                                            </tr>

                                             <tr>
                                            <td class="font-weight-bolder">First shift</td>
                                            <td ><input class="form-control" type="number"></td>
                                            
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Second shift </td>
                                            <td ><input class="form-control" type="number"></td>
                                            
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Third shift </td>
                                            <td ><input class="form-control" type="number"></td>
                                            </tr>
                                            </tbody>
                                        </table>
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
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
             <div class="modal-header p-3">
        <h5 class="modal-title m-0">Add New for Coal Table A</h5>
        <a class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </a>
      </div>
                <div class="modal-body">
                      <div class="row">
                        <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Form<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <select class="form-control form-control-sm searchableselect">
                                        <option>Select</option>
                                        <option></option>
                                     </select>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Grade<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <select class="form-control form-control-sm searchableselect">
                                        <option>Select</option>
                                        <option></option>
                                     </select>
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Name of Colliery Siding<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text">
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Size Of Coal (1) <span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                     <input class="form-control" type="text">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal Raised<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <div class="py-2">
                                        <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1">
                                        <label class="custom-control-label" for="radio1">Open Cast</label>
                                        </div>
                                        <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2">
                                        <label class="custom-control-label" for="radio2">Workings below ground</label>
                                        </div>
                                        <div class="custom-control custom-radio custom-control-inline">
                                        <input type="radio" class="custom-control-input" id="radio3" name="radio-iRequirement" value="2">
                                        <label class="custom-control-label" for="radio3">Both</label>
                                        </div>
                                   </div>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Stock at the beginning of month (2)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Open Cast Working (3)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Colliery consumption (Boilers, Domestic etc (6)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal used in making coke in colliery (7)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coke Produced (8)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                     <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal Despatched By Rail (9)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal Despatched By Road (10)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                       <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal Despatched By Other (11)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Closing Stock (12) <span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                        
                         
                      </div>
               
                 
                 
                
                    <a class="btn btn-primary btn-md m-0" href="#">Submit</a>
                    <a class="btn btn-danger btn-md m-0" href="#">Reset</a>
                    
                </div>
               
            </div>
        </div>
    </div>
    <!-- alert 2-->
    <div class="modal fade alert-modal2" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
             <div class="modal-header p-3">
        <h5 class="modal-title m-0">Add for Machinery Table B</h5>
        <a class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </a>
      </div>
                <div class="modal-body">
                      <div class="row">
                        <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Select Background Type<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <select class="form-control form-control-sm searchableselect">
                                        <option>Select</option>
                                        <option></option>
                                     </select>
                                 </div>
                              </div>
                         </div>
                         <div class="offset-lg-6"></div>
                          <div class="col-sm-12">
                         <h6 class="text-brown  font-weight-bold">Coal-cutting machines</h6>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Number in use<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Type<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text">
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Square metres cut<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                    <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal cut (tonnes)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                     <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-12">
                         <h6 class="text-brown  font-weight-bold">Mechanical Loaders</h6>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Number in use<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Type<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal loaded (tonnes)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-12">
                         <h6 class="text-brown  font-weight-bold">Conveyors</h6>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Type<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Length (Metres)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                     <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal conveyed (tonnes)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         
                        
                         
                      </div>
               
                 
                 
                
                    <a class="btn btn-primary btn-md m-0" href="#">Submit</a>
                    <a class="btn btn-danger btn-md m-0" href="#">Reset</a>
                    
                </div>
               
            </div>
        </div>
    </div>
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
     <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>


        $(document).ready(function () {
            loadNavigation('MontlyReturnFormTwo', 'glereturncoal', 'plmonretcoal', 'tl', 'E-Return Coal', 'Monthly Return', ' ');

            $('.searchableselect').searchableselect();
            $('#datatable').DataTable();
            $('#datatable2').DataTable();
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


