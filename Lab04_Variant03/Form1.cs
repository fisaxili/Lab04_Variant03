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

        //Загрузка графа

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
