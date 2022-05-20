/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>Vector</class>

namespace MaximumDiversityProblem.DataStructure;

/// <summary>
/// Class that represents a vector.
/// </summary>
public class Vector {
  private float[] vector;

  /// <summary>
  /// Default Constructor of the class.
  /// </summary>
  public Vector() {
    this.vector = new float[0];
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vector">Vector.</param>
  public Vector(float[] vector) {
    this.vector = new float[vector.Length];
    for (int i = 0; i < vector.Length; i++) {
      this.vector[i] = vector[i];
    }
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="numebrElements">Number of elements.</param>
  public Vector(int numberElements) {
    this.vector = new float[numberElements];
  }

  /// <summary>
  /// Gets the number of elements.
  /// </summary>
  /// <returns>Number of elements.</returns>
  public int Count {
    get {
      return this.vector.Length;
    }
  }

  /// <summary>
  /// Override of the [] operator.
  /// </summary>
  /// <param name="index">Index.</param>
  /// <returns>Element at the index.</returns>
  public float this[int index] {
    get {
      return this.vector[index];
    }
    set {
      this.vector[index] = value;
    }
  }

  /// <summary>
  /// Calculates the distance between two vectors.
  /// </summary>
  /// <param name="vector">Vector.</param>
  /// <returns>Distance between the two vectors.</returns>
  public float Distance(Vector vector) {
    float sum = 0;
    for (int i = 0; i < this.Count; i++) {
      float value = this[i] - vector[i];
      sum += value * value;
    }
    return (float) Math.Sqrt((double) sum);
  }

  /// <summary>
  /// String representation of the vector.
  /// </summary>
  /// <returns>String representation of the vector.</returns>
  public override string ToString() {
    string result = "[";
    foreach (float value in this.vector) {
      result += value.ToString("0.00").Replace(",", ".") + ", ";
    }
    result = result.Substring(0, result.Length - 2);
    result += "]";
    return result;
  }
}
