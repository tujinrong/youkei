using BCC.Affect.DataAccess;
using Org.BouncyCastle.Ocsp;

namespace BCC.Affect.Service.testryu
{
    [TestClass]
    public class testchen
    {
        [TestMethod]
        public void tst()
        {
            string s = "@ # $ % ^ & * - _ ! + = [ ] { } |  : ' , . ? / ` ~ \" ( ) ;";
            var symbolArray = s.Replace(" ", "").Split();
            var list = s.Replace(" ", "").ToCharArray();
            var symbolregex = $"\\{string.Join("\\", list)}";
            var b = s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            bool flg = new bool();
        }
        [TestMethod]
        public void tst2()
        {
            string s1 = "1";
            string s2 = string.Empty;
            string s3 = "3";
            string s4 = "4";
            string? s5 = null;
            string s6 = "6";
            var list = new List<string>();
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);
            list.Add(s5);
            list.Add(s6);
            var str = string.Join(",", list);
            string x1;
            string x2;
            //DaEncryptUtil.GeneratePemRsaKeyPair(out x1, out x2);


            var encrypt1 = DaEncryptUtil.RsaEncrypt("000000000001");
            var decrypt1 = DaEncryptUtil.RsaDecrypt(encrypt1);


            //一度だけ暗号化する
            var encrypt2 = DaEncryptUtil.RsaEncrypt("abc", out var privateKeyPem2);
            var decrypt2 = DaEncryptUtil.RsaDecrypt(encrypt2, privateKeyPem2);

            //同じ公開鍵で複数回暗号化する
            var encrypt3A = DaEncryptUtil.RsaEncrypt("abc", out var publicKey, out var privateKeyPem3);
            var encrypt3B = DaEncryptUtil.RsaEncrypt("abcd", publicKey);
            var encrypt3C = DaEncryptUtil.RsaEncrypt("abcde", publicKey);
            var decrypt3A = DaEncryptUtil.RsaDecrypt(encrypt3A, privateKeyPem3);
            var decrypt3B = DaEncryptUtil.RsaDecrypt(encrypt3B, privateKeyPem3);
            var decrypt3C = DaEncryptUtil.RsaDecrypt(encrypt3C, privateKeyPem3);

            var l = new List<string>();
            for (long i = 810000000002; i <= 810000000028; i++)
            {
                var t = DaEncryptUtil.AesEncrypt(i.ToString());
                l.Add(t);
            }
            var t2 = DaEncryptUtil.AesDecrypt("");
            var t4 = DaEncryptUtil.AesEncrypt("800000000000040");
            var t5 = DaEncryptUtil.AesEncrypt("000000000001");
            var t6 = DaEncryptUtil.AesEncrypt("333333333333");
        }

        [TestMethod]
        public void tst3()
        {
            string simei_kana = "カトウユウト";
            var kana1 = DaConvertUtil.ToKana(simei_kana);
            var seion1 = DaConvertUtil.ToSeion(kana1);
        }
    }
}
