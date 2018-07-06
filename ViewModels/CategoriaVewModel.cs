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
            //FiltrarDatos(1, "Android");
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
            int count = 0, cantidad, numRegistros = 0, inicio = 0, regPorPagina = 5, cantidadPaginas, 
                paginas;
            string dataFilter = string.Empty, paginador = string.Empty, estado = null;

            List<object[]> data = new List<object[]>();
            IEnumerable<Categoria> query;
            var categoria = context.Categoria.OrderBy(c => c.Nombre.ToUpper().Trim()).ToList();
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

            foreach (var cat in query)
            {
                if (cat.Estado == true)
                {
                    estado = "<a class = 'btn  btn-info'>Activo</a>";
                }
                else
                {
                    estado = "<a class = 'btn btn-default'>No Activo</a>";

                }

                dataFilter += "<tr>" + 
                    
                    "<td>" + cat.Nombre      + "</td>" + 
                    "<td>" + cat.Descripcion + "</td>" + 
                    "<td>" + estado + " </td>"     + 
                    "<td>" + "<a data-toggle='modal' data-target='#myModal' class='btn btn-success'>Edit</a>|" +
                    "<a data-toggle='modal' data-target='#myModal3' class='btn btn-danger' >Delete</a>" + 
                    "</td>" + 
                    
                    "</tr>";
            }

            object[] dataObject = { dataFilter, paginador };
            data.Add(dataObject);
            return data;
        }

    }
}
