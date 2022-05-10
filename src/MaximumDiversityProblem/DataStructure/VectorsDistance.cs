/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>VectorsDistance</class>

namespace MaximumDiversityProblem.DataStructure;

/// <summary>
/// Class that represents vectors with distances.
/// </summary>
public class VectorsDistance {
  private Vectors vectors;
  private double distance;
  private List<bool> indices;
  private Vectors solution;
  
  /// <summary>
  /// Default Constructor of the class.
  /// </summary>
  public VectorsDistance() {
    this.distance = 0;
    this.indices = new List<bool>();
    this.solution = new Vectors();
    this.vectors = new Vectors();
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  public VectorsDistance(Vectors vectors) {
    this.distance = 0;
    this.indices = new List<bool>();
    for (int i = 0; i < vectors.Count; i++) {
      this.indices.Add(false);
    }
    this.solution = new Vectors();
    this.vectors = new Vectors(vectors);
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  /// <param name="distance">Distance of the vectors.</param>
  public VectorsDistance(Vectors vectors, double distance) : this(vectors) {
    this.distance = distance;
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectorsDistance">Vectors with distances.</param>
  public VectorsDistance(VectorsDistance vectorsDistance) {
    this.distance = vectorsDistance.distance;
    this.indices = new List<bool>(vectorsDistance.indices);
    this.solution = new Vectors(vectorsDistance.solution);
    this.vectors = new Vectors(vectorsDistance.vectors);
  }

  /// <summary>
  /// Adds a vector to the solution.
  /// </summary>
  /// <param name="vector">Vector.</param>
  /// <returns>True if the vector was added, false otherwise.</returns>
  public bool AddVector(Vector vector) {
    int index = this.vectors.IndexOf(vector);
    if (index != -1) {
      this.indices[index] = true;
      for (int i = 0; i < this.solution.Count; i++) {
        this.distance += vector.Distance(this.solution[i]);
      }
      this.solution.AddVector(vector);
      return true;
    }
    return false;
  }

  /// <summary>
  /// Removes a vector from the solution.
  /// </summary>
  /// <param name="vector">Vector.</param>
  /// <returns>True if the vector was removed, false otherwise.</returns>
  private bool RemoveVector(Vector vector) {
    int index = this.vectors.IndexOf(vector);
    if (index != -1) {
      this.indices[index] = false;
      this.solution.RemoveVector(vector);
      for (int i = 0; i < this.solution.Count; i++) {
        this.distance -= vector.Distance(this.solution[i]);
      }
      return true;
    }
    return false;
  }

  /// <summary>
  /// Swaps two vectors from the total with the solution.
  /// </summary>
  /// <param name="index1">Index of the first vector.</param>
  /// <param name="index2">Index of the second vector.</param>
  /// <returns>A copy of the vectors with the swapped vectors.</returns>
  public VectorsDistance Swap(int index1, int index2) {
    VectorsDistance newSolution = new VectorsDistance(this);
    newSolution.AddVector(this.vectors[index1]);
    newSolution.RemoveVector(this.vectors[index2]);
    return newSolution;
  }

  /// <summary>
  /// Getter of the number of vectors.
  /// </summary>
  /// <returns>Number of vectors.</returns>
  public int Count {
    get {
      return this.vectors.Count;
    }
  }

  /// <summary>
  /// Getter and Setter of the distance.
  /// </summary>
  /// <returns>Distance.</returns>
  public double Distance {
    get {
      return this.distance;
    }
    set {
      this.distance = value;
    }
  }

  /// <summary>
  /// Getter of the length of the solution.
  /// </summary>
  /// <returns>Length of the solution.</returns>
  public int LengthSolution {
    get {
      return this.solution.Count;
    }
  }

  /// <summary>
  /// Getter of the Indices of the solution.
  /// </summary>
  /// <returns>Indices of the solution.</returns>
  public List<bool> Indices {
    get {
      return this.indices;
    }
  }

  /// <summary>
  /// String representation of the class.
  /// </summary>
  /// <returns>String representation of the class.</returns>
  public override string ToString() {
    string distance = this.distance.ToString().Replace(",", ".");
    string indices = "[";
    foreach (bool value in this.indices) {
      indices += value ? "1, " : "0, ";
    }
    indices = indices.Substring(0, indices.Length - 2);
    indices += "]";
    return $"\u001b[32mVectors:\u001b[0m\n{this.solution.ToString()}\n" +
        $"\u001b[32mIndices:\u001b[0m\n{indices}\n" +
        $"\u001b[32mDistance:\u001b[0m\n{distance}\n";
  }

  /// <summary>
  /// Return the center of the solution.
  /// </summary>
  /// <returns>Center of the solution.</returns>
  public Vector Center() {
    if (this.solution.Count == 0) {
      return this.vectors.Center();
    }
    return this.solution.Center();
  }

  /// <summary>
  /// Return the farthest vector from the given vector.
  /// </summary>
  /// <param name="from">Vector.</param>
  /// <returns>Farthest vector from the given vector.</returns>
  public Vector FarthestFrom(Vector from) {
    return this.vectors.FarthestFrom(from, this.indices);
  }

  /// <summary>
  /// Override of the [] operator.
  /// </summary>
  /// <param name="index">Index of the vector.</param>
  /// <returns>Vector.</returns>
  public bool this[int index] {
    get {
      return this.indices[index];
    }
  }
}
