<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="SE256demoWEEK1.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <br />
    <br />
    <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <legend>User Page</legend>
                <br />
                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <div class="col-lg-10 col-lg-offset-2">
                        <p></p>
                    </div>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required*" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Required*" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblAddress1" runat="server" Text="Address 1:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ErrorMessage="Required*" ControlToValidate="txtAddress1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblAddress2" runat="server" Text="Address 2:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control"> </asp:TextBox>
                        <%--rfv not needed--%>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>


                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblCity" runat="server" Text="City:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Required*" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>




<%--states will need to be added to server--%>
                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblState" runat="server" Text="State:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                
                         <%--added drop down list - called it ddlStates--%>
                        <asp:DropDownList ID="ddlStates" runat="server" CssClass="form-control" DataSourceID="sdsStates" DataTextField="State_Full_Name" DataValueField="state_id"></asp:DropDownList>
                        <%--<asp:SqlDataSource ID="sdsStates" runat="server" ConnectionString="<%$ ConnectionStrings:SE256 %>" SelectCommand="States_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        --%>
                        <%--<asp:SqlDataSource ID="sdsStates" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="States_Get_All" SelectCommandType="StoredProcedure" ></asp:SqlDataSource>
                        --%>
                       
                        <asp:SqlDataSource ID="sdsStates" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString2 %>" SelectCommand="States_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                        <%--<asp:DropDownList ID="ddlStates" runat="server" CssClass="form-control">
                        <asp:ListItem Value=""></asp:ListItem>   <%--made a blank entry for rfv test--%>
                        <%--<asp:ListItem Value="1">RI</asp:ListItem>
                        <asp:ListItem Value="2">MA</asp:ListItem>
                        <asp:ListItem Value="3">CT</asp:ListItem>--%>
                        <%--</asp:DropDownList>--%>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Required*" ControlToValidate="ddlStates"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblZip" runat="server" Text="Zip Code:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvZip" runat="server" ErrorMessage="Required*" ControlToValidate="txtZip"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexZip" runat="server" ErrorMessage="Not a valid Zip Code" ControlToValidate="txtZip" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

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
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexEmail" runat="server" ErrorMessage="Not a valid Email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="cvBothEmails1" runat="server" ErrorMessage="Emails must match" ControlToValidate="txtConfirmEmail" Operator="Equal" Type="String" ControlToCompare="txtEmail"></asp:CompareValidator>

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
                        <asp:CompareValidator ID="cvBothEmails2" runat="server" ErrorMessage="Emails must match" ControlToValidate="txtEmail" Operator="Equal" Type="String" ControlToCompare="txtConfirmEmail"></asp:CompareValidator>
               
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Required*" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexPhone" runat="server" ErrorMessage="Not a valid Phone Number" ControlToValidate="txtPhone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <asp:Label ID="lblIsActive" runat="server" Text="Is Active:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                        <%--need to fix --%> <%--<asp:RequiredFieldValidator ID="rfvIsActive" runat="server" ErrorMessage="Required*" ControlToValidate="chkIsActive"></asp:RequiredFieldValidator>--%>
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
                        <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-success" OnClick="lbtnUpdate_Click">Update</asp:LinkButton>
                        
                        <%--*********onclick links to function on thispage.aspx.cs--%>
                        <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-primary" OnClick="lbtnCancelClick" CausesValidation="False" >Cancel</asp:LinkButton>

                    </div>
                </div>

            </fieldset>
        </div>
        <%--closes class="form-horizontal">--%>
    </div>
    <%--closes class="container-fluid"--%>
</asp:Content>
