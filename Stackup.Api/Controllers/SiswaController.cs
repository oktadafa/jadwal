using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]

public class SiswaController :ControllerBase
{
    private readonly DbSiswa  _dbSiswa;

    Response response = new Response();

    public SiswaController(IConfiguration configuration)
    {
        _dbSiswa = new DbSiswa(configuration);
    }

    [HttpGet]

    public IActionResult GetAllSiswa()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbSiswa.GetAllSiswa();
        }
        catch (Exception ex)
        {
            response.status = 200;
            response.message = ex.Message;
        }

        return Ok(response);
    }


[HttpPost]
 public IActionResult AddSiswa([FromBody] Siswa siswa)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbSiswa.CreateSiswa(siswa);
        }
        catch (Exception ex)
        {
            response.status = 200;
            response.message = ex.Message;
        }

        return Ok(response);
    }


    [HttpPut("{id}")]

    public IActionResult UpdateSiswa(string id,[FromBody] Siswa siswa)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbSiswa.updateSiswa(id, siswa);
        }
        catch (Exception ex)
        {
            response.status = 200;
            response.message = ex.Message;
        }

        return Ok(response);
    }



    [HttpDelete("{id}")]

    public IActionResult DeleteSiswa(string id)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbSiswa.DeleteSiswa(id);
        }
        catch (Exception ex)
        {
            response.status = 200;
            response.message = ex.Message;
        }

        return Ok(response);
    }

    [HttpGet("{id}")]

    public IActionResult GetJadwalSiswaByIdSiswa(string id)
    {
    
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbSiswa.DeleteSiswa(id);
        }
        catch (Exception ex)
        {
            response.status = 200;
            response.message = ex.Message;
        }

        return Ok(response);
    }
}