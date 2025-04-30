<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddJewels.aspx.cs" Inherits="JawelsDiamond.Views.AddJewels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    body {
        font-family: Arial, sans-serif;
    }

    h1 {
        text-align: center;
        margin-bottom: 30px;
        color: #333;
    }

    .form-container {
        max-width: 600px;
        margin: auto;
        padding: 30px;
        background-color: #f9f9f9;
        box-shadow: 0 0 10px rgba(0,0,0,0.1);
        border-radius: 8px;
    }

    .form-container div {
        margin-bottom: 15px;
    }

    label {
        display: block;
        font-weight: bold;
        margin-bottom: 5px;
        color: #555;
    }

    input[type="text"],
    select,
    .aspNetTextBox,
    .aspNetDropDownList {
        width: 100%;
        padding: 8px 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    .form-container .button-container {
        display: flex;
        justify-content: space-between;
    }

    .form-container input[type="submit"],
    .form-container input[type="button"],
    .form-container button,
    .form-container .aspNetButton {
        padding: 10px 20px;
        border: none;
        background-color: #007bff;
        color: white;
        border-radius: 4px;
        cursor: pointer;
    }

    .form-container .aspNetButton:hover {
        background-color: #0056b3;
    }

    #errorMsg {
        margin-top: 20px;
        text-align: center;
        font-size: 14px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add Jewels</h1>
    <div class="form-container">
        
            <%--Jewel Name--%>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Jewel Name"></asp:Label>
                <asp:TextBox ID="JewelName" runat="server"></asp:TextBox>
            </div>
            <%--Category--%>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                <asp:DropDownList ID="JewelCategory" runat="server"></asp:DropDownList>
            </div>
            <%--Brand--%>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Brand"></asp:Label>
                <asp:DropDownList ID="JewelBrand" runat="server"></asp:DropDownList>
            </div>
            <%--Price--%>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
                <asp:TextBox ID="JewelPrice" runat="server"></asp:TextBox>
            </div>
            <%--Release Year--%>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Release Year"></asp:Label>
                 <asp:TextBox ID="JewelReleaseYear" runat="server"></asp:TextBox>
            </div>
            
            <%-- Submit --%>
            <div>
            <asp:Button ID="Button2" runat="server" Text="Add Jewels" OnClick="Add_Btn"/>
            <asp:Button ID="Button3" runat="server" Text="Cancel" OnClick="Cancel_Btn"/>
            </div>

            <%--Error Message--%>
            <asp:Label ID="errorMsg" runat="server" Text="Input the form" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
