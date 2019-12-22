<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kladionica._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <h1>Dobrodošli u Kladionicu</h1>
        <div class="row">
            <div class="col-md-4">
                <a href="Listici.aspx" data-toggle="tooltip" title="Listići">
                    <img src="Content/images/Listici.jpg" class="img-thumbnail" />
                </a>
            </div>
            <div class="col-md-4">
                <a href="Susreti.aspx" data-toggle="tooltip" title="Susreti">
                    <img src="Content/images/Susreti.jpg" class="img-thumbnail" />
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <a href="PregledPonuda.aspx" data-toggle="tooltip" title="Pregled ponuda">
                    <img src="Content/images/PregledPonuda.jpg" class="img-thumbnail" />
                </a>
            </div>
            <div class="col-md-4">
                <a href="PregledOklada.aspx" data-toggle="tooltip" title="Pregled oklada">
                    <img src="Content/images/PregledOklada.jpg" class="img-thumbnail" />
                </a>
            </div>
        </div>
    </div>
</asp:Content>
