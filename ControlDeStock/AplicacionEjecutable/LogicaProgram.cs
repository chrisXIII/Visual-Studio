using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Clases;
using ControlDeStock;

namespace AplicacionEjecutable
{
    class LogicaProgram
    {
        private List<Categoria> Categorias = Negocio.CargarCategorias();
        private List<Producto> Productos = Negocio.CargaProductos();

        /// <summary>
        /// Inicia El Programa
        /// </summary>
        public void IniciarPrograma()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(Menu.CrearMenuPrincipal().ToString());
                Console.WriteLine("\nElegir Una Opcion");
                opcion = int.Parse(Console.ReadLine());            
                switch (opcion)
                {
                    case 1:
                        
                        MenuMostrarProductos();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(Menu.CrearSubMenuBuscar().ToString());
                        Console.WriteLine("Elegir una Opcion:");
                        int opcionBuscar = int.Parse(Console.ReadLine());
                        if (opcionBuscar == 1)
                        {
                            Console.WriteLine("Ingresar Nombre Del Producto");
                            string nombreProducto = Console.ReadLine();
                            Console.WriteLine(Tabla.CrearTabla(BuscarProducto(Productos,nombreProducto)).ToString());
                        }
                        else if(opcionBuscar == 2)
                        {
                            Console.WriteLine("Ingresar ID Del Producto");
                            int iDProducto = int.Parse(Console.ReadLine());                          
                            Console.WriteLine(Tabla.CrearTabla(BuscarProducto(Productos, iDProducto)).ToString());
                        }
                        else if (opcionBuscar == 3)
                        {

                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("1)Ingresar Nuevo Producto\n2)Salir");
                        int opcionCrear = int.Parse(Console.ReadLine());
                        if (opcionCrear == 1)
                        {
                            AgregarProducto(Productos);
                        }
                        else if (opcionCrear == 2)
                        {

                        }
                      
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("1)Ingresar Nombre Del Producto a Modificar\n2)Salir");
                        int opcionModificar = int.Parse(Console.ReadLine());
                        if (opcionModificar == 1)
                        {
                            string nombre = Console.ReadLine();
                            ModificarProducto(Productos, nombre);
                        }
                        else if(opcionModificar == 2)
                        {
                            
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("1)Ingresar ID Del Producto a Eliminar\n2)Salir");
                        int opcionEliminar = int.Parse(Console.ReadLine());
                        if (opcionEliminar == 1)
                        {
                            int id = int.Parse(Console.ReadLine());
                            EliminarProducto(Productos, id);
                        }
                        else if (opcionEliminar == 2)
                        {
                           
                        }
                        
                        break;
                    case 6:
               
                        MenuFacturacion();
                        break;
                    case 7:
                      
                        Salir();
                        break;                   
                    default:
                       
                        Console.WriteLine("Elegir Una Opcion Correcta");
                        break;
                }
                if (opcion!=7)
                {
                    Console.WriteLine("Apriete Cualquier Tecla para volver al Menu Principal");
                    Console.ReadKey();
                }
                
            } while (opcion != 7);
            
        }

        /// <summary>
        /// Muestra El Menu Mostrar Productos
        /// </summary>
        public void MenuMostrarProductos()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(Menu.CrearSubMenuMostrar().ToString());
                Console.WriteLine("\nElegir Una Opcion");
                opcion = int.Parse(Console.ReadLine());
                
                switch (opcion)
                {
                    case 1:
                        List <Producto> productosMostrados = MostrarProductos(Productos);
                        Console.WriteLine(Tabla.TablaCompleta(MostrarProductos(Productos)).ToString());
                        break;
                    case 2:
                        ListaCategorias(Categorias);
                        Console.WriteLine("\nElegir Categoria Para Mostrar Sus Productos:");
                        int opcionCat = int.Parse(Console.ReadLine());
                        Console.WriteLine(Tabla.TablaCompleta(MostrarProductos(Productos, Categorias[opcionCat])));
                        break;
                    case 3:
                        Console.WriteLine(Menu.SubMenuBuscarPorStock());
                        Console.WriteLine("Elegir Los Productos a listar por Stock");
                        int opcionStock = int.Parse(Console.ReadLine());
                        Console.WriteLine(Tabla.TablaCompleta(MostrarProductos(Productos, opcionStock)).ToString());
                        break;
                    case 4:
                        Console.WriteLine(Tabla.CrearTabla(ProductoMasVendido(Productos)).ToString());
                        break;
                    case 5:
                        Console.WriteLine(Tabla.CrearTabla(ProductoMasCaro(Productos)).ToString());
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Elegir una Opcion Valida");
                        break;
                }
                if (opcion!=6)
                {
                    Console.WriteLine("Apriete Cualquier Tecla para volver al Menu Mostrar Productos");
                    Console.ReadKey();
                }
                

            } while (opcion!= 6);
            
        }


        /// <summary>
        /// Muestra El Menu Facturacion
        /// </summary>
        public void MenuFacturacion()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(Menu.CrearSubMenuFacturacion().ToString());
                Console.WriteLine("\nElegir Una Opcion");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(Tabla.CrearTabla(ProductoConMasFacturacion(Productos)).ToString());
                        ImprimirFacturacion(Tabla.CrearTabla(ProductoConMasFacturacion(Productos)).ToString());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(Tabla.TablaCompleta(OrdenarFacturacionMenorAMayor(Productos)).ToString());
                        ImprimirFacturacion(Tabla.TablaCompleta(OrdenarFacturacionMenorAMayor(Productos)).ToString());
                        break;
                    
                    case 3:
                        Console.Clear();
                        ImprimirFacturacion(TodaLaFacturacion(Productos));
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Elegir una Opcion Valida");
                        break;
                }
                if (opcion != 4)
                {
                    Console.WriteLine("Apriete Cualquier Tecla para volver al Menu Facturacion");
                    Console.ReadKey();
                }              

            } while (opcion != 4);
        }

        /// <summary>
        /// Muestra Todos Los Productos
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <returns></returns>
        public List<Producto> MostrarProductos(List<Producto> ProductosObtenidos)
        {           
            return ProductosObtenidos;
        }

        /// <summary>
        /// Muestra Productos Por Categoria
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="Categoria"></param>
        /// <returns></returns>
        public List<Producto> MostrarProductos(List<Producto> ProductosObtenidos, Categoria Categoria)
        {            
            List<Producto> ProductosFiltrados = new List<Producto>();
           

            foreach (var producto in ProductosObtenidos)
            {
                if (producto.Categoria == Categoria.Id)
                {
                    ProductosFiltrados.Add(producto);
                }
            }

            return ProductosFiltrados;
        }

        /// <summary>
        /// Muestra Productos Por Stock
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public List<Producto> MostrarProductos(List<Producto> ProductosObtenidos, int opcion)
        {            
            List<Producto> ProductosFiltrados = new List<Producto>();
            int stock = 0;

            switch (opcion)
            {
                case 1:
                    stock = 0;
                    foreach (var producto in ProductosObtenidos)
                    {
                        if (producto.Stock == stock)
                        {
                            ProductosFiltrados.Add(producto);
                        }
                    }
                    break;
                case 2:
                    stock = 100;
                    foreach (var producto in ProductosObtenidos)
                    {
                        if (producto.Stock <= stock)
                        {
                            ProductosFiltrados.Add(producto);
                        }
                    }
                    break;
                case 3:
                    stock = 100;
                    foreach (var producto in ProductosObtenidos)
                    {
                        if (producto.Stock > stock)
                        {
                            ProductosFiltrados.Add(producto);
                        }
                    }
                    break;
               
            }

            return ProductosFiltrados;
        }

        /// <summary>
        /// Muestra El Producto Mas Vendido
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <returns></returns>
        public Producto ProductoMasVendido (List<Producto> ProductosObtenidos)
        {           
            Producto productoMasVendido = ProductosObtenidos[0];

            foreach (var producto in ProductosObtenidos)
            {
                if (producto.Vendidos > productoMasVendido.Vendidos)
                {
                    productoMasVendido = producto;
                }
            }

            return productoMasVendido;
        }

        /// <summary>
        /// Muestra El Producto Mas Caro
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <returns></returns>
        public Producto ProductoMasCaro(List<Producto> ProductosObtenidos)
        {
            Producto productoMasCaro = ProductosObtenidos[0];

            foreach (var producto in ProductosObtenidos)
            {
                if (producto.Precio > productoMasCaro.Precio)
                {
                    productoMasCaro = producto;
                }
            }

            return productoMasCaro;
        }

        /// <summary>
        /// Busca Producto Por Nombre
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="productoBuscado"></param>
        /// <returns></returns>
        public Producto BuscarProducto(List<Producto> ProductosObtenidos, string productoBuscado)
        {
            Producto productoEncontrado = new Producto();
                       
            foreach (var producto in ProductosObtenidos)
            {
                if (producto.Nombre == productoBuscado)
                {
                    productoEncontrado = producto;
                }
                
            }

            if(productoEncontrado.Nombre == "")
            {
                productoEncontrado.Nombre = $"El producto Buscado Por Nombre {productoBuscado} no existe en el sistema";
            }

            return productoEncontrado;
        }

        /// <summary>
        /// Busca Producto por ID
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Producto BuscarProducto(List<Producto> ProductosObtenidos, int id)
        {
            Producto productoEncontrado = new Producto();

            foreach (var producto in ProductosObtenidos)
            {
                if (producto.Id == id)
                {
                    productoEncontrado = producto;
                }
                
            }

            if (productoEncontrado.Nombre == "")
            {
                productoEncontrado.Nombre = $"El producto Buscado Por ID {id} no existe en el sistema";
            }


            return productoEncontrado;
        }

        /// <summary>
        /// Agrega un Producto
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="nombre"></param>
        /// <param name="categoria"></param>
        /// <param name="id"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="vendidos"></param>
        public void AgregarProducto(List<Producto> ProductosObtenidos)
        {
            Producto producto = new Producto();
            Console.WriteLine("Nombre Del Producto:");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("ID Del Producto:");
            producto.Id = int.Parse(Console.ReadLine());
            ListaCategorias(Categorias);
            Console.WriteLine("Elegir Categoria Correspondiente");
            producto.Categoria = int.Parse(Console.ReadLine());
            Console.WriteLine("Precio Del Producto:");
            producto.Precio = int.Parse(Console.ReadLine());
            Console.WriteLine("Stock Del Producto:");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Vendidos Del Producto:");
            producto.Vendidos = int.Parse(Console.ReadLine());            

            try
            {
                ProductosObtenidos.Add(producto);
                Console.WriteLine($"El articulo {producto.Nombre} fue agregado correctamente");
            }
            catch (ArgumentOutOfRangeException)
            {

                Console.WriteLine("No es posible agregar el articulo por falta de Espacio");
            }
            
        }

        /// <summary>
        /// Modifica un Producto buscado por el nombre
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="nombre"></param>
        public void ModificarProducto (List<Producto> ProductosObtenidos, string nombre)
        {
            Producto productoModificar = BuscarProducto(ProductosObtenidos, nombre);
            int opcion;
            Console.WriteLine(Tabla.CrearTabla(productoModificar).ToString());

            do
            {
                Console.WriteLine("Que parametro desea modificar del producto:\n\n1)Nombre\n2)ID\n3)Categoria\n4)Precio\n5)Stock\n6)Vendidos\n7)Todos\n8)Salir");
                opcion = int.Parse(Console.ReadLine());
                
                    switch (opcion)
                    {
                    case 1:
                        Console.WriteLine("Escribir Nuevo Nombre");
                        productoModificar.Nombre = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Escribir Nuevo ID");
                        productoModificar.Id = int.Parse(Console.ReadLine());
                        break;
                    case 3:                        
                        ListaCategorias(Categorias);
                        Console.WriteLine("Elegir Nueva Categoria");
                        int categoria = int.Parse(Console.ReadLine());
                        productoModificar.Categoria = categoria;
                        break;
                    case 4:
                        Console.WriteLine("Escribir Nuevo Precio");
                        productoModificar.Precio = int.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Escribir Nuevo Stock");
                        productoModificar.Id = int.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Escribir Nuevas Ventas");
                        productoModificar.Vendidos = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.WriteLine("Escribir Nuevo Nombre");
                        productoModificar.Nombre = Console.ReadLine();
                        Console.WriteLine("Escribir Nuevo ID");
                        productoModificar.Id = int.Parse(Console.ReadLine());
                        ListaCategorias(Categorias);
                        Console.WriteLine("Elegir Nueva Categoria");
                        productoModificar.Categoria = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escribir Nuevo Precio");
                        productoModificar.Precio = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escribir Nuevo Stock");
                        productoModificar.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escribir Nuevas Ventas");
                        productoModificar.Vendidos = int.Parse(Console.ReadLine());
                        break;

                    case 8:                        
                    break;

                        default: 
                            Console.WriteLine("Elegir una Opcion Valida");
                            break;
                    }

                int i = 0;
                int index = 0;
                foreach (var producto in ProductosObtenidos)
                {
                    if (productoModificar.Id == producto.Id)
                    {
                        index = i;
                    }
                    i++;
                }
                ProductosObtenidos[index] = productoModificar;
                
                
            } while (opcion!=8);
           

        }

        /// <summary>
        /// Eliminar un Producto por el ID
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <param name="id"></param>
        public void EliminarProducto(List<Producto> ProductosObtenidos, int id)
        {
            Producto producto = BuscarProducto(ProductosObtenidos, id);
            int opcion;

            Console.WriteLine(Tabla.CrearTabla(producto).ToString());

            Console.WriteLine("Desea Eliminar El Producto?\n1)Si\n2)No");
            opcion = int.Parse(Console.ReadLine());
            do
            {
                if (opcion == 1)
                {
                    ProductosObtenidos.Remove(producto);
                    Console.WriteLine("Producto Eliminado Correctamente");
                    Console.WriteLine("Desea Agregar Nuevo Producto?\n1)Si\n2)No");
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1)
                    {
                        AgregarProducto(ProductosObtenidos);
                        opcion = 2;
                    }
                }
                else if (opcion != 1 & opcion != 2)
                {
                    Console.WriteLine("Elegir una opcion correcta");
                }
                
            } while (opcion != 2);

           
        }

                
        /// <summary>
        /// Obtiene Productos con mas Facturacion
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <returns></returns>
        public Producto ProductoConMasFacturacion(List<Producto> ProductosObtenidos)
        {
            Producto ProductoMasFacturado = ProductosObtenidos[0];

            foreach (var producto in ProductosObtenidos)
            {
                if (producto.Precio*producto.Vendidos > ProductoMasFacturado.Precio* ProductoMasFacturado.Vendidos)
                {
                    ProductoMasFacturado = producto;
                }
            }

            return ProductoMasFacturado;

           
        }
        
        /// <summary>
        /// Ordenar la lista de facturacion de menor a mayor
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        /// <returns></returns>
        public List<Producto> OrdenarFacturacionMenorAMayor(List<Producto> ProductosObtenidos)
        {
           
            bool hayCambio = false;
            do
            {
                hayCambio = false;
                for (int i = 0; i < ProductosObtenidos.Count - 1; i++)
                {                    
                    if (ProductosObtenidos[i].Precio * ProductosObtenidos[i].Vendidos > ProductosObtenidos[i+1].Precio * ProductosObtenidos[i+1].Vendidos)
                    {
                        //Existe una permutación o cambio del orden.
                        Producto temporal = ProductosObtenidos[i + 1];
                        ProductosObtenidos[i + 1] = ProductosObtenidos[i];
                        ProductosObtenidos[i] = temporal;
                        hayCambio = true;
                    }
                }
            } while (hayCambio);
            return ProductosObtenidos;
        }

        /// <summary>
        /// Obtiene la facturacion total de los productos
        /// </summary>
        /// <param name="ProductosObtenidos"></param>
        public string TodaLaFacturacion (List<Producto> ProductosObtenidos)
        {
            double Totalfacturado = 0;
            string total;

            Console.WriteLine(Tabla.CrearTabla(ProductoConMasFacturacion(ProductosObtenidos)).ToString());
            Console.WriteLine(Tabla.TablaCompleta(OrdenarFacturacionMenorAMayor(ProductosObtenidos)).ToString());

            foreach (var producto in ProductosObtenidos)
            {
                Totalfacturado += producto.Vendidos * producto.Precio;
            }

            total = "Total Facturado:" + Totalfacturado;

            Console.WriteLine(total);

            return total;
        }

        /// <summary>
        /// Termina El Programa
        /// </summary>
        public void Salir()
        {
            Console.WriteLine("Desea Abandonar El Programa?\n1)Si\n2)No");
            int opcion = int.Parse(Console.ReadLine());

            do
            {
                if (opcion == 2)
                {
                    Menu.CrearMenuPrincipal();
                }
                else if (opcion != 1 || opcion != 2)
                {
                    Console.WriteLine("Elija Una Opcion Correcta");
                }

            } while (opcion != 1);
            
        }

        /// <summary>
        /// Lista las Categorias Disponibles
        /// </summary>
        /// <param name="Categorias"></param>
        public void ListaCategorias(List<Categoria> Categorias)
        {           
            foreach (var categoria in Categorias)
            {              
                Console.WriteLine($"{categoria.Id}){categoria.Nombre}");
                
            }
        }

      
     
        /// <summary>
        /// Imprime Facturacion
        /// </summary>
        /// <param name="TextoImprimir"></param>
        public void ImprimirFacturacion(String TextoImprimir)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Facturacion.txt";
            using (StreamWriter miTexto = new StreamWriter(path, false))
            {
                miTexto.WriteLine(TextoImprimir);
            }
            
        }
    }
}
