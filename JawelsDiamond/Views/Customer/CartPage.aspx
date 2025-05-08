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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="HeaderCart" runat="server" CssClass="header-cart" Text=""></asp:Label>
    <div class="content-style">
        <asp:GridView ID="CartGrid" runat="server" AutoGenerateColumns="false" CssClass="gridview-style">
        <Columns>
           <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="BrandName" HeaderText="Brand" />
        
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subtotal">
                <ItemTemplate>
                    <%# Eval("Subtotal", "{0:C}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="UpdateQty"
                        CommandArgument='<%# Eval("JewelID") %>' Text="Update" CssClass="btn btn-sm btn-warning" />
                    <asp:Button ID="btnDelete" runat="server" CommandName="DeleteItem"
                        CommandArgument='<%# Eval("JewelID") %>' Text="Delete" CssClass="btn btn-sm btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>

        <div>
            <asp:Label ID="Lbl_TotalPrice" runat="server" Text="Total Price: " CssClass="fw-bold"></asp:Label>
            <asp:Label ID="Lbl_TotalPriceValue" runat="server" Text="$0.00"></asp:Label>
        </div>
    </div>

</asp:Content>
