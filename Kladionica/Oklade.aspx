<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Oklade.aspx.cs" Inherits="Kladionica.Oklade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group push-slightly-down">
        <asp:HyperLink ID="listicLink" runat="server" NavigateUrl="~/Listici">
            <asp:Label ID="listicLabel" runat="server" Font-Size="X-Large"></asp:Label>
        </asp:HyperLink>
        <asp:LinkButton ID="addButton" runat="server" OnClick="addButton_Click" CssClass="put-left-margin">
            <span class="glyphicon glyphicon-plus"></span>
        </asp:LinkButton>
    </div>
    <div class="clear"></div>
    <asp:Panel ID="editPanel" runat="server" Visible="false" DefaultButton="saveLinkButton">
        <div class="form-group lined-up">
            <label>Ponuda:</label>
            <asp:DropDownList ID="ponudaDropDownList" runat="server" CssClass="form-control" 
                DataTextField="Description" DataValueField="PonudaId">
            </asp:DropDownList>
        </div>
        <div class="form-group lined-up-button">
            <asp:LinkButton ID="saveLinkButton" runat="server" 
                OnClick="saveLinkButton_Click" 
                CausesValidation="true"
                ValidationGroup="edit">
                <span class="glyphicon glyphicon-floppy-disk"></span>
            </asp:LinkButton>
        </div>
    </asp:Panel>
    <div class="clear"></div>
    <table class="table table-striped table-condensed narrower">
        <thead>
            <tr>
                <th scope="col">Ponuda</th>
                <th scope="col">Koeficient</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="okladeRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="ponudaLabel" runat="server" Text='<%# Eval("Ponuda") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="koeficientLabel" runat="server" Text='<%# Eval("Koeficient") %>'></asp:Label>
                        </td>
                        <td class="right">
                            <asp:LinkButton ID="deleteLinkButton" runat="server" 
                                CommandArgument='<%# Eval("OkladaId") %>' 
                                CommandName="edit" OnCommand="deleteLinkButton_Command"
                                OnClientClick="return confirm('Jeste li sigurni da želite izbrisati tu okladu?')">
                                <span class="glyphicon glyphicon-remove smaller-size red"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
