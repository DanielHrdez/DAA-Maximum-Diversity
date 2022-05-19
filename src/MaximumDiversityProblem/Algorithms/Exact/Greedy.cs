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
  /// Default constructor.
  /// </summary>
  public Greedy() : base() {}

  /// <summary>
  /// Constructor with algorithm.
  /// </summary>
  /// <param name="algorithm">Algorithm type.</param>
  public Greedy(Algorithm algorithm) : base(algorithm) {}

  /// <summary>
  /// Constructor with algorithm.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  public Greedy(VectorsDistance vectors, int maxLength) {
    this.vectors = vectors;
    this.maxLength = maxLength;
    this.CheckParameters();
  }

  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    Vector center = this.vectors.Center();
    int farthest = this.vectors.FarthestFrom(center);
    this.vectors.AddVector(farthest);
    while (this.vectors.LengthSolution != this.maxLength) {
      center = this.vectors.Center(true);
      farthest = this.vectors.FarthestFrom(center);
      this.vectors.AddVector(farthest);
    }
    return this.vectors;
  }
}
