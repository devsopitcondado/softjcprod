<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ingseries.aspx.cs" Inherits="Softjc.views.ingseries" %>

<%@ Reference Control ="~/views/Cantidad.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="container">
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
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <h4>
                            <asp:Label ID="dat" class="label label-default" runat="server" Text="Fecha:"></asp:Label></h4>
                        <asp:TextBox ID="date" class="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="container">

        <div class="row">

            <!-- Category -->

            <div class="col-xs-6 col-sm-3">
                <h4>
                    <asp:Label ID="categoria" class="label label-default" runat="server" Text="Categoria:"></asp:Label></h4>
                <hr />
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="list-group">
                            <asp:ListBox ID="Listcategoria" class="form-control" runat="server" ForeColor="Black" Height="250px" Rows="10" Width="200px" Font-Size="Medium" AutoPostBack="True"></asp:ListBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- Marca -->


            <div class="col-xs-6 col-sm-3">
                <h4>
                    <asp:Label ID="marca" class="label label-default" runat="server" Text="Marca:"></asp:Label></h4>
                <hr />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="list-group">
                            <asp:ListBox ID="Lismarca" class="form-control" runat="server" ForeColor="Black" Height="250px" Rows="10" Width="200px" Font-Size="Medium" AutoPostBack="True"></asp:ListBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- Modelo -->
            <div class="col-xs-6 col-sm-3">
                <h4>
                    <asp:Label ID="modelo" class="label label-default" runat="server" Text="Modelo:"></asp:Label></h4>
                <hr />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="list-group">
                            <asp:ListBox ID="Listmodelo" class="form-control" runat="server" ForeColor="Black" Height="250px" Rows="10" Width="200px" Font-Size="Medium" AutoPostBack="True"></asp:ListBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-xs-6 col-sm-4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <h4>
                            <asp:Label ID="serie" class="label label-default" runat="server" Text="Serie:"></asp:Label></h4>
                        <asp:TextBox ID="numserie" class="form-control" runat="server" Style="margin-left: 100px" Width="250px" placeholder="Ingrese Serie..."></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-xs-6 col-sm-3">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                <asp:CheckBox ID="Chksinserie" runat="server" AutoPostBack="true" Checked="false" class="checkbox" OnCheckedChanged="Chksinserie_CheckedChanged" />
                <h4>
                    <asp:Label ID="SS" class="label label-default" runat="server" Text="Sin Serie"></asp:Label></h4>
                         </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>
    <hr />
    <div class="container">

        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <div class="col-xs-6 col-sm-1">
                        <h4>
                            <asp:Label ID="iCant" class="label label-default" runat="server" Text="Ingrese Cantidad: " Enabled="False" Visible="False"></asp:Label></h4>
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <asp:TextBox ID="iCanttext" class="form-control" runat="server" Style="margin-left: 100px" Width="250px" placeholder="Ingrese Cantidad..." Enabled="False" Visible="False"></asp:TextBox>
                    </div>

                    <div class="col-xs-6 col-sm-4">
                        <asp:Button ID="cCtr" class="btn btn-default btn-lg" runat="server" OnClick="cCtr_Click" Text="Generar Series" Enabled="False" Visible="False" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <hr />
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
             <asp:PlaceHolder ID="CantPlaceHolder1" runat="server">
             </asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>

    <hr />

    <div class="container">
        <div class="row">
            <div class="col-xs-6 col-sm-4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="save" class="btn btn-default btn-lg" runat="server" OnClick="save_Click" Text="Guardar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-xs-6 col-sm-4">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="savecantidad" class="btn btn-default btn-lg" runat="server" OnClick="savecantidad_Click" Text="Guardar" Visible="false" Enabled ="false" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-xs-6 col-sm-8">
                <asp:GridView ID="GridSerie" class="table table-striped" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridSerie_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
