using System.Collections.Generic;

namespace ApiClients.DocumentCreationClient.Models
{
    public class HandlebarPdfRequest
    {
        public string BearerToken { get; set; }

        public string Header { get; set; }

        public string UniqueReference { get; set; }

        public string JsonData { get; set; }

        public string HandlebarHtmlTemplate { get; set; }

        public string FileSavePath { get; set; }

        public List<AdditionalDocuments> AdditionalDocuments { get; set; }
    }

    public class AdditionalDocuments
    {
        public string Base64Document { get; set; }
        public AdditionalDocumentTypes Type { get; set; }
    }

    public enum AdditionalDocumentTypes
    {
        Jpg,
        Jpeg,
        Png,
        Pdf,
        Doc,
        Docx,
        Html,
        Htm
    }
}
