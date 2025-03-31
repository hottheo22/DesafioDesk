using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMVC.Model
{
    public class LancamentoModel
    {
        public string Tipo { get; set; } //Receita ou Despesa
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Id { get; set; }
        public DateTime Data { get; set; }
    }
}
