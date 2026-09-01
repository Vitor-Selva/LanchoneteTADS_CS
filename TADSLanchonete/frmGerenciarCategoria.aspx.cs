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
            if (!IsPostBack)
            {
                AtualizarListViewCategorias();
            }
        }

        private void AtualizarListViewCategorias()
        {
            List<Categoria> categorias =
                CategoriaDAO.Listar();
            PopularLvCategorias(categorias);
        }

        private void PopularLvCategorias(List<Categoria> categorias)
        {
            lvCategorias.DataSource = categorias;
            lvCategorias.DataBind();
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
                AtualizarListViewCategorias();
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocurreu um erro: " +
                        ex.Message;
            }
        }

        protected void lvCategorias_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                int id = int.Parse(e.CommandArgument.ToString());
                if (id == null) { return; }
                string comando = e.CommandName;

                if (comando == "Excluir")
                {
                    string mensagem = CategoriaDAO.Excluir(id);
                    Mensagem.InnerText = mensagem;
                    AtualizarListViewCategorias();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}