using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem_Estar_Financeiro_Familiar
{
    internal class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } = string.Empty;
    }
}
