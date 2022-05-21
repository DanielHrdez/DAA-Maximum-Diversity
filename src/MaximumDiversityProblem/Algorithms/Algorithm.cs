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
  protected int maxLength;

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  public Algorithm() {
    this.vectors = new VectorsDistance();
    this.maxLength = 0;
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="algorithm">Algorithm to be used.</param>
  public Algorithm(Algorithm algorithm) {
    this.vectors = new VectorsDistance(algorithm.vectors.Vectors);
    this.maxLength = algorithm.maxLength;
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectors">Vectors to be used.</param>
  /// <param name="maxLength">Maximum length of the solution.</param>
  public Algorithm(Vectors vectors, int maxLength) {
    this.vectors = new VectorsDistance(vectors);
    this.maxLength = maxLength;
    this.CheckParameters();
  }

  /// <summary>
  /// Sets the vectors to be used.
  /// </summary>
  /// <param name="vectors">Vectors to be used.</param>
  public void SetVectors(Vectors vectors) {
    this.vectors = new VectorsDistance(vectors);
  }

  public void ResetVectors() {
    this.vectors = new VectorsDistance(this.vectors.Vectors);
  }

  /// <summary>
  /// Sets the max length of the solution.
  /// </summary>
  /// <param name="maxLength">Max length of the solution.</param>
  public void SetMaxLength(int maxLength) {
    this.maxLength = maxLength;
  }

  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <returns>The solution.</returns>
  public abstract VectorsDistance Run();

  /// <summary>
  /// Check if max length is valid.
  /// </summary>
  protected void CheckParameters() {
    if (this.maxLength < 1 || this.maxLength >= this.vectors.Count) {
      throw new System.ArgumentException(
          "maxLength must be greater than 0 " +
          "and less than the number of vectors"
      );
    }
  }

  public override string ToString() {
    return this.GetType().Name;
  }
}
