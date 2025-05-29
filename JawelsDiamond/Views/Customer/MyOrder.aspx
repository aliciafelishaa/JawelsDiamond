<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyOrder.aspx.cs" Inherits="JawelsDiamond.Views.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview-style {
            width: 90%;
            margin: 30px auto;
            border-collapse: collapse;
            font-family: Arial, sans-serif;
        }

        .gridview-style th, .gridview-style td {
            border: 1px solid #ccc;
            padding: 10px;
            text-align: center;
        }

        .gridview-style th {
            background-color: #007bff;
            color: white;
        }

        .gridview-style tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridview-style tr:hover {
            background-color: #eef;
        }

        .title{
            text-align: center;
            margin-top: 30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="title">My Orders</h2>
    <asp:GridView ID="OrderGrid" runat="server" AutoGenerateColumns="false" CssClass="gridview-style">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" SortExpression="PaymentMethod"></asp:BoundField>
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" SortExpression="TransactionStatus"></asp:BoundField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="ViewDetailsBtn" runat="server" Text="View Details" OnClick="ViewDetails_Click" CommandArgument='<%# Eval("TransactionID") %>' />
                    
                    <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm Package" OnClick="ConfirmPackage_Click" CommandArgument='<%# Eval("TransactionID") %>' 
                        Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" ? true : false %>' />
                    <asp:Button ID="RejectBtn" runat="server" Text="Reject Package" OnClick="RejectPackage_Click" CommandArgument='<%# Eval("TransactionID") %>' 
                        Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" ? true : false %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
