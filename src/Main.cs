/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @date 08/05/2022
 * Main program
 */

using MaximumDiversityProblem;
using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms;

MaximumDiversity maximumDiversity = new MaximumDiversity(
    "data/max_div_30_3.txt",
    AlgorithmType.Greedy
);

Vectors solution = maximumDiversity.Run(4);

Console.WriteLine(solution);
