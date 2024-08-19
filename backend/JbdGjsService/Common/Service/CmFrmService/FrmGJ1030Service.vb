' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: サービスGJ1030関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

    Public Module FrmGJ1030Service

#Region "f_ComboBox_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
    '引数            :区分
    '戻り値          :InitResponse
    '------------------------------------------------------------------
    Public Function f_ComboBox_Set(ByVal wKbn As String, ki As Integer) As InitResponse
        Dim sSql As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim ret As Boolean = False
        Dim res = New InitResponse()

        If wKbn = "C" Then
            '--------------------
            '契約区分
            '--------------------
            Dim cdt = f_CodeMaster_Data_Select(1, 0)
            'データ結果判定
            If cdt.Rows.Count > 0 Then
                res.KEIYAKU_KBN_CD_NAME_LIST = New List(Of CodeNameModel)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In cdt.Rows
                    Dim item As New CodeNameModel
                    item.CODE = Cint(row("MEISYO_CD").ToString())
                    item.NAME = row("MEISYO").ToString()
                    res.KEIYAKU_KBN_CD_NAME_LIST.Add(item)
                Next
            End If

        End If
            
        '--------------------
        '事務委託先
        '--------------------
        sWhere = "KI = " & ki
        Dim jdt = f_JimuItaku_Data_Select(sWhere)
        'データ結果判定
        If jdt.Rows.Count > 0 Then
            res.ITAKU_CD_NAME_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In jdt.Rows
                Dim item As New CodeNameModel
                item.CODE = Cint(row("ITAKU_CD").ToString())
                item.NAME = row("ITAKU_NAME").ToString()
                res.ITAKU_CD_NAME_LIST.Add(item)
            Next
        End If

        '--------------------
        '契約者
        '--------------------
        sWhere = "KI = " & ki
        Dim kdt = f_Keiyaku_Data_Select(ki, True, String.Empty)
        'データ結果判定
        If kdt.Rows.Count > 0 Then
            res.KEIYAKUSYA_CD_NAME_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In kdt.Rows
                Dim item As New CodeNameModel
                item.CODE = Cint(row("KEIYAKUSYA_CD").ToString())
                item.NAME = row("KEIYAKUSYA_NAME").ToString()
                res.KEIYAKUSYA_CD_NAME_LIST.Add(item)
            Next
        End If

        res.KI= ki
        
        Return res
    End Function
#End Region

    End Module

End Namespace
