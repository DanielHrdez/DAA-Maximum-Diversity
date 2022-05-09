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

MaximumDiversity maximumDiversity = new MaximumDiversity(
    "data/max_div_15_2.txt",
    "Greedy"
);

VectorsDistance solution = maximumDiversity.Run(4);

Console.WriteLine(solution);
