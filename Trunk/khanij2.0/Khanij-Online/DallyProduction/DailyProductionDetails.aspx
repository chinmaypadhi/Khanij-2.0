<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyProductionDetails.aspx.cs" Inherits="DallyProduction_DailyProductionDetails" %>


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
<%--    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />--%>
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
                           
                        </li>
                        <li class="nav-item">
                            
                        </li>
                    </ul>
                    <uc1:util runat="server" ID="util" />
                </div>

                <section class="box form-container">
                   
                    <div class="content-body pt-0">
                       
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="viewtable">




                                    <table id="datatable" class="table table-sm table-bordered">
                                        <thead>
                                            <tr>
                                                <th width="30"> Sl#</th>

                                                <th>

                                                    Lessee Details
                                                </th>
                                                <th>

                                                    Mineral Name
                                                </th>
                                                <th>
                                                    Month-Year of Production
                                                </th>
                                                <th>
                                                   Total Production(In MT)
                                                </th>
                                                <th>
                                                   Paid Amount
                                                </th>
                                                <th>
                                                   Payment Date
                                                </th>
                                                <th>
                                                   Payment Status
                                                </th>

                                                
                                            </tr>
                                        </thead>




                                        <tbody>

                                            

                                            <tr class="active-row">
                                                <td>
                                                    1
                                                </td>
                                                <td><p class="m-0"></p> </td>
                                                <td><p class="m-0"></p> </td>
                                                <td><p class="m-0"></p> </td>
                                                <td><p class="m-0"></p> </td>
                                                <td><p class="m-0"></p> </td>
                                                <td><p class="m-0"</p> </td>
                                                <td><p class="m-0"></p> </td>

                                            </tr>
                                            </tbody> 

                                    </table>
                                </div>


                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</section>

           <uc1:footer runat="server" ID="footer" />
        </div>
        <!-- END CONTENT -->
    </div>
    <!-- END CONTAINER -->
    </form>
    <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
  
<!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 "><i class="fas fa-check fa-2x mb-3 text-success"></i><br> Your Form has been submitted
                        Successfully.</h5>
                    <a class="btn btn-primary btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
               
            </div>
        </div>
    </div>




    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('DailyProduction Detail', 'glTMng', 'plmineral', 'tl', 'Masters', 'Daily Production Summary Report', '');

            $('.searchableselect').searchableselect();


        });
    </script>
</body>
</html>
