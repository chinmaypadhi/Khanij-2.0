<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnpartsix.aspx.cs" Inherits="EReturn_YearlyReturnpartsix" %>
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
                                        <a class="nav-link " href="YearlyReturnpartfive.aspx">
                                         Part 5
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="YearlyReturnpartsix.aspx">
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
                                 <h6 class="font-weight-bold">Production, Despatches and stocks, To be submitted separately for each 
                                 mineral, Unit of quantity in tonnes<small> (Part – VI)</small></h6>
                                </div>
                               
                                

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1" role="presentation">
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Type & Production and Grade</a>
                                  </li>
                                  <li>
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Grade-wise ROM</a>
                                  </li>
                                  <li>
                                    <a  id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Details of deductions made</a>
                                  </li>
                                   <li>
                                    <a id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">Sales/ Dispatches effected</a>
                                  </li>
                                  <li>
                                    <a  id="five-tab" data-toggle="tab" href="#five" role="tab" aria-controls="five" aria-selected="false">Reasons for Increase/Decrease</a>
                                  </li>
                                   
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                <div class="row mt-2">
                                     <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Type of ore produced</label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio1">Hematite</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio2">Magnetite</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="row">
                                  <div class="col-xl-12">
                                     <h5 class="text-brown font-weight-bold">Production and Stocks of ROM ore at mine-head</h5>
                                     </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Open Cast workings</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Opening stock">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Production">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Closing stock">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                      <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Underground Workings</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Opening stock">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Production">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Closing stock">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div> 
                                          <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c) Dump workings</label>
                                            <div class="row">
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Opening stock">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Production">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="number" class="form-control" placeholder="Closing stock">
                                            </div>
                                           
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
                                  <div class="form-group row ">
                                            <div class="col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Grade-wise ROM ore despatches from mine head ($)</label>
                                              
                                            </div>
                                            <div class="col-sm-12">
                                            <div class="table-responsive">
                                                <table id="datatable" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th width="30">Sl#</th>
                                                            <th>Mineral Nature</th>
                                                            <th>Mineral Grade</th>
                                                            <th>Despatches From Minehead</th>
                                                            <th>Ex-Mine price</th>
                                                            <th width="100px" class="noprint">Actions</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>xxx</td>
                                                            <td>xxx</td>
                                                            <td>xxx</td>
                                                            <td>xxx</td>
                                                            <td class="noprint"><a data-toggle="modal"
                                                data-target=".alert-modal"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    data-placement="top"  title="Edit"><i class="fas fa-pencil-alt"></i></a>
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
                                  <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-5 col-form-label font-weight-bolder">Captive dispatches and ex-mine sales</label>
                                                <div class="col-sm-5">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio3" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio3">Hematite</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio4" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio4">Magnetite</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                  <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Ex-mine sales</label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio5" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio5">Hematite</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio6" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio6">Magnetite</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                  </div>
                                 <h5 class="text-brown font-weight-bold">Details of deductions made from sale value for computation of Ex-mine price (Rs / Tonne)</h5>
                                    <div class="row">
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">a) Cost of transportation (indicate loading station and distance from mine in remarks)</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-6">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">b)Loading and unloading charges</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-6">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">c) Railway freight, if applicable
(indicate destination and distance)</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-6">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">d) Port handling charges or export duty
(indicate name of port)</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-6">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">e) Charges for sampling and analysis</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-6">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">f) Rent for the plot at Stocking yard</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-6">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">g) Other charges(specify clearly)</label>
                                            <div class="row">
                                             <div class="col-sm-4">
                                              <input type="text" class="form-control" placeholder="Other">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                            <div class="col-sm-4">
                                            <textarea class="form-control" rows="1" placeholder="Enter Remark"></textarea>
                                            </div>
                                           
                                           
                                       </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Total (a) to (g)</label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="text" class="form-control" placeholder="Amount ( in Rs / Tonne)">
                                            </div>
                                           
                                           
                                           
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
                                  <div class="tab-pane fade" id="four" role="tabpanel" aria-labelledby="four-tab">
                                 
                                        <div class="form-group row ">
                                            <div class="col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Sales/ Despatches effected for Domestic Purposes and for Exports</label>
                                              
                                            </div>
                                            <div class="col-sm-12">
                                            <div class="table-responsive">
                                                <table id="Table1" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th width="30">Sl#</th>
                                                            <th>Mineral Nature</th>
                                                            <th>Mineral Grade</th>
                                                            <th>Nature of despatch</th>
                                                            <th>Registration No.</th>
                                                            <th>purchaser Consinee</th>
                                                            <th>Domestic Purposes Quantity</th>
                                                            <th>sale Value</th>
                                                            <th>Country</th>
                                                            <th>Export Quantity</th>
                                                            <th>FoBValue</th>
                                                            <th width="130px" class="noprint">Actions</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
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
                                                data-target=".alert-modal2"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    data-placement="top"  title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                   data-placement="top"   title="Delete"><i class="far fa-trash-alt"></i></a>
                                                                    <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-success btn-sm"
                                                                     data-toggle="modal"
                                                data-target=".alert-modal2" data-placement="top" title="Add New"><i class="fas fa-plus"></i></a>
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
                                   <div class="tab-pane fade" id="five" role="tabpanel" aria-labelledby="five-tab">
                                 <div class="form-group row">
                                            <div class="col-sm-6">
                                               <label class="col-form-label font-weight-bolder">Give reasons for increase/decrease in production/nil production, if any, during the month compared to the previous month</label>
                                               <textarea class="form-control" rows="2"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                       
                                            <div class="col-sm-6">
                                                 <label class="col-form-label font-weight-bolder">Give reasons for increase/decrease in grade wise ex-mine price, if any, during the month compared to the previous month</label>
                                                   <textarea class="form-control" rows="2"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
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
        <h5 class="modal-title m-0">Add New Grade Wise ROM</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">×</span>
        </button>
      </div>
                <div class="modal-body">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Nature<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                    <option>Select</option>
                                    <option></option>
                                 </select>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Grade</label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                    <option>Select</option>
                                    <option></option>
                                 </select>
                            </div>
                        </div>
                    </div>
                     <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Despatches Minehead<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Ex-mine Price<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                               <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                  
                        </div>
                    <a class="btn btn-primary btn-md ml-0" href="#">Submit</a>
                    
                </div>
               
            </div>
        </div>
    </div>
    <!-- alert 2-->
    <div class="modal fade alert-modal2" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
            <div class="modal-header p-2">
        <h5 class="modal-title m-0">Add New Sales / Dispatch Details</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">×</span>
        </button>
      </div>
                <div class="modal-body">
                <div class="row">
                    <div class="col-sm-12">
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
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Grade</label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                    <option>Select</option>
                                    <option></option>
                                 </select>
                            </div>
                        </div>
                    </div>
                      <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Nature of Dispatch<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                    <option>Select</option>
                                    <option></option>
                                 </select>
                            </div>
                        </div>
                    </div>
                     <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Registration No.<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Consigee Name<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                    <option>Select</option>
                                    <option></option>
                                 </select>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Quantity<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                               <input class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Sale Value<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                               <input class="form-control" type="text">
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
            loadNavigation('YearlyReturnpartsix', 'glereturn', 'plyearet', 'tl', 'E-Return Non-coal', 'Yearly Return Iron Ore', ' ');
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




