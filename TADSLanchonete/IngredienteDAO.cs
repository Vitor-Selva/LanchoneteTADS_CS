using System;

namespace TADSLanchonete
{
    internal class IngredienteDAO
    {
        internal static string Casdastrar(Ingrediente ingrediente)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    ctx.Ingredientes.Add(ingrediente);
                    ctx.SaveChanges();
                    mensagem = "O ingrediente " 
                        + ingrediente.NomeIngrediente
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