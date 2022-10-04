<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="RolesResponsibity_AddUser" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                            Add New User
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ViewUser.aspx">
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
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">Login ID <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="inputLoginId" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">Full Name <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="inputName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label">User Type <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control" ID="dropdownUserType" runat="server">
                                                        <asp:ListItem>Select User</asp:ListItem>
                                                        <asp:ListItem>Admin</asp:ListItem>
                                                        <asp:ListItem>MRD</asp:ListItem>
                                                        <asp:ListItem>DGM </asp:ListItem>
                                                        <asp:ListItem>Regional Office</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label">Department <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control" ID="dropdownDepart" runat="server">
                                                        <asp:ListItem>Select Department</asp:ListItem>
                                                    </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-4 col-form-label">Designation <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control" ID="dropdownDesign" runat="server">
                                                        <asp:ListItem>Select Designation</asp:ListItem>
                                                    </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-4 col-form-label">Password <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="inputPassword" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownState" class="col-sm-4 col-form-label">State <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control" ID="dropdownState" runat="server">
                                                        <asp:ListItem>Select State</asp:ListItem>
                                                        <asp:ListItem>Andaman Nicobar</asp:ListItem>
                                                        <asp:ListItem>Andhra Pradesh </asp:ListItem>
                                                        <asp:ListItem>Arunanchal Pradesh </asp:ListItem>
                                                        <asp:ListItem>Assam</asp:ListItem>
                                                    </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label">District <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control" ID="dropdownDist" runat="server">
                                                        <asp:ListItem>Select District</asp:ListItem>
                                                    </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputMobile" class="col-sm-4 col-form-label">Mobile <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="inputMobile" CssClass="form-control" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label">Email <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="inputMail" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputPin" class="col-sm-4 col-form-label">Pin Code </label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="inputPin" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">Status <span class="text-danger">*</span></label>
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
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="textAddress" class="col-sm-4 col-form-label">Address </label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox CssClass="form-control" runat="server" TextMode="MultiLine" ID="textAddress"></asp:TextBox>
                                                    <small class="text-danger">Maximum <strong>500</strong> characters</small> 
                                                </div>
                                            </div>
                                        </div>
                                            <div class="col-sm-6 offset-sm-2">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                data-target=".alert-modal">Alert Box 1</a>
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 show-toast">Alert Box 2</a>
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
    <!-- success Modal -->
<%--    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-4 text-success"><i class="fas fa-check fa-2x mb-3"></i><br> Your Form has been submitted
                        Successfully.</h5>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-success btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
            </div>
        </div>
    </div>--%>
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

<!-- alert 2-->
<div class="outer-toast" aria-live="polite" aria-atomic="true">
<div class="toast hide" id="myToast" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false" style="position: fixed; top: 10%; right: 25%; transform: translate(-50%, 0px); min-width: 400px; z-index:9990" >
  <div class="toast-body bg-white text-center p-5">
   <h6 class="mb-4"> Do you want to Submit This Form?</h6>
      <a href="javascript:;" class=" btn btn-md btn-info" data-dismiss="toast" aria-label="Close">
      <span aria-hidden="true">Ok</span>
    </a>
  </div>
</div>
</div>

<%-- Loader --%>

<%--<div class="loader-box">
    <i class="fas fa-spinner fa-spin"></i>
</div>--%>

    <script>
        indicateMe = "yes"

    $(document).ready(function() {
        loadNavigation('AddUser', 'glRoleRes', 'plUser', 'tl', 'Roles and Responsibity', 'User', ' ');

        $(".show-toast").click(function () {
            $("#myToast").toast({ autohide: false });
            $("#myToast").toast('show');
        }); 

        $(".alert-modal").modal({
            show: false,
            backdrop: 'static'
        });
    });
    </script>
</body>
</html>
