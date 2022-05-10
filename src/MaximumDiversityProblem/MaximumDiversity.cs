/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>MaximumDiversity</class>

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms;
using MaximumDiversityProblem.IO;

namespace MaximumDiversityProblem;

/// <summary>
/// Class that implements the Maximum Diversity Problem.
/// </summary>
public class MaximumDiversity {
  private Algorithm algorithm;

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="problem">The problem to solve.</param>
  /// <param name="algorithmName">The name of the algorithm to use.</param>
  public MaximumDiversity(Vectors problem, string algorithmName) {
    this.SetAlgorithm(algorithmName);
    this.algorithm!.SetVectors(problem);
  }

  /// <summary>
  /// Constructor of the class.
  /// </summary>
  /// <param name="vectorsFilePath">The path of the file containing the vectors.</param>
  /// <param name="algorithmName">The name of the algorithm to use.</param>
  public MaximumDiversity(string vectorsFilePath, string algorithmName) : this(
      ReadVectorsFile.Read(vectorsFilePath),
      algorithmName
  ) {}

  /// <summary>
  /// Runs the algorithm.
  /// </summary>
  /// <param name="maxLength">The maximum length of the solution.</param>
  public VectorsDistance Run(int maxLength) {
    return this.algorithm.Run(maxLength);
  }

  /// <summary>
  /// Sets the algorithm to use.
  /// </summary>
  /// <param name="algorithmName">The name of the algorithm to use.</param>
  private void SetAlgorithm(string algorithmName) {
    Type algorithmType;
    try {
      algorithmType = System.Type.GetType("MaximumDiversityProblem.Algorithms.Exact." + algorithmName)!;
      if (algorithmType == null) {
        throw new System.ArgumentException(
            "The algorithm \u001b[31m" + algorithmName + "\u001b[0m does not exist in Exact Algorithms."
        );
      }
    } catch (System.ArgumentException e) {
      algorithmType = System.Type.GetType("MaximumDiversityProblem.Algorithms.Approximated." + algorithmName)!;
      if (algorithmType == null) {
        throw new System.ArgumentException(
            e.Message +
            "\nThe algorithm \u001b[31m" + algorithmName + "\u001b[0m does not exist in Approximated Algorithms."
        );
      }
    }
    this.algorithm = (Algorithm) System.Activator.CreateInstance(algorithmType)!;
    if (this.algorithm == null) {
      throw new System.ArgumentException(
          "The algorithm \u001b[31m" + algorithmName + "\u001b[0m does not exist"
      );
    }
  }
}
