using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica5
{
    class Program
    {
        public List<Productos> _Productos { get; set; }
        public List<Categorias> Categorias { get; set; }
        public List<Productos> ProductosCategoria { get; set; }
        public List<Productos> ProductosFiltrados { get; set; }
        public List<Categorias> CategoriasProductosRegistrados { get; set; }




        static void Main(string[] args)
        {
            Program program = new Program();

            program.ProductosCategorias();
            program.firstStep();
            program.secondStep();
            program.thirdStep();

        }

        public void firstStep()
        {

            //1 - Productos por una categoría en especifico

                       ProductosCategoria = (from p in _Productos
                                  where p.categoriaID == 1
                                  select p).ToList();
            foreach(Productos producto in ProductosCategoria)
            {
                Console.WriteLine("Filtrando Productos Categoria SmartWatch : "+producto.nombre +" y" + producto.marca);

            }

        }
        void secondStep()
        {


            //2 - Los productos con precios mayores de 3,000 pesos pero menores de 5000 pesos, ordenados descendente mente
            ProductosFiltrados = (from p in _Productos
                                  where p.precio >= 3000 && p.precio <= 5000
                                  select p).ToList();
            foreach (Productos producto in ProductosFiltrados)
            {

                Console.WriteLine("Filtrando Productos Filtrado Rango de Precio :" + producto.nombre + " y "+ producto.precio);
            }
        }

        void thirdStep()
        {
            //3 - Los nombres de las categorías de los productos registrados(usar join)

            CategoriasProductosRegistrados = (from c in Categorias
                                              join p in _Productos on c.id equals p.categoriaID
                                              select c).Distinct().ToList();
            foreach (Categorias categorias in CategoriasProductosRegistrados)
            {
                Console.WriteLine("Los nombres de las categorías de los productos registrado :" + categorias.nombre);
            }
        }

     

        public void ProductosCategorias()
        {


            Categorias = new List<Categorias> {
                new Categorias { id = 1, nombre = "SmartWatch" },
                new Categorias { id = 2, nombre = "Phone" },
                new Categorias { id = 3, nombre = "Laptop" },
                new Categorias { id = 4, nombre = "Consola de Videos Juego" }
            };

            //Llenando Arreglo de Productos
            _Productos = new List<Productos> {
                new Productos { id = 1, nombre = "Fitbit Versa", categoriaID = 1, marca = "Fitbit", modelo = "Versa 2", precio = 8000 },
                new Productos { id = 2, nombre = "Apple Watch", categoriaID = 1, marca = "Apple Watch", modelo = "Serie 6", precio = 21000 },
                new Productos { id = 3, nombre = "AGPTEK Watch", categoriaID = 1, marca = "AGPTEK", modelo = "LW11", precio = 4000 },
                new Productos { id = 4, nombre = "Garmin Vivoactive 3", categoriaID = 1, marca = "Garmin", modelo = "VivoActive", precio = 3500 },
                new Productos { id = 5, nombre = "Apple Iphone", categoriaID = 2, marca = "Apple", modelo = "13 PRO", precio = 85000 },
                new Productos { id = 6, nombre = "Samsumg Galaxy", categoriaID = 2, marca = "Samsumg", modelo = "S21", precio = 65000 },
                new Productos { id = 7, nombre = "Samsung Galaxy Flip", categoriaID = 2, marca = "Samsumg", modelo = "Flip", precio = 60000 },
                new Productos { id = 8, nombre = "OnePlus 8", categoriaID = 2, marca = "OnePlus", modelo = "Glacial", precio = 15000 },
                new Productos { id = 9, nombre = "Macbook Pro", categoriaID = 3, marca = "Apple", modelo = "PRO", precio = 2500 },
                new Productos { id = 10, nombre = "Think pad", categoriaID = 3, marca = "Lenovo", modelo = "THINKPAD", precio = 1500 },
                new Productos { id = 9, nombre = "Play 5", categoriaID = 4, marca = "Play Station", modelo = "PS5", precio = 2500 },
                new Productos { id = 10, nombre = "Xbox One", categoriaID = 4, marca = "XBOX", modelo = "ONE", precio = 1500 }
            };


        }

        
    }
}
