<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="form_stop_master.aspx.cs" Inherits="Practise_project.Stop.form_stop_master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2 class="text-center mt-4 mb-4">Stop Registration Form</h2>

    <div class="container mt-5">
        <!-- Form Section -->
        <div class="form-container" style="max-width: 600px; margin: auto;">
            
            <!-- Stop Name -->
            <div class="mb-3">
                <asp:Label Text="Stop Name:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_stop" ToolTip="Stop Name" runat="server" CssClass="form-control" placeholder="Enter Stop Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RSname" runat="server" ForeColor="Red" ControlToValidate="txt_stop" ErrorMessage="Please Enter Stop Name" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Submit Button -->
            <div class="mb-3 text-center">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="ErrMsg" CssClass="btn btn-success btn-lg" />
            </div>
        </div>
    </div>

    <!-- Message Label -->
    <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="red" CssClass="d-block text-center mt-3"></asp:Label>

    <h2 class="text-center mt-5">Stop Details</h2>

    <!-- Data Grid -->
    <div class="container">
        <asp:GridView runat="server" ID="grid_stop" OnRowCommand="grid_stop_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None"
            CssClass="table table-bordered table-striped text-center mt-4" Width="100%" DataKeyNames="Stop_id" AutoGenerateColumns="false">
            
            <Columns>
                <asp:BoundField DataField="stop_id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="stop_name" HeaderText="Stop Name" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center gap-2">
                            <asp:Button ID="btn_edit" CommandName="edit_data" runat="server" Text="Edit" CommandArgument='<%#Eval("stop_id")%>' BackColor="blue" ForeColor="White" />
                            <asp:Button ID="btn_del" CommandName="delete_data" runat="server" Text="Delete" CommandArgument='<%#Eval("stop_id")%>' BackColor="Red" ForeColor="White" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
