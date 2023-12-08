using PROVAAPI.Models;

namespace PROVAAPI.Models;
public class Imc
{
    public Aluno? aluno { get; set; }
    public int AlunoID { get; set; }
    //public string Nome { get; set; }
    //public string Data { get; set; }

    public int ImcID { get; set; }
    public float Altura { get; set; }
    public float Peso { get; set; }
    
    public float ResultadoConta { get; set; }
    public string? ResultadoFinalImc { get; set; }
    public string? Obesidade { get; set; } 

}
