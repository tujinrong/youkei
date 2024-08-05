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
        Inherits Db.DaResponseBase
        Public Property totalpagecount As Integer     'ページ数
        Public Property totalrowcount As Integer      '総件数

        ''' <summary>
        ''' ページャー設定
        ''' </summary>
        Public Sub SetPageInfo(total As Integer, pagesize As Integer)
            totalpagecount = (total + pagesize - 1) / pagesize    'ページ数
            totalrowcount = total                                 '総件数
        End Sub

        ''' <summary>
        ''' 上限件数チェック
        ''' </summary>
        Public Function CheckTotal(total As Integer, queryflg As Boolean) As Boolean
            totalrowcount = total
            'todo warning num and error num
            Const waringNum = 20
            Const errorNum = 2 * waringNum
            If totalrowcount >= errorNum Then
                'todo error msg
                SetServiceError("error msg")
                Return False
            End If

            If queryflg = True OrElse totalrowcount < waringNum Then Return True

            'todo warning msg
            SetServiceAlert("warning msg")

            Return False
        End Function
    End Class
End Namespace
