<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.Sidebar" %>

<%--<style>
    body .wrapper .sidebar-menu {
    background: #222222;
    color: #1f1f1f;
}
    .wrapper .sidebar-menu {
    display: table-cell;
    vertical-align: top;
    background: #303641;
    width: 280px;
    position: relative;
    z-index: 100;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}
    body .wrapper .sidebar-menu {
    background: #222222;
    color: #1f1f1f;
}
    .wrapper .sidebar-menu .logo-env {
    width: 100%;
    padding: 35px;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}
    .wrapper .sidebar-menu .logo-env:before, .wrapper .sidebar-menu .logo-env:after {
    content: " ";
    display: table;
}
    .wrapper .sidebar-menu .logo-env > div {
    display: block;
    vertical-align: middle;
    white-space: nowrap;
    float: left;
}
    .wrapper .sidebar-menu .logo-env > div > a {
    display: inline-block;
    color: #aaabae;
}
    
    .wrapper .sidebar-menu .logo-env > div.sidebar-collapse, .wrapper .sidebar-menu .logo-env > div.sidebar-mobile-menu {
    position: relative;
    float: right;
}
    .wrapper .sidebar-menu .logo-env > div.sidebar-collapse a, .wrapper .sidebar-menu .logo-env > div.sidebar-mobile-menu a {
    display: inline-block;
    border: 1px solid #454a54;
    text-align: center;
    padding: 0;
    line-height: 1;
    font-size: 20px;
    font-weight: 300;
    padding: 5px 2px;
    -webkit-border-radius: 3px;
    -webkit-background-clip: padding-box;
    -moz-border-radius: 3px;
    -moz-background-clip: padding;
    border-radius: 3px;
    background-clip: padding-box;
    -webkit-transition: all 200ms ease-in-out;
    -moz-transition: all 200ms ease-in-out;
    -o-transition: all 200ms ease-in-out;
    transition: all 200ms ease-in-out;
}
    .entypo-menu {
    color: #EEE;
}
    .entypo-menu:before {
    content: '\e811';
}
    [class^="entypo-"]:before, [class*=" entypo-"]:before {
    font-family: "entypo";
    font-style: normal;
    font-weight: normal;
    speak: none;
    display: inline-block;
    text-decoration: inherit;
    width: 1em;
    margin-right: .2em;
    text-align: center;
    /* opacity: .8; */
    font-variant: normal;
    text-transform: none;
    line-height: 1em;
    margin-left: .2em;
    /* font-size: 120%; */
    /* text-shadow: 1px 1px 1px rgba(127, 127, 127, 0.3); */
}
    body .wrapper .sidebar-menu .logo-env > div.sidebar-collapse a, body .wrapper .sidebar-menu .logo-env > div.sidebar-mobile-menu a {
    border-color: #282828;
}
    .wrapper .sidebar-menu #main-menu {
    list-style: none;
    margin: 0;
    padding: 0;
    margin-bottom: 20px;
}
    body .wrapper .sidebar-menu #main-menu li {
    border-color: #282828;
}
    .wrapper .sidebar-menu #main-menu li {
    position: relative;
    margin: 0;
    font-size: 12px;
    border-bottom: 1px solid rgba(69, 74, 84, 0.7);
}
    body .wrapper .sidebar-menu #main-menu li a {
    color: #EEE;
}
    .wrapper .sidebar-menu #main-menu li a {
        position: relative;
        display: block;
        padding: 10px 20px;
        color: #aaabae;
        z-index: 2;
        -webkit-transition: color 250ms ease-in-out, background-color 250ms ease-in-out;
        -moz-transition: color 250ms ease-in-out, background-color 250ms ease-in-out;
        -o-transition: color 250ms ease-in-out, background-color 250ms ease-in-out;
        transition: color 250ms ease-in-out, background-color 250ms ease-in-out;
}   
    .wrapper .sidebar-menu #main-menu li ul {
    position: relative;
    list-style: none;
    padding: 0;
    margin: 0;
    border-top: 1px solid rgba(69, 74, 84, 0.4);
    display: none;
    overflow: hidden;
    z-index: 1;
}
    .wrapper .sidebar-menu #main-menu li i {
    position: relative;
    font-size: 15px;
    margin-right: 5px;
}
    .entypo-gauge:before {
    content: '\e8de';
}
    body .wrapper .sidebar-menu #main-menu li ul > li {
    border-color: #282828;
}
    .wrapper .sidebar-menu #main-menu li ul > li {
    border-bottom: 1px solid rgba(69, 74, 84, 0.4);
}
    body .wrapper .sidebar-menu #main-menu li ul > li > a {
    background-color: #1f1f1f;
}
    body .wrapper .sidebar-menu #main-menu li ul > li ul > li > a {
    background-color: #1b1b1b;
}
    .wrapper .sidebar-menu #main-menu li ul > li ul > li > a {
        padding-left: 60px;
        background: #262b34;
    }

</style>
<div class="sidebar-menu">
    <div class="sidebar-menu-inner">
        <header class="logo-env">
            <!-- logo -->
            <div class="logo"><a href="">
                <img src="" width="120" alt="">
            </a></div>
            <!-- logo collapse icon -->
            <div class="sidebar-collapse"><a href="#" class="sidebar-collapse-icon">
                <!-- add class "with-animation" if you want sidebar to have animation during expanding/collapsing transition -->
                <i class="entypo-menu"></i></a></div>
            <!-- open/close menu icon (do not remove if you want to enable menu on mobile devices) -->
            <div class="sidebar-mobile-menu visible-xs"><a href="#" class="with-animation">
                <!-- add class "with-animation" to support animation -->
                <i class="entypo-menu"></i></a></div>
        </header>
        <ul id="main-menu" class="main-menu" style="">
            <li class="has-sub root-level"><a href=""><i class="entypo-gauge"></i><span class="title">Dashboard</span></a>
                <ul>
                    <li><a href=""><span class="title">Dashboard 1</span></a> </li>
                    <li><a href=""><span class="title">Dashboard 2</span></a> </li>
                    <li><a href=""><span class="title">Dashboard 3</span></a> </li>
                </ul>
            </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-layout"></i><span class="title">Layouts</span></a>
                <ul>
                    <li><a href=""><span class="title">Layout API</span></a> </li>
                </ul>
            </li>
            <li class="root-level"><a href="" target="_blank"><i class="entypo-monitor"></i><span class="title">Frontend</span></a> </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-newspaper"></i><span class="title">UI Elements</span></a>
                <ul>
                    <li><a href=""><span class="title">Pagination</span></a> </li>
                </ul>
            </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-mail"></i><span class="title">Mailbox</span><span class="badge badge-secondary">8</span></a>
                <ul>
                    <li><a href=""><i class="entypo-inbox"></i><span class="title">Inbox</span></a> </li>
                    
                </ul>
            </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-doc-text"></i><span class="title">Forms</span></a>
                <ul>
                   
                    <li><a href=""><span class="title">Editors</span></a> </li>
                </ul>
            </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-window"></i><span class="title">Tables</span></a>
                <ul>
                    <li><a href=""><span class="title">Basic Tables</span></a> </li>
                    
                </ul>
            </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-bag"></i><span class="title">Extra</span><span class="badge badge-info badge-roundless">New Items</span></a>
                <ul>
                    <li class="has-sub"><a href=""><span class="title">Icons</span><span class="badge badge-success">3</span></a>
                        <ul>
                            <li><a href=""><span class="title">Font Awesome</span></a> </li>
                           
                        </ul>
                    </li>
                    <li><a href=""><span class="title">Portlets</span></a> </li>
                    <li class="has-sub"><a href=""><span class="title">Maps</span></a>
                        <ul>
                            
                            <li><a href=""><span class="title">Vector Maps</span></a> </li>
                        </ul>
                    </li>
                    
                    <li><a href=""><span class="title">Load Progress</span></a> </li>
                </ul>
            </li>
            <li class="root-level"><a href=""><i class="entypo-chart-bar"></i><span class="title">Charts</span></a> </li>
            <li class="has-sub root-level"><a href=""><i class="entypo-flow-tree"></i><span class="title">Menu Levels</span></a>
                <ul>
                    <li><a href=""><i class="entypo-flow-line"></i><span class="title">Menu Level 1.1</span></a> </li>
                    
                    <li class="has-sub"><a href=""><i class="entypo-flow-line"></i><span class="title">Menu Level 1.3</span></a>
                        <ul>
                            <li><a href=""><i class="entypo-flow-parallel"></i><span class="title">Menu Level 2.1</span></a> </li>
                            <li class="has-sub"><a href=""><i class="entypo-flow-parallel"></i><span class="title">Menu Level 2.2</span></a>
                                <ul>
                                    <li class="has-sub"><a href=""><i class="entypo-flow-cascade"></i><span class="title">Menu Level 3.1</span></a>
                                        <ul>
                                            <li><a href=""><i class="entypo-flow-branch"></i><span class="title">Menu Level 4.1</span></a> </li>
                                        </ul>
                                    </li>
                                    <li><a href=""><i class="entypo-flow-cascade"></i><span class="title">Menu Level 3.2</span></a> </li>
                                </ul>
                            </li>
                            <li><a href=""><i class="entypo-flow-parallel"></i><span class="title">Menu Level 2.3</span></a> </li>
                        </ul>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</div>--%>
