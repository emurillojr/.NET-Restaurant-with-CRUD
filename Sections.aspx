<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Sections.aspx.cs" Inherits="SE256demoWEEK1.Sections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

<h3>Sections Page</h3>   
All Sections

    <div class ="row">
            <div class ="col-md-12">
                <div class="table-responsive">
                
                <asp:GridView ID="gvSections" runat="server" AutoGenerateColumns="false" DataSourceID="sdsSections" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundField DataField="sect_id" HeaderText="Section ID" SortExpression="sect_id" />
                        <asp:BoundField DataField="sect_name" HeaderText="Section Name" SortExpression="sect_name" />
                        <asp:BoundField DataField="sect_desc" HeaderText="Section Description" SortExpression="sect_desc" />
                        <asp:BoundField DataField="sect_active" HeaderText="Section Active" SortExpression="sect_active" />
                        

                       <asp:HyperLinkField DataNavigateUrlFields="sect_id" DataNavigateUrlFormatString="Admin/Section/{0}" Text="View/Edit"/>


                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" Position="TopAndBottom" />
                    <PagerStyle BackColor="YellowGreen" HorizontalAlign="Center" />
                </asp:GridView>
                    </div>
                <asp:SqlDataSource ID="sdsSections" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_MurilloConnectionString %>" SelectCommand="sections_Get_All" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>

</asp:Content>
