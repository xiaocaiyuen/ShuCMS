<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shu.Manage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理系统登录</title>
    <script src="js/jquery.js"></script>
    <style type="text/css">
        body
        {
            background: url(images/box_bg.jpg) repeat;
            margin: 0;
            padding: 0;
        }
        .login_top
        {
            margin: 0 auto;
            padding: 0px;
            text-align: center;
            margin-top: 10%;
        }
        .login_box
        {
            margin: 0 auto;
            background: url(images/logo_bg.jpg) no-repeat center top;
            height: 240px;
            margin-top: 20px;
            text-align: center;
        }
        .input_box
        {
            margin: 0 auto;
            width: 562px;
            height: 245px;
            padding-top: 22px;
        }
        .login_input_box
        {
            float: left;
            width: 200px;
            margin-top: 42px;
            margin-left: 110px;
            display: inline;
        }
        .login_input
        {
            width: 153px;
            height: 24px;
            line-height: 24px;
            font-size: 18px;
            background-color: transparent;
            border: 0px;
        }
        .login_name
        {
            float: left;
        }
        .login_pwd
        {
            float: left;
            margin-top: 20px;
            display: inline;
        }
        .login_button
        {
            float: left;
            margin-top: 20px;
        }
        .login_bottom
        {
            margin-top: 0px;
            height: 22px;
            padding-top: 25px;
            background: url(images/bottom_line.png) no-repeat center top;
            text-align: center;
            font-size: 12px;
            font-family: 微软雅黑;
            color: #797979;
        }
    </style>
    <script type="text/javascript">
        /*判断是否在iframe中*/
        if (self != top) {
            top.location = "Login.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <div class="login_top">
        <img src="images/logo.png" alt="如意宝技术有限公司" height="70" /></div>
    <div class="login_box">
        <div class="input_box">
            <div style="float: left; width: 470px; margin-left: 35px; text-align: left; display: inline;">
                <img src="images/beta_v1.0.jpg" alt="管理系统" /></div>
            <div class="login_input_box">
                <div class="login_name">
                    <asp:TextBox ID="tbxUserName" CssClass="login_input" runat="server" MaxLength="50"></asp:TextBox></div>
                <div class="login_pwd">
                    <asp:TextBox ID="tbxPassword" CssClass="login_input" runat="server" MaxLength="50"
                        TextMode="Password"></asp:TextBox></div>
                <div class="login_button">
                    <asp:ImageButton ID="ImageButton1" OnClick="btnSubmit_Click" ImageUrl="images/login_but.jpg"
                        runat="server" /></div>
            </div>
        </div>
    </div>
    <div class="login_bottom">
        @2016 如意宝技术有限公司 www.ahlongshu.cn 版权所有
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    document.getElementById("<%=tbxUserName.ClientID %>").focus();
</script>