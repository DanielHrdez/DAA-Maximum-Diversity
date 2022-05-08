/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * AlgorithmType enum
 */

namespace Algorithm.Base {
  public enum AlgorithmType {
    Greedy = new Greedy(),
    Grasp = new Grasp(),
    Tabu = new Tabu(),
    BrunchBound = new BrunchBound()
  }
}