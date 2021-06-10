<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ingseriesadmin.aspx.cs" Inherits="Softjc.views.ingseriesadmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Dashboard</h1>
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
    
    <!--   Empieza la entrada de los productos -->

    <hr />
    
    <h4>Entrada</h4>
    
    <hr />
      <div class="row">
                <div class="col-xs-6 col-sm-4">

                    <asp:TextBox ID="findseriebin" class="form-control" runat="server" Height="25px" Width="383px" OnTextChanged="findseriebin_TextChanged"></asp:TextBox>
                </div>

    </div>

    <hr />

    <hr />

    <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">

            <ContentTemplate>
                <asp:GridView ID="Rsentrada" class="table table-striped" runat="server"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="Rsentrada_PageIndexChanging"
                    OnSelectedIndexChanged="Rsentradag_SelectedIndexChanged">
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
    
    
    <div class="row">

        <div class="col-xs-6 col-sm-4">

            <h4>
                <asp:Label ID="Label1" class="label label-default" runat="server" Text="Serie"></asp:Label></h4>

        </div>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="col-xs-6 col-sm-4">

                    <asp:TextBox ID="entradaserieprod" class="form-control" runat="server" Enabled="False" Height="25px" Width="383px"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">

            <h4>
                <asp:Label ID="Label2" class="label label-default" runat="server" Text="Uso"></asp:Label></h4>

        </div>
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="Label3" class="label label-default" runat="server" Text="Vicepresidencia"></asp:Label></h4>

        </div>

    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <asp:DropDownList ID="ddlusoin" class="btn btn-default dropdown-toggle" runat="server">
                <asp:ListItem>STOCK</asp:ListItem>
                <asp:ListItem>ASIGNACION</asp:ListItem>
                <asp:ListItem>APERTURA DE TIENDA</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-xs-6 col-sm-4">
            <asp:DropDownList ID="ddlvpin" class="btn btn-default dropdown-toggle" runat="server">
                <asp:ListItem>VPBCEBCAP</asp:ListItem>
                <asp:ListItem>VPSC</asp:ListItem>
                <asp:ListItem>VPBNC</asp:ListItem>
                <asp:ListItem>VPA</asp:ListItem>
                <asp:ListItem>VPI</asp:ListItem>
                <asp:ListItem>VPE</asp:ListItem>
                <asp:ListItem>VPCCI</asp:ListItem>
                 </asp:DropDownList>
        </div>

    </div>



    <div class="row">

        <div class="col-xs-6 col-sm-4">
          

        </div>

           </div>
    <div class="row">

        <div class="col-xs-6 col-sm-4">


           
        </div>

    </div>
    <hr />

    <div class="row">
        <div class="col-xs-6 col-sm-3">

            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:Button ID="prdin" class="btn btn-default btn-lg" runat="server" OnClick="prdin_Click" Text="Ingreso" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    
    <hr />
    
    
    <h4>
        <asp:Label ID="Label4" runat="server" Text="Seleccione por favor: "></asp:Label>
    </h4>
     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="invfiltro" class="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="invfiltro_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>STOCK</asp:ListItem>
                <asp:ListItem>APERTURA DE TIENDA</asp:ListItem>
                <asp:ListItem>ASIGNACION</asp:ListItem>
            </asp:DropDownList>
    </ContentTemplate>
            </asp:UpdatePanel>
    
    <hr />

    <!--   Finaliza la entrada de los productos -->


    <!-- Muestra la cantidad de productos en stock, asignacion y apertura de tienda por categoria -->

     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>

        <asp:MultiView ID="MultiView1" runat="server">
            
        <asp:View ID="View0" runat="server">
     <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">

            <ContentTemplate>
                 <asp:GridView ID="stocatprd0" class="table table-striped" runat="server"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="35">
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
        </asp:View>
        <asp:View ID="View1" runat="server">
     <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">

            <ContentTemplate>
                 <asp:GridView ID="stocatprd1" class="table table-striped" runat="server"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="35">
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
        </asp:View>
            <asp:View ID="View2" runat="server">
     <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">

            <ContentTemplate>
                 <asp:GridView ID="stocatprd2" class="table table-striped" runat="server"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="35">
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
        </asp:View>
    </asp:MultiView>
                     </ContentTemplate>
            </asp:UpdatePanel>


   


    <!--   Finaliza -->


    <h4>Producto ya ingresado listo para darle un Destino</h4>
    
    <hr />


    <!-- Muestra los productos ya ingresado listo para darle un destino -->


    <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                 <asp:GridView ID="Rprdentsindestinogrid" class="table table-striped" runat="server"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" 
                     OnPageIndexChanging="Rprdentsindestinogrid_PageIndexChanging" OnSelectedIndexChanged="Rprdentsindestinogrid_SelectedIndexChanged"> 
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
                    <asp:TextBox ID="tserie" class="form-control" runat="server" Enabled="False" Height="25px" Width="383px"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">

            <h4>
                <asp:Label ID="uso" class="label label-default" runat="server" Text="Uso"></asp:Label></h4>

        </div>
        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="destino" class="label label-default" runat="server" Text="Destino"></asp:Label></h4>

        </div>

    </div>

    <div class="row">
        <div class="col-xs-6 col-sm-4">
            <asp:DropDownList ID="ddluso" class="btn btn-default dropdown-toggle" runat="server">
                <asp:ListItem>ASIGNACION</asp:ListItem>
                <asp:ListItem>APERTURA DE TIENDA</asp:ListItem>
                <asp:ListItem>PRESTAMO</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-xs-6 col-sm-4">
            <asp:TextBox ID="tdestino" class="form-control" runat="server"></asp:TextBox>
        </div>

    </div>



    <div class="row">

        <div class="col-xs-6 col-sm-4">
            <!--

            <h4>

            <asp:Label ID="vp" class="label label-default" runat="server" Text="Vicepresidencia"></asp:Label>
                
            </h4>

                -->

        </div>

        <div class="col-xs-6 col-sm-4">
            <h4>
                <asp:Label ID="req" class="label label-default" runat="server" Text="Requerimiento"></asp:Label></h4>

        </div>
    </div>
    <div class="row">

        <div class="col-xs-6 col-sm-4">
            
            
            <!-- Codigo comentado ya que no puede salir un producto ingresado a una VP a otra VP
            
                <asp:DropDownList ID="ddlvp" class="btn btn-default dropdown-toggle" runat="server">
                <asp:ListItem>VPBCEBCAP</asp:ListItem>
                <asp:ListItem>VPSC</asp:ListItem>
                <asp:ListItem>VPBNC</asp:ListItem>
                <asp:ListItem>VPA</asp:ListItem>
                <asp:ListItem>VPI</asp:ListItem>
                <asp:ListItem>VPE</asp:ListItem>
                <asp:ListItem>VPCCI</asp:ListItem>

            </asp:DropDownList> -->
        
            </div>

        <div class="col-xs-6 col-sm-4">
            <asp:TextBox ID="treq" class="form-control" runat="server"></asp:TextBox>
        </div>
    
    </div>
    
    
    
    <hr />

    <div class="row">
        <div class="col-xs-6 col-sm-3">

            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <asp:Button ID="update" class="btn btn-default btn-lg" runat="server" OnClick="update_Click" Text="Actualizar" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <hr />
    <hr />
    <hr />

    
        <hr />
    <hr />
    <hr />

    <div class="table-responsive">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:GridView ID="Rprdentcondestinogrid" class="table table-striped" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True"
                    OnPageIndexChanging="Rprdentcondestinogrid_PageIndexChanging" OnSelectedIndexChanged="Rprdentcondestinogrid_SelectedIndexChanged">
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



         </asp:Content>

