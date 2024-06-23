namespace Producer
{
    public interface IAlunoFactory
    {
        Aluno CriarAluno(Dictionary<string, object> data, List<Dictionary<string, object>> frequencias);
    }
}
