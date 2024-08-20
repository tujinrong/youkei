' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 型変換共通関数
'
' 作成日　　: 2023.06.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Module DaConvertUtil
        ''' <summary>
        ''' objectを文字列に変換
        ''' </summary>
        Public Function [CStr](obj As Object) As String
            If obj Is Nothing OrElse obj Is Convert.DBNull Then Return String.Empty
            If TypeOf obj Is String Then Return obj.ToString()
            Return String.Empty
        End Function

        ''' <summary>
        ''' objectをnull許容型文字列に変換
        ''' </summary>
        Public Function CNStr(obj As Object) As String
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            If TypeOf obj Is String Then
                If String.IsNullOrEmpty([CStr](obj)) Then Return Nothing
                Return obj.ToString()
            End If
            Return String.Empty
        End Function

        ''' <summary>
        ''' objectを数字に変換、nullの場合、０にする
        ''' </summary>
        Public Function [CInt](obj As Object) As Integer
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return 0
            If TypeOf obj Is Integer Then Return Cint(obj)
            Dim i As Integer = Nothing
            Return If((Integer.TryParse(obj.ToString(), i)), i, 0)

            ''' <summary>
            ''' objectをnull許容型整数に変換
            ''' </summary>
        End Function

        ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: 種類 'System.ArgumentOutOfRangeException' の例外がスローされました。
        ''' パラメーター名:node
        ''' 実際の値は int or System.Enum です。
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertToVariableDeclaratorOrNull(IsPatternExpressionSyntax node)
        '''    場所 System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
        '''    場所 System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
        '''    場所 System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
        '''    場所 System.Linq.Buffer`1..ctor(IEnumerable`1 source)
        '''    場所 System.Linq.Enumerable.ToArray[TSource](IEnumerable`1 source)
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertToDeclarationStatement(List`1 des, List`1 isPatternExpressions)
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.InsertRequiredDeclarations(SyntaxList`1 convertedStatements, CSharpSyntaxNode originaNode)
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertStatement(StatementSyntax statement, CSharpSyntaxVisitor`1 methodBodyVisitor)
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.<>c__DisplayClass10_0.<ConvertStatements>b__0(StatementSyntax s)
        '''    場所 System.Linq.Enumerable.<SelectManyIterator>d__17`2.MoveNext()
        '''    場所 Microsoft.CodeAnalysis.SyntaxList`1.CreateNode(IEnumerable`1 nodes)
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertStatements(SyntaxList`1 statements, MethodBodyExecutableStatementVisitor iteratorState)
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertBody(BlockSyntax body, ArrowExpressionClauseSyntax expressionBody, Boolean hasReturnType, MethodBodyExecutableStatementVisitor iteratorState)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        ''' 
        '''         /// <summary>
        '''         /// objectをnull許容型整数に変換
        '''         /// </summary>
        '''         public static int CNInt(object obj)
        '''         {
        '''             if (obj is null || obj is System.DBNull) return null;
        '''             if ((object)obj is int or System.Enum) return (int)obj;
        '''             return int.TryParse(obj.ToString(), out int i)  i : null;
        '''         }
        ''' 
        ''' 

        ''' <summary>
        ''' objectをdoubleに変換。NULL及び変換できない場合、０にする
        ''' </summary>
        Public Function [CDbl](obj As Object) As Double
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return 0R
            If TypeOf obj Is Double Then Return CType(obj, Double)
            Dim i As Double = Nothing
            Return If(Double.TryParse(obj.ToString(), i), i, 0R)
        End Function

        ''' <summary>
        ''' objectをdoubleに変換。NULL及び変換できない場合、NULLにする
        ''' </summary>
        Public Function CNDbl(obj As Object) As Double
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            If TypeOf obj Is Double Then Return CDbl(obj)
            Dim i As Double = Nothing
            Return If(Double.TryParse(obj.ToString(), i), i, Nothing)
        End Function

        ''' <summary>
        ''' objectをDecimalに変換。NULL及び変換できない場合、0にする
        ''' </summary>
        Public Function [CDec](obj As Object) As Decimal
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return 0
            If TypeOf obj Is Decimal Then Return CType(obj, Decimal)
            Dim i As Decimal = Nothing
            Return If(Decimal.TryParse(obj.ToString(), i), i, 0)
        End Function

        ''' <summary>
        ''' objectをDecimalに変換。NULL及び変換できない場合、nullにする
        ''' </summary>
        Public Function CNDec(obj As Object) As Decimal
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            If TypeOf obj Is Decimal Then Return CDec(obj)
            Dim i As Decimal = Nothing
            Return If(Decimal.TryParse(obj.ToString(), i), i, Nothing)
        End Function
        ''' <summary>
        ''' objectをLongに変換。NULL及び変換できない場合、０にする
        ''' </summary>
        Public Function [CLng](obj As Object) As Long
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return 0L
            If TypeOf obj Is Long Then Return CType(obj, Long)
            Dim i As Long = Nothing
            Return If(Long.TryParse(obj.ToString(), i), i, 0L)
        End Function

        ''' <summary>
        ''' objectをLongに変換。NULL及び変換できない場合、nullにする
        ''' </summary>
        Public Function CNLng(obj As Object) As Long
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return 0L
            If TypeOf obj Is Long Then Return CLng(obj)
            Dim i As Long = Nothing
            Return If(Long.TryParse(obj.ToString(), i), i, Nothing)
        End Function


        ''' <summary>
        ''' objectをfloatに変換。NULL及び変換できない場合、０にする
        ''' </summary>
        Public Function [CSng](obj As Object) As Single
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return 0F
            If TypeOf obj Is Single Then Return CType(obj, Single)
            Dim i As Single = Nothing
            Return If(Single.TryParse(obj.ToString(), i), i, 0F)
        End Function
        ''' <summary>
        ''' objectをfloatに変換。NULL及び変換できない場合、Nullにする
        ''' </summary>
        Public Function CNSng(obj As Object) As Single
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            If TypeOf obj Is Single Then Return CSng(obj)
            Dim i As Single = Nothing
            Return If(Single.TryParse(obj.ToString(), i), i, Nothing)
        End Function

        ''' <summary>
        ''' objectを日付に変換、NULL及び変換できない場合、DateTime最小値にする
        ''' </summary>
        Public Function [CDate](obj As Object) As Date
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return New DateTime()
            If TypeOf obj Is Date Then Return CType(obj, Date)
            Dim i As Date = Nothing
            Return If(Date.TryParse(obj.ToString(), i), i, New DateTime())
        End Function

        ''' <summary>
        ''' objectを日付に変換、NULL及び変換できない場合、Nullにする
        ''' </summary>
        Public Function CNDate(obj As Object) As Date
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            If TypeOf obj Is Date Then Return CDate(obj)
            Dim i As Date = Nothing
            Return If(Date.TryParse(obj.ToString(), i), i, Nothing)
        End Function

        ''' <summary>
        ''' objectをTimeSpanに変換、NULL及び変換できない場合、TimeSpan最小値にする
        ''' </summary>
        Public Function CTimeSpan(obj As Object) As TimeSpan
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return New TimeSpan()
            If TypeOf obj Is TimeSpan Then Return CType(obj, TimeSpan)
            Dim i As TimeSpan = Nothing
            Return If(TimeSpan.TryParse(obj.ToString(), i), i, New TimeSpan())
        End Function

        ''' <summary>
        ''' objectをTimeSpanに変換、NULL及び変換できない場合、Nullにする
        ''' </summary>
        Public Function CNTimeSpan(obj As Object) As TimeSpan
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            Dim i As TimeSpan = Nothing
            Return If(TimeSpan.TryParse(obj.ToString(), i), i, Nothing)
        End Function


        ''' <summary>
        ''' object対象を論理値に変換。NULL及び変換できない場合、falseにする
        ''' </summary>
        Public Function [CBool](obj As Object) As Boolean
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return False
            If TypeOf obj Is Boolean Then Return CType(obj, Boolean)
            If Equals(obj.ToString(), "1") Then Return True
            If Equals(obj.ToString(), "0") Then Return False
            Dim i As Boolean = Nothing
            Return If(Boolean.TryParse(obj.ToString(), i), i, False)
        End Function

        ''' <summary>
        ''' object対象を論理値に変換。NULL及び変換できない場合、NULLにする
        ''' </summary>
        Public Function CNBool(obj As Object) As Boolean
            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
            If TypeOf obj Is Boolean Then Return CBool(obj)
            If Equals(obj.ToString(), "1") Then Return True
            If Equals(obj.ToString(), "0") Then Return False
            Dim i As Boolean = Nothing
            Return If(Boolean.TryParse(obj.ToString(), i), i, Nothing)
        End Function

        ''' <summary>
        ''' Enum型へ変換
        ''' </summary>
        'Public Function ParseEnum(Of TEnum As {Structure, [Enum]})(enumString As String) As TEnum
        '    Dim enumValue As TEnum = Nothing

        '    If [Enum].TryParse(enumString, enumValue) Then
        '        Return enumValue
        '    Else
        '        Throw New ArgumentException($"Invalid enum value: {enumString}")
        '    End If
        'End Function

        ''' <summary>
        ''' Enum型から文字に変換
        ''' </summary>
        Public Function EnumToStr(obj As [Enum]) As String
            If obj Is Nothing Then Return String.Empty
            Dim i = Convert.ToInt64(obj)
            If i = -1 Then Return String.Empty
            Return i.ToString()
        End Function

        ''' <summary>
        ''' Enum型から文字に変換
        ''' </summary>
        Public Function EnumToNStr(obj As [Enum]) As String
            If obj Is Nothing Then Return Nothing
            Return EnumToStr(obj)
        End Function

        ''' <summary>
        ''' 空白文字からnothingに変換
        ''' </summary>
        Public Function ToNStr(str As String) As String
            If String.IsNullOrEmpty(str) Then Return Nothing
            Return str
        End Function

        ''' <summary>
        ''' 数値から文字へ変換
        ''' </summary>
        Public Function ToStr(i As Integer) As String
            If i = 0 Then Return String.Empty
            Return i.ToString()
        End Function

        ''' <summary>
        ''' 空白ないリスト取得
        ''' </summary>
        Public Function NzStrList(str As String, list As List(Of String)) As List(Of String)
            If Not String.IsNullOrEmpty(str) Then list.Add(str)
            Return list
        End Function

        ''' <summary>
        ''' コードリスト取得(「,」区切り文字列から)
        ''' </summary>
        Public Function CommaStrToList(str As String) As List(Of String)
            Dim list = New List(Of String)()
            If Not String.IsNullOrEmpty(str) Then
                list = str.Split(COMMA).ToList()
            End If
            Return list
        End Function

        ''' <summary>
        ''' 「,」区切り文字列取得(コードリストから)
        ''' </summary>
        Public Function ListToCommaStr(cdList As List(Of String), Optional sortFlg As Boolean = True) As String
            Dim cd As String = Nothing
            If sortFlg Then cdList.Sort()
            If cdList.Count > 0 Then
                cd = String.Join(COMMA, cdList)
            End If

            Return cd
        End Function

        ''' <summary>
        ''' 「、」区切り文字列取得(名称リストから)
        ''' </summary>
        Public Function ListToCommaStr2(nmList As List(Of String)) As String
            Dim nm As String = Nothing
            If nmList.Count > 0 Then
                nm = String.Join(C_COMMA2, nmList)
            End If

            Return nm
        End Function

        ''' <summary>
        ''' 「、」区切り文字列取得(「,」区切り文字列から)
        ''' </summary>
        Public Function CommaStrToCommaStr2(str As String, nmList As List(Of DaSelectorModel), Optional sortFlg As Boolean = False) As String
            Dim cds = CommaStrToList(str)
            If sortFlg Then cds.Sort()
            Dim nms = nmList.Where(Function(e) cds.Contains(e.value)).[Select](Function(e) e.label).ToList()
            Return ListToCommaStr2(nms)
        End Function

        ''' <summary>
        ''' 論理値から文字型に変換
        ''' </summary>
        Public Function BoolToStr(flg As Boolean) As String
            If flg Then Return "1"
            Return "0"
        End Function
#Region "カナ変換"
        ''' <summary>
        ''' unicode差分(カタカナ-ひらがな)
        ''' </summary>
        ' Private ReadOnly offset As Integer = "ァ"c - "ぁ"c

        Private builder As StringBuilder = New StringBuilder()

        Private re As Regex = New Regex("[ｦ-ﾝ]ﾞ|[ｦ-ﾝ]ﾟ|[ｦ-ﾝ]")

        Public Function ToKana(str As String) As String
            'ひらがなからカタカナへ変換
            str = ToKatakana(str)
            '半角カタカナから全角カタカナへ変換
            str = ToFullKataKana(str)
            Return str
        End Function

        Public Function ToNKana(str As String) As String
            If String.IsNullOrEmpty(str) Then Return Nothing
            Return DaConvertUtil.ToKana(str)
        End Function

        Public Function ToNSeionKana(str As String) As String
            If String.IsNullOrEmpty(str) Then Return Nothing
            Return DaConvertUtil.ToSeion(DaConvertUtil.ToKana(str))
        End Function

        ''' <summary>
        ''' カナ変換(ひらがな=>カタカナ)
        ''' </summary>
        Public Function ToKatakana(str As String) As String
            Call builder.Clear()
            For Each c In str
                ' builder.Append(If(IsHiragana(c), Microsoft.VisualBasic.ChrW(c + offset), c))
            Next
            Return builder.ToString()
        End Function

        ''' <summary>
        ''' カナ変換(カタカナ=>ひらがな)
        ''' </summary>
        Public Function ToHiragana(str As String) As String
            Call builder.Clear()
            For Each c In str
                'builder.Append(If(IsKatakana(c), Microsoft.VisualBasic.ChrW(c - offset), c))
            Next
            Return builder.ToString()
        End Function

        ''' <summary>
        ''' カナ変換(半角カタカナ=>全角カタカナ)
        ''' </summary>
        Public Function ToFullKataKana(str As String) As String
            Dim output = re.Replace(str, Function(match) 'Matchした場合の処理
                                             If KanaChangeMap.ContainsKey(match.Value) Then '辞書にあれば辞書にある値を返す
                                                 Return KanaChangeMap(match.Value) '辞書になければつまり半角カタカナでなければ変換せずに返す
                                             Else
                                                 Return match.Value
                                             End If
                                         End Function)
            Return output
        End Function

        ''' <summary>
        ''' 清音化
        ''' </summary>
        Public Function ToSeion(str As String) As String
            str = str.Replace(SPACE, "").Replace(SPACE_FULL, "").Replace("ﾞ", "").Replace("ﾟ", "").Replace("ヴァ", "バ").Replace("ヴィ", "ビ").Replace("ヴ", "ブ").Replace("ハ", "ワ").Replace("ガ", "カ").Replace("ギ", "キ").Replace("グ", "ク").Replace("ゲ", "ケ").Replace("ゴ", "コ").Replace("ザ", "サ").Replace("ジ", "シ").Replace("ズ", "ス").Replace("ゼ", "セ").Replace("ゾ", "ソ").Replace("ダ", "タ").Replace("ヂ", "シ").Replace("ヅ", "ス").Replace("デ", "テ").Replace("ド", "ト").Replace("バ", "ワ").Replace("パ", "ワ").Replace("ビ", "ヒ").Replace("ピ", "ヒ").Replace("ブ", "フ").Replace("プ", "フ").Replace("ベ", "ヘ").Replace("ペ", "ヘ").Replace("ボ", "ホ").Replace("ポ", "ホ").Replace("ヲ", "オ").Replace("ヷ", "ワ").Replace("ヸ", "ヰ").Replace("ヹ", "ヱ").Replace("ヺ", "オ").Replace("ヾ", "ヽ").Replace("オウ", "オオ").Replace("コウ", "コオ").Replace("ソウ", "ソオ").Replace("トウ", "トオ").Replace("ノウ", "ノオ").Replace("ホウ", "ホオ").Replace("モウ", "モオ").Replace("ヨウ", "ヨオ").Replace("ロウ", "ロオ").Replace("ァ", "ア").Replace("ィ", "イ").Replace("ゥ", "ウ").Replace("ェ", "エ").Replace("ォ", "オ").Replace("ッ", "ツ").Replace("ャ", "ヤ").Replace("ュ", "ユ").Replace("ョ", "ヨ").Replace("ヮ", "ワ").Replace("ヵ", "カ").Replace("ヶ", "ケ")
            Return str
        End Function

        ''' <summary>
        ''' ひらがな範囲判断
        ''' </summary>
        Private Function IsHiragana(c As Char) As Boolean
            'ひらがな範囲
            Return c >= ChrW(12352) AndAlso c <= "ゟ"c
        End Function

        ''' <summary>
        ''' カタカナ範囲判断
        ''' </summary>
        Private Function IsKatakana(c As Char) As Boolean
            'カタカナ範囲
            Return c >= "゠"c AndAlso c <= "ヿ"c
        End Function
        ''' <summary>
        ''' 変換関係(半角カタカナ=>全角カタカナ)
        ''' </summary>
        Private ReadOnly KanaChangeMap As Dictionary(Of String, String) = New Dictionary(Of String, String) From {
    {"ｱ", "ア"},
    {"ｨ", "ィ"},
    {"ｲ", "イ"},
    {"ｩ", "ゥ"},
    {"ｳ", "ウ"},
    {"ｪ", "ェ"},
    {"ｴ", "エ"},
    {"ｫ", "ォ"},
    {"ｵ", "オ"},
    {"ｶ", "カ"},
    {"ｶﾞ", "ガ"},
    {"ｷ", "キ"},
    {"ｷﾞ", "ギ"},
    {"ｸ", "ク"},
    {"ｸﾞ", "グ"},
    {"ｹ", "ケ"},
    {"ｹﾞ", "ゲ"},
    {"ｺ", "コ"},
    {"ｺﾞ", "ゴ"},
    {"ｻ", "サ"},
    {"ｻﾞ", "ザ"},
    {"ｼ", "シ"},
    {"ｼﾞ", "ジ"},
    {"ｽ", "ス"},
    {"ｽﾞ", "ズ"},
    {"ｾ", "セ"},
    {"ｾﾞ", "ゼ"},
    {"ｿ", "ソ"},
    {"ｿﾞ", "ゾ"},
    {"ﾀ", "タ"},
    {"ﾀﾞ", "ダ"},
    {"ﾁ", "チ"},
    {"ﾁﾞ", "ヂ"},
    {"ｯ", "ッ"},
    {"ﾂ", "ツ"},
    {"ﾂﾞ", "ヅ"},
    {"ﾃ", "テ"},
    {"ﾃﾞ", "デ"},
    {"ﾄ", "ト"},
    {"ﾄﾞ", "ド"},
    {"ﾅ", "ナ"},
    {"ﾆ", "ニ"},
    {"ﾇ", "ヌ"},
    {"ﾈ", "ネ"},
    {"ﾉ", "ノ"},
    {"ﾊ", "ハ"},
    {"ﾊﾞ", "バ"},
    {"ﾊﾟ", "パ"},
    {"ﾋ", "ヒ"},
    {"ﾋﾞ", "ビ"},
    {"ﾋﾟ", "ピ"},
    {"ﾌ", "フ"},
    {"ﾌﾞ", "ブ"},
    {"ﾌﾟ", "プ"},
    {"ﾍ", "ヘ"},
    {"ﾍﾞ", "ベ"},
    {"ﾍﾟ", "ペ"},
    {"ﾎ", "ホ"},
    {"ﾎﾞ", "ボ"},
    {"ﾎﾟ", "ポ"},
    {"ﾏ", "マ"},
    {"ﾐ", "ミ"},
    {"ﾑ", "ム"},
    {"ﾒ", "メ"},
    {"ﾓ", "モ"},
    {"ｬ", "ャ"},
    {"ﾔ", "ヤ"},
    {"ｭ", "ュ"},
    {"ﾕ", "ユ"},
    {"ｮ", "ョ"},
    {"ﾖ", "ヨ"},
    {"ﾗ", "ラ"},
    {"ﾘ", "リ"},
    {"ﾙ", "ル"},
    {"ﾚ", "レ"},
    {"ﾛ", "ロ"},
    {"ﾜ", "ワ"},
    {"ｦ", "ヲ"},
    {"ﾝ", "ン"},
    {"ｰ", "ー"}
}
    End Module
#End Region
End Namespace
