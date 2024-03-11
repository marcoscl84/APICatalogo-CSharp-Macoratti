namespace APICatalogo.Sevices;

public class MeuServico : IMeuServico
{
    public string Saudacao(string nome)
    {
        return $"Welcome, {nome} \n\n {DateTime.UtcNow}";
    }
}
