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
  private float upperLimit;

  /// <summary>
  /// Default Constructor of the class.
  /// </summary>
  public VectorsUpperLimit() {
    this.vectors = new VectorsDistance();
    this.upperLimit = 0;
  }

  /// <summary>
  /// Constructor of the class with vectors
  /// </summary>
  /// <param name="vectors">Vectors.</param>
  public VectorsUpperLimit(VectorsDistance vectors) : this() {
    this.vectors = new VectorsDistance(vectors);
  }

  /// <summary>
  /// Adds a vector to the vectors with index
  /// </summary>
  /// <param name="index">Index of the vector.</param>
  public void AddVector(int index)  {
    this.vectors.AddVector(index);
  }

  /// <summary>
  /// Getter of the length of the solution.
  /// </summary>
  /// <returns>Length of the solution.</returns>
  public int LengthSolution {
    get {
      return this.vectors.LengthSolution;
    }
  }

  /// <summary>
  /// Getter of the distance of the solution.
  /// </summary>
  /// <returns>Distance of the solution.</returns>
  public float Distance {
    get {
      return this.vectors.Distance;
    }
  }

  /// <summary>
  /// Getter of the vectors.
  /// </summary>
  /// <returns>Vectors.</returns>
  public VectorsDistance Vectors {
    get {
      return this.vectors;
    }
  }

  /// <summary>
  /// Getter of the upper limit.
  /// </summary>
  /// <returns>Upper limit.</returns>
  public float UpperLimit {
    get {
      return this.upperLimit;
    }
    set {
      this.upperLimit = value;
    }
  }
}
