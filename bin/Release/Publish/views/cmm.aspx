<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cmm.aspx.cs" Inherits="Softjc.views.CMM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <h4>
                        <asp:Label ID="dat" class="label label-default" runat="server" Text="Fecha:"></asp:Label></h4>
                    <asp:TextBox ID="date" class="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-xs-6 col-sm-4">
                <h4>
                    <asp:Label ID="lcategoria" class="label label-default" runat="server" Text="Categoria"></asp:Label></h4>
            </div>
            <div class="col-xs-6 col-sm-4">
                <h4>
                    <asp:Label ID="lmarcar" class="label label-default" runat="server" Text="Marca"></asp:Label></h4>
            </div>
            <div class="col-xs-6 col-sm-4">
                <h4>
                    <asp:Label ID="lmodelo" class="label label-default" runat="server" Text="Modelo"></asp:Label></h4>
            </div>
        </div>
        <hr />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-xs-6 col-sm-4">
                        <asp:TextBox ID="tcategoria" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <asp:TextBox ID="tmarca" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <asp:TextBox ID="tmodelo" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-6 col-sm-4">
                        <asp:Button ID="bsavecategoria" class="btn btn-default btn-lg" runat="server" Text="Guardar" OnClick="bsavecategoria_Click" />
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <asp:Button ID="bsavemarca" class="btn btn-default btn-lg" runat="server" Text="Guardar" OnClick="bsavemarca_Click" />
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <asp:Button ID="bsavemodelo" class="btn btn-default btn-lg" runat="server" Text="Guardar" OnClick="bsavemodelo_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
