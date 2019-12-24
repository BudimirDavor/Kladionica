<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kladionica._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <h3><b>Kladionica Hattrick demo</b></h3>
        <div class="row">
            <div class="float">
                <a href="Listici.aspx" title="Listići" class="link">
                    <img src="Content/images/Listici.jpg" />
                </a>
            </div>
            <div class="float">
                <a href="Susreti.aspx" title="Susreti" class="link">
                    <img src="Content/images/Susreti.jpg" />
                </a>
            </div>
            <br />
            <div class="float">
                <a href="PregledPonuda.aspx" title="Pregled ponuda" class="link">
                    <img src="Content/images/PregledPonuda.jpg" />
                </a>
            </div>
            <div class="float">
                <a href="PregledOklada.aspx" title="Pregled oklada" class="link">
                    <img src="Content/images/PregledOklada.jpg" />
                </a>
            </div>
        </div>
    </div>
</asp:Content>
