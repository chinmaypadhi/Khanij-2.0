<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewUTAssignment.aspx.cs" Inherits="RolesResponsibity_ViewUTAssignment" %>

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
                    <div class="button-links text-right">
                        <a href="ViewAccessPermission.aspx" class="btn btn-primary btn-sm">User Wise Access Permission</a>
                        <a href="#" class="btn btn-primary btn-sm active">User Type Wise Menu Assignment</a>
                    </div>
                    <!-- MAIN CONTENT AREA STARTS -->
                    <div class="row">
                        <div class="col-12">
                            <div class="main-tab">
                                <ul class="nav nav-tabs">
                                    <li class="nav-item">
                                        <a class="nav-link" href="AddUTAssignment.aspx">Assign Rights
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="javascript:void(0);">View
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
                                                        User Type </label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select User Type</option>
                                                        <option value="neq">Admin</option>
                                                        <option value="startswith">Asst. Mining Officer</option>
                                                        <option value="contains">Cess User</option>
                                                    </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                        Total Role </label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select Role</option>
                                                        <option value="neq">0</option>
                                                        <option value="startswith">0</option>
                                                    </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <a href="#" class="btn btn-sm btn-success mt-0"> Show </a> 
                                            </div>
                                        </div>
                                   
                                        </div>

                                </div>
                                <div class="content-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive custom-accordion" id="viewtable">
                                                <table class="table table-sm table-bordered user-list">
                                                    <thead>
                                                        <tr>
                                                            <th width="30"></th>
                                                            <th>  
                                                                User Type                                                                 

                                                            </th>
                                                            <th>         
                                                                Total Roles                                                         
                                                             
                                                            </th>
                                                            <th width="60"> Edit</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td class="text-center">
                                                                <a data-toggle="collapse" class="collapse collapsed" href="#user-1"> <i class="fas fa-chevron-right icon-show"></i><i class="fas fa-chevron-up icon-close"></i></a>
                                                            </td>
                                                            <td>Admin</td>
                                                            <td>3</td>
                                                            <td >
                                                                <a href="AddUTAssignment.aspx" class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                            </td>
                                                        </tr>
                                                        <tr id="user-1" class="collapse" data-parent=".user-list">
															<td>&nbsp;</td>
                                                            <td colspan="4">
                                                           
                                                               <table class="table table-sm table-bordered mb-0">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Assigned Roles</th>
                                                                        <th>  
                                                                           View
                                                                        </th>
                                                                        <th>         
                                                                           New
                                                                        </th>
                                                                        <th>Modify</th>
                                                                        <th>Delete</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            Geology
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Monthly Progress Reports	
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                           MPR Approval		
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    </tbody>
                                                                   </table>
                                                           
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td class="text-center">
                                                                
                                                            </td>
                                                            <td>Asst. Mining Officer</td>
                                                            <td class="active-row">0</td>
                                                            <td ><a href="AddUTAssignment.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                               
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="text-center">
                                                               
                                                            </td>
                                                            <td>Cess User</td>
                                                            <td>0</td>
                                                            <td ><a href="AddUTAssignment.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td class="text-center">
                                                                <a data-toggle="collapse" class="collapse collapsed" href="#user-4"> <i class="fas fa-chevron-right icon-show"></i><i class="fas fa-chevron-up icon-close"></i></a>
                                                            </td>
                                                            <td>Check Post In-Charge</td>
                                                            <td>5</td>
                                                            <td ><a href="AddUTAssignment.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr id="user-4" class="collapse" data-parent=".user-list">
															<td>&nbsp;</td>
                                                           <td colspan="4">
                                                            <table class="table table-sm table-bordered mb-0">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Assigned Roles</th>
                                                                        <th>  
                                                                           View
                                                                        </th>
                                                                        <th>         
                                                                           New
                                                                        </th>
                                                                        <th>Modify</th>
                                                                        <th>Delete</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            Geology
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Monthly Progress Reports	
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                           MPR Approval		
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Monthly Progress Reports	
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                           MPR Approval		
                                                                        </td>
                                                                        <td>Yes</td>
                                                                        <td>Yes</td>
                                                                        <td>
                                                                          Yes 
                                                                        </td>
                                                                        <td>Yes</td>
                                                                    </tr>
                                                                    </tbody>
                                                                   </table>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                                
                                            </div>
                                            <div class="row mt-2">
                                                <div class="col-4">
                                                    1 - 100 of 26146 items
                                                </div>
                                                <div class="col-8">
                                                    <nav aria-label="Page navigation">
                                                <ul class="pagination pg-blue float-right pagination-sm">
                                                    <li class="page-item disabled">
                                                        <span class="page-link">Prev</span>
                                                    </li>
                                                    <li class="page-item"><a class="page-link">1</a></li>
                                                    <li class="page-item active">
                                                        <span class="page-link">
                                                            2
                                                            <span class="sr-only">(current)</span>
                                                        </span>
                                                    </li>
                                                    <li class="page-item"><a class="page-link">3</a></li>
                                                    <li class="page-item">
                                                        <a class="page-link">Next </a>
                                                    </li>
                                                </ul>
                                                <div class="clearfix"></div>
                                            </nav>
                                                </div>
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
    <script>
        excelMe = "yes"
        pdfMe = "yes"

        $(function () {
            //$('[data-toggle="popover"]').popover()
            $('.address-popover').popover({
                container: 'body'
            })
        })

    $(document).ready(function() {
        loadNavigation('ViewUTAssignment', 'glRoleRes', 'plAPermission', 'tl', 'Roles and Responsibity', 'Access Permission', '');
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
