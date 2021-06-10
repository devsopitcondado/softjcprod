<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pasedesalida.aspx.cs" Inherits="Softjc.views.pasedesalida" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Pase de Salida</h1>
    <hr />
    <h2 class="sub-header">Equipo</h2>
    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <asp:Image ID="Image1" runat="server" Height="105px" ImageAlign="Middle" ImageUrl="~/Imagenes/NUEVO_LOGO_ICASA.png" Width="189px" BorderStyle="Double" />
        </div>
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="nusuario" class="label label-default" runat="server" Text="Nombre de usuario:"></asp:Label></h4>
            <asp:TextBox ID="user" class="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-xs-6 col-md-4">
            <h4>
                <asp:Label ID="dat" class="label label-default" runat="server" Text="Fecha:"></asp:Label></h4>
            <asp:TextBox ID="date" class="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <h2 class="sub-header">Ingrese los datos</h2>

    <div class="row">

        <div class="col-xs-6 col-sm-4">

            <h4>
                <asp:Label ID="descripcion" class="label label-default" runat="server" Text="Descripcion"></asp:Label></h4>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-8">
            <asp:TextBox ID="tdescripcion" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="receptor" class="label label-default" runat="server" Text="Por este medio
                autorizo al señor:"></asp:Label></h4>
        </div>
        <div class="col-xs-6 col-sm-4">

            <h4>
                <asp:Label ID="dpi" class="label label-default" runat="server" Text="DPI:"></asp:Label></h4>

        </div>
    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <asp:TextBox ID="treceptor" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-6 col-sm-4">
            <asp:TextBox ID="tdpi" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="num_ticket" class="label label-default" runat="server" Text="Ticket:"></asp:Label></h4>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <asp:TextBox ID="tticket" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-6 col-sm-4">
            <asp:Button ID="find" class="btn btn-default btn-lg" runat="server" OnClick="find_Click" Text="Buscar" />
        </div>
    </div>

    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-8">
            <asp:GridView ID="GridDetailSalida" class="table table-striped" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-8">

            <asp:Button ID="finalizar" class="btn btn-default btn-lg" runat="server" Text="Generar" OnClick="finalizar_Click" />

           </div>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    <hr />
    <hr />
    <hr />
       <div class="row">
          <div class="col-xs-6 col-sm-8">
             <div>
     
        </div>
          </div>
       </div>
</asp:Content>