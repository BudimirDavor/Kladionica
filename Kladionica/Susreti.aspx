<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Susreti.aspx.cs" Inherits="Kladionica.Susreti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="searchPanel" runat="server" DefaultButton="searchButton" CssClass="push-slightly-down">
        <div class="form-group lined-up">
            <label>Domaćin:</label>
            <asp:TextBox ID="domacinSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group lined-up">
            <label>Gost:</label>
            <asp:TextBox ID="gostSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group lined-up-button">
            <asp:LinkButton ID="searchButton" runat="server" OnClick="searchButton_Click">
            <span class="glyphicon glyphicon-search"></span>
            </asp:LinkButton>
        </div>
    </asp:Panel>
    <div class="form-group lined-up-button">
        <asp:LinkButton ID="addButton" runat="server" OnClick="addButton_Click">
            <span class="glyphicon glyphicon-plus"></span>
        </asp:LinkButton>
    </div>
    <div class="clear"></div>
    <asp:Panel ID="editPanel" runat="server" Visible="false" DefaultButton="saveLinkButton">
        <div class="form-group lined-up">
            <label>Domaćin:</label>
            <asp:TextBox ID="domacinTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="domacinReq" runat="server" 
                ControlToValidate="domacinTextBox"
                ValidationGroup="edit"
                Display="Dynamic"
                ForeColor="red"
                ErrorMessage="Unos je obavezan"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group lined-up">
            <label>Gost:</label>
            <asp:TextBox ID="gostTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="gostReq" runat="server" 
                ControlToValidate="gostTextBox"
                ValidationGroup="edit"
                Display="Dynamic"
                ForeColor="red"
                ErrorMessage="Unos je obavezan"></asp:RequiredFieldValidator>
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
                <th scope="col">Domaćin</th>
                <th scope="col">Gost</th>
                <th scope="col">Broj ponuda</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="susretiRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="domacinLabel" runat="server" Text='<%# Eval("Domacin") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="gostLabel" runat="server" Text='<%# Eval("Gost") %>'></asp:Label>
                        </td>
                        <td>
                            <span class="badge badge-pill">
                                <%# Eval("BrojPonuda") %>
                            </span>
                        </td>
                        <td>
                            <asp:LinkButton ID="ponudeLinkButton" runat="server" 
                                CommandArgument='<%# Eval("SusretId") %>' 
                                CommandName="link" OnCommand="editLinkButton_Command">
                                Ponude
                            </asp:LinkButton>
                        </td>
                        <td class="right">
                            <asp:LinkButton ID="editLinkButton" runat="server" 
                                CommandArgument='<%# Eval("SusretId") %>' 
                                CommandName="edit" OnCommand="editLinkButton_Command">
                                <span class="glyphicon glyphicon-pencil smaller-size put-right-margin"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="deleteLinkButton" runat="server" 
                                CommandArgument='<%# Eval("SusretId") %>' 
                                CommandName="edit" OnCommand="deleteLinkButton_Command"
                                OnClientClick="return confirm('Jeste li sigurni da želite izbrisati taj susret?')">
                                <span class="glyphicon glyphicon-remove smaller-size red"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
