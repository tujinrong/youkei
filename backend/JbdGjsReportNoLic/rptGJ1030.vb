Imports JbdGjsCommon
Imports Oracle.ManagedDataAccess.Client
Interface InterfaceRptGJ1030
    Sub sub1(wkDSRep As DataSet)
End Interface

Public Class rptGJ1030
    Implements InterfaceRptGJ1030
    ''' <summary>
    ''' 2行ごとの線引きカウント
    ''' </summary>
    ''' <remarks></remarks>
    Dim LineCount As Integer = 0
    ''' <summary>
    ''' 2行ごとの線引きカウント
    ''' </summary>
    ''' <remarks></remarks>
    Dim LineCount2 As Integer = 0
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "家畜防疫互助基金契約者一覧表(連絡用)"





    '2017/07/14　追加終了







    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ1030.sub1
        ' Insert code here that implements this method.

    End Sub
End Class
