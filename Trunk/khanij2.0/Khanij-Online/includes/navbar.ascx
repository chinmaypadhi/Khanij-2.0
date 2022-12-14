<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navbar.ascx.cs" Inherits="includes_navbar" %>
<link rel="stylesheet" href="../css/khanij-icon.css" /> 
<div class="page-topbar ">
    <div class="logo-area">
        <img src="../img/govt-logo.png" alt="Chhattishgarh Govt" class="main-logo">
        <img src="../img/govt-logo.png" alt="Chhattishgarh Govt" class="mobile-screen-logo">
        <h1>Mineral Resources Department
            <small>Govt. of Chhattisgarh</small>
        </h1>
    </div>
    
    <div class="quick-area">
        <div class="float-left">
                        <ul class="info-menu list-inline list-unstyled">
                <li class="sidebar-toggle-wrap list-inline-item">
                    <a href="#" data-toggle="sidebar" class="sidebar_toggle">
                        <i class="fa fa-bars"></i>
                    </a>
                </li>
            </ul>
            </div>
            
        <div class="float-right align-items-center justify-content-end ml-auto  d-lg-flex">
            
                <div class="khanij-online align-items-center justify-content-end ml-auto d-lg-block d-none d-lg-flex ">
           
            <img src="../img/khanij-online.jpg" alt="Khanij Online" class="mr-2" />
         <span class="text-white font-weight-bold">A Web based mines & minerals<br /> management system</span> 
               
      </div>

            <ul class="info-menu right-links list-inline list-unstyled">
                <li class="profile list-inline-item showopacity ">
                    <a href="#" data-toggle="dropdown" class="toggle ">
                        <img src="../img/profile.jpg" alt="user-image" class="rounded-circle img-inline">
                        <span>Administrator <i class="fa fa-angle-down"></i></span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-right profile animated fadeIn">
                        <li class="dropdown-item">
                            <a href="#" title="Profile">
                                <i class="fas fa-user"></i>
                                Profile
                            </a>
                        </li>
                        <li class="last dropdown-item">
                            <a href="../Dashboard/change-password.aspx" title="Change Password">
                                <i class="fas fa-key"></i>
                                Change Password
                            </a>
                        </li>

                    </ul>
                </li>
                <li class="message-toggle-wrapper list-inline-item showopacity">
                    <a href="#" data-toggle="dropdown" class="toggle d-lg-block d-none">
                        <i class="fa fa-bell"></i>
                        <span class="badge badge-pill badge-accent">3</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-right messages animated fadeIn">
                        <li class="external text-center">
                            <a href="javascript:;">
                               <i class="fas fa-times fa-2x"></i>
                            </a>
                        </li>
                        <li class="list dropdown-item">

                            <ul class="dropdown-menu-list list-unstyled custom-scroll ">
                                <li class="unread">
                                    <a href="javascript:;">
                                       <span class="time small">8th Dec</span>
                                            <span class="desc small">
                                                Sometimes it takes a lifetime to win a battle.
                                            </span>
                                    </a>
                                </li>

                                <li class="unread">
                                    <a href="javascript:;">
                                        <span class="time small">8th Dec</span>
                                            <span class="desc small">
                                                Sometimes it takes a lifetime to win a battle.
                                            </span>
                                    </a>
                                </li>
                                <li class="unread">
                                    <a href="javascript:;">
                                            <span class="time small">7th Dec</span>
                                            <span class="desc small">
                                                Sometimes it takes a lifetime to win a battle.
                                            </span>
                                    </a>
                                </li>
                                <li >
                                    <a href="javascript:;">
                                           <span class="time small">16th Nov</span>
                                            <span class="desc small">
                                                Sometimes it takes a lifetime to win a battle.
                                            </span>
                                    </a>
                                </li>
                                <li >
                                    <a href="javascript:;">
                                             <span class="time small">16th Nov</span>
                                            <span class="desc small">
                                                Sometimes it takes a lifetime to win a battle.
                                            </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:;">
                                             <span class="time small">15th Nov</span>
                                            <span class="desc small">
                                                Sometimes it takes a lifetime to win a battle.
                                            </span>
                                    </a>
                                </li>
                            </ul>

                        </li>
                    </ul>

                </li>
                
                
                <li class="chat-toggle-wrapper list-inline-item">
                    <a href="#" class="setting-show">
                        <i class="fas fa-cog"></i>
                    </a>
                </li>
                <li class="logout-lnk list-inline-item">
                    <a href="../Default.aspx" class="toggle">
                        <i class="fas fa-power-off"></i>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</div>

<div class="theme">
    <div class="media">
        <a href="javascript:void(0);" onClick="chooseStyle('change', 60);" title="Light Theme"
            class="demo-theme-light original-box"></a>
        <a href="javascript:void(0);" onClick="chooseStyle('none', 60);" title="Dark Theme"
            class="demo-theme-dark black-box"></a>
    </div>
</div>
<div class="page-setting hideit">
    <div class="text-right">
        <a href="javascript:void(0);" class="setting-close"><i class="fas fa-times"></i></a>
    </div>


    <div class="chat-wrapper py-3 pl-3 pr-4">
        <div class="px-3">
            <div class="row mb-2">
                <div class="col-3 mb-2 px-1">
                    <div class="setting-color bg-brown theme-default" 
                        onClick="chooseStyle('none', 60);">
                        <span class="fas fa-check"></span>
                    </div>
                </div>
                <div class="col-3 mb-2 px-1">
                    <div class="setting-color bg-info theme-info"  
                        onClick="chooseStyle('infotheme', 60);">
                        <span class="fas fa-check"></span>
                    </div>
                </div>
               <div class="col-3 mb-2 px-1">
                    <div class="setting-color bg-success theme-green"  
                        onClick="chooseStyle('greentheme', 60);">
                        <span class="fas fa-check"></span>
                    </div>
                </div>
                <%-- <div class="col-3 mb-2 px-1">
                    <div class="setting-color bg-warning theme-orange"  
                        onClick="chooseStyle('orangetheme', 60);">
                        <span class="fas fa-check"></span>
                    </div>
                </div>--%>
                <div class="col-3 mb-2 px-1">
                    <div class="setting-color bg-secondary theme-purple"  
                        onClick="chooseStyle('purpletheme', 60);">
                        <span class="fas fa-check"></span>
                    </div>
                </div>
                <%--<div class="col-3 mb-2 px-1">
                    <div class="setting-color bg-danger theme-red"  
                        onClick="chooseStyle('redtheme', 60);">
                        <span class="fas fa-check"></span>
                    </div>
                </div>--%>
            </div> 
        </div>
    </div>

</div>