' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通関数
'
' 作成日　　: 2024.07.16
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports JbdGjsService.JBD.GJS.Service.Common
Imports JbdGjsService.JBD.GJS.Db.DaCodeConst

Namespace JBD.GJS.Service
    Public Module CmLogicUtil
        '予約状態
        Public Const YOYAKUSTATUS1 As String = "空"
        Public Const YOYAKUSTATUS2 As String = "満"
        Public Const YOYAKUSTATUS3 As String = "超過"
        '基本事業保留個数(検診)
        Public Const AWSH001_CT As Integer = 49
        '拡事業開始事業コード(検診)
        Public Const AWSH001_ST As Integer = 50
        '不詳表記
        Private Const Fusyohyoki As String = "不詳"
        '警告非表示内容
        Private Const NoAuthWarningtext As String = "＊＊＊＊＊＊＊＊＊＊"
        '警告内容
        Private Const WarningtextPrefix As String = "支援措置対象者"
        '機能ID(検診固定頭)
        Private Const AWSH001 As String = "AWSH001"
        '予約状態
        Private Const YOYAKUSTATUS5 As String = "○"
        Private Const YOYAKUSTATUS6 As String = "待"


        ''' <summary>
        ''' 個人番号(DB)取得
        ''' </summary>
        ''' <paramname="personalno">個人番号(画面表示)</param>
        ''' <returns></returns>
        Public Function GetPersonalnoDB(personalno As String) As String
            If Not String.IsNullOrEmpty(personalno) Then
                Return Db.CmEncryptUtil.RsaDecryptAndAesEncrypt(personalno)
            End If
            Return Nothing
        End Function


        ''' <summary>
        ''' 年齢取得(○○か月)
        ''' </summary>
        Public Function GetAgeStr(bymd As Date, kijunymd As Date) As String
            Dim years = kijunymd.Year - bymd.Year
            Dim months = kijunymd.Month - bymd.Month
            Dim days = kijunymd.Day - bymd.Day
            If days < 0 Then
                months -= 1
            End If
            If months < 0 Then
                years -= 1
                months += 12
            End If

            Return $"{years}歳{months}か月"
        End Function


        ''' <summary>
        ''' 年度範囲チェック
        ''' </summary>
        Public Function CheckNendo(nendo As Integer, day As Date) As Boolean
            If day.Year = nendo AndAlso day.Month > 3 OrElse day.Year = nendo + 1 AndAlso day.Month < 4 Then
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' 一覧警告内容取得
        ''' </summary>
        ''' <paramname="db"></param>
        ''' <paramname="siensotikbn">支援措置区分</param>
        ''' <paramname="alertviewflg">警告参照フラグ</param>
        ''' <returns></returns>
        Public Function GetKeikoku(db As Db.DaDbContext, siensotikbn As String, alertviewflg As Boolean) As String
            Dim str = String.Empty
            If Not String.IsNullOrEmpty(siensotikbn) Then
                'str = If(alertviewflg, $"{WarningtextPrefix}{C_LEFT_BRACKET_FULL}{Gjs.Db.DaNameService.GetName(db, Gjs.Db.EnumNmKbn.支援措置区分, siensotikbn)}{C_RIGHT_BRACKET_FULL}", NoAuthWarningtext)
            End If
            Return str
        End Function

 
        Public Function GetSex(db As Db.DaDbContext, sex As String) As String
            If String.IsNullOrEmpty(sex) Then
                Return String.Empty
            End If
            Return Gjs.Db.DaNameService.GetName(db, Gjs.Db.EnumNmKbn.性別_システム共有, sex)
        End Function


        ''' <summary>
        ''' 住所取得
        ''' </summary>
        Public Function GetAdrs(jutokbn As Db.Enum住登区分, adrs1 As String, adrs2 As String, adrsFlg As Boolean) As String
            '住登区分により表示パターンが異なる
            Select Case jutokbn
                Case Db.Enum住登区分.住民
                    '住所
                    If adrsFlg Then
                        Return $"{adrs1}{adrs2}"
                    End If
                    Return Db.DaConvertUtil.CStr(adrs2)
                Case Db.Enum住登区分.住登外
                    '住所
                    Return $"{adrs1}{adrs2}"
                Case Else
                    Throw New ArgumentException("Enum住登区分 error")
            End Select
        End Function


        ''' <summary>
        ''' 世帯主宛名番号取得
        ''' </summary>
        Public Function GetSetainushi(dtl As List(Of Db.tt_afatenaDto)) As String
            '世帯主コード
            Dim cd = 名称マスタ.標準版.続柄._02
            '世帯主の宛名番号取得
            Dim atenano = If(dtl.Where(Function(x) Equals(x.zokucd1, cd) OrElse Equals(x.zokucd2, cd) OrElse Equals(x.zokucd3, cd) OrElse Equals(x.zokucd4, cd)).FirstOrDefault().atenano, String.Empty)

            Return atenano
        End Function


        ''' <summary>
        ''' 警告参照フラグ取得
        ''' </summary>
        Public Function GetAlertviewflg(db As Db.DaDbContext, token As String, userid As String, regsisyo As String) As Boolean
            Dim dto = GetDto(db, token, userid, regsisyo)
            Return dto.alertviewflg
        End Function

        ''' <summary>
        ''' 更新可能支所一覧取得
        ''' </summary>
        Public Function GetSisyoList(db As Db.DaDbContext, token As String, userid As String, regsisyo As String) As List(Of String)
            Dim dto = GetDto(db, token, userid, regsisyo)
            Return GetSisyoList(dto)
        End Function

        ''' <summary>
        ''' 個人番号権限フラグ取得
        ''' </summary>
        Public Function GetPersonalflg(db As Db.DaDbContext, token As String, userid As String, regsisyo As String, kinoid As String) As Boolean
            Dim dto = GetDto(db, token, userid, regsisyo)
            Dim list = GetAuthList(dto)
            Return GetPersonalflg(list, kinoid)
        End Function

        ''' <summary>
        ''' 画面権限一覧取得
        ''' </summary>
        Public Function GetAuthList(db As Db.DaDbContext, token As String, userid As String, regsisyo As String) As List(Of Db.GamenModel)
            Dim dto = GetDto(db, token, userid, regsisyo)
            Return GetAuthList(dto)
        End Function

        ''' <summary>
        ''' 権限取得
        ''' </summary>
        Public Function GetAuthVM(db As Db.DaDbContext, token As String, userid As String, regsisyo As String, kinoid As String) As CmAuthVM
            Dim vm = New CmAuthVM()
            Dim dto = GetDto(db, token, userid, regsisyo)
            vm.alertviewflg = dto.alertviewflg
            vm.editSisyos = GetSisyoList(dto)
            Dim list = GetAuthList(dto)
            vm.personalflg = GetPersonalflg(list, kinoid)

            Return vm
        End Function


        ''' <summary>
        ''' 個人番号操作権限付与フラグ(ログインユーザー)取得
        ''' </summary>
        Public Function GetPnoeditflg(db As Db.DaDbContext, token As String, userid As String, regsisyo As String) As Boolean
            Dim dto = GetDto(db, token, userid, regsisyo)
            Return dto.pnoeditflg
        End Function

        ''' <summary>
        ''' 事業コード一覧を取得
        ''' </summary>
        ''' <paramname="db"></param>
        ''' <paramname="kbn">事業コード区分</param>
        ''' <paramname="kinoid">機能ID</param>
        ''' <paramname="no">画面選択の場合のみ</param>
        ''' <returns></returns>
        Public Function GetJigyocdList(db As Db.DaDbContext, kbn As Enum事業コード区分, kinoid As String, no As String, hasStopFlg As Boolean) As List(Of String)
            '集約コードパターンEnum
            Dim kbn2 = GetPatternEnum(kinoid)
            '集約コードパターンNo
            Dim patternno As Integer = If(Equals(no, Nothing), Nothing, CmLogicUtil.GetPatternno(kinoid, no))

            Return GetJigyocdList(db, kbn, kinoid, kbn2, patternno, hasStopFlg)
        End Function

        ''' <summary>
        ''' 事業コード一覧を取得
        ''' </summary>
        ''' <paramname="db"></param>
        ''' <paramname="kbn">事業コード区分</param>
        ''' <paramname="kinoid">機能ID</param>
        ''' <paramname="kbn2">取得パターン：DB設定(1);画面選択(2)</param>
        ''' <paramname="patternno">パターンNo.：画面選択の場合のみ</param>
        ''' <returns></returns>
        Public Function GetJigyocdList(db As Db.DaDbContext, kbn As Enum事業コード区分, kinoid As String, kbn2 As Enum事業コードパターン, patternno As Integer, hasStopFlg As Boolean) As List(Of String)
            Dim list = GetJigyocdSelectorList(db, kbn, kinoid, Gjs.Db.Enum名称区分.名称, kbn2, patternno, hasStopFlg)
            Return list.[Select](Function(e) e.value).ToList()
        End Function
        ''' <summary>
        ''' パターンNoを取得
        ''' </summary>
        ''' <paramname="kinoid">機能ID</param>
        ''' <paramname="no">画面選択</param>
        ''' <returns></returns>
        Public Function GetPatternno(kinoid As String, no As String) As Integer
            Select Case kinoid
                '保健指導管理
                                '集団指導管理
                Case "AWKK00301G", "AWKK00303G"
                    'modify by zhang 20240604 begin
                    'switch (no)
                    'modify by zhang 20240604 end
                    Select Case no.PadLeft(2, "0"c)
                        Case 名称マスタ.システム.拡_予約_保健指導業務区分._01, 名称マスタ.システム.拡_予約_保健指導業務区分._02
                            Return Db.DaConvertUtil.CInt(no)
                        Case Else
                            Throw New Exception("集約コードパターン error")
                    End Select
                '妊産婦情報管理
                                '
                                '予防接種情報管理
                Case "AWBH00301G", "AWBH00401G", "AWYS00101G"
                    Return Db.DaConvertUtil.CInt(no)
                Case Else
                    Throw New Exception("集約コードパターン設定の機能ID error")
            End Select
        End Function

        ''' <summary>
        ''' 事業コード一覧を取得
        ''' </summary>
        Public Function GetJigyocdSelectorList(db As Db.DaDbContext, kbn As Enum事業コード区分, kinoid As String, kbn2 As Db.Enum名称区分, no As String, hasStopFlg As Boolean) As List(Of Db.DaSelectorModel)
            '集約コードパターンEnum
            Dim kbn3 = GetPatternEnum(kinoid)
            '集約コードパターンNo
            Dim patternno As Integer = If(Equals(no, Nothing), Nothing, CmLogicUtil.GetPatternno(kinoid, no))

            Return GetJigyocdSelectorList(db, kbn, kinoid, kbn2, kbn3, patternno, False)
        End Function

        ''' <summary>
        ''' 事業コード一覧を取得
        ''' </summary>
        Public Function GetJigyocdSelectorList(db As Db.DaDbContext, kbn As Enum事業コード区分, kinoid As String, kbn2 As Db.Enum名称区分, kbn3 As Enum事業コードパターン, patternno As Integer, hasStopFlg As Boolean) As List(Of Db.DaSelectorModel)
            '汎用コードを取得
            Dim code = kinoid
            If kbn3 = Enum事業コードパターン.画面選択 Then
                code = $"{code}{patternno}"
            End If

            Select Case kbn
                Case Else
                    Throw New Exception("Enum事業コード区分 error")
            End Select
        End Function


        ''' <summary>
        ''' 検索パラメータ取得(ドロップダウンリストのコード)
        ''' </summary>
        Public Function GetSearchPara(para As String) As String
            Return If(String.IsNullOrEmpty(para), Nothing, Db.GetCd(para))
        End Function


        ''' <summary>
        ''' 住民状態取得(ソート用)
        ''' </summary>
        Public Function CIntJuminjotaiSort(juminjotai As String) As Integer
            Dim kbn = Db.DaConvertUtil.CInt(juminjotai)
            If kbn = 1 Then
                Return 1
            Else
                Return 2
            End If
        End Function


        ''' <summary>
        ''' 計算処理(数式)
        ''' </summary>
        Public Function Calculate(keisansusiki As String) As Double
            Dim table As Data.DataTable = New Data.DataTable()
            table.Columns.Add("keisansusiki", GetType(String), keisansusiki)
            Dim row As Data.DataRow = table.NewRow()
            table.Rows.Add(row)
            Return Double.Parse(CStr(row("keisansusiki")))
        End Function

 
        ''' <summary>
        ''' 一覧選択リスト(条件コード)
        ''' </summary>
        Public Function GetFreeItemCdList(db As Db.DaDbContext, nmkbn As Db.Enum名称区分, inputtype As Db.Enum入力タイプ, kbn As Enum条件コード区分, ParamArray keys As String()) As List(Of Db.DaSelectorModel)
            Select Case inputtype
                Case Gjs.Db.Enum入力タイプ.コード_名称マスタ
                    Select Case kbn
                        Case Enum条件コード区分.コード1
                            Return Gjs.Db.DaNameService.GetSelectorList(db, Gjs.Db.EnumNmKbn.名称マスタメインコード, nmkbn)
                        Case Enum条件コード区分.コード2
                            If keys.Length = 0 Then
                                Return New List(Of Db.DaSelectorModel)()
                            End If
                            Return Gjs.Db.DaSelectorService.GetSelectorList(db, nmkbn, Gjs.Db.Enumシステムマスタ区分.名称メインマスタ, keys)
                        Case Enum条件コード区分.コード3
                            Return New List(Of Db.DaSelectorModel)()
                        Case Else
                            Throw New Exception("Enum条件コード区分 error")
                    End Select
                Case Gjs.Db.Enum入力タイプ.コード_汎用マスタ
                    Select Case kbn
                        Case Enum条件コード区分.コード1
                            Return Gjs.Db.DaNameService.GetSelectorList(db, Gjs.Db.EnumNmKbn.汎用マスタメインコード, nmkbn)
                        Case Enum条件コード区分.コード2
                            If keys.Length = 0 Then
                                Return New List(Of Db.DaSelectorModel)()
                            ElseIf keys.Length = 3 AndAlso Equals(Gjs.Db.DaConvertUtil.CStr(keys(0)), 名称マスタ.システム.名称マスタメインコード._3019) Then
                                '検診フリー項目の場合
                                'var dtl = db.tm_afhanyo_main.SELECT.WHERE.ByKey(CStr(keys[0])).GetDtoList();
                                '成人健（検）診事業コード=>No.
                                Dim ct = Gjs.Db.DaConvertUtil.CInt(keys(1))
                                'グループID
                                Dim kensinKbn = CType(Gjs.Db.DaConvertUtil.CInt(keys(2)), Db.EnumKensinKbn)
                                Dim subcdMin = 230001
                                Dim subcdMax = 270000
                                '標準
                                If ct <= AWSH001_CT Then
                                    If kensinKbn = Gjs.Db.EnumKensinKbn.一次 Then
                                        subcdMin = 230001 + 200 * (ct - 1)
                                    Else
                                        subcdMin = 240001 + 200 * (ct - 1)
                                    End If
                                    '拡
                                    subcdMax = subcdMin + 199
                                Else
                                    If kensinKbn = Gjs.Db.EnumKensinKbn.一次 Then
                                        subcdMin = 250002 + 200 * (ct - AWSH001_ST - 1)
                                        subcdMax = subcdMin + 198
                                    Else
                                        subcdMin = 260001 + 200 * (ct - AWSH001_ST - 1)
                                        subcdMax = subcdMin + 199
                                    End If
                                End If
                            End If
                            Return Gjs.Db.DaSelectorService.GetSelectorList(db, nmkbn, Gjs.Db.Enumシステムマスタ区分.汎用メインマスタ, keys)
                        Case Enum条件コード区分.コード3
                            Return New List(Of Db.DaSelectorModel)()
                        Case Else
                            Throw New Exception("Enum条件コード区分 error")
                    End Select
                Case Gjs.Db.Enum入力タイプ.コード_ユーザーマスタ
                    Select Case kbn
                        'Case Enum条件コード区分.コード1
                        '    Return DaSelectorServiceHelpers.GetSelectorList(db, nmkbn, Gjs.Db.Enumマスタ区分.所属グループマスタ)
                        Case Enum条件コード区分.コード2, Enum条件コード区分.コード3
                            Return New List(Of Db.DaSelectorModel)()
                        Case Else
                            Throw New Exception("Enum条件コード区分 error")
                    End Select
                Case Gjs.Db.Enum入力タイプ.コード_地区情報マスタ
                    Select Case kbn
                        Case Enum条件コード区分.コード1
                            Return Gjs.Db.DaNameService.GetSelectorList(db, Gjs.Db.EnumNmKbn.地区区分, nmkbn)
                        Case Enum条件コード区分.コード2, Enum条件コード区分.コード3
                            Return New List(Of Db.DaSelectorModel)()
                        Case Else
                            Throw New Exception("Enum条件コード区分 error")
                    End Select
                Case Gjs.Db.Enum入力タイプ.コード_所属グループマスタ, Gjs.Db.Enum入力タイプ.コード_会場情報マスタ, Gjs.Db.Enum入力タイプ.医療機関, Gjs.Db.Enum入力タイプ.事業従事者
                    Select Case kbn
                        Case Enum条件コード区分.コード1, Enum条件コード区分.コード2, Enum条件コード区分.コード3
                            Return New List(Of Db.DaSelectorModel)()
                        Case Else
                            Throw New Exception("Enum条件コード区分 error")
                            'todo
                    End Select

                Case Else
                    Throw New Exception("Enum入力タイプ error")
            End Select
        End Function


        ''' <summary>
        ''' 名称取得(項目)
        ''' </summary>
        Public Function GetFreeItemCdNm(db As Db.DaDbContext, cd As String, kbn As Enumフリーマスタ分類, inputtype As Db.Enum入力タイプ, codejoken1 As String, codejoken2 As String, codejoken3 As String, nmkbn As Db.Enum名称区分, kinoid As String, patternno As Integer) As String
            Dim list = GetFreeItemCdList(db, nmkbn, kbn, inputtype, codejoken1, codejoken2, codejoken3, kinoid, patternno)
            Dim name = list.Find(Function(e) Equals(e.value, cd))
            Return CmLogicUtil.GetCdNm(name, cd)
        End Function
        ''' <summary>
        ''' 名称取得(条件コード)リスト
        ''' </summary>
        Public Function GetFreeItemCdNm(db As Db.DaDbContext, nmkbn As Db.Enum名称区分, inputtype As Db.Enum入力タイプ, codejoken1 As String, codejoken2 As String, codejoken3 As String) As String()
            Dim strs = New String(2) {}
            If Not String.IsNullOrEmpty(codejoken1) Then
                'コード条件1(コード：名称)
                strs(0) = CmLogicUtil.GetFreeItemCdNm(db, Gjs.Db.Enum名称区分.名称, inputtype, Enum条件コード区分.コード1, codejoken1)
                If Not String.IsNullOrEmpty(codejoken2) Then
                    'コード条件2(コード：名称)
                    strs(1) = CmLogicUtil.GetFreeItemCdNm(db, Gjs.Db.Enum名称区分.名称, inputtype, Enum条件コード区分.コード2, codejoken2, codejoken1)
                End If
            End If
            Return strs
        End Function


        ''' <summary>
        ''' 詳細条件のコントローラータイプを取得
        ''' </summary>
        Public Function GetFreeKoumokuSethanyokbn1(inputtype As Db.Enum入力タイプ, ctrltype As Db.Enumコントローラータイプ) As String
            Select Case ctrltype
                Case Db.Enumコントローラータイプ.通用項目
                    Return Db.DaConvertUtil.EnumToStr(GetSearchSetType(inputtype))
                Case Db.Enumコントローラータイプ.一覧選択
                    Return Db.DaConvertUtil.EnumToStr(GetMstKbn(inputtype))
                Case Db.Enumコントローラータイプ.参照ダイアログ
                    Return Db.DaConvertUtil.EnumToStr(GetSearchDialogSetType(inputtype))
                Case Else
                    Throw New Exception("Enumコントローラータイプ error")
            End Select
        End Function


        ''' <summary>
        ''' 入力桁取得
        ''' </summary>
        Public Function GetKetas(keta As String) As (Integer, Integer)
            '入力桁リスト取得
            'Dim ketas = CommaStrToList(keta)
            Dim ketas = keta
            Dim keta1 As Integer = If(ketas.Count > 0, Db.DaConvertUtil.CInt(ketas(0)), Nothing)                   '入力桁(整数)
            Dim keta2 As Integer = If(ketas.Count = 2, Db.DaConvertUtil.CInt(ketas(1)), Nothing)                  '入力桁(小数)

            Return (keta1, keta2)
        End Function
        ''' <summary>
        ''' フリー項目初期設定(共通部分)
        ''' </summary>
        Public Function GetFreeVM(db As Db.DaDbContext, vm As FixFreeItemBaseVM, datatypes As List(Of Db.tm_afmeisyoDto), kbn As Enumフリーマスタ分類, kinoid As String, patternno As Integer, numvalue As Double, strvalue As String, fusyoflg As Boolean, itemcd As String, itemnm As String, groupid2 As String, tani As String, keta As String, hissuflg As Boolean, hanif As String, hanit As String, inputflg As Boolean, msgkbn As Db.EnumMsgCtrlKbn, biko As String, syokiti As String, inputtype As Db.Enum入力タイプ, codejoken1 As String, codejoken2 As String, codejoken3 As String) As FixFreeItemBaseVM
            vm.itemcd = itemcd             '項目コード

            '項目名
            If Not String.IsNullOrEmpty(tani) Then
                'vm.itemnm = $"{itemnm}{C_LEFT_BRACKET_FULL}{tani}{C_RIGHT_BRACKET_FULL}"
            Else
                vm.itemnm = itemnm
            End If
            vm.inputtypekbn = inputtype    '入力タイプ区分
            Dim ketas = GetKetas(keta)
            'vm.keta1 = ketas.keta1         '入力桁(整数部/文字)
            'vm.keta2 = ketas.keta2         '入力桁(小数部)
            vm.hissuflg = hissuflg         '必須フラグ
            vm.hanif = Gjs.Db.DaConvertUtil.CStr(hanif)         '入力範囲（開始）
            vm.hanit = Gjs.Db.DaConvertUtil.CStr(hanit)         '入力範囲（終了）
            vm.inputflg = inputflg         '入力フラグ
            vm.msgkbn = msgkbn             'メッセージ区分

            '入力区分関連情報を取得
            '保存型取得
            vm.biko = Gjs.Db.DaConvertUtil.CStr(biko)           '備考
            '画面項目入力区分
            ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
            '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
            '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
            '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
            '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
            ''' 
            ''' Input:
            ''' 
            '''             //入力区分関連情報を取得
            '''             var nmDto = datatypes.Find(x => x.nmcd == JBD.GJS.Db.DaConvertUtil.EnumToStr(inputtype))!;
            ''' 
            ''' 
            ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
            '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
            '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
            '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
            '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
            ''' 
            ''' Input:
            '''             //保存型取得
            '''             var savekbn = (JBD.GJS.Service.Enum入力値保存型)JBD.GJS.Db.DaConvertUtil.CInt(nmDto.hanyokbn1!);
            ''' 
            ''' 

            ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
            '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
            '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
            '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
            ''' 
            ''' Input:
            ''' 
            '''             vm.inputkbn = (JBD.GJS.Service.Enum画面項目入力)JBD.GJS.Db.DaConvertUtil.CInt(nmDto.hanyokbn3!)
            ''' 

            '初期値
            If Not String.IsNullOrEmpty(syokiti) AndAlso vm.inputkbn = Enum画面項目入力.選択 Then
                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
                ''' 
                ''' Input:
                '''                 vm.syokiti = JBD.GJS.Service.CmLogicUtil.GetFreeItemCdNm(db, syokiti!, kbn, inputtype, codejoken1, codejoken2, codejoken3, JBD.GJS.Db.Enum名称区分.名称, kinoid, patternno)
                ''' 
            Else
                vm.syokiti = Gjs.Db.DaConvertUtil.CStr(syokiti)
            End If

            '既存データがある場合
            'If numvalue Is Nothing OrElse Not String.IsNullOrEmpty(strvalue) Then
            '    '値
            '    Select Case savekbn
            '        Case Enum入力値保存型.数値
            '            vm.value = numvalue
            '        Case Enum入力値保存型.文字
            '            vm.value = strvalue
            '            If vm.inputkbn = Enum画面項目入力.選択 OrElse vm.inputkbn = Enum画面項目入力.選択_検索 Then
            '                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
            '                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
            '                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
            '                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
            '                ''' 
            '                ''' Input:
            '                '''                             vm.value = JBD.GJS.Service.CmLogicUtil.GetFreeItemCdNm(db, strvalue!, kbn, inputtype, codejoken1, codejoken2, codejoken3, JBD.GJS.Db.Enum名称区分.名称, kinoid, patternno)
            '                ''' 
            '            End If

            '        Case Else
            '            Throw New Exception("Enum入力値保存型 error")
            '    End Select
            '    vm.fusyoflg = fusyoflg '不詳フラグ
            'End If

            '一覧選択リスト
            vm.cdlist = New List(Of Db.DaSelectorModel)()
            If vm.inputkbn = Enum画面項目入力.選択 Then
                vm.cdlist = GetFreeItemCdList(db, Gjs.Db.Enum名称区分.名称, kbn, inputtype, codejoken1, codejoken2, codejoken3, kinoid, patternno)
            End If

            '参照ダイアログ
            If vm.inputkbn = Enum画面項目入力.選択_検索 Then
                Dim kbn2 As Db.Enum参照ダイアログ項目区分
                Select Case vm.inputtypekbn
                    Case Gjs.Db.Enum入力タイプ.医療機関
                        kbn2 = Gjs.Db.Enum参照ダイアログ項目区分.医療機関
                    Case Gjs.Db.Enum入力タイプ.事業従事者
                        kbn2 = Gjs.Db.Enum参照ダイアログ項目区分.事業従事者
                    Case Gjs.Db.Enum入力タイプ.検診実施機関
                        kbn2 = Gjs.Db.Enum参照ダイアログ項目区分.検診実施機関
                    Case Else
                        Throw New Exception("Enum入力値保存型 error")
                End Select

                vm.cdlist = CmLogicUtil.GetCdList(db, kinoid, Gjs.Db.DaConvertUtil.CNStr(patternno), kbn2)
            End If

            Return vm
        End Function
        ''' <summary>
        ''' 業務区分取得(基準値)
        ''' </summary>
        Public Function GetKijunGyomukbn(gyomukbn As String) As Enum基準値業務区分
            Select Case gyomukbn
                Case 名称マスタ.システム.基準値業務区分._01
                    Return Enum基準値業務区分.成人保健
                Case 名称マスタ.システム.基準値業務区分._02
                    Return Enum基準値業務区分.母子保健
                Case 名称マスタ.システム.基準値業務区分._03
                    Return Enum基準値業務区分.予防接種
                Case Else
                    Throw New Exception("業務区分 error")
            End Select
        End Function
        ''' <summary>
        ''' 業務区分取得(拡・予約・指導)
        ''' </summary>
        Public Function GetKakuYoyakuSidoGyomukbn(gyomukbn As String) As Enum拡予約指導業務区分
            Select Case gyomukbn
                Case 名称マスタ.システム.拡_予約_保健指導業務区分._01
                    Return Enum拡予約指導業務区分.成人保健
                Case 名称マスタ.システム.拡_予約_保健指導業務区分._02
                    Return Enum拡予約指導業務区分.母子保健
                Case 名称マスタ.システム.拡_予約_保健指導業務区分._03
                    Return Enum拡予約指導業務区分.予防接種
                Case Else
                    Throw New Exception("業務区分 error")
            End Select
        End Function
        ''' <summary>
        ''' 一覧選択リスト(項目)
        ''' </summary>
        Public Function GetFreeItemCdList(db As Db.DaDbContext, nmkbn As Db.Enum名称区分, freemstkbn As Enumフリーマスタ分類, inputtype As Db.Enum入力タイプ, codejoken1 As String, codejoken2 As String, codejoken3 As String, kinoid As String, patternno As Integer) As List(Of Db.DaSelectorModel)
            Dim keyList1 As List(Of String) = Nothing
            Dim keyList2 As List(Of String) = Nothing
            Select Case freemstkbn
                Case Enumフリーマスタ分類.成人
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, Nothing, False)
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, Nothing, False)
                Case Enumフリーマスタ分類.指導
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.画面選択, patternno, False)
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.画面選択, patternno, False)
                Case Enumフリーマスタ分類.母子
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, Nothing, False)
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, Nothing, False)
                Case Enumフリーマスタ分類.対象者抽出
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, Nothing, False)
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, Nothing, False)
                Case Else
                    Throw New Exception("Enumフリーマスタ分類 error")
            End Select

            Dim kbn = GetMstKbn(inputtype)
            Select Case kbn
                Case Gjs.Db.Enumマスタ区分.名称マスタ, Gjs.Db.Enumマスタ区分.汎用マスタ
                    Return GetCommonCdList(db, kbn, nmkbn, Nothing)
                Case Gjs.Db.Enumマスタ区分.ユーザーマスタ, Gjs.Db.Enumマスタ区分.地区情報マスタ
                    Return CmLogicUtil.GetCommonCdList(db, kbn, nmkbn, Nothing, Gjs.Db.DaConvertUtil.CStr(codejoken1))
                Case Gjs.Db.Enumマスタ区分.所属グループマスタ, Gjs.Db.Enumマスタ区分.会場情報マスタ
                    Return GetCommonCdList(db, kbn, nmkbn, Nothing)
                Case Gjs.Db.Enumマスタ区分.医療機関マスタ, Gjs.Db.Enumマスタ区分.医療機関マスタ_保険
                    Return GetCommonCdList(db, kbn, nmkbn, keyList1)
                Case Gjs.Db.Enumマスタ区分.事業従事者担当者情報マスタ
                    'todo
                    Return GetCommonCdList(db, kbn, nmkbn, keyList2)
                Case Else
                    Throw New Exception("フリー項目設定のマスタ区分エラー")
            End Select
        End Function
        ''' <summary>
        ''' 年齢範囲リスト取得
        ''' </summary>
        'Public Function ParseAgeRanges(ageStr As String) As HashSet(Of Integer)
        '    If String.IsNullOrEmpty(ageStr) Then Return New HashSet(Of Integer)(0)
        '    Dim ranges = New HashSet(Of Integer)()
        '    For Each part In ageStr.Split(C_COMMA)
        '        If part.Contains(C_DASHED) Then
        '            Dim rangeParts = part.Split(C_DASHED)
        '            Dim min = Integer.Parse(rangeParts(0))
        '            Dim max = Integer.Parse(rangeParts(1))
        '            For i = min To max
        '                ranges.Add(i)
        '            Next
        '        Else
        '            ranges.Add(Integer.Parse(part))
        '        End If
        '    Next
        '    Return ranges
        'End Function

        ''' <summary>
        ''' 予約状態
        ''' </summary>
        ''' <paramname="teiin">定員数</param>
        ''' <paramname="ct">申込人数</param>
        ''' <returns></returns>
        Public Function GetYoyakuStatus(teiin As Integer, ct As Integer) As String
            Dim i = teiin - ct
            If i = 0 Then
                Return YOYAKUSTATUS2
            ElseIf i > 0 Then
                Return YOYAKUSTATUS1
            Else
                Return YOYAKUSTATUS3
            End If
        End Function

        ''' <summary>
        ''' 予約状態
        ''' </summary>
        Public Function GetYoyakuStatus2(taikiflg As String) As String
            If String.IsNullOrEmpty(taikiflg) Then
                Return String.Empty
            ElseIf Equals(taikiflg, 名称マスタ.標準版.キャンセル待ち._1) Then
                Return YOYAKUSTATUS5
            Else
                Return YOYAKUSTATUS6
            End If
        End Function

        ''' <summary>
        ''' 名称取得(条件コード)
        ''' </summary>
        Private Function GetFreeItemCdNm(db As Db.DaDbContext, nmkbn As Db.Enum名称区分, inputtype As Db.Enum入力タイプ, kbn As Enum条件コード区分, cd As String, ParamArray keys As String()) As String
            Dim list = GetFreeItemCdList(db, nmkbn, inputtype, kbn, keys)
            Dim name = list.Find(Function(e) Equals(e.value, cd))
            Return CmLogicUtil.GetCdNm(name, cd)
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Private Function GetCdNm(model As Db.DaSelectorModel, cd As String) As String
            If model Is Nothing Then Return $"{cd}{Db.DaConst.SELECTOR_DELIMITER}"
            Return $"{cd}{Db.DaConst.SELECTOR_DELIMITER}{model.label}"
        End Function
        ''' <summary>
        ''' 行政区名称取得
        ''' </summary>
        'Private Function GetGyoseiku(kbn As Db.Enum地区区分, dtl As List(Of Db.tm_aftikuDto), code As String) As String
        '    If String.IsNullOrEmpty(code) Then Return String.Empty
        '    Dim dto = dtl.Find(Function(e) e.tikukbn = kbn AndAlso Equals(e.tikucd, code))
        '    If dto Is Nothing Then Return String.Empty
        '    Return
        'End Function
        ''' <summary>
        ''' ログイン時権限データ取得
        ''' </summary>
        Private Function GetDto(db As Db.DaDbContext, token As String, userid As String, regsisyo As String) As Db.tt_aftokenDto
            Dim tokenseq = Gjs.Db.CmTokenService.GetTokenUD(token, userid, regsisyo)
            Dim dto As Db.tt_aftokenDto = New Db.tt_aftokenDto()
            Return dto
            'return db.tt_aftoken.GetDtoByKey(tokenseq);
        End Function
        ''' <summary>
        ''' 画面権限一覧取得
        ''' </summary>
        Private Function GetAuthList(dto As Db.tt_aftokenDto) As List(Of Db.GamenModel)
            Dim list = New List(Of Db.GamenModel)()
            'if (!string.IsNullOrEmpty(dto.gamenauth))
            '{
            '    list = JsonConvert.DeserializeObject<List<GamenModel>>(dto.gamenauth)!;
            '}
            Return list
        End Function
        ''' <summary>
        ''' 更新可能支所一覧取得
        ''' </summary>
        Private Function GetSisyoList(dto As Db.tt_aftokenDto) As List(Of String)
            Dim list = New List(Of String)()
            If Not String.IsNullOrEmpty(dto.sisyocd) Then
                list = dto.sisyocd.Split.ToList()
            End If
            Return list
        End Function
        ''' <summary>
        ''' 個人番号権限フラグ取得
        ''' </summary>
        Private Function GetPersonalflg(list As List(Of Db.GamenModel), kinoid As String) As Boolean
            Dim auth = list.Find(Function(e) Equals(e.menuid, kinoid))
            If auth IsNot Nothing Then
                Return auth.personalnoflg
            End If
            Return False
        End Function
       

        ''' <summary>
        ''' 帳票ID取得
        ''' </summary>
        Private Function GetRptID(kinoid As String) As String
            'todo euc
            'kinoidで

            Return "0001"
        End Function
        ''' <summary>
        ''' 集約コード取得(事業コード)
        ''' </summary>
        Private Function GetCodeSet(db As Db.DaDbContext, code As String, kbn As Db.EnumHanyoKbn) As HashSet(Of String)
            '''名称マスタから画面対応する集約コードを取得する
            'var dto = DaHanyoService.GetHanyoDtl(db, kbn).Find(e => e.hanyocd == code);
            '''集約コード一覧を取得
            'if (dto != null && dto.hanyokbn1 != null)
            '{
            '    return dto.hanyokbn1.Split(C_COMMA).ToHashSet();
            '}

            Return New HashSet(Of String)()
        End Function


        ''' <summary>
        ''' マスタ区分取得
        ''' </summary>
        Private Function GetMstKbn(inputtype As Db.Enum入力タイプ) As Db.Enumマスタ区分
            Select Case inputtype
                Case Db.Enum入力タイプ.コード_名称マスタ
                    Return Db.Enumマスタ区分.名称マスタ
                Case Db.Enum入力タイプ.コード_汎用マスタ
                    Return Db.Enumマスタ区分.汎用マスタ
                Case Db.Enum入力タイプ.コード_ユーザーマスタ
                    Return Db.Enumマスタ区分.ユーザーマスタ
                Case Db.Enum入力タイプ.コード_所属グループマスタ
                    Return Db.Enumマスタ区分.所属グループマスタ
                Case Db.Enum入力タイプ.コード_地区情報マスタ
                    Return Db.Enumマスタ区分.地区情報マスタ
                Case Db.Enum入力タイプ.コード_会場情報マスタ
                    Return Db.Enumマスタ区分.会場情報マスタ
                Case Db.Enum入力タイプ.医療機関
                    Return Db.Enumマスタ区分.医療機関マスタ
                Case Db.Enum入力タイプ.事業従事者
                    Return Db.Enumマスタ区分.事業従事者担当者情報マスタ
                Case Db.Enum入力タイプ.検診実施機関
                    'todo
                    Return Db.Enumマスタ区分.医療機関マスタ_保険
                Case Else
                    Throw New Exception("Enum入力タイプ error")
            End Select
        End Function

        ''' <summary>
        ''' 参照ダイアログ区分取得
        ''' </summary>
        Private Function GetSearchDialogSetType(inputtype As Db.Enum入力タイプ) As Db.Enum参照ダイアログ項目区分
            Select Case inputtype
                Case Db.Enum入力タイプ.宛名番号
                    Return Db.Enum参照ダイアログ項目区分.宛名番号
                Case Db.Enum入力タイプ.医療機関
                    Return Db.Enum参照ダイアログ項目区分.医療機関
                Case Db.Enum入力タイプ.事業従事者
                    Return Db.Enum参照ダイアログ項目区分.事業従事者
                Case Db.Enum入力タイプ.検診実施機関
                    'todo
                    Return Db.Enum参照ダイアログ項目区分.検診実施機関
                Case Else
                    Throw New Exception("Enum入力タイプ error")
            End Select
        End Function
        ''' <summary>
        ''' コード一覧取得
        ''' </summary>
        Private Function GetCommonCdList(db As Db.DaDbContext, kbn As Db.Enumマスタ区分, nmkbn As Db.Enum名称区分, keyList As List(Of String), ParamArray keys As String()) As List(Of Db.DaSelectorModel)
            Select Case kbn
                'Case Gjs.Db.Enumマスタ区分.名称マスタ, Gjs.Db.Enumマスタ区分.汎用マスタ, Gjs.Db.Enumマスタ区分.所属グループマスタ, Gjs.Db.Enumマスタ区分.会場情報マスタ
                '    Return New Exception("Enumマスタ区分 error")
                'Case Gjs.Db.Enumマスタ区分.ユーザーマスタ, Gjs.Db.Enumマスタ区分.地区情報マスタ
                '    If Not String.IsNullOrEmpty(keys(0)) Then
                '        Return DaSelectorServiceHelpers.GetSelectorList(db, nmkbn, kbn, False, keys)
                '    End If
                '    Return DaSelectorServiceHelpers.GetSelectorList(db, nmkbn, kbn)
                'Case Gjs.Db.Enumマスタ区分.医療機関マスタ, Gjs.Db.Enumマスタ区分.医療機関マスタ_保険, Gjs.Db.Enumマスタ区分.事業従事者担当者情報マスタ
                '    If keyList IsNot Nothing Then
                '        Return Gjs.Db.DaSelectorService.GetSelectorList(db, nmkbn, kbn, False, Gjs.Db.DaConvertUtil.CStr(Gjs.Db.DaConvertUtil.ListToCommaStr(keyList)))
                '    End If
                '    'todo
                '    Return DaSelectorServiceHelpers.GetSelectorList(db, nmkbn, kbn)
                Case Else
                    Throw New Exception("Enumマスタ区分 error")
            End Select
        End Function
        ''' <summary>
        ''' 詳細条件項目区分取得
        ''' </summary>
        Private Function GetSearchSetType(inputtype As Db.Enum入力タイプ) As Enum項目区分
            Select Case inputtype
                Case Db.Enum入力タイプ.数値_整数, Db.Enum入力タイプ.数値_小数点付き実数, Db.Enum入力タイプ.数値_符号付き整数
                    Return Enum項目区分.数字
                Case Db.Enum入力タイプ.半角文字_半角数字, Db.Enum入力タイプ.半角文字_半角英数字, Db.Enum入力タイプ.半角文字_年, Db.Enum入力タイプ.半角文字_年_不詳あり, Db.Enum入力タイプ.半角文字_年月, Db.Enum入力タイプ.半角文字_年月_不詳あり, Db.Enum入力タイプ.半角文字_時刻, Db.Enum入力タイプ.半角文字_半角, Db.Enum入力タイプ.全角文字_全角_改行不可, Db.Enum入力タイプ.全角文字_全角_改行可, Db.Enum入力タイプ.全角半角文字_全角半角_改行不可, Db.Enum入力タイプ.全角半角文字_全角半角_改行可
                    Return Enum項目区分.文字
                Case Db.Enum入力タイプ.日付_年月日
                    Return Enum項目区分.日付
                Case Db.Enum入力タイプ.日付_年月日_不詳あり
                    Return Enum項目区分.日付不明
                Case Db.Enum入力タイプ.日時_年月日時分秒
                    Return Enum項目区分.日時
                Case Else
                    Throw New Exception("Enum入力タイプ error")
            End Select
        End Function
        ''' <summary>
        ''' 事業コードパターンを取得
        ''' </summary>
        ''' <paramname="kinoid">機能ID</param>
        ''' <returns></returns>
        Private Function GetPatternEnum(kinoid As String) As Enum事業コードパターン
            Select Case kinoid
                '保健指導管理
                                '集団指導管理
                Case "AWKK00301G", "AWKK00303G"
                    Return Enum事業コードパターン.画面選択
                Case Else
                    Return Enum事業コードパターン.DB設定
            End Select
        End Function

        ''' <summary>
        ''' 一覧選択リストを取得（参照ダイアログ項目用）
        ''' </summary>
        Public Function GetCdList(db As Db.DaDbContext, kinoid As String, patternno As String, kbn As Db.Enum参照ダイアログ項目区分, Optional hasStopFlg As Boolean = False) As List(Of Db.DaSelectorModel)
            '参照ダイアログ項目区分
            If kbn = Gjs.Db.Enum参照ダイアログ項目区分.医療機関 OrElse kbn = Gjs.Db.Enum参照ダイアログ項目区分.事業従事者 OrElse kbn = Gjs.Db.Enum参照ダイアログ項目区分.検診実施機関 Then
                '実施事業(表示範囲)
                'Dim keyList As List(Of String)
                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
                '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
                ''' 
                ''' Input:
                '''                 keyList = JBD.GJS.Service.CmLogicUtil.GetJigyocdList(db, kbn == JBD.GJS.Db.Enum参照ダイアログ項目区分.事業従事者 
                '''                                         JBD.GJS.Service.Enum事業コード区分.事業従事者 : JBD.GJS.Service.Enum事業コード区分.医療機関, kinoid!, patternno, false)
                ''' 

                '参照画面項目一覧取得(詳細条件)
                'Return GetSearchItemCdList(db, kbn, Gjs.Db.Enum名称区分.名称, keyList, hasStopFlg)
            End If

            Return New List(Of Db.DaSelectorModel)()
        End Function

        ''' <summary>
        ''' ユーザ領域コード最大値を取得
        ''' </summary>
        Public Function GetUserRyoikiMaxCd(keta As Integer) As Integer
            Dim maxCd = 0

            If Db.DaConvertUtil.CInt(keta) > 0 Then
                maxCd = CInt(Math.Pow(10, Db.DaConvertUtil.CInt(keta))) - 1
            Else
                maxCd = Integer.MaxValue
            End If

            Return maxCd
        End Function

    End Module
End Namespace
