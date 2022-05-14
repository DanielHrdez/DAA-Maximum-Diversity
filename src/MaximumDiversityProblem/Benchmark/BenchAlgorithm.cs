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
  private List<Vectors> problems;

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="dataModels">The data models.</param>
  public BenchAlgorithm(List<Vectors> problems) {
    this.problems = problems;
  }

  /// <summary>
  /// Run the benchmark.
  /// </summary>
  /// <param name="model">The model of the problem.</param>
  /// <returns>The results of the benchmark.</returns>
  public List<List<string>> Run(MaximumDiversity model) {
    string outputFolder = "csv";
    Directory.CreateDirectory(outputFolder);
    List<List<string>> results = new List<List<string>>();
    string algorithmName = model.GetAlgorithmName();
    List<string> header = new List<string>();
    header.Add("Problema");
    header.Add("Total vectors");
    header.Add("Dimension vectors");
    header.Add("Length solution");
    if (algorithmName == "Grasp") {
      header.Add("Iterations");
      header.Add("Number of Candidates");
    }
    else if (algorithmName == "Tabu") {
      header.Add("Iterations");
      header.Add("List size");
    }
    header.Add("Dispersión");
    header.Add("Solution");
    header.Add("Tiempo CPU (sg)");
    results.Add(header);
    int maxIterations = 20;
    int maxLengthVectors = 5;
    int numberOfColumns = header.Count;
    string filename = string.Format("{0}/{1}.csv", outputFolder, algorithmName);

    PrintTable.PrintTitleHeader(algorithmName, header);
    WriteCSV.ClearFile(filename);
    WriteCSV.Add(filename, header);
    Stopwatch sw = new Stopwatch();
    foreach (Vectors problem in this.problems) {
      for (int i = 2; i <= maxLengthVectors; i++) {
        for (int j = 10; j <= maxIterations; j *= 2) {
          if (algorithmName == "Grasp") ((Grasp) model.GetAlgorithm()).SetMaxIterations(j);
          if (algorithmName == "Tabu") ((Tabu) model.GetAlgorithm()).SetMaxIterations(j);
          for (int k = 2; k <= 3; k++) {
            if (algorithmName == "Grasp") ((Grasp) model.GetAlgorithm()).SetCandidates(k);
            if (algorithmName == "Tabu") ((Tabu) model.GetAlgorithm()).SetMaxTabuList(k);
            model.SetVectors(problem);
            sw.Start();
            VectorsDistance result = model.Run(i);
            sw.Stop();
            List<string> currentResult = new List<string>();
            currentResult.Add(
              String.Format("max_div_{0}_{1}", problem.Count, problem.Components)
            );
            currentResult.Add(problem.Count.ToString());
            currentResult.Add(problem.Components.ToString());
            currentResult.Add(i.ToString());
            currentResult.Add(result.Distance.ToString());
            currentResult.Add(result.VectorsSolution);
            currentResult.Add(sw.Elapsed.TotalSeconds.ToString());
            PrintTable.PrintRow(currentResult, false);
            WriteCSV.Add(filename, currentResult);
            results.Add(currentResult);
            if (algorithmName == "Greedy") break;
          }
          if (algorithmName == "Greedy") break;
        }
      }
    }

    PrintTable.PrintBottom(numberOfColumns);
    return results;
  }
}
