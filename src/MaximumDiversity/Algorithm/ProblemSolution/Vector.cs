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
    private List<float> vector;

    /**
     * Constructor of the class
     */
    public Vector() {
      this.vector = new List<float>();
    }

    public Vector(float[] vector) {
      this.vector = new List<float>();
      foreach (float value in vector) {
        this.vector.Add(value);
      }
    }

    public int Count {
      get {
        return this.vector.Count;
      }
    }

    public float this[int index] {
      get {
        return this.vector[index];
      }
      set {
        this.vector[index] = value;
      }
    }
  }
}