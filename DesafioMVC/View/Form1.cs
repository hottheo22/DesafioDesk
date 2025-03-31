using DesafioMVC.Controller;
using DesafioMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DesafioMVC
{
    public partial class Form1 : Form
    {
        private FinancasController controller;
        private FinancasModel model;
        

        public Form1()
        {
            InitializeComponent();

            model = new FinancasModel(); // Cria um único Model
            controller = new FinancasController(model); // Passa o Model para o Controller
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico();
            cbTipo.Items.Add("Receita");
            cbTipo.Items.Add("Despesa");
        }

        private void ConfigurarGrafico() // Método que configura o DataGridView
        {
            DataGrid.Columns.Add("Id", "Id");
            DataGrid.Columns.Add("Descricao", "Descrição");
            DataGrid.Columns.Add("Valor", "Valor");
            DataGrid.Columns.Add("Tipo", "Tipo");
            DataGrid.Columns.Add("Data", "Data");
            chGrafico.Series["Series1"].Name = "Receita";

            chGrafico.Width = 450;
            
            
        }

        private void btLit_Click(object sender, EventArgs e)
        {
            controller.ListElemento(DataGrid);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string descricao = txtDesc.Text;
            decimal valor = decimal.Parse(NUD.Text);
            string tipo = cbTipo.SelectedItem.ToString();
            DateTime data = DTP.Value;

            controller.AdicionarElemento(descricao, valor, tipo, data, DataGrid);

            // Atualiza o gráfico automaticamente ao adicionar
            AtualizaChart();

        }
        private void btRemove_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0) // Verifica se há linha selecionada
            {
                int id = Convert.ToInt32(DataGrid.SelectedRows[0].Cells[0].Value); // Pega o ID da linha selecionada

                controller.RemoveElemento(id, DataGrid); // Remove do Controller e atualiza a grid
            }
            else
            {
                MessageBox.Show("Selecione uma linha para remover.");
            }
            
        }
        private void AtualizaChart()
        {

            // Limpa o gráfico antes de atualizar
            chGrafico.Series.Clear();

            // Zera os valores antes de recalcular
            decimal totalReceita = 0;
            decimal totalDespesa = 0;

            // Percorre todas as linhas do DataGridView
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Valor"].Value != null && row.Cells["Tipo"].Value != null)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string tipo = row.Cells["Tipo"].Value.ToString();

                    if (tipo == "Receita")
                        totalReceita += valor;
                    else if (tipo == "Despesa")
                        totalDespesa += valor;
                }
            }

            // Cria e adiciona as séries corretamente
            
        }
        public void TotalGeral()
        {
            chGrafico.Series.Clear(); // Limpa o gráfico antes de adicionar novos dados
            decimal totalReceita = 0;
            decimal totalDespesa = 0;

            // Percorre todas as linhas do DataGrid para somar os valores
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Valor"].Value != null && row.Cells["Tipo"].Value != null)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string tipo = row.Cells["Tipo"].Value.ToString();

                    // Soma receitas e despesas
                    if (tipo == "Receita")
                        totalReceita += valor;
                    else if (tipo == "Despesa")
                        totalDespesa += valor;
                }
            }

            // Soma total de receitas e despesas
            decimal totalGeral = totalReceita + totalDespesa;

            // Criação da série para o total combinado
            Series serieTotal = new Series("Total")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue
            };

            // Adiciona o valor combinado
            serieTotal.Points.AddXY("Total", totalGeral);

            // Adiciona a série ao gráfico
            chGrafico.Series.Add(serieTotal);

            // Ajusta automaticamente os eixos do gráfico
            chGrafico.ChartAreas[0].RecalculateAxesScale();
        }

        public void MostrarDespesa()
        {
            chGrafico.Series.Clear(); // Limpa o gráfico antes de adicionar novos dados
            decimal totalDespesa = 0;

            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Valor"].Value != null && row.Cells["Tipo"].Value != null)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string tipo = row.Cells["Tipo"].Value.ToString();

                    if (tipo == "Despesa")
                        totalDespesa += valor;
                }
            }

            // Cria e adiciona a série da Despesa
            Series serieDespesa = new Series("Despesa")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Red
            };
            serieDespesa.Points.AddXY("Despesa", totalDespesa);
            chGrafico.Series.Add(serieDespesa);
        }
        public void MostrarReceita()
        {
            chGrafico.Series.Clear(); // Limpa o gráfico antes de adicionar novos dados
            decimal totalReceita = 0;

            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Valor"].Value != null && row.Cells["Tipo"].Value != null)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string tipo = row.Cells["Tipo"].Value.ToString();

                    if (tipo == "Receita")
                        totalReceita += valor;
                }
            }
            Series serieReceita = new Series("Receita")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green
            };
            serieReceita.Points.AddXY("Receita", totalReceita);
            chGrafico.Series.Add(serieReceita);
        }
        private void btRelatorio_Click(object sender, EventArgs e)
        {       
            AtualizaChart(); 
        }

        private void btTotal_Click(object sender, EventArgs e)
        {
            TotalGeral();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MostrarReceita();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MostrarDespesa();
        }
    }
}
