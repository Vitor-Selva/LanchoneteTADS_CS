using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TADSLanchonete
{
    public partial class frmGerenciarIngredientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarListViewIngrediente();
            }
        }

        private void PopularLvIngredientes(List<Ingrediente> ingredientes)
        {
            if (ingredientes == null) { return; }

            lvIngredientes.DataSource = ingredientes;
            lvIngredientes.DataBind(); // Renderiza os elementos na tela
        }

        protected void btnConfirmar_Click(
            object sender, EventArgs e)
        {
            try
            {
                string nomeIngrediente = txtNomeIngrediente.Value;
                if (string.IsNullOrEmpty(nomeIngrediente))
                {
                    Mensagem.InnerText = "O campo Nome Ingrediente precisa ser preechido";
                    return;
                }
                var ingrediente = new Ingrediente();
                ingrediente.NomeIngrediente = nomeIngrediente;
                Mensagem.InnerText =
                    IngredienteDAO.Casdastrar(ingrediente);
                txtNomeIngrediente.Value = "";

                AtualizarListViewIngrediente();
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocurreu um erro: " + 
                        ex.Message;
            }
        }

        private void AtualizarListViewIngrediente()
        {
            List<Ingrediente> ingredientes =
                IngredienteDAO.Listar();
            PopularLvIngredientes(ingredientes);
        }

        protected void lvIngredientes_ItemCommand(
            object sender, 
            ListViewCommandEventArgs e
        )
        {
            try
            {
                int id = int.Parse(e.CommandArgument.ToString());
                if ( id == null ) { return; }
                string comando = e.CommandName;

                if(comando == "Excluir")
                {
                    string mensagem = IngredienteDAO.Excluir(id);
                    Mensagem.InnerText = mensagem;
                    AtualizarListViewIngrediente();
                } else if(comando == "Visualizar")
                {
                    Ingrediente ingrediente = IngredienteDAO.Listar(id);
                    ModificarFormularioParaVisualizar(ingrediente);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ModificarFormularioParaVisualizar(Ingrediente ingrediente)
        {
            txtNomeIngrediente.Disabled = false;
            btnConfirmar.Enabled = false;
            btnLinkCadastra.Visible = true;
            txtNomeIngrediente.Value = ingrediente.NomeIngrediente;
        }
    }
}