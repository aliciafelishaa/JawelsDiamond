<%@ Page Title="Transaction Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="JawelsDiamond.Views.TransactionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .details-container {
            max-width: 800px;
            margin: 40px auto;
            padding: 30px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
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

        .title {
            text-align: center;
            margin-top: 30px;
            font-size: 28px;
            color: #333;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="title">Transaction Details</h2>
    <div class="details-container">
        <div class="detail">
            <h3>Transaction ID: </h3>
            <asp:Label ID="lblTransactionID" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="detail">
            <h3>Jewel Name: </h3>
            <asp:Label ID="lblJewelName" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="detail">
            <h3>Quantity: </h3>
            <asp:Label ID="lblQuantity" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="button-container">
            <asp:Button ID="btnBack" runat="server" Text="Back to My Orders" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
