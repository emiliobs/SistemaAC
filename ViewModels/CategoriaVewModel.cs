using Microsoft.AspNetCore.Identity;
using SistemaAC.Data;
using SistemaAC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.ViewModels
{
    public class CategoriaVewModel
    {
        ApplicationDbContext context;
        public CategoriaVewModel(ApplicationDbContext context)
        {
            this.context = context;
            FiltrarDatos(1, "Android");
        }


        public List<IdentityError> GuardarCategoria(string nombre, string descripcion,
                                                             string estado)
        {
            var erroList = new List<IdentityError>();
            var categoria = new Categoria()
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Estado =  Convert.ToBoolean(estado),
            };

            context.Add(categoria);

             context.SaveChanges();

            erroList.Add(new IdentityError {

                Code = "Save",
                Description = "Save",
            });

            return erroList;
        }

        public List<object[]> FiltrarDatos(int numPagina, string valor)
        {
            int count = 0, cantidad, numRegistros = 0, inicio = 0, regPorPagina = 1, cantidadPaginas, 
                paginas;
            string dataFilter = string.Empty, paginador = string.Empty, estado = null;

            List<object[]> data = new List<object[]>();
            IEnumerable<Categoria> query;
            var categoria = context.Categoria.OrderBy(c => c.Nombre).ToList();
            numRegistros = categoria.Count;
            inicio = (numPagina - 1) * regPorPagina;
            cantidadPaginas = (numRegistros / regPorPagina);

            if (valor == "null")
            {
                query = categoria.Skip(inicio).Take(regPorPagina);
            }
            else
            {
                query = categoria.Where(c => c.Nombre.StartsWith(valor) ||  c.Descripcion.StartsWith(valor))
                       .Skip(inicio).Take(regPorPagina);
            }

            cantidad = query.Count();

            return data;
        }

    }
}
