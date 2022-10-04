<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnCopperPart4.aspx.cs" Inherits="EReturn_YearlyReturnCopperPart4" %>
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
                                        <a class="nav-link" href="YearlyReturnCopperPart3.aspx">
                                         Part 3
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="YearlyReturnCopperPart4.aspx">
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
                                 <h6 class="font-weight-bold">Consumption of Explosives<small> (Part – IV)</small></h6>
                                </div>
                              <div class="row">
                                   <div class="col-xl-12">
                                   <h5 class="text-brown font-weight-bold">Consumption of Explosives</h5>
                                   <h6 class="text-brown font-weight-bold">Licensed capacity of magazine: 
                                   (specify unit separately in kg/tonne, numbers, metres)</h6>
                                   </div>


                                   <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label font-weight-bold">Item</label>
                                              <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label font-weight-bold">Unit</label>
                                              <select class="form-control form-control-sm searchableselect">
                                                <option>Select</option>
                                                <option></option>
                                             </select>
                                            </div>
                                            <div class="col-sm-4">
                                             <label class="col-form-label font-weight-bold">Capacity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                        <div class="row">
                                            <div class="col-sm-4">
                                             <label class="col-form-label font-weight-bold">Item</label>
                                              <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-4">
                                            <label class="col-form-label font-weight-bold">Unit</label>
                                              <select class="form-control form-control-sm searchableselect">
                                                <option>Select</option>
                                                <option></option>
                                             </select>
                                            </div>
                                            <div class="col-sm-4">
                                             <label class="col-form-label font-weight-bold">Capacity</label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                        </div>
                                    <div class="col-xl-12">
                                        <div class="table-responsive">
                                <table class="table table-sm table-bordered">
<tbody>
<tr>
    <th rowspan="2" class="text-center font-weight-bold">Classification of Explosives</th>
    <th rowspan="2" class="text-center font-weight-bold">Unit</th>
    <th colspan="2" class="text-center font-weight-bold">Quantity consumed during the year</th>
    <th colspan="2" class="text-center font-weight-bold" >Estimated requirement during the next year</th>
</tr>
<tr>
    <th class="font-weight-bold">Small dia.(upto 32 mm</th>
    <th class="font-weight-bold">Large dia. (above 32 mm</th>
    <th class="font-weight-bold">Small dia.(upto 32 mm</th>
    <th class="font-weight-bold">Large dia.(above 32 mm</th>
</tr>
<tr>
    <td class="font-weight-bold">1.Gun Powder</td>
    <td>Kg.</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">2.Nitrate Mixture</td>
    <td>Kg.</td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
</tr>
<tr>
    <td>a. Loose ammonium nitrate</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td>b. Ammonium nitrate in cartridged form</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">3. Nitro compound</td>
    <td>Kg.</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">4. Liquid Oxygen soaked cartridges</td>
    <td>Kg.</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">5.Slurry explosives (Mention different trade names)</td>
    <td>Kg.</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">6. Detonators</td>
    <td>No.s</td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
</tr>
<tr>
    <td>i) Ordinary</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">ii) Electrical</td>
    <td></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
</tr>
<tr>
    <td>(a) Ordinary</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td>(b) Delay</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">7. Fuse</td>
    <td>Mts</td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
    <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
     <td><input class="form-control" type="number" placeholder="None" disabled=""></td>
</tr>
<tr>
    <td >(a)Safety Fuse</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td >(b)Detonating Fuse</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">8.Plastic ignition cord</td>
    <td>Mts</td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
<tr>
    <td class="font-weight-bold">9.Others (specify)</td>
    <td></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
    <td><input class="form-control" type="number"></td>
</tr>
</tbody>
</table>
</div>
</div>
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
    
     <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>

        $(document).ready(function () {
            loadNavigation('YearlyReturnCopperPart4', 'glereturn', 'plyearetcop', 'tl', 'E-Return Non-coal', 'Yearly Return Copper', ' ');
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






