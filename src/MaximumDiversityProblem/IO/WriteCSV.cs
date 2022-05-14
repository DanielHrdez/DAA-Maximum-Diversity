/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>WriteCSV</class>

namespace MaximumDiversityProblem.IO;

/// <summary>
/// This class writes the solution of the problem in a csv file.
/// </summary>
public class WriteCSV {
  private static string DELIMITER = ",";

  /// <summary>
  /// Writes the solution of the problem in a csv file.
  /// </summary>
  /// <param name="filename">The name of the file.</param>
  /// <param name="results">The solution of the problem.</param>
  public static void Write(string filename, List<List<string>> results) {
    using (StreamWriter writer = File.CreateText(filename)) {
      foreach (List<string> result in results) {
        for (int i = 0; i < result.Count; i++) {
          result[i] = result[i].Replace(DELIMITER, ".").Replace(". ", "").Replace("\n", "").Replace("\r", "");
          writer.Write(result[i] + DELIMITER);
        }
        writer.WriteLine();
      }
    }
  }

  /// <summary>
  /// Clear the file.
  /// </summary>
  /// <param name="filename">The name of the file.</param>
  public static void ClearFile(string filename) {
    File.WriteAllText(filename, "");
  }

  /// <summary>
  /// Add a line to the file.
  /// </summary>
  /// <param name="filename">The name of the file.</param>
  /// <param name="result">The line to add.</param>
  public static void Add(string filename, List<string> result) {
    using (StreamWriter file = File.AppendText(filename)) {
      for (int i = 0; i < result.Count; i++) {
        result[i] = result[i].Replace(DELIMITER, ".").Replace(". ", "").Replace("\n", "").Replace("\r", "");
        file.Write(result[i] + DELIMITER);
      }
      file.WriteLine();
    }
  }
}
