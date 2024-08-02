' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: チェック処理
' 
' 作成日　　: 2024.07.10
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Service
    Public Class CmCheckService
        ''' <summary>
        ''' 存在チェック
        ''' </summary>
        Public Shared Function CheckExist(obj As Object, res As Db.DaResponseBase, msg As String) As Boolean
            If obj Is Nothing Then
                res.SetServiceError(msg)
                Return False
            End If
            Return True
        End Function

        ''' <summary>
        ''' 存在チェック
        ''' </summary>
        Public Shared Function CheckExist(obj As Object, res As Db.DaResponseBase, msgID As Db.EnumMessage, ParamArray param As String()) As Boolean
            If obj Is Nothing Then
                res.SetServiceError(msgID, param)
                Return False
            End If
            Return True
        End Function

        ''' <summary>
        ''' データ存在チェック
        ''' </summary>
        Public Shared Function CheckDeleted(res As Db.DaResponseBase, dto As Object) As Boolean
            Dim msg = Db.DaMessageService.GetMsg(Db.EnumMessage.DATA_NOTEXIST_ERROR, "更新対象", "更新")
            Return CheckDeleted(res, dto, msg)
        End Function

        ''' <summary>
        ''' データ存在チェック
        ''' </summary>
        Public Shared Function CheckDeleted(res As Db.DaResponseBase, dto As Object, msgID As Db.EnumMessage, ParamArray param As String()) As Boolean
            Dim msg = Db.DaMessageService.GetMsg(msgID, param)
            Return CheckDeleted(res, dto, msg)
        End Function

        ''' <summary>
        ''' データ存在チェック
        ''' </summary>
        Public Shared Function CheckDeleted(res As Db.DaResponseBase, dto As Object, msg As String) As Boolean
            If dto Is Nothing Then
                res.SetServiceError(msg)
                Return False
            Else
                Dim infos = dto.GetType().GetProperties().ToList()
                If infos.Exists(Function(x) Equals(x.Name, NameOf(Db.tm_afuserDto.stopflg))) Then
                    ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                    '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
                    '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
                    '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                    '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
                    ''' 
                    ''' Input:
                    '''                     bool stopflg = (bool)(dto.GetType().GetProperty((System.String)(nameof((System.Boolean)(Jbd.Gjs.Db.tm_afuserDto.stopflg))))!.GetValue(dto)!);
                    ''' 
                    ''' 
                    'If stopflg Then
                    res.SetServiceError(msg)
                        Return False
                    ' End If
                End If
            End If
            Return True
        End Function

        '''' <summary>
        '''' キーの重複チェック
        '''' </summary>
        'public static bool CheckDuplicatKey(Exception ex, string keyName, CmResponseBase res)
        '{
        '    if (ex.GetType() == typeof(AiDbException))
        '    {
        '        AiDbException aiex = (AiDbException)ex;
        '        if (aiex.ExcetionType == EnumDbExcetionType.KeyDuplicate)
        '        {
        '            // 入力された{0}は既に登録されています。
        '            res.ReturnCode = EnumServiceResult.ServiceError;
        '            res.Message = DaMessageService.GetMsg(EnumMessage.CM_KEYDUPLICATE_ERROR, keyName);

        '            return false;
        '        }
        '        else
        '        {
        '            throw ex;
        '        }
        '    }
        '    else
        '    {
        '        throw ex;
        '    }
        '}

        '''' <summary>
        '''' メッセージボックス設定
        '''' </summary>
        'private static void SetMsgType(EnumMsgKBN kbn, CmSearchResponseBase res, string msg)
        '{
        '    switch (kbn)
        '    {
        '        case EnumMsgKBN.エラー:
        '            {
        '                res.ReturnCode = EnumServiceResult.ServiceError;
        '                break;
        '            }
        '        case EnumMsgKBN.確認:
        '            {
        '                res.ReturnCode = EnumServiceResult.OK;
        '                break;
        '            }
        '    }
        '    res.Message = msg;
        '}

        '''' <summary>
        '''' 存在チェック
        '''' </summary>
        'public static bool CheckItemExist<T>(DaDbContext db,string tableName, string itenName, string value, CmResponseBase res, string message) where T : notnull
        '{
        '    var selecthelper = DaDaoBase.GetSelectHelper<T>(db.Session,tableName);
        '    if (selecthelper.WHERE.ByItem(itenName, value).Exists())
        '    {
        '        res.ReturnCode = EnumServiceResult.ServiceError;
        '        res.Message = message;
        '        return false;
        '    }
        '    return true;
        '}

        '''' <summary>
        '''' 最大行数チェック
        '''' </summary>
        ''' Public Shared Function CheckSearchCount(cnt As Integer, maxConfirm As Integer, MaxError As Integer, res As CmSearchResponseBase) As Boolean
        'public static bool CheckSearchCount(int cnt, int MaxError, CmSearchResponseBase res)
        '{
        '    if (MaxError != 0 && cnt > MaxError)
        '    {
        '        // SetMsgType(EnumMsgKBN.エラー, res, DaMessageService.GetMsg(EnumMessage.E00001, MaxError))
        '        SetMsgType(EnumMsgKBN.エラー, res, $"{MaxError}件以上検索不可");
        '        return false;
        '    }
        '    // If maxConfirm <> 0 AndAlso cnt > maxConfirm Then
        '    // SetMsgType(EnumMsgKBN.確認, res, DaMessageService.GetMsg(EnumMessage.E00001, maxConfirm))
        '    // Return False
        '    // End If
        '    return true;
        '}
    End Class
End Namespace
