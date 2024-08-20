' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: コントロールマスタ
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaControlService

        Private Shared _cache As MemoryCache
        Const CACHE_MINIUTE As Integer = 5


        ''' <summary>
        ''' キャシュークリア
        ''' </summary>
        Public Shared Sub ClearCache()
            _cache.Clear()
        End Sub

        'Public Shared Function GetList(db As DaDbContext, ParamArray ctrlKbns As EnumCtrlKbn()) As List(Of tm_afctrlDtoEx)
        '    Dim list = GetList(db)
        '    If ctrlKbns Is Nothing OrElse ctrlKbns.Length = 0 Then
        '        Return list
        '    End If
        '    Dim dic = GetDic(db)
        '    Return dic.Where(Function(d) ctrlKbns.Contains(d.Key)).SelectMany(Function(d) d.Value).ToList()
        'End Function

        'Public Shared Function GetList(db As DaDbContext, ctrlmaincd As String, ctrlsubcd As Integer) As List(Of tm_afctrlDtoEx)
        '    Dim dic = GetDic(db)
        '    Dim dtl As List(Of tm_afctrlDtoEx) = Nothing
        '    Return If(dic.TryGetValue(CType(DaConvertUtil.CInt(ctrlmaincd) * 100000000L + ctrlsubcd, EnumCtrlKbn), dtl), dtl, New List(Of tm_afctrlDtoEx)(0))
        'End Function

        'Public Shared Function GetRow(db As DaDbContext, ctrlKbn As EnumCtrlKbn, ctrCd As String) As tm_afctrlDtoEx
        '    Dim dic = GetDic(db)
        '    Return dic
        'End Function

        'Public Shared Function GetSystemConfig(db As DaDbContext) As SystemConfig
        '    Dim dic = GetDic(db)
        '    Dim value = dic(EnumCtrlKbn.config情報).Find(Function(x) Equals(x.ctrlcd, DaCodeConst.コントロールマスタ.システム.config情報._01)).value1
        '    Dim systemConfig As SystemConfig = New SystemConfig()
        '    ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '    '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
        '    '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '    '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        '    ''' 
        '    ''' Input:
        '    '''             systemConfig.TokenTimeout = value != null  System.TimeSpan.Parse(value!) : new System.TimeSpan(0, 1, 0, 0)
        '    ''' 
        '    Return systemConfig
        'End Function

        'Private Shared Function GetList(db As DaDbContext) As List(Of tm_afctrlDtoEx)
        '    If _cache Is Nothing Then
        '        _cache = New MemoryCache(New MemoryCacheOptions())
        '    End If

        '    ' list = db.tm_afctrl.SELECT.GetDtoList().Select(x => new tm_afctrlDtoEx(x)).ToList();
        '    Dim list As List(Of tm_afctrlDtoEx)
        '    ''' Cannot convert IfStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '    '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitIfStatement(IfStatementSyntax node)
        '    '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '    '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
        '    ''' 
        '    ''' Input:
        '    '''             if (!JBD.GJS.Db.DaControlService._cache.TryGetValue("LIST", out list!))
        '    '''             {
        '    '''                // list = db.tm_afctrl.SELECT.GetDtoList().Select(x => new tm_afctrlDtoEx(x)).ToList();
        '    '''                 JBD.GJS.Db.DaControlService._cache.Set("LIST", list, System.TimeSpan.FromMinutes(JBD.GJS.Db.DaControlService.CACHE_MINIUTE));
        '    ''' 
        '    '''             }
        '    ''' 
        '    ''' 

        '    Return list
        'End Function

        'Private Shared Function GetDic(db As DaDbContext) As Dictionary(Of EnumCtrlKbn, List(Of tm_afctrlDtoEx))
        '    Dim list = GetList(db)
        '    Dim dic = New Dictionary(Of EnumCtrlKbn, List(Of tm_afctrlDtoEx))()
        '    For Each row In list
        '        Dim key = CType(Integer.Parse(row.ctrlmaincd) * 100000000L + row.ctrlsubcd, EnumCtrlKbn)
        '        If Not dic.ContainsKey(key) Then
        '            dic(key) = New List(Of tm_afctrlDtoEx)()
        '        End If
        '        dic(key).Add(row)
        '    Next

        '    Return dic
        'End Function


        Public Class SystemConfig
            Public TokenTimeout As TimeSpan
        End Class
    End Class

    Public Class tm_afctrlDtoEx
        Inherits tm_afctrlDto
        Public EnumDataType As EnumDataType
        'Public ReadOnly Property IntValue1 As Integer
        '    Get
        '        Return If(EnumDataType = EnumDataType.整数, DaConvertUtil.CInt(value1), CSharpImpl.__Throw(Of Integer)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property IntValue2 As Integer
        '    Get
        '        Return If(EnumDataType = EnumDataType.整数 AndAlso rangeflg, DaConvertUtil.CInt(value2), CSharpImpl.__Throw(Of Integer)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property DecValue1 As Decimal
        '    Get
        '        Return If(EnumDataType = EnumDataType.小数, DaConvertUtil.CDec(value1), CSharpImpl.__Throw(Of Decimal)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property DecValue2 As Decimal
        '    Get
        '        Return If(EnumDataType = EnumDataType.小数 AndAlso rangeflg, DaConvertUtil.CDec(value2), CSharpImpl.__Throw(Of Decimal)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property StringValue1 As String
        '    Get
        '        Return If(EnumDataType = EnumDataType.文字列, DaConvertUtil.CStr(value1), CSharpImpl.__Throw(Of String)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property StringValue2 As String
        '    Get
        '        Return If(EnumDataType = EnumDataType.文字列 AndAlso rangeflg, DaConvertUtil.CStr(value2), CSharpImpl.__Throw(Of String)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property DateTimeValue1 As Date
        '    Get
        '        Return If(EnumDataType = EnumDataType.日付, DaConvertUtil.CDate(value1), CSharpImpl.__Throw(Of Date)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property DateTimeValue2 As Date
        '    Get
        '        Return If(EnumDataType = EnumDataType.日付 AndAlso rangeflg, DaConvertUtil.CDate(value2), CSharpImpl.__Throw(Of Date)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property TimeSpanValue1 As TimeSpan
        '    Get
        '        Return If(EnumDataType = EnumDataType.時間, DaConvertUtil.CTimeSpan(value1), CSharpImpl.__Throw(Of TimeSpan)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property TimeSpanValue2 As TimeSpan
        '    Get
        '        Return If(EnumDataType = EnumDataType.時間 AndAlso rangeflg, DaConvertUtil.CTimeSpan(value2), CSharpImpl.__Throw(Of TimeSpan)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property BoolValue1 As Boolean
        '    Get
        '        Return If(EnumDataType = EnumDataType.フラグ, DaConvertUtil.CBool(value1), CSharpImpl.__Throw(Of Boolean)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property BoolValue2 As Boolean
        '    Get
        '        Return If(EnumDataType = EnumDataType.フラグ AndAlso rangeflg, DaConvertUtil.CBool(value2), CSharpImpl.__Throw(Of Boolean)(New ArgumentException()))
        '    End Get
        'End Property

        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        ''' 
        '''         public int nIntValue1 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.整数)  JBD.GJS.Db.DaConvertUtil.CNInt(base.value1) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public int nIntValue2 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.整数 && base.rangeflg)  JBD.GJS.Db.DaConvertUtil.CNInt(base.value2) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public decimal nDecValue1 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.小数)  JBD.GJS.Db.DaConvertUtil.CNDec(base.value1) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public decimal nDecValue2 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.小数 && base.rangeflg)  JBD.GJS.Db.DaConvertUtil.CNDec(base.value2) : throw new System.ArgumentException();
        ''' 
        ''' 
        'Public ReadOnly Property nStringValue1 As String
        '    Get
        '        Return If(EnumDataType = EnumDataType.文字列, value1, CSharpImpl.__Throw(Of String)(New ArgumentException()))
        '    End Get
        'End Property
        'Public ReadOnly Property nStringValue2 As String
        '    Get
        '        Return If(EnumDataType = EnumDataType.文字列 AndAlso rangeflg, value2, CSharpImpl.__Throw(Of String)(New ArgumentException()))
        '    End Get
        'End Property

        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public System.DateTime nDateTimeValue1 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.日付)  JBD.GJS.Db.DaConvertUtil.CNDate(base.value1) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public System.DateTime nDateTimeValue2 => ((this.EnumDataType == JBD.GJS.Db.EnumDataType.日付) && base.rangeflg)  JBD.GJS.Db.DaConvertUtil.CNDate(base.value2) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public System.TimeSpan nTimeSpanValue1 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.時間)  JBD.GJS.Db.DaConvertUtil.CNTimeSpan(base.value1) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public System.TimeSpan nTimeSpanValue2 => ((this.EnumDataType == JBD.GJS.Db.EnumDataType.時間) && base.rangeflg)  JBD.GJS.Db.DaConvertUtil.CNTimeSpan(base.value2) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public bool nBoolValue1 => (this.EnumDataType == JBD.GJS.Db.EnumDataType.フラグ)  JBD.GJS.Db.DaConvertUtil.CNBool(base.value1) : throw new System.ArgumentException();
        ''' 
        ''' 
        ''' Cannot convert PropertyDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        '''         public bool nBoolValue2 => ((this.EnumDataType == JBD.GJS.Db.EnumDataType.フラグ) && base.rangeflg)  JBD.GJS.Db.DaConvertUtil.CNBool(base.value2) : throw new System.ArgumentException();
        ''' 
        ''' 

        Public Sub New(dto As tm_afctrlDto)
            ctrlmaincd = dto.ctrlmaincd         'コントロールメインコード
            ctrlsubcd = dto.ctrlsubcd          'コントロールサブコード
            ctrlcd = dto.ctrlcd                'コントロールコード
            itemnm = dto.itemnm                '項目名称
            datatype = dto.datatype            'データ型
            rangeflg = dto.rangeflg            '範囲フラグ
            value1 = dto.value1                '値１
            value2 = dto.value2                '値２
            EnumDataType = dto.datatype
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal throw statements")>
            Shared Function __Throw(Of T)(ByVal e As Exception) As T
                Throw e
            End Function
        End Class
    End Class
End Namespace
