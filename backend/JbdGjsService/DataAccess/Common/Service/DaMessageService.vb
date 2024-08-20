' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: メッセージ処理
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaMessageService
        Private Shared MsgDic As Dictionary(Of String, MessageModel)
        Private Shared MsgNoDic As Dictionary(Of String, MessageModel)

        Shared Sub New()
            MsgDic = New Dictionary(Of String, MessageModel)()
            ReadFile("msg.ts", MsgDic)
            MsgNoDic = MsgDic.Values.ToDictionary(Function(e) e.MsgNo, Function(e) e)
        End Sub

        Public Shared Function GetMsg(id As EnumMessage, ParamArray param As Object()) As String
            Dim m = GetMsgModel(id).Msg & "(" & GetMsgModel(id).MsgNo & ")"
            Return String.Format(m, param)
        End Function
        Public Shared Function GetMsg(msgNo As String, ParamArray param As Object()) As String
            If MsgNoDic.ContainsKey(msgNo) = False Then
                Return "メッセージNoが存在しません"
            End If
            Dim msgModel = MsgNoDic(msgNo)
            Dim m = msgModel.Msg & "(" & msgModel.MsgNo & ")"
            Return String.Format(m, param)
        End Function

        Public Shared Function GetMsgModel(id As EnumMessage) As MessageModel
            Call ReadFile()
                        ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
'''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input:
            Dim key = System.Enum.GetName(GetTYpe (EnumMessage), id)


            If MsgDic.ContainsKey(key) = False Then
                Throw New Exception("メッセージファイルは最新ではありません")
            End If
            Return MsgDic(key)
        End Function

        Public Shared Function GetViewModelList() As List(Of MessageViewModel)
            Call ReadFile()
            Return MsgDic.[Select](Function(e) New MessageViewModel(e.Key, e.Value.MsgNo, e.Value.Msg)).OrderBy(Function(e) e.MessageNo).ToList()
        End Function

        Private Shared Sub ReadFile()
            If MsgDic Is Nothing OrElse MsgDic.Count = 0 Then
                MsgDic = New Dictionary(Of String, MessageModel)()
                ReadFile("msg.ts", MsgDic)
                MsgNoDic = MsgDic.Values.ToDictionary(Function(e) e.MsgNo, Function(e) e)
            End If
        End Sub

        Private Shared Sub ReadFile(file As String, dic As Dictionary(Of String, MessageModel))
            Dim loc = AppDomain.CurrentDomain.BaseDirectory & "bin"
            'Dim fPath As String
            'If Directory.Exists(loc) Then
            '    fPath = Path.Combine(loc, "Resource", file)
            'Else
            '    loc = AppDomain.CurrentDomain.BaseDirectory
            '    fPath = Path.Combine(loc, "Resource", file)
            'End If
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
            Dim enc = Encoding.GetEncoding("Shift_JIS")
            'Using sr = New StreamReader(fPath, enc)
            '    While sr.Peek() >= 0
            '        Dim s As String = If(sr.ReadLine(), String.Empty)
            '        Dim words = GetWords(s)
            '        Dim model = New MessageModel()
            '        model.MsgNo = words(1)
            '        model.Msg = words(2)
            '        dic.Add(words(0), model)
            '    End While
            'End Using
        End Sub

        Private Shared Function GetWords(s As String) As String()
            Dim list = New List(Of String)()

            Dim ptn = "const\s([A-Z0-9_]+)\s*\=\s*\{\s*No:\s*\'([A-Z0-9]+)\',\s*Msg:\s*\'([^']+)"
            Dim gs = Regex.Matches(s, ptn)
            Dim g = gs(0)

            list.Add(g.Groups(1).Value)
            list.Add(g.Groups(2).Value)
            list.Add(g.Groups(3).Value.Replace("\n", Environment.NewLine))

            Return list.ToArray()
        End Function
    End Class

    Public Class MessageModel
        Public Property MsgNo As String
        Public Property Msg As String
    End Class

    Public Class MessageViewModel
        Public Property MessageNo As String
        Public Property Message As String
        Public Property Key As String

        Public Sub New(desc As String, MsgNo As String, Msg As String)
            Key = desc
            MessageNo = MsgNo
            Message = Msg
        End Sub
    End Class
End Namespace
