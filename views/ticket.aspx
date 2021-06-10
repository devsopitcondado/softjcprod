<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ticket.aspx.cs" Inherits="Softjc.views.ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="page-header">Salida</h1>

    <h2 class="sub-header">Series</h2>

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
    <hr />
    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="requeri" class="label label-default" runat="server" Text="Requerimiento"></asp:Label></h4>
        </div>
        <div class="col-xs-6 col-sm-4">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
            <asp:TextBox ID="treqfind" class="form-control" runat="server"></asp:TextBox>
                  </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div class="col-xs-6 col-sm-4">
             <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
            <asp:Button ID="findredestino" class="btn btn-default btn-lg" runat="server" Text="Buscar" OnClick="findredestino_Click" />
                </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>
    <hr />
    <hr />
    <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="Fdestino" class="table table-striped" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True"
                    OnPageIndexChanging="Fdestino_PageIndexChanging"
                    OnSelectedIndexChanged="Fdestino_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/check.ico" ShowSelectButton="True" />
                    </Columns>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <hr />
    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="serie" class="label label-default" runat="server" Text="Serie"></asp:Label></h4>
        </div>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="col-xs-6 col-sm-4">
                    <asp:TextBox ID="tserie" class="form-control" runat="server" Enabled="False" Height="34px" Width="100%"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <hr />
    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="uso" class="label label-default" runat="server" Text="Uso"></asp:Label></h4>
        </div>
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="salida" class="label label-default" runat="server" Text="Salida"></asp:Label></h4>
        </div>
    </div>
    <hr />
    <hr />
    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <asp:DropDownList ID="ddluso" class="btn btn-default dropdown-toggle" runat="server">
                <asp:ListItem>STOCK</asp:ListItem>
                <asp:ListItem>ASIGNACION</asp:ListItem>
                <asp:ListItem>APERTURA DE TIENDA</asp:ListItem>
                <asp:ListItem>PRESTAMO</asp:ListItem>
                <asp:ListItem>OTROS</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="col-xs-6 col-sm-4">
                    <asp:TextBox ID="tsalida" class="form-control" runat="server" Enabled="False" Height="34px" Width="100%"></asp:TextBox>
                </div>
                <div class="col-xs-6 col-sm-4">
                    <asp:CheckBox ID="editsalida" runat="server" OnCheckedChanged="editsalida_CheckedChanged" AutoPostBack="true"
                        Text="Habilitar" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <hr />
    <hr />
    <div class="row">

        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="vp" class="label label-default" runat="server" Text="Vicepresidencia"></asp:Label></h4>

        </div>

        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="req" class="label label-default" runat="server" Text="Requerimiento"></asp:Label></h4>

        </div>
    </div>
    <hr />
    <hr />
    <div class="row">

        <div class="col-xs-6 col-sm-4">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <h4>
                        <asp:TextBox ID="tvice" class="form-control" Enabled="False" Height="34px" Width="100%" runat="server"></asp:TextBox></h4>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-xs-6 col-sm-4">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="treqeq" class="form-control" runat="server" Enabled="False" Height="34px" Width="100%"></asp:TextBox>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
    <hr />
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="col-xs-6 col-sm-3">
                    <asp:Button ID="update" class="btn btn-default btn-lg" runat="server" OnClick="update_Click" Text="Actualizar" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <hr />



    <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:GridView ID="SalidaGrd" class="table table-striped" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="SalidaGrd_PageIndexChanging" OnRowDeleting="SalidaGrd_RowDeleting" PageSize="250">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
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
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <div class="row">
        <div class="col-xs-6 col-sm-3">
            <asp:Button ID="finalizar" class="btn btn-default btn-lg" runat="server" Text="Finalizar" OnClick="Finalizar_Click" />
        </div>
    </div>

</asp:Content>

