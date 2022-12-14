<%@ Control Language="C#" AutoEventWireup="true" CodeFile="util.ascx.cs" Inherits="includes_util" %>

<div class="util-group d-flex align-items-center float-right">
        <span class="text-danger" id="indicate">(*) Indicate mandatory </span>
        <a href="javascript:PrintPage();void(0)" class="btn-floating btn-sm btn-outline-primary" title="Print" id="printIcon" data-toggle="tooltip" data-placement="top"><i class="fas fa-print"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-danger" title="Delete" id="deleteIcon" data-toggle="tooltip" data-placement="top" onClick="gotoDelete('D');"><i class="far fa-trash-alt"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-info" title="Download" id="downloadIcon" data-toggle="tooltip" data-placement="top"><i class="fas fa-download"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-success" title="Export to excel" id="excelIcon" data-toggle="tooltip" data-placement="top"><i class="far fa-file-excel"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-danger" title="Export to pdf" id="pdfIcon" data-toggle="tooltip" data-placement="top"><i class="far fa-file-pdf"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-dark" onClick="goBack();" title="Back" id="backIcon" data-toggle="tooltip" data-placement="top"><i class="fas fa-arrow-left"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-success" title="Active" id="activeIcon" data-toggle="tooltip" data-placement="top"><i class="fas fa-check"></i></a>
        <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-warning" title="In Active" id="inactiveIcon" data-toggle="tooltip" data-placement="top"><i class="fas fa-times"></i></a>
    <a href="javascript:void(0);" class="btn-floating btn-sm btn-outline-primary" title="Refresh" id="refreshIcon" data-toggle="tooltip" data-placement="top"><i class="fas fa-sync-alt"></i></a>
    </div>
    <div class="clearfix"></div>