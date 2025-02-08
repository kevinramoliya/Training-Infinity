<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="form_route_master.aspx.cs" Inherits="Practise_project.Route.form_route_master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2 class="text-center mt-4 mb-4">Route Registration Form</h2>

    <div class="container mt-5">
        <!-- Form Section with Border and Padding -->
        <div class="form-container" style="max-width: 600px; margin: auto;">

            <!-- Route Name -->
            <div class="mb-3">
                <asp:Label Text="Route Name:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_route" ToolTip="Route Name" runat="server" CssClass="form-control" placeholder="Enter Route Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Rrname" runat="server" ForeColor="Red" ControlToValidate="txt_route" ErrorMessage="Please Enter Route Name" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Bus Start Time -->
            <div class="mb-3">
                <asp:Label runat="server" Text="Bus Start Time:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_start_time" TextMode="Time" ToolTip="Route Start Time" runat="server" CssClass="form-control" placeholder="Enter Start Time"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RRtime" runat="server" ForeColor="Red" ControlToValidate="txt_start_time" ErrorMessage="Please Enter Start Time" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Submit Button -->
            <div class="mb-3 text-center">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="ErrMsg" CssClass="btn btn-success btn-lg" />
            </div>
        </div>
    </div>

    <!-- Message Label -->
    <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="red" CssClass="d-block text-center mt-3"></asp:Label>

    <h2 class="text-center mt-5">Route Details</h2>

    <!-- Data Grid -->
    <div class="container">
        <asp:GridView runat="server" ID="grid_route" CellPadding="4" OnRowCommand="grid_route_RowCommand"
            ForeColor="#333333" GridLines="None" CssClass="table table-bordered table-striped text-center mt-4"
            Width="100%" DataKeyNames="route_id" AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="route_id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="route_name" HeaderText="Route Name" />
                <asp:BoundField DataField="route_start_time" HeaderText="Route Start Time" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center gap-2">
                            <asp:Button ID="btn_edit" CommandName="edit_data" runat="server" Text="Edit" CommandArgument='<%#Eval("route_id")%>' BackColor="blue" ForeColor="White" />
                            <asp:Button ID="btn_del" CommandName="delete_data" runat="server" Text="Delete"
                                CommandArgument='<%#Eval("route_id")%>' CausesValidation="false" BackColor="Red" ForeColor="White" />

                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
