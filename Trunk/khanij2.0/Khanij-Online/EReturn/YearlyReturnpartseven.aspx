<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnpartseven.aspx.cs" Inherits="EReturn_YearlyReturnpartseven" %>

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
                                        <a class="nav-link " href="YearlyReturnpartthree.aspx">
                                         Part 3
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link " href="YearlyReturnpartfour.aspx">
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
                                        <a class="nav-link active" href="YearlyReturnpartseven.aspx">
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
                                 <h6 class="font-weight-bold">Cost of production, Cost of production per tonne of ore/mineral produced <small> (Part – VII)</small></h6>
                                </div>
                               
                                

                               
                                 
                                  
                                   
                                
                               
                                 
                                  <h5 class="text-brown font-weight-bold">Production and Stocks of ROM ore at Mine-head</h5>
                                    <h6 class="text-brown font-weight-bold">1 Direct Cost</h6>
                                    <div class="row">

                                       <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Exploration</label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">b) Mining</label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c) Beneficiation(Mechanical Only)</label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        
                                          <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">2 Over-head cost</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">3 Depreciation</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">4 Interest</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">5 Royalty</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">6 Payments made to DMF</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">7 Payments made to NMET</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">8 Taxes</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">9 Dead Rent</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">10 Others (specify)</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                    <h6 class="text-brown font-weight-bold">Total (1) to (10)</h6>
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-12">
                                              <input type="number" class="form-control" placeholder="Cost per tonne (Rs)">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-sm-12">
                                                <div class="custom-control custom-checkbox">
                                                         <input type="checkbox" class="custom-control-input" id="customCheck1">
                                                         <label class="custom-control-label" for="customCheck1">
                                                        I certify that the information furnished above is correct and complete in all respects</label>
                                                </div>
                                        </div>
                                       </div>

                                       

                                    
                                    
       <div class="row mt-3">
                                    <div class="col-sm-12">
                                        <a href="javascript:void(0);" class="btn btn-success btn-md ml-0 waves-effect waves-light">Save &amp; Update</a>
                                      
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
            loadNavigation('YearlyReturnpartseven', 'glereturn', 'plyearet', 'tl', 'E-Return Non-coal', 'Yearly Return Iron Ore', ' ');
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






