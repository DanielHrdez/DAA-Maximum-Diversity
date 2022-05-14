/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Swap</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Approximated.LocalSearch;

/// <summary>
/// Class that represents the swap local search algorithm.
/// </summary>
public class Swap {
  /// <summary>
  /// Runs the swap local search algorithm.
  /// </summary>
  /// <param name="currentSolution">The current solution.</param>
  /// <returns>The new solution.</returns>
  public VectorsDistance Search(VectorsDistance currentSolution) {
    VectorsDistance bestSolution = new VectorsDistance(currentSolution);
    VectorsDistance newSolution;
    for (int i = 0; i < currentSolution.Count; i++) {
      for (int j = 0; j < currentSolution.Count; j++) {
        if (i == j || currentSolution[i, j]) continue;
        newSolution = currentSolution.Swap(i, j);
        if (newSolution.Distance > bestSolution.Distance) {
          bestSolution = new VectorsDistance(newSolution);
        }
      }
    }
    return bestSolution;
  }

  /// <summary>
  /// Runs the swap local search algorithm and returns all the solutions.
  /// </summary>
  /// <param name="currentSolution">The current solution.</param>
  /// <returns>The new solutions.</returns>
  public List<VectorsDistance> Neighbors(VectorsDistance currentSolution) {
    List<VectorsDistance> neighbors = new List<VectorsDistance>();
    VectorsDistance newSolution;
    for (int i = 0; i < currentSolution.Count; i++) {
      for (int j = 0; j < currentSolution.Count; j++) {
        if (i == j || currentSolution[i, j]) continue;
        newSolution = currentSolution.Swap(i, j);
        neighbors.Add(newSolution);
      }
    }
    return neighbors;
  }
}
