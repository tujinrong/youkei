' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: トークン管理
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports Newtonsoft.Json

Namespace Jbd.Gjs.Db
    Public Class DaTokenService
        ''' <summary>
        ''' ログインの時に呼び出し
        ''' </summary>
        ''' <paramname="SID"></param>
        ''' <returns></returns>
        'Public Shared Function SaveToken(db As DaDbContext, userid As String, regsisyo As String, userDto As tm_afuserDto) As Long
        '    ' 同じユーザー同時ログイン可
        '    'tc_aftokenDao.DELETE(new AiSessionModel()).WHERE.ByItem(nameof(tt_aftokenDto.userid), userid).Execute();
        '    Dim dto = GetDto(db, userid, regsisyo, userDto)
        '    'db.tt_aftoken.INSERT.Execute(dto);
        '    'db.tt_aftoken.DELETE.WHERE.ByFilter($"{nameof(tt_aftokenDto.accessdttm)}<@{nameof(tt_aftokenDto.accessdttm)}", DaUtil.Now.AddDays(-1)).Execute();
        '    Return dto.tokenseq
        'End Function

        Public Shared Function SaveToken(db As DaDbContext, userid As String) As Long
            ' 同じユーザー同時ログイン可
            'tc_aftokenDao.DELETE(new AiSessionModel()).WHERE.ByItem(nameof(tt_aftokenDto.userid), userid).Execute();
            Dim dto = GetDto(db, userid)
            'db.tt_aftoken.INSERT.Execute(dto);
            'db.tt_aftoken.DELETE.WHERE.ByFilter($"{nameof(tt_aftokenDto.accessdttm)}<@{nameof(tt_aftokenDto.accessdttm)}", DaUtil.Now.AddDays(-1)).Execute();
            Return dto.tokenseq
        End Function

        Public Shared Sub DeleteUserID(db As DaDbContext, userID As String)
            'db.tt_aftoken.DELETE.WHERE.ByItem(nameof(tt_aftokenDto.userid), userID).Execute();
        End Sub

        Public Shared Sub DeleteUserID(db As DaDbContext, list As List(Of String))
            ' db.tt_aftoken.DELETE.WHERE.ByItemList(nameof(tt_aftokenDto.userid), list).Execute();
        End Sub

        Public Shared Sub DeleteAll(db As DaDbContext)
            ' db.tt_aftoken.DELETE.WHERE.ByFilter("1=1").Execute();
        End Sub

        ''' <summary>
        ''' トークンに変換
        ''' </summary>
        Public Shared Function GetToken(tokenID As Long, userid As String, regsisyo As String) As String
            Return TokenEncrypt(tokenID.ToString(), userid, regsisyo)
        End Function

        ''' <summary>
        ''' トークンに変換
        ''' </summary>
        Public Shared Function GetTokenGjs(tokenID As String, userid As String, regsisyo As String) As String
            Return TokenEncrypt(tokenID, userid, regsisyo)
        End Function

        ''' <summary>
        ''' トークンIDに変換
        ''' </summary>
        Public Shared Function GetTokenUD(token As String, userid As String, regsisyo As String) As Long
            Return DaConvertUtil.CLng(TokenDecrypt(token, userid, regsisyo))
        End Function

        ''' <summary>
        ''' トークンIDに変換
        ''' </summary>
        Public Shared Function GetTokenUDGjs(token As String, userid As String, regsisyo As String) As String
            Return TokenDecrypt(token, userid, regsisyo)
        End Function

        ''' <summary>
        ''' トークンテーブル
        ''' </summary>
        Public Shared Function Validate(db As DaDbContext, token As String, ByRef userid As String, ByRef regsisyo As String, ByRef message As String) As Boolean
            Dim tokenseq = GetTokenUD(token, userid, regsisyo)
            Console.WriteLine("=============tokenseq===========")
            Console.WriteLine(tokenseq)
            Console.WriteLine(DaUtil.Now)
            ' var dto = db.tt_aftoken.GetDtoByKey(tokenseq);
            'if (dto is null)
            '{
            '    message = "検証失敗！";
            '    return false;
            '}
            'var lasttime = dto.accessdttm;
            'var TimeOut = lasttime.Add(DaControlService.GetSystemConfig(db).TokenTimeout);
            'Console.WriteLine("=============lasttime===========");
            'Console.WriteLine(lasttime);
            Console.WriteLine(DaUtil.Now)
            Console.WriteLine("=============TimeOut===========")
            'Console.WriteLine(TimeOut);
            'Console.WriteLine(DaUtil.Now);
            'if (TimeOut < DaUtil.Now)
            '{
            '    //db.tt_aftoken.DeleteByKey(tokenseq);
            '    message = "期限が切れた！";
            '    return false;
            '}
            'else
            '{
            '    //dto.accessdttm = DaUtil.Now;
            '    //db.tt_aftoken.UpdateDto(dto);
            '    //userid = dto.userid;
            '    return true;
            '}
            Return True
            'message = "検証成功";
        End Function
        ''' <summary>
        ''' トークンテーブル
        ''' </summary>
        Private Shared Function GetDto(db As DaDbContext, userid As String, regsisyo As String, userDto As tm_afuserDto) As tt_aftokenDto
            Dim dto = New tt_aftokenDto()
            dto.userid = userid                'ユーザーID
            dto.regsisyo = regsisyo            '登録支所
            dto.accessdttm = DaUtil.Now        'アクセス日時
            dto.syozokucd = userDto.syozokucd  '所属グループコード

            '権限設定がユーザー権限の場合
            If userDto.authsetflg Then
                dto.rolekbn = Enumロール区分.ユーザー
                dto.kanrisyaflg = userDto.kanrisyaflg                                                                  '管理者フラグ
                dto.pnoeditflg = userDto.pnoeditflg                                                                    '個人番号操作権限付与フラグ
                dto.alertviewflg = userDto.alertviewflg                                                                '警告参照フラグ
                dto.sisyocd = String.Join(COMMA, GetSisyoList(db, Enumロール区分.ユーザー, userid))                    '更新可能支所一覧
                '権限設定が所属権限の場合
                dto.gamenauth = System.Text.Json.JsonSerializer.Serialize(GetGamenAuthList(db, Enumロール区分.ユーザー, userid))     '画面権限(共通バーを含む)
            Else
                ' var syozokuDto = db.tm_afsyozoku.GetDtoByKey(userDto.syozokucd!);
                dto.rolekbn = Enumロール区分.所属                '更新可能支所一覧
                '画面権限(共通バーを含む)
                'dto.kanrisyaflg = syozokuDto.kanrisyaflg;                                                                   //管理者フラグ
                'dto.pnoeditflg = syozokuDto.pnoeditflg;                                                                     //個人番号操作権限付与フラグ
                'dto.alertviewflg = syozokuDto.alertviewflg;                                                                 //警告参照フラグ
                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
                ''' 
                ''' Input:
                '''                 //dto.kanrisyaflg = syozokuDto.kanrisyaflg;                                                                   //管理者フラグ
                '''                 //dto.pnoeditflg = syozokuDto.pnoeditflg;                                                                     //個人番号操作権限付与フラグ
                '''                 //dto.alertviewflg = syozokuDto.alertviewflg;                                                                 //警告参照フラグ
                '''                 dto.sisyocd = string.Join(Jbd.Gjs.Db.DaStrPool.COMMA, Jbd.Gjs.Db.DaTokenService.GetSisyoList(db, Jbd.Gjs.Db.Enumロール区分.所属, userDto.syozokucd!))
                ''' 
                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
                ''' 
                ''' Input:
                '''                 dto.gamenauth = Newtonsoft.Json.JsonConvert.SerializeObject(Jbd.Gjs.Db.DaTokenService.GetGamenAuthList(db, Jbd.Gjs.Db.Enumロール区分.所属, userDto.syozokucd!))
                ''' 
            End If
            Return dto
        End Function

        Private Shared Function GetDto(db As DaDbContext, userid As String) As tt_aftokenDto
            Dim dto = New tt_aftokenDto()
            dto.userid = userid                'ユーザーID
            dto.regsisyo = "0"            '登録支所
            dto.accessdttm = DaUtil.Now        'アクセス日時
            dto.syozokucd = "0"  '所属グループコード

            '権限設定がユーザー権限の場合
            'If userDto.authsetflg Then
            '    dto.rolekbn = Enumロール区分.ユーザー
            '    dto.kanrisyaflg = userDto.kanrisyaflg                                                                  '管理者フラグ
            '    dto.pnoeditflg = userDto.pnoeditflg                                                                    '個人番号操作権限付与フラグ
            '    dto.alertviewflg = userDto.alertviewflg                                                                '警告参照フラグ
            '    dto.sisyocd = String.Join(COMMA, GetSisyoList(db, Enumロール区分.ユーザー, userid))                    '更新可能支所一覧
            '    '権限設定が所属権限の場合
            '    dto.gamenauth = JsonConvert.SerializeObject(GetGamenAuthList(db, Enumロール区分.ユーザー, userid))     '画面権限(共通バーを含む)
            'Else
                ' var syozokuDto = db.tm_afsyozoku.GetDtoByKey(userDto.syozokucd!);
                dto.rolekbn = Enumロール区分.所属                '更新可能支所一覧
                '画面権限(共通バーを含む)
                'dto.kanrisyaflg = syozokuDto.kanrisyaflg;                                                                   //管理者フラグ
                'dto.pnoeditflg = syozokuDto.pnoeditflg;                                                                     //個人番号操作権限付与フラグ
                'dto.alertviewflg = syozokuDto.alertviewflg;                                                                 //警告参照フラグ
                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
                ''' 
                ''' Input:
                '''                 //dto.kanrisyaflg = syozokuDto.kanrisyaflg;                                                                   //管理者フラグ
                '''                 //dto.pnoeditflg = syozokuDto.pnoeditflg;                                                                     //個人番号操作権限付与フラグ
                '''                 //dto.alertviewflg = syozokuDto.alertviewflg;                                                                 //警告参照フラグ
                '''                 dto.sisyocd = string.Join(Jbd.Gjs.Db.DaStrPool.COMMA, Jbd.Gjs.Db.DaTokenService.GetSisyoList(db, Jbd.Gjs.Db.Enumロール区分.所属, userDto.syozokucd!))
                ''' 
                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
                ''' 
                ''' Input:
                '''                 dto.gamenauth = Newtonsoft.Json.JsonConvert.SerializeObject(Jbd.Gjs.Db.DaTokenService.GetGamenAuthList(db, Jbd.Gjs.Db.Enumロール区分.所属, userDto.syozokucd!))
                ''' 
            'End If
            Return dto
        End Function

        ''' <summary>
        ''' 更新可能支所一覧
        ''' </summary>
        Private Shared Function GetSisyoList(db As DaDbContext, rolekbn As Enumロール区分, roleid As String) As List(Of String)
            Dim list = New List(Of String)()
            'var dtl = db.tt_afauthsisyo.SELECT.WHERE.ByKey(EnumToStr(rolekbn), roleid).GetDtoList();
            'list = dtl.Select(e => e.sisyocd).ToList();
            Return list
        End Function
        ''' <summary>
        ''' 画面権限一覧
        ''' </summary>
        Private Shared Function GetGamenAuthList(db As DaDbContext, rolekbn As Enumロール区分, roleid As String) As List(Of GamenModel)
            Dim list = New List(Of GamenModel)()
            'var dtl = db.tt_afauthgamen.SELECT.WHERE.ByKey(EnumToStr(rolekbn), roleid).GetDtoList();
            'foreach (var dto in dtl)
            '{
            '    list.Add(GetModel(dto));
            '}
            Return list
        End Function
        ''' <summary>
        ''' 画面権限
        ''' </summary>
        Private Shared Function GetModel(dto As tt_afauthgamenDto) As GamenModel
            Dim model = New GamenModel()
            model.programkbn = dto.programkbn          'プログラム区分(0:画面;1:共通バー)
            model.menuid = dto.kinoid                  '機能ID
            model.addflg = dto.addflg                  '追加権限フラグ
            model.updateflg = dto.updateflg            '修正権限フラグ
            model.deleteflg = dto.deleteflg            '削除権限フラグ
            model.personalnoflg = dto.personalnoflg    '個人番号利用権限フラグ
            Return model
        End Function
    End Class
End Namespace
