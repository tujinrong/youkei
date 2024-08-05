' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ベースロジック
' 　　　　　　画面項目からDB項目に変換
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmConerterBase
        ''' <summary>
        ''' 検索入力欄(通常)
        ''' </summary>
        Public Shared Function ToLikeStr(value As String) As String
            If String.IsNullOrEmpty(value) Then
                Return Nothing
            End If
            Return $"%{value}%"
        End Function
        ''' <summary>
        ''' 検索入力欄(カナ)
        ''' </summary>
        Public Shared Function ToKanaLikeStr(value As String) As String
            If String.IsNullOrEmpty(value) Then
                Return Nothing
            End If

            Return $"%{Db.DaConvertUtil.ToKana(value)}%"
        End Function
        ''' <summary>
        ''' 検索入力欄(氏名カナ)
        ''' </summary>
        Public Shared Function ToKnameLikeStr(kname As String) As String
            If Not String.IsNullOrEmpty(kname) Then
                'カタカナへ変換
                kname = Db.DaConvertUtil.ToKana(kname)
                '清音化
                kname = Db.DaConvertUtil.ToSeion(kname)
                '%変換
                kname = kname.Replace("％", "%")
                Return $"{kname}%"
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
