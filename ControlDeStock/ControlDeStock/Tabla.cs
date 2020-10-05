using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeStock
{
    public static class Tabla
    {
        public static StringBuilder CrearTabla(Producto producto)
        {
            StringBuilder Tabla = new StringBuilder();
            
            Tabla.Append($"| {"ID",10} | {"Nombre",20} | {"Categoria",10} | {"Precio",10} | {"Stock",10} | {"Vendidos",10} |\n");
            Tabla.Append($"| {producto.Id,10} | {producto.Nombre,20} | {producto.Categoria,10} | {producto.Precio,10} | {producto.Stock,10} | {producto.Vendidos,10} |\n");

            return Tabla;
        }

        public static StringBuilder TablaCompleta(List<Producto> productos)
        {
            StringBuilder Tabla2 = new StringBuilder();            
            Tabla2.Append($"| {"ID",10} | {"Nombre",20} | {"Categoria",10} | {"Precio",10} | {"Stock",10} | {"Vendidos",10} |\n");

            foreach (var producto in productos)
            {
                Tabla2.Append($"| {producto.Id,10} | {producto.Nombre,20} | {producto.Categoria,10} | {producto.Precio,10} | {producto.Stock,10} | {producto.Vendidos,10} |\n").ToString();
            }

            return Tabla2;
        }

    }
}
