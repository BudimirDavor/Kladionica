<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listici.aspx.cs" Inherits="Kladionica.Listici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="searchPanel" runat="server" DefaultButton="searchButton" CssClass="push-slightly-down">
        <div class="form-group lined-up">
            <label>Vrijeme uplate:</label>
            <asp:TextBox ID="vrijemeUplateSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group lined-up">
            <label>Iznos uplate:</label>
            <asp:TextBox ID="iznosUplateSearchTextBox" runat="server" CssClass="form-control"></asp:TextBox>
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
            <label>Vrijeme uplate:</label>
            <asp:TextBox ID="vrijemeUplateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vrijemeUplateReq" runat="server" 
                ControlToValidate="vrijemeUplateTextBox"
                ValidationGroup="edit"
                Display="Dynamic"
                ForeColor="red"
                ErrorMessage="Unos je obavezan"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="vrijemeUplateRan" runat="server"
                ControlToValidate="vrijemeUplateTextBox"
                ValidationGroup="edit"
                Display="Dynamic"
                ForeColor="red"
                OnServerValidate="vrijemeUplateRan_ServerValidate"
                ErrorMessage="Mora biti ispravan format (npr. 5.10.2020 10:45)"></asp:CustomValidator>
        </div>
        <div class="form-group lined-up">
            <label>Iznos uplate:</label>
            <asp:TextBox ID="iznosUplateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="iznosUplateReq" runat="server" 
                ControlToValidate="iznosUplateTextBox"
                ValidationGroup="edit"
                Display="Dynamic"
                ForeColor="red"
                ErrorMessage="Unos je obavezan"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="iznosUplateReg" runat="server"
                ControlToValidate="iznosUplateTextBox"
                ForeColor="Red"
                ValidationGroup="edit"
                ValidationExpression="^[1-9][0-9]*$"
                ErrorMessage="Mora biti brojčani iznos"></asp:RegularExpressionValidator>
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
                <th scope="col">Vrijeme uplate</th>
                <th scope="col">Iznos uplate</th>
                <th scope="col">Mogući dobitak</th>
                <th scope="col">Broj oklada</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="listiciRepeater" runat="server" >
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="vrijemeUplateLabel" runat="server" Text='<%# Eval("VrijemeUplate", "{0:dd.MM.yyyy HH:mm}") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="iznosUplateLabel" runat="server" Text='<%# Eval("IznosUplate", "{0:c}") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="moguciDobitakLabel" runat="server" Text='<%# Eval("MoguciDobitak", "{0:c}") %>'></asp:Label>
                        </td>
                        <td>
                            <span class="badge badge-pill">
                                <%# Eval("BrojOklada") %>
                            </span>
                        </td>
                        <td>
                            <asp:LinkButton ID="okladeLinkButton" runat="server"
                                CommandArgument='<%# Eval("ListicId") %>'
                                CommandName="link" OnCommand="editLinkButton_Command">
                                Oklade
                            </asp:LinkButton>
                        </td>
                        <td class="right">
                            <asp:LinkButton ID="editLinkButton" runat="server"
                                CommandArgument='<%# Eval("ListicId") %>'
                                CommandName="edit" OnCommand="editLinkButton_Command">
                                <span class="glyphicon glyphicon-pencil smaller-size put-right-margin"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="deleteLinkButton" runat="server" 
                                CommandArgument='<%# Eval("ListicId") %>' 
                                CommandName="edit" OnCommand="deleteLinkButton_Command"
                                OnClientClick="return confirm('Jeste li sigurni da želite izbrisati taj Listic?')">
                                <span class="glyphicon glyphicon-remove smaller-size red"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                
            </asp:Repeater>
        </tbody>
    </table>
    <div>
        <a href="logs/log.txt" title="Logovi" class="link" target="_blank">
            <h3>Logovi kreiranja listića</h3>
        </a>
    </div>
</asp:Content>
