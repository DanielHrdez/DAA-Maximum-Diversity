/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Solution class
 */

using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumDiversityProblemTest.DataStructure {
  public class Vectors : IEnumerable {
    private List<Vector> vectors;

    /**
     * Constructor of the class
     */
    public Vectors() {
      this.vectors = new List<Vector>();
    }

    public Vectors(int numberVectors, int numberElements) {
      this.vectors = new List<Vector>();
      for (int i = 0; i < numberVectors; i++) {
        this.vectors.Add(new Vector(numberElements));
      }
    }

    public void AddVector(Vector vector) {
      this.vectors.Add(vector);
    }

    public void RemoveVector(Vector vector) {
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

    public Vector this[int index] {
      get {
        return vectors[index];
      }
      set {
        vectors[index] = value;
      }
    }

    public double this[int index1, int index2] {
      get {
        return vectors[index1][index2];
      }
      set {
        vectors[index1][index2] = value;
      }
    }

    override public string ToString() {
      string result = "[\n";
      foreach (Vector vector in this.vectors) {
        result += "  " + vector.ToString() + ",\n";
      }
      result += "]";
      return result;
    }

    public IEnumerator GetEnumerator() {
      return this.vectors.GetEnumerator();
    }

    public Vector FarthestFrom(Vector from) {
      Vector farthest = new Vector(this.Components);
      double maxDistance = -Double.MinValue;
      foreach (Vector vector in this.vectors) {
        double distance = vector.Distance(from);
        if (distance > maxDistance) {
          maxDistance = distance;
          farthest = vector;
        }
      }
      return farthest;
    }

    public Vector Center() {
      Vector center = new Vector(new double[this.Components]);
      double constant = 1 / (double)this.Count;
      for (int i = 0; i < this.Components; i++) {
        for (int j = 0; j < this.Count; j++) {
          center[i] += this.vectors[j][i];
        }
        center[i] *= constant;
      }
      return center;
    }
  }
}