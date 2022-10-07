using Microsoft.AspNetCore.Mvc;
using MoabTodoApiService.Models;
using MoabTodoApiService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoabTodoApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeNodesController : ControllerBase
    {
        private readonly TreeNodeService _treeNodeService;
        private readonly ILogger<TreeNodesController> _logger;

        public TreeNodesController(ILogger<TreeNodesController> logger, TreeNodeService treeNodeService)
        {
            _treeNodeService = treeNodeService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetByRequest()
        {
            try
            {
                var treeNodes = await _treeNodeService.GetAll();
                return Ok(treeNodes);
            }
            catch (Exception)
            {
                _logger.LogError("Error with data exchange with db server");

                return StatusCode(500, "Error with data exchange with db server");
            }
        }
        [HttpPost]
        public async Task<ActionResult> SaveList(List<TreeNode> treeNodes)
        {
            try
            {
                await _treeNodeService.Truncate();
                await _treeNodeService.BulkInsert(treeNodes);
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogError("Error with data exchange with db server");
                return StatusCode(500, "Error with data exchange with db server");
            }
        }
    }
}
