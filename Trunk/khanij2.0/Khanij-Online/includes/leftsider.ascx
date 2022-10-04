<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leftsider.ascx.cs" Inherits="includes_leftsider" %>

<div class="page-sidebar-wrapper" id="main-menu-wrapper">
    <ul class="wraplist">
        <li class="gldashboard">
            <a href="../Dashboard/Dashboard.aspx">
                <i class="fas fa-tachometer-alt"></i>
                <span class="title">Dashboard</span>
            </a>
        </li>
        <li class="glRoleRes">
            <a href="javascript:;">
                <i class="fa fa-columns"></i>
                <span class="title">Roles & Responsibity</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="pllesseprof" href="../RolesResponsibity/LesseeProfile.aspx">Lessee Profile
                    </a>
                </li>
                <li>
                    <a class="pllicenprof" href="../RolesResponsibity/LicenseeProfile.aspx">Licensee Profile
                    </a>
                </li>

                <li>
                    <a class="plUser" href="../RolesResponsibity/ViewUser.aspx">User
                    </a>
                </li>
                <li>
                    <a class="plAPermission" href="../RolesResponsibity/ViewAccessPermission.aspx">Access Permission
                    </a>
                </li>


            </ul>
        </li>

        <li class="glTMng">
            <a href="javascript:;">
                <i class="fa fa-columns"></i>
                <span class="title">Masters</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="pldesignation" href="../Masters/AddDesignation.aspx">Designation
                    </a>
                </li>
                <li>
                    <a class="plmineralgrade" href="../Masters/AddMineraGrade.aspx">Mineral Grade
                    </a>
                </li>
                <li>
                    <a class="pldepartment" href="../Masters/NewDepartment.aspx">Department
                    </a>
                </li>
                <li>
                    <a class="plpaymenthead" href="../Masters/AddPaymentHead.aspx">Payment Head
                    </a>
                </li>

                <li>
                    <a class="plpaymenttype" href="../Masters/AddPaymentType.aspx">Payment Type
                    </a>
                </li>

                <li>
                    <a class="plleasetype" href="../Masters/AddLeaseType.aspx">Lease Type
                    </a>
                </li>

                <li>
                    <a class="pllicensetype" href="../Masters/AddLicenseType.aspx">License Type
                    </a>
                </li>

                <li>
                    <a class="plmineralform" href="../Masters/AddMineralForm.aspx">Mineral Form
                    </a>
                </li>

                <li>
                    <a class="plmineral" href="../Masters/AddMineral.aspx">Mineral
                    </a>
                </li>

                <li>
                    <a class="plstate" href="../Masters/Addstate.aspx">state
                    </a>
                </li>

                <li>
                    <a class="plDivision" href="../Masters/AddDivision.aspx">Division
                    </a>
                </li>

                <li>
                    <a class="pldistrict" href="../Masters/AddDistrict.aspx">District
                    </a>
                </li>

                <li>
                    <a class="pltehsil" href="../Masters/AddTehsil.aspx">Tehsil
                    </a>
                </li>
                <li>
                    <a class="pltehsil" href="../Masters/addMineralCategory.aspx">Mineral Category
                    </a>
                </li>
                <li><a class="pltehsil" href="../Masters/addMineralSchedule.aspx">Mineral Schedule</a></li>
                <li><a class="pltehsil" href="../Masters/addMineralSchedulePart.aspx">Mineral Schedule Part</a></li>
                <li><a class="pltehsil" href="../Masters/addRoyalty.aspx">Royalty</a></li>
                <li><a class="pltehsil" href="../Masters/addTransportationMode.aspx">Transportation Mode</a></li>
                <li><a class="pltehsil" href="../Masters/addRailwayMaster.aspx">Railway Master</a></li>
                <li><a class="pltehsil" href="../Masters/addRailwayZone.aspx">Railway Zone</a></li>
                <li><a class="pltehsil" href="../Masters/addNotice.aspx">Notice</a></li>
                <li><a class="pltehsil" href="../Masters/addMineralUnit.aspx">Mineral Unit</a></li>
                <li><a class="pltehsil" href="../Masters/addRoyaltyCreator.aspx">Royalty Creator</a></li>
                <li><a class="pltehsil" href="../Masters/addRoyaltyMapping.aspx">Royalty Mapping</a></li>
                <li><a class="pltehsil" href="../Masters/addCheckPost.aspx">Check Post</a></li>
                <li><a class="pltehsil" href="../Masters/addCompanyMaster.aspx">Company Master</a></li>
                <li><a class="pltehsil" href="../Masters/addTransparencyportalnoticeMaster.aspx">Transparency portal notice Master</a></li>
                <li><a class="pltehsil" href="../Masters/addUpdateStatus.aspx">Update Status</a></li>
                <li><a class="pltehsil" href="../Masters/addApplicationSetting.aspx">Application Setting</a></li>
                <li><a class="pltehsil" href="../Masters/addFactoryConfiguration.aspx">Factory Configuration</a></li>
                <li><a class="pltehsil" href="../Masters/addCreateLesseelicensee.aspx">Create Lessee/licensee</a></li>
                <li><a class="pltehsil" href="../Masters/addRuleMaster.aspx">Rule Master</a></li>
                <li><a class="pltehsil" href="../Masters/addPolicyMaster.aspx">Policy Master</a></li>
                <li><a class="pltehsil" href="../Masters/addWeighbridge.aspx">Weighbridge</a></li>
                <li><a class="pltehsil" href="../Masters/addRoute.aspx">Route</a></li>
                <li><a class="pltehsil" href="../Masters/addFeedback.aspx">Feedback</a></li>
                <li><a class="pltehsil" href="../Masters/addMenu.aspx">Menu</a></li>
            </ul>
        </li>

        <li class="glUIS">
            <a href="javascript:;">
                <i class="fa fa-columns"></i>
                <span class="title">User Information System</span>
                <span class="arrow "></span>
            </a>

            <ul class="sub-menu">
                <li>
                    <a href="#">
                        <span>Lessee Profile</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span>Licensee Profile</span>
                    </a>
                </li>
                <li>
                    <a class="plsubuser" href="../UserInformationSystem/AddSubUser.aspx">
                        <span>Sub User</span>
                    </a>
                </li>
                <li>
                    <a class="plsubuserright" href="../UserInformationSystem/AddSubUserRights.aspx">
                        <span>Sub User Rights</span>
                    </a>
                </li>
                <li>
                    <a class="pltailinguserprofil" href="../UserInformationSystem/AddTailingDamUserProfile.aspx">
                        <span>Tailing Dam User Profile</span>
                    </a>
                </li>
                <li>
                    <a class="pltilingaproval" href="../UserInformationSystem/ViewTailingDamApproval.aspx">
                        <span>Tailing Dam Approval</span>
                    </a>
                </li>
            </ul>
        </li>



        <li class="glStar">
            <a href="../StarRating/StarRating.aspx">
                <i class="fa fa-columns"></i>
                <span class="title">Star Rating Minor Minerals</span>
            </a>
        </li>


        <li class="glhelpdesk">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Help Desk</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plraiseticket" href="../HelpDesk/RaiseTicket.aspx">
                        <span>Raise Ticket</span>
                    </a>
                </li>
                <li>
                    <a class="plrepticlis" href="../HelpDesk/ReportedTicketList.aspx">
                        <span>Reported Ticket List</span>
                    </a>
                </li>
                <li>
                    <a class="plsumrep" href="../HelpDesk/SummaryReport.aspx">
                        <span>Summary Report</span>
                    </a>
                </li>
            </ul>
        </li>


        <li class="glnoticeletter">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Notice/Letter</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plsendnot" href="../NoticeLetter/SendNoticeLetter.aspx">
                        <span>Send Notice/Letter</span>
                    </a>
                </li>
                <li>
                    <a class="plnotinbox" href="../NoticeLetter/NoticeLetterinbox.aspx">
                        <span>Notice/Letter Inbox</span>
                    </a>
                </li>
                <li>
                    <a class="plviewnotlet" href="../NoticeLetter/ReceivedReply.aspx">
                        <span>Sent Notice/Letter</span>
                    </a>
                </li>
                <li>
                    <a class="plnotpay" href="../NoticeLetter/NoticePenalty.aspx">
                        <span>Notice/Letter Payment</span>
                    </a>
                </li>
            </ul>
        </li>

        <li class="glereturn">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">E-Return Non-coal</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plmonret" href="../EReturn/MontlyReturn.aspx">
                        <span>Montly Return Iron Ore</span>
                    </a>
                </li>
                <li>
                    <a class="plyearet" href="../EReturn/YearlyReturn.aspx">
                        <span>Yearly Return Iron Ore</span>
                    </a>
                </li>
                <li>
                    <a class="plmonretcop" href="../EReturn/MontlyReturnCopper.aspx">
                        <span>Montly Return Copper</span>
                    </a>
                </li>
                <li>
                    <a class="plyearetcop" href="../EReturn/YearlyReturnCopper.aspx">
                        <span>Yearly Return Copper</span>
                    </a>
                </li>

            </ul>
        </li>

        <li class="glereturncoal">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">E-Return coal</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plmonretcoal" href="../EReturnCoal/MontlyReturnCoal.aspx">
                        <span>Montly Return</span>
                    </a>
                </li>
                <li>
                    <a class="plyearetcoal" href="../EReturnCoal/YearlyReturnCoal.aspx">
                        <span>Yearly Return</span>
                    </a>
                </li>

            </ul>
        </li>
        <li class="glereturnlicensee">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">E-Return Licensee</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="pleretlienmon" href="../EReturnLicensee/MontlyReturn.aspx">
                        <span>Montly Return</span>
                    </a>
                </li>
                <li>
                    <a class="plerlieyearly" href="../EReturnLicensee/YearlyReturn.aspx">
                        <span>Yearly Return</span>
                    </a>
                </li>

            </ul>
        </li>
        <li class="gletransitpass">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">E-Transit pass</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plpurcon" href="../ETransitPass/PurchaserConsignee.aspx">
                        <span>Purchaser Consignee</span>
                    </a>
                </li>
                <li>
                    <a class="pletrapas" href="../ETransitPass/Adde-TransitPassTP.aspx">
                        <span>E-Transit Pass - TP</span>
                    </a>
                </li>

            </ul>
        </li>

        <li class="glepermit">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">E-Permit</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="Epermit" href="../Epermit/ApplyePermit.aspx">
                        <span>Apply e-permit</span>
                    </a>
                </li>

            </ul>
        </li>

        <li class="glchangerequest">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Change Request</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="pladdintcr" href="../changeRequest/AddInitialChangeRequest.aspx">
                        <span>Initial Change Request</span>
                    </a>
                </li>
                <%--<li>
                                        <a class="plsubtim" href="../changeRequest/SubmitionofTimeline.aspx">
                                            <span>Submition of Timeline</span>
                                        </a>
                                    </li>--%>
                <li>
                    <a class="plsubtimeline" href="../changeRequest/SubmitTimeline.aspx">
                        <span>Submit Timeline</span>
                    </a>
                </li>
                <li>
                    <a class="plstaotim" href="../changeRequest/StatusofTimeline.aspx">
                        <span>Status of Timeline</span>
                    </a>
                </li>
                <li>
                    <a class="plappoad" href="../changeRequest/ApprovalofUATDate.aspx">
                        <span>Approval of UAT Date</span>
                    </a>
                </li>
                <li>
                    <a class="pluatfee" href="../changeRequest/UATFeedback.aspx">
                        <span>UAT Feedback</span>
                    </a>
                </li>

                <li>
                    <a class="plupsrs" href="../changeRequest/UploadSRS.aspx">
                        <span>Upload SRS</span>
                    </a>
                </li>
                <li>
                    <a class="appsrs" href="../changeRequest/ApprovalofSRS.aspx">
                        <span>Approval of SRS</span>
                    </a>
                </li>
                <li>
                    <a class="updevsta" href="../changeRequest/UpdateDevelopmentStatus.aspx">
                        <span>Update Development Status</span>
                    </a>
                </li>
                <li>
                    <a class="plreqdatliv" href="../changeRequest/RequestdateCRLive.aspx">
                        <span>Request date CR in Live</span>
                    </a>
                </li>

            </ul>
            <%--<ul class="sub-menu">
                                    <li>
                                        <a class="pladdintcr" href="../changeRequest/AddInitialChangeRequest.aspx">
                                            <span>Initial Change Request</span>
                                        </a>
                                    </li>
                                     <li>
                                        <a class="plsubtim" href="../changeRequest/SubmitionofTimeline.aspx">
                                            <span>Submition of Timeline</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a class="plupsrs" href="../changeRequest/UploadSRS.aspx">
                                            <span>Upload SRS</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a class="appsrs" href="../changeRequest/ApprovalofSRS.aspx">
                                            <span>Approval of SRS</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a class="updevsta" href="../changeRequest/UpdateDevelopmentStatus.aspx">
                                            <span>Update Development Status</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a class="plreqdatliv" href="../changeRequest/RequestdateCRLive.aspx">
                                            <span>Request date CR in Live</span>
                                        </a>
                                    </li>
                                    
                                </ul>--%>
        </li>

        <li class="glgeology">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Geology</span>
                <span class="arrow"></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plfieprord" href="../Geology/FieldProgramOrders.aspx">
                        <span>Field Program Orders</span>
                    </a>
                </li>
                <li>
                    <a class="plfpocre" href="../Geology/FPOCreator.aspx">
                        <span>FPO Creator</span>
                    </a>
                </li>
                <li>
                    <a class="plfpoappr" href="../Geology/FPOApprover.aspx">
                        <span>FPO Approver</span>
                    </a>
                </li>
                <li>
                    <a class="plmonprorep" href="../Geology/MonthlyProgressReports.aspx">
                        <span>Monthly Progress Reports</span>
                    </a>
                </li>
                <li>
                    <a class="plmrpfor" href="../Geology/MPRForwarder.aspx">
                        <span>MPR Forwarder</span>
                    </a>
                </li>
                <li>
                    <a class="plmrappr" href="../Geology/MPRApproval.aspx">
                        <span>MPR Approval</span>
                    </a>
                </li>
                <li>
                    <a class="pllabrep" href="../Geology/AddLabReport.aspx">
                        <span>Lab Report</span>
                    </a>
                </li>
                <li>
                    <a class="planasam" href="../Geology/AnalysedSamples.aspx">
                        <span>Analysed Samples</span>
                    </a>
                </li>
                <li>
                    <a class="plfierepsta" href="../Geology/FieldReportStatus.aspx">
                        <span>Field Report Status</span>
                    </a>
                </li>
                <li>
                    <a class="plrepfor" href="../Geology/FieldReportForward.aspx">
                        <span>Field Report Forward</span>
                    </a>
                </li>
                <li>
                    <a class="plrepforapp" href="../Geology/FieldReportApproval.aspx">
                        <span>Field Report Approval</span>
                    </a>
                </li>
                <li>
                    <a class="plrecnewsam" href="../Geology/RecieveNewSample.aspx">
                        <span>Receive New Samples</span>
                    </a>
                </li>
                <li>
                    <a class="plsubinsrep" href="../Geology/AddSubmitInspectionReport.aspx">
                        <span>Submit Inspection Report</span>
                    </a>
                </li>
                <li>
                    <a class="plsubttedinre" href="../Geology/SubmittedInspectionReport.aspx">
                        <span>Submitted Inspection Report</span>
                    </a>
                </li>

            </ul>
        </li>

        <li class="glholiday">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Leave</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plholtype" href="../Leave/AddHolidayType.aspx">
                        <span>Holiday Type</span>
                    </a>
                </li>
                <li>
                    <a class="plholiday" href="../Leave/AddHoliday.aspx">
                        <span>Holiday</span>
                    </a>
                </li>
                <li>
                    <a class="pllearu" href="../Leave/AddLeaveRule.aspx">
                        <span>Leave Rule</span>
                    </a>
                </li>
                <li>
                    <a class="plleatyp" href="../Leave/AddLeaveType.aspx">
                        <span>Leave Type</span>
                    </a>
                </li>
                <li>
                    <a class="plauth" href="../Leave/AddAuthorities.aspx">
                        <span>Authorities</span>
                    </a>
                </li>
                <li>
                    <a class="plridleav" href="../Leave/AddRiderLeave.aspx">
                        <span>Rider leave</span>
                    </a>
                </li>
                <li>
                    <a class="plappleav" href="../Leave/AddApplyLeave.aspx">
                        <span>Apply Leave</span>
                    </a>
                </li>
                <li>
                    <a class="plleavinbox" href="../Leave/LeaveInbox.aspx">
                        <span>Leave Inbox</span>
                    </a>
                </li>
                <li>
                    <a class="plleaveapp" href="../Leave/LeaveApplicationAll.aspx">
                        <span>Leave Application</span>
                    </a>
                </li>


            </ul>
        </li>

        <li class="glempprofile">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Employee Profil</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plofficetype" href="../EmplyeeProfile/AddOfficeType.aspx">
                        <span>Office Level</span>
                    </a>
                </li>
               <%-- <li>
                    <a class="ploffice" href="../EmplyeeProfile/AddOffice.aspx">
                        <span>Office</span>
                    </a>
                </li>--%>
                <li>
                    <a class="plsection" href="../EmplyeeProfile/AddSection.aspx">
                        <span>Section</span>
                    </a>
                </li>
                <%--<li>
                    <a class="plsecmap" href="../EmplyeeProfile/AddSectionMapping.aspx">
                        <span>Section Mapping</span>
                    </a>
                </li>--%>
                <li>
                    <a class="plemperinf" href="../EmplyeeProfile/EmpPersonalDetails.aspx">
                        <span>Emp Personal Details</span>
                    </a>
                </li>
                <%--<li>
                    <a class="plemcurpd" href="../EmplyeeProfile/EmpCurrentPostingDetail.aspx">
                        <span>Emp Current Posting Detail</span>
                    </a>
                </li>
                <li>
                    <a class="pladdinf" href="../EmplyeeProfile/AddressInformation.aspx">
                        <span>Address Information</span>
                    </a>
                </li>--%>

                <li>
                    <a class="pllast" href="../EmplyeeProfile/ListEmpPersonalDetails.aspx">
                        <span>Emplyees Deatils</span>
                    </a>
                </li>

            </ul>
        </li>

        <li class="glepermit">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Demand/Credit Note</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="Epermit" href="../DemandCreditNotePayment/DemandNotePayment.aspx">
                        <span>Demand/Credit Note Payment</span>
                    </a>
                    <a class="Epermit" href="../DemandCreditNotePayment/AddManualCreditAmount.aspx">
                        <span>Manual Credit Amount</span>
                    </a>
                </li>

            </ul>
        </li>

        <li class="glnoticeletter">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Grievance</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plsendnot" href="../Grievance/AddGrievance.aspx">
                        <span>Complaint Register</span>
                    </a>
                </li>
                <li>
                    <a class="plnotinbox" href="../Grievance/GrievanceComplaint_List.aspx">
                        <span>Complaint List</span>
                    </a>
                </li>
                <li>
                    <a class="plviewnotlet" href="../Grievance/GeneratedComplaints.aspx">
                        <span>Generated Complaints</span>
                    </a>
                </li>
                <li>
                    <a class="plnotpay" href="../Grievance/PendancyComplaints.aspx">
                        <span>Pendancy Complaints</span>
                    </a>
                </li>
                <li>
                    <a class="plnotpay" href="../Grievance/Submission_of_Complaint.aspx">
                        <span>Submission of Complaint</span>
                    </a>
                </li>
            </ul>
        </li>



        <li class="glnoticeletter">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">End User</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plsendnot" href="../EndUserProfileRequest/NewRequrest.aspx">
                        <span>New Request</span>
                    </a>
                </li>


            </ul>
        </li>
        <li class="glepermit">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Vehicle Owner</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="Vehicle" href="../VehicleOwner/Profile.aspx">
                        <span>Profile</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/EditProfile.aspx">
                        <span>Edit Profile</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/AddVehicle.aspx">
                        <span>Add Vehicle</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/VehicleTrips.aspx">
                        <span>Vehicle Trips</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/Create.aspx">
                        <span>Manage BreakDown</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/Vehicle.aspx">
                        <span>Vehicle Details</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/Vehicle.aspx">
                        <span>Vehicle Details Payment Count/Generated Slip</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/VehiclesPayment.aspx">
                        <span>VehicleRenewal Details</span>
                    </a>
                </li>
                <li>
                    <a class="Vehicle" href="../VehicleOwner/ApprovalLetter.aspx">
                        <span>Vehicle Breakdown</span>
                    </a>
                </li>

            </ul>
        </li>
        <li class="glcheckpost">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">Checkpost</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="Epermit" href="../Checkpost/CheckEPass.aspx">
                        <span>Check Transit Pass</span>
                    </a>
                    <a class="Epermit" href="../Checkpost/IrregularityCases.aspx">
                        <span>Cases Of Irregularity</span>
                    </a>
                    <a class="Epermit" href="../Checkpost/SubmitCases.aspx">
                        <span>Submit Irregularity</span>
                    </a>

                </li>

            </ul>
        </li>
        <li class="glaec">
            <a href="javascript:void(0);">
                <i class="fa fa-columns"></i>
                <span class="title">AEC</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a class="plaecconf" href="../AEC/AddConfiguration.aspx">
                        <span>Configuration</span>
                    </a>
                </li>
                <li>
                    <a class="plselapp" href="../AEC/AddSelfAppraisal.aspx">
                        <span>Self Appraisal Class 1,2,3</span>
                    </a>
                </li>
                <li>
                    <a class="plrera" href="../AEC/RemarkReportingAuthority.aspx">
                        <span>Remark Reporting Authority</span>
                    </a>
                </li>
                <li>
                    <a class="plgreau" href="../AEC/GradingReviewingAuthority.aspx">
                        <span>Grading Reviewing Authority</span>
                    </a>
                </li>
                <li>
                    <a class="plgracau" href="../AEC/GradingAcceptingAuthority.aspx">
                        <span>Grading Accepting Authority</span>
                    </a>
                </li>
                <li>
                    <a class="plaffc" href="../AEC/AddAppraisalFormforClassIII.aspx">
                        <span>Appraisal Form for Class III</span>
                    </a>
                </li>
                <li>
                    <a class="plvreac" href="../AEC/ViewReviewingAuthorityClass.aspx">
                        <span>Reviewing  Authority  Class</span>
                    </a>
                </li>
                <li>
                    <a class="placcauc" href="../AEC/AcceptingAuthorityClassIII.aspx">
                        <span>Accepting Authority Class III</span>
                    </a>
                </li>
                <li>
                    <a class="plppfps" href="../AEC/AddAppraisalFromforPAStaff.aspx">
                        <span>Appraisal Form  for PA Staff</span>
                    </a>
                </li>
                <li>
                    <a class="plrapss" href="../AEC/ReviewingAuthorityPAStaff.aspx">
                        <span>Reviewing Authority  PA Staff </span>
                    </a>
                </li>
                <li>
                    <a class="plaaps" href="../AEC/AcceptingAuthorityPAStaff.aspx">
                        <span>Accepting Authority PA Staff</span>
                    </a>
                </li>
                <li>
                    <a class="plaaeffc" href="../AEC/AppraisalFromforClassIV.aspx">
                        <span>Appraisal Form  for Class IV</span>
                    </a>
                </li>
                <li>
                    <a class="plaecad" href="../AEC/AddAppraisalforDriver.aspx">
                        <span>Appraisal for Driver</span>
                    </a>
                </li>
                <li>
                    <a class="plaecapp" href="../AEC/ClassOneTwoThree.aspx">
                        <span>AEC Applications</span>
                    </a>
                </li>



            </ul>
        </li>

    </ul>

</div>
