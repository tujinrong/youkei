﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ドロップダウンリスト
'
' 作成日　　: 2024.07.14
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class CmDateFmToModel
        Public Property VALUE_FM As DateTime?   'From日付
        Public Property VALUE_TO As DateTime?   'To日付

        ''' <summary>
        ''' Cacheに使用
        ''' </summary>
        Public Sub New()
        End Sub
    End Class

End Namespace
