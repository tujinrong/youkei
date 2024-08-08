' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 初期処理
'
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    Public Class StartFactory
        Public Shared Sub Start(ByVal configuration As Microsoft.Extensions.Configuration.ConfigurationManager)
            DaGlobal.GetConnectionStringFunc = Function(key) If(configuration.GetConnectionString(key), String.Empty)
            DaGlobal.GetSectionConfigStringValueFunc = Function(section, key) If(configuration.GetSection(section).GetValue(Of String)(key), String.Empty)
        End Sub
    End Class
End Namespace
