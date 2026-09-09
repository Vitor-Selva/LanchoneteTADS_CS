<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGerenciarIngredientes.aspx.cs" Inherits="TADSLanchonete.frmGerenciarIngredientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <header>
        <a href="Default.aspx">Início</a>

        <h1>Gerenciar Ingredientes</h1>
    </header>

    <main>
        <h2>Cadastrar Ingrediente</h2>
        <form id="form1" runat="server">
            <p>
                <input
                    type="text"
                    id="txtNomeIngrediente"
                    placeholder="Nome Ingrediente"
                    runat="server" />
            </p>
            <p>
                <asp:Button
                    ID="btnConfirmar"
                    Text="Cadastrar"
                    runat="server"
                    OnClick="btnConfirmar_Click" />
            </p>
            <p>
                <a href="~/frmGerenciarIngredientes.aspx" runat="server" id="btnLinkCadastra" visible="false">Cadastrar Ingrediente</a>
            </p>
            <p>
                <p id="Mensagem" runat="server"></p>
            </p>

            <p>
                <%--Mostrar dados cadastrados--%>
                <table border="1">
                    <head>
                        <tr>
                            <td>Código</td>
                            <td>Descrição</td>
                            <td>Ações</td>
                        </tr>
                    </head>
                    <asp:ListView runat="server" ID="lvIngredientes" OnItemCommand="lvIngredientes_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("IdIngrediente") %>
                                </td>
                                <td>
                                    <%# Eval("NomeIngrediente") %>
                                </td>
                                <td>
                                    <asp:ImageButton
                                        ImageUrl="~/img/visualizar.png"
                                        runat="server"
                                        CommandName="Visualizar"
                                        CommandArgument='<%# Eval("IdIngrediente") %>' />
                                    <asp:ImageButton
                                        ImageUrl="~/img/editar.png"
                                        runat="server" />
                                    <asp:ImageButton ImageUrl="~/img/excluir.png"
                                        runat="server"
                                        CommandName="Excluir"
                                        CommandArgument='<%# Eval("IdIngrediente") %>'
                                        OnClientClick="return confirm('Deseja realmente excluir essa Categoria?')" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </p>

        </form>
    </main>

    <footer></footer>
</body>
</html>
