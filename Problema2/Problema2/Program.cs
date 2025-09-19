class Program
{
  static void Main()
  {
    int n = 4, m = 5;
    int[,] ventas = new int[n, m];

    Console.WriteLine("Ingrese las ventas:");

    for (int i = 0; i < n; i++)
    {
      Console.WriteLine($"Producto {i + 1}:");
      for (int j = 0; j < m; j++)
      {
        Console.Write($"  Día {j + 1}: ");
        ventas[i, j] = int.Parse(Console.ReadLine());
      }
    }

    int[] totalPorProducto = new int[n];
    int[] totalPorDia = new int[m];

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < m; j++)
      {
        totalPorProducto[i] += ventas[i, j];
        totalPorDia[j] += ventas[i, j];
      }
    }

    int productoLider = 0;
    for (int i = 1; i < n; i++)
    {
      if (totalPorProducto[i] > totalPorProducto[productoLider])
        productoLider = i;
    }

    int diaMasBajo = 0;
    for (int j = 1; j < m; j++)
    {
      if (totalPorDia[j] < totalPorDia[diaMasBajo])
        diaMasBajo = j;
    }

    Console.WriteLine("");
    Console.WriteLine("Totales por producto:");
    for (int i = 0; i < n; i++)
    {
      Console.WriteLine($"Producto {i + 1}: {totalPorProducto[i]}");
    }

    Console.WriteLine("");
    Console.WriteLine("Totales por día:");
    for (int j = 0; j < m; j++)
    {
      Console.WriteLine($"Día {j + 1}: {totalPorDia[j]}");
    }

    Console.WriteLine($"Producto líder: Producto {productoLider + 1}");
    Console.WriteLine($"Día más bajo: Día {diaMasBajo + 1}");
  }
}
