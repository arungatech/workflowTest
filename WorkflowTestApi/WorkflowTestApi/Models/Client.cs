using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowTestApi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }

        public int CategorieClientId { get; set; }
        public virtual CategorieClient CategorieClient { get; set; }
    }
}
