' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 共通関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service

    Public Class DaUtil


        ''' <summary>
        ''' 現在日時
        ''' </summary>
        ''' <summary>
        ''' 現在日時
        ''' </summary>
        Public Shared ReadOnly Property Now As Date
            Get
                'Return SystemClock.Instance.GetCurrentInstant().InZone(CType(DaConst.TOKYO_TIME_ZONE, DateTimeZone)).ToDateTimeUnspecified()
                        ' 東京のタイムゾーン情報を取得
                Dim tokyoTimeZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time")
                ' 現在のUTC時刻を取得
                Dim utcNow As DateTime = DateTime.UtcNow
                ' 東京の現在の時刻を取得
                Return TimeZoneInfo.ConvertTimeFromUtc(utcNow, tokyoTimeZone)
            End Get
        End Property


        ''' <summary>
        ''' 今日
        ''' </summary>
        Public Shared ReadOnly Property Today As Date
            Get
                Return Now.Date
            End Get
        End Property


        ''' <summary>
        ''' 年度取得
        ''' </summary>
        Public Shared Function GetNendo(day As Date) As Integer
            Dim nendo = day.Year
            If day.Month >= 4 Then
                nendo += 1
            End If

            Return nendo
        End Function


        ''' <summary>
        ''' 年度末の取得
        ''' </summary>
        Public Shared Function GetNendoLastday() As Date
            Return GetNendoLastday(Today)
        End Function


        ''' <summary>
        ''' 年度末の取得
        ''' </summary>
        Public Shared Function GetNendoLastday([date] As Date) As Date
            Return New DateTime(GetNendo(Today), 3, 31)
        End Function


        ''' <summary>
        ''' 年齡計算
        ''' </summary>
        'public static int GetAge(DateTime birthday, DateTime kijunday)
        '{
        '    var localBirthday = LocalDate.FromDateTime(birthday);
        '    var localKijunday = LocalDate.FromDateTime(kijunday);
        '    var age = Period.Between(localBirthday, localKijunday).Years;
        '    if (localBirthday.PlusYears(age) > localKijunday)
        '    {
        '        age--;
        '    }

        '    return age;
        '}

        ''' <summary>
        ''' 年齡計算(本日)
        ''' </summary>
        'public static int GetAge(DateTime birthday)
        '{
        '    return GetAge(birthday, Today);
        '}


        ''' <summary>
        ''' メソッド説明を取得
        ''' </summary>
        ''' <paramname="method"></param>
        ''' <returns></returns>
        Public Shared Function GetMethodDesc(method As MethodBase) As String
            Try
            Dim displayNameAttribute As DisplayNameAttribute = CType(Attribute.GetCustomAttribute(method, GetType(DisplayNameAttribute)), DisplayNameAttribute)
            Return displayNameAttribute.DisplayName
            Catch
                Return ""
            End Try
        End Function


        ''' <summary>
        ''' サービスクラスの説明を取得
        ''' </summary>
        ''' <paramname="method"></param>
        ''' <returns></returns>
        Public Shared Function GetServiceDesc(method As MethodBase) As String
            Try
                Dim type As Type = method.DeclaringType
                Dim attribute As DisplayNameAttribute = type.GetCustomAttributes(GetType(DisplayNameAttribute), True).OfType(Of DisplayNameAttribute)().Single()
                Return attribute.DisplayName
            Catch
                Return ""
            End Try
        End Function


        ''' <summary>
        ''' 機能IDを取得
        ''' </summary>
        Public Shared Function GetKinoid(method As MethodBase) As String
            ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
            '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
            '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
            '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
            '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
            ''' 
            ''' Input:
            '''             System.Type type = @method.DeclaringType!;
            ''' 
            ''' 
            ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
            '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
            '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
            '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
            '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
            ''' 
            ''' Input:
            '''             var ns = @type.Namespace!;
            ''' 
            ''' 
            'Return ns.Substring(ns.LastIndexOf("."c) + 1)
            Return String.Empty

        End Function


        ''' <summary>
        ''' 四捨五入
        ''' </summary>
        Public Shared Function Round(d As Double, n As Integer) As Double
            Dim num = Math.Pow(10R, n)
            Dim i = d * num
            Dim r = Math.Round(i, MidpointRounding.AwayFromZero)
            Return r / num
        End Function


    End Class
End Namespace
