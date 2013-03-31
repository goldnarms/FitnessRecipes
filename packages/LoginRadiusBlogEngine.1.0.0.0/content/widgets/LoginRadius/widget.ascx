<%@ Control Language="C#" AutoEventWireup="true" CodeFile="widget.ascx.cs" Inherits="Widgets.BlogRoll.widgets_LoginRadius_widget"
    ViewStateMode="Enabled" EnableViewState="true" %>
<div runat="server" id="frmloginradius" style="width: 178px; height: 46px; margin-left: auto;
    margin-right: auto;">
    <iframe src="https://hub.loginradius.com/Control/PluginSlider.aspx?apikey=<%= Apikey %>"
        width="400" height="264" frameborder="0"></iframe>
</div>
<div runat="server" id="frmemail" style="position: fixed; width: 100%; height: 100%;
    top: 0px; left: 0px; background: none no-repeat scroll 0 0 rgba(127, 127, 127, 0.6);">
    <div class="frmemail" style="width: 380px; background-color: white; height: 100px;
        padding: 20px; position: absolute; top: 50%; left: 50%; margin-left: -200px;
        margin-top: -30px; border: 4px solid #666;">
        <div>
            <b>Please Enter your Email ID</b></div>
        <br />
        <div>
            Email ID :
            <asp:TextBox runat="server" ID="txt_email" ValidationGroup="lremail"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfv_txt_email" ControlToValidate="txt_email"
                ValidationGroup="lremail" ErrorMessage="Email ID is required" Style="visibility: visible;
                font-size: 12px; margin-top: 5px; position: absolute"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="rev_txt_email" ControlToValidate="txt_email"
                ErrorMessage="Valid Email ID required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="lremail" Style="visibility: visible; font-size: 12px; margin-top: 5px;">
            </asp:RegularExpressionValidator>
            <br />
            <br />
            
            <asp:LinkButton runat="server" ID="btn_submitemail" Text="Submit" OnClick="btn_submitemail_click"
                ValidationGroup="lremail" Style="background-color: #CCC; padding: 4px 12px 4px 12px;
                color: black; margin-left: 154px;"></asp:LinkButton>
            <div style="width: 169px; margin-left: 266px; font-size:11px;">
              
                    Powered By
                <a href="http://www.loginradius.com">
                    <img src="https://hub.loginradius.com/Include/Interfaces/PluginSlider/img/icon2/loginradiusshort.png" alt="LoginRadius"
                        style=" position:absolute; margin-top:-3px;" /></a>
            </div>
        </div>
    </div>
</div>
<div runat="server" id="statefields">
    <input type="hidden" id="hdID" runat="server" />
    <input type="hidden" id="hdBirthDate" runat="server" />
    <input type="hidden" id="hdProfileName" runat="server" />
    <input type="hidden" id="hdFirstName" runat="server" />
    <input type="hidden" id="hdLastName" runat="server" />
    <input type="hidden" id="hdMiddleName" runat="server" />
</div>
