/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Approximated</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms.Approximated;

/// <summary>
/// Class that represents an approximated algorithm.
/// </summary>
public abstract class Approximated : Algorithm {
  protected int iterations;
  public Approximated(Vectors vectors, int iterations) : base(vectors) {
    this.iterations = iterations;
  }
}
