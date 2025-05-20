<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateJewelQuantityPage.aspx.cs" Inherits="JawelsDiamond.Views.Customer.UpdateJewelQuantityPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 30px;
            background-color: #fff;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
            border-radius: 12px;
            font-family: 'Segoe UI', sans-serif;
        }

        h2 {
            text-align: center;
            color: #2c3e50;
            margin-bottom: 30px;
        }

        .detail-group {
            display: flex;
            justify-content: space-between;
            padding: 10px 0;
            border-bottom: 1px solid #eee;
            font-size: 16px;
        }

        .detail-group h4 {
            margin: 0;
            font-weight: 600;
            color: #333;
        }

        .detail-group span {
            color: #555;
        }

        .update-quantity-container {
            margin-top: 40px;
            padding-top: 20px;
            border-top: 2px solid #ccc;
            text-align: center;
        }

        .update-quantity-container label {
            font-size: 16px;
            margin-right: 10px;
            font-weight: 500;
        }

        .quantity-input {
            padding: 10px;
            width: 80px;
            font-size: 16px;
            text-align: center;
            border: 1px solid #ccc;
            border-radius: 8px;
            margin-right: 10px;
        }

        .btn-update {
            padding: 10px 20px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 8px;
            font-size: 16px;
            cursor: pointer;
            transition: background 0.2s ease;
        }

        .btn-update:hover {
            background-color: #218838;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Jewel Details</h2>

        <div class="detail-group">
            <h4>Jewel Name:</h4>
            <span><asp:Label ID="lblJewelName" runat="server" Text="Label"></asp:Label></span>
        </div>
        <div class="detail-group">
            <h4>Category:</h4>
            <span><asp:Label ID="lblJewelCategory" runat="server" Text="Label"></asp:Label></span>
        </div>
        <div class="detail-group">
            <h4>Brand:</h4>
            <span><asp:Label ID="lblJewelBrand" runat="server" Text="Label"></asp:Label></span>
        </div>
        <div class="detail-group">
            <h4>Brand Country Origin:</h4>
            <span><asp:Label ID="lblCountryOrigin" runat="server" Text="Label"></asp:Label></span>
        </div>
        <div class="detail-group">
            <h4>Brand Class:</h4>
            <span><asp:Label ID="lblClass" runat="server" Text="Label"></asp:Label></span>
        </div>
        <div class="detail-group">
            <h4>Price:</h4>
            <span><asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label></span>
        </div>
        <div class="detail-group">
            <h4>Release Year:</h4>
            <span><asp:Label ID="lblReleaseYear" runat="server" Text="Label"></asp:Label></span>
        </div>

        <div class="update-quantity-container">
            <asp:Label ID="lblQuantity" runat="server" Text="Enter Quantity: " />
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity-input" />
            <asp:Button ID="btnUpdateQuantity" runat="server" Text="Update Quantity" OnClick="btnUpdateQuantity_Click" CssClass="btn-update" />
        </div>
    </div>
</asp:Content>
