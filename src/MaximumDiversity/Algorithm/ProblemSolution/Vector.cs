/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Solution class
 */

namespace Algorithm.ProblemSolution {
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
  }
}