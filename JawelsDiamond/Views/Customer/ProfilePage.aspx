<%@ Page Title="Profile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="JawelsDiamond.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .profile-container {
            max-width: 800px;
            margin: 40px auto;
            padding: 30px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        .profile-container .detail {
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

        .form-container {
            margin-top: 30px;
        }

        .form-container input {
            width: 100%;
            padding: 10px;
            margin: 5px 0;
            font-size: 16px;
        }

        .title{
            text-align: center;
            margin-top: 30px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="title">Profile Information</h2>
    <div class="profile-container">
        <div class="detail">
            <h3>Name: </h3>
            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="detail">
            <h3>Email: </h3>
            <asp:Label ID="lblUserEmail" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="form-container">
            <h3>Change Password</h3>

            <div>
                <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div class="button-container">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            </div>

            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
