Imports System.Data
Imports Oracle.ManagedDataAccess.Client

Public Class OracleDbHelper
    Private connectionString As String

    Public Sub New(connString As String)
        connectionString = connString
    End Sub

    Public Function GetData(query As String) As DataTable
        Dim dt As New DataTable()

        Using conn As New OracleConnection(connectionString)
            Using cmd As New OracleCommand(query, conn)
                conn.Open()
                Dim reader As OracleDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using

        Return dt
    End Function
End Class