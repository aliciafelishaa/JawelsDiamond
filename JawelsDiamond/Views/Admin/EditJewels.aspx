<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditJewels.aspx.cs" Inherits="JawelsDiamond.Views.Admin.EditJewels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            width: 50%;
            margin: 20px auto;
            padding: 20px;
            background-color: #f7f7f7;
            border-radius: 8px;
        }
        .form-container label {
            display: block;
            margin-bottom: 8px;
        }
        .form-container input, .form-container select {
            width: 100%;
            padding: 8px;
            margin-bottom: 12px;
            border-radius: 4px;
            border: 1px solid #ccc;
        }
        .form-container button {
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .form-container button:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2>Edit Jewel</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <asp:HiddenField ID="hfJewelID" runat="server" />
        <asp:Label ID="lblJewelName" runat="server" Text="Jewel Name"></asp:Label>
        <asp:TextBox ID="txtJewelName" runat="server"></asp:TextBox>

        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>

        <asp:Label ID="lblBrand" runat="server" Text="Brand"></asp:Label>
        <asp:DropDownList ID="ddlBrand" runat="server"></asp:DropDownList>

        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>

        <asp:Label ID="lblReleaseYear" runat="server" Text="Release Year"></asp:Label>
        <asp:TextBox ID="txtReleaseYear" runat="server" TextMode="Number"></asp:TextBox>

        <asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
