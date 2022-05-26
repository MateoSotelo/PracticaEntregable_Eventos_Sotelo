using LogicaDepositos_PE;
using EventosDepositos_PE;
using System.Threading;

// See https://aka.ms/new-console-template for more information

//OJO!! USAR PROYECTOS NET FRAMEWORK, NO NET CORE

PrincipalLogica logica = new PrincipalLogica();
logica.productoAgregadoEliminadoHandler += ProductoAgregadoEliminado;
logica.productoAgregadoModificadoHandler += ProdcutoAgregadoModificado;

int entrada = 1;

while (entrada != 0)
{
    Console.Clear();

    Console.WriteLine("Ingrese 1 si quiere ingresar un elemento");
    Console.WriteLine("Ingrese 2 si quiere eliminar un elemento");
    Console.WriteLine("Ingrese 3 si quiere imprmir las descripciones");
    Console.WriteLine("Ingrese 0 si quiere cerrar la app");

    entrada = int.Parse(Console.ReadLine());

    switch (entrada)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Ingresando un elemento...");

            Console.Write("Ingrese 1 si quiere ingresar una computadora, sino ingresara un monitor: ");
            bool ingresarComputadora = int.Parse(Console.ReadLine()) == 1 ? true : false;
            IngresarElemento(ingresarComputadora);
            break;
        case 2:
            EliminarElemento();
            break;
        case 3:
            ObtenerDescripciones();
            break;
    }

    Console.ReadKey();
}

void ObtenerDescripciones()
{
    Console.Clear();
    Console.WriteLine("Descripciones de los elementos...");

    logica.OrdenarListaPorTipoProducto();
}

void IngresarElemento(bool ingresarComputadora)
{
    Console.Write("Ingrese Modelo: ");
    string modelo = Console.ReadLine();

    Console.Write("Ingrese Marca: ");
    string marca = Console.ReadLine();

    Console.Write("Ingrese numero de serie: ");
    int numeroSerie = int.Parse(Console.ReadLine());

    if (ingresarComputadora == true)
    {
        Console.Write("Ingrese procesador: ");
        string descripcionProcesador = Console.ReadLine();

        Console.Write("Ingrese memoria RAM: ");
        byte numMemoriaRAM = byte.Parse(Console.ReadLine());

        logica.AgregarElemento(modelo, marca, numeroSerie, descripcionProcesador, numMemoriaRAM);
    }
    else
    {
        Console.Write("Ingresar año de Fabricacion: ");
        short añoFabricacion = short.Parse(Console.ReadLine());

        Console.Write("Ingresar cantidad de pulgadas (opcional): ");
        int? pulgadas = int.Parse(Console.ReadLine());

        logica.AgregarElemento(modelo, marca, numeroSerie, añoFabricacion,pulgadas);
    }
}

void EliminarElemento()
{
    Console.WriteLine("Eliminando un elemento...");

    Console.WriteLine("ingresar ID del elemento a eliminar: ");
    string ID = Console.ReadLine();

    bool resultado = logica.EliminarElemento(ID);

    if (resultado == true)
    {
        Console.WriteLine("Objeto eliminado");
        logica.EliminarElemento(ID);
    }
    else
    {
        Console.WriteLine("No se encontro el objeto");
    }
}

static void ProductoAgregadoEliminado(object? sender, ProductoAgregadoEliminadoEventsArgs e)
{
    Console.Clear();

    Console.WriteLine($"Producto: {e.tipoProducto}, ID: {e.ID}");
    Thread.Sleep(800);
}

static void ProdcutoAgregadoModificado(object? sender, ProductoAgregadoModificadoEventsArgs e)
{
    if (e.Ultimo == true)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Producto {e.Descripcion}, Total de Monitores {e.cantidadMonitores} - Porcentaje {e.porcentajeMonitores * 100}%,Total de Computadoras {e.cantidadComputadoras} - Porcentaje {e.porcentajeComputadoras * 100}%");
    }
    else
    {
        Console.WriteLine($"Producto {e.Descripcion}");
    }

    Console.ForegroundColor = ConsoleColor.White;
}

