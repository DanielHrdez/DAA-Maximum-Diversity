/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>Vectors</class>

using System.Collections;

namespace MaximumDiversityProblem.DataStructure;

/// <summary>
/// Class that represents a set of vectors.
/// </summary>
public class Vectors : IEnumerable {
  public Vector[] vectors;

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  public Vectors() {
    this.vectors = new Vector[0];
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  public Vectors(Vectors vectors) {
    this.vectors = new Vector[vectors.Count];
    for (int i = 0; i < vectors.Count; i++) {
      this.vectors[i] = vectors[i];
    }
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="numberVectors">Number of vectors.</param>
  /// <param name="numberElements">Number of elements.</param>
  public Vectors(int numberVectors, int numberElements) {
    this.vectors = new Vector[numberVectors];
    for (int i = 0; i < numberVectors; i++) {
      this.vectors[i] = new Vector(numberElements);
    }
  }

  /// <summary>
  /// Gets the number of vectors.
  /// </summary>
  /// <returns>Number of vectors.</returns>
  public int Count {
    get {
      return this.vectors.Length;
    }
  }

  /// <summary>
  /// Gets the number of components.
  /// </summary>
  /// <returns>Number of components.</returns>
  public int Components {
    get {
      return this.vectors[0].Count;
    }
  }

  /// <summary>
  /// Overrides the [] operator.
  /// </summary>
  /// <param name="index">Index.</param>
  /// <returns>Vector.</returns>
  public Vector this[int index] {
    get {
      return vectors[index];
    }
    set {
      vectors[index] = value;
    }
  }

  /// <summary>
  /// Overrides the [,] operator.
  /// </summary>
  /// <param name="index1">Index 1.</param>
  /// <param name="index2">Index 2.</param>
  /// <returns>Component.</returns>
  public double this[int index1, int index2] {
    get {
      return vectors[index1][index2];
    }
    set {
      vectors[index1][index2] = value;
    }
  }

  /// <summary>
  /// String representation of the vectors.
  /// </summary>
  /// <returns>String representation of the vectors.</returns>
  public override string ToString() {
    string result = "";
    foreach (Vector vector in this.vectors) {
      result += vector.ToString() + "\n";
    }
    return result.Substring(0, result.Length - 1);
  }

  /// <summary>
  /// Gets the enumerator.
  /// </summary>
  /// <returns>The enumerator.</returns>
  public IEnumerator GetEnumerator() {
    return this.vectors.GetEnumerator();
  }

  /// <summary>
  /// Gets the farthest vector from the given vector.
  /// </summary>
  /// <param name="from">From vector.</param>
  /// <returns>Farthest vector.</returns>
  public Vector FarthestFrom(Vector from) {
    Vector farthest = new Vector(this.Components);
    double maxDistance = Double.MinValue;
    foreach (Vector vector in this.vectors) {
      double distance = vector.Distance(from);
      if (distance > maxDistance) {
        maxDistance = distance;
        farthest = vector;
      }
    }
    return farthest;
  }

  /// <summary>
  /// Gets the farthest vector from the given vector.
  /// </summary>
  /// <param name="from">From vector.</param>
  /// <param name="ignore">List of vectors to ignore.</param>
  /// <returns>Farthest vector.</returns>
  public Vector FarthestFrom(Vector from, bool[] ignore) {
    Vector farthest = new Vector(this.Components);
    double maxDistance = Double.MinValue;
    for (int i = 0; i < this.vectors.Length; i++) {
      if (ignore[i]) continue;
      double distance = this.vectors[i].Distance(from);
      if (distance > maxDistance) {
        maxDistance = distance;
        farthest = this.vectors[i];
      }
    }
    return farthest;
  }

  /// <summary>
  /// Gets the cenetr of the vectors.
  /// </summary>
  /// <returns>Center of the vectors.</returns>
  public Vector Center() {
    Vector center = new Vector(this.Components);
    for (int i = 0; i < this.Components; i++) {
      for (int j = 0; j < this.Count; j++) {
        center[i] += this.vectors[j][i];
      }
      center[i] /= this.Count;
    }
    return center;
  }

  /// <summary>
  /// Gets the index of the given vector.
  /// </summary>
  /// <param name="vector">Vector.</param>
  /// <returns>Index of the given vector.</returns>
  public int IndexOf(Vector vector) {
    for (int i = 0; i < this.Count; i++) {
      if (this.vectors[i].Equals(vector)) {
        return i;
      }
    }
    return -1;
  }
}
