﻿/// Universidad de La Laguna
/// Escuela Superior de Ingeniería y Tecnología
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author>Daniel Hernandez de Leon</author>
/// <date>08/05/2022</date>
/// Main Program

using MaximumDiversityProblem;
using MaximumDiversityProblem.DataStructure;
using MaximumDiversityProblem.Algorithms.Approximated.LocalSearch;

MaximumDiversity maximumDiversity = new MaximumDiversity(
    "data/max_div_15_2.txt",
    "Greedy"
);

VectorsDistance solution = maximumDiversity.Run(5);

Console.WriteLine("\u001b[31mGREEDY\u001b[0m");
Console.WriteLine(solution);

VectorsDistance swapped = Swap.Search(solution);

Console.WriteLine("\u001b[31mLOCAL_SEARCH\u001b[0m");
Console.WriteLine(swapped);
