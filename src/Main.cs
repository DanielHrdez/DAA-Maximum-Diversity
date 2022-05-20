/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// Main Program

using MaximumDiversityProblem;
using MaximumDiversityProblem.Benchmark;

string[] algorithms = {"Greedy", "Grasp", "Tabu", "BrunchBound"};
string[] files = Directory.GetFiles("data");
MaximumDiversity[] maximumDiversity = new MaximumDiversity[files.Length * algorithms.Length];
for (int i = 0; i < algorithms.Length; i++) {
    for (int j = 0; j < files.Length; j++) {
        maximumDiversity[i * files.Length + j] = new MaximumDiversity(files[j], algorithms[i]);
    }
}

BenchAlgorithm.Run(maximumDiversity);
