using Microsoft.AspNetCore.Mvc;

namespace AprendizadoSobreTasks.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Tasks()    
    {
        var test1 = TestarTask();

        var result = await test1;

        return Ok(result);
    }

    private async Task<int> TestarTask()
    {
        await Task.Delay(10000);

        return 7;
    }
}
