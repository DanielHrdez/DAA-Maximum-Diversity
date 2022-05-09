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

  override public Vectors Run(int maxParameter) {
    this.CheckParameters(maxParameter);
    Vectors solution = new Vectors();
    Vector center = this.vectors.Center();
    while (solution.Count != maxParameter) {
      Vector farthest = this.vectors.FarthestFrom(center);
      solution.AddVector(farthest);
      this.vectors.RemoveVector(farthest);
      center = this.vectors.Center();
    }
    return solution;
  }
}
