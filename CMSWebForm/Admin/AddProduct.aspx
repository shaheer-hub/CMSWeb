<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="CMSWebForm.Admin.AddProduct" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Product</h2>
    <div class="container">
        <div class="row addrow">
            <div class="col-md-6">
                <div class="form-group form-inline">
                    <asp:Label ID="Label1" runat="server" CssClass="labels" Text="Name:" meta:resourcekey="Label1Resource1"></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" meta:resourcekey="txtNameResource1"></asp:TextBox>
                </div>
                <div class="form-group form-inline">
                    <asp:Label ID="Label2" runat="server" CssClass="labels"  Text="Price:" meta:resourcekey="Label2Resource1"></asp:Label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" meta:resourcekey="txtPriceResource1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="Only Numbers allowed" ValidationExpression="^[+-]?(\d*\.)?\d+$" ControlToValidate="txtPrice" ForeColor="Red" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group form-inline">
                    <asp:Label ID="Label3" runat="server" CssClass="labels"  Text="Product Description:" meta:resourcekey="Label3Resource1"></asp:Label>
                    <asp:TextBox ID="txtPDescription" runat="server" TextMode="MultiLine" CssClass="form-control" meta:resourcekey="txtPDescriptionResource1"></asp:TextBox>
                </div>
                <div class="form-group form-inline">
                    <asp:Label ID="Label4" runat="server" CssClass="labels"  Text="Product Category:" meta:resourcekey="Label4Resource1"></asp:Label>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" meta:resourcekey="ddlCategoryResource1"></asp:DropDownList>
                </div>
                <div class="form-group form-inline">
                    <asp:Label ID="Label5" runat="server" CssClass="labels"  Text="Product Type:" meta:resourcekey="Label5Resource1"></asp:Label>
                    <asp:DropDownList ID="ddlProdType" runat="server" CssClass="form-control" meta:resourcekey="ddlProdTypeResource1"></asp:DropDownList>
                </div>
                <div class="form-group form-inline">
                    <asp:Label ID="Label6" runat="server" CssClass="labels"  Text="Select Image:" meta:resourcekey="Label6Resource1"></asp:Label>
                    <asp:FileUpload ID="imgUploader" CssClass="form-control" runat="server" meta:resourcekey="imgUploaderResource1" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                </div>
            </div>
        </div>
    </div>
    <asp:GridView ID="GVProducts" SkinID="SuiteSkin"  runat="server" AutoGenerateColumns=False meta:resourcekey="GVProductsResource1" OnPageIndexChanging="GVProducts_PageIndexChanging" AllowPaging="True" >
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" Text = '<%#Eval("ProdName") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
                <HeaderStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="Label2" Text='<%#Eval("ProdPrice") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
                <HeaderStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="Label3" Text='<%#Eval("ProdDescription") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30%" />
                <HeaderStyle Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="Label4" Text='<%#Eval("Category") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20%" />
                <HeaderStyle Width="20%" />
            </asp:TemplateField>
            

            <asp:TemplateField HeaderText="Product Type">
                <ItemTemplate>
                    <asp:Label ID="Label5" Text='<%#Eval("ProductType") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20%" />
                <HeaderStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Photo">
                <ItemTemplate>
                    <asp:Image ID="grdImg1" src='<%#Eval("Image") %>' runat="server"></asp:Image>
                    
                </ItemTemplate>
                <ItemStyle Width="40%" />
                <HeaderStyle Width="40%" />
            </asp:TemplateField>
            

        </Columns>
    </asp:GridView>
    <div class="paggingRow">
                            <div class="pagging-pageSize">
                                <asp:Label ID="lblPageSize" runat="server" Text="Page Size:" CssClass="page" meta:resourcekey="lblPageSizeResource1"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" CssClass="pagging-combobox" OnSelectedIndexChanged="ddlPageSize_OnSelectedIndexChanged" meta:resourcekey="ddlPageSizeResource1">
                                    <asp:ListItem Text="5" Value="5" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="40" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="pagging-pageButtons">
                                <asp:ImageButton ID="imgBtnFirst" runat="server" ImageUrl="~/images/layout/First.png" CssClass="pagging-buttons" OnClick="imgBtnFirst_OnClick" ToolTip="First" meta:resourcekey="imgBtnFirstResource1" />

                                <asp:ImageButton ID="imgBtnPrevious" runat="server" ImageUrl="~/images/layout/Previous.png" CssClass="pagging-buttons" OnClick="imgBtnPrevious_OnClick" ToolTip="Previous" meta:resourcekey="imgBtnPreviousResource1" />

                                <asp:ImageButton ID="imgBtnNext" runat="server" ImageUrl="~/images/layout/Next.png" CssClass="pagging-buttons" OnClick="imgBtnNext_OnClick" ToolTip="Next" meta:resourcekey="imgBtnNextResource1" />

                                <asp:ImageButton ID="imgBtnLast" runat="server" ImageUrl="~/images/layout/Last.png" CssClass="pagging-buttons" OnClick="imgBtnLast_OnClick" ToolTip="Last" meta:resourcekey="imgBtnLastResource1" />
                            </div>
                            <div class="pagging-pageNumber">
                                <asp:DropDownList ID="cmbNumberOfPages" runat="server" AutoPostBack="True" CssClass="pagging-combobox" OnSelectedIndexChanged="cmbNumberOfPages_OnSelectedIndexChanged" meta:resourcekey="cmbNumberOfPagesResource1" />
                            </div>
                        </div>

                   

   
</asp:Content>
