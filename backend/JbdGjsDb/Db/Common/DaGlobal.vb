' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: Global変数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Db
    Public Class DaGlobal
        Public Shared WriteExcelLog As Boolean = False
        Private Shared _ConnectionString As String
        Public Delegate Function GetConfigValue(key As String) As String
        Public Shared GetConnectionStringFunc As GetConfigValue = Nothing
        Public Delegate Function GetOracleConfigValue(key As String) As String
        Public Shared GetOracleConnectionStringFunc As GetOracleConfigValue = Nothing
        Public Delegate Function GetSectionConfigValueDelegate(Of Out T)(section As String, key As String) As T
        Public Shared GetSectionConfigStringValueFunc As GetSectionConfigValueDelegate(Of String) = Nothing

        Public Shared ReadOnly Property ConnectionString As String
            Get
                If GetConnectionStringFunc Is Nothing Then
#If DEBUG
                    Return "User Id=GJS;Password=GJS;Data Source=User Id=GJS;Password=GJS;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=S19C01)))"
#Else
                    Return ""
#End If
                End If
                Dim setting = GetConnectionStringFunc("connectionString")

                If Not String.IsNullOrEmpty(setting) Then
                    _ConnectionString = setting
                Else
                    Throw New Exception("ポータルサーバーの接続文字列を取得できないので、管理者に連絡してください。")
                End If

                Return _ConnectionString
            End Get
        End Property

    End Class
End Namespace
