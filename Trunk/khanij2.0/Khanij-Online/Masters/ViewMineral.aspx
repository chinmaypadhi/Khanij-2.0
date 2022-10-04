<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMineral.aspx.cs" Inherits="Masters_ViewMineral" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
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
                                        <a class="nav-link" href="AddMineral.aspx">
                                            Add New Mineral
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
                                <%--<div class="search-box">
                                    <div class="searchform px-3 pt-3">
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Mineral Category </label>
                                                    <div class="col-sm-8">
                                                       <asp:DropDownList Class="form-control searchableselect" ID="DropDownList4" runat="server">
                                                        <asp:ListItem>Select Mineral Category</asp:ListItem>
                                                        <asp:ListItem>Major Mineral</asp:ListItem>
                                                        <asp:ListItem>Minor Mineral</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Mineral Schedule </label>
                                                    <div class="col-sm-8">
                                                        <asp:DropDownList Class="form-control searchableselect" ID="DropDownList3" runat="server">
                                                        <asp:ListItem>Select Schedule</asp:ListItem>
                                                        <asp:ListItem>>First Schedule of MMDR Act 1957</asp:ListItem>
                                                        <asp:ListItem>Non Schedule</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                       Mineral Schedule Part </label>
                                                    <div class="col-sm-8">
                                                       <asp:DropDownList Class="form-control searchableselect" ID="DropDownList5" runat="server">
                                                        <asp:ListItem>Select Schedule Part</asp:ListItem>
                                                        <asp:ListItem>Part A</asp:ListItem>
                                                        <asp:ListItem>Part B</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Mineral Name </label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </select>
                                                    </div>
                                                </div>
                                            </div>
                                           
                                        </div>
                                    <div class="advancesearch">
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">Mineral Unit</label>
                                                    <div class="col-sm-8">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList1" runat="server">
                                                        <asp:ListItem>Select Unit Type</asp:ListItem>
                                                        <asp:ListItem>Carat</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">Royalty Basis</label>
                                                    <div class="col-sm-8">
                                                   <asp:DropDownList Class="form-control searchableselect" ID="DropDownList2" runat="server">
                                                        <asp:ListItem>Select Royalty Basis</asp:ListItem>
                                                        <asp:ListItem>Advalorem</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                           
                                        </div>
                                    </div>
                                        <div class="row">
                                        <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <div class="col-sm-9 offset-md-4">
                                                        
                                                        <a href="#" class="btn btn-sm btn-info searchbtn rounded-0">
                                                            <i class="fas fa-chevron-down"></i> 
                                                            <span>Advance Search</span></a> 
                                                        <a href="#" class="btn btn-sm btn-success ml-0"> Show </a> 
                                                    </div>
                                                </div>
                                            </div>
                                            </div>
                                        </div>

                                   
                                </div>--%>

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
                                                           Mineral Category 
                                                            </th>
                                                            <th> 
                                                             Mineral Schedule
                                                            </th>
                                                            <th>                                                               
                                                            Mineral Schedule Part
                                                            </th>
                                                            <th>                                                                 
                                                             Mineral Name
                                                            </th>
                                                             <th>                                                                 
                                                             Mineral Unit
                                                            </th>
                                                             <th>                                                                 
                                                            Royalty Basis
                                                            </th>
                                                             <th>                                                                 
                                                           Mineral Status
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
																<p class="m-0">Minor Mineral</p>
																
															</td>
                                                            <td>
																<p class="m-0">Schedule-I of MMR</p>
															</td>
                                                            <td>                                                                
                                                               <p class="m-0">Part B</p>																
                                                            </td>
                                                             <td>                                                                
                                                               <p class="m-0">Agate</p>																
                                                            </td>
                                                             <td>                                                                
                                                               <p class="m-0">Cubic Meter</p>																
                                                            </td>
                                                             <td>                                                                
                                                               <p class="m-0">Other</p>																
                                                            </td>
                                                            <td>
																<p class="m-0">Active</p>
															</td>
                                                            <td class="noprint"><a href="AddMineral.aspx"
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



        $(document).ready(function () {
            loadNavigation('ViewMineral', 'glTMng', 'plmineral', 'tl', 'Masters', 'Minerals', '');

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

