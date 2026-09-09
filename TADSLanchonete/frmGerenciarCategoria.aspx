<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGerenciarCategoria.aspx.cs" Inherits="TADSLanchonete.frmGerenciarCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <header>
        <a href="Default.aspx">Início</a>

        <h1>Gerenciar Categorias</h1>
    </header>

    <main>
        <h2>Cadastrar Categoria</h2>
        <form id="form1" runat="server">
            <p>
                <input
                    type="text"
                    id="txtNomeCategoria"
                    placeholder="Nome Categoria"
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
                <a href="~/frmGerenciarCategoria.aspx" runat="server" id="btnLinkCadastra" visible="false">Cadastrar Categoria</a>
            </p>
            <p>
                <p id="Mensagem" runat="server"></p>
            </p>
            <table border="1">
                <head>
                    <tr>
                        <td>Código</td>
                        <td>Descrição</td>
                        <td>Ações</td>
                    </tr>
                </head>
                <p>
                    <asp:ListView runat="server" ID="lvCategorias" OnItemCommand="lvCategorias_ItemCommand">
                        <EmptyItemTemplate>
                            <p>Não existem categorias cadastradas!</p>
                        </EmptyItemTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("IdCategoria") %>
                                </td>
                                <td>
                                    <%# Eval("NomeCategoria") %>
                                </td>
                                <td>
                                    <asp:ImageButton
                                        ImageUrl="~/img/visualizar.png"
                                        runat="server"
                                        CommandName="Visualizar"
                                        CommandArgument='<%# Eval("IdCategoria") %>' />
                                    <asp:ImageButton
                                        ImageUrl="~/img/editar.png"
                                        runat="server"
                                        CommandName="Editar"
                                        CommandArgument='<%# Eval("IdCategoria") %>' />
                                    <asp:ImageButton
                                        ImageUrl="~/img/Excluir.png"
                                        runat="server"
                                        CommandName="Excluir"
                                        CommandArgument='<%# Eval("IdCategoria") %>'
                                        OnClientClick="return confirm('Deseja realmente excluir esse ingrediente?')" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </p>
            </table>
        </form>
    </main>

    <footer></footer>
</body>
</html>
