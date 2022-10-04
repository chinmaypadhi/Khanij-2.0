<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportedTicketList.aspx.cs" Inherits="HelpDesk_ReportedTicketList" %>
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
    <style type="text/css">
        .collon { position: absolute;left: -10px;
    font-weight: 600;}
    </style>
    <script src="../js/jquery.min.js"></script>
    <script>
    function onpullTicketSubmit() {
        alert("Ticket pull back successfully.");
        $('#Pullbackticket').modal('toggle');
    }

    function onReOpenSubmit() {
        alert("Ticket has been Re-Open successfully.");
        $('#Reopenticket').modal('toggle');
    }

    function onCloseBtnClick() {
        $('#Pullbackticket').modal('hide');
        $('#Reopenticket').modal('hide');
    }
    function Closesubmit() {
        debugger;
        var _remarks = $('#Closeremark').val();
        if (_remarks == null || _remarks == "") {
            alert("Remarks Required !");
            return false;
        }
    }
    $(function () {



        //$('table > tbody  > tr').each(function (index, tr) {
        //    debugger;
        //    var editBtn = $(this).find("p #btnEdit");


        //    var forwardBtn = $(this).find("p #btnforwardticket");
        //    var osuUpdateBtn = $(this).find("p #btnupdatestatus");
        //    var closeBtn = $(this).find("p #btncloseticket");
        //    var reOpenBtn = $(this).find("p #btnReopenticket");
        //    var pullTicketBtn = $(this).find("p #btnpullticket");
        //    debugger;
        //    var BackendTicket = $(this).find("p #btntakeaction");

        //    $('[id = "' + BackendTicket[0].id + '"]').hide();
        //    var Usertype = "Admin";
        //    int Status = 0;
        //    if (UserType == "FMS" || Usertype == "FMS USER" || Usertype == "OSU" || Usertype == "OSU USER") {
        //        //$('[name = "' + responseUserBtn + '"]').hide();
        //        $('[id = "' + forwardBtn[0].id + '"]').hide();
        //        $('[id = "' + closeBtn[0].id + '"]').hide();
        //        $('[id = "' + reOpenBtn[0].id + '"]').hide();
        //        $('[id = "' + editBtn[0].id + '"]').hide();
        //        $('[id = "' + pullTicketBtn[0].id + '"]').hide();

        //        if (Status == 3 || Status == 4 || Status == 5) {
        //            $('[id = "' + osuUpdateBtn[0].id + '"]').show();
        //            //$('[name = "' + replyBtn + '"]').hide();
        //        }
        //        else if (Status == 8 || Status == 9) {
        //            $('[id = "' + closeBtn[0].id + '"]').hide();
        //            $('[id = "' + osuUpdateBtn[0].id + '"]').hide();
        //            $('[id = "' + editBtn[0].id + '"]').hide();
        //            //$('[name = "' + replyBtn + '"]').hide();
        //        }
        //   if (UserType == "OSU" || UserType == "OSU USER") {
        //            //if (data[i].IsBackendApprove == 1 && data[i].Status == 4) {
        //            //    $('[name = "' + BackendProcced + '"]').show();
        //            //}
        //            //else {
        //                if (Status == 8) {
        //                    $('[id = "' + BackendTicket[0].id + '"]').hide();
        //                }
        //                else {
        //                    $('[id = "' + BackendTicket[0].id + '"]').show();
        //                }
        //            //}


        //        }
        //        else {
        //           // $('[name = "' + BackendProcced + '"]').hide();
        //       $('[id = "' + BackendTicket[0].id + '"]').show();
        //        }
        //    }
        //     else if (UserType == "HELPDESK USER" || UserType == "HELPDESK") {
        //        $('[id = "' + closeBtn[0].id + '"]').show();
        //        $('[name = "' + reOpenBtn + '"]').hide();
        //        $('[name = "' + osuUpdateBtn + '"]').hide();
        //        $('[name = "' + editBtn + '"]').show();


        //        //$('[name = "' + replyBtn + '"]').hide();
        //        $('[name = "' + forwardBtn + '"]').hide();
        //        if (data[i].Status == 1 || data[i].Status == 9) {
        //            //$('[name = "' + responseUserBtn + '"]').show();
        //            $('[name = "' + forwardBtn + '"]').show();
        //            $('[name = "' + pullTicketBtn + '"]').hide();
        //        }
        //        else if (data[i].Status == 6 || data[i].Status == 3 || data[i].Status == 4) {
        //            //$('[name = "' + responseUserBtn + '"]').show();
        //            $('[name = "' + forwardBtn + '"]').hide();
        //            $('[name = "' + pullTicketBtn + '"]').show();
        //        }
        //        else if (data[i].Status == 8) {
        //            $('[name = "' + closeBtn + '"]').hide();
        //            $('[name = "' + osuUpdateBtn + '"]').hide();
        //            //$('[name = "' + replyBtn + '"]').hide();
        //            //$('[name = "' + responseUserBtn + '"]').hide();
        //            $('[name = "' + forwardBtn + '"]').hide();
        //            $('[name = "' + editBtn + '"]').hide();
        //            $('[name = "' + pullTicketBtn + '"]').hide();
        //        }
        //        //else {
        //        //    var cell = this.tbody.find(">tr").eq(i).find(">td:nth-last-child(1)");
        //        //    cell.hide();
        //        //}
        //    }
        //});
    });
    function PageLoad() {
        alert('y');
        //var data = this.dataSource.view();

    }
    function onBtnForwardSubmit() {
        debugger;
        alert("Request forwarded to FMS User Successfully.");
        $('#FetchUserlist').modal('toggle');
        //var _remarks = $('#Remark').val();

        //var _UserTypeId = $("#UserType").val();
        //var _DistrictId = $("#DistrictID").val();
        //var _FMSUserId = $("#Fmsuser option:selected").val();
        //var _OSUUserId = $("#Osuuser").val();
        //var _TicketId = $("#hidticket").val();
        //if (_UserTypeId == null || _UserTypeId == "") {
        //    alert("User Type Required !");
        //    return false;
        //}
        //if (_UserTypeId == "14") {
        //    if (_DistrictId == null || _DistrictId == "") {
        //        alert("District Required !");
        //        return false;
        //    }
        //    else {
        //        if (_FMSUserId == null || _FMSUserId == "") {
        //            alert("FMS Users Required !");
        //            return false;
        //        }
        //        else {
        //            $.ajax({
        //                type: "POST",

        //                url: "/Helpdesk/RaiseTicket/Update",

        //                data: {
        //                    "TicketId": parseInt(_TicketId),
        //                    "UserTypeId": _UserTypeId,
        //                    "DistrictId": _DistrictId,
        //                    "remarks": _remarks,
        //                    "FMSUserId": _FMSUserId,
        //                    "OSUUserId": _OSUUserId
        //                },

        //                dataType: "json",
        //                success: function (result) {
        //                    if (result != null) {
        //                        if (result == "1") {
        //                            alert("Request forwarded to FMS User Successfully.");
        //                        }
        //                        else if (result == "3" || result == "4") {
        //                            alert("This ticket has been forwarded by HelpDesk User to any (OSU/FMS User)");
        //                        }

        //                        else {
        //                            alert("Request not forwarded ! Please try again later.");
        //                        }
        //                    }

        //                }
        //            });
        //        }
        //    }

        //}

        //else {
        //    if (_OSUUserId == null || _OSUUserId == "") {
        //        alert("OSU Users Required !");
        //        return false;
        //    }
        //    else {

        //        $.ajax({
        //            type: "POST",

        //            url: "/Helpdesk/RaiseTicket/Update",

        //            data: {
        //                "TicketId": parseInt(_TicketId),
        //                "UserTypeId": _UserTypeId,
        //                "DistrictId": _DistrictId,
        //                "remarks": _remarks,
        //                "FMSUserId": _FMSUserId,
        //                "OSUUserId": _OSUUserId
        //            },

        //            dataType: "json",
        //            success: function (result) {
        //                if (result != null) {
        //                    if (result == "1") {
        //                        alert("Request forwarded to OSU User Successfully.");
        //                    }
        //                    else if (result == "3" || result == "4") {
        //                        alert("This ticket has been forwarded by HelpDesk User to any (OSU/FMS User)");
        //                    }

        //                    else {
        //                        alert("Request not forwarded ! Please try again later.");
        //                    }
        //                }

        //            }
        //        });
        //    }
        //}
    }
    $(document).ready(function () {
        $(document).on("click", ".popup", function () {

            var passedID = $(this).data('id');
            $(".modal-body .hiddenid").val(passedID);
            //$('.icon-edit1').on("click", function () {
            $("#EditModal").modal('show');


        });
    });

    function Closeuser(id) {
        $("#hidclose").val(id);
    }
    $(document).on("click", "#btnUpdate", function () {

    alert('Data Updated Successfully');
        

    });
    function Edituser(id) {


        
        $("#divfms").hide();
        $("#divosu").hide();
         $("#DistrictID").Empty();
        $("#DistrictID").append($("<option></option>").val(1).html('Chhattisgarh'));
    }
    $(function () {
        $("#UserType").change(function () {
            debugger;
            var usertype = $("#Usertype").val();

            var optionSelected = $("option:selected", this);
            var valueSelected = this.value;

            if (valueSelected == "18") {
                $("#divdistrict").hide();
                $("#divfms").hide();
                $("#divosu").show();
                $("#Osuuser").append($("<option></option>").val(1).html('Nihar Sahoo(OSU0004)'));
            }

            else {


                $("#divdistrict").show();
                $("#divfms").show();
                $("#divosu").hide();
            }

        });
        $("#DistrictID").change(function () {
            $("#divfms").show();
            var usertype = $("#Usertype").val();

            var optionSelected = $("option:selected", this);
            var valueSelected = this.value;
            $('#Fmsuser').empty();
            var did = valueSelected;


            $("#Fmsuser").append($("<option></option>").val(1).html('Nihar Roy(FMS0004)'));
        });
    });
    </script>
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
                                           Reported Ticket List
                                        </a>
                                    </li>
                                   
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                            <div class="p-2">
                                <div class="row no-gutters">
                                    <div class="col bg-success mr-2 text-center text-white shadow-sm">
                                        <h6>Solved Ticket</h6>
                                        <h4>81</h4>
                                    </div>
                                     <div class="col bg-info mr-2 text-center text-white shadow-sm">
                                        <h6>Reopen Ticket</h6>
                                        <h4>81</h4>
                                    </div>
                                     <div class="col bg-danger mr-2 text-center text-white shadow-sm">
                                        <h6>Action Required</h6>
                                        <h4>81</h4>
                                    </div>
                                     <div class="col bg-warning mr-2 text-center text-white shadow-sm">
                                        <h6>Ticket Under Processing</h6>
                                        <h4>81</h4>
                                    </div>
                                     <div class="col bg-secondary text-center text-white shadow-sm">
                                        <h6>Ticket Initiated</h6>
                                        <h4>81</h4>
                                    </div>
                                </div>
                                </div>     
                                <div class="search-box">
                                    <div class="searchform px-3 py-3">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="form-group row">
                                                    <div class="col-sm-2">
                                                        <select class="form-control form-control-sm">
                                                        <option value="eq">Is equal to</option>
                                                        </select>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <input type="text" class="form-control" id="Text1">
                                                    </div>
                                                     <div class="col-sm-2">
                                                        <select class="form-control form-control-sm">
                                                        <option value="eq">AND</option>
                                                        </select>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <select class="form-control form-control-sm">
                                                        <option value="eq">Is equal to</option>
                                                    </select>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <input type="text" class="form-control" id="Text2">
                                                    </div>
                                                    <div class="col-sm-2">
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
                                                    <th width="30">Sl#</th>
                                                    <th>Ticket Number</th>
                                                    <th>Open Date & time</th>
                                                    <th>State and District Name</th>
                                                    <th>Complainer Details</th>
                                                    <th>Module</th>
                                                    <th>Problem Description</th>
                                                   
                                                    <th>Priority</th>
                                                    <th>Status</th>
                                                    <th>Close Date & time</th>
                                                    <th>Days/Time Taken For Close</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            <tr class="active-row">
                                            <td><p class="m-0">1</p></td>
                                             <td>
                                                        <p class="m-0">
                                                           
                                                            <a href="javascript:void(0);" data-toggle="modal" data-target="#FetchTicketDetails" onclick="Edit(1)">Ticket_00000000010</a>
                                                        </p>
                                                    </td>
                                                    <td><p class="m-0">04-Feb-2021 , 09:32</p></td>
                                                    <td><p class="m-0">Chhattisgarh,Bemetara</p></td>
                                                    <td><p class="m-0">Suroj kumar Pradhan,9853150842</p></td>
                                                    <td><p class="m-0">Digital Signature</p></td>
                                                    <td><p class="m-0">Testing</p></td>
                                                    <td><p class="m-0">High</p></td>
                                                    <td><p class="m-0">Forwarded to FMS - Suraj Despande(FMS0004)</p></td>
                                                    <td><p class="m-0">04 Feb 2021, 10:47:41</p></td>
                                                    <td><p class="m-0">4 Days / 21 Hours / 27 Minutes </p></td>

                                                    <td>
                                                        <p class="m-0">
                                                           

                                                            <a class="btn btn-info btn-sm popup" data-toggle="tooltip" title="" data-original-title="Edit" id="btnupdatestatus">
                                                                <i class="icon-edit1"></i>Update Status
                                                            </a>
                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p class="m-0">
                                                           
                                                            <a class="btn btn-info btn-sm" href="RaiseTicket.aspx?id=1"
                                                               class="btn-floating btn-outline-primary btn-sm"
                                                               title="Edit" name='#: SrNo #btnEdit' id="btnEdit">Edit</a>
                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p class="m-0">
                                                            <a class="btn btn-info btn-sm" href="javascript:void(0);" data-toggle="modal" data-id="btnforwardticket" data-target="#FetchUserlist" onclick="Edituser(1)">Forward</a>

                                                        </p>
                                                    </td>

                                                    <td>
                                                        <p class="m-0">
                                                           <a class="btn btn-info btn-sm" href="javascript:void(0);" data-toggle="modal" data-id="btncloseticket" data-target="#CloseTicket" onclick="Closeuser(1)">Close Ticket</a>


                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p class="m-0">
                                                           <a class="btn btn-info btn-sm" href="javascript:void(0);" data-toggle="modal" data-id="btnpullticket" data-target="#Pullticket" onclick="Closeuser(1)">Pull Ticket</a>


                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p class="m-0">
                                                          <a class="btn btn-info btn-sm" href="javascript:void(0);" data-toggle="modal" data-id="btnReopenticket" data-target="#Reopenticket" onclick="Closeuser(1)">Reopen Ticket</a>


                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p class="m-0">
                                                           
                                                            <a class="btn btn-info btn-sm" href="BackendTicket.aspx"
                                                               class="btn-floating btn-outline-primary btn-sm"
                                                               title="Edit" id="btntakeaction">Take Action</a>
                                                        </p>
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
            <div id="Pullticket" class="modal fade" role="dialog">
                    <div class="modal-dialog" style="width: 700px; display: block; Top: 165px; padding-right: 50px;">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-body">
                                <div class="form-group row">
                                    <label class="col-12 col-md-4 control-label" for="demo-text-input">Remark </label>
                                    <div class="col-12 col-md-8 col-xl-8">
                                        <span class="colon">:</span>
                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="onpullTicketSubmit();">Pull Ticket</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal" onclick="onCloseBtnClick();">Close</button>
                            </div>
                        </div>

                    </div>
                </div>

                 <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" id="Reopenticket">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title" id="Comp_MHDR"></h5>
                                <button type="button" class="close" aria-label="Close" id="CloseMeeting" data-dismiss="modal">
                                    <span aria-hidden="true">&times;</span>
                                </button>


                            </div>
                            <form asp-action="CreateEdit" asp-controller="RaiseTicket" method="post" enctype="multipart/form-data">
                                <div class="modal-body">

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label" for="demo-text-input">Remark </label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <span class="colon">:</span>
                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label">
                                            Supporting Document <span class="text-danger">*</span>
                                        </label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <span class="colon">:</span>
                                            <div class="custom-file">
                                                <div class="custom-file">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />

                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label" for="demo-email-input"></label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <button class="btn btn-success mb-1" id="btnReopen" onclick="onReOpenSubmit();" >Reopen Ticket</button>
                                            <button type="button" class="btn btn-danger mb-1" data-dismiss="modal">Cancel</button>
                                        </div>

                                    </div>
                                </div>
                            </form>
                           
                        </div>
                    </div>
                </div>
               <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" id="EditModal">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title" id="H1"></h5>
                                <button type="button" class="close" aria-label="Close" id="Button1" data-dismiss="modal">
                                    <span aria-hidden="true">&times;</span>
                                </button>


                            </div>
                            <form asp-action="CreateEdit" asp-controller="RaiseTicket" method="post" enctype="multipart/form-data">
                                <div class="modal-body">

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label" for="demo-text-input">Remark </label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <span class="colon">:</span>
                                            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label">
                                            Supporting Document <span class="text-danger">*</span>
                                        </label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <span class="colon">:</span>
                                            <div class="custom-file">
                                                <div class="custom-file">
                                                    <asp:FileUpload ID="FileUpload2" runat="server" class="form-control" />

                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label" for="demo-email-input"></label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <button class="btn btn-success mb-1" id="btnUpdate">Update</button>
                                            <button type="button" class="btn btn-danger mb-1" data-dismiss="modal">Cancel</button>
                                        </div>

                                    </div>
                                </div>
                            </form>
                            
                        </div>
                    </div>
                </div>

                 <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" id="FetchTicketDetails">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title" id="H2"></h5>
                                <button type="button" class="close" aria-label="Close" id="Button2" data-dismiss="modal">
                                    <span aria-hidden="true">&times;</span>
                                </button>


                            </div>

                            <div class="modal-body">

                                <table border="1" role="grid" class="k-grid-header-wrap k-auto-scrollable" style="overflow: auto; width: 100%">
                                    <thead>
                                        <tr>
                                            <th style="width: 10%">Action Taken By</th>
                                            <th style="width: 10%">Action Taken On</th>
                                            <th style="width: 60%">Remarks</th>
                                            <th style="width: 20%">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody id="popupTable">
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                          
                        </div>
                    </div>
                </div>

                 <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" id="FetchUserlist">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title" id="H3"></h5>
                                <button type="button" class="close" aria-label="Close" id="Button3" data-dismiss="modal">
                                    <span aria-hidden="true">&times;</span>
                                </button>


                            </div>

                            <div class="modal-body">


                                <div class="modal-body">

                                    <div class="form-group row">
                                        <label class="col-sm-3 control-label" for="demo-text-input">User Type </label>
                                        <div class="col-sm-2">
                                            <span class="colon">:</span>
                                        </div>
                                        <div class="col-sm-7">
                                         <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="14" Text="Fms User"></asp:ListItem>
                                                   <asp:ListItem value="18" Text="OSU User"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Low"></asp:ListItem>
                                                  </asp:DropDownList>     

                                        </div>

                                    </div>
                                </div>
                                <div class="form-group row" id="divdistrict">
                                    <label class="col-sm-3 control-label" for="demo-text-input">District</label>
                                    <div class="col-sm-2">
                                        <span class="colon">:</span>
                                    </div>
                                    <div class="col-sm-7">
                                         <asp:DropDownList ID="DistrictID" runat="server" class="form-control">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Chhattisgarh"></asp:ListItem>
                                                  
                                                  </asp:DropDownList>     
                                    </div>
                                </div>
                                <div class="form-group row" id="divfms">
                                    <label class="col-sm-3 control-label" for="demo-text-input">Fms User</label>
                                    <div class="col-sm-2">
                                        <span class="colon">:</span>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Tanmaya Sahoo(FMS0004)"></asp:ListItem>
                                                  
                                                  </asp:DropDownList>    
                                    </div>
                                </div>

                                <div class="form-group row" id="divosu">
                                    <label class="col-sm-3 control-label" for="demo-text-input">OSU User</label>
                                    <div class="col-sm-2">
                                        <span class="colon">:</span>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="Osuuser" runat="server" class="form-control">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Nihar Sahoo(OSU0004)"></asp:ListItem>
                                                  
                                                  </asp:DropDownList>    
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 control-label" for="demo-text-input">Remarks</label>
                                    <div class="col-sm-2">
                                        <span class="colon">:</span>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="col-12 col-md-4 control-label" for="demo-email-input"></label>
                                    <div class="col-12 col-md-8 col-xl-8">
                                        <button class="btn btn-success mb-1" id="btnForward" onclick="onBtnForwardSubmit();">Forward</button>
                                        <button type="button" class="btn btn-danger mb-1" data-dismiss="modal">Cancel</button>
                                    </div>

                                </div>
                            </div>

                        </div>

                        @*<div class="modal-footer">

                </div>*@
                    </div>
                </div>
                <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" id="CloseTicket">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title" id="H4"></h5>
                                <button type="button" class="close" aria-label="Close" id="Button4" data-dismiss="modal">
                                    <span aria-hidden="true">&times;</span>
                                </button>


                            </div>

                            <form asp-action="Close" asp-controller="RaiseTicket" method="post" enctype="multipart/form-data">
                                <div class="modal-body">

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label" for="demo-text-input">Remark</label>
                                         <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label">
                                            Document <span class="text-danger">*</span>
                                        </label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <span class="colon">:</span>
                                            <div class="custom-file">
                                                <div class="custom-file">
                                                    <asp:FileUpload ID="FileUpload3" runat="server" class="form-control" />

                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-12 col-md-4 control-label" for="demo-email-input"></label>
                                        <div class="col-12 col-md-8 col-xl-8">
                                            <button class="btn btn-success mb-1" id="btnclose" onclick="Closesubmit();">Update</button>
                                            <button type="button" class="btn btn-danger mb-1" data-dismiss="modal">Cancel</button>
                                        </div>

                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
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
            loadNavigation('ReportedTicketList', 'glhelpdesk', 'plrepticlis', 'tl', 'Help Desk', 'Reported Ticket List', '');

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

    <!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
            <div class="modal-header p-2">
                <h5 class="modal-title mt-0">Complainer Details</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">×</span>
                </button>
      </div>
                <div class="modal-body">
                    
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label text-left">State</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>Chhattisgarh</label>
                            <label class="col-sm-3 col-form-label text-left">District</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>Raipur</label>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label text-left">Complainer Name</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>Vaibhav Mayee</label>
                            <label class="col-sm-3 col-form-label text-left">Complainer Mobile No.</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>9372211223</label>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label text-left">User Name</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>CTL_Vaibhav</label>
                            <label class="col-sm-3 col-form-label text-left">Category</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>Software</label>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label text-left">Module</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>E-Permit</label>
                            <label class="col-sm-3 col-form-label text-left">Item</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>E-Permit</label>
                        </div>
                         <div class="form-group row">
                            <label class="col-sm-3 col-form-label text-left">Priority</label>
                            <label class="col-sm-3 form-control-plaintext"><span class="collon">:</span>Medium</label>
                        </div>
                   
                </div>
               
            </div>
        </div>
    </div>
</body>
</html>

