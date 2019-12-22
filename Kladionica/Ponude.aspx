<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ponude.aspx.cs" Inherits="Kladionica.Ponude" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group push-slightly-down">
        <asp:HyperLink ID="susretLink" runat="server" NavigateUrl="~/Susreti">
            <asp:Label ID="susretLabel" runat="server" Font-Size="X-Large"></asp:Label>
        </asp:HyperLink>
        <asp:LinkButton ID="addButton" runat="server" OnClick="addButton_Click" CssClass="put-left-margin">
            <span class="glyphicon glyphicon-plus"></span>
        </asp:LinkButton>
    </div>
    <div class="clear"></div>
    <asp:Panel ID="editPanel" runat="server" Visible="false" DefaultButton="saveLinkButton">
        <div class="form-group lined-up">
            <label>Tip:</label>
            <asp:DropDownList ID="tipDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="X" Value="X"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group lined-up">
            <label>Koeficient:</label>
            <asp:TextBox ID="koeficientTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="koeficientReq" runat="server" 
                ControlToValidate="koeficientTextBox"
                ValidationGroup="edit"
                Display="Dynamic"
                ForeColor="red"
                ErrorMessage="Unos je obavezan"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="koeficientReg" runat="server"
                ControlToValidate="koeficientTextBox"
                ForeColor="Red"
                ValidationGroup="edit"
                ValidationExpression="^[1-9][0-9]*,?[0-9]*$"
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
                <th scope="col">Tip</th>
                <th scope="col">Koeficient</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="ponudeRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="tipLabel" runat="server" Text='<%# Eval("Tip") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="koeficientLabel" runat="server" Text='<%# Eval("Koeficient") %>'></asp:Label>
                        </td>
                        <td class="right">
                            <asp:LinkButton ID="editLinkButton" runat="server" 
                                CommandArgument='<%# Eval("PonudaId") %>' 
                                CommandName="edit" OnCommand="editLinkButton_Command">
                                <span class="glyphicon glyphicon-pencil smaller-size put-right-margin"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="deleteLinkButton" runat="server" 
                                CommandArgument='<%# Eval("PonudaId") %>' 
                                CommandName="edit" OnCommand="deleteLinkButton_Command"
                                OnClientClick="return confirm('Jeste li sigurni da želite izbrisati tu ponudu?')">
                                <span class="glyphicon glyphicon-remove smaller-size red"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
