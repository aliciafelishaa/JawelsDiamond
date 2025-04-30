<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="JewelDetail.aspx.cs" Inherits="JawelsDiamond.Views.JewelDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Styling for jewel details */
        .details-container {
            max-width: 800px;
            margin: 40px auto;
            padding: 30px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        .details-container h2 {
            text-align: center;
            color: #333;
        }

        .details-container .detail {
            margin-bottom: 20px;
            font-size: 18px;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        .button-container button {
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .button-container button:hover {
            background-color: #0056b3;
        }
        .header-jwls{
    display: flex;
    align-items: center;
    justify-content: center
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="header-jwls">Jewel Details</h2>
    <div class="details-container">
        <%--Jewel Name--%>
        <div class="detail">
            <h3>Jewel Name: </h3>
            <asp:Label ID="lblJewelName" runat="server" Text="Label"></asp:Label>
        </div>
        <%--Jewel Category Name--%>
        <div class="detail">
            <h3>Category: </h3>
            <asp:Label ID="lblJewelCategory" runat="server" Text="Label"></asp:Label>
        </div>
        <%--Jewel Brand Name--%>
        <div class="detail">
            <h3>Brand: </h3>
            <asp:Label ID="lblJewelBrand" runat="server" Text="Label"></asp:Label>
        </div>
        <%--Jewel Country Origin from Brand--%>
        <div class="detail">
            <h3>Brand Country Origin: </h3>
            <asp:Label ID="lblCountryOrigin" runat="server" Text="Label"></asp:Label>
        </div>
        <%--Jewel Class--%>
        <div class="detail">
            <h3>Brand Class: </h3>
            <asp:Label ID="lblClass" runat="server" Text="Label"></asp:Label>
        </div>
        <%--Jewel Price--%>
        <div class="detail">
            <h3>Price: </h3>
            <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>
        </div>
        <%--Jewel Release Year--%>
        <div class="detail">
            <h3>Release Year: </h3>
            <asp:Label ID="lblReleaseYear" runat="server" Text="Label"></asp:Label>
        </div>

        <%--Add cart for Customer--%>
        <asp:Panel ID="addToCartBtn" runat="server" CssClass="button-container" Style="display:none;">
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
        </asp:Panel>

        <%-- Edit and Delete buttons for Admins --%>
        <asp:Panel ID="adminButtons" runat="server" CssClass="button-container" Style="display:none;">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelet" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </asp:Panel>
    </div>
</asp:Content>
