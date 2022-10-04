<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMineral.aspx.cs" Inherits="Masters_AddMineral" %>
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
                                            Add New Mineral
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ViewMineral.aspx">
                                            View
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">Mineral Category  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList4" runat="server">
                                                        <asp:ListItem>Select Mineral Category</asp:ListItem>
                                                        <asp:ListItem>Major Mineral</asp:ListItem>
                                                        <asp:ListItem>Minor Mineral</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">Mineral Schedule <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList3" runat="server">
                                                        <asp:ListItem>Select Schedule</asp:ListItem>
                                                        <asp:ListItem>>First Schedule of MMDR Act 1957</asp:ListItem>
                                                        <asp:ListItem>Non Schedule</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label">Mineral Schedule Part <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <asp:DropDownList Class="form-control searchableselect" ID="DropDownList5" runat="server">
                                                        <asp:ListItem>Select Schedule Part</asp:ListItem>
                                                        <asp:ListItem>Part A</asp:ListItem>
                                                        <asp:ListItem>Part B</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label">Mineral Name <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-4 col-form-label">Mineral Unit <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList1" runat="server">
                                                        <asp:ListItem>Select Unit Type</asp:ListItem>
                                                        <asp:ListItem>Carat</asp:ListItem>
                                                    </asp:DropDownList>                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-4 col-form-label">Royalty Basis <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList2" runat="server">
                                                        <asp:ListItem>Select Royalty Basis</asp:ListItem>
                                                        <asp:ListItem>Advalorem</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">Mineral Status <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                    <asp:RadioButtonList ID="customRadio" class="custom-radio" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" >
                                        <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                        <asp:ListItem Value="2">Inactive</asp:ListItem>
                                    </asp:RadioButtonList>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                       
                                            <div class="col-sm-6 offset-sm-2">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                data-target=".alert-modal">Submit</a>
                                              
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
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
            loadNavigation('AddMineral', 'glTMng', 'plmineral', 'tl', 'Masters', 'Minerals', '');

            $('.searchableselect').searchableselect();


        });
    </script>
</body>
</html>

