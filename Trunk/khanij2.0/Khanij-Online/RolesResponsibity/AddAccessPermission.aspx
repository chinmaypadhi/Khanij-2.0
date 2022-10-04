<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAccessPermission.aspx.cs" Inherits="RolesResponsibity_AddAccessPermission" %>

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
    <%--<link rel="stylesheet" href="../css/mdb.min.css" media="screen" />--%>
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
                    <div class="button-links text-right">
                        <a href="#" class="btn btn-primary btn-sm active">User Wise Access Permission</a>
                        <a href="ViewUTAssignment.aspx" class="btn btn-primary btn-sm">User Type Wise Menu Assignment</a>
                    </div>
                    <!-- MAIN CONTENT AREA STARTS -->
                    <div class="row">
                        <div class="col-12">
                            <div class="main-tab">
                                <ul class="nav nav-tabs">
                                    <li class="nav-item">
                                        <a class="nav-link active" href="javascript:void(0);">
                                            Assign Roles
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ViewAccessPermission.aspx">
                                            View
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-2 col-form-label">User Type <span class="text-danger">*</span></label>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList CssClass="form-control searchableselect" ID="dropdownUserType" runat="server" data-live-search="true">
                                                        <asp:ListItem>Select User Type</asp:ListItem>
                                                        <asp:ListItem>Admin</asp:ListItem>
                                                        <asp:ListItem>MRD</asp:ListItem>
                                                        <asp:ListItem>DGM </asp:ListItem>
                                                        <asp:ListItem>Regional Office</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-2 col-form-label">Role <span class="text-danger">*</span></label>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList CssClass="form-control searchableselect" ID="DropDownList1" disabled runat="server" data-live-search="true">
                                                        <asp:ListItem>Select Role</asp:ListItem>
                                                        <asp:ListItem>Admin</asp:ListItem>
                                                        <asp:ListItem>MRD</asp:ListItem>
                                                        <asp:ListItem>DGM </asp:ListItem>
                                                        <asp:ListItem>Regional Office</asp:ListItem>
                                                    </asp:DropDownList>                                                  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-2 col-form-label">User <span class="text-danger">*</span></label>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList CssClass="form-control searchableselect" ID="DropDownList2" disabled runat="server" data-live-search="true">
                                                        <asp:ListItem>Select User</asp:ListItem>
                                                        <asp:ListItem>Admin</asp:ListItem>
                                                        <asp:ListItem>MRD</asp:ListItem>
                                                        <asp:ListItem>DGM </asp:ListItem>
                                                        <asp:ListItem>Regional Office</asp:ListItem>
                                                    </asp:DropDownList>                                                  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                        <div class="rights-accordion">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-2 col-form-label">Rights </label>
<div class="col-sm-10"> 
<div class="panel ">
    <div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox18" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseOne" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">

<div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseOne_a" aria-expanded="true" aria-controls="collapseOne_a" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox21" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseOne_a" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">
        <div class="form-check">
            <asp:CheckBox ID="CheckBox22" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox23" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
      </div>
    </div>


        <ul class="rights-chkbox-list">
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox19" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox20" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
            </ul>
      </div>
    </div>
  </div>
    <div class="panel ">
    <div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox24" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">

<div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseTwo_a" aria-expanded="true" aria-controls="collapseTwo_a" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox25" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseTwo_a" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">
        <div class="form-check">
            <asp:CheckBox ID="CheckBox26" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox27" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
      </div>
    </div>
        <ul class="rights-chkbox-list">
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox28" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox29" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
            </ul>
      </div>
    </div>
  </div>

        <div class="panel ">
    <div class="form-check">
            <asp:CheckBox ID="CheckBox30" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
  </div>
        <div class="panel ">
    <div class="form-check">
            <asp:CheckBox ID="CheckBox1" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
  </div>
        <div class="panel ">
    <div class="form-check">
            <asp:CheckBox ID="CheckBox2" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
  </div>                                          

<div class="panel ">
    <div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseThree" aria-expanded="true" aria-controls="collapseThree" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox3" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseThree" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">

<div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseThree_a" aria-expanded="true" aria-controls="collapseThree_a" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox4" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseThree_a" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">
        <div class="form-check">
            <asp:CheckBox ID="CheckBox5" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox6" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
      </div>
    </div>


        <ul class="rights-chkbox-list">
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox7" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox8" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
            </ul>
      </div>
    </div>
  </div>
    <div class="panel ">
    <div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseFour" aria-expanded="true" aria-controls="collapseFour" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox9" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseFour" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">

<div class="panel-heading"">
        <a role="button" data-toggle="collapse" href="#collapseFour_a" aria-expanded="true" aria-controls="collapseFour_a" class="panel-title trigger collapsed"></a>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox10" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
    </div>
    <div id="collapseFour_a" class="panel-collapse collapse" role="tabpanel">
      <div class="panel-body">
        <div class="form-check">
            <asp:CheckBox ID="CheckBox11" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
          <div class="form-check">
            <asp:CheckBox ID="CheckBox12" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="defaultCheck1">
                Default checkbox
                </label>
            </div>
      </div>
    </div>
        <ul class="rights-chkbox-list">
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox13" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
                <li>
                <div class="form-check">
                <asp:CheckBox ID="CheckBox14" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label" for="defaultCheck1">
                    Default checkbox
                    </label>
                </div>
                </li>
            </ul>
      </div>
    </div>
  </div>
                                          
                                                </div>
                                            </div>
                                            </div>
                                        </div>
                                            <div class="col-sm-6 offset-sm-2">
                                                <a href="#" class="btn btn-primary btn-md ml-0">Submit</a>
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
        <link rel="stylesheet" type="text/css" href="../css/searchable-select.min.css">
<script type="text/javascript" src="../js/searchable-select.min.js"></script>
    <script>
        indicateMe = "yes"


    $(document).ready(function() {
        loadNavigation('AddAccessPermission', 'glRoleRes', 'plAPermission', 'tl', 'Roles and Responsibity', 'Access Permission', ' ');

        $('.searchableselect').searchableselect();

        $(".open-button").on("click", function () {
            $(this).closest('.collapse-group').find('.collapse').collapse('show');
        });

        $(".close-button").on("click", function () {
            $(this).closest('.collapse-group').find('.collapse').collapse('hide');
        });
    });
    </script>
</body>
</html>