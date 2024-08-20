'*******************************************************************
'業務名称  : 互助防疫システム
'機能概要　: DbContext
'　　　　　　
'作成日　　: 2024.07.17
'作成者　　: AIPlus
'変更履歴:
'*******************************************************************

Namespace JBD.GJS.Service
    Public Class DaDbContext
        Implements IDisposable
        Public Property Session As SessionContext = New SessionContext()

        Public Sub New()
            Call DaGlobal.InitDbLib()
            Session = New SessionContext(DaGlobal.ConnectionString)
            Session.SessionData(DaConst.SessionID) = 0L
            Session.DbContext = Me
        End Sub

        Public Sub New(req As DaRequestBase)
            Call DaGlobal.InitDbLib()
            Session.Connection = New DaOraDbContext(DaGlobal.ConnectionString).Connection
            Session.UserID = req.USER_ID
            Session.SessionData(NameOf(DaRequestBase.ip)) = req.ip
            Session.SessionData(NameOf(DaRequestBase.Service)) = req.Service
            Session.SessionData(NameOf(DaRequestBase.Method)) = req.Method
            Session.SessionData(NameOf(DaRequestBase.ServiceDesc)) = req.ServiceDesc
            Session.SessionData(NameOf(DaRequestBase.MethodDesc)) = req.MethodDesc
            Session.SessionData(NameOf(DaRequestBase.os)) = req.os
            Session.SessionData(NameOf(DaRequestBase.browser)) = req.browser
            Session.SessionData(NameOf(DaRequestBase.sessionid)) = req.sessionid
            Session.DbContext = Me
            If Session.Connection.State = Data.ConnectionState.Closed Then
                Session.Connection.Open()
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Session.Connection?.Close()
            Session.Connection?.Dispose()
            Session.Connection = Nothing
        End Sub

    End Class
End Namespace
