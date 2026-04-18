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
