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
  private double[][] distanceMatrix;
  private double maxDistance;

  public BrunchBound() {
    this.lowerBound = 0;
    this.nodesCount = 0;
    this.distanceMatrix = this.CreateDistanceMatrix();
    this.maxDistance = this.SearchMaxDistance();
  }

  private double SearchMaxDistance() {
    double maxDistance = 0;
    for (int i = 0; i < this.nodesCount; i++) {
      for (int j = i + 1; j < this.nodesCount; j++) {
        if (this.distanceMatrix[i][j] > maxDistance) {
          maxDistance = this.distanceMatrix[i][j];
        }
      }
    }
    return maxDistance;
  }

  private double[][] CreateDistanceMatrix() {
    int length = this.vectors.Count;
    double[][] distanceMatrix = new double[length][];
    for (int i = 0; i < length; i++) {
      distanceMatrix[i] = new double[length];
      for (int j = 0; j < length; j++) {
        distanceMatrix[i][j] = this.vectors.Vectors[i].Distance(this.vectors.Vectors[j]);
      }
    }
    return distanceMatrix;
  }

  /// <summary>
  /// Runs the BrunchBound search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    this.vectors = new Greedy(this).Run();
    this.lowerBound = this.vectors.Distance;
    List<VectorsUpperLimit> queue = new List<VectorsUpperLimit>();
    queue.AddRange(
      this.PopulateCandidates(new VectorsDistance(this.vectors.Vectors))
    );
    while (queue.Count > 0) {
      VectorsDistance currentVector = this.SelectCandidate(queue);
      queue.AddRange(this.PopulateCandidates(currentVector));
    }
    return this.vectors;
  }

  /// <summary>
  /// Return all the candidates of the current solution.
  /// </summary>
  /// <returns>A list of vectors distance.</returns>
  private List<VectorsUpperLimit> PopulateCandidates(VectorsDistance vectors) {
    List<VectorsUpperLimit> candidates = new List<VectorsUpperLimit>();
    for (int i = 0; i < vectors.Count; i++) {
      if (!vectors.Indices[i]) {
        VectorsUpperLimit candidate = new VectorsUpperLimit(vectors);
        candidate.AddVector(i);
        if (candidate.LengthSolution >= this.maxLength) {
          if (candidate.Distance > this.lowerBound) {
            this.vectors = candidate.Vectors;
            this.lowerBound = candidate.Distance;
          }
        } else {
          this.SetUpperLimit(candidate);
          if (candidate.UpperLimit > this.lowerBound) {
            candidates.Add(candidate);
            nodesCount++;
          }
        }
      }
    }
    return candidates;
  }

  private void SetUpperLimit(VectorsUpperLimit vectors) {
    int length = this.distanceMatrix.Length;
    vectors.UpperLimit = vectors.Distance + this.maxDistance *
        (this.Fibonacci(length, new int[2]) - this.Fibonacci(vectors.LengthSolution, new int[2]));
  }

  private int Fibonacci(int number, int[] result) {
    int a, b, c, d;
    int MOD = 1000000007;
    if (number == 0) {
      result[0] = 0;
      result[1] = 1;
      return result[0];
    }
    this.Fibonacci((number / 2), result);
    a = result[0];
    b = result[1];
    c = 2 * b - a;
    if (c < 0) c += MOD;
    c = (a * c) % MOD;
    d = (a * a + b * b) % MOD;
    if (number % 2 == 0) {
      result[0] = c;
      result[1] = d;
    } else {
      result[0] = d;
      result[1] = c + d;
    }
    return result[0];
  }

  /// <summary>
  /// Select the maximum candidate.
  /// </summary>
  /// <returns>The vectors with maximum distance.</returns>
  private VectorsDistance SelectCandidate(List<VectorsUpperLimit> queue) {
    VectorsUpperLimit candidate = queue[0];
    for (int i = 1; i < queue.Count; i++) {
      if (queue[i].Distance > candidate.Distance) {
        candidate = queue[i];
      }
    }
    queue.Remove(candidate);
    return candidate.Vectors;
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
