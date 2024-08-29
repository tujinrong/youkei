' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 型変換共通関数
'
' 作成日　　: 2023.06.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class DaFormatUtil
#Region "西暦"
        ''' <summary>
        ''' 日付編集
        ''' </summary>
        Public Function FormatYMD(value As Date) As String
            'If value Is Nothing Then Return String.Empty
            Return FormatYMD(value, DaConst.DateFormat)
        End Function

        ''' <summary>
        ''' 日付編集
        ''' </summary>
        'Public Function NFormatYMD(value As Date) As String
        '    If value Is Nothing Then Return Nothing
        '    Return FormatYMD(value, DaConst.DateFormat)
        'End Function

        ''' <summary>
        ''' 日付編集
        ''' </summary>
        Public Function FormatYMD(value As Date, format As String) As String
            'If value Is Nothing Then Return String.Empty
            Return CDate(value).ToString(format)
        End Function

        ''' <summary>
        ''' 時間表示
        ''' </summary>
        'Public Function FormatTime(value As Date) As String
        '    If value Is Nothing Then Return String.Empty
        '    Return FormatTime(CDate(value))
        'End Function
        ''' <summary>
        ''' 時間表示
        ''' </summary>
        Public Function FormatTime(value As Date) As String
            Return value.ToString("HH:mm:ss")
        End Function
        ''' <summary>
        ''' 時間表示(HHmm=>HH:mm)
        ''' </summary>
        Public Function FormatTime(value As String) As String
            If String.IsNullOrEmpty(value) Then Return String.Empty
            Return value.Insert(2, DaStrPool.COLON)
        End Function
        ''' <summary>
        ''' 時間範囲表示(HH:mm～HH:mm)
        ''' </summary>
        Public Function FormatTimeRange(tmf As String, tmt As String) As String
            Return $"{FormatTime(tmf)}{DaStrPool.C_TILDE_FULL}{FormatTime(tmt)}"
        End Function
        ''' <summary>
        ''' 日付範囲表示(和暦～和暦)
        ''' </summary>
        Public Function FormatWaKjYMDRange(ymdf As String, ymdt As String) As String
            Return $"{DaFormatUtil.FormatWaKjYMD(ymdf)}{DaStrPool.C_TILDE_FULL}{DaFormatUtil.FormatWaKjYMD(ymdt)}"
        End Function
        ''' <summary>
        ''' 時間表示
        ''' </summary>
        Public Function FormatTime2(value As Date) As String
            Return value.ToString("yyyyMMddHHmmss")
        End Function
        ''' <summary>
        ''' 時間表示
        ''' </summary>
        Public Function FormatTime(value As TimeSpan) As String
            Return String.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", value.Hours, value.Minutes, value.Seconds, value.Milliseconds)
        End Function
#End Region

#Region "西暦漢字"
        ''' <summary>
        ''' 年月編集
        ''' </summary>
        Public Function FormatKjYM(value As String) As String
            If String.IsNullOrEmpty(value) Then Return String.Empty
            If value.Length <> 6 Then Return String.Empty
            Dim strLeft = value.Substring(0, 4)
            Dim strRight = value.Substring(4, 2)
            Return $"{strLeft}年{strRight}月"
        End Function

        ''' <summary>
        ''' 年月日編集
        ''' </summary>
        Public Function FormatKjYMD(value As Date) As String
            Return value.ToString("yyyy年MM月dd日")
        End Function

        ''' <summary>
        ''' 年月日編集
        ''' </summary>
        'Public Function FormatKjYMD(value As Date) As String
        '    If value Is Nothing Then Return String.Empty
        '    Return
        'End Function

        ''' <summary>
        ''' 年月日編集
        ''' </summary>
        Public Function FormatKjYMD(value As String) As String
            If String.IsNullOrEmpty(value) Then Return String.Empty
            If value.Length = 10 Then
                Return $"{value.Substring(0, 4)}年{value.Substring(5, 2)}月{value.Substring(8, 2)}日"
            ElseIf value.Length = 8 Then
                Return $"{value.Substring(0, 4)}年{value.Substring(4, 2)}月{value.Substring(6, 2)}日"
            Else
                Return "ERROR"
            End If
        End Function

#End Region

#Region "和暦"

        ''' <summary>
        ''' 年月編集
        ''' </summary>
        'public static string FormatWaKjYM(string value)
        '{
        '    if (string.IsNullOrEmpty(value)) return string.Empty;
        '    if (value.Length != 6) return string.Empty;
        '    int y = DaConvertUtil.CInt(value.Substring(0, 4));
        '    int m = DaConvertUtil.CInt(value.Substring(4, 2));
        '    DateTime dt = new DateTime(y, m, 1);
        '    return AiDataUtil.FormatDate(dt, "ggyy年MM月");
        '}

        ''' <summary>
        ''' 和暦日付
        ''' </summary>
        'public static string FormatWaKjYMD(DateTime value)
        '{
        '    if (value == null) return string.Empty;
        '    return AiDataUtil.FormatDate(value!.Value, DaConst.JapanDateFormat);
        '}

        ''' <summary>
        ''' 和暦日付
        ''' </summary>
        'public static string FormatWaKjYMD(DateTime value)
        '{
        '    return AiDataUtil.FormatDate(value, DaConst.JapanDateFormat);
        '}

        ''' <summary>
        ''' 和暦日付
        ''' </summary>
        Public Shared Function FormatWaKjYMD(value As String) As String
            If String.IsNullOrEmpty(value) Then Return String.Empty
            Dim dt As Date = Nothing

            If Date.TryParse(value, dt) Then
                ' return AiDataUtil.FormatDate(dt, DaConst.JapanDateFormat);
                Return String.Empty
            Else
                Return String.Empty
            End If
        End Function
        ''' <summary>
        ''' 和暦日時
        ''' </summary>
        'public static string FormatWaKjDttm(DateTime value)
        '{
        '    if (value == null) return string.Empty;
        '    return AiDataUtil.FormatDate(value!.Value, DaConst.JapanTimeFormat);
        '}

        ''' <summary>
        ''' 和暦日時
        ''' </summary>
        'public static string FormatWaKjDttm(DateTime value)
        '{
        '    return AiDataUtil.FormatDate(value, DaConst.JapanTimeFormat);
        '}
        ''' <summary>
        ''' 和暦日時
        ''' </summary>
        'public static string FormatWaKjDttm2(DateTime value)
        '{
        '    return AiDataUtil.FormatDate(value, DaConst.JapanTimeFormat2);
        '}
#End Region

        ''' <summary>
        ''' 記号変換
        ''' </summary>
        Public Function FormatFlgStr(flg As Boolean) As String
            Return If(flg, "○", String.Empty)
        End Function

        ''' <summary>
        ''' 郵便番号変換
        ''' </summary>
        Public Function FormatYubin(yubin As String) As String
            If yubin.Length = 7 AndAlso Integer.TryParse(yubin, 1) Then
                '郵便番号をハイフン「-」で表示
                Return $"{yubin.Substring(0, 3)}-{yubin.Substring(3)}"
            End If

            Return String.Empty
        End Function
    End Class
End Namespace
