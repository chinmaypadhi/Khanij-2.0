<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MontlyReturnpartone.aspx.cs" Inherits="EReturn_MontlyReturnInner" %>
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
                                         Part 1
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="MontlyReturnparttwo.aspx">
                                         Part 2
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="text-center text-dark">
                                <h6 class="font-weight-bold"> </h6>
                                <h6 class="font-weight-bold">Monthly Return <small>(Form F-1)</small></h6>
                                <p class="font-weight-normal mb-0">To be used for minerals other than Copper, Gold, Lead, Pyrites,Tin,
                                 Tungsten, Zinc and precious and semi-precious stones
                                </p>
                                 <h6 class="font-weight-bold">General And Labour <small>(Part – I)</small></h6>
                                
                                </div>

                                

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                    <li class="startstep activestep1">
                                      <a  class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Details of Mine</a>
                                    </li>
                                    <li>
                                        <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Name & address of Lessee/Owner</a>
                                    </li>
                                    <li>
                                         <a  id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false"> Details of Rent/ Royalty/Dead/DMF/NMET</a>
                                    </li>
                                    <li>
                                    <a  id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">Details on working of mine</a>
                                    </li>
                                    <li>
                                     <a  id="five-tab" data-toggle="tab" href="#five" role="tab" aria-controls="five" aria-selected="false"> Average Daily Employment</a>
                                    </li>
                                </ul>

                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                
                                        <h5 class="text-brown font-weight-bold">Details of Mine </h5>
                                        <div class="form-group row">
                                            <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder">Registration No.<small> (allotted by IBM)</small> </label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label  class="col-form-label font-weight-bolder">Mine Code<small> (allotted by IBM)</small></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder">Name of the Mineral</label>
                                                <input type="text" class="form-control">
                                            </div>
                                           
                                       </div>

                                        <div class="form-group row">
                                             <div class="col-sm-4">
                                                <label  class="col-form-label font-weight-bolder">Name of Mine</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Name(s) of other mineral(s)</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            
                                             
                                       </div>

                                      <h5 class="text-brown font-weight-bold">Location of the mine</h5>

                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <label  class="col-form-label font-weight-bolder">Village</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                 <label class="col-form-label font-weight-bolder">Post Office</label>
                                                <input type="text" class="form-control">
                                            </div>
                                             <div class="col-sm-3">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Tahsil/Taluk</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">District</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            
                                       </div>

                                        <div class="form-group row">
                                        <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">State</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">PIN Code</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Fax No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">E-mail Id</label>
                                                <input type="email" class="form-control">
                                            </div>
                                        </div>
                                       

                                       <div class="row">
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Mobile No.</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Phone No.</label>
                                                 <input type="number" class="form-control">
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
                                  <h5 class="text-brown font-weight-bold"> Name & address of Lessee/Owner</h5>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Name of Lessee/Owner</label>
                                               <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">District</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label  class="col-form-label font-weight-bolder">State</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">PIN Code</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            
                                             
                                       </div>

                                        <div class="form-group row">
                                        <div class="col-sm-6">
                                                 <label  class="col-form-label font-weight-bolder">Address</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea2" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                             <div class="col-sm-3">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Fax No.</label>
                                               <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label  class="col-form-label font-weight-bolder">E-mail</label>
                                                <input type="email" class="form-control">
                                            </div>
                                          
                                            
                                            
                                       </div>

                                        <div class="row">
                                            <div class="col-sm-3">
                                                 <label class="col-form-label font-weight-bolder">Mobile No.</label>
                                                 <input type="number" class="form-control">
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

                                  <h5 class="text-brown font-weight-bold">Details of Rent/Royalty/Dead/DMF/NMET</h5>
                                  
                                        <div class="form-group row">
                                            <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder">Rent paid (Rs)</label>
                                                <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label  class="col-form-label font-weight-bolder">Royalty paid (Rs)</label>
                                                 <input type="number" class="form-control">
                                            </div>
                                             <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder">Dead Rent paid (Rs)</label>
                                                <input type="number" class="form-control">
                                            </div>
                                       </div>

                                        <div class="row">
                                            <div class="col-sm-4">
                                                <label  class="col-form-label font-weight-bolder">Payment made to the DMF (Rs)</label>
                                                <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Payment made to the NMET (Rs)</label>
                                                 <input type="number" class="form-control">
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
                                  <h5 class="text-brown font-weight-bold">Details on working of mine</h5>
                                   
                                        <div class="form-group row mt-2">
                                            <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">No. of days the mine worked</label>
                                                <div class="col-sm-6">
                                                   <input type="number" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                            
                                       </div>
                                       <div class="row">
                                            <div class="col-sm-12"> <label  class="col-form-label pt-0 font-weight-bolder">Reasons for work stoppage in the mine during the month (due to strike, lockout, heavy rain, non-availability of labour, transport bottleneck, lack of demand, uneconomic operations, etc.) and the number of days of work stoppage for each reason separately</label></div>
                                            <div class="col-sm-12">
                                                  <div class="table-responsive">
                                              <table class="table table-sm border" id="insert">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">Reasons</th>
                                                   <th width="250px" class="font-weight-bolder">Number of days</th> 
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="t1">
                                                        <textarea class="form-control" rows="1"></textarea>
                                                    </td>
                                                    <td id="t2">
                                                       <input type="number" class="form-control">
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
                                    <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                     
                                   </div>
                                  <div class="tab-pane fade" id="five" role="tabpanel" aria-labelledby="five-tab">
                                   <h5 class="text-brown font-weight-bold">Average Daily Employment</h5>
                                        <div class="table-responsive">
                                        <table class="table table-sm table-bordered mt-3">
                                             <tbody>
                                             <tr>
                                                <th rowspan="2" class="font-weight-bolder text-center">Work place</th>
                                                <th colspan="2" class="font-weight-bolder text-center">Direct</th>
                                                <th colspan="2" class="font-weight-bolder text-center">Contract</th>
                                                <th colspan="2" class="font-weight-bolder text-center">Total Salary/Wages (Rs)</th>
                                            </tr>
                                             <tr>
                                                <th class="font-weight-bolder text-center">Male</th>
                                                <th class="font-weight-bolder text-center">Female</th>
                                                <th class="font-weight-bolder text-center">Male</th>
                                                <th class="font-weight-bolder text-center">Female</th>
                                                <th class="font-weight-bolder text-center">Direct</th>
                                                <th class="font-weight-bolder text-center">Contract</th>
                                            </tr>
                                                                                     <tr>
                                            <td class="font-weight-bolder">Below ground</td>
                                            <td><input class="form-control"  type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            </tr>
                                                                                     <tr>
                                            <td class="font-weight-bolder">Opencast</td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            </tr>
                                                                                     <tr>
                                            <td class="font-weight-bolder">Above ground</td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            </tr>
                                             <tr>
                                            <td class="font-weight-bolder">Total</td>
                                            <td><input class="form-control"></td>
                                            <td><input class="form-control"></td>
                                            <td><input class="form-control"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
                                            <td><input class="form-control" type="text"></td>
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
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    
    
    <script>
        
        
        $(document).ready(function () {
            loadNavigation('MontlyReturnpartone', 'glereturn', 'plmonret', 'tl', 'E-Return Non-coal', 'Monthly Return iron ore', ' ');
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
        var add = '<tr> <td id="t1"><textarea class="form-control" rows="1"></textarea></td><td id="t2"><input type="number" class="form-control"></td><td><button class="btn btn-danger btn-md remove  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Remove Row"><i class="fa fa-times" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-md add-btn  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

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

