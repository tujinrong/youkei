' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8020関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Imports OracleInternal.Json

Namespace JBD.GJS.Service.GJ8020

    Public Class FrmGJ8020Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SetForm_Data
        '説明            :データ取得SQL
        '引数            :1.req DaRequestBase  データセット
        '戻り値          :String(SQL)
        '------------------------------------------------------------------
        Public Shared Function f_SetForm_Data(req As DaRequestBase) As String
            Dim wkSQL As String = String.Empty
            'SQL
            wkSQL += "SELECT"
            wkSQL += "  KI,"                 '--期
            wkSQL += "  JIGYO_NENDO,"        '--事業対象開始年度
            wkSQL += "  JIGYO_SYURYO_NENDO," '--事業対象終了年度

            '2015/03/21  追加開始
            'wkSQL += "  ZENKI_TUMITATE_DATE,"   '--前期積立金取込日   '2015/01/19　追加
            'wkSQL += "  ZENKI_KOFU_DATE,"       '--前期交付金取込日   '2015/01/19　追加
            'wkSQL += "  HENKAN_KEISAN_DATE,"    '--返還金計算日       '2015/01/19　追加
            '--前期積立金取込日
            wkSQL &= "  TO_CHAR(ZENKI_TUMITATE_DATE, 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ZENKI_TUMITATE_DATE,"
            '--前期交付金取込日
            wkSQL &= "  TO_CHAR(ZENKI_KOFU_DATE,     'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ZENKI_KOFU_DATE,"
            '--返還金計算日
            wkSQL &= "  TO_CHAR(HENKAN_KEISAN_DATE,  'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS HENKAN_KEISAN_DATE,"
            '2015/03/21  追加終了

            wkSQL += "  HENKAN_NINZU,"      '--積立金返還人数
            wkSQL += "  HENKAN_GOKEI,"      '--積立金返還額合計
            wkSQL += "  HENKAN_RITU,"       '--前期積立金返還率

            wkSQL += "  TAISYO_NENDO,"       '--対象年度
            wkSQL += "  NOFU_KIGEN,"         '--当初対象積立金納付期限
            wkSQL += "  HASSEI_KAISU,"       '--現在の発生回数
            wkSQL += "  BIKO,"               '--備考
            wkSQL += "  REG_DATE,"           '--データ登録日
            wkSQL += "  REG_ID,"             '--データ登録ＩＤ
            wkSQL += "  UP_DATE,"            '--データ更新日
            wkSQL += "  UP_ID,"              '--データ更新ＩＤ
            wkSQL += "  COM_NAME "           '--コンピュータ名"
            wkSQL += "FROM"
            wkSQL += "  TM_SYORI_KI"
            Return wkSQL
        End Function

#End Region
#Region "f_Data_Insert 処理対象期・年度マスタメンテナンス更新処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Insert
        '説明            :処理対象期・年度マスタメンテナンス更新処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
            Dim Cmd As New OracleCommand
            Dim ret As Boolean = False

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case wNojoCd.EDIT_KBN
                Case EnumEditKbn.Edit       '変更入力
                    Cmd.CommandText = "PKG_GJ8020.GJ8020_SYORI_KI_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ8020.GJ8020_SYORI_KI_INS"
            End Select

            '--期
            Cmd.Parameters.Add("IN_KI", wNojoCd.SYORI_KI.KI)
            '--事業対象開始年度
            Cmd.Parameters.Add("IN_JIGYO_NENDO", wNojoCd.SYORI_KI.JIGYO_NENDO)
            '--事業対象終了年度
            Cmd.Parameters.Add("IN_JIGYO_SYURYO_NENDO", wNojoCd.SYORI_KI.JIGYO_SYURYO_NENDO)

            '--対象年度
            Cmd.Parameters.Add("IN_TAISYO_NENDO", wNojoCd.SYORI_KI.TAISYO_NENDO)
            '--当初対象積立金納付期限
            If wNojoCd.SYORI_KI.NOFU_KIGEN Is Nothing Then
                Cmd.Parameters.Add("IN_NOFU_KIGEN", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_NOFU_KIGEN", f_DateTrim(CDate(wNojoCd.SYORI_KI.NOFU_KIGEN)))
            End If
            '--現在の発生回数
            If wNojoCd.SYORI_KI.HASSEI_KAISU Is Nothing Then
                Cmd.Parameters.Add("IN_HASSEI_KAISU", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_HASSEI_KAISU", wNojoCd.SYORI_KI.HASSEI_KAISU)
            End If
            '--備考
            Cmd.Parameters.Add("IN_BIKO", wNojoCd.SYORI_KI.BIKO)

            Cmd.Parameters.Add("IN_SYORI_NENDO_REG_DATE", Now)
            Cmd.Parameters.Add("IN_SYORI_NENDO_REG_ID", pLOGINUSERID)
            Cmd.Parameters.Add("IN_SYORI_NENDO_UP_DATE", Now)
            Cmd.Parameters.Add("IN_SYORI_NENDO_UP_ID", pLOGINUSERID)
            Cmd.Parameters.Add("IN_SYORI_NENDO_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            ret = True
            Return New DaResponseBase
        End Function

#End Region

    End Class

End Namespace
