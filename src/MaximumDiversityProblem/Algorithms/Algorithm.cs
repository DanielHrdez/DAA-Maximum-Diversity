/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <enum>Algorithm</enum>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.Algorithms;

/// <summary>
/// Abstract class that represents an algorithm.
public abstract class Algorithm {
  protected VectorsDistance vectors;

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  public Algorithm() {
    this.vectors = new VectorsDistance();
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors to be used.</param>
  public Algorithm(Vectors vectors) {
    this.vectors = new VectorsDistance(vectors);
  }

  /// <summary>
  /// Sets the vectors to be used.
  /// </summary>
  /// <param name="vectors">Vectors to be used.</param>
  public void SetVectors(Vectors vectors) {
    this.vectors = new VectorsDistance(vectors);
  }

  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <param name="maxLength">Maximum length of the solution.</param>
  /// <returns>The solution.</returns>
  public abstract VectorsDistance Run(int maxLength);

  /// <summary>
  /// Check if max length is valid.
  /// </summary>
  /// <param name="maxLength">Maximum length of the solution.</param>
  protected void CheckParameters(int maxLength) {
    if (maxLength < 1 || maxLength >= this.vectors.Count) {
      throw new System.ArgumentException(
          "maxLength must be greater than 0 " +
          "and less than the number of vectors"
      );
    }
  }
}
