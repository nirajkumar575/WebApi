using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly FileService _fileService;

    public FileController(FileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("write")]
    public async Task<IActionResult> WriteToFile([FromBody] LoginModel model)
    {
        await _fileService.WriteToFileAsync("ID: "+model.Id +"\r\n"+"UserName: "+model.UserName+"\r\n"+"Email: "+model.Email+"\r\n");
        return Ok(model.UserName + " details has been added successfully !!");
    }
}
