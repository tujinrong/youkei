// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 暗号化処理
//
// 作成日　　: 2023.07.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace BCC.Affect.DataAccess
{
    public static class DaEncryptUtil
    {
        private static readonly string AesKey;
        private static readonly string AesIv;
        private static readonly string RsaPublicKeyPem;
        private static readonly string RsaPrivateKeyPem;
        private static readonly int[] ValidKeyLengths = { 16, 24, 32 };
        private const int ValidIvLength = 16;
        private const int RsaStrength = 2048;

        static DaEncryptUtil()
        {
            if (DaGlobal.GetSectionConfigStringValueFunc != null)
            {
                AesKey = DaGlobal.GetSectionConfigStringValueFunc("Aes", nameof(AesKey)).Trim();
                AesIv = DaGlobal.GetSectionConfigStringValueFunc("Aes", nameof(AesIv)).Trim();
                RsaPublicKeyPem = DaGlobal.GetSectionConfigStringValueFunc("Rsa", nameof(RsaPublicKeyPem)).Trim();
                RsaPrivateKeyPem = DaGlobal.GetSectionConfigStringValueFunc("Rsa", nameof(RsaPrivateKeyPem)).Trim();
            }
            else
            {
                AesKey = "PTmqHv?*-^%RC-73MDR-!zHg4-wrGi&R";
                AesIv = "X$4ceLSdhHWOI^+t";
                RsaPublicKeyPem = "-----BEGIN PUBLIC KEY-----\r\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhl81icNTbjrhWHs+OiPw\r\nfBmIqo4AccHz0gMWiIwH7nL34LKRFYD0UUOalUOtC3hWaEjaFdMrPbCjAluZuIMC\r\nqi0ulKUub0mPAvWP0QFFu+a3Uv1ITwSKcWKcO7y5rMcjEXo7T8l03TQhlKY38QMh\r\nW2FxGhZzplFixhdIgR46IlgarN0wdqJCv9zbx8VaM7QVDW5aVdbse+8WuqCLuSUo\r\nBgBclO4+YA3dAO2VkEp+5zxjwjxmkXhX6merwCPn4K83a1vLVM3LO5wZXtCRQlE7\r\nGxMVemtxZV/+3Nlup3TTIYClBNXYgt0tQeR9u4fKFXnwvfUd73zCRwnoETab7wQr\r\ntwIDAQAB\r\n-----END PUBLIC KEY-----";
                RsaPrivateKeyPem = "-----BEGIN RSA PRIVATE KEY-----\r\nMIIEoQIBAAKCAQEAhl81icNTbjrhWHs+OiPwfBmIqo4AccHz0gMWiIwH7nL34LKR\r\nFYD0UUOalUOtC3hWaEjaFdMrPbCjAluZuIMCqi0ulKUub0mPAvWP0QFFu+a3Uv1I\r\nTwSKcWKcO7y5rMcjEXo7T8l03TQhlKY38QMhW2FxGhZzplFixhdIgR46IlgarN0w\r\ndqJCv9zbx8VaM7QVDW5aVdbse+8WuqCLuSUoBgBclO4+YA3dAO2VkEp+5zxjwjxm\r\nkXhX6merwCPn4K83a1vLVM3LO5wZXtCRQlE7GxMVemtxZV/+3Nlup3TTIYClBNXY\r\ngt0tQeR9u4fKFXnwvfUd73zCRwnoETab7wQrtwIDAQABAoH/crlpjsfIKp4a7JUo\r\nQsS1svXQ3haok5wpa25cF/AJHrGcXxeENWotd8bSxudKRRMLjpBbotjxySeY4PzB\r\n+RArNkUUEmfQ9FfZeT+dQWeLkAbZoyYK37VJ7BcguruLy69eirIazSjqVRcIuU96\r\nc7mmLvFMMdVCn1AB4Izb7M9PrpP8i8V2Jko9OSFbN/Mmn5T9oNpR42Z6EmogmEng\r\nWyPLfKCRwBqwsxsqo8V45JOTOuC9rlb68T2RrJdmrdtm2R2XD8R+OGnSw1MU9jp5\r\nx0WGOPK0VKNP5/A6HNVgf88o8sU8cUXrFDJ/VVWJqaVxWtCTmGoE8seTXOMTVr2h\r\nmifBAoGBAOhi6bZm9VtqAQzuLoQAx8R+oH+JlLWHQLcZgs2p9CxFpF4sQxdzPUuF\r\nitgufH4UXjdcDCXtFBFezeIOrYfmNZFwLcITDFGrVQDYa6aIKprylqRcLvINXmJ9\r\nMEA7rfxDyjBvMkEpnZ5DvvmzTsGos9vUkIhMSLSnkOvE83lQZP3xAoGBAJQGoyd/\r\nZtfXxLVX5GARmsecX3vlWYvnQWHLIN8aYf+z0WMHKyNObwKNskDJfHjaCLTyecSp\r\nfMZPgxyI1fzEqVLIZcYCHcjVit/4T31KrUxr3WfsedIIPFoOGuM9NgElve+mcaRS\r\na47fjpOYvUJ73ZZFmOezqz2k9EoBLuys7TwnAoGAWXvdKxOyXyUOioAdAU+bnRp1\r\niybbUJtoXBlCuRc8ot+eT3UT0K/bZn1h3aTo41PMg9y6ANCt7ZJoDShBwhbvgbWE\r\nqTrUf45OCSlNKq88WLYZM+kbWrGzKpGyRsm0UXN5I/VtkJIJ06uammRla0UfHQNZ\r\nNGLLjGUJ9P++EXTXrsECgYAUIs8A6XjA9c4BaSJc2yg17RSkEu/acyvWtL4U+07H\r\nbNuX3/rDQ8EgFMxhucbf3bD/hFiCIxghFeHc+NQ7HTl3VGFbzR/mGP5aNzoA7i6i\r\nza2BnI55vrsO+Qo5TTNSdqLevcKJuth8x/ZqJ4XfTGA5N+Bz7GHn8c91XbHXajKf\r\nUwKBgQCP+6avCrle4bQtrt3KdOMXrG/sTiqJ2fuILIbIeEZpjS11E9BgAay2MzDc\r\nLucHX0asUUQjgieIi/sm6m6w7jJiLMq6jpNmKVBjOAYHsZrwmD4+Q34SZj7OeVWV\r\nQ/3xMs2iMtaO7nzV3EeXb/1wOzO9LHVQNKQ2I/Ws0tG/hsTAHQ==\r\n-----END RSA PRIVATE KEY-----";
            }
        }

        /// <summary>
        /// AES暗号化：DB格納または検索のため
        /// </summary>
        /// <param name="value">画面リクエストデータ</param>
        /// <returns></returns>
        public static string RsaDecryptAndAesEncrypt(string value)
        {
            //画面データをRSA復号化して、AES暗号化
            return AesEncrypt(RsaDecrypt(value));
        }

        /// <summary>
        /// RSA暗号化：画面表示のため
        /// </summary>
        public static string AesDecryptAndRsaEncrypt(string value, string publicKeyPem, string? key = null, string? iv = null)
        {
            //DBデータをAES復号化して、RSA暗号化
            return RsaEncrypt(AesDecrypt(value, key, iv), publicKeyPem);
        }

        /// <summary>
        /// AES復号化後、RSA暗号化（秘密キーを返す）
        /// </summary>
        public static string AesDecryptAndRsaEncrypt(string value, out string privateKeyPem, string? key = null, string? iv = null)
        {
            return RsaEncrypt(AesDecrypt(value, key, iv), out privateKeyPem);
        }

        /// <summary>
        /// RSA暗号化（秘密キーを返す）
        /// </summary>
        public static string RsaEncrypt(string value, out string privateKeyPem)
        {
            return RsaEncrypt(value, out _, out privateKeyPem);
        }

        /// <summary>
        /// RSA暗号化（公開キー、秘密キーを返す）
        /// </summary>
        public static string RsaEncrypt(string value, out string publicKeyPem, out string privateKeyPem)
        {
            GeneratePemRsaKeyPair(out publicKeyPem, out privateKeyPem);
            return RsaEncrypt(value, publicKeyPem);
        }

        /// <summary>
        /// RSA暗号化
        /// </summary>
        public static string RsaEncrypt(string value, string? publicKeyPem = null)
        {
            using var rsa = new RSACryptoServiceProvider();

            publicKeyPem = publicKeyPem ?? RsaPublicKeyPem;
            string publicKeyBase64 = publicKeyPem
            .Replace("-----BEGIN PUBLIC KEY-----", "")
            .Replace("-----END PUBLIC KEY-----", "")
            .Replace("\n", "");

            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyBase64);

            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
            return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(value), false));
        }

        /// <summary>
        /// RSA復号化
        /// </summary>
        public static string RsaDecrypt(string value, string? privateKeyPem = null)
        {
            using var rsa = new RSACryptoServiceProvider();
            privateKeyPem = privateKeyPem ?? RsaPrivateKeyPem;
            string privateKeyBase64 = privateKeyPem
            .Replace("-----BEGIN RSA PRIVATE KEY-----", "")
            .Replace("-----END RSA PRIVATE KEY-----", "")
            .Replace("\n", "");

            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyBase64);

            rsa.ImportRSAPrivateKey(privateKeyBytes, out _);
            return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(value), false));
        }

        /// <summary>
        /// AES暗号化
        /// </summary>
        public static string AesEncrypt(string value, string? key = null, string? iv = null)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            key = CheckAndGetKey(key);
            iv = CheckAndGetIv(iv);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var valueBytes = Encoding.UTF8.GetBytes(value);
            var resultArray = aes.CreateEncryptor().TransformFinalBlock(valueBytes, 0, valueBytes.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// AES復号化
        /// </summary>
        public static string AesDecrypt(string value)
        {
            return AesDecrypt(value, null, null);
        }

        /// <summary>
        /// AES復号化
        /// </summary>
        public static string AesDecrypt(string value, string? key, string? iv)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            key = CheckAndGetKey(key);
            iv = CheckAndGetIv(iv);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var valueBytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(aes.CreateDecryptor().TransformFinalBlock(valueBytes, 0, valueBytes.Length));
        }

        /// <summary>
        /// Aesキー取得
        /// </summary>
        private static string CheckAndGetKey(string? key)
        {
            if (key == null) return AesKey;

            if (!ValidKeyLengths.Contains(key.Length))
            {
                throw new ArgumentException("AesKey error");
            }

            return key;
        }

        /// <summary>
        /// AesIv取得
        /// </summary>
        private static string CheckAndGetIv(string? iv)
        {
            if (iv == null) return AesIv;

            if (iv.Length != ValidIvLength)
            {
                throw new ArgumentException($"AseIv error");
            }

            return iv;
        }

        /// <summary>
        /// トークンIDの暗号化処理
        /// </summary>
        public static string TokenEncrypt(string tokenID, string userid, string? regsisyo)
        {
            if (string.IsNullOrEmpty(tokenID))
            {
                return string.Empty;
            }

            string key = FuncMD5($"userid:{userid},regsisyo:{regsisyo}");
            byte[] keyArray = Convert.FromBase64String(key);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(tokenID);

            Aes aes = Aes.Create();
            aes.Key = keyArray;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = aes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解読処理
        /// </summary>
        public static string TokenDecrypt(string hex, string userid, string? regsisyo)
        {
            try
            {
                if (string.IsNullOrEmpty(hex))
                {
                    return string.Empty;
                }
                string key = FuncMD5($"userid:{userid},regsisyo:{regsisyo}");
                byte[] keyArray = Convert.FromBase64String(key);
                byte[] toEncryptArray = Convert.FromBase64String(hex);

                Aes aes = Aes.Create();
                aes.Key = keyArray;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = aes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);//  UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// MD5変換
        /// </summary>
        private static string FuncMD5(string str)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));

                var sBuilder = new StringBuilder();

                int i;
                var loopTo = data.Length - 1;
                for (i = 0; i <= loopTo; i++)
                    sBuilder.Append(data[i].ToString("x2"));

                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// PEM形式でRSAキーペアを生成
        /// </summary>
        public static void GeneratePemRsaKeyPair(out string publicKeyPem, out string privateKeyPem)
        {
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), RsaStrength));
            var keyPair = keyPairGenerator.GenerateKeyPair();
            //公開キー(暗号化)
            using var publicKeyWriter = new StringWriter();
            var pemWriter = new PemWriter(publicKeyWriter);
            pemWriter.WriteObject(keyPair.Public);
            publicKeyPem = publicKeyWriter.ToString().Trim();
            //秘密キー(復号化)
            using var privateKeyWriter = new StringWriter();
            pemWriter = new PemWriter(privateKeyWriter);
            pemWriter.WriteObject(keyPair.Private);
            privateKeyPem = privateKeyWriter.ToString().Trim();
        }
    }
}