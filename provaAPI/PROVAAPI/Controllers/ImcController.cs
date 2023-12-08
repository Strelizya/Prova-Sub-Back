using Microsoft.AspNetCore.Mvc;
using PROVAAPI.Models;

namespace PROVAAPI.Controllers;

[ApiController]
[Route("api/imc")]
public class ImcController : ControllerBase
{

    //Banco de dados
    private readonly AppDataContext _ctx;

    public ImcController(AppDataContext context){
        _ctx = context;
    }

    //Cadastrando o IMC
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Imc imc){
        try
        {
            Aluno? aluno = _ctx.alunos.Find(imc.AlunoID);
            imc.aluno = aluno;
            if(aluno != null){

                //FAZER CALCULO

                imc.ResultadoConta = imc.Peso / (imc.Altura*2); 

                float rest = imc.ResultadoConta;

                if(rest <= 18.5){
                    imc.ResultadoFinalImc = "Magreza";
                    imc.Obesidade = "0";
                }else if(rest <= 24.9){
                    imc.ResultadoFinalImc = "Normal";
                    imc.Obesidade = "0";
                }else if(rest <= 29.9){
                    imc.ResultadoFinalImc = "Sobrepeso";
                    imc.Obesidade = "I";
                }else if (rest <= 39.9){
                    imc.ResultadoFinalImc = "Obesisade";
                    imc.Obesidade = "II";
                }else{
                    imc.ResultadoFinalImc = "Obesidade grave";
                    imc.Obesidade = "III";
                }

                _ctx.imcs.Add(imc);
                _ctx.SaveChanges();
                return Created("", imc);
            }
            return BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //LISTA DE IMC
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar(){

        try
        {
            List<Imc> imcs = _ctx.imcs.ToList();
            return imcs.Count == 0? NotFound(): Ok(imcs);
        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    
    }

    //ALTERAR IMC
    [HttpPut]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id, [FromBody] Imc imc){

        try
        {
            Imc? imcCadastrado = _ctx.imcs.FirstOrDefault(x => x.ImcID == id);

            if(imcCadastrado != null){
                Aluno? aluno = _ctx.alunos.Find(imc.AlunoID);
                imc.aluno = aluno;  

                imcCadastrado.AlunoID = imc.AlunoID;
                imcCadastrado.Altura = imc.Altura;
                imcCadastrado.Peso = imc.Peso;

                imc.ResultadoConta = imc.Peso / imc.Altura; 

                float rest = imcCadastrado.ResultadoConta = imc.ResultadoConta;

                if(rest <= 18.5){
                    imcCadastrado.ResultadoFinalImc = imc.ResultadoFinalImc = "Magreza";
                    imcCadastrado.Obesidade = imc.Obesidade = "0";
                }else if(rest <= 24.9){
                    imcCadastrado.ResultadoFinalImc = imc.ResultadoFinalImc = "Normal";
                    imcCadastrado.Obesidade = imc.Obesidade = "0";
                }else if(rest <= 29.9){
                    imcCadastrado.ResultadoFinalImc= imc.ResultadoFinalImc = "Sobrepeso";
                    imcCadastrado.Obesidade = imc.Obesidade = "I";
                }else if (rest <= 39.9){
                    imcCadastrado.ResultadoFinalImc = imc.ResultadoFinalImc = "Obesisade";
                    imcCadastrado.Obesidade = imc.Obesidade = "II";
                }else{
                    imcCadastrado.ResultadoFinalImc = imc.ResultadoFinalImc = "Obesidade grave";
                    imcCadastrado.Obesidade = imc.Obesidade = "III";
                }

                _ctx.Update(imcCadastrado);
                _ctx.SaveChanges();
                return Ok (imcCadastrado);

            } 
            return BadRequest();
            
        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }

    }
}
