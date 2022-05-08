/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * MaximumDiversity class
 */

namespace MaximumDiversity {
  public class MaximumDiversity {
    private Algorithm algorithm;

    /**
     * Constructor of the class
     */
    public MaximumDiversity(Vectors problem, AlgorithmType algorithmType) {
      this.algorithm = algorithmType;
      this.algorithm.SetVectors(problem);
    }

    public Vectors Run(int maxParameter) {
      return this.algorithm.Run(maxParameter);
    }
  }
}