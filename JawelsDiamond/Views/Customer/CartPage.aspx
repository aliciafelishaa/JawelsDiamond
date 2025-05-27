<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="JawelsDiamond.Views.Customer.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .header-cart{
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 24px;
            font-weight: 700;
        }

        .content-style{
            display: flex;
            align-items: center;
            justify-content: center;
        }

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
            width: fit-content;
        }

        .gridview-style th {
            background-color: #fff700;
            color: black;
        }

        .gridview-style tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridview-style tr:hover {
            background-color: #eef;
        }

        .header-jwls{
            display: flex;
            align-items: center;
            justify-content: center
        }
        .two-columns {
            display: flex;
            justify-content: center;
            align-items: flex-start;
            flex-wrap: wrap;
            gap: 40px;
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }

        .cart-items {
            flex: 0 0 70%;
            min-width: 500px;
        }

        .checkout-panel {
            flex: 0 0 25%;
            min-width: 300px;
        }

        .checkout-box {
            border: 1px solid #ddd;
            padding: 20px;
            border-radius: 12px;
            background-color: #f5f5f5;
            font-family: Arial, sans-serif;
        }

        .checkout-box label,
        .checkout-box select,
        .checkout-box button {
            width: 100%;
            margin-bottom: 12px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="HeaderCart" runat="server" CssClass="header-cart" Text=""></asp:Label>
    <div class="content-style two-columns">
        <!-- Left side: Cart items -->
    <div class="cart-items">
        <asp:GridView ID="CartGrid" DataKeyNames="JewelID" runat="server" AutoGenerateColumns="false" CssClass="gridview-style" OnRowDeleting="CartGrid_RowDeleting" OnRowEditing="CartGrid_RowEditing">
            <Columns>
                <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
                <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" UseSubmitBehavior="false" runat="server" CommandName="Edit"
                           Text="Update" CssClass="btn btn-sm btn-warning" />
                        <asp:Button ID="btnDelete" UseSubmitBehavior="false" runat="server"  CommandName="Delete"
                            Text="Delete" CssClass="btn btn-sm btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <!-- Right side: Checkout section -->
    <div class="checkout-panel">
        <div class="checkout-box">
            <asp:Label ID="Lbl_TotalPrice" runat="server" Text="Total Price: " CssClass="fw-bold"></asp:Label>
            <asp:Label ID="Lbl_TotalPriceValue" runat="server" Text="$0.00" CssClass="fw-bold"></asp:Label>

            <br /><br />

            <asp:Label ID="Lbl_PaymentMethod" runat="server" Text="Payment Method:" AssociatedControlID="PaymentDropdown"></asp:Label><br />
            <asp:DropDownList ID="PaymentDropdown" runat="server" CssClass="form-control">
                <asp:ListItem Text="-- Select Payment Method --" Value="" />
                <asp:ListItem Text="Credit Card" Value="credit" />
                <asp:ListItem Text="PayPal" Value="paypal" />
                <asp:ListItem Text="Bank Transfer" Value="bank" />
            </asp:DropDownList>

            <br />

            <asp:Button ID="Btn_ClearCart" runat="server" Text="Clear Cart" CssClass="btn btn-outline-danger w-100" OnClick="Btn_ClearCart_Click"/>
            <br /><br />
            <asp:Button ID="Btn_Checkout" runat="server" Text="Checkout" CssClass="btn btn-success w-100" />
        </div>
    </div>
    </div>
</asp:Content>
