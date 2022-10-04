<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addRoyaltyMapping.aspx.cs" Inherits="Masters_addRoyaltyMapping" %>
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
                            <a class="nav-link active" href="javascript:void(0);">
                                Add
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="ViewRoyaltyMapping.aspx" >
                                View
                            </a>
                        </li>
                    </ul>
                    <uc1:util runat="server" ID="util" />
                </div>

                <section class="box form-container">

                    <div class="content-body">
                        <

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Category<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="MineralTypeId" name="MineralTypeId" class="form-control">
                                                <option value="">Select Mineral Category</option>
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Schedule<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="MineralScheduleID" name="MineralScheduleID" class="form-control">
                                                <option value="">Select Mineral Schedule</option>
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Schedule Part<span class="text-danger"></span></label>
                                        <div class="col-sm-7">
                                            <select id="MineralSchedulePartID" name="MineralSchedulePartID" class="form-control">
                                                <option value="">Select Mineral Schedule Part</option>
                                                
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Name<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="MineralId" name="MineralId" class="form-control">
                                                <option value="">Select Mineral Name</option>
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Unit<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select class="form-control" id="UnitId" name="UnitId">
                                                <option value="">Select Mineral Unit</option>
                                                
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Royalty Basis<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="RoyaltyRateTypeId" name="RoyaltyRateTypeId" Class="form-control">
                                                <option value="">Select Royalty Basis</option>
                                               
                                            </select>

                                        </div>
                                    </div>
                                </div>



                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Form<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="MineralNatureId" name="MineralNatureId" Class="form-control">
                                                <option value="">Select Mineral Form</option>
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Mineral Grade<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="MineralGradeId" name="MineralGradeId" Class="form-control">
                                                <option value="">Select Mineral Grade</option>
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Royalty<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="RoyaltyId" name="RoyaltyId" Class="form-control">
                                                <option value="">Select Rate Of Royalty</option>
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Grant Type <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <div class="py-2">
                                                <asp:RadioButtonList ID="customRadio" class="custom-radio" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            <asp:ListItem Value="1" Selected="True">After</asp:ListItem>
            <asp:ListItem Value="2">Before</asp:ListItem>
        </asp:RadioButtonList>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Grant Order Date <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <input type="text" id="txtGrantOrderDate" name="GrantOrderDate" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Auction Type <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="AuctionTypeId" name="AuctionName" Class="form-control">
                                                <option value="">Select Auction Type</option>
                                                <option value="With Auction">With Auction</option>
                                                <option value="Without Auction">Without Auction</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Lease Type <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <select id="ddlMinesStatus" name="LesseeTypeID" Class="form-control">
                                                <option value="">Select Status</option>
                                                
                                            </select>
                                        </div>
                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive" id="viewtable">
                                            <table id="datatable" class="table table-sm table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th scope="row">Payment Type <span class="text-danger">*</span></th>
                                                        <th scope="col">Calculation Type <span class="text-danger">*</span></th>
                                                        <th scope="col">Calculation Rate <span class="text-danger">*</span></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    
                                                            <tr class='item'>
                                                                <td>
                                                                    <p class="m-0">
                                                                        <input id="chkData" type="checkbox" name="type" class="chk"  />PaymentType
                                                                </td>
                                                                <td>
                                                                    <select id="ddlCalculationTypeId_@count" name="CalculationTypeId" Class="form-control">
                                                                        <option value="">Select Rate Of Royalty</option>
                                                                        
                                                                    </select>
                                                                </td>
                                                                <td>
                                                                    <input type="text" class="form-control" />
                                                                </td>
                                                            </tr>
                                                          
                                                        
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 offset-sm-2">
                                        <input type="submit" value='Submit' class="btn btn-primary btn-md ml-0" name="Submit" id="Submit" />
                                        <input type="reset" value="Reset" class="btn btn-danger btn-md" />
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
            loadNavigation('Add Royalty Mapping', 'glTMng', 'plmineral', 'tl', 'Masters', 'Royalty Mapping', '');

            $('.searchableselect').searchableselect();


        });
    </script>
</body>
</html>
