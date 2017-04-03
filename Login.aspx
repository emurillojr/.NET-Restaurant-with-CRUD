<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SE256demoWEEK1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <legend>Login To My Account</legend>
                <br />
                <div class="form-group">
                    <asp:Label ID="lblUserName" runat="server" Text="User Name:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" TextMode="Email"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Required*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--closes class="form-group"> above--%>

                <div class="form-group ">
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Required*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <br />
                        <asp:HyperLink ID="hlnkForgotPassword" runat="server" NavigateUrl="ForgotPassword.aspx"> I forgot my password</asp:HyperLink>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--closes class="form-group "> above--%>

                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <br />
                       <%-- ***** #3 --%>
                       <%-- ********added on click event for lab 5--%>
                        <asp:LinkButton ID="lbtnLogin" runat="server" CssClass="btn btn-success" OnClick="lbtnLogin_Click">Login</asp:LinkButton>
                        <br />
                       <%-- *******added for error message for login failed - Lab 5--%>
                        <asp:label id="lblMessage" runat="server" />
                    </div>
                </div>
                <%--closes class="form-group"> above--%>
            </fieldset>
        </div>
        <%--closes class="form-horizontal">--%>
    </div>
    <%--closes class="container-fluid"> top--%>
</asp:Content>
