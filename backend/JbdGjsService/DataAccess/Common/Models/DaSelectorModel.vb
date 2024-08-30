' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ドロップダウンリスト
'
' 作成日　　: 2024.07.14
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaSelectorModel
        Public Property value As String   'コード
        Public Property label As String   '名称

        ''' <summary>
        ''' Cacheに使用
        ''' </summary>
        Public Sub New()
        End Sub

        Public Sub New(value As String, label As String)
            Me.value = If(value, String.Empty)
            Me.label = If(label, String.Empty)
        End Sub

        Public Overrides Function ToString() As String
            Return $"{value}{DaConst.SELECTOR_DELIMITER}{label}"
        End Function
    End Class
    Public Class DaSelectorKeyModel
        Inherits DaSelectorModel
        Public Property key As String   'キー項目(連動フィルター用)
        Public Sub New(value As String, label As String, key As String)
            MyBase.New(value, label)
            Me.key = If(key, String.Empty)
        End Sub
    End Class

    Public Class DaSelectorDisabledModel
        Inherits DaSelectorModel
        Public Property disabled As Boolean   '無効属性
        Public Sub New(value As String, label As String, Optional disabled As Boolean = False)
            MyBase.New(value, label)
            Me.disabled = DaConvertUtil.CBool(disabled)
        End Sub
    End Class

    Public Class DaSelectorTreeModel(Of T As DaSelectorModel)
        Inherits DaSelectorModel
        Public Property children As List(Of T) 'サブレベルオプション

        Public Sub New(value As String, label As String, Optional children As IEnumerable(Of T) = Nothing)
            MyBase.New(value, label)
            Me.children = If(children.ToList(), New List(Of T)())
        End Sub
    End Class
End Namespace
