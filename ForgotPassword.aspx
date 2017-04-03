<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="SE256demoWEEK1.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">


    <br />
    <br />
    <div class="container-fluid">


        <div class="form-horizontal">
            <fieldset>
                <legend>Reset Password Page</legend>
                <br />

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <div class="col-lg-10 col-lg-offset-2">

                        <p></p>
                        <br />

                    </div>

                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexEmail" runat="server" ErrorMessage="Not a valid Email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="cvBothEmails1" runat="server" ErrorMessage="Emails must match" ControlToValidate="txtEmail" Operator="Equal" Type="String" ControlToCompare="txtConfirmEmail"></asp:CompareValidator>

                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ErrorMessage="Required*" ControlToValidate="txtConfirmEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexConfirmEmail" runat="server" ErrorMessage="Not a valid Email" ControlToValidate="txtConfirmEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="cvBothEmails2" runat="server" ErrorMessage="Emails must match" ControlToValidate="txtConfirmEmail" Operator="Equal" Type="String" ControlToCompare="txtEmail"></asp:CompareValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Required*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvBothPasswords1" runat="server" ErrorMessage="Passwords must match" ControlToValidate="txtPassword" Operator="Equal" Type="String" ControlToCompare="txtConfirmPassword"></asp:CompareValidator>

                    </div>
                    <div class="col-lg-5"></div>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Required*" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvBothPasswords2" runat="server" ErrorMessage="Passwords must match" ControlToValidate="txtConfirmPassword" Operator="Equal" Type="String" ControlToCompare="txtPassword"></asp:CompareValidator>

                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <br />
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <br />
                        <br />
                        <%--<button type="reset" class="btn btn-primary">Cancel</button>--%>
                        <%--<button type="submit" class="btn btn-success">Reset Password</button>--%>
                        <asp:LinkButton ID="lbtnResetPassword" runat="server" CssClass="btn btn-success">Reset Password</asp:LinkButton>
                    </div>
                </div>

            </fieldset>
        </div>
        <%--closes class="form-horizontal">--%>
    </div>
    <%--closes class="container-fluid"--%>
</asp:Content>
