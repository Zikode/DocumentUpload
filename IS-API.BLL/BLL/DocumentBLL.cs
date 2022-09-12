using IS_API.Contracts.BLL;
using IS_API.Contracts.Repository;
using IS_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.BLL.BLL
{
  public  class DocumentBLL : IDocumentBLL
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentBLL(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public Task<IEnumerable<Document>> GetAllDocuments()
        {
            return _documentRepository.GetAllDocuments();
        }

        public Task<Document> GetDocument(int userId)
        {
            return _documentRepository.GetDocument(userId);
        }

        public int InsertDocument(Document document)
        {
            return _documentRepository.InsertDocument(document);
        }

    }
}
