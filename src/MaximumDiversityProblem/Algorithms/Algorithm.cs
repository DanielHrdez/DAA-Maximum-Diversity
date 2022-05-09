/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Algorithm abstract class
 */

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms;
public abstract class Algorithm {
  protected Vectors vectors;
  protected List<int> indexs;
  protected double distance;

  public Algorithm() {
    this.vectors = new Vectors();
    this.indexs = new List<int>();
    this.distance = 0;
  }

  public Algorithm(Vectors vectors) {
    this.vectors = vectors;
    this.indexs = new List<int>(vectors.Count);
    this.distance = 0;
  }

  public void SetVectors(Vectors vectors) {
    this.vectors = vectors;
    this.indexs = new List<int>(vectors.Count);
  }

  public abstract (Vectors, double) Run(int maxParameter);

  protected void CheckParameters(int maxParameter) {
    if (maxParameter < 1 || maxParameter >= this.vectors.Count) {
      throw new System.ArgumentException(
          "maxParameter must be greater than 0 " +
          "and less than the number of vectors"
      );
    }
  }
}
