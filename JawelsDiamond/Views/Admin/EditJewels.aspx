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
    <h2>Edit Jewels</h2>
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
         <asp:Button ID="Button2" runat="server" Text="Save Changes" OnClick="Edit_Click"/>
         <asp:Button ID="Button3" runat="server" Text="Cancel" OnClick="CancelBtn_Click"/>
         </div>

         <%--Error Message--%>
         <asp:Label ID="errorMsg" runat="server" Text="Input the form" ForeColor="Red"></asp:Label>
 </div>
</asp:Content>
