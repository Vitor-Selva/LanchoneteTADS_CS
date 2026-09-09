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

                string qs = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(qs))
                {
                    int id = int.Parse(qs);
                    Categoria categoria = CategoriaDAO.Listar(id);
                    if (categoria != null)
                    {
                        bool visualizar = false;
                        ModificarFormularioParaVisualizar(categoria, visualizar);
                        EditarFormulario(categoria);
                    }
                }
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
                bool editando = false;
                if (string.IsNullOrEmpty(nomeCategoria))
                {
                    Mensagem.InnerText = "O campo Nome Categoria precisa ser preechido";
                    return;
                }

                Categoria categoria = null;

                if (ViewState["IdCategoria"] == null)
                {
                    // Estou cadastrando uma nova categoria
                    categoria = new Categoria();
                }
                else
                {
                    // Estou editando uma categoria existente
                    int idCategoria = (int)ViewState["IdCategoria"];
                    categoria = CategoriaDAO.Listar(idCategoria);
                    editando = true;
                }
                categoria.NomeCategoria = nomeCategoria;

                if (!editando)
                {
                    Mensagem.InnerText =
                        CategoriaDAO.Casdastrar(categoria);
                }
                else
                {
                    Mensagem.InnerText = CategoriaDAO.Editar(categoria);
                    btnConfirmar.Text = "Cadastrar";
                    ViewState["IdCategoria"] = null;
                }
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
                else if (comando == "Visualizar")
                {
                    Categoria categoria = CategoriaDAO.Listar(id);

                    bool visualizar = true;
                    ModificarFormularioParaVisualizar(categoria, visualizar);
                }
                else if (comando == "Editar")
                {
                    //Categoria categoria = CategoriaDAO.Listar(id);
                    //bool visualizar = false;
                    //ModificarFormularioParaVisualizar(categoria, visualizar);

                    //EditarFormulario(categoria);

                    string url = "~/frmGerenciarCategoria.aspx?id=" + id;

                    Response.Redirect(url);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void EditarFormulario(Categoria categoria)
        {
            // Personalizando Botão
            btnConfirmar.Text = "Alterar";
            //btnConfirmar.Click -= btnConfirmar_Click;
            //btnConfirmar.Click += btnEditar_Click; NÃO DEU CERTO ASSIM

            ViewState["IdCategoria"] = categoria.IdCategoria;
            Mensagem.InnerText = "";
        }

        private void ModificarFormularioParaVisualizar(Categoria categoria, bool visualizar)
        {
            if (visualizar)
            {
                txtNomeCategoria.Disabled = true;
                btnConfirmar.Enabled = false;
                btnLinkCadastra.Visible = true;
            }
            txtNomeCategoria.Value = categoria.NomeCategoria;
        }
    }

}