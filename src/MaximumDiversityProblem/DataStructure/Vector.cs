/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>Vector</class>

namespace MaximumDiversityProblem.DataStructure;
public class Vector {
  private List<double> vector;

  /**
    * Constructor of the class
    */
  public Vector() {
    this.vector = new List<double>();
  }

  public Vector(double[] vector) {
    this.vector = new List<double>();
    foreach (double value in vector) {
      this.vector.Add(value);
    }
  }

  public Vector(int numberElements) {
    this.vector = new List<double>();
    for (int i = 0; i < numberElements; i++) {
      this.vector.Add(0);
    }
  }

  public int Count {
    get {
      return this.vector.Count;
    }
  }

  public double this[int index] {
    get {
      return this.vector[index];
    }
    set {
      this.vector[index] = value;
    }
  }

  public double Distance(Vector vector) {
    double sum = 0;
    for (int i = 0; i < this.Count; i++) {
      double value = this[i] - vector[i];
      sum += value * value;
    }
    return Math.Sqrt(sum);
  }

  public override string ToString() {
    string result = "[";
    foreach (double value in this.vector) {
      result += value.ToString().Replace(",", ".") + ", ";
    }
    result = result.Substring(0, result.Length - 2);
    result += "]";
    return result;
  }

  public Vector Clone() {
    Vector vector = new Vector(this.Count);
    for (int i = 0; i < this.Count; i++) {
      vector[i] = this[i];
    }
    return vector;
  }
}
