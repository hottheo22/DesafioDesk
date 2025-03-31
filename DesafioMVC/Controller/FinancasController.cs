using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesafioMVC.Model;

namespace DesafioMVC.Controller
{
    class FinancasController
    {
        private FinancasModel model;

        public FinancasController(FinancasModel model)
        {
            model = new FinancasModel();
            this.model = model;
        }

        // Método para adicionar um lançamento
        public void AdicionarElemento(string descricao, decimal valor, string tipo, DateTime data, DataGridView dataGrid)
        {
            model.AdicionarElemento(descricao, valor, tipo, data, dataGrid);
            ListElemento(dataGrid); // Agora o método recebe o DataGrid corretamente
        }


        public void ListElemento(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

            List<LancamentoModel> lancamentos = model.ListarLancamento();

            foreach(var lancamento in lancamentos)
            {
                dataGrid.Rows.Add(lancamento.Id, lancamento.Descricao, lancamento.Valor, lancamento.Tipo, lancamento.Data);
            }
        }

        public void RemoveElemento(int id, DataGridView dataGrid)
        {
            model.RemoverElemento(id);
            dataGrid.Rows.Clear();
            List<LancamentoModel> lancamentos = model.ListarLancamento();
            foreach (var lancamento in lancamentos)
            {
                // Adiciona os novos dados ao DataGridView
                dataGrid.Rows.Add(lancamento.Id, lancamento.Descricao, lancamento.Valor, lancamento.Tipo, lancamento.Data);
            }
        }
    }
}
