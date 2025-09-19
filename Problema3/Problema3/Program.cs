using System.Globalization;

class Program
{
  static void Main()
  {
    Console.Write("Ingrese número de estudiantes (m): ");
    int m = int.Parse(Console.ReadLine());

    Console.Write("Ingrese número de asignaturas (k): ");
    int k = int.Parse(Console.ReadLine());

    double[,] notas = new double[m, k];
    Console.WriteLine("");

    for (int i = 0; i < m; i++)
    {
      Console.WriteLine($"Notas del estudiante {i + 1}:");
      for (int j = 0; j < k; j++)
      {
        Console.Write($"  Asignatura {j + 1}: ");
        notas[i, j] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
      }
    }

    double[] promediosEst = CalcularPromediosEstudiantes(notas, m, k);
    double[] promediosAsig = CalcularPromediosAsignaturas(notas, m, k);

    int mejorEst = ObtenerMejorEstudiante(promediosEst);
    int asigExigente = ObtenerAsignaturaExigente(promediosAsig);

    Console.WriteLine("");
    Console.WriteLine("Promedios por estudiante:");
    for (int i = 0; i < m; i++)
    {
      Console.WriteLine($"Estudiante {i + 1}: {promediosEst[i]:0.00}");
    }

    Console.WriteLine("");
    Console.WriteLine("Promedios por asignatura:");
    for (int j = 0; j < k; j++)
    {
      Console.WriteLine($"Asignatura {j + 1}: {promediosAsig[j]:0.00}");
    }

    Console.WriteLine("");
    Console.WriteLine($"Mejor estudiante: Estudiante {mejorEst + 1} ({promediosEst[mejorEst]:0.00})");
    Console.WriteLine($"Asignatura más exigente: Asignatura {asigExigente + 1} ({promediosAsig[asigExigente]:0.00})");

    Console.WriteLine("");
    Console.WriteLine("Alertas (promedio < 3.0):");

    bool hayAlertas = false;
    for (int i = 0; i < m; i++)
    {
      if (promediosEst[i] < 3.0)
      {
        Console.WriteLine($"Estudiante {i + 1} en riesgo ({promediosEst[i]:0.00})");
        hayAlertas = true;
      }
    }

    if (!hayAlertas) Console.WriteLine("Ningún estudiante en riesgo.");
  }

  static double[] CalcularPromediosEstudiantes(double[,] notas, int m, int k)
  {
    double[] promedios = new double[m];

    for (int i = 0; i < m; i++)
    {
      double suma = 0;
      for (int j = 0; j < k; j++)
      {
        suma += notas[i, j];
      }
      promedios[i] = suma / k;
    }
    return promedios;
  }

  static double[] CalcularPromediosAsignaturas(double[,] notas, int m, int k)
  {
    double[] promedios = new double[k];
    for (int j = 0; j < k; j++)
    {
      double suma = 0;
      for (int i = 0; i < m; i++)
      {
        suma += notas[i, j];
      }
      promedios[j] = suma / m;
    }
    return promedios;
  }

  static int ObtenerMejorEstudiante(double[] promediosEst)
  {
    int indexMayor = 0;
    for (int i = 1; i < promediosEst.Length; i++)
    {
      if (promediosEst[i] > promediosEst[indexMayor])
        indexMayor = i;
    }
    return indexMayor;
  }

  static int ObtenerAsignaturaExigente(double[] promediosAsig)
  {
    int indexMayor = 0;
    for (int j = 1; j < promediosAsig.Length; j++)
    {
      if (promediosAsig[j] < promediosAsig[indexMayor])
        indexMayor = j;
    }
    return indexMayor;
  }
}
