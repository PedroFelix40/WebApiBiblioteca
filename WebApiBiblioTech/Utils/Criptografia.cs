namespace webapibibliotech.Utils
{
    public class Criptografia
    {
        /// <summary>
        /// Gera uma hash a partir de uma senha 
        /// </summary>
        /// <param name="senha">senha que receberá a hash</param>
        /// <returns>senha criptografada com a hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
