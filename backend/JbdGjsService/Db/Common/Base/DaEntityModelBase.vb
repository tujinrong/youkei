' *******************************************************************
' 業務名称　: 生乳取引数量等確認事務支援システム
' 機能概要　: Modelベースクラス
'
' 作成日　　: 2022.08.03
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports Microsoft.VisualBasic.CompilerServices

Namespace JBD.GJS.Db
    Public Class DaEntityModelBase
        Public Function Copy() As Object
            Return MemberwiseClone()
        End Function

        Public Function Copy(Of T)() As T
            Return Conversions.ToGenericParameter(Of T)(MemberwiseClone())
        End Function
    End Class
End Namespace
