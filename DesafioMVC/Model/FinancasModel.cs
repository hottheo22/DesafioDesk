using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesafioMVC.Model
{
    public class FinancasModel
    {
        public List<LancamentoModel> meusLancamentos = new List<LancamentoModel>();

        public void AdicionarElemento(string descricao, decimal valor, string tipo, DateTime data, DataGridView dataGrid)
        {
            LancamentoModel newLancamento = new LancamentoModel
            {
                Descricao = descricao,
                Tipo = tipo,
                Valor = valor,
                Data = data,
                Id = 1 + meusLancamentos.Count

              
            };
            meusLancamentos.Add(newLancamento);

        }

        public void RemoverElemento(int id)
        {
            LancamentoModel reLancamento = meusLancamentos.FirstOrDefault(l => l.Id == id);

            if (reLancamento != null)
            {
                meusLancamentos.Remove(reLancamento);

                // Reorganiza os IDs para manter sequência correta
                for (int i = 0; i < meusLancamentos.Count; i++)
                {
                    meusLancamentos[i].Id = i + 1;
                }
            }
            else
            {
                MessageBox.Show("Selecione um item válido para remover.");
            }
        }

        public List<LancamentoModel> ListarLancamento()
        {
            return meusLancamentos;
        }

        
    }
}

