/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Algorithm abstract class
 */

namespace Algorithm.Base {
  public abstract class Algorithm {
    protected Vectors vectors;
    public Algorithm() {
      this.vectors = new Vectors();
    }
    public void SetVectors(Vectors vectors) {
      this.vectors = vectors;
    }
    public abstract Vectors Run(int maxParameter);
  }
}