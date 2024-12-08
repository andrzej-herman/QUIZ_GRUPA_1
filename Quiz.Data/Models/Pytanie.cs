using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Models
{
    public class Pytanie : Base
    {
        public int Kategoria { get; set; }
        public List<Odpowiedz> Odpowiedzi { get; set; }
    }
}
