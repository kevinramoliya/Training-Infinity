<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="form_bus_master.aspx.cs" Inherits="Practise_project.Bus.form_bus_master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2 class="text-center mt-4 mb-4">Bus Registration Form</h2>

    <div class="container">
        <div class="form-container">
            <!-- Bus Name -->
            <div class="mb-3">
                <asp:Label Text="Bus Name:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="b_name" ToolTip="Enter Bus Name" runat="server" CssClass="form-control" placeholder="Enter Bus Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RBname" runat="server" ForeColor="Red" ControlToValidate="b_name" ErrorMessage="Please enter bus name" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Bus Number -->
            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="Bus Number:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="b_number" ToolTip="Enter Bus Number" runat="server" CssClass="form-control" placeholder="Enter Bus Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RBnumber" runat="server" ForeColor="Red" ControlToValidate="b_number" ErrorMessage="Please enter bus number" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Submit Button -->
            <div class="text-center">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="ErrMsg" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>

    <!-- Message Label -->
    <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="red" CssClass="d-block text-center mt-3"></asp:Label>

    <h2 class="text-center mt-4">Bus Details</h2>

    <div class="container mt-3">
        <asp:GridView runat="server" ID="grid_bus" CssClass="table result-table text-center" CellPadding="4" ForeColor="#333333" OnRowCommand="grid_bus_RowCommand" GridLines="None" Width="100%" DataKeyNames="bus_id" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="bus_id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="bus_name" HeaderText="Bus Name" />
                <asp:BoundField DataField="bus_number" HeaderText="Bus Number" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center gap-2">
                            <asp:Button ID="btn_edit" CommandName="edit_data" runat="server" Text="Edit" CommandArgument='<%#Eval("bus_id")%>' BackColor="blue" ForeColor="White" />
                            <asp:Button ID="btn_del" CommandName="delete_data" runat="server" Text="Delete" CommandArgument='<%#Eval("bus_id")%>' BackColor="red" ForeColor="White" OnClientClick="return confirm('Are you sure you want to delete this bus?');" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
