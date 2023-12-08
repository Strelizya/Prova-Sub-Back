using Microsoft.AspNetCore.Mvc;
using PROVAAPI.Models;

namespace PROVAAPI.Controllers;

[ApiController]
[Route("api/aluno")]
public class AlunoController : ControllerBase
{
    //Banco de dados
    private readonly AppDataContext _ctx;

    public AlunoController(AppDataContext context){
        _ctx = context;
    }


    //Cadastrando o aluno
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Aluno aluno){
        try{

            _ctx.alunos.Add(aluno);
            _ctx.SaveChanges();
            return Created("", aluno);

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

}
