<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewJewels.aspx.cs" Inherits="JawelsDiamond.Views.ViewJewels" %>
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

    .header-jwls{
        display: flex;
        align-items: center;
        justify-content: center
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="header-jwls">View Jewels</h2>
    <asp:GridView ID="JewelGrid" runat="server" AutoGenerateColumns="false" CssClass="gridview-style">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" SortExpression="JewelID"></asp:BoundField>
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName"></asp:BoundField>
           <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" DataFormatString="{0:C}" HtmlEncode="false" SortExpression="JewelPrice" />
            
            <asp:HyperLinkField DataNavigateUrlFields="JewelID" DataNavigateUrlFormatString="JewelDetail.aspx?id={0}" Text="See Details" HeaderText="Actions"></asp:HyperLinkField>
        </Columns>
    </asp:GridView>

</asp:Content>
