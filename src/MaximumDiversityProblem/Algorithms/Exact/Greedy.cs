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

  override public (Vectors, double) Run(int maxParameter) {
    this.CheckParameters(maxParameter);
    Vectors solution = new Vectors();
    Vectors temporal = this.vectors.Clone();
    Vector center = this.vectors.Center();
    while (solution.Count != maxParameter) {
      (Vector vector, double distance) farthest = this.vectors.FarthestFrom(center);
      this.distance += farthest.distance;
      solution.AddVector(farthest.vector);
      this.vectors.RemoveVector(farthest.vector);
      center = this.vectors.Center();
    }
    this.vectors = temporal;
    return (solution, this.distance);
  }
}