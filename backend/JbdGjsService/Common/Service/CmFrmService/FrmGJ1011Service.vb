' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ1011関数
'
' 作成日　　: 2024.09.18
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1011

    Public Class FrmGJ1011Service

#Region "f_SetForm_Data データ取得SQL処理"
        ''' <summary>
        ''' フォームデータセット
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function f_SetForm_Data(KI As Integer?, KEIYAKUSYA_CD As Integer?) As String
            Dim wkSb As New StringBuilder
            wkSb.AppendLine(" SELECT * FROM TM_KEIYAKU ")
            wkSb.AppendLine(" where " &
                     " KI = " & KI &
                     " and KEIYAKUSYA_CD = " & KEIYAKUSYA_CD &
                    "")
            Return wkSb.ToString()
        End Function
#End Region

#Region "f_Data_Deleate 削除処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Deleate
        '説明            :削除処理
        '引数            :なし
        '戻り値          :DaResponseBase
        '------------------------------------------------------------------
        Public Shared Function f_Data_Deleate(db As DaDbContext, wNojoCd As DeleteRequest) As DaResponseBase

            Dim wkCmd As New OracleCommand
            Dim wkSql As String = String.Empty
            Dim wkRet As Boolean = False

            'ストアドプロシージャの呼び出し
            wkCmd.Connection = db.Session.Connection
            wkCmd.CommandType = CommandType.StoredProcedure
            wkCmd.CommandText = "PKG_GJ1011.GJ1011_KEIYAKU_DEL"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", wNojoCd.KI)
            '契約者番号
            Dim paraKEIYAKU_CD As OracleParameter = wkCmd.Parameters.Add("IN_KEIYAKU", wNojoCd.KEIYAKUSYA_CD)
            '委託先
            Dim paraITAKUSAKI_CD As OracleParameter = wkCmd.Parameters.Add("IN_OLD_JIMUITAKU_CD", wNojoCd.OLD_JIMUITAKU_CD)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ更新日    
            wkCmd.Parameters.Add("IN_UP_DATE", Now)
            'データ更新ＩＤ    
            wkCmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
            wkCmd.Parameters.Add("IN_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()
            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Return New DaResponseBase(EnumServiceResult.Exception , wkCmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If

            Return New DaResponseBase

        End Function
#End Region

#Region "f_Data_Update 交付実績更新処理"
        ''' <summary>
        ''' 交付実績更新処理
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
            Dim ret As Boolean = False
            Dim Cmd As New OracleCommand
            Dim wNow As Date = Now

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case wNojoCd.EDIT_KBN
                Case EnumEditKbn.Edit       '変更入力
                    Cmd.CommandText = "PKG_GJ1011.GJ1011_KEIYAKU_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ1011.GJ1011_KEIYAKU_INS"
            End Select

            '----------------------------------------
            '   申請者基本情報1
            '----------------------------------------
            '期
            Cmd.Parameters.Add("IN_KI", wNojoCd.KEIYAKUSYA.KI)
            '契約者
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", wNojoCd.KEIYAKUSYA.KEIYAKUSYA_CD)
            '都道府県コード
            Cmd.Parameters.Add("IN_KEN_CD", wNojoCd.KEIYAKUSYA.KEN_CD)
            '契約区分
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", wNojoCd.KEIYAKUSYA.KEIYAKU_KBN)
            '契約状況
            Cmd.Parameters.Add("IN_KEIYAKU_JYOKYO", wNojoCd.KEIYAKUSYA.KEIYAKU_JYOKYO)
            '契約日
            If wNojoCd.KEIYAKUSYA.KEIYAKU_DATE Is Nothing OrElse wNojoCd.KEIYAKUSYA.KEIYAKU_DATE = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE", wNojoCd.KEIYAKUSYA.KEIYAKU_DATE)
            End If
            '----------------------------------------
            '   申請者基本情報2
            '----------------------------------------
            '契約者名    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_NAME", wNojoCd.KEIYAKUSYA.KEIYAKUSYA_NAME)
            '契約者名（フリガナ）     
            Cmd.Parameters.Add("IN_KEIYAKUSYA_KANA", wNojoCd.KEIYAKUSYA.KEIYAKUSYA_KANA)
            '代表者名    
            Cmd.Parameters.Add("IN_DAIHYO_NAME", wNojoCd.KEIYAKUSYA.DAIHYO_NAME)
            '郵便番号    
            Cmd.Parameters.Add("IN_ADDR_POST", wNojoCd.KEIYAKUSYA.ADDR_POST)
            '住所１    
            Cmd.Parameters.Add("IN_ADDR_1", wNojoCd.KEIYAKUSYA.ADDR_1)
            '住所２    
            Cmd.Parameters.Add("IN_ADDR_2", wNojoCd.KEIYAKUSYA.ADDR_2)
            '住所３    
            Cmd.Parameters.Add("IN_txt_ADDR_3", wNojoCd.KEIYAKUSYA.ADDR_3)
            '住所４    
            Cmd.Parameters.Add("IN_txt_ADDR_4", wNojoCd.KEIYAKUSYA.ADDR_4)
            '電話番号1    
            Cmd.Parameters.Add("IN_ADDR_TEL1", wNojoCd.KEIYAKUSYA.ADDR_TEL1)
            '電話番号2    
            Cmd.Parameters.Add("IN_txt_ADDR_TEL2", wNojoCd.KEIYAKUSYA.ADDR_TEL2)
            'ＦＡＸ    
            Cmd.Parameters.Add("IN_ADDR_FAX", wNojoCd.KEIYAKUSYA.ADDR_FAX)
            'メールアドレス    
            Cmd.Parameters.Add("IN_ADDR_E_MAIL", wNojoCd.KEIYAKUSYA.ADDR_E_MAIL)
            '事務委託先番号    
            Cmd.Parameters.Add("IN_NEW_JIMUITAKU_CD", wNojoCd.KEIYAKUSYA.JIMUITAKU_CD)
            If wNojoCd.EDIT_KBN = EnumEditKbn.Edit Then
                '変更前　事務委託先番号  
                If wNojoCd.KEIYAKUSYA.OLD_JIMUITAKU_CD.HasValue Then
                    Cmd.Parameters.Add("IN_OLD_JIMUITAKU_CD", wNojoCd.KEIYAKUSYA.OLD_JIMUITAKU_CD)
                Else
                    Cmd.Parameters.Add("IN_OLD_JIMUITAKU_CD", DBNull.Value)
                End If
            End If

            '----------------------------------------
            '   申請者基本情報3
            '----------------------------------------
            '振込先コード（金融機関）    
            Cmd.Parameters.Add("IN_FURI_BANK_CD", wNojoCd.KEIYAKUSYA.FURI_BANK_CD)
            '振込先支店コード    
            Cmd.Parameters.Add("IN_FURI_BANK_SITEN_CD", wNojoCd.KEIYAKUSYA.FURI_BANK_SITEN_CD)
            '口座種別    
            Cmd.Parameters.Add("IN_FURI_KOZA_SYUBETU", wNojoCd.KEIYAKUSYA.FURI_KOZA_SYUBETU)
            '口座番号    
            Cmd.Parameters.Add("IN_FURI_KOZA_NO", wNojoCd.KEIYAKUSYA.FURI_KOZA_NO)
            '口座名義人    
            Cmd.Parameters.Add("IN_FURI_KOZA_MEIGI", wNojoCd.KEIYAKUSYA.FURI_KOZA_MEIGI)
            '口座名義人（カナ）    
            Cmd.Parameters.Add("IN_FURI_KOZA_MEIGI_KANA", wNojoCd.KEIYAKUSYA.FURI_KOZA_MEIGI_KANA)

            '----------------------------------------
            '   その他
            '----------------------------------------
            '備考    
            Cmd.Parameters.Add("IN_FURI_KOZA_BIKO", wNojoCd.KEIYAKUSYA.BIKO)
            '入力状況    
            Cmd.Parameters.Add("IN_NYURYOKU_JYOKYO", wNojoCd.KEIYAKUSYA.NYURYOKU_JYOKYO)
            '廃業日
            If wNojoCd.KEIYAKUSYA.HAIGYO_DATE Is Nothing OrElse wNojoCd.KEIYAKUSYA.HAIGYO_DATE = New Date Then
                Cmd.Parameters.Add("IN_HAIGYO_DATE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_HAIGYO_DATE", wNojoCd.KEIYAKUSYA.HAIGYO_DATE)
            End If
            '経営安定対策事業生産者番号    
            Cmd.Parameters.Add("IN_SEISANSYA_CD", wNojoCd.KEIYAKUSYA.SEISANSYA_CD)
            '日鶏協番号    
            Cmd.Parameters.Add("IN_NIKKEIKYO_CD", wNojoCd.KEIYAKUSYA.NIKKEIKYO_CD)

            '----------------------------------------
            '   共通情報
            '----------------------------------------

            Select Case wNojoCd.EDIT_KBN
                Case EnumEditKbn.Add       '新規入力
                    'データ登録日
                    Cmd.Parameters.Add("IN_REG_DATE", Now)
                    'データ登録ＩＤ
                    Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            End Select

            'データ更新日
            Cmd.Parameters.Add("IN_UP_DATE", Now)
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
