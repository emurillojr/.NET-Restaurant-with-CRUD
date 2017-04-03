<%@ Page Title="" Language="C#" MasterPageFile="~/Demo.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE256demoWEEK1.Directions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <legend>Contact Us</legend>
    <div class="container-fluid">
        <br />
         <asp:Label ID="lblmessage" runat="server"></asp:Label>
        <div class="row">
            <div class="col-lg-12">
                <div style="color: sandybrown">
                    Send us a message.  We appreciate any feedback.
                    <br /> <br />
                </div>
                <!--close small well div-->
            </div>
            <!--close 12 div-->
        </div>

        <div class="form-horizontal">
            <fieldset>
                <br />
                <div class="form-group">
                    <label for="Comments" class="col-lg-2 control-label">Comments:</label>
                    <div class="col-lg-10">
                        <textarea class="form-control" rows="5" id="Comments"></textarea>
                        <span class="help-block" style="color: sandybrown">In order to best serve you, please help us by providing your information below so that we may follow up regarding your questions or comments. Thank you.</span>
                        <br />
                        <br />
                    </div>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblName" runat="server" Text="Name:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                </div>
                <br />

                <div class="form-group">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number:" CssClass="col-lg-2 control-label"></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Required*" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexPhone" runat="server" ErrorMessage="Not a valid Phone Number" ControlToValidate="txtPhone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                </div>
                <br />

                <div class="form-group">
                        <asp:Label ID="lblGuestEmail" runat="server" Text="Email:" CssClass="col-lg-2 control-label"></asp:Label>
                       <div class="col-lg-10">
                         <asp:TextBox ID="txtGuestEmail" runat="server" CssClass="form-control"> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="rexGuestEmail" runat="server" ErrorMessage="Not a valid Email" ControlToValidate="txtGuestEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                </div>
                <br />


                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                   <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-primary" OnClick="lbtnCancel_Click" CausesValidation="False" >Cancel</asp:LinkButton>
                   <asp:LinkButton ID="lbtnSendMessage" runat="server" CssClass="btn btn-success" OnClick="lbtnSendMessage_Click" >Send Message</asp:LinkButton>
                   </div>
                    <br />
                   
                </div>
            </fieldset>
        </div>

    </div>
    <br />
    <br />
    <br />
    <br />
    <br />



</asp:Content>
