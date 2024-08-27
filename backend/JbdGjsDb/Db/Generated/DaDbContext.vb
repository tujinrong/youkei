'*******************************************************************
'業務名称  : 互助防疫システム
'機能概要　: DbContext
'　　　　　　
'作成日　　: 2024.07.17
'作成者　　: 宋 峰
'変更履歴:
'*******************************************************************

Namespace JBD.GJS.Db
    Public Class DaDbContext
        Implements IDisposable
        Public Property db As DaOraDbContext = New DaOraDbContext()

        Public Sub New()
            db = New DaOraDbContext(DaGlobal.ConnectionString)
            db.DbData("sessionid") = 0L
            db.DbContext = Me
            If db.Connection.State = Data.ConnectionState.Closed Then
                db.Connection.Open()
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            db.Connection?.Close()
            db.Connection?.Dispose()
            db.Connection = Nothing
        End Sub

    End Class
End Namespace
