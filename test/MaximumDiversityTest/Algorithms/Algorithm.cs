/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Algorithm abstract class
 */

using MaximumDiversityProblemTest.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumDiversityProblemTest.Algorithms {
  public abstract class Algorithm {
    protected Vectors vectors;

    public Algorithm() {
      this.vectors = new Vectors();
    }

    public void SetVectors(Vectors vectors) {
      this.vectors = vectors;
    }

    public abstract Vectors Run(int maxParameter);

    protected void CheckParameters(int maxParameter) {
      if (maxParameter < 1 || maxParameter >= this.vectors.Count) {
        throw new System.ArgumentException(
            "maxParameter must be greater than 0 " +
            "and less than the number of vectors"
        );
      }
    }
  }
}