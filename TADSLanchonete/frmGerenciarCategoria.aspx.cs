using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TADSLanchonete
{
    public partial class frmGerenciarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeCategoria = txtNomeCategoria.Value;
                if (string.IsNullOrEmpty(nomeCategoria))
                {
                    Mensagem.InnerText = "O campo Nome Categoria precisa ser preechido";
                    return;
                }
                var categoria = new Categoria();
                categoria.NomeCategoria = nomeCategoria;
                Mensagem.InnerText =
                    CategoriaDAO.Casdastrar(categoria);
                txtNomeCategoria.Value = "";
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocurreu um erro: " +
                        ex.Message;
            }
        }
    }
}