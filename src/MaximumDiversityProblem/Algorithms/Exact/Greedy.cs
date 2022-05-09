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

  override public VectorsDistance Run(int maxParameter) {
    this.CheckParameters(maxParameter);
    Vector center = this.vectors.Center();
    while (this.vectors.LengthSolution != maxParameter) {
      (Vector vector, double distance) farthest = this.vectors.FarthestFrom(center);
      this.vectors.Distance += farthest.distance;
      this.vectors.AddVector(farthest.vector);
      this.vectors.RemoveVector(farthest.vector);
      center = this.vectors.Center();
    }
    return this.vectors;
  }
}
