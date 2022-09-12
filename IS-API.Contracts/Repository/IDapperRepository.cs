using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Contracts.Repository
{
    public interface IDapperRepository
    {
        Task<IEnumerable<T>> Query<T>(string sqlCommand);
        Task<IEnumerable<T>> QueryWithParameter<T>(string sqlCommand, object parameters);
        Task<T> QuerySingleWithParameter<T>(string sqlCommand, object parameters);
        int Execute(string sqlCommand, object parameters);
        Task<int> Excute(string sqlCommand);
    }
}
