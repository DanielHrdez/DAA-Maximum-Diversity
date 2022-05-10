/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>VectorsDistance</class>

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

  public VectorsDistance(VectorsDistance vectorsDistance) {
    this.distance = vectorsDistance.distance;
    this.indices = new List<bool>(vectorsDistance.indices);
    this.solution = new Vectors(vectorsDistance.solution);
    this.vectors = new Vectors(vectorsDistance.vectors);
  }

  public bool AddVector(Vector vector) {
    int index = this.vectors.IndexOf(vector);
    if (index != -1) {
      this.indices[index] = true;
      for (int i = 0; i < this.solution.Count; i++) {
        this.distance += vector.Distance(this.solution[i]);
      }
      this.solution.AddVector(vector);
      return true;
    }
    return false;
  }

  public VectorsDistance Swap(int index1, int index2) {
    VectorsDistance newSolution = new VectorsDistance(this);
    newSolution.AddVector(this.vectors[index1]);
    newSolution.RemoveVector(this.vectors[index2]);
    return newSolution;
  }

  private bool RemoveVector(Vector vector) {
    int index = this.vectors.IndexOf(vector);
    if (index != -1) {
      this.indices[index] = false;
      this.solution.RemoveVector(vector);
      for (int i = 0; i < this.solution.Count; i++) {
        this.distance -= vector.Distance(this.solution[i]);
      }
      return true;
    }
    return false;
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
    return $"\u001b[32mVectors:\u001b[0m\n{this.solution.ToString()}\n" +
        $"\u001b[32mIndices:\u001b[0m\n{indices}\n" +
        $"\u001b[32mDistance:\u001b[0m\n{distance}\n";
  }

  public Vector Center() {
    if (this.solution.Count == 0) {
      return this.vectors.Center();
    }
    return this.solution.Center();
  }

  public Vector FarthestFrom(Vector from) {
    return this.vectors.FarthestFrom(from, this.indices);
  }

  public bool this[int index] {
    get {
      return this.indices[index];
    }
  }
}
