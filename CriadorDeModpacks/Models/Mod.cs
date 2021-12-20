using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class Mod
    {
   

        public string Caminho { get; set; }
        public string Nome { get; set; }
        public string Pasta { get; set; } = "";
        public string Versao { get; set; }

        public Mod(string caminho, string nome, string versao)
        {
            Caminho = caminho;
            Nome = nome;
            Versao = versao;
        }
        public Mod()
        {

        }
        public override string ToString()
        {
            return Nome;
        }

    }
}
