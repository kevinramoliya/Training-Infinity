<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="form_student_master.aspx.cs" Inherits="Practise_project.Student.form_student_master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2 class="text-center ">Student Registration Form</h2>

    <div class="container mt-5">
        <!-- Form Section -->
        <div class="form-container" style="max-width: 700px; margin: auto;">

            <!-- Student Name -->
            <div class="mb-3">
                <asp:Label Text="Student Name:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Sname" runat="server" CssClass="form-control" placeholder="Enter Student Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RSname" runat="server" ForeColor="Red" ControlToValidate="Sname" ErrorMessage="Please Enter Student Name" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Email -->
            <div class="mb-3">
                <asp:Label Text="Email:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="SEmail" runat="server" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RSEmail" runat="server" ForeColor="Red" ControlToValidate="SEmail" ErrorMessage="Please Enter Email ID" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Address -->
            <div class="mb-3">
                <asp:Label Text="Address:" runat="server" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="SAddress" runat="server" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RSAddress" runat="server" ForeColor="Red" ControlToValidate="SAddress" ErrorMessage="Please Enter Address" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Gender -->
            

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Gender:" CssClass="form-label"></asp:Label>
                        <div class="form-check form-check-inline">
                            <asp:RadioButtonList ID="rblGender" RepeatDirection="Horizontal" runat="server" CssClass="form-check-input">
                                <asp:ListItem Text="Male" Value="1" Selected="True" />
                                <asp:ListItem Text="Female" Value="2" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
          

            <!-- City -->
            <div class="mb-3">
                <asp:Label runat="server" Text="City:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">Select City</asp:ListItem>
                    <asp:ListItem Value="Rajkot">Rajkot</asp:ListItem>
                    <asp:ListItem Value="Ahmedabad">Ahmedabad</asp:ListItem>
                    <asp:ListItem Value="Vadodara">Vadodara</asp:ListItem>
                    <asp:ListItem Value="Surat">Surat</asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Mobile Number -->
            <div class="mb-3">
                <asp:Label Text="Mobile Number:" runat="server" CssClass="form-label"></asp:Label>
                <div class="input-group">
                    <span class="input-group-text">+91</span>
                    <asp:TextBox ID="Mnumber" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RMnumber" runat="server" ForeColor="Red" ControlToValidate="Mnumber" ErrorMessage="Please Enter Mobile Number" ValidationGroup="ErrMsg" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Submit Button -->
            <div class="mb-3 text-center">
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="SubmitBtnClick" ValidationGroup="ErrMsg" CssClass="btn btn-success btn-lg px-4" />
            </div>
        </div>
    </div>

    <!-- Message Label -->
    <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="red" CssClass="d-block text-center mt-3"></asp:Label>

    <h2 class="text-center mt-5">Student Details</h2>

    <!-- Student Data Table -->
    <div class="container">
        <asp:GridView runat="server" ID="grid_stud" CellPadding="4" ForeColor="#333333" OnRowCommand="grid_stud_RowCommand" GridLines="None"
            CssClass="table table-striped table-bordered text-center mt-4" Width="100%" DataKeyNames="student_id" AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="student_id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="Student_name" HeaderText="Name" />
                <asp:BoundField DataField="Student_email" HeaderText="Email" />
                <asp:BoundField DataField="Student_address" HeaderText="Address" />
                <asp:BoundField DataField="Student_gender" HeaderText="Gender" />
                <asp:BoundField DataField="Student_city" HeaderText="City" />
                <asp:BoundField DataField="Student_mobile" HeaderText="Mobile" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center gap-2">
                            <asp:Button ID="btn_edit" CommandName="edit_data" runat="server" Text="Edit" CommandArgument='<%#Eval("student_id")%>' BackColor="blue" ForeColor="White"/>
                            <asp:Button ID="btn_del" CommandName="delete_data" runat="server" Text="Delete" CommandArgument='<%#Eval("student_id")%>' BackColor="red" ForeColor="White" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>