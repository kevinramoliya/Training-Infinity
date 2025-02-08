<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="form_driver_master.aspx.cs" Inherits="Practise_project.Driver.form_driver_master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2 class="text-center mt-4 mb-4">Driver Registration Form</h2>

    <div class="container mt-5">
        <!-- Form Section with Border and Padding -->
        <div class="form-container" style="max-width: 600px; margin: auto;">
            
            <!-- Driver Name -->
            <div class="mb-3">
                <asp:Label Text="Driver Name:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_driver" ToolTip="Driver Name" runat="server" CssClass="form-control" placeholder="Enter Driver Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RDname" runat="server" ForeColor="Red" ControlToValidate="txt_driver" ErrorMessage="Please Enter Driver Name" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Driver Number -->
            <div class="mb-3">
                <asp:Label runat="server" Text="Driver Number:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_number" ToolTip="Driver Number" runat="server" CssClass="form-control" placeholder="Enter Driver Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RDnumber" runat="server" ForeColor="Red" ControlToValidate="txt_number" ErrorMessage="Please Enter Driver Number" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Submit Button -->
            <div class="mb-3 text-center">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="ErrMsg" CssClass="btn btn-success btn-lg" />
            </div>
        </div>
    </div>

    <!-- Message Label -->
    <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="red" CssClass="d-block text-center mt-3"></asp:Label>

    <h2 class="text-center mt-5">Driver Details</h2>

    <!-- Data Grid -->
    <div class="container">
        <asp:GridView runat="server" ID="grid_driver" OnRowCommand="grid_driver_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-bordered table-striped text-center mt-4"
            Width="100%" DataKeyNames="driver_id" AutoGenerateColumns="false">
            
            <Columns>
                <asp:BoundField DataField="driver_id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="driver_name" HeaderText="Driver Name" />
                <asp:BoundField DataField="driver_mobile_number" HeaderText="Driver Number" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center gap-2">
                            <asp:Button ID="btn_edit" CommandName="edit_data" runat="server" Text="Edit" CommandArgument='<%#Eval("driver_id")%>' BackColor="blue" ForeColor="White" />
                            <asp:Button ID="btn_del" CommandName="delete_data" runat="server" Text="Delete" CommandArgument='<%#Eval("driver_id")%>' BackColor="Red" ForeColor="White" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
