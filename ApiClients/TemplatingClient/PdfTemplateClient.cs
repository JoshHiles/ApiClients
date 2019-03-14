using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.TemplatingClient
{
    public interface IPdfTemplateClient
    {
    }

    public class PdfTemplateClient : IBaseClient, IPdfTemplateClient
    {
        public string BaseUri { get; set; }
    }
}
