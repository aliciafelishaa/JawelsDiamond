<%@ Page Title="Reports" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="JawelsDiamond.Views.Admin.Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" 
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row mb-4">
            <div class="col">
                <h1 class="text-center display-5">Crystal Reports</h1>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="card shadow-sm rounded-4">
                    <div class="card-body">
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
                            CssClass="w-100" Height="800px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
