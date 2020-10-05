using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class Menu
    {

        public static StringBuilder CrearMenuPrincipal()
        {
            StringBuilder Menu = new StringBuilder();

            Menu.Append("Control de Stock\n");
            Menu.Append("1)Mostrar Productos\n");
            Menu.Append("2)Buscar Productos\n");
            Menu.Append("3)Agregar Nuevo Producto\n");
            Menu.Append("4)Modificar Producto\n");
            Menu.Append("5)Eliminar Producto Del Sistema\n");
            Menu.Append("6)Facturacion\n");
            Menu.Append("7)Salir\n");

            return Menu;
        }

        public static StringBuilder CrearSubMenuMostrar()
        {
            StringBuilder SubMenuMostrar = new StringBuilder();

            SubMenuMostrar.Append("1)Mostrar Todos\n");
            SubMenuMostrar.Append("2)Mostrar Segun Categoria\n");
            SubMenuMostrar.Append("3)Mostrar Segun Stock\n");
            SubMenuMostrar.Append("4)Producto Mas Vendido\n");
            SubMenuMostrar.Append("5)Producto Mas Caro\n");
            SubMenuMostrar.Append("6)Atras\n");

            return SubMenuMostrar;
        }

        public static StringBuilder CrearSubMenuBuscar()
        {
            StringBuilder SubMenuBuscar = new StringBuilder();

            SubMenuBuscar.Append("1)Buscar Producto Por Nombre\n");
            SubMenuBuscar.Append("2)Buscar Producto Por ID\n");
            SubMenuBuscar.Append("3)Atras\n");
            return SubMenuBuscar;
        }

        public static StringBuilder CrearSubMenuFacturacion()
        {
            StringBuilder SubMenuFacturacion = new StringBuilder();
            SubMenuFacturacion.Append("1)Mostrar Producto Que Mas Facturo\n");
            SubMenuFacturacion.Append("2)Mostrar Facturacion Por Producto Ordenado De Menor a Mayor\n");
            SubMenuFacturacion.Append("3)Mostrar Toda La Informacion De Facturacion\n");
            SubMenuFacturacion.Append("4)Atras\n");
            return SubMenuFacturacion;
        }

        public static StringBuilder SubMenuBuscarPorStock()
        {
            StringBuilder SubMenuFacturacion = new StringBuilder();
            SubMenuFacturacion.Append("1)Sin Stock\n");
            SubMenuFacturacion.Append("2)Con Stock pero menor a 100 unidades\n");
            SubMenuFacturacion.Append("3)Con Stock pero mayor a 100 unidades\n");
            return SubMenuFacturacion;
        }

        

    }
}
