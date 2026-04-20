using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab04_Variant03;

namespace Lab04_Variant03
{
    /// <summary>
    /// Главная форма приложения «Дорожная сеть района» (Вариант 3, ЛР №4).
    /// Реализует: загрузку графа, BFS, DFS, проверку достижимости, компоненты связности.
    /// </summary>
    public partial class Form1 : Form
    {
        private Graph? _graph;

        public Form1()
        {
            InitializeComponent();
        }

        // ─── Загрузка графа ───────────────────────────────────────────

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Выберите файл графа",
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                _graph = Graph.LoadFromFile(dlg.FileName);
                PopulateComboBoxes();

                AppendOutput($"✔ Граф загружен: {_graph.Vertices.Count} вершин.");
                AppendOutput("Вершины:");
                foreach (string v in _graph.Vertices)
                    AppendOutput($"  • {v}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла:\n{ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBoxes()
        {
            if (_graph == null) return;

            cmbBfsStart.Items.Clear();
            cmbDfsStart.Items.Clear();
            cmbReachFrom.Items.Clear();
            cmbReachTo.Items.Clear();
            cmbDijkstraSource.Items.Clear();
            cmbDijkstraFrom.Items.Clear();
            cmbDijkstraTo.Items.Clear();
            cmbVariantFrom.Items.Clear();
            cmbVariantTo.Items.Clear();

            foreach (string v in _graph.Vertices)
            {
                cmbBfsStart.Items.Add(v);
                cmbDfsStart.Items.Add(v);
                cmbReachFrom.Items.Add(v);
                cmbReachTo.Items.Add(v);
                cmbDijkstraSource.Items.Add(v);
                cmbDijkstraFrom.Items.Add(v);
                cmbDijkstraTo.Items.Add(v);
                cmbVariantFrom.Items.Add(v);
                cmbVariantTo.Items.Add(v);
            }

            if (cmbBfsStart.Items.Count > 0)
            {
                cmbBfsStart.SelectedIndex = 0;
                cmbDfsStart.SelectedIndex = 0;
                cmbReachFrom.SelectedIndex = 0;
                cmbReachTo.SelectedIndex = cmbReachTo.Items.Count > 1 ? 1 : 0;
                cmbDijkstraSource.SelectedIndex = 0;
                cmbDijkstraFrom.SelectedIndex = 0;
                cmbDijkstraTo.SelectedIndex = cmbDijkstraTo.Items.Count > 1 ? 1 : 0;
                cmbVariantFrom.SelectedIndex = 0;
                cmbVariantTo.SelectedIndex = cmbVariantTo.Items.Count > 1 ? 1 : 0;
            }
        }

        // ─── BFS ──────────────────────────────────────────────────────

        private void btnBfs_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;
            if (cmbBfsStart.SelectedItem is not string start) return;

            var order = _graph!.BFS(start);

            AppendOutput("");
            AppendOutput($"═══ BFS от вершины «{start}» ═══");
            AppendOutput($"Порядок посещения ({order.Count} вершин):");
            for (int i = 0; i < order.Count; i++)
                AppendOutput($"  {i + 1}. {order[i]}");
        }

        // ─── DFS ──────────────────────────────────────────────────────

        private void btnDfs_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;
            if (cmbDfsStart.SelectedItem is not string start) return;

            var order = _graph!.DFS(start);

            AppendOutput("");
            AppendOutput($"═══ DFS от вершины «{start}» ═══");
            AppendOutput($"Порядок посещения ({order.Count} вершин):");
            for (int i = 0; i < order.Count; i++)
                AppendOutput($"  {i + 1}. {order[i]}");
        }

        // ─── Достижимость ─────────────────────────────────────────────

        private void btnReach_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;
            if (cmbReachFrom.SelectedItem is not string from) return;
            if (cmbReachTo.SelectedItem is not string to) return;

            bool reachable = _graph!.IsReachable(from, to);

            AppendOutput("");
            AppendOutput($"═══ Достижимость ═══");
            AppendOutput(reachable
                ? $"✔ Вершина «{to}» ДОСТИЖИМА из «{from}»."
                : $"✘ Вершина «{to}» НЕ достижима из «{from}».");
        }

        // ─── Компоненты связности ─────────────────────────────────────

        private void btnComponents_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;

            var components = _graph!.GetConnectedComponents();

            AppendOutput("");
            AppendOutput($"═══ Компоненты связности: {components.Count} ═══");
            for (int i = 0; i < components.Count; i++)
            {
                AppendOutput($"  Компонента {i + 1} ({components[i].Count} вершин):");
                foreach (string v in components[i])
                    AppendOutput($"    - {v}");
            }
        }

        // ─── Очистить вывод ───────────────────────────────────────────

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        // ─── Дейкстра: все расстояния от источника ────────────────────

        private void btnDijkstraAll_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;
            if (cmbDijkstraSource.SelectedItem is not string source) return;

            var (dist, _) = _graph!.Dijkstra(source);

            AppendOutput("");
            AppendOutput($"═══ Дейкстра: расстояния от «{source}» ═══");
            AppendOutput($"  {"Вершина",-35} {"Расстояние (км)",15}");
            AppendOutput($"  {new string('─', 52)}");

            foreach (string v in _graph.Vertices)
            {
                string distStr = double.IsPositiveInfinity(dist[v]) ? "недостижима" : $"{dist[v]:F2} км";
                AppendOutput($"  {v,-35} {distStr,15}");
            }
        }

        // ─── Дейкстра: кратчайший путь между двумя вершинами ─────────

        private void btnDijkstraPath_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;
            if (cmbDijkstraFrom.SelectedItem is not string from) return;
            if (cmbDijkstraTo.SelectedItem is not string to) return;

            var (dist, prev) = _graph!.Dijkstra(from);
            var path = Graph.RestorePath(prev, from, to);

            AppendOutput("");
            AppendOutput($"═══ Кратчайший путь: «{from}» → «{to}» ═══");

            if (path.Count == 0)
            {
                AppendOutput("  ✘ Путь не существует.");
                return;
            }

            AppendOutput($"  Маршрут: {string.Join(" → ", path)}");
            AppendOutput($"  Длина:   {dist[to]:F2} км");
        }

        // ─── Вспомогательные методы ───────────────────────────────────

        private bool CheckGraphLoaded()
        {
            if (_graph != null) return true;
            MessageBox.Show("Сначала загрузите файл графа.",
                            "Граф не загружен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void AppendOutput(string text)
        {
            txtOutput.AppendText(text + Environment.NewLine);
            txtOutput.ScrollToCaret();
        }

        // ─── ЛР №6: Точки сочленения ──────────────────────────────────

        private void btnArticulation_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;

            var points = _graph!.FindArticulationPoints();

            AppendOutput("");
            AppendOutput("═══ Точки сочленения ═══");

            if (points.Count == 0)
            {
                AppendOutput("  Точек сочленения нет (граф двусвязен).");
                return;
            }

            AppendOutput($"  Найдено: {points.Count}");
            foreach (string v in points)
                AppendOutput($"  ⚠ {v}");

            AppendOutput("");
            AppendOutput("  Интерпретация: удаление этих перекрёстков");
            AppendOutput("  разрывает дорожную сеть на несвязные части.");
        }

        // ─── ЛР №6: МОД (алгоритм Прима) ─────────────────────────────

        private void btnPrimMST_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;

            var (edges, total) = _graph!.PrimMST();

            AppendOutput("");
            AppendOutput("═══ Минимальное остовное дерево (алгоритм Прима) ═══");

            if (edges.Count == 0)
            {
                AppendOutput("  МОД не построен (граф пуст или несвязен).");
                return;
            }

            AppendOutput($"  {"Ребро",-50} {"Вес (км)",10}");
            AppendOutput($"  {new string('─', 62)}");

            foreach (var (from, to, weight) in edges)
                AppendOutput($"  {from} — {to,-30} {weight,8:F2} км");

            AppendOutput($"  {new string('─', 62)}");
            AppendOutput($"  Суммарный вес МОД: {total:F2} км");
            AppendOutput("");
            AppendOutput("  Интерпретация: минимальная дорожная инфраструктура,");
            AppendOutput("  связывающая все перекрёстки района.");
        }

        // ─── ЛР №6: Задача варианта — кратчайший маршрут (Дейкстра) ──

        private void btnVariantTask_Click(object sender, EventArgs e)
        {
            if (!CheckGraphLoaded()) return;
            if (cmbVariantFrom.SelectedItem is not string from) return;
            if (cmbVariantTo.SelectedItem is not string to) return;

            var (dist, prev) = _graph!.Dijkstra(from);
            var path = Graph.RestorePath(prev, from, to);

            AppendOutput("");
            AppendOutput($"═══ Задача варианта №3: кратчайший маршрут ═══");
            AppendOutput($"  Из: {from}");
            AppendOutput($"  В:  {to}");
            AppendOutput("");

            if (path.Count == 0)
            {
                AppendOutput("  ✘ Маршрут не существует.");
                return;
            }

            AppendOutput($"  Маршрут ({path.Count - 1} участков):");
            for (int i = 0; i < path.Count - 1; i++)
                AppendOutput($"    {i + 1}. {path[i]} → {path[i + 1]}");

            AppendOutput("");
            AppendOutput($"  ✔ Итоговая длина: {dist[to]:F2} км");
        }
    }
}
