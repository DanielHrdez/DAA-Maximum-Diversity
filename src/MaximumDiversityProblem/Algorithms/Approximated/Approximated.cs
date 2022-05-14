/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Approximated</enum>

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms.Approximated.LocalSearch;

namespace MaximumDiversityProblem.Algorithms.Approximated;

/// <summary>
/// Abstract class that represents an approximated algorithm.
/// </summary>
public abstract class Approximated : Algorithm {
  protected int iterations;
  protected Swap localSearch;

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="iterations">Number of iterations.</param>
  public Approximated(int iterations) : base() {
    this.iterations = iterations;
    this.localSearch = new Swap();
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors to be used.</param>
  /// <param name="iterations">Number of iterations.</param>
  /// <param name="maxLength">Maximum length of the solution.</param>
  public Approximated(Vectors vectors, int iterations, int maxLength) : base(vectors, maxLength) {
    this.iterations = iterations;
    this.localSearch = new Swap();
  }

  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  protected VectorsDistance Search(VectorsDistance solution) {
    return this.localSearch.Search(solution);
  }
}
