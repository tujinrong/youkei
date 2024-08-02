Imports System.Windows.Forms

Public Class GjsTool

    ''' <summary>
    ''' タイトル領域用メッセージ取得
    ''' </summary>
    ''' <returns>取得した文字列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetGjsMessage() As String

        Dim dSysdate As DateTime = DateTime.Today
        Dim sMessage As String = String.Empty

        Select Case dSysdate.Day
            Case 5
                sMessage = "Today is the egg day!"
        End Select


        Select Case dSysdate.ToString("yyyy/MM/dd")
            Case "2015/04/05", "2016/03/27", "2017/04/16", "2018/04/01", "2019/04/21", "2020/04/21"
                sMessage = "Let's celebrate the Spring! 'Easter'"
        End Select


        Select Case dSysdate.Month
            Case 1
                If dSysdate.Day < 8 Then
                    sMessage = "あけましておめでとうございます"
                End If

            Case 11
                If dSysdate.Day = 5 Then
                    sMessage = "Have a nice egg day!"
                End If
        End Select

        Return sMessage
    End Function

    '2015/02/26 JBD368 ADD ↓↓↓

    ''' <summary>
    ''' フォームサイズ設定変更
    ''' </summary>
    ''' <param name="frm">対象フォーム</param>
    ''' <remarks></remarks>
    Public Shared Sub SetFormSize(ByVal frm As System.Windows.Forms.Form)

        'フォームサイズが画面サイズを超える場合は高さを調整し、
        'フォームにスクロールを設定する

        Dim sizeChangeFlg As Boolean = False

        '現在のフォームの高さ、幅を取得
        Dim height As Integer = frm.Height
        Dim width As Integer = frm.Width

        'ディスプレイの作業領域の高さを取得
        Dim displayHeight As Integer = Screen.GetWorkingArea(frm).Height
        'ディスプレイの作業領域の幅を取得
        Dim displayWidth As Integer = Screen.GetWorkingArea(frm).Width

        'フォームの高さ調整
        If displayHeight < height Then
            sizeChangeFlg = True
            '2015/03/06 JBD368 UPD ↓↓↓
            'frm.Height = Screen.GetWorkingArea(frm).Height - 20     '20は見栄えのための微調整分
            frm.Height = Screen.GetWorkingArea(frm).Height - 5     '5は見栄えのための微調整分
            '2015/03/06 JBD368 UPD ↑↑↑
            frm.AutoScroll = True
        End If

        'フォームの幅調整
        If displayWidth < width Then
            frm.Width = Screen.GetWorkingArea(frm).Width - 10       '10は見栄えのための微調整分
            frm.AutoScroll = True
        Else
            If sizeChangeFlg Then
                frm.Width = width + 18      '18は見栄えのための微調整分
            End If
        End If

    End Sub
    '2015/02/26 JBD368 ADD ↑↑↑
End Class
