using LogicaDepositos_PE;

// See https://aka.ms/new-console-template for more information

PrincipalLogica logica = new PrincipalLogica();

int entrada = 1;

while (entrada != 0)
{
    Console.Clear();

    Console.WriteLine("Ingrese 1 si quiere ingresar un elemento");
    Console.WriteLine("Ingrese 2 si quiere eliminar un elemento");
    Console.WriteLine("Ingrese 3 si quiere imprmir las descripciones");
    Console.WriteLine("Ingrese 4 si quiere imprimir la lista ordenada por tipo de producto");
    Console.WriteLine("Ingrese 0 si quiere cerrar la app");

    switch (entrada)
    {
        case 1:
            Console.Write("Ingrese 1 si quiere ingresar una computadoram sino ingresara un monitor: ");
            bool ingresarComputadora = int.Parse(Console.ReadLine()) == 1 ? true : false;
            IngresarElemento(ingresarComputadora);
            break;
        case 2:
            EliminarElemento();
            break;
        case 3:
            ObtenerDescripciones();
            break;
        case 4:
            ObtenerListaOrdenada();
            break;
    }

}

void ObtenerListaOrdenada()
{
    List<string> elementos = logica.OrdenarListaPorTipoProducto();

    foreach (string elemento in elementos)
    {
        Console.WriteLine(elemento);
    }
}

void ObtenerDescripciones()
{
    List<string> descripciones = logica.ObtenerDescripcionElementos();

    foreach (string descripcion in descripciones)
    {
        Console.WriteLine(descripcion);
    }
}

void IngresarElemento(bool ingresarComputadora)
{
    Console.Write("Ingrese Modelo: ");
    string modelo = Console.ReadLine();

    Console.Write("Ingrese Marca: ");
    string marca = Console.ReadLine();

    Console.Write("Ingrese edad: ");
    int numeroSerie = int.Parse(Console.ReadLine());

    if (ingresarComputadora == true)
    {
        Console.Write("Ingrese procesador: ");
        string descripcionProcesador = Console.ReadLine();

        Console.Write("Ingrese memoria RAM: ");
        byte numMemoriaRAM = byte.Parse(Console.ReadLine());
    }
    else
    {
        Console.Write("Ingresar año de Fabricacion");
        short añoFabricacion = short.Parse(Console.ReadLine());
    }
}

void EliminarElemento()
{
    Console.WriteLine("ingresar ID del elemento a eliminar: ");
    string ID = Console.ReadLine();

    bool resultado = logica.EliminarElemento(ID);

    if (resultado == true)
    {
        Console.WriteLine("Objeto eliminado");
    }
    else
    {
        Console.WriteLine("No se encontro el objeto");
    }
}

