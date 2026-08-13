using System;
using System.Web.Services.Description;

namespace TADSLanchonete
{
    internal class CategoriaDAO
    {
        internal static string Casdastrar(Categoria categoria)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    ctx.Categorias.Add(categoria);
                    ctx.SaveChanges();
                    mensagem = "A Categoria "
                        + categoria.NomeCategoria
                        + " foi cadastrado com sucesso";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }
            return mensagem;
        }
    }
}