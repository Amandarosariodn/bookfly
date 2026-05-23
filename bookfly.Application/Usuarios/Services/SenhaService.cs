using System.Security.Cryptography;
using bookfly.Application.Usuarios.Services.Interfaces;

namespace bookfly.Application.Usuarios.Services
{
    public class SenhaService : ISenhaService
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        public string GerarHash(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha não pode ser vazia.");

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                senha,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                HashSize
            );

            return $"PBKDF2${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        public bool VerificarSenha(string senha, string senhaHash)
        {
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(senhaHash))
                return false;

            string[] partes = senhaHash.Split('$');

            if (partes.Length != 4 || partes[0] != "PBKDF2")
                return false;

            if (!int.TryParse(partes[1], out int iterations))
                return false;

            byte[] salt = Convert.FromBase64String(partes[2]);
            byte[] hashSalvo = Convert.FromBase64String(partes[3]);
            byte[] hashInformado = Rfc2898DeriveBytes.Pbkdf2(
                senha,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                hashSalvo.Length
            );

            return CryptographicOperations.FixedTimeEquals(hashSalvo, hashInformado);
        }
    }
}
