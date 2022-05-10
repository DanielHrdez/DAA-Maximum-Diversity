/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Greedy</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Exact;

/// <summary>
/// Greedy algorithm.
/// </summary>
public class Greedy : Algorithm {
  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <param name="maxLength">The maximum length.</param>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run(int maxLength) {
    this.CheckParameters(maxLength);
    Vector center = this.vectors.Center();
    while (this.vectors.LengthSolution != maxLength) {
      Vector farthest = this.vectors.FarthestFrom(center);
      this.vectors.AddVector(farthest);
      center = this.vectors.Center();
    }
    return this.vectors;
  }
}
