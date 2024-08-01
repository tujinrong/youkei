Imports JbdGjsCommon

Interface InterfaceRptGJ1040
    Sub sub1(wkDSRep As DataSet, wkKbn As Integer)
End Interface

Public Class rptGJ1040
    Implements InterfaceRptGJ1040

    '前のページのグループ情報を保持
    Private lo_BeforeKenCD As String
    Private lo_BeforeKenNM As String
    Friend pKIKIN2 As Boolean       '2017/07/14　追加

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "契約者別契約情報入力確認チェックリスト(農場別等)"



    Sub sub1(wkDSRep As DataSet, wkKbn As Integer) Implements InterfaceRptGJ1040.sub1


    End Sub

End Class
