' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: Global変数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

'using NpgsqlTypes;

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

        ''' <summary>
        ''' DB初期化
        ''' </summary>
        Public Shared Sub InitDbLib()
            '性能テスト
            'AiGlobal.PostgresSchema = "report";

            'AiGlobal.DiffHandler = DaDbLogService.DiffDelegate!;
            'AiGlobal.SqlLogHandler = DaDbLogService.LogDelegate!;

            '''AiGlobal.LogDiffHandler = DaDbLogService.DiffLogDelegate!;

            '''パラメータタイプ
            'AiGlobal.ParameterTypeDic = new Dictionary<string, int>() { { "nendo", (int)NpgsqlDbType.Char } };

            '''DB固定項目名設定
            'AiGlobal.CreateUserFieldName = nameof(tm_afuserDto.reguserid);
            'AiGlobal.CreateTimeFieldName = nameof(tm_afuserDto.regdttm);
            'AiGlobal.UpdateUserFieldName = nameof(tm_afuserDto.upduserid);
            'AiGlobal.UpdateTimeFieldName = nameof(tm_afuserDto.upddttm);
            'AiGlobal.TimeStampFieldName = nameof(tm_afuserDto.upddttm);
            '''登録支所
            'AiGlobal.CreateUnitName = nameof(tt_shkensinDto.regsisyo);
            '''削除フラグ
            'AiGlobal.DeleteFlagName = "delflg";

            'AiGlobal.SystemTableItems = new string[] { nameof(tm_afuserDto.reguserid), nameof(tm_afuserDto.regdttm), nameof(tm_afuserDto.upduserid), nameof(tm_afuserDto.upddttm), nameof(tt_shkensinDto.regsisyo) };
            'AiGlobal.SetUpdateFieldsWhenInsert = true;
            'AiGlobal.DatabaseType = EnumDatabaseType.POSTGRE;

            '暗号化解読方法設定
            'ArGlobal.DeEncrypt = DaEncryptUtil.AesDecrypt;
        End Sub

        ' public static class Path
        ' {
        ' //リクエストの時に取得する
        ' public static string ServerPath;
        ' 
        ' public static string UpdloadPath => System.IO.Path.GetTempPath();
        ' /// <summary>
        ' /// ダウンロードファイルのパス
        ' /// </summary>
        ' public static string DwonloadFullPath => System.IO.Path.Combine(ServerPath, DaConst.DONWLOAD_PATH);
        ' 
        ' /// <summary>
        ' /// メッセージファイルのパス
        ' /// </summary>
        ' public static string ResourceFullPath => System.IO.Path.Combine(ServerPath, DaConst.RESOURCE_PATH);
        ' }

    End Class
End Namespace
