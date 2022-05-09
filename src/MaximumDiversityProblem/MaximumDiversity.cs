/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * MaximumDiversity class
 */

using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms;
using MaximumDiversityProblem.IO;

namespace MaximumDiversityProblem;
public class MaximumDiversity {
  private Algorithm algorithm;

  /**
    * Constructor of the class
    */
  public MaximumDiversity(Vectors problem, AlgorithmType algorithmName) {
    this.SetAlgorithm(algorithmName);
    this.algorithm!.SetVectors(problem);
  }

  public MaximumDiversity(string vectorsFilePath, AlgorithmType algorithmName) : this(
      ReadVectorsFile.Read(vectorsFilePath),
      algorithmName
  ) {}

  public Vectors Run(int maxParameter) {
    return this.algorithm.Run(maxParameter);
  }

  private void SetAlgorithm(AlgorithmType algorithmName) {
    Type algorithmType = System.Type.GetType("MaximumDiversityProblem.Algorithms." + algorithmName.ToString())!;
    if (algorithmType == null) {
      throw new System.ArgumentException(
          "The algorithm \u001b[31m" + algorithmName.ToString() + "\u001b[0m does not exist"
      );
    }
    this.algorithm = (Algorithm) System.Activator.CreateInstance(algorithmType)!;
    if (this.algorithm == null) {
      throw new System.ArgumentException(
          "The algorithm \u001b[31m" + algorithmName.ToString() + "\u001b[0m does not exist"
      );
    }
  }
}
