/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <struct>VectorsUpperLimit</struct>

namespace MaximumDiversityProblem.DataStructure;

/// <summary>
/// Struct that represents vectors distances with an upperlimit.
/// </summary>
public class VectorsUpperLimit {
  private VectorsDistance vectors;
  private double upperLimit;
  public VectorsUpperLimit() {
    this.vectors = new VectorsDistance();
    this.upperLimit = 0;
  }
  public VectorsUpperLimit(VectorsDistance vectors) : this() {
    this.vectors = new VectorsDistance(vectors);
  }
  public void AddVector(int index)  {
    this.vectors.AddVector(index);
  }
  public int LengthSolution {
    get {
      return this.vectors.LengthSolution;
    }
  }
  public double Distance {
    get {
      return this.vectors.Distance;
    }
  }
  public VectorsDistance Vectors {
    get {
      return this.vectors;
    }
  }
  public double UpperLimit {
    get {
      return this.upperLimit;
    }
    set {
      this.upperLimit = value;
    }
  }
}
