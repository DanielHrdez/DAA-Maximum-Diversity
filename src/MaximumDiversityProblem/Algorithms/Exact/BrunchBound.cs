/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>BrunchBound</enum>

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms.Approximated;

namespace MaximumDiversityProblem.Algorithms.Exact;

/// <summary>
/// Class that represents the brunch bound algorithm.
/// </summary>
public class BrunchBound : Algorithm {
  private float lowerBound;
  private int nodesCount;
  private float maxDistance;
  private int numberCombinations;
  private bool useGrasp;
  private bool strategy;
  private List<VectorsUpperLimit> queue;

  /// <summary>
  /// Default Constructor of the class.
  /// </summary>
  public BrunchBound() : base() {
    this.lowerBound = 0;
    this.nodesCount = 0;
    this.maxDistance = 0;
    this.numberCombinations = 0;
    this.useGrasp = false;
    this.strategy = false;
    this.queue = new List<VectorsUpperLimit>();
  }

  public void UseGrasp(bool useGrasp) {
    this.useGrasp = useGrasp;
  }

  public void Strategy(bool strategy) {
    this.strategy = strategy;
  }

  /// <summary>
  /// Search for the maximum distance of the solution.
  /// </summary>
  private void SearchMaxDistance() {
    this.maxDistance = 0;
    for (int i = 0; i < this.vectors.Count - 1; i++) {
      for (int j = i + 1; j < this.vectors.Count; j++) {
        float distance = this.vectors.Vectors[i].Distance(this.vectors.Vectors[j]);
        if (distance > this.maxDistance) {
          this.maxDistance = distance;
        }
      }
    }
  }

  /// <summary>
  /// Runs the BrunchBound search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    this.nodesCount = 0;
    this.numberCombinations = this.Fibonacci(this.maxLength);
    this.SearchMaxDistance();
    if (!useGrasp) this.vectors = new Greedy(this).Run();
    else this.vectors = new Grasp(this, 3, 20).Run();
    this.lowerBound = this.vectors.Distance;
    this.queue = new List<VectorsUpperLimit>();
    this.queue.AddRange(
      this.PopulateCandidates(new VectorsDistance(this.vectors.Vectors))
    );
    while (this.queue.Count > 0) {
      VectorsDistance currentVector = this.SelectCandidate();
      this.queue.AddRange(this.PopulateCandidates(currentVector));
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
            for (int j = 0; j < this.queue.Count; j++) {
              if (this.queue[j].UpperLimit <= this.lowerBound) {
                this.queue.RemoveAt(j);
                j--;
              }
            }
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

  /// <summary> 
  /// Set the upper limit of the current solution.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  private void SetUpperLimit(VectorsUpperLimit vectors) {
    vectors.UpperLimit = vectors.Distance + this.maxDistance *
        (this.numberCombinations - vectors.LengthSolution);
  }

  /// <summary>
  /// Calcs the fibonacci number.
  /// </summary>
  /// <param name="number">The number.</param>
  /// <returns>The fibonacci number.</returns>
  private int Fibonacci(int number) {
    if (number == 2) return 1;
    return this.Fibonacci(number - 1) + number - 1;
  }

  /// <summary>
  /// Select the maximum candidate.
  /// </summary>
  /// <returns>The vectors with maximum distance.</returns>
  private VectorsDistance SelectCandidate() {
    if (!this.strategy) {
      VectorsUpperLimit candidate = this.queue[0];
      for (int i = 1; i < this.queue.Count; i++) {
        if (this.queue[i].UpperLimit < candidate.UpperLimit) {
          candidate = this.queue[i];
        }
      }
      this.queue.Remove(candidate);
      return candidate.Vectors;
    } else {
      VectorsUpperLimit candidate = this.queue[0];
      this.queue.Remove(candidate);
      return candidate.Vectors;
    }
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
