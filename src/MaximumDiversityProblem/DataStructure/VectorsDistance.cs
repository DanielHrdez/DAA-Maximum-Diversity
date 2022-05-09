/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * VectorsDistance class
 */


namespace MaximumDiversityProblem.DataStructure;
public class VectorsDistance : Vectors {
  private double distance;
  private List<bool> indices;
  
  public VectorsDistance() : base() {
    this.distance = 0;
    this.indices = new List<bool>();
  }

  public VectorsDistance(Vectors vectors) : base(vectors) {
    this.distance = 0;
    this.indices = new List<bool>(vectors.Count);
  }

  public VectorsDistance(Vectors vectors, double distance) : this(vectors) {
    this.distance = distance;
  }

  public double Distance {
    get {
      return this.distance;
    }
    set {
      this.distance = value;
    }
  }

  public List<bool> Indices {
    get {
      return this.indices;
    }
  }

  public override string ToString() {
    return $"Vectors:\n{base.ToString()}\n\nDistance:\n{this.distance}";
  }
}
