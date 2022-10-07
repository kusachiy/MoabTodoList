using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoabTodoApiService.Models
{
    public class TreeNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
