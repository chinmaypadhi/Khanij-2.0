<%@ Page Language="C#" AutoEventWireup="true" CodeFile="datatabledownload.aspx.cs" Inherits="Dashboard_datatabledownload" %>
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
                                        <a class="nav-link active" href="ActionTaken.aspx">
                                           Download
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
                                                       <asp:TextBox ID="inputName" CssClass="form-control" runat="server"></asp:TextBox> 
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-2">
                                                <div class="form-group row">
                                                        <a href="#" class="btn btn-sm btn-success m-0"> Show </a> 
                                                </div>
                                            </div>
                                          
                                        </div>
                                    
                                        
                                        </div>

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
			<th>Order</th>
			<th>Description</th>
			<th>Deadline</th>
			<th>Status</th>
			<th>Amount</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td>1</td>
			<td>Alphabet puzzle</td>
			<td>2016/01/15</td>
			<td>Done</td>
			<td data-order="1000">€1.000,00</td>
		</tr>
		<tr>
			<td>2</td>
			<td>Layout for poster</td>
			<td></td>
			<td></td>
			<td></td>
		</tr>
		<tr>
			<td>3</td>
			<td>Image creation</td>
			<td>2016/01/23</td>
			<td></td>
			<td data-order="1500">€1.500,00</td>
		</tr>
		<tr>
			<td>4</td>
			<td>Create font</td>
			<td>2016/02/26</td>
			<td>Done</td>
			<td data-order="1200">€1.200,00</td>
		</tr>
		<tr>
			<td>5</td>
			<td>Sticker production</td>
			<td>2016/02/18</td>
			<td>Planned</td>
			<td data-order="2100">€2.100,00</td>
		</tr>
		<tr>
			<td>6</td>
			<td>Glossy poster</td>
			<td>2016/03/17</td>
			<td>To Do</td>
			<td data-order="899">€899,00</td>
		</tr>
		<tr>
			<td>7</td>
			<td>Beer label</td>
			<td>2016/05/28</td>
			<td>Confirmed</td>
			<td data-order="2499">€2.499,00</td>
		</tr>
		<tr>
			<td>8</td>
			<td>Shop sign</td>
			<td>2016/04/19</td>
			<td>Offer</td>
			<td data-order="1099">€1.099,00</td>
		</tr>
		<tr>
			<td>9</td>
			<td>X-Mas decoration</td>
			<td>2016/10/31</td>
			<td>Confirmed</td>
			<td data-order="1750">€1.750,00</td>
		</tr>
		<tr>
			<td>10</td>
			<td>Halloween invite</td>
			<td>2016/09/12</td>
			<td>Planned</td>
			<td data-order="400">€400,00</td>
		</tr>
		<tr>
			<td>11</td>
			<td>Wedding announcement</td>
			<td>2016/07/09</td>
			<td>To Do</td>
			<td data-order="299">€299,00</td>
		</tr>
		<tr>
			<td>12</td>
			<td>Member pasport</td>
			<td>2016/06/22</td>
			<td>Offer</td>
			<td data-order="149">€149,00</td>
		</tr>
		<tr>
			<td>13</td>
			<td>Drink tickets</td>
			<td>2016/11/01</td>
			<td>Confirmed</td>
			<td data-order="199">€199,00</td>
		</tr>
		<tr>
			<td>14</td>
			<td>Album cover</td>
			<td>2017/03/15</td>
			<td>To Do</td>
			<td data-order="4999">€4.999,00</td>
		</tr>
		<tr>
			<td>15</td>
			<td>Shipment box</td>
			<td>2017/02/08</td>
			<td>Offer</td>
			<td data-order="1399">€1.399,00</td>
		</tr>
		
		<tr>
			<td>16</td>
			<td>Wooden puzzle</td>
			<td>2017/01/11</td>
			<td>Done</td>
			<td data-order="1000">€1.000,00</td>
		</tr>
		<tr>
			<td>17</td>
			<td>Fashion Layout</td>
			<td>2016/01/30</td>
			<td>Planned</td>
			<td data-order="1834">€1.834,00</td>
		</tr>
		<tr>
			<td>18</td>
			<td>Toy creation</td>
			<td>2016/01/10</td>
			<td>To Do</td>
			<td data-order="1550">€1.550,00</td>
		</tr>
		<tr>
			<td>19</td>
			<td>Create stamps</td>
			<td>2016/02/26</td>
			<td>Done</td>
			<td data-order="1220">€1.220,00</td>
		</tr>
		<tr>
			<td>20</td>
			<td>Sticker design</td>
			<td>2017/02/18</td>
			<td>Planned</td>
			<td data-order="2100">€2.100,00</td>
		</tr>
		<tr>
			<td>21</td>
			<td>Poster rock concert</td>
			<td>2017/04/17</td>
			<td>To Do</td>
			<td data-order="899">€899,00</td>
		</tr>
		<tr>
			<td>22</td>
			<td>Wine label</td>
			<td>2017/05/28</td>
			<td>Confirmed</td>
			<td data-order="2799">€2.799,00</td>
		</tr>
		<tr>
			<td>23</td>
			<td>Shopping bag</td>
			<td>2017/04/19</td>
			<td>Offer</td>
			<td data-order="1299">€1.299,00</td>
		</tr>
		<tr>
			<td>24</td>
			<td>Decoration for Easter</td>
			<td>2017/10/31</td>
			<td>Confirmed</td>
			<td data-order="1650">€1.650,00</td>
		</tr>
		<tr>
			<td>25</td>
			<td>Saint Nicolas colorbook</td>
			<td>2017/09/12</td>
			<td>Planned</td>
			<td data-order="510">€510,00</td>
		</tr>
		<tr>
			<td>26</td>
			<td>Wedding invites</td>
			<td>2017/07/09</td>
			<td>To Do</td>
			<td data-order="399">€399,00</td>
		</tr>
		<tr>
			<td>27</td>
			<td>Member pasport</td>
			<td>2017/06/22</td>
			<td>Offer</td>
			<td data-order="249">€249,00</td>
		</tr>
		<tr>
			<td>28</td>
			<td>Drink tickets</td>
			<td>2017/11/01</td>
			<td>Confirmed</td>
			<td data-order="199">€199,00</td>
		</tr>
		<tr>
			<td>29</td>
			<td>Blue-Ray cover</td>
			<td>2018/03/15</td>
			<td>To Do</td>
			<td data-order="1999">€1.999,00</td>
		</tr>
		<tr>
			<td>30</td>
			<td>TV carton</td>
			<td>2019/02/08</td>
			<td>Offer</td>
			<td data-order="1369">€1.369,00</td>
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
    <style type="text/css">
        .pagination {top: -30px;position: relative;}
    </style>
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
    <link href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.flash.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.print.min.js"></script>
    
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"



        $(document).ready(function () {
            loadNavigation('NewRequrest', 'gldashboard', 'pl', 'tl', 'Dashboard', 'End User Profile Request', '');

            $('.searchableselect').searchableselect();

           // $('#datatable').DataTable();

            $('.shorting-lnk').click(function () {
                $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
            });

        });
    </script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datatable').DataTable({
                dom: 'Bfrtip',
                buttons: [
            'copy', 'excelFlash', 'excel', 'pdf', 'print', {
                text: 'Reload',
                action: function (e, dt, node, config) {
                    dt.ajax.reload();
                }
            }
        ]
            });
        });
    </script>
    
</body>
</html>



