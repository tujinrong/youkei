' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ドロップダウンリスト
'
' 作成日　　: 2024.07.14
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class CodeNameModel
        Public Property CODE As Integer   'コード
        Public Property NAME As String   '名称

        ''' <summary>
        ''' Cacheに使用
        ''' </summary>
        Public Sub New()
        End Sub

        Public Sub New(value As String, label As String)
            Me.CODE = CInt(If(value, String.Empty))
            Me.NAME = If(label, String.Empty)
        End Sub

        Public Overrides Function ToString() As String
            Return $"{CODE}{DaConst.SELECTOR_DELIMITER}{NAME}"
        End Function
    End Class
    Public Class CodeNameKeyModel
        Inherits CodeNameModel
        Public Property key As String   'キー項目(連動フィルター用)
        Public Sub New(value As String, label As String, key As String)
            MyBase.New(value, label)
            Me.key = If(key, String.Empty)
        End Sub
    End Class

    Public Class CodeNameDisabledModel
        Inherits CodeNameModel
        Public Property disabled As Boolean   '無効属性
        Public Sub New(value As String, label As String, Optional disabled As Boolean = False)
            MyBase.New(value, label)
            Me.disabled = DaConvertUtil.CBool(disabled)
        End Sub
    End Class

    Public Class CodeNameTreeModel(Of T As CodeNameModel)
        Inherits CodeNameModel
        Public Property children As List(Of T) 'サブレベルオプション

        Public Sub New(value As String, label As String, Optional children As IEnumerable(Of T) = Nothing)
            MyBase.New(value, label)
            Me.children = If(children.ToList(), New List(Of T)())
        End Sub
    End Class
End Namespace
