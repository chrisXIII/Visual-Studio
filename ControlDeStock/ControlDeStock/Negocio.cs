using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class Negocio
    {
        

        static List<Producto> Productos;
        static List<Categoria> Categorias;
        
        static Negocio()
        {
            Productos = new List<Producto>();
            Categorias = new List<Categoria>();
            
        }

        public static List<Categoria> CargarCategorias()
        {
            Categorias.Add(new Categoria("Electricidad",0));
            Categorias.Add(new Categoria("Construccion",1));
            Categorias.Add(new Categoria("Plomeria",2));
            Categorias.Add(new Categoria("Herramientas",3));
            return Categorias;
        }
                                                                 
                                                                 

        public static List<Producto> CargaProductos()
        {
            Producto producto1 = new Producto();
            producto1.Nombre = "Ladrillo";
            producto1.Categoria = 1;
            producto1.Id = 12;
            producto1.Precio = 80;
            producto1.Stock = 120;
            producto1.Vendidos = 50;
            Productos.Add(producto1);

            Producto producto2 = new Producto();
            producto2.Nombre = "Destornillador";
            producto2.Categoria = 3;
            producto2.Id = 15;
            producto2.Precio = 95;
            producto2.Stock = 124;
            producto2.Vendidos = 13;
            Productos.Add(producto2);

            Producto producto3 = new Producto();
            producto3.Nombre = "Bombillas";
            producto3.Categoria = 0;
            producto3.Id = 4;
            producto3.Precio = 20;
            producto3.Stock = 300;
            producto3.Vendidos = 100;
            Productos.Add(producto3);

            Producto producto4 = new Producto();
            producto4.Nombre = "Caños de agua";
            producto4.Categoria = 2;
            producto4.Id = 1;
            producto4.Precio = 100;
            producto4.Stock = 0;
            producto4.Vendidos = 500;
            Productos.Add(producto4);

            Producto producto5 = new Producto();
            producto5.Nombre = "Pinza";
            producto5.Categoria = 3;
            producto5.Id = 9;
            producto5.Precio = 135;
            producto5.Stock = 80;
            producto5.Vendidos = 25;
            Productos.Add(producto5);

            Producto producto6 = new Producto();
            producto6.Nombre = "Flexible caño";
            producto6.Categoria = 2;
            producto6.Id = 10;
            producto6.Precio = 100;
            producto6.Stock = 5;
            producto6.Vendidos = 495;
            Productos.Add(producto6);

            Producto producto7 = new Producto();
            producto7.Nombre = "Canillas";
            producto7.Categoria = 2;
            producto7.Id = 11;
            producto7.Precio = 45;
            producto7.Stock = 15;
            producto7.Vendidos = 1200;
            Productos.Add(producto7);

            Producto producto8 = new Producto();
            producto8.Nombre = "Bolsa Arena";
            producto8.Categoria = 1;
            producto8.Id = 90;
            producto8.Precio = 60;
            producto8.Stock = 45;
            producto8.Vendidos = 1500;
            Productos.Add(producto8);

            Producto producto9 = new Producto();
            producto9.Nombre = "Martillo";
            producto9.Categoria = 3;
            producto9.Id = 31;
            producto9.Precio = 120;
            producto9.Stock = 150;
            producto9.Vendidos = 95;
            Productos.Add(producto9);

            Producto producto10 = new Producto();
            producto10.Nombre = "Cable";
            producto10.Categoria = 0;
            producto10.Id = 7;
            producto10.Precio = 50;
            producto10.Stock = 98;
            producto10.Vendidos = 30;
            Productos.Add(producto10);
            
          

            return Productos;
        }

        
    }
}
