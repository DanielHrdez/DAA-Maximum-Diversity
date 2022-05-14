/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>PrintTable</class>

namespace MaximumDiversityProblem.IO;

/// <summary>
/// This class prints a table.
/// </summary>
public class PrintTable {
  /// <summary>
  /// Prints a table.
  /// </summary>
  /// <param name="title"> The title of the table.</param>
  /// <param name="results"> The results of the table.</param>
  public static void Print(string title, List<List<string>> results) {    
    PrintTitle(title);
    bool header = false;
    int resultSize = results[0].Count;
    PrintTop(resultSize);
    for (int i = 0; i < results.Count; i++) {
      PrintRow(results[i], false);
      if (!header) {
        PrintLine(resultSize);
        header = true;
      }
    }
    PrintBottom(resultSize);
    Console.WriteLine();
  }

  /// <summary>
  /// Prints a row
  /// </summary>
  /// <param name="row"> The row to print.</param>
  /// <param name="color"> The color of the row.</param>
  public static void PrintRow(List<string> row, bool color) {
    string separator = "│";
    int spaces = Console.WindowWidth * 80 / (100 * row.Count) + 1;
    string stringFormat = " {0,-" + spaces + "}";
    for (int i = 0; i < row.Count; i++) {
      Console.Write(separator);
      if (color) Console.ForegroundColor = ConsoleColor.Cyan;
      string value = row[i];
      if (value.Length > spaces) value = value.Substring(0, spaces - 3) + "...";
      Console.Write(stringFormat, value);
      Console.ResetColor();
    }
    Console.WriteLine(separator);
  }

  /// <summary>
  /// Print the top
  /// </summary>
  /// <param name="numberOfColumns"> number of columns</param>
  public static void PrintTop(int numberOfColumns) {
    string topLine = lineSeparator(numberOfColumns, "┌─", "─┬─", "─┐");
    Console.WriteLine(topLine);
  }

  /// <summary>
  /// Print a line
  /// </summary>
  /// <param name="numberOfColumns"> number of columns</param>
  public static void PrintLine(int numberOfColumns) {
    string line = lineSeparator(numberOfColumns, "├─", "─┼─", "─┤");
    Console.WriteLine(line);
  }

  /// <summary>
  /// Prints the header
  /// </summary>
  /// <param name="header"> The header of the table.</param>
  public static void PrintHeader(List<string> header) {
    int numberOfColumns = header.Count;
    PrintTop(numberOfColumns);
    PrintRow(header, true);
    PrintLine(numberOfColumns);
  }

  /// <summary>
  /// Prints the title
  /// </summary>
  /// <param name="title"> The title of the table.</param>
  public static void PrintTitle(string title) {
    Console.Write("\u001B[1m");
    Console.WriteLine("{0,40}" + title, "");
    Console.Write("\u001B[0m");
  }

  /// <summary>
  /// Print the title and the header
  /// </summary>
  /// <param name="title"> The title of the table</param>
  /// <param name="header"> The header of the table</param>
  public static void PrintTitleHeader(string title, List<string> header) {
    PrintTitle(title);
    PrintHeader(header);
  }

  /// <summary>
  /// Prints the bottom of the table.
  /// </summary>
  /// <param name="numberOfColumns"> The number of columns.</param>
  public static void PrintBottom(int numberOfColumns) {
    string bottomLine = lineSeparator(numberOfColumns, "└─", "─┴─", "─┘");
    Console.WriteLine(bottomLine);
  }

  /// <summary>
  /// Prints a table.
  /// </summary>
  /// <param name="size"> The rows of the table.</param>
  /// <param name="start"> The start char of the line.</param>
  /// <param name="interception"> The interception char of the columns.</param>
  /// <param name="end"> The end char of the line.</param>
  /// <returns>The line.</params>
  private static string lineSeparator(int size, string start, string interception, string end) {
    string lineSeparator = start;
    int spaces = Console.WindowWidth * 80 / (100 * size);
    for (int i = 1; i < size; i++) {
      lineSeparator += new string('─', spaces) + interception;
    }
    return lineSeparator + new string('─', spaces) + end;
  }
}
