using Dapper;
using MoabTodoApiService.Data;
using MoabTodoApiService.Models;
using System.Data;

namespace MoabTodoApiService.Services
{
    public class TreeNodeService
    {
        private const string TABLE_NAME = "tree_nodes";
        private readonly DapperContext _context;

        public TreeNodeService(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<TreeNode>> GetAll()
        {
            string commandText = $"SELECT * FROM {TABLE_NAME}";
            using (var connection = _context.CreateConnection())
            {
                var nodes = await connection.QueryAsync<TreeNode>(commandText);
                return nodes.ToList();
            }
        }

        public async Task Truncate()
        {
            string commandText = $"TRUNCATE {TABLE_NAME}";
            using (var connection = _context.CreateConnection())
            {
                var nodes = await connection.QueryAsync<TreeNode>(commandText);
            }
        }

        public async Task BulkInsert(List<TreeNode> treeNodes)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = treeNodes.Select(t =>
                {
                    var tempParams = new DynamicParameters();
                    tempParams.Add("@Id", t.Id, DbType.Int64, ParameterDirection.Input);
                    tempParams.Add("@Name", t.Name, DbType.String, ParameterDirection.Input);
                    tempParams.Add("@ParentId", t.ParentId, DbType.Int64, ParameterDirection.Input);
                    return tempParams;
                }).ToList();

                await connection.ExecuteAsync(
                    $"INSERT INTO {TABLE_NAME} (id,name,\"parentId\") VALUES (@Id, @Name,@ParentId)",
                    parameters).ConfigureAwait(false);
            }
        }       
    }
}


