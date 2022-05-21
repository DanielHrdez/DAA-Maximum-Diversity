/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Tabu</enum>

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms.Exact;

namespace MaximumDiversityProblem.Algorithms.Approximated;

/// <summary>
/// Class that represents the tabu search algorithm.
/// </summary>
public class Tabu : Approximated {
  private int maxTabuList;
  private Queue<VectorsDistance> tabuList;

  /// <summary>
  /// Constructor of the tabu search algorithm.
  /// </summary>
  public Tabu(): base() {
    this.maxTabuList = 0;
    this.tabuList = new Queue<VectorsDistance>();
  }

  /// <summary>
  /// Constructor of the tabu search algorithm.
  /// </summary>
  /// <param name="maxTabuList">The maximum size of the tabu list.</param>
  /// <param name="iterations">The number of iterations.</param>
  public Tabu(int maxTabuList, int iterations): base(iterations) {
    this.maxTabuList = maxTabuList;
    this.tabuList = new Queue<VectorsDistance>();
  }

  /// <summary>
  /// Setter of the maximum size of the tabu list.
  /// </summary>
  /// <param name="maxTabuList">The maximum size of the tabu list.</param>
  public void SetMaxTabuList(int maxTabuList) {
    this.maxTabuList = maxTabuList;
  }

  /// <summary>
  /// Runs the tabu search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    this.vectors = new VectorsDistance(this.vectors.Vectors);
    this.vectors = new Greedy(this).Run();
    VectorsDistance bestCandidate = this.vectors;
    this.tabuList = new Queue<VectorsDistance>();
    this.tabuList.Enqueue(this.vectors);
    for (int i = 0; i < this.iterations; i++) {
      List<VectorsDistance> neighbors = this.localSearch.Neighbors(bestCandidate);
      bestCandidate = neighbors[0];
      for (int j = 0; j < neighbors.Count; j++) {
        if (this.tabuList.Contains(neighbors[j])) continue;
        if (neighbors[j].Distance > bestCandidate.Distance) {
          bestCandidate = neighbors[j];
        }
      }
      if (bestCandidate.Distance > this.vectors.Distance) {
        this.vectors = bestCandidate;
      }
      this.tabuList.Enqueue(bestCandidate);
      if (this.tabuList.Count > this.maxTabuList) {
        this.tabuList.Dequeue();
      }
    }
    return this.vectors;
  }
}
