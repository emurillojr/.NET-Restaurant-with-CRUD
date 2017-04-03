<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ResMgmt.aspx.cs" Inherits="SE256demoWEEK1.ResMgmt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

<h3>Res Mgmt Page</h3>
All Reservations
    <br />
    <br />
    <asp:LinkButton ID="lbtnNewReservation" runat="server" CssClass="btn btn-info" OnClick="lbtnNewReservation_Click">New Reservation</asp:LinkButton>
          
    <br />
    <br />              

    <div class ="row">
            <div class ="col-md-12">
                <div class="table-responsive">
                
                <asp:GridView ID="gvResMgmt" runat="server" AutoGenerateColumns="false" DataSourceID="sdsResMgmt" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundField DataField="res_id" HeaderText="Res ID" SortExpression="res_id" />
                        <asp:BoundField DataField="guest_name" HeaderText="Guest Name" SortExpression="guest_name" />
                        <asp:BoundField DataField="tbl_name" HeaderText="Table Name" SortExpression="tbl_name" />
                        <asp:BoundField DataField="employee" HeaderText="Employee" SortExpression="employee" />
                        <asp:BoundField DataField="res_date" HeaderText="Res Date" SortExpression="res_date" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="res_time" HeaderText="Res Time" SortExpression="res_time" DataFormatString="{0:t}"/>
                        <asp:BoundField DataField="res_guest_cnt" HeaderText="Reservation Guest Count" SortExpression="res_guest_cnt" />
                        <asp:BoundField DataField="res_spec_req" HeaderText="Reservation Special Request" SortExpression="res_spec_req" />
                        
                       

                       <asp:HyperLinkField DataNavigateUrlFields="res_id" DataNavigateUrlFormatString="Admin/Reservation/{0}" Text="View/Edit"/>


                     </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" Position="TopAndBottom" />
                    <PagerStyle BackColor="YellowGreen" HorizontalAlign="Center" />
                </asp:GridView>
                    </div>
                <asp:SqlDataSource ID="sdsResMgmt" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="reservations_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>



</asp:Content>
