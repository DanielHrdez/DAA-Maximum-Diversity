/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Grasp</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Approximated;

/// <summary>
/// Class that represents the grasp algorithm.
/// </summary>
public class Grasp : Approximated {
  private int candidates;

  /// <summary>
  /// Constructor of the Grasp class.
  /// </summary>
  public Grasp() : base() {
    this.candidates = 0;
  }

  /// <summary>
  /// Constructor of the Grasp class.
  /// </summary>
  /// <param name="candidates">The number of candidates.</param>
  /// <param name="iterations">The number of iterations.</param>
  public Grasp(int candidates, int iterations) : base(iterations) {
    this.candidates = candidates;
  }

  public void SetCandidates(int candidates) {
    this.candidates = candidates;
  }

  /// <summary>
  /// Runs the grasp search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    for (int i = 0; i < this.iterations; i++) {
      VectorsDistance solution = this.RandomGreedy();
      solution = this.Search(solution);
      if (solution.Distance > this.vectors.Distance) {
        this.vectors = solution;
      }
    }
    return this.vectors;
  }

  /// <summary>
  /// Runs the random greedy algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  private VectorsDistance RandomGreedy() {
    VectorsDistance solution = new VectorsDistance(this.vectors.Vectors);
    Vector center = solution.Center();
    int[] farthest = solution.FarthestsFrom(center, this.candidates);
    int random = farthest[new Random().Next(farthest.Length)];
    solution.AddVector(random);
    while (solution.LengthSolution != this.maxLength) {
      center = solution.CenterSolution();
      farthest = solution.FarthestsFrom(center, this.candidates);
      random = farthest[new Random().Next(farthest.Length)];
      solution.AddVector(random);
    }
    return solution;
  }
}
