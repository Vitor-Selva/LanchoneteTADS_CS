using System;
using System.Collections.Generic;
using System.Linq;
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

        internal static string Editar(Categoria categoria)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    Categoria categoriaVelha = ctx.Categorias.FirstOrDefault(c => c.IdCategoria == categoria.IdCategoria);

                    categoriaVelha.NomeCategoria = categoria.NomeCategoria;

                    ctx.SaveChanges();
                    mensagem = "A Categoria "
                        + categoriaVelha.NomeCategoria
                        + " foi alterada com sucesso";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static string Excluir(int id)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    Categoria categoria = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
                    ctx.Categorias.Remove(categoria);
                    ctx.SaveChanges();

                    mensagem = "A categoria " + categoria.NomeCategoria +
                        " foi removida com suuuuuucessso!!";
                }
            }
            catch (Exception ex)
            {

                mensagem = ex.Message;
            }
            return mensagem;

        }

        internal static List<Categoria> Listar()
        {
            List<Categoria> categorias = null;

            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    categorias = ctx.Categorias
                        .OrderBy(x => x.NomeCategoria).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return categorias;
        }

        internal static Categoria Listar(int id)
        {
            Categoria categoria = null;

            using (var ctx = new LanchoneteDBEntities())
            {
                categoria = ctx.Categorias.FirstOrDefault(
                  c => c.IdCategoria.Equals(id)
                );

                // LINQ TO ENTITIES
            }

            return categoria;
        }
    }
}