using Domain.Base;

namespace Domain.ValueObjects;

public class CPF : ValueObject
{
    public CPF(string cpf)
    {
        Numero = cpf;
        ValidateEntity();
    }

    public string Numero { get; private set; }

    public void ValidateEntity()
    {
        CPFAssertionConcern.AssertCPFFormat(Numero, "O numero de CPF informado não é valido");
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Numero;
    }
}