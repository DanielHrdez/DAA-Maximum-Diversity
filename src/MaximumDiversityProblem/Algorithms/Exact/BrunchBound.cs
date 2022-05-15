/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>BrunchBound</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Exact;

/// <summary>
/// Class that represents the brunch bound algorithm.
/// </summary>
public class BrunchBound : Algorithm {
  private double lowerBound;
  private int nodesCount;

  /// <summary>
  /// Runs the BrunchBound search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    this.vectors = new Greedy(this).Run();
    this.lowerBound = this.vectors.Distance;
    List<VectorsDistance> queue = new List<VectorsDistance>();
    queue.AddRange(
      this.populateCandidates(new VectorsDistance(this.vectors.Vectors))
    );
    while (queue.Count > 0) {
      VectorsDistance currentVector = this.selectCandidate(queue);
      queue.AddRange(this.populateCandidates(currentVector));
    }
    return this.vectors;
  }

  /// <summary>
  /// Return all the candidates of the current solution.
  /// </summary>
  /// <returns>A list of vectors distance.</returns>
  private List<VectorsDistance> populateCandidates(VectorsDistance vectors) {
    List<VectorsDistance> candidates = new List<VectorsDistance>();
    for (int i = 0; i < vectors.Count; i++) {
      if (!vectors.Indices[i]) {
        VectorsDistance candidate = new VectorsDistance(vectors);
        candidate.AddVector(i);
        if (candidate.LengthSolution >= this.maxLength) {
          if (candidate.Distance > this.lowerBound) {
            this.vectors = candidate;
            this.lowerBound = candidate.Distance;
          }
        } else {
          double idealDistance = new Greedy(
              new VectorsDistance(candidate),
              this.maxLength
          ).Run().Distance;
          if (idealDistance + 1 > this.lowerBound) {
            candidates.Add(candidate);
            nodesCount++;
          }
        }
      }
    }
    return candidates;
  }

  /// <summary>
  /// Select the maximum candidate.
  /// </summary>
  /// <returns>The vectors with maximum distance.</returns>
  private VectorsDistance selectCandidate(List<VectorsDistance> queue) {
    VectorsDistance candidate = queue[0];
    for (int i = 1; i < queue.Count; i++) {
      if (queue[i].Distance > candidate.Distance) {
        candidate = queue[i];
      }
    }
    queue.Remove(candidate);
    return candidate;
  }

  /// <summary>
  /// Returns the count of nodes visited.
  /// </summary>
  /// <returns>The count of nodes visited.</returns>
  public int NodesCount {
    get {
      return this.nodesCount;
    }
  }
}
