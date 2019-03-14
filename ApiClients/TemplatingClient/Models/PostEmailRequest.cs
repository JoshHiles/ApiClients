using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.TemplatingClient.Models
{
    public class PostEmailRequest
    {
        public Guid Id = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        public string Html { get; set; }
    }
}
