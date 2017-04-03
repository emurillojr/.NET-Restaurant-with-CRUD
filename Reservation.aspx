<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="SE256demoWEEK1.Reservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <br />
    <br />

    <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <br />

                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                <br />

                <legend>Reservation Page</legend>
                <br />

                <div id="GUESTINFO" runat="server">   <%-- ///div to hold the fields guest email,first, last, phone--%> 
                    <div class="form-group">
                        <asp:Label ID="lblGuestEmail" runat="server" Text="Guest Email:" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtGuestEmail" runat="server" CssClass="form-control"> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="rexGuestEmail" runat="server" ErrorMessage="Not a valid Email" ControlToValidate="txtGuestEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <p></p>
                        </div>
                        <asp:Label ID="lblGuestFirstName" runat="server" Text="Guest First Name:" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtGuestFirstName" runat="server" CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label ID="lblGuestLastName" runat="server" Text="Guest Last Name:" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtGuestLastName" runat="server" CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>
                
                    <div class="form-group">
                        <asp:Label ID="lblGuestPhone" runat="server" Text="Guest Phone Number:" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtGuestPhone" runat="server" CssClass="form-control"> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="rexGuestPhone" runat="server" ErrorMessage="Not a valid Phone Number" ControlToValidate="txtGuestPhone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>
                </div>   <%--//// closes div id GUESTINFO--%>

                <%--//holds the guestID and TblID hidden--%>
                        <asp:HiddenField ID="hidetxtGuestID" runat="server" />
                        <asp:HiddenField ID="hidetxtTblID" runat="server" />
           
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <p></p>
                    </div>
                    <asp:Label ID="lblUserID" runat="server" Text="Employee:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <%--**************  edited users_Get_All stored procedure to get last, first name as employee     --%>
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" DataSourceID="sdsEmployee" DataTextField="employee" DataValueField="user_id"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="users_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>
                    <div class="col-lg-5"></div>
                </div>

                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <p></p>
                    </div>
                    <asp:Label ID="lblResDate" runat="server" Text="Reservation Date:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtResDate" runat="server" CssClass="form-control" TextMode="Date"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvResDate" runat="server" ErrorMessage="Required*" ControlToValidate="txtResDate"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
           
                <div class="form-group">
                    <asp:Label ID="lblResTime" runat="server" Text="Reservation Time:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:RequiredFieldValidator ID="rfvResTime" runat="server" ErrorMessage="Required*" ControlToValidate="ddlResTime"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlResTime" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
           
                <div class="form-group">
                    <asp:Label ID="lblResGuestCnt" runat="server" Text="Reservation Guest Count:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtResGuestCnt" runat="server" CssClass="form-control" TextMode="Number" min="1" max="10"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvResGuestCnt" runat="server" ErrorMessage="Required*" ControlToValidate="txtResGuestCnt"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvResGuesCnt" runat="server" ControlToValidate="txtResGuestCnt" ErrorMessage="min 1, max 10" Type="Integer" MinimumValue="1" MaximumValue="10"></asp:RangeValidator>

                    </div>
                    <div class="col-lg-5"></div>
                </div>
     
                <div class="form-group">
                    <asp:Label ID="lblResSpecReq" runat="server" Text="Reservation Special Request:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtResSpecReq"  Rows="5" runat="server" CssClass="form-control" > </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvResSpecReq" runat="server" ErrorMessage="Required*" ControlToValidate="txtResSpecReq"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <br />
                        <br />
                        <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-success" OnClick="lbtnUpdate_Click">Update</asp:LinkButton>
                        <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-primary" OnClick="lbtnCancel_Click" CausesValidation="False">Cancel</asp:LinkButton>
                    </div>
                </div>

            </fieldset>
        </div>
    </div>

</asp:Content>
