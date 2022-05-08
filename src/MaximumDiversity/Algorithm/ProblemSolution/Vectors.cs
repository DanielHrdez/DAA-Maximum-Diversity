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
  public class Vectors {
    private List<List<float>> vectors;

    /**
     * Constructor of the class
     */
    public Vectors() {
      this.vectors = new List<List<float>>();
    }

    public void AddVector(List<float> vector) {
      this.vectors.Add(vector);
    }

    public void RemoveVector(List<float> vector) {
      this.vectors.Remove(vector);
    }

    public int Count {
      get {
        return this.vectors.Count;
      }
    }

    public int Components {
      get {
        return this.vectors[0].Count;
      }
    }

    public List<float> this[int index] {
      get {
        return vectors[index];
      }
      set {
        vectors[index] = value;
      }
    }

    public float this[int index1, int index2] {
      get {
        return vectors[index1][index2];
      }
      set {
        vectors[index1][index2] = value;
      }
    }
  }
}