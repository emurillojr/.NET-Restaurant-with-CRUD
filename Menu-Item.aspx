<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Menu-Item.aspx.cs" Inherits="SE256demoWEEK1.Menu_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <br />
    <br />
    <div class="container-fluid">

        <div class="form-horizontal">
            <fieldset>
                <legend>Menu Item Page</legend>
                <br />

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <div class="col-lg-10 col-lg-offset-2">
                        <p></p>
                    </div>
                    <asp:Label ID="lblName" runat="server" Text="Name:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Required*" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblAllergens" runat="server" Text="Allergens:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtAllergens" runat="server" CssClass="form-control"> </asp:TextBox>
                        <%--rfv not needed--%>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblPrice" runat="server" Text="Price:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Required*" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPrice" runat="server" ErrorMessage="Must be $ & greater than 0" ControlToValidate="txtPrice"
                            Type="Currency" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <%--menu type will need to be added to server--%>
                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblMenu" runat="server" Text="Menu:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlMenu" runat="server" CssClass="form-control" DataSourceID="sdsMenu" DataTextField="menu_name" DataValueField="menu_id"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsMenu" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString2 %>" SelectCommand="Menus_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="rfvMenu" runat="server" ErrorMessage="Required*" ControlToValidate="ddlMenu"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <%--Category type will need to be added to server--%>
                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblCategory" runat="server" Text="Category:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" DataSourceID="sdsCat" DataTextField="cat_name" DataValueField="cat_id"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsCat" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="Menu_Categories_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ErrorMessage="Required*" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <asp:Label ID="lblGluten_Free" runat="server" Text="Gluten Free:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:CheckBox ID="chkGluten_Free" runat="server" />
                        <%--need to fix --%> <%--<asp:RequiredFieldValidator ID="rfvIsActive" runat="server" ErrorMessage="Required*" ControlToValidate="chkIsActive"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="col-lg-5"></div>

                </div>

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
                        <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-primary" OnClick="lbtnCancelClick" CausesValidation="False">Cancel</asp:LinkButton>

                    </div>
                </div>

            </fieldset>
        </div>
        <%--closes class="form-horizontal">--%>
    </div>
    <%--closes class="container-fluid"--%>
</asp:Content>
