' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: API認証
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Public Enum Role
    User
    Everyone
End Enum

Namespace JBD.GJS.WebService
    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method)>
    Public Class AuthorizeAttribute
        Inherits Attribute
        Implements IAuthorizationFilter
        Private ReadOnly _roles As IList(Of Role)

        Public Sub New(ParamArray roles As Role())
            _roles = If(roles, New Role() {})
        End Sub

        Public Sub OnAuthorization(ByVal context As AuthorizationFilterContext) Implements IAuthorizationFilter.OnAuthorization
        End Sub
    End Class
End Namespace
