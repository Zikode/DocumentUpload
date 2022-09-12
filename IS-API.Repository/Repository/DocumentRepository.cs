using IS_API.Contracts.Repository;
using IS_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Repository.Repository
{
   public class DocumentRepository : IDocumentRepository
    {
        private readonly IDapperRepository _dapper;

        public DocumentRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            return await _dapper.Query<Document>("[dbo].[GetAllDocuments]");
        }

        public async Task<Document> GetDocument(int userId)
        {
            return await _dapper.QuerySingleWithParameter<Document>("[dbo].[GetUserDocument]", new { UserId = userId });
        }

        public int InsertDocument(Document document)
        {
            return _dapper.Execute("[dbo].[InsertDocument]", new
            {
                @FileName = document.FileName,
                @Path = document.Path,
                @Fk_UserId = document.Fk_UserId
            });
        }
    }
}