  <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPages.aspx.cs" Inherits="JawelsDiamond.Views.LoginPages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="p-5 rounded-4 shadow card" style="max-width: 450px; width: 100%;">
            <h1 class="fw-bold text-center">Login Page</h1>
            <div class="d-grid gap-1">
                <div>
                    <asp:Label ID="Lbl_Email" runat="server" Text="Email" class="form-label"></asp:Label>
                    <asp:TextBox ID="TB_Email" runat="server" placeholder="Input your email here" class="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Lbl_Password" runat="server" Text="Password" class="form-label"></asp:Label>
                    <asp:TextBox ID="TB_Password" runat="server" placeholder="Input your password here" class="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:CheckBox ID="CBox_RememberMe" runat="server" class="form-check-input" />
                    <asp:Label ID="Lbl_RememberMe" runat="server" Text="Remember Me" class="form-check-label ms-2"></asp:Label>
                </div>
                <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
                <asp:Button ID="Btn_Login" runat="server" Text="Login" class="btn btn-primary px-4 py-2 rounded-pill fw-semibold" OnClick="Btn_Login_Click" />
                <asp:LinkButton ID="Link_Btn_ToRegister" runat="server" OnClick="Link_Btn_ToRegister_Click" CssClass="link-primary text-decoration-none">Don't have an account? Register here</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
