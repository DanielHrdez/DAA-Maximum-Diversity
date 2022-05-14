/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>BenchAlgorithm</class>

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.IO;
using MaximumDiversityProblem.Algorithms.Exact;
using MaximumDiversityProblem.Algorithms.Approximated;
using System.Diagnostics;

namespace MaximumDiversityProblem.Benchmark;

/// </summary>
/// This class Bench a vehicle routing problem.
/// </summary>
public class BenchAlgorithm {
  /// <summary>
  /// Run the benchmark.
  /// </summary>
  /// <param name="model">The model of the problem.</param>
  /// <returns>The results of the benchmark.</returns>
  public static List<List<string>> Run(MaximumDiversity[] models) {
    string outputFolder = "csv";
    Directory.CreateDirectory(outputFolder);
    List<List<string>> results = new List<List<string>>();
    string previousAlgorithm = "";
    for (int index = 0; index < models.Length; index++) {
      string algorithmName = models[index].GetAlgorithmName();
      List<string> header = new List<string>();
      header.Add("N Vectors");
      header.Add("Dimension");
      header.Add("Length sol");
      if (algorithmName == "Grasp") {
        header.Add("Iterations");
        header.Add("N Candidates");
      }
      else if (algorithmName == "Tabu") {
        header.Add("Iterations");
        header.Add("List size");
      }
      header.Add("Dispersión");
      header.Add("Solution");
      header.Add("CPU (sg)");
      results.Add(header);
      int maxIterations = 20;
      int maxLengthVectors = 5;
      int numberOfColumns = header.Count;
      string filename = string.Format("{0}/{1}.csv", outputFolder, algorithmName);

      if (previousAlgorithm != algorithmName) {
        PrintTable.PrintTitleHeader(algorithmName, header);
        WriteCSV.ClearFile(filename);
        WriteCSV.Add(filename, header);
      }
      Stopwatch sw = new Stopwatch();
      for (int i = 2; i <= maxLengthVectors; i++) {
        for (int j = 10; j <= maxIterations; j *= 2) {
          if (algorithmName == "Grasp") ((Grasp) models[index].GetAlgorithm()).SetMaxIterations(j);
          if (algorithmName == "Tabu") ((Tabu) models[index].GetAlgorithm()).SetMaxIterations(j);
          for (int k = 2; k <= 3; k++) {
            if (algorithmName == "Grasp") ((Grasp) models[index].GetAlgorithm()).SetCandidates(k);
            if (algorithmName == "Tabu") ((Tabu) models[index].GetAlgorithm()).SetMaxTabuList(k);
            sw.Start();
            VectorsDistance result = models[index].Run(i);
            sw.Stop();
            List<string> currentResult = new List<string>();
            Vectors problem = models[index].GetVectors();
            currentResult.Add(problem.Count.ToString());
            currentResult.Add(problem.Components.ToString());
            currentResult.Add(i.ToString());
            if (algorithmName != "Greedy") {
              currentResult.Add(j.ToString());
              currentResult.Add(k.ToString());
            }
            currentResult.Add(result.Distance.ToString());
            currentResult.Add(result.VectorsSolution.Replace("\n", ""));
            currentResult.Add(sw.Elapsed.TotalSeconds.ToString());
            PrintTable.PrintRow(currentResult, false);
            WriteCSV.Add(filename, currentResult);
            results.Add(currentResult);
            if (algorithmName == "Greedy") break;
          }
          if (algorithmName == "Greedy") break;
        }
      }
      try {
        if (models[index + 1].GetAlgorithmName() != algorithmName) {
          PrintTable.PrintBottom(numberOfColumns);
        }
      } catch (System.IndexOutOfRangeException) {
        PrintTable.PrintBottom(numberOfColumns);
      }
      previousAlgorithm = algorithmName;
    }
    return results;
  }
}