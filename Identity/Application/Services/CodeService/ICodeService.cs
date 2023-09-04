namespace Application.Services.CodeService;

public interface ICodeService
{
    bool Verification(VerificationRequest request);

    string Generate(GenerateRequest request);
}