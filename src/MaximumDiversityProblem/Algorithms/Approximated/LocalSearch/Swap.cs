/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Swap</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Approximated.LocalSearch;
public class Swap {
  public static VectorsDistance Search(VectorsDistance currentSolution) {
    VectorsDistance bestSolution = new VectorsDistance(currentSolution);
    VectorsDistance newSolution;
    for (int i = 0; i < currentSolution.Count; i++) {
      for (int j = 0; j < currentSolution.Count; j++) {
        if (i == j || !currentSolution[j]) continue;
        newSolution = currentSolution.Swap(i, j);
        if (newSolution.Distance > bestSolution.Distance) {
          bestSolution = new VectorsDistance(newSolution);
        }
      }
    }
    return bestSolution;
  }
}
