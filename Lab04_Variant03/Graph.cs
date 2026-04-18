using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab04_Variant03
{
    /// <summary>
    /// Представляет граф дорожной сети в виде списка смежности.
    /// Граф неориентированный, взвешенный.
    /// </summary>
    public class Graph
    {
        // Список смежности: вершина -> список (сосед, вес)
        private readonly Dictionary<string, List<(string neighbor, double weight)>> _adjacency;

        // Упорядоченный список вершин для стабильного вывода
        private readonly List<string> _vertices;

        public IReadOnlyList<string> Vertices => _vertices;

        public Graph()
        {
            _adjacency = new Dictionary<string, List<(string, double)>>();
            _vertices = new List<string>();
        }

        /// <summary>Добавить вершину, если её ещё нет.</summary>
        public void AddVertex(string name)
        {
            if (!_adjacency.ContainsKey(name))
            {
                _adjacency[name] = new List<(string, double)>();
                _vertices.Add(name);
            }
        }

        /// <summary>Добавить неориентированное ребро с весом.</summary>
        public void AddEdge(string from, string to, double weight)
        {
            AddVertex(from);
            AddVertex(to);
            _adjacency[from].Add((to, weight));
            _adjacency[to].Add((from, weight));
        }

        /// <summary>Получить соседей вершины.</summary>
        public IEnumerable<(string neighbor, double weight)> GetNeighbors(string vertex)
        {
            if (_adjacency.TryGetValue(vertex, out var list))
                return list;
            return Enumerable.Empty<(string, double)>();
        }

        //  Загрузка графа из файла
        /// <summary>
        /// Загружает граф из текстового файла.
        /// Формат: секция VERTICES (по одной вершине на строку),
        /// секция EDGES (Вершина1;Вершина2;Вес).
        /// Строки, начинающиеся с '#', игнорируются.
        /// </summary>
        public static Graph LoadFromFile(string path)
        {
            var graph = new Graph();
            string section = "";

            foreach (string rawLine in File.ReadAllLines(path))
            {
                string line = rawLine.Trim();
                if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                    continue;

                if (line == "VERTICES") { section = "V"; continue; }
                if (line == "EDGES") { section = "E"; continue; }

                if (section == "V")
                {
                    graph.AddVertex(line);
                }
                else if (section == "E")
                {
                    string[] parts = line.Split(';');
                    if (parts.Length < 3) continue;

                    string from = parts[0].Trim();
                    string to = parts[1].Trim();
                    double weight = double.Parse(parts[2].Trim(),
                                        System.Globalization.CultureInfo.InvariantCulture);
                    graph.AddEdge(from, to, weight);
                }
            }

            return graph;
        }
