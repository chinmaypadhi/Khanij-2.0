<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoyaltyCreator.aspx.cs" Inherits="Report_RoyaltyCreator" %>
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
                                        <a class="nav-link active" href="javascript:void(0);">
                                        Royalty Creator
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
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Mineral Category </label>
                                                    <div class="col-sm-8">
                                                    <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select Category</asp:ListItem>
                                                        <asp:ListItem>Major Mineral</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Mineral Name </label>
                                                    <div class="col-sm-8">
                                                       <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select State</asp:ListItem>
                                                        <asp:ListItem>Tin Ore</asp:ListItem>
                                                        <asp:ListItem>Moulding Sand</asp:ListItem>
                                                        <asp:ListItem>Iron ore</asp:ListItem>
                                                        <asp:ListItem>Bauxite</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Mineral Grade </label>
                                                    <div class="col-sm-8">
                                                      <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select Grade</asp:ListItem>
                                                        <asp:ListItem>Grade</asp:ListItem>
                                                        <asp:ListItem>Fines (Slime)- 65% Fe and above</asp:ListItem>
                                                        <asp:ListItem>LesseeLOI</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Status </label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select Status</option>
                                                        <option value="neq">Approved</option>
                                                        <option value="startswith">Reject</option>
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
                                                    <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select Unit</asp:ListItem>
                                                        <asp:ListItem>KG</asp:ListItem>
                                                        <asp:ListItem>Metric Tonne</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">Mineral Form</label>
                                                    <div class="col-sm-8">
                                                     <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select Form</asp:ListItem>
                                                        <asp:ListItem>For use in alumina and aluminium metal extraction</asp:ListItem>
                                                         <asp:ListItem>For use other than alumina and aluminium metal extraction</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">Schedule Part</label>
                                                    <div class="col-sm-8">
                                                    <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Select Schedule Part</asp:ListItem>
                                                        <asp:ListItem>NA	</asp:ListItem>
                                                         <asp:ListItem>Part C</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">Creator Name</label>
                                                    <div class="col-sm-8">
                                                    <asp:DropDownList CssClass="form-control searchableselect" runat="server">
                                                        <asp:ListItem>Creator Name</asp:ListItem>
                                                        <asp:ListItem>Shri Anurag Diwan(DGM0008)</asp:ListItem>
                                                         <asp:ListItem>Shri Anurag Diwan(DGM0008)</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="row">
                                        <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <div class="col-sm-8 offset-md-4">
                                                        <a href="#" class="btn btn-sm btn-info searchbtn rounded-0">
                                                            <i class="fas fa-chevron-down"></i> 
                                                            <span>Advance Search</span></a> 
                                                        <a href="#" class="btn btn-sm btn-success ml-0"> Show </a> 
                                                    </div>
                                                </div>
                                            </div>
                                            </div>
                                        </div>

                                </div>

                                <div class="content-body pt-0">
                                    <div class="legend-box">
                                          <ul class="d-flex mb-1 justify-content-end list-unstyled">
                                              <li><span class="bg-success"></span> Approved</li>
                                              <li><span class="bg-danger"></span> Reject</li>
                                            </ul>
                                          </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive" id="viewtable">
                                                <table id="datatable" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th width="20">Sl#</th>
                                                            <th>
                                                                Category
                                                            </th>
                                                            <th>
                                                             Schedule
                                                            </th>
                                                            <th> 
                                                             Schedule Part
                                                            </th>
                                                            <th>                                                               
                                                            Name
                                                            </th>
                                                            <th>                                                                 
                                                             Unit
                                                            </th>
                                                           <th>                                                                 
                                                             Form
                                                            </th>
                                                            <th>                                                                 
                                                             Grade
                                                            </th>
                                                            <th>                                                                 
                                                             Royalty Rate
                                                            </th>
                                                            <th>                                                                 
                                                             Creator Name
                                                            </th>
                                                            <th>                                                                 
                                                             Request Time
                                                            </th>
                                                           
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="active-row">
                                                            <td>1</td>
                                                            <td>
                                                              Major Mineral	
                                                            </td>
                                                            <td>
																Non Schedule	
															</td>
                                                            <td>
																NA	
															</td>
                                                            <td>                                                                
                                                              Tin Ore																	
                                                            </td>
                                                            <td>
																KG
															</td>
                                                            
                                                            <td>For use in alumina and aluminium metal extraction		</td>
                                                            <td>NA	</td>
                                                            <td>8% of 1321	</td>
                                                            <td>Shri Anurag Diwan(DGM0008)	</td>
                                                            <td>12-May-20 14:46:41	</td>
                                                        </tr>
                                                        <tr class="active-row">
                                                            <td>2</td>
                                                            <td>
                                                               Major Mineral	
                                                            </td>
                                                            <td>Non Schedule	</td>
                                                            <td>NA	</td>
                                                            <td >Moulding Sand	</td>
                                                            <td>Metric Tonne	</td>
                                                            
                                                            <td>NA	</td>
                                                            <td>NA	</td>
                                                            <td>10% of 319	</td>
                                                            <td>Shri Anurag Diwan(DGM0008)	</td>
                                                            <td>12-May-20 14:46:41	</td>
                                                        </tr>
                                                        <tr class="active-row">
                                                            <td>3</td>
                                                            <td>
                                                              Major Mineral	
                                                            </td>
                                                            <td>
																Non Schedule	
															</td>
                                                            <td>
																NA	
															</td>
                                                            <td>                                                                
                                                              Tin Ore																	
                                                            </td>
                                                            <td>
																KG
															</td>
                                                            
                                                            <td>For use in alumina and aluminium metal extraction		</td>
                                                            <td>NA	</td>
                                                            <td>8% of 1321	</td>
                                                            <td>Shri Anurag Diwan(DGM0008)	</td>
                                                            <td>12-May-20 14:46:41	</td>
                                                        </tr>
                                                        <tr class="active-row">
                                                            <td>4</td>
                                                            <td>
                                                               Major Mineral	
                                                            </td>
                                                            <td>Non Schedule	</td>
                                                            <td>NA	</td>
                                                            <td >Moulding Sand	</td>
                                                            <td>Metric Tonne	</td>
                                                            
                                                            <td>NA	</td>
                                                            <td>NA	</td>
                                                            <td>10% of 319	</td>
                                                            <td>Shri Anurag Diwan(DGM0008)	</td>
                                                            <td>12-May-20 14:46:41	</td>
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
        backMe = "yes"



    $(document).ready(function() {
        loadNavigation('RoyaltyCreator', 'gldashboard', 'pl', 'tl', 'Dashboard', 'MIS Report', '');

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
