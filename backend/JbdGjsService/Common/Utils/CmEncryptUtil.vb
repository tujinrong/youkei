' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 暗号化処理
'
' 作成日　　: 2023.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
'using Org.BouncyCastle.Crypto;
'using Org.BouncyCastle.Crypto.Generators;
'using Org.BouncyCastle.OpenSsl;
'using Org.BouncyCastle.Security;

Namespace JBD.GJS.Db
    Public Module CmEncryptUtil
        Private ReadOnly AesKey As String
        Private ReadOnly AesIv As String
        Private ReadOnly RsaPublicKeyPem As String
        Private ReadOnly RsaPrivateKeyPem As String
        Private ReadOnly ValidKeyLengths As Integer() = {16, 24, 32}
        Private Const ValidIvLength As Integer = 16
        Private Const RsaStrength As Integer = 2048

        Sub New()
            If DaGlobal.GetSectionConfigStringValueFunc IsNot Nothing Then
                AesKey = DaGlobal.GetSectionConfigStringValueFunc("Aes", NameOf(AesKey)).Trim()
                AesIv = DaGlobal.GetSectionConfigStringValueFunc("Aes", NameOf(AesIv)).Trim()
                RsaPublicKeyPem = DaGlobal.GetSectionConfigStringValueFunc("Rsa", NameOf(RsaPublicKeyPem)).Trim()
                RsaPrivateKeyPem = DaGlobal.GetSectionConfigStringValueFunc("Rsa", NameOf(RsaPrivateKeyPem)).Trim()
            Else
                AesKey = "PTmqHv*-^%RC-73MDR-!zHg4-wrGi&R"
                AesIv = "X$4ceLSdhHWOI^+t"
                RsaPublicKeyPem = "-----BEGIN PUBLIC KEY-----" & vbCrLf & "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhl81icNTbjrhWHs+OiPw" & vbCrLf & "fBmIqo4AccHz0gMWiIwH7nL34LKRFYD0UUOalUOtC3hWaEjaFdMrPbCjAluZuIMC" & vbCrLf & "qi0ulKUub0mPAvWP0QFFu+a3Uv1ITwSKcWKcO7y5rMcjEXo7T8l03TQhlKY38QMh" & vbCrLf & "W2FxGhZzplFixhdIgR46IlgarN0wdqJCv9zbx8VaM7QVDW5aVdbse+8WuqCLuSUo" & vbCrLf & "BgBclO4+YA3dAO2VkEp+5zxjwjxmkXhX6merwCPn4K83a1vLVM3LO5wZXtCRQlE7" & vbCrLf & "GxMVemtxZV/+3Nlup3TTIYClBNXYgt0tQeR9u4fKFXnwvfUd73zCRwnoETab7wQr" & vbCrLf & "twIDAQAB" & vbCrLf & "-----END PUBLIC KEY-----"
                RsaPrivateKeyPem = "-----BEGIN RSA PRIVATE KEY-----" & vbCrLf & "MIIEoQIBAAKCAQEAhl81icNTbjrhWHs+OiPwfBmIqo4AccHz0gMWiIwH7nL34LKR" & vbCrLf & "FYD0UUOalUOtC3hWaEjaFdMrPbCjAluZuIMCqi0ulKUub0mPAvWP0QFFu+a3Uv1I" & vbCrLf & "TwSKcWKcO7y5rMcjEXo7T8l03TQhlKY38QMhW2FxGhZzplFixhdIgR46IlgarN0w" & vbCrLf & "dqJCv9zbx8VaM7QVDW5aVdbse+8WuqCLuSUoBgBclO4+YA3dAO2VkEp+5zxjwjxm" & vbCrLf & "kXhX6merwCPn4K83a1vLVM3LO5wZXtCRQlE7GxMVemtxZV/+3Nlup3TTIYClBNXY" & vbCrLf & "gt0tQeR9u4fKFXnwvfUd73zCRwnoETab7wQrtwIDAQABAoH/crlpjsfIKp4a7JUo" & vbCrLf & "QsS1svXQ3haok5wpa25cF/AJHrGcXxeENWotd8bSxudKRRMLjpBbotjxySeY4PzB" & vbCrLf & "+RArNkUUEmfQ9FfZeT+dQWeLkAbZoyYK37VJ7BcguruLy69eirIazSjqVRcIuU96" & vbCrLf & "c7mmLvFMMdVCn1AB4Izb7M9PrpP8i8V2Jko9OSFbN/Mmn5T9oNpR42Z6EmogmEng" & vbCrLf & "WyPLfKCRwBqwsxsqo8V45JOTOuC9rlb68T2RrJdmrdtm2R2XD8R+OGnSw1MU9jp5" & vbCrLf & "x0WGOPK0VKNP5/A6HNVgf88o8sU8cUXrFDJ/VVWJqaVxWtCTmGoE8seTXOMTVr2h" & vbCrLf & "mifBAoGBAOhi6bZm9VtqAQzuLoQAx8R+oH+JlLWHQLcZgs2p9CxFpF4sQxdzPUuF" & vbCrLf & "itgufH4UXjdcDCXtFBFezeIOrYfmNZFwLcITDFGrVQDYa6aIKprylqRcLvINXmJ9" & vbCrLf & "MEA7rfxDyjBvMkEpnZ5DvvmzTsGos9vUkIhMSLSnkOvE83lQZP3xAoGBAJQGoyd/" & vbCrLf & "ZtfXxLVX5GARmsecX3vlWYvnQWHLIN8aYf+z0WMHKyNObwKNskDJfHjaCLTyecSp" & vbCrLf & "fMZPgxyI1fzEqVLIZcYCHcjVit/4T31KrUxr3WfsedIIPFoOGuM9NgElve+mcaRS" & vbCrLf & "a47fjpOYvUJ73ZZFmOezqz2k9EoBLuys7TwnAoGAWXvdKxOyXyUOioAdAU+bnRp1" & vbCrLf & "iybbUJtoXBlCuRc8ot+eT3UT0K/bZn1h3aTo41PMg9y6ANCt7ZJoDShBwhbvgbWE" & vbCrLf & "qTrUf45OCSlNKq88WLYZM+kbWrGzKpGyRsm0UXN5I/VtkJIJ06uammRla0UfHQNZ" & vbCrLf & "NGLLjGUJ9P++EXTXrsECgYAUIs8A6XjA9c4BaSJc2yg17RSkEu/acyvWtL4U+07H" & vbCrLf & "bNuX3/rDQ8EgFMxhucbf3bD/hFiCIxghFeHc+NQ7HTl3VGFbzR/mGP5aNzoA7i6i" & vbCrLf & "za2BnI55vrsO+Qo5TTNSdqLevcKJuth8x/ZqJ4XfTGA5N+Bz7GHn8c91XbHXajKf" & vbCrLf & "UwKBgQCP+6avCrle4bQtrt3KdOMXrG/sTiqJ2fuILIbIeEZpjS11E9BgAay2MzDc" & vbCrLf & "LucHX0asUUQjgieIi/sm6m6w7jJiLMq6jpNmKVBjOAYHsZrwmD4+Q34SZj7OeVWV" & vbCrLf & "Q/3xMs2iMtaO7nzV3EeXb/1wOzO9LHVQNKQ2I/Ws0tG/hsTAHQ==" & vbCrLf & "-----END RSA PRIVATE KEY-----"
            End If
        End Sub

        ''' <summary>
        ''' AES暗号化：DB格納または検索のため
        ''' </summary>
        ''' <paramname="value">画面リクエストデータ</param>
        ''' <returns></returns>
        Public Function RsaDecryptAndAesEncrypt(value As String) As String
            '画面データをRSA復号化して、AES暗号化
            Return AesEncrypt(RsaDecrypt(value))
        End Function

        ''' <summary>
        ''' RSA暗号化：画面表示のため
        ''' </summary>
        Public Function AesDecryptAndRsaEncrypt(value As String, publicKeyPem As String, Optional key As String = Nothing, Optional iv As String = Nothing) As String
            'DBデータをAES復号化して、RSA暗号化
            Return CmEncryptUtil.RsaEncrypt(AesDecrypt(value, key, iv), publicKeyPem)
        End Function

        ''' <summary>
        ''' AES復号化後、RSA暗号化（秘密キーを返す）
        ''' </summary>
        'public static string AesDecryptAndRsaEncrypt(string value, out string privateKeyPem, string key = null, string iv = null)
        '{
        '    return RsaEncrypt(AesDecrypt(value, key, iv), out privateKeyPem);
        '}

        ''' <summary>
        ''' RSA暗号化（秘密キーを返す）
        ''' </summary>
        'public static string RsaEncrypt(string value, out string privateKeyPem)
        '{
        '    return RsaEncrypt(value, out _, out privateKeyPem);
        '}

        ''' <summary>
        ''' RSA暗号化（公開キー、秘密キーを返す）
        ''' </summary>
        'public static string RsaEncrypt(string value, out string publicKeyPem, out string privateKeyPem)
        '{
        '    GeneratePemRsaKeyPair(out publicKeyPem, out privateKeyPem);
        '    return RsaEncrypt(value, publicKeyPem);
        '}

        ''' <summary>
        ''' RSA暗号化
        ''' </summary>
        Public Function RsaEncrypt(value As String, Optional publicKeyPem As String = Nothing) As String
            Dim rsa = New RSACryptoServiceProvider()

            publicKeyPem = If(publicKeyPem, RsaPublicKeyPem)
            Dim publicKeyBase64 As String = publicKeyPem.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace(vbLf, "")

            Dim publicKeyBytes = Convert.FromBase64String(publicKeyBase64)

            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, 1)
            Return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(value), False))
        End Function

        ''' <summary>
        ''' RSA復号化
        ''' </summary>
        Public Function RsaDecrypt(value As String, Optional privateKeyPem As String = Nothing) As String
            Dim rsa = New RSACryptoServiceProvider()
            privateKeyPem = If(privateKeyPem, RsaPrivateKeyPem)
            Dim privateKeyBase64 As String = privateKeyPem.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "").Replace(vbLf, "")

            Dim privateKeyBytes = Convert.FromBase64String(privateKeyBase64)

            rsa.ImportRSAPrivateKey(privateKeyBytes, 1)
            Return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(value), False))
        End Function

        ''' <summary>
        ''' AES暗号化
        ''' </summary>
        Public Function AesEncrypt(value As String, Optional key As String = Nothing, Optional iv As String = Nothing) As String
            If String.IsNullOrEmpty(value) Then Return String.Empty
            key = CheckAndGetKey(key)
            iv = CheckAndGetIv(iv)

            Dim aes = Cryptography.Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = Encoding.UTF8.GetBytes(iv)
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Dim valueBytes = Encoding.UTF8.GetBytes(value)
            Dim resultArray = aes.CreateEncryptor().TransformFinalBlock(valueBytes, 0, valueBytes.Length)
            Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
        End Function

        ''' <summary>
        ''' AES復号化
        ''' </summary>
        Public Function AesDecrypt(value As String) As String
            Return AesDecrypt(value, Nothing, Nothing)
        End Function

        ''' <summary>
        ''' AES復号化
        ''' </summary>
        Public Function AesDecrypt(value As String, key As String, iv As String) As String
            If String.IsNullOrEmpty(value) Then Return String.Empty
            key = CheckAndGetKey(key)
            iv = CheckAndGetIv(iv)

            Dim aes = Cryptography.Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = Encoding.UTF8.GetBytes(iv)
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Dim valueBytes = Convert.FromBase64String(value)
            Return Encoding.UTF8.GetString(aes.CreateDecryptor().TransformFinalBlock(valueBytes, 0, valueBytes.Length))
        End Function

        ''' <summary>
        ''' Aesキー取得
        ''' </summary>
        Private Function CheckAndGetKey(key As String) As String
            If Equals(key, Nothing) Then Return AesKey

            If Not ValidKeyLengths.Contains(key.Length) Then
                Throw New ArgumentException("AesKey error")
            End If

            Return key
        End Function

        ''' <summary>
        ''' AesIv取得
        ''' </summary>
        Private Function CheckAndGetIv(iv As String) As String
            If Equals(iv, Nothing) Then Return AesIv

            If iv.Length <> ValidIvLength Then
                Throw New ArgumentException($"AseIv error")
            End If

            Return iv
        End Function

        ''' <summary>
        ''' トークンIDの暗号化処理
        ''' </summary>
        Public Function TokenEncrypt(tokenID As String, userid As String, regsisyo As String) As String
            If String.IsNullOrEmpty(tokenID) Then
                Return String.Empty
            End If

            Dim key = FuncMD5($"userid:{userid},regsisyo:{regsisyo}")
            Dim keyArray = Convert.FromBase64String(key)
            Dim toEncryptArray = Encoding.UTF8.GetBytes(tokenID)

            Dim aes As Aes = Aes.Create()
            aes.Key = keyArray
            aes.Mode = CipherMode.ECB
            aes.Padding = PaddingMode.PKCS7

            Dim cTransform As ICryptoTransform = aes.CreateEncryptor()
            Dim resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)

            Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
        End Function

        ''' <summary>
        ''' 解読処理
        ''' </summary>
        Public Function TokenDecrypt(hex As String, userid As String, regsisyo As String) As String
            Try
                If String.IsNullOrEmpty(hex) Then
                    Return String.Empty
                End If
                Dim key = FuncMD5($"userid:{userid},regsisyo:{regsisyo}")
                Dim keyArray = Convert.FromBase64String(key)
                Dim toEncryptArray = Convert.FromBase64String(hex)

                Dim aes As Aes = Aes.Create()
                aes.Key = keyArray
                aes.Mode = CipherMode.ECB
                aes.Padding = PaddingMode.PKCS7

                Dim cTransform As ICryptoTransform = aes.CreateDecryptor()
                Dim resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)

                Return Encoding.UTF8.GetString(resultArray) '  UTF8Encoding.UTF8.GetString(resultArray);
            Catch __unusedException1__ As Exception
                Return String.Empty
            End Try
        End Function

        ''' <summary>
        ''' MD5変換
        ''' </summary>
        Private Function FuncMD5(str As String) As String
            Using md5Hash = MD5.Create()
                Dim data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str))

                Dim sBuilder = New StringBuilder()

                Dim i As Integer
                Dim loopTo = data.Length - 1
                For i = 0 To loopTo
                    sBuilder.Append(data(i).ToString("x2"))
                Next

                Return sBuilder.ToString()
            End Using
        End Function

        ''' <summary>
        ''' PEM形式でRSAキーペアを生成
        ''' </summary>
        'public static void GeneratePemRsaKeyPair(out string publicKeyPem, out string privateKeyPem)
        '{
        '    var keyPairGenerator = new RsaKeyPairGenerator();
        '    keyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), RsaStrength));
        '    var keyPair = keyPairGenerator.GenerateKeyPair();
        '    //公開キー(暗号化)
        '    using var publicKeyWriter = new StringWriter();
        '    var pemWriter = new PemWriter(publicKeyWriter);
        '    pemWriter.WriteObject(keyPair.Public);
        '    publicKeyPem = publicKeyWriter.ToString().Trim();
        '    //秘密キー(復号化)
        '    using var privateKeyWriter = new StringWriter();
        '    pemWriter = new PemWriter(privateKeyWriter);
        '    pemWriter.WriteObject(keyPair.Private);
        '    privateKeyPem = privateKeyWriter.ToString().Trim();
        '}
    End Module
End Namespace
