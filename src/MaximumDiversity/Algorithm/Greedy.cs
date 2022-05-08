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

    public void Run() {
      Vectors solution = new Vectors();
      List<float> center = this.Center(this.vectors);
      while (solution.Count <= m) {
        List<float> farthest = this.Farthest(center, solution);
        solution.AddVector(farthest);
        this.vectors.RemoveVector(farthest);
        center = this.Center(this.vectors);
      }
      this.vectors = solution;
    }

    private List<float> Center(Vectors vectors) {
      int numberVectors = vectors.Count;
      int numberComponents = vectors[0].Count;
      List<float> center = new List<float>(new float[numberVectors]);
      float constant = 1 / numberVectors;
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