' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 
' 
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmGlobal
        Private Shared _RuntimeMode As EnumRuntimeMode = EnumRuntimeMode.NORMAL

        Public Shared Property RuntimeMode As EnumRuntimeMode
            Get
                Return _RuntimeMode
            End Get
            Set(value As EnumRuntimeMode)
                _RuntimeMode = value
            End Set
        End Property
    End Class
End Namespace
