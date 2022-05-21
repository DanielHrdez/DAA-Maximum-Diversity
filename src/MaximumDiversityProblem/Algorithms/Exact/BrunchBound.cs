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
  private float[] distances;
  private int[] fibonacciNumbers;
  private int numberCombinations;
  private bool useGrasp;
  private bool useDepthFirst;
  private Queue<VectorsUpperLimit> queue;
  private List<VectorsUpperLimit> list;

  /// <summary>
  /// Default Constructor of the class.
  /// </summary>
  public BrunchBound() : base() {
    this.lowerBound = 0;
    this.nodesCount = 0;
    this.distances = new float[0];
    this.numberCombinations = 0;
    this.useGrasp = false;
    this.useDepthFirst = false;
    this.queue = new Queue<VectorsUpperLimit>();
    this.list = new List<VectorsUpperLimit>();
    this.fibonacciNumbers = new int[0];
  }

  public void UseGrasp(bool useGrasp) {
    this.useGrasp = useGrasp;
  }

  public void UseDepthFirst(bool useDepthFirst) {
    this.useDepthFirst = useDepthFirst;
  }

  /// <summary>
  /// Search for the maximum distance of the solution.
  /// </summary>
  private void SortMaxDistance() {
    this.distances = new float[this.vectors.Count * this.vectors.Count];
    float[][] distances = this.vectors.Vectors.distanceMatrix;
    for (int i = 0; i < distances.Length - 1; i++) {
      for (int j = i + 1; j < distances[i].Length; j++) {
        this.distances[i * distances.Length + j] = distances[i][j];
      }
    }
    this.MergeSort(this.distances, 0, this.distances.Length - 1);
  }

  private void MergeSort(float[] array, int start, int end) {
    if (start < end) {
      int middle = (start + end) / 2;
      this.MergeSort(array, start, middle);
      this.MergeSort(array, middle + 1, end);
      this.Merge(array, start, middle, end);
    }
  }

  private void Merge(float[] array, int start, int middle, int end) {
    float[] left = new float[middle - start + 1];
    float[] right = new float[end - middle];
    for (int l = 0; l < left.Length; l++) {
      left[l] = array[start + l];
    }
    for (int m = 0; m < right.Length; m++) {
      right[m] = array[middle + 1 + m];
    }
    int i = 0;
    int j = 0;
    int k = start;
    while (i < left.Length && j < right.Length) {
      if (left[i] >= right[j]) {
        array[k] = left[i];
        i++;
      } else {
        array[k] = right[j];
        j++;
      }
      k++;
    }
    while (i < left.Length) {
      array[k] = left[i];
      i++;
      k++;
    }
    while (j < right.Length) {
      array[k] = right[j];
      j++;
      k++;
    }
  }

  private int[] CalcFibonacciNumbers(int max) {
    int[] fibonacciNumbers = new int[max];
    for (int i = 0; i < fibonacciNumbers.Length; i++) {
      fibonacciNumbers[i] = this.Fibonacci(i + 1);
    }
    return fibonacciNumbers;
  }

  /// <summary>
  /// Runs the BrunchBound search algorithm.
  /// </summary>
  /// <returns>The vectors distance.</returns>
  public override VectorsDistance Run() {
    this.nodesCount = 0;
    this.fibonacciNumbers = this.CalcFibonacciNumbers(this.maxLength);
    this.numberCombinations = this.fibonacciNumbers[this.maxLength - 1];
    this.SortMaxDistance();
    if (!useGrasp) this.vectors = new Greedy(this).Run();
    else this.vectors = new Grasp(this, 3, 20).Run();
    this.lowerBound = this.vectors.Distance;
    if (this.useDepthFirst) {
      this.queue = new Queue<VectorsUpperLimit>();
      this.PopulateCandidatesQueue(new VectorsDistance(this.vectors.Vectors));
      while (this.queue.Count > 0) {
        VectorsDistance currentVector = this.SelectCandidateQueue();
        this.PopulateCandidatesQueue(currentVector);
        nodesCount++;
      }
    } else {
      this.list = new List<VectorsUpperLimit>();
      this.PopulateCandidatesList(new VectorsDistance(this.vectors.Vectors));
      while (this.list.Count > 0) {
        VectorsDistance currentVector = this.SelectCandidateList();
        this.PopulateCandidatesList(currentVector);
        nodesCount++;
      }
    }
    return this.vectors;
  }

  /// <summary>
  /// Return all the candidates of the current solution.
  /// </summary>
  /// <returns>A list of vectors distance.</returns>
  private void PopulateCandidatesList(VectorsDistance vectors) {
    for (int i = 0; i < vectors.Count; i++) {
      if (!vectors.Indices[i]) {
        VectorsUpperLimit candidate = new VectorsUpperLimit(vectors);
        candidate.AddVector(i);
        if (candidate.LengthSolution >= this.maxLength) {
          if (candidate.Distance > this.lowerBound) {
            this.vectors = candidate.Vectors;
            this.lowerBound = candidate.Distance;
            for (int j = 0; j < this.list.Count; j++) {
              if (this.list[j].UpperLimit <= this.lowerBound) {
                this.list.RemoveAt(j);
                j--;
              }
            }
          }
        } else {
          this.SetUpperLimit(candidate);
          if (candidate.UpperLimit > this.lowerBound) {
            this.list.Add(candidate);
          }
        }
      }
    }
  }

  /// <summary>
  /// Return all the candidates of the current solution.
  /// </summary>
  /// <returns>A list of vectors distance.</returns>
  private void PopulateCandidatesQueue(VectorsDistance vectors) {
    for (int i = 0; i < vectors.Count; i++) {
      if (!vectors.Indices[i]) {
        VectorsUpperLimit candidate = new VectorsUpperLimit(vectors);
        candidate.AddVector(i);
        if (candidate.LengthSolution >= this.maxLength) {
          if (candidate.Distance > this.lowerBound) {
            this.vectors = candidate.Vectors;
            this.lowerBound = candidate.Distance;
            this.queue = new Queue<VectorsUpperLimit>(
              this.queue.Where(x => x.UpperLimit > this.lowerBound)
            );
          }
        } else {
          this.SetUpperLimit(candidate);
          if (candidate.UpperLimit > this.lowerBound) {
            this.queue.Enqueue(candidate);
          }
        }
      }
    }
  }

  /// <summary> 
  /// Set the upper limit of the current solution.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  private void SetUpperLimit(VectorsUpperLimit vectors) {
    vectors.UpperLimit = vectors.Distance;
    int max = this.numberCombinations - this.fibonacciNumbers[vectors.LengthSolution - 1];
    for (int i = 0; i < max; i++) {
      vectors.UpperLimit += this.distances[i];
    }
  }

  /// <summary>
  /// Calcs the fibonacci number.
  /// </summary>
  /// <param name="number">The number.</param>
  /// <returns>The fibonacci number.</returns>
  private int Fibonacci(int number) {
    if (number == 1) return 0;
    int numberMinus1 = number - 1;
    return this.Fibonacci(numberMinus1) + numberMinus1;
  }

  /// <summary>
  /// Select the maximum candidate.
  /// </summary>
  /// <returns>The vectors with maximum distance.</returns>
  private VectorsDistance SelectCandidateList() {
    VectorsUpperLimit candidate = this.list[0];
    int index = 0;
    for (int i = 1; i < this.list.Count; i++) {
      if (this.list[i].UpperLimit < candidate.UpperLimit) {
        candidate = this.list[i];
        index = i;
      }
    }
    this.list.RemoveAt(index);
    return candidate.Vectors;
  }

  /// <summary>
  /// Select the maximum candidate.
  /// </summary>
  /// <returns>The vectors with maximum distance.</returns>
  private VectorsDistance SelectCandidateQueue() {
    return this.queue.Dequeue().Vectors;
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
