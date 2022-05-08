/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * MaximumDiversity class
 */

using MaximumDiversity.Algorithms;
using Algorithms.ProblemSolution;

namespace MaximumDiversity {
  public class MaximumDiversity {
    private Algorithm algorithm;

    /**
     * Constructor of the class
     */
    public MaximumDiversity(Vectors problem, AlgorithmType algorithm) {
      Type algorithmType = System.Type.GetType("MaximumDiversity.Algorithms." + algorithm.ToString())!;
      if (algorithmType == null) {
        throw new System.ArgumentException(
            "The algorithm " + algorithm.ToString() + " does not exist"
        );
      }
      this.algorithm = (Algorithm) System.Activator.CreateInstance(algorithmType)!;
      if (this.algorithm == null) {
        throw new System.ArgumentException(
            "The algorithm " + algorithm.ToString() + " does not exist"
        );
      }
      this.algorithm.SetVectors(problem);
    }

    public Vectors Run(int maxParameter) {
      return this.algorithm.Run(maxParameter);
    }
  }
}