' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8061関数
'
' 作成日　　: 2024.09.27
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8061

    Public Class FrmGJ8061Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :String
    '------------------------------------------------------------------
    Public Shared Function f_Search_SQLMake(req As InitDetailRequest) As String

        'SQL
        Dim wSql = "SELECT * FROM TM_JIMUITAKU " & _
                "WHERE KI = " & req.KI & _
                "  AND ITAKU_CD = " & req.ITAKU_CD
        Return wSql

    End Function

#End Region

#Region "f_Data_Deleate 委託先削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :委託先削除処理
    '引数            :なし
    '戻り値          :DaResponseBase
    '------------------------------------------------------------------
    Public Shared Function f_Data_Deleate(db As DaDbContext, wNojoCd As DeleteRequest) As DaResponseBase

        Dim wkCmd As New OracleCommand
        Dim wkSql As String = String.Empty

        'ストアドプロシージャの呼び出し
        wkCmd.Connection = db.Session.Connection
        wkCmd.CommandType = CommandType.StoredProcedure
        '
        wkCmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_DEL"

        '引き渡し
        'グループコード
        Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", wNojoCd.KI)
        Dim paraGROUP_CD As OracleParameter = wkCmd.Parameters.Add("IN_ITAKU_CD", wNojoCd.ITAKU_CD)

        '戻り
        Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
        Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

        wkCmd.ExecuteNonQuery()

        Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
        If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "99" Then
                '削除済みは正常終了とみなす
                Return New DaResponseBase(EnumServiceResult.Exception , wkCmd.Parameters("OU_MSGNM").Value.ToString())　
            End If
        End If

        'データベースへの接続を閉じる
        If Not wkCmd Is Nothing Then
            wkCmd.Dispose()
        End If

        Return New DaResponseBase

    End Function
#End Region

#Region "f_Data_Update 委託先更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :委託先更新処理
    '引数            :なし
    '戻り値          :DaResponseBase
    '------------------------------------------------------------------
    Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        'ストアドプロシージャの呼び出し
        Cmd.Connection = db.Session.Connection
        Cmd.CommandType = CommandType.StoredProcedure

        Select Case wNojoCd.EDIT_KBN
            Case EnumEditKbn.Add      '新規入力
                Cmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_INS"
            Case EnumEditKbn.Edit      '変更入力
                Cmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_UPD"
        End Select

        '引き渡し
        '期 
        Cmd.Parameters.Add("IN_KI", wNojoCd.ITAKU.KI)
        '事務委託先番号 
        Cmd.Parameters.Add("IN_ITAKU_CD", wNojoCd.ITAKU.ITAKU_CD)
        '都道府県コード
        Cmd.Parameters.Add("IN_KEN_CD", wNojoCd.ITAKU.KEN_CD)
        '事務委託先名（正式）
        Cmd.Parameters.Add("IN_ITAKU_NAME", wNojoCd.ITAKU.ITAKU_NAME)
        '事務委託先名（略称）
        Cmd.Parameters.Add("IN_ITAKU_RYAKU", wNojoCd.ITAKU.ITAKU_RYAKU)
        '代表者名
        If wNojoCd.ITAKU.DAIHYO_NAME.Trim = "" Then
            Cmd.Parameters.Add("IN_DAIHYO_NAME", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_DAIHYO_NAME", wNojoCd.ITAKU.DAIHYO_NAME)
        End If
        '担当者名  
        If wNojoCd.ITAKU.TANTO_NAME.Trim = "" Then
            Cmd.Parameters.Add("IN_TANTO_NAME", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_TANTO_NAME", wNojoCd.ITAKU.TANTO_NAME)
        End If

        '郵便番号
        Cmd.Parameters.Add("IN_ADDR_POST", wNojoCd.ITAKU.ADDR_POST)
        '住所１
        Cmd.Parameters.Add("IN_ADDR_1", wNojoCd.ITAKU.ADDR_1)
        '住所２
        If wNojoCd.ITAKU.ADDR_2.Trim = "" Then
            Cmd.Parameters.Add("IN_ADDR_2", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_2", wNojoCd.ITAKU.ADDR_2)
        End If
        '住所３
        If wNojoCd.ITAKU.ADDR_3.Trim = "" Then
            Cmd.Parameters.Add("IN_ADDR_3", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_3", wNojoCd.ITAKU.ADDR_3)
        End If
        '住所４
        If wNojoCd.ITAKU.ADDR_4.Trim = "" Then
            Cmd.Parameters.Add("IN_ADDR_4", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_4", wNojoCd.ITAKU.ADDR_4)
        End If
        '電話番号
        Cmd.Parameters.Add("IN_ADDR_TEL", wNojoCd.ITAKU.ADDR_TEL)
        'ＦＡＸ
        If wNojoCd.ITAKU.ADDR_FAX = "" Then
            Cmd.Parameters.Add("IN_ADDR_FAX", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_FAX", wNojoCd.ITAKU.ADDR_FAX)
        End If
        'メールアドレス
        If wNojoCd.ITAKU.ADDR_E_MAIL = "" Then
            Cmd.Parameters.Add("IN_ADDR_E_MAIL", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_E_MAIL", wNojoCd.ITAKU.ADDR_E_MAIL)
        End If
        '金融機関情報印字有無(1:有 2:無)
        Cmd.Parameters.Add("IN_BANK_INJI_KBN", wNojoCd.ITAKU.BANK_INJI_KBN)
        'まとめ先
        If String.IsNullOrEmpty( wNojoCd.ITAKU.MATOMESAKI.ToString()) Then
            Cmd.Parameters.Add("IN_MATOMESAKI", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_MATOMESAKI", wNojoCd.ITAKU.MATOMESAKI)
        End If
        '申込書類
        If wNojoCd.ITAKU.MOSIKOMISYORUI = "" Then
            Cmd.Parameters.Add("IN_MOSIKOMISYORUI", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_MOSIKOMISYORUI", wNojoCd.ITAKU.MOSIKOMISYORUI)
        End If
        '請求書・契約書
        If wNojoCd.ITAKU.SEIKYUSYO = "" Then
            Cmd.Parameters.Add("IN_SEIKYUSYO", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_SEIKYUSYO", wNojoCd.ITAKU.SEIKYUSYO)
        End If
        '入金方法
        If wNojoCd.ITAKU.NYUKINHOHO = "" Then
            Cmd.Parameters.Add("IN_NYUKINHOHO", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_NYUKINHOHO", wNojoCd.ITAKU.NYUKINHOHO)
        End If
        'ラベル発行
        If String.IsNullOrEmpty( wNojoCd.ITAKU.LABELHAKKO.ToString()) Then
            Cmd.Parameters.Add("IN_LABELHAKKO", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_LABELHAKKO", wNojoCd.ITAKU.LABELHAKKO)
        End If
        '除外フラグ
        If String.IsNullOrEmpty( wNojoCd.ITAKU.JYOGAI_FLG.ToString()) Then
            Cmd.Parameters.Add("IN_JYOGAI_FLG", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_JYOGAI_FLG", wNojoCd.ITAKU.JYOGAI_FLG)
        End If
        '備考    BIKO
        If wNojoCd.ITAKU.BIKO = "" Then
            Cmd.Parameters.Add("IN_BIKO", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_BIKO", wNojoCd.ITAKU.BIKO)
        End If

        '共通
        Select Case wNojoCd.EDIT_KBN
            Case EnumEditKbn.Add      '新規入力
                'データ登録日
                Cmd.Parameters.Add("IN_REG_DATE", wNow)
                'データ登録ＩＤ
                Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
        End Select

        'データ更新日
        Cmd.Parameters.Add("IN_UP_DATE", wNow)
        'データ更新ＩＤ
        Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
        'コンピュータ名
        Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

        '戻り
        Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
        Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

        Cmd.ExecuteNonQuery()
        Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
        If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
            Return New DaResponseBase(EnumServiceResult.Exception , Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())　
        End If

        'データベースへの接続を閉じる
        If Not Cmd Is Nothing Then
            Cmd.Dispose()
        End If

        Return New DaResponseBase
    End Function

#End Region

    End Class

End Namespace
