using IS_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Contracts.BLL
{
    public interface IDocumentBLL
    {
        public int InsertDocument(Document document);
        public Task<Document> GetDocument(int userId);
        public Task<IEnumerable<Document>> GetAllDocuments();
    }
}
