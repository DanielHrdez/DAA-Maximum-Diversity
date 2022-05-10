/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Tabu</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Approximated;

/// <summary>
/// Class that represents the tabu search algorithm.
/// </summary>
public class Tabu : Algorithm {
  /// <summary>
  /// Runs the tabu search algorithm.
  /// </summary>
  /// <param name="maxLength">The maximum length of the solution.</param>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run(int maxLength) {
    return this.vectors;
  }
}
