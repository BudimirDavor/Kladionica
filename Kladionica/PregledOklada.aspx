<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PregledOklada.aspx.cs" Inherits="Kladionica.PregledOklada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="searchPanel" runat="server" DefaultButton="searchButton" CssClass="push-slightly-down">
        <div class="form-group col-lg-2">
            <label>Vrijeme uplate:</label>
            <asp:TextBox ID="vrijemeUplateSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2">
            <label>Iznos uplate:</label>
            <asp:TextBox ID="iznosUplateSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2">
            <label>Mogući dobitak:</label>
            <asp:TextBox ID="moguciDobitakTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2">
            <label>Koeficient:</label>
            <asp:TextBox ID="koeficientSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group lined-up-button">
            <asp:LinkButton ID="searchButton" runat="server" OnClick="searchButton_Click">
                <span class="glyphicon glyphicon-search"></span>
            </asp:LinkButton>
        </div>
    </asp:Panel>
    <div class="clear"></div>
    <table class="table table-striped table-condensed narrower">
        <thead>
            <tr>
                <th scope="col">Listić</th>
                <th scope="col">Koeficient</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="okladeRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="listicLabel" runat="server" Text='<%# Eval("Listic") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="koeficientLabel" runat="server" Text='<%# Eval("Koeficient") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
