<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="source_file.aspx.cs" Inherits="FineUI.Examples.source_file" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../res/google-code-prettify/prettify.css" rel="stylesheet" />
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-size: 13px;
            background-color: White;
        }

        pre.prettyprint {
            border: none;
            margin: 0;
            padding: 10px 5px;
            color: #666;
        }

        li.L0, li.L1, li.L2, li.L3, li.L4,
        li.L5, li.L6, li.L7, li.L8, li.L9 {
            list-style-type: decimal !important;
            background-color: #fff;
        }
    </style>
</head>
<body onload="prettyPrint();">
    <form id="form1" runat="server">
        <asp:Literal runat="server" ID="desc"></asp:Literal>
    </form>
    <script src="../res/google-code-prettify/prettify.js"></script>
    <script src="../res/google-code-prettify/lang-basic.js"></script>
</body>
</html>
