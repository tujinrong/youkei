' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 検索処理
' 　　　　　　レスポンスインターフェースベース
' 作成日　　: 2024.07.26
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmSearchResponseBase
        Inherits DaResponseBase
        Public Property TOTAL_PAGE_COUNT As Integer = Nothing     'ページ数
        Public Property TOTAL_ROW_COUNT As Integer  = Nothing    '総件数

        ''' <summary>
        ''' ページャー設定
        ''' </summary>
        Public Sub SetPageInfo(total As Integer, pagesize As Integer)
            TOTAL_PAGE_COUNT = CInt((total + pagesize - 1) / pagesize)    'ページ数
            TOTAL_ROW_COUNT = total                                 '総件数
        End Sub

        ''' <summary>
        ''' 上限件数チェック
        ''' </summary>
        Public Function CheckTotal(total As Integer, queryflg As Boolean) As Boolean
            TOTAL_PAGE_COUNT = total
            'todo warning num and error num
            Const waringNum = 20
            Const errorNum = 2 * waringNum
            If TOTAL_PAGE_COUNT >= errorNum Then
                'todo error msg
                SetServiceError("error msg")
                Return False
            End If

            If queryflg = True OrElse TOTAL_PAGE_COUNT < waringNum Then Return True

            'todo warning msg
            SetServiceAlert("warning msg")

            Return False
        End Function

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New()

        End Sub
    End Class
End Namespace
