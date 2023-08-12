<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="adminbookissuing.aspx.cs" Inherits="WebApplication3.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("< thead ></thead > ").append($(this).find("tr: first"))).dataTable();
       });


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
		<div class="row">
			<div class="col-md-4">
				<div class="card">
					<div class="card-body">
						<div class="row">
							<div class="col">
								<center>
									<h4>Book Issuing</h4>
								</center>
							</div>
						</div>
						<div class="row">
							<div class="col">
								<center>
									<img width="100px" src="imgs/books.png" />
								</center>
							</div>
						</div>
						<div class="row">
							<div class="col">
								<hr>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<label>Member ID</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<label>Book ID</label>
									<div class="input-group">
										<asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
										<asp:Button for="TextBox1" class="btn btn-dark" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<label>Member Name</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<label>Book Name</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<label>Issue Date</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<label>Due Date</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								
								<div class="col-6">
									<asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Issue" OnClick="Button2_Click" />
								</div>
								<div class="col-6">
									<asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Return" OnClick="Button4_Click" />
								</div>
								
								
							</div>
						</div>
					</div>
					<a href="homepage.aspx"><< Back to Home
					</a>
					<br>
						<br>
						</div>
            <div class="col-md-8">
                <div class="card">
					<div class="card-body">
			 <%--<asp:SqlDataSource ID="SqlDataSourceDescription" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:TESTDB10ConnectionString %>"
                    ProviderName="System.Data.SqlClient"  ></asp:SqlDataSource>--%>
			
			 
		<%--	 <div class="row" style="padding-bottom:1%">
              <center>
              
                  </center>
          </div>
                         --%>
                         <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Issue List</h4>
                        </center>
                     </div>
                  </div>
                         
			 <asp:Panel ID ="panel1" runat="server" width="100%" Visible="true">
           <div class="table table-striped table-bordered" style="background-color:white;border-radius:25px 25px 25px 25px" >
              
               <br>
    
               <div class="table-responsive" >
                <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false"  CssClass="table table-striped table-bordered table-hover Grid" Style="border-color:black"  EmptyDataText="There are no data records to display."
                         DataSourceID="SqlDataSource1" AllowPaging="true" OnRowCommand="GridViewBookTitledetails_RowCommand" OnPageIndexChanging="GridViewBookTitledetails_PageIndexChanging"  BorderColor="Black" GridLines="Both" BorderStyle="Solid" 
                    PageSize="10" PagerSettings-PageButtonCount="5" OnRowEditing="GridViewBookTitledetails_RowEditing" OnDataBound="GridViewBookTitledetails_DataBound" >  
                <PagerStyle CssClass="GridPager" />
                            
                    <Columns>  
                               
                                <asp:TemplateField HeaderText="Member Id">                 
                                   <ItemTemplate>
                                   <asp:Label ID="lblMember_id" runat="server" Text='<%# Eval("member_id") %>' Style="word-wrap: break-word"></asp:Label> 
              
                                   </ItemTemplate>
                                     <EditItemTemplate>
                           <asp:Textbox ID="TextBox2" CssClass="form-control"  runat="server" Text='<%# Bind("member_id")%>' Width ="100%" />            
                    </EditItemTemplate> 
                                </asp:TemplateField>    
                         <asp:TemplateField HeaderText="Member Name">                 
                                   <ItemTemplate>
                                   <asp:Label ID="lblmember_name" runat="server" Text='<%# Eval("member_name") %>' Style="word-wrap: break-word"></asp:Label> 
              
                                   </ItemTemplate>
                                     <EditItemTemplate>
                           <asp:Textbox ID="TextBox3" CssClass="form-control"  runat="server" Text='<%# Bind("member_name")%>' Width ="100%" />            
                    </EditItemTemplate> 
                                </asp:TemplateField>
                           <asp:TemplateField HeaderText="Book Id">                 
                                   <ItemTemplate>
                                   <asp:Label ID="lblbook_id" runat="server" Text='<%# Eval("book_id") %>' Style="word-wrap: break-word"></asp:Label> 
              
                                   </ItemTemplate>
                                     <EditItemTemplate>
                           <asp:Textbox ID="TextBox1" CssClass="form-control"  runat="server" Text='<%# Bind("book_id")%>' Width ="100%" />            
                    </EditItemTemplate> 
                                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Book Name">                 
                                   <ItemTemplate>
                                   <asp:Label ID="lblbook_name" runat="server" Text='<%# Eval("book_name") %>' Style="word-wrap: break-word"></asp:Label> 
              
                                   </ItemTemplate>
                                     <EditItemTemplate>
                           <asp:Textbox ID="TextBox4" CssClass="form-control"  runat="server" Text='<%# Bind("book_name")%>' Width ="100%" />            
                    </EditItemTemplate> 
                                </asp:TemplateField>
                         <asp:TemplateField HeaderText="Issue Date">                 
                                   <ItemTemplate>
                                   <asp:Label ID="lblissue_date" runat="server" Text='<%# Eval("issue_date") %>' Style="word-wrap: break-word"></asp:Label> 
              
                                   </ItemTemplate>
                                     <EditItemTemplate>
                           <asp:Textbox ID="TextBox5" CssClass="form-control"  runat="server" Text='<%# Bind("issue_date")%>' Width ="100%" TextMode="Date"/>            
                    </EditItemTemplate> 
                                </asp:TemplateField>
                         <asp:TemplateField HeaderText="Due Date">                 
                                   <ItemTemplate>
                                   <asp:Label ID="lbldue_date" runat="server" Text='<%# Eval("due_date") %>' Style="word-wrap: break-word"></asp:Label> 
              
                                   </ItemTemplate>
                                     <EditItemTemplate>
                           <asp:Textbox ID="TextBox6" CssClass="form-control"  runat="server" Text='<%# Bind("due_date")%>' Width ="100%" TextMode="Date"/>            
                    </EditItemTemplate> 
                                </asp:TemplateField>
  
                               

                         
                         <asp:TemplateField HeaderText="Edit" > 
            <ItemTemplate>
               <asp:LinkButton ID="lnkupdate" runat="server" Text="Edit" CommandName="Edit" ForeColor="Blue" ></asp:LinkButton>
            </ItemTemplate>   
                                    <EditItemTemplate>  
                  
                         <asp:LinkButton ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" ForeColor="Blue"></asp:LinkButton>
                 
                         <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" ForeColor="Blue"></asp:LinkButton>
                         
                    </EditItemTemplate>  
          </asp:TemplateField>     
                               </Columns>
                <PagerStyle ForeColor="#0000ff" HorizontalAlign="Center" />

                               </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TESTDB10ConnectionString %>" SelectCommand="SELECT member_id,member_name,book_id,book_name,issue_date,due_date from book_issue_tbl" SelectCommandType="Text">  
                                                                   
                             </asp:SqlDataSource>
                   </div>
               
              
               
               </div>

			 </asp:Panel>
                            
                </div>
             </div>
                 </div>
              
             
              
						</div>
				</asp:Content>
