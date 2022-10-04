<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="RolesResponsibity_ViewUser" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" media="screen" />
    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />
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
                                        <a class="nav-link" href="AddUser.aspx">
                                            Add New User
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="javascript:void(0);">
                                        
                                            View
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="search-box">
                                    <div class="searchform px-3 pt-3">
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        User Name </label>
                                                    <div class="col-sm-8">
                                                        <input type="text" class="form-control form-control-sm" id="v">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        Login ID </label>
                                                    <div class="col-sm-8">
                                                        <input type="text" class="form-control form-control-sm" id="v">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        Department </label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select Department</option>
                                                        <option value="neq">End User</option>
                                                        <option value="startswith">Tailing Dam</option>
                                                        <option value="contains">LesseeLOI</option>
                                                    </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        Designation </label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select Designation</option>
                                                        <option value="neq">End User</option>
                                                        <option value="startswith">Tailing Dam</option>
                                                        <option value="contains">LesseeLOI</option>
                                                    </select>
                                                    </div>
                                                </div>
                                            </div>
                                           <%-- <div class="col-sm-2">
                                                <a href="#" class="btn btn-sm btn-success"> Show </a> 
                                            </div>--%>
                                        </div>
                                    <div class="advancesearch">
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">State</label>
                                                    <div class="col-sm-8">
                                                    <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select State</asp:ListItem>
                                                        <asp:ListItem>Odisha</asp:ListItem>
                                                        <asp:ListItem>Chhattishgarh</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">District</label>
                                                    <div class="col-sm-8">
                                                     <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select District</asp:ListItem>
                                                        <asp:ListItem>Korba</asp:ListItem>
                                                         <asp:ListItem>Burhanpur</asp:ListItem>
                                                         <asp:ListItem>Gondia</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">Mobile</label>
                                                    <div class="col-sm-8">
                                                        <input type="text" class="form-control" id="v">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">Email</label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="row">
                                        <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <div class="col-sm-9 offset-md-3">
                                                        
                                                        <a href="#" class="btn btn-sm btn-info searchbtn rounded-0">
                                                            <i class="fas fa-chevron-down"></i> 
                                                            <span>Advance Search</span></a> 
                                                        <a href="#" class="btn btn-sm btn-success ml-0"> Show </a> 
                                                    </div>
                                                </div>
                                            </div>
                                            </div>
                                        </div>

                                    <%--<div class="text-center"><a href="#" class="btn btn-sm shadow-sm searchbtn rounded-0">
                                        <i class="fas fa-chevron-down"></i> <span>Advance Search</span></a> 
                                    </div>--%>
                                </div>

                                <div class="content-body pt-0">
                                    <div class="legend-box">
                                          <ul class="d-flex mb-1 justify-content-end list-unstyled">
                                              <li><span class="bg-success"></span> Active</li>
                                              <li><span class="bg-warning"></span> Inactive</li>
                                            </ul>
                                          </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive" id="viewtable">
                                                <table id="datatable" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th width="30">Sl#</th>
                                                            <th width="15" class="noprint">
                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                            </th>
                                                            <th>
                                                              
                                                            User Name/Login Id
                                                            </th>
                                                            <th> 
                                                             Department/Designation 
                                                            </th>
                                                            <th width="25%">                                                               
                                                            Address
                                                            </th>
                                                            <th>                                                                 
                                                             Contact
                                                            </th>
                                                            <th width="60" class="noprint">Edit</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="active-row">
                                                            <td>1</td>
                                                            <td class="noprint">
                                                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                                            </td>
                                                            <td>
																<p class="m-0"><span class="text-muted"> Name :</span> Ziyauel khan</p>
																<p class=" m-0"><span class="text-muted">ID :</span> 4270017269</p>
															</td>
                                                            <td>
																<p class="m-0"><span class="text-muted">Dept. :</span> Transporter/Vehicle Owner</p>
																<p class="m-0"><span class="text-muted">Desg. :</span> Transporter</p>
															</td>
                                                            <td>                                                                
                                                               <p class="m-0">Ring road No. -04, Kirandul dantewada (CG),
																	Dantewada, Chhattisgarh ,
																   494556
																</p>																
                                                            </td>
                                                            <td>
																<p class="m-0"><i class="fas fa-mobile-alt text-muted"></i> +91-32065 58476</p>
																<p class="m-0"><i class="far fa-envelope text-muted"></i> ziyauel@gmail.com</p>
															</td>
                                                            <td class="noprint"><a href="AddUser.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    title="Delete"><i class="far fa-trash-alt"></i></a>
                                                            </td>
                                                        </tr>
                                                        <tr class="inactive-row">
                                                            <td>2</td>
                                                            <td class="noprint">
                                                                <asp:CheckBox ID="CheckBox3" runat="server" />
                                                            </td>
                                                            <td class="active-row"><p class="m-0"><span class="text-muted"> Name -</span> Ziyauel khan</p>
                                                              <p class=" m-0"><span class="text-muted">ID -</span> 4270017269</p></td>
                                                            <td class="active-row"><p class="m-0"><span class="text-muted">Dept. -</span> End User</p>
                                                              <p class="m-0"><span class="text-muted">Desg. -</span> End User</p></td>
                                                            <td class="active-row"><p class="m-0">Ambikapur,
                                                              Surguja ,
                                                              494556 </p></td>
                                                            <td class="active-row"><p class="m-0"><i class="fas fa-mobile-alt text-muted"></i> +91-32065 58476</p>
                                                              <p class="m-0"><i class="far fa-envelope text-muted"></i> ziyauel@gmail.com</p></td>
                                                            <td class="noprint"><a href="AddUser.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    title="Delete"><i class="far fa-trash-alt"></i></a>
                                                            </td>
                                                        </tr>
                                                        <tr class="active-row">
                                                            <td>3</td>
                                                            <td class="noprint">
                                                                <asp:CheckBox ID="CheckBox4" runat="server" />
                                                            </td>
                                                            <td><p class="m-0"><span class="text-muted"> Name -</span> Ziyauel khan</p>
                                                              <p class=" m-0"><span class="text-muted">ID -</span> 4270017269</p></td>
                                                            <td><p class="m-0"><span class="text-muted">Dept. -</span> Transporter/Vehicle Owner</p>
                                                              <p class="m-0"><span class="text-muted">Desg. -</span> Transporter</p></td>
                                                            <td><p class="m-0">Ring road No. -04, Kirandul dantewada (CG),
                                                              Dantewada, Chhattisgarh ,
                                                              494556 </p></td>
                                                            <td><p class="m-0"><i class="fas fa-mobile-alt text-muted"></i> +91-32065 58476</p>
                                                              <p class="m-0"><i class="far fa-envelope text-muted"></i> ziyauel@gmail.com</p></td>
                                                            <td class="noprint"><a href="AddUser.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    title="Delete"><i class="far fa-trash-alt"></i></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>4</td>
                                                            <td class="noprint">
                                                                <asp:CheckBox ID="CheckBox5" runat="server" />
                                                            </td>
                                                            <td class="active-row"><p class="m-0"><span class="text-muted"> Name -</span> Ziyauel khan</p>
                                                              <p class=" m-0"><span class="text-muted">ID -</span> 4270017269</p></td>
                                                            <td class="active-row"><p class="m-0"><span class="text-muted">Dept. -</span> Transporter/Vehicle Owner</p>
                                                              <p class="m-0"><span class="text-muted">Desg. -</span> Transporter</p></td>
                                                            <td class="active-row"><p class="m-0">Ring road No. -04, Kirandul dantewada (CG),
                                                              Dantewada, Chhattisgarh ,
                                                              494556 </p></td>
                                                            <td class="active-row"><p class="m-0"><i class="fas fa-mobile-alt text-muted"></i> +91-32065 58476</p>
                                                              <p class="m-0"><i class="far fa-envelope text-muted"></i> ziyauel@gmail.com</p></td>
                                                            <td class="noprint"><a href="AddUser.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    title="Delete"><i class="far fa-trash-alt"></i></a>
                                                            </td>
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
    <link rel="stylesheet"href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
<script src="../js/dataTables.bootstrap4.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"



    $(document).ready(function() {
        loadNavigation('ViewUser', 'glRoleRes', 'plUser', 'tl', 'Roles and Responsibity', 'User', '');

        $('.searchableselect').searchableselect();

        $('#datatable').DataTable();

        $('.shorting-lnk').click(function () {
            $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
        });
        $('.filter-dropdown').hide();
        $('.filter-lnk').click(function () {
            $(this).toggleClass('active');
            $(this).siblings('.filter-dropdown').slideToggle();
        });
        $('.filter-btn').click(function () {
            $(this).parent('.shorting-cell .filter-dropdown').slideUp();
            if ($(this).parent().parent('.shorting-cell').find('.filter-lnk').hasClass('active')) {
                $(this).parent().siblings('.filter-lnk').removeClass('active');
            }
            
        });
    });
    </script>
</body>
</html>
