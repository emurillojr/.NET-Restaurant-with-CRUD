<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="SE256demoWEEK1.Tables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

<h3>Tables Page</h3>
All Tables

    <div class ="row">
            <div class ="col-md-12">
                <div class="table-responsive">
                
                <asp:GridView ID="gvTables" runat="server" AutoGenerateColumns="false" DataSourceID="sdsTables" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundField DataField="tbl_name" HeaderText="Table Name" SortExpression="tbl_name" />
                        <asp:BoundField DataField="tbl_desc" HeaderText="Table Description" SortExpression="tbl_desc" />
                        <asp:BoundField DataField="tbl_seat_cnt" HeaderText="Table Seat Count" SortExpression="tbl_seat_cnt" />
                        <asp:BoundField DataField="sect_name" HeaderText="Section Name" SortExpression="sect_name" />
                        <asp:BoundField DataField="tbl_active" HeaderText="Table Active" SortExpression="tbl_active" />
                        

                       <asp:HyperLinkField DataNavigateUrlFields="tbl_id" DataNavigateUrlFormatString="Admin/Table/{0}" Text="View/Edit"/>


                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" Position="TopAndBottom" />
                    <PagerStyle BackColor="YellowGreen" HorizontalAlign="Center" />
                </asp:GridView>
                    </div>
                <asp:SqlDataSource ID="sdsTables" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="tables_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>


</asp:Content>
