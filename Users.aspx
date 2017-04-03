<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SE256demoWEEK1.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

<h3>Users Page</h3>
All Users


    <div class ="row">
            <div class ="col-md-12">
                <div class="table-responsive">
                
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" DataSourceID="sdsUsers" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundField DataField="user_id" HeaderText="User ID" SortExpression="user_id" />
                        <asp:BoundField DataField="user_email" HeaderText="User Email" SortExpression="user_email" />
                        <asp:BoundField DataField="user_first" HeaderText="User First Name" SortExpression="user_first" />
                        <asp:BoundField DataField="user_last" HeaderText="User Last Name" SortExpression="user_last" />
                        <asp:BoundField DataField="user_add1" HeaderText="User Add1" SortExpression="user_add1" />
                        <asp:BoundField DataField="user_add2" HeaderText="User Add2" SortExpression="user_add2" />
                        <asp:BoundField DataField="user_city" HeaderText="User City" SortExpression="user_city" />
                        <asp:BoundField DataField="state_id" HeaderText="User State ID" SortExpression="state_id" />
                        <asp:BoundField DataField="user_zip" HeaderText="User Zip" SortExpression="user_zip" />
                        <asp:BoundField DataField="user_salt" HeaderText="Salt" SortExpression="user_salt" />
                        <asp:BoundField DataField="user_pwd" HeaderText="Pwd" SortExpression="user_pwd" />
                        <asp:BoundField DataField="user_phone" HeaderText="User Phone" SortExpression="user_phone" />
                        <asp:BoundField DataField="user_active" HeaderText="User Active" SortExpression="user_active" />
                       

                       <asp:HyperLinkField DataNavigateUrlFields="user_id" DataNavigateUrlFormatString="Admin/User/{0}" Text="View/Edit"/>


                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" Position="TopAndBottom" />
                    <PagerStyle BackColor="YellowGreen" HorizontalAlign="Center" />
                </asp:GridView>
                    </div>
                <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="users_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>


</asp:Content>
