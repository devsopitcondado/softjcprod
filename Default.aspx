<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Softjc._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <img src="Imagenes/C1.jpg" alt="mll">
                <div class="carousel-caption">
                    <h3>Maquina llenadora de latas</h3>
                    <p>CREEMOS, CONFIAMOS E INVERTIMOS EN GUATEMALA</p>
                </div>
            </div>
            <div class="item">
                <img src="Imagenes/C5.jpg" alt="mdc">
                <div class="carousel-caption">
                    <h3>Moderna casa de cocimientos</h3>
                    <p>CREEMOS, CONFIAMOS E INVERTIMOS EN GUATEMALA</p>
                </div>
            </div>
            <div class="item">
                <img src="Imagenes/C4.png" alt="reconocimientos">
                <div class="carousel-caption">
                    <h3>Múltiples reconocimientos a nivel mundial</h3>
                    <p>CREEMOS, CONFIAMOS E INVERTIMOS EN GUATEMALA</p>
                </div>
            </div>
        </div>
        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

</asp:Content>
