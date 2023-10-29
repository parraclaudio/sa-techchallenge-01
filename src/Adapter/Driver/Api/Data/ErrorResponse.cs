namespace Api.Data;

public class ErrorResponse
{
    public ErrorResponse(string errorMessage)
    {
        MensagemDeErro = errorMessage;
    }

    public string MensagemDeErro { get; private set; }
}