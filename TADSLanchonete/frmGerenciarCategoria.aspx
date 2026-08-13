<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGerenciarCategoria.aspx.cs" Inherits="TADSLanchonete.frmGerenciarCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                    runat="server"
                    required
                />
            </p>
            <p>
                <asp:Button 
                    ID="btnConfirmar"   
                    Text="Cadastrar"
                    runat="server"
                    onclick="btnConfirmar_Click"
                 />
            </p>
            <p>
                <p id="Mensagem" runat="server"></p>
            </p>
        </form>
    </main>

    <footer></footer>
</body>
</html>
