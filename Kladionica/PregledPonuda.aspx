<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PregledPonuda.aspx.cs" Inherits="Kladionica.PregledPonuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="searchPanel" runat="server" DefaultButton="searchButton" CssClass="push-slightly-down">
        <div class="form-group col-lg-2">
            <label>Domaćin:</label>
            <asp:TextBox ID="domacinSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2">
            <label>Gost:</label>
            <asp:TextBox ID="gostSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2">
            <label>Tip:</label>
            <asp:DropDownList ID="tipSearchDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="X" Value="X"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
            </asp:DropDownList>
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
                <th scope="col">Susret</th>
                <th scope="col">Tip</th>
                <th scope="col">Koeficient</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="ponudeRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="susretLabel" runat="server" Text='<%# Eval("Susret") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="tipLabel" runat="server" Text='<%# Eval("Tip") %>'></asp:Label>
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
