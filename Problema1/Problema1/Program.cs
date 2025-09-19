class Program
{
  static void Main()
  {
    Console.Write("Ingrese la cantidad de productos vendidos hoy: ");
    int n = int.Parse(Console.ReadLine());

    int[] codigos = new int[n + 100];
    Console.WriteLine("");
    Console.WriteLine("Ingrese los códigos de productos:");

    for (int i = 0; i < n; i++)
    {
      Console.Write($"Código [{i}]: ");
      codigos[i] = int.Parse(Console.ReadLine());
    }

    Console.WriteLine("");
    Console.WriteLine("--- INVENTARIO INICIAL ---");
    ImprimirVector(codigos, n);
    Console.WriteLine("");

    // 1. Buscar cuántas veces aparece un código
    Console.Write("Ingrese un código a buscar: ");
    int buscar = int.Parse(Console.ReadLine());

    Console.WriteLine($"El código {buscar} aparece {ContarCodigo(codigos, n, buscar)} veces.");
    Console.WriteLine("");

    // 2. Insertar en una posición
    Console.Write("Ingrese el código a insertar: ");
    int nuevo = int.Parse(Console.ReadLine());

    Console.WriteLine("");
    Console.Write($"Ingrese la posición donde insertarlo: ");
    int pos = int.Parse(Console.ReadLine());

    n = InsertarCodigo(codigos, n, nuevo, pos);
    Console.WriteLine("Inventario después de insertar:");
    ImprimirVector(codigos, n);
    Console.WriteLine("");

    // 3. Eliminar primera ocurrencia
    Console.Write("Ingrese el código a eliminar: ");
    int eliminar = int.Parse(Console.ReadLine());

    n = EliminarCodigo(codigos, n, eliminar);
    Console.WriteLine("");
    Console.WriteLine("Inventario después de eliminar:");
    ImprimirVector(codigos, n);
  }

  static int ContarCodigo(int[] vector, int n, int codigo)
  {
    int count = 0;

    for (int i = 0; i < n; i++)
    {
      if (vector[i] == codigo) count++;
    }

    return count;
  }

  static int InsertarCodigo(int[] vector, int n, int valor, int pos)
  {
    if (pos < 0 || pos > n)
    {
      Console.WriteLine("Posición inválida.");
      return n;
    }

    for (int i = n; i > pos; i--)
    {
      vector[i] = vector[i - 1];
    }

    vector[pos] = valor;

    return n + 1;
  }

  static int EliminarCodigo(int[] vector, int n, int valor)
  {
    for (int i = 0; i < n; i++)
    {
      if (vector[i] == valor)
      {
        for (int j = i; j < n - 1; j++)
        {
          vector[j] = vector[j + 1];
        }

        vector[n - 1] = 0;

        return n - 1;
      }
    }
    Console.WriteLine("El código no se encontró.");
    return n;
  }

  static void ImprimirVector(int[] vector, int n)
  {
    Console.WriteLine(string.Join(" ", vector[..n]));
  }
}
