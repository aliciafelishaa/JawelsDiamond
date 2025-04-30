<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="JawelsDiamond.Views.RegisterPage" %>

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
                <h1 class="fw-bold text-center">Register Page</h1>
                <div class="d-grid gap-1">
                    <div>
                        <asp:Label ID="Lbl_Email" runat="server" Text="Email" class="form-label"></asp:Label>
                        <asp:TextBox ID="TB_Email" runat="server" class="form-control" placeholder="Input your email here"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Lbl_Username" runat="server" Text="Username" class="form-label"></asp:Label>
                        <asp:TextBox ID="TB_Username" runat="server" class="form-control" placeholder="Input your username here"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Lbl_Password" runat="server" Text="Password" class="form-label"></asp:Label>
                        <asp:TextBox ID="TB_Password" runat="server" class="form-control" placeholder="Input your password here" TextMode="Password"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Lbl_ConfirmPass" runat="server" Text="Confirm Password" class="form-label"></asp:Label>
                        <asp:TextBox ID="TB_ConfirmPass" runat="server" class="form-control" placeholder="Input password confirmation here" TextMode="Password"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Lbl_Gender" runat="server" Text="Gender" class="form-label d-block"></asp:Label>
                        <asp:RadioButtonList ID="RBL_Gender" runat="server"
                            CssClass="bootstrap-radio">
                            <asp:ListItem Text="Male" Value="Male" />
                            <asp:ListItem Text="Female" Value="Female" />
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth" class="form-label"></asp:Label>
                        <asp:TextBox ID="TB_DOB" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Btn_Register" runat="server" Text="Register" class="btn btn-primary px-4 py-2 rounded-pill fw-semibold" OnClick="Btn_Register_Click" />
                    <div class="text-center">
                        <asp:LinkButton ID="Link_Btn_ToLogin" runat="server" OnClick="Link_Btn_ToLogin_Click" CssClass="link-primary text-decoration-none">Already have an account? Login here</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
