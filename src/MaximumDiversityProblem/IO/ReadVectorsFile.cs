/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// <class>ReadVectorsFile</class>

using MaximumDiversityProblem.DataStructure;

namespace MaximumDiversityProblem.IO;
public class ReadVectorsFile {
  public static Vectors Read(string filePath) {
    string[] lines = File.ReadAllLines(filePath);
    Vectors vectors = new Vectors(int.Parse(lines[0]), int.Parse(lines[1]));
    for (int i = 2; i < lines.Length; i++) {
      if (lines[i].Length < 1) continue;
      lines[i] = lines[i].Replace("\t", " ");
      string[] vector = lines[i].Split(' ');
      for (int j = 0; j < vector.Length; j++) {
        vectors[i - 2, j] = double.Parse(vector[j]);
      }
    }
    return vectors;
  }
}
