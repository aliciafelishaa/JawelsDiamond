<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="JawelsDiamond.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-SgOJa3DmI69IUzQ2PVdRZhwQ+dy64/BUtbMJw1MZ8t5HZApcHrRKUc4W0kG879m7" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/js/bootstrap.bundle.min.js" integrity="sha384-k6d4wzSIapyDyv1kpU366/PK5hCdSbCRGRCMv+eplOQJWyd1fbcAu9OCUj5zNLiq" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
