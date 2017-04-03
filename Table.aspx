<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="SE256demoWEEK1.Table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <br />
    <br />
    <div class="container-fluid">

        <div class="form-horizontal">
            <fieldset>
                <legend>Table Page</legend>
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



                <%--Section will need to be added to server--%>
                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblSection" runat="server" Text="Section:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        
                    <%--     <asp:DropDownList ID="ddlStates" runat="server" CssClass="form-control" DataSourceID="sdsStates" DataTextField="State_Full_Name" DataValueField="state_id"></asp:DropDownList>
                     --%>  
                         <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control" DataSourceID="sdsSections" DataTextField="sect_name" DataValueField="sect_id"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsSections" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString2 %>" SelectCommand="sections_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="rfvSection" runat="server" ErrorMessage="Required*" ControlToValidate="ddlSection"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <%--spacing for text to aline with textboxes--%>
                    <asp:Label ID="lblSeatCount" runat="server" Text="Seat Count:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtSeatCount" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSeatCount" runat="server" ErrorMessage="Required*" ControlToValidate="txtSeatCount"></asp:RequiredFieldValidator>
                      <%--  <asp:CompareValidator ID="cvSeatCount" runat="server" ErrorMessage="Must be # & greater than 0" ControlToValidate="txtSeatCount"
                            Type="Integer" Operator="GreaterThanEqual" ValueToCompare="1" ></asp:CompareValidator>
                    --%>

                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%-- closes class="form-group"> above--%>

                <div class="form-group">
                    <asp:Label ID="lblIsActive" runat="server" Text="Is Active:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                    </div>
                    <div class="col-lg-5"></div>

                </div>


                <br />
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <br />
                        <br />
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

