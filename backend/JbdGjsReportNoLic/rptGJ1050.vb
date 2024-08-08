Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ1050
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ1050
    Implements InterfaceRptGJ1050

    '前のページのグループ情報を保持
    Private lo_KeiyakusyaCD As String
    Private lo_KeiyakusyaCD_CNT As Integer = 0
    Private cnt_line As Integer = 0 '2021/04/13 JBD9020 R03年度追加基金対応 ADD
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加

    Private mae_Jimu As String '2021/04/13 JBD9020 R03年度追加基金対応 ADD

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "事務委託先別・契約者別生産者積立金等一覧表（仮計算）"


    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ1050.sub1


    End Sub


End Class
