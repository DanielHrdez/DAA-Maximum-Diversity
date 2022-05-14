/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Grasp</enum>

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms.Exact;

namespace MaximumDiversityProblem.Algorithms.Approximated;

/// <summary>
/// Class that represents the grasp algorithm.
/// </summary>
public class Grasp : Algorithm {
  private int candidates;
  private int iterations;

  public Grasp(int candidates, int iterations) : base() {
    this.candidates = candidates;
    this.iterations = iterations;
  }

  /// <summary>
  /// Runs the grasp search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    for (int i = 0; i < this.iterations; i++) {
      VectorsDistance solution = this.RandomGreedy();
      solution = this.Search();
      if (solution.Distance > this.vectors.Distance) {
        this.vectors = solution;
      }
    }
    return this.vectors;
  }

  private VectorsDistance RandomGreedy() {
    VectorsDistance solution = new VectorsDistance(this.vectors.Vectors);
    while (solution.LengthSolution != this.maxLength) {
      Vector center = solution.Center();
      int[] farthest = solution.FarthestsFrom(center, this.candidates);
      int random = farthest[new Random().Next(farthest.Length)];
      solution.AddVector(random);
    }
    return solution;
  }
}
