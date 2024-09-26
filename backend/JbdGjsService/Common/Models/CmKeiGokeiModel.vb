' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ドロップダウンリスト
'
' 作成日　　: 2024.07.14
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class CmKeiGokeiModel
        Public Property SAIRANKEI_SEIKEI As Integer? = Nothing   '採卵鶏(成鶏)
        Public Property SAIRANKEI_IKUSEIKEI As Integer? = Nothing   '採卵鶏(育成鶏)
        Public Property NIKUYOUKEI As Integer? = Nothing   '肉用鶏
        Public Property SYUKEI_SEIKEI As Integer? = Nothing   '種鶏(成鶏)
        Public Property SYUKEI_IKUSEIKEI As Integer? = Nothing   '種鶏(育成鶏)
        Public Property UZURA As Integer? = Nothing   'うずら
        Public Property AHIRU As Integer? = Nothing   'あひる
        Public Property KIJI As Integer? = Nothing   'きじ
        Public Property HOROHOROTORI As Integer? = Nothing   'ほろほろ鳥
        Public Property SICHIMENCHOU As Integer? = Nothing   '七面鳥
        Public Property DACHOU As Integer? = Nothing   'だちょう

        ''' <summary>
        ''' Cacheに使用
        ''' </summary>
        Public Sub New()
        End Sub
    End Class

End Namespace
