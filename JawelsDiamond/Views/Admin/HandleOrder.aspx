<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HandleOrder.aspx.cs" Inherits="JawelsDiamond.Views.Admin.HandleOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Optional: Link Bootstrap CSS here if not already included in MasterPage -->
    <%-- <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" /> --%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Handle Orders</h1>

        <asp:GridView ID="GV_Transaction" runat="server" AutoGenerateColumns="False"
            CssClass="table table-striped table-bordered table-hover"
            OnRowDataBound="GV_Transaction_RowDataBound"
            OnRowCommand="GV_Transaction_RowCommand"
            DataKeyNames="TransactionId">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" SortExpression="TransactionId" />
                <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" SortExpression="TransactionStatus" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <div class="d-flex gap-2">
                            <asp:Label ID="Lbl_Arrived" runat="server" CssClass="text-muted" Text="Waiting for user confirmation..." Visible="false" />
                            <asp:Button ID="Btn_Confirm" runat="server" Text="Confirm Payment"
                                CssClass="btn btn-sm btn-primary" UseSubmitBehavior="false"
                                CommandName="Confirm" CommandArgument="<%# Container.DataItemIndex %>" />
                            <asp:Button ID="Btn_Ship" runat="server" Text="Ship Package"
                                CssClass="btn btn-sm btn-success" UseSubmitBehavior="false"
                                CommandName="Ship" CommandArgument="<%# Container.DataItemIndex %>" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
