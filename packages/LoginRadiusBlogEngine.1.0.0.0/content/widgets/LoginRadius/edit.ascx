<%@ Control Language="C#" AutoEventWireup="true" CodeFile="edit.ascx.cs" Inherits="Widgets.Twitter.widgets_LoginRadius_edit" %>


<fieldset>
    <legend>LoghinRadius Configuration</legend>


    <label for="<%=txtKey.ClientID %>">
        Key</label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="txtKey" ErrorMessage="Please enter a key"
        ValidationGroup="add" /><br />
    <asp:TextBox runat="server" ID="txtKey" Width="250px" />
    <br />
    <br />
    <label for="<%=txtsecret.ClientID %>">
        Secret</label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="Server" ControlToValidate="txtsecret" ErrorMessage="Please enter a secret"
        ValidationGroup="add" />
    
    <br />
    <asp:TextBox runat="server" ID="txtsecret" Width="250px" />

  
</fieldset>
