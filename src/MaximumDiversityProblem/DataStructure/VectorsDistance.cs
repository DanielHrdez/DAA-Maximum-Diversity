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
public class VectorsDistance {
  private Vectors vectors;
  private double distance;
  private List<bool> indices;
  private Vectors solution;
  
  public VectorsDistance() {
    this.distance = 0;
    this.indices = new List<bool>();
    this.solution = new Vectors();
    this.vectors = new Vectors();
  }

  public VectorsDistance(Vectors vectors) {
    this.distance = 0;
    this.indices = new List<bool>();
    for (int i = 0; i < vectors.Count; i++) {
      this.indices.Add(false);
    }
    this.solution = new Vectors();
    this.vectors = new Vectors(vectors);
  }

  public VectorsDistance(Vectors vectors, double distance) : this(vectors) {
    this.distance = distance;
  }

  public void AddVector(Vector vector) {
    int index = this.vectors.IndexOf(vector);
    if (index != -1) {
      this.indices[index] = true;
      this.solution.AddVector(vector);
    }
  }

  public int Count {
    get {
      return this.vectors.Count;
    }
  }

  public double Distance {
    get {
      return this.distance;
    }
    set {
      this.distance = value;
    }
  }

  public int LengthSolution {
    get {
      return this.solution.Count;
    }
  }

  public List<bool> Indices {
    get {
      return this.indices;
    }
  }

  public override string ToString() {
    string distance = this.distance.ToString().Replace(",", ".");
    string indices = "[";
    foreach (bool value in this.indices) {
      indices += value ? "1, " : "0, ";
    }
    indices = indices.Substring(0, indices.Length - 2);
    indices += "]";
    return $"Vectors:\n{this.solution.ToString()}\n\nIndices:\n{indices}\n\nDistance:\n{distance}";
  }

  public Vector Center() {
    return this.vectors.Center();
  }

  public (Vector, double) FarthestFrom(Vector from) {
    return this.vectors.FarthestFrom(from);
  }

  public bool RemoveVector(Vector vector) {
    return this.vectors.RemoveVector(vector);
  }
}
