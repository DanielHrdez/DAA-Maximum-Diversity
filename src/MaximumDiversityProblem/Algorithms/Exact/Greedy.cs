/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Greedy class
 */

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Exact;
public class Greedy : Algorithm {
  public Greedy() : base() {}

  public override VectorsDistance Run(int maxLength) {
    this.CheckParameters(maxLength);
    Vector center = this.vectors.Center();
    while (this.vectors.LengthSolution != maxLength) {
      Vector farthest = this.vectors.FarthestFrom(center);
      this.vectors.AddVector(farthest);
      center = this.vectors.Center();
    }
    return this.vectors;
  }
}
