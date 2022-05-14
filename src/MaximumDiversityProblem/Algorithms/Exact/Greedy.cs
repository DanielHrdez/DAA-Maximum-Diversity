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
  public Greedy() : base() {}

  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    while (this.vectors.LengthSolution != this.maxLength) {
      Vector center = this.vectors.Center();
      int farthest = this.vectors.FarthestFrom(center);
      this.vectors.AddVector(farthest);
    }
    return this.vectors;
  }
}
