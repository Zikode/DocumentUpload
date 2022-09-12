using Dapper;
using IS_API.Contracts.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Repository.Dapper
{
   public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;
        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Excute(string sqlCommand)
        {
            using IDbConnection connection = GetConnection();
            var results = await connection.ExecuteAsync(sqlCommand, commandType: CommandType.StoredProcedure);
            return results;
        }


        public int Execute(string sqlCommand, object parameters)
        {
            using IDbConnection connection = GetConnection();
            var results = connection.Execute(sqlCommand, parameters, commandType: CommandType.StoredProcedure);
            return results;

        }

        public async Task<IEnumerable<T>> Query<T>(string sqlCommand)
        {
            using IDbConnection connection = GetConnection();
            var results = await connection.QueryAsync<T>(sqlCommand, commandType: CommandType.StoredProcedure);
            return results;

        }

        public async Task<T> QuerySingleWithParameter<T>(string sqlCommand, object parameters)
        {
            using IDbConnection connection = GetConnection();
            var results = await connection.QueryFirstOrDefaultAsync<T>(sqlCommand, parameters, commandType: CommandType.StoredProcedure);
            return results;
        }

        public async Task<IEnumerable<T>> QueryWithParameter<T>(string sqlCommand, object parameters)
        {
            using IDbConnection connection = GetConnection();
            var results = await connection.QueryAsync<T>(sqlCommand, parameters, commandType: CommandType.StoredProcedure);
            return results;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DevConnectionString"));
        }
    }
}
