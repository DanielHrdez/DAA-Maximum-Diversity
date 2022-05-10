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
  public MaximumDiversity(string vectorsFilePath, string algorithmName) : this(
      ReadVectorsFile.Read(vectorsFilePath),
      algorithmName
  ) {}

  public VectorsDistance Run(int maxParameter) {
    return this.algorithm.Run(maxParameter);
  }

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
