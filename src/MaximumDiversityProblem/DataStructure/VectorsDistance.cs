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
  private bool[] indices;
  private int length;
  
  /// <summary>
  /// Default Constructor of the class.
  /// </summary>
  public VectorsDistance() {
    this.distance = 0;
    this.indices = new bool[0];
    this.vectors = new Vectors();
    this.length = 0;
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  public VectorsDistance(Vectors vectors) {
    this.distance = 0;
    this.indices = new bool[vectors.Count];
    this.vectors = new Vectors(vectors);
    this.length = 0;
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
    this.indices = new bool[vectorsDistance.indices.Length];
    for (int i = 0; i < vectorsDistance.indices.Length; i++) {
      this.indices[i] = vectorsDistance.indices[i];
    }
    this.vectors = new Vectors(vectorsDistance.vectors);
    this.length = vectorsDistance.length;
  }

  /// <summary>
  /// Adds a vector to the solution.
  /// </summary>
  /// <param name="vector">Vector.</param>
  /// <returns>True if the vector was added, false otherwise.</returns>
  public bool AddVector(Vector vector) {
    int index = this.vectors.IndexOf(vector);
    if (index != -1) {
      for (int i = 0; i < this.vectors.Count; i++) {
        if (this.indices[i]) {
          this.distance += vector.Distance(this.vectors[i]);
        }
      }
      this.indices[index] = true;
      this.length++;
      return true;
    }
    return false;
  }

  /// <summary>
  /// Adds a vector to the solution.
  /// </summary>
  /// <param name="index">Vector.</param>
  /// <param name="ignore">Vector to ignore.</param>
  /// <returns>True if the vector was added, false otherwise.</returns>
  public bool AddVector(int index, int ignore) {
    Vector vector = this.vectors[index];
    for (int i = 0; i < this.vectors.Count; i++) {
      if (this.indices[i] && i != ignore) {
        this.distance += vector.Distance(this.vectors[i]);
      }
    }
    this.indices[index] = true;
    this.length++;
    return true;
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
      for (int i = 0; i < this.vectors.Count; i++) {
        if (this.indices[i]) {
          this.distance -= vector.Distance(this.vectors[i]);
        }
      }
      this.length--;
      return true;
    }
    return false;
  }

  /// <summary>
  /// Removes a vector from the solution.
  /// </summary>
  /// <param name="index">Vector.</param>
  /// <param name="ignore">Vector to ignore.</param>
  /// <returns>True if the vector was removed, false otherwise.</returns>
  private bool RemoveVector(int index, int ignore) {
    Vector vector = this.vectors[index];
    this.indices[index] = false;
    for (int i = 0; i < this.vectors.Count; i++) {
      if (this.indices[i] && i != ignore) {
        this.distance -= vector.Distance(this.vectors[i]);
      }
    }
    this.length--;
    return true;
  }

  /// <summary>
  /// Swaps two vectors from the total with the solution.
  /// </summary>
  /// <param name="index1">Index of the first vector.</param>
  /// <param name="index2">Index of the second vector.</param>
  /// <returns>A copy of the vectors with the swapped vectors.</returns>
  public VectorsDistance Swap(int index1, int index2) {
    VectorsDistance newSolution = new VectorsDistance(this);
    newSolution.AddVector(index1, index2);
    newSolution.RemoveVector(index2, index1);
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
      return this.length;
    }
  }

  /// <summary>
  /// Getter of the Indices of the solution.
  /// </summary>
  /// <returns>Indices of the solution.</returns>
  public bool[] Indices {
    get {
      return this.indices;
    }
  }

  /// <summary>
  /// Getter of the number of components.
  /// </summary>
  /// <returns>Number of components.</returns>
  public int Components {
    get {
      return this.vectors.Components;
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
    string vectorString = "";
    for (int i = 0; i < this.vectors.Count; i++) {
      if (this.indices[i]) {
        vectorString += this.vectors[i].ToString() + '\n';
      }
    }
    vectorString = vectorString.Substring(0, vectorString.Length - 1);
    return ToGreen("Vectors:") + $"\n{vectorString}\n" +
        ToGreen("Indices:") + $"\n{indices}\n" +
        ToGreen("Distance:") + $"\n{distance}\n";
  }

  /// <summary>
  /// Converts to green.
  /// </summary>
  /// <param name="text">Text to be converted.</param>
  /// <returns>Text in green.</returns>
  private static string ToGreen(string text) {
    return $"\u001b[32m{text}\u001b[0m";
  }

  /// <summary>
  /// Return the center of the solution.
  /// </summary>
  /// <returns>Center of the solution.</returns>
  public Vector Center() {
    if (this.length == 0) {
      return this.vectors.Center();
    }
    Vector center = new Vector(new double[this.Components]);
    for (int i = 0; i < this.Components; i++) {
      for (int j = 0; j < this.Count; j++) {
        if (this.indices[j]) {
          center[i] += this.vectors[j, i];
        }
      }
      center[i] /= this.length;
    }
    return center;
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

  /// <summary>
  /// Override of the [,] operator.
  /// </summary>
  /// <param name="index1">Index1 of the vector.</param>
  /// <param name="index2">Index2 of the vector.</param>
  /// <returns>Vector.</returns>
  public bool this[int index1, int index2] {
    get {
      return this.indices[index1] || !this.indices[index2];
    }
  }
}
