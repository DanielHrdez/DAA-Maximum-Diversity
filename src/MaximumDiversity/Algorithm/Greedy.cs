/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Greedy class
 */

namespace MaximumDiversity.Algorithm {
  public class Greedy : Algorithm {
    public Greedy() : base() {}

    public Vectors Run(int maxParameter) {
      if (maxParameter < 1 || maxParameter >= this.vectors.Count) {
        throw new System.ArgumentException(
            "maxParameter must be greater than 0 " +
            "and less than the number of vectors"
        );
      }
      Vectors solution = new Vectors();
      Vector center = this.Center(this.vectors);
      while (solution.Count <= m) {
        Vector farthest = this.Farthest(center);
        solution.AddVector(farthest);
        this.vectors.RemoveVector(farthest);
        center = this.Center(this.vectors);
      }
      return solution;
    }

    private Vector Farthest(Vector center) {
      Vector farthest = this.vectors[0];
      double maxDistance = 0;
      foreach (Vector vector in this.vectors) {
        double distance = this.Distance(center, vector);
        if (distance > maxDistance) {
          maxDistance = distance;
          farthest = vector;
        }
      }
      return farthest;
    }

    private Vector Center(Vectors vectors) {
      int numberVectors = vectors.Count;
      int numberComponents = vectors[0].Count;
      Vector center = new Vector(new double[numberVectors]);
      double constant = 1 / numberVectors;
      for (int i = 0; i < numberComponents; i++) {
        for (int j = 0; j < numberVectors; j++) {
          center[i] += vectors[j][i];
        }
        center[i] *= constant;
      }
      return center;
    }
  }
}