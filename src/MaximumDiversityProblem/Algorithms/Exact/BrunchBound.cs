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
  private double maxDistance;
  private int numberCombinations;
  private double[] maxDistances;

  public BrunchBound() {
    this.lowerBound = 0;
    this.nodesCount = 0;
    this.maxDistance = 0;
    this.numberCombinations = 0;
    this.maxDistances = new double[0];
  }

  private void SearchMaxDistance() {
    this.maxDistance = 0;
    for (int i = 0; i < this.vectors.Count - 1; i++) {
      for (int j = i + 1; j < this.vectors.Count; j++) {
        double distance = this.vectors.Vectors[i].Distance(this.vectors.Vectors[j]);
        if (distance > this.maxDistance) {
          this.maxDistance = distance;
        }
      }
    }
  }

  private double[] CreateDistanceMatrix() {
    double[] distanceList = new double[this.vectors.Count * this.vectors.Count];
    for (int i = 0; i < this.vectors.Count - 1; i++) {
      for (int j = 1; j < this.vectors.Count; j++) {
        distanceList[i * this.vectors.Count + j] =
            this.vectors.Vectors[i].Distance(this.vectors.Vectors[j]);
      }
    }
    return distanceList;
  }

  private double[] CreateMaxDistances() {
    double[] distanceList = this.CreateDistanceMatrix();
    this.maxDistances = new double[this.numberCombinations];
    Array.Sort(distanceList);
    int countSq = this.vectors.Count * this.vectors.Count - 1;
    for (int i = 0; i < this.numberCombinations; i++) {
      this.maxDistances[i] = distanceList[countSq - i];
    }
    return this.maxDistances;
  }

  /// <summary>
  /// Runs the BrunchBound search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    this.numberCombinations = this.Fibonacci(this.maxLength);
    this.SearchMaxDistance();
    // this.CreateMaxDistances();
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
    vectors.UpperLimit = vectors.Distance + this.maxDistance *
        (this.numberCombinations - vectors.LengthSolution);
    // vectors.UpperLimit = vectors.Distance;
    // int max = this.numberCombinations - vectors.LengthSolution;
    // for (int i = 0; i < max; i++) {
    //   vectors.UpperLimit += this.maxDistances[i];
    // }
  }

  private int Fibonacci(int number) {
    if (number == 2) return 1;
    return this.Fibonacci(number - 1) + number - 1;
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
