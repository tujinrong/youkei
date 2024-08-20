' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: メッセージ定義
'             
'作成日　　 : 2024.07.17
'作成者　　 : AIPlus
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Db

    Public Class DaOraDbContext
        Public Connection As OracleConnection

        Private _CommandTimeout As Integer

        Public Property CommandTimeout As Integer
            Get
                Return If(_CommandTimeout <= 0, _CommandTimeout, _CommandTimeout)
            End Get
            Set(value As Integer)
                _CommandTimeout = value
            End Set
        End Property

        Public Property DbContext As Object

        Public Property Unit As Object

        Public Property UserID As Object

        Public Property DbData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()


        Public Sub New()
        End Sub

        Public Sub New(connStr As String)
            Connection = New OracleConnection(DaGlobal.ConnectionString)
        End Sub

        Public Sub Dispose()
            If Connection IsNot Nothing Then
                Connection.Close()
                Connection.Dispose()
                Connection = Nothing
            End If
        End Sub
    End Class
End Namespace
