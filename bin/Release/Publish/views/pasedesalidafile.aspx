<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pasedesalidafile.aspx.cs" Inherits="Softjc.views.pasedesalidafile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <hr />
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
        <CR:CrystalReportViewer ID="CRV1PS" runat="server" PrintMode="ActiveX"  Height="50px" ReportSourceID="CRV1PSC" ToolPanelWidth="200px" Width="350px" ToolPanelView="ParameterPanel" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" HasRefreshButton="True"  />
        <CR:CrystalReportSource ID="CRV1PSC" runat="server">
            <Report FileName="CRV1PST.rpt">
            </Report>
        </CR:CrystalReportSource>
        </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </asp:Content>
