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

        }

        protected void btnConfirmar_Click(
            object sender, EventArgs e)
        {
            try
            {
                string nomeIngrediente = txtNomeIngrediente.Value;
                if(string.IsNullOrEmpty(nomeIngrediente))
                {
                    Mensagem.InnerText = "O campo Nome Ingrediente precisa ser preechido";
                    return;
                }
                var ingrediente = new Ingrediente();
                ingrediente.NomeIngrediente = nomeIngrediente;
                Mensagem.InnerText = 
                    IngredienteDAO.Casdastrar(ingrediente);
                txtNomeIngrediente.Value = "";
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocurreu um erro: " + 
                        ex.Message;
            }
        }
    }
}