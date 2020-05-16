using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowTestApi.Models
{
    public class CategorieClient
    {
        public int Id { get; set; }
        public string CodeCategorie { get; set; }
        public string LibelleCategorie { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
