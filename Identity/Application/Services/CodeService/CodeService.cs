using OtpNet;

namespace Application.Services.CodeService;

public class CodeService : ICodeService
{
    public bool Verification(VerificationRequest request)
    {
        var base32Secret = Base32Encoding.ToBytes(request.SecretKey);

        var totp = new Totp(base32Secret, mode: OtpHashMode.Sha256, step: 300);
        
      return  totp.VerifyTotp(request.Code, out long a);
    }

    public string Generate(GenerateRequest request)
    {
        var base32Secret = Base32Encoding.ToBytes(request.SecretKey);
        
        var totp = new Totp(base32Secret,mode: OtpHashMode.Sha256 ,step: 300);
        
        return  totp.ComputeTotp();
    }
}