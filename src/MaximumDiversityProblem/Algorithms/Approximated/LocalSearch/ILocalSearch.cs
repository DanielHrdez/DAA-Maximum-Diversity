/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>LocalSearch</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Approximated.LocalSearch;

/// <summary>
/// Interface that represents a local search algorithm.
/// </summary>
public interface ILocalSearch {
    /// <summary>
  /// Runs the local search algorithm.
  /// </summary>
  /// <param name="currentSolution">The current solution.</param>
  /// <returns>The new solution.</returns>
  VectorsDistance Search(VectorsDistance currentSolution);
}
