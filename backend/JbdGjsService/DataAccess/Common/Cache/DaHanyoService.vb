' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 汎用マスタ
'
' 作成日　　: 2023.07.05
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Module DaHanyoService
        ''' <summary>
        ''' 汎用データ(1件)
        ''' </summary>
        'public static tm_afhanyoDto GetHanyoDto(DaDbContext db, EnumHanyoKbn kbn, string cd)
        '{
        '    var maincd = ((long)kbn / DaNameService.MAINCODE_DIGIT).ToString();
        '    var subcd = (int)((long)kbn % DaNameService.MAINCODE_DIGIT);
        '    //return db.tm_afhanyo.GetDtoByKey(maincd, subcd, cd);
        '}
        '''' <summary>
        '''' 汎用データ(1件)
        '''' </summary>
        'public static tm_afhanyoDto GetHanyoDto(DaDbContext db, string maincd, int subcd, string cd)
        '{
        '   // return db.tm_afhanyo.GetDtoByKey(maincd, subcd, cd);
        '}
        ''' <summary>
        ''' 汎用データ一覧
        ''' </summary>
        'public static List<tm_afhanyoDto> GetHanyoDtl(DaDbContext db, string maincd, int subcd)
        '{
        '   // return db.tm_afhanyo.SELECT.WHERE.ByKey(maincd, subcd).GetDtoList().OrderBy(e => e.orderseq == null).ThenBy(e => e.orderseq).ThenBy(e => e.hanyocd).ToList();
        '}
        ''' <summary>
        ''' 汎用データ一覧
        ''' </summary>
        'public static List<tm_afhanyoDto> GetHanyoDtl(DaDbContext db, EnumHanyoKbn kbn)
        '{
        '    var maincd = ((long)kbn / DaNameService.MAINCODE_DIGIT).ToString();
        '    var subcd = (int)((long)kbn % DaNameService.MAINCODE_DIGIT);
        '    return GetHanyoDtl(db, maincd, CInt(subcd));
        '}
        '''' <summary>
        '''' 汎用データ一覧
        '''' </summary>
        'public static List<tm_afhanyoDto> GetHanyoDtl(DaDbContext db, string keycd)
        '{
        '    var keys = keycd.Split(DaStrPool.C_DASHED);
        '    return GetHanyoDtl(db, keys[0], CInt(keys[1]));
        '}
        ''' <summary>
        ''' 汎用データ一覧
        ''' </summary>
        Public Function GetHanyoDtl(dtl As List(Of tm_afhanyoDto), kbn As EnumHanyoKbn) As List(Of tm_afhanyoDto)
            Dim maincd = (CLng(kbn) / 100000000L).ToString()
            Dim subcd = CInt(kbn Mod 100000000L)
            Return dtl.Where(Function(e) Equals(e.hanyomaincd, maincd) AndAlso e.hanyosubcd = subcd).ToList()
        End Function
        ''' <summary>
        ''' 汎用データ一覧(使用停止を除く)
        ''' </summary>
        'public static List<tm_afhanyoDto> GetHanyoNoDelDtl(DaDbContext db, string maincd, int subcd)
        '{
        '    return GetHanyoDtl(db, maincd, subcd).Where(e => !e.stopflg).ToList();
        '}
        '''' <summary>
        '''' 汎用データ一覧(使用停止を除く)
        '''' </summary>
        'public static List<tm_afhanyoDto> GetHanyoNoDelDtl(DaDbContext db, EnumHanyoKbn kbn)
        '{
        '    return GetHanyoDtl(db, kbn).Where(e => !e.stopflg).ToList();
        '}
        ''' <summary>
        ''' 汎用データ一覧(使用停止を除く)
        ''' </summary>
        'public static List<tm_afhanyoDto> GetHanyoNoDelDtl(DaDbContext db, string keycd)
        '{
        '    return GetHanyoDtl(db, keycd).Where(e => !e.stopflg).ToList();
        '}
        ''' <summary>
        ''' ドロップダウンリスト取得
        ''' </summary>
        'public static List<DaSelectorModel> GetSelectorList(DaDbContext db, EnumHanyoKbn kbn1, Enum名称区分 kbn2, bool hasStopFlg)
        '{
        '    return GetSelectorList(hasStopFlg  GetHanyoDtl(db, kbn1) : GetHanyoNoDelDtl(db, kbn1), kbn2);
        '}
        ''' <summary>
        ''' ドロップダウンリスト取得
        ''' </summary>
        'public static List<DaSelectorModel> GetSelectorList(DaDbContext db, string keycd, Enum名称区分 kbn, bool hasStopFlg)
        '{
        '    return GetSelectorList(hasStopFlg  GetHanyoDtl(db, keycd) : GetHanyoNoDelDtl(db, keycd), kbn);
        '}
        '''' <summary>
        '''' ドロップダウンリスト取得
        '''' </summary>
        'public static List<DaSelectorModel> GetSelectorList(DaDbContext db, string hanyomaincd, int hanyosubcd, Enum名称区分 kbn, bool hasStopFlg = false)
        '{
        '    return GetSelectorList(hasStopFlg  GetHanyoDtl(db, hanyomaincd, hanyosubcd) : GetHanyoNoDelDtl(db, hanyomaincd, hanyosubcd), kbn);
        '}

        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetName(db As DaDbContext, kbn1 As EnumHanyoKbn, kbn2 As Enum名称区分, cd As String) As String
            'var CdNm = GetCdNm(db, kbn1, kbn2, cd);
            'if (!string.IsNullOrEmpty(CdNm))
            '{
            '    return CdNm.Split(DaConst.SELECTOR_DELIMITER)[1].ToString();
            '}
            Return String.Empty
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetName(dtl As List(Of tm_afhanyoDto), kbn As Enum名称区分, cd As String) As String
            Dim CdNm = GetCdNm(dtl, kbn, cd)
            If Not String.IsNullOrEmpty(CdNm) Then
                Return CdNm.Split(DaConst.SELECTOR_DELIMITER)(1).ToString()
            End If
            Return String.Empty
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetName(dtl As List(Of tm_afhanyoDto), kbn1 As EnumHanyoKbn, kbn2 As Enum名称区分, cd As String) As String
            Dim maincd = (CLng(kbn1) / 100000000L).ToString()
            Dim subcd = CInt(kbn1 Mod 100000000L)
            Return GetName(dtl, maincd, subcd, kbn2, cd)
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetName(dtl As List(Of tm_afhanyoDto), maincd As String, subcd As Integer, kbn As Enum名称区分, cd As String) As String
            Dim dtl2 = dtl.Where(Function(e) Equals(e.hanyomaincd, maincd) AndAlso e.hanyosubcd = subcd).ToList()
            Return GetName(dtl2, kbn, cd)
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        'public static string GetCdNm(DaDbContext db, EnumHanyoKbn kbn1, Enum名称区分 kbn2, string cd)
        '{
        '    var maincd = ((long)kbn1 / 100000000L).ToString();
        '    var subcd = (int)((long)kbn1 % 100000000L);
        '    return GetCdNm(db, maincd, subcd, kbn2, cd);
        '}
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        'public static string GetCdNm(DaDbContext db, string keycd, Enum名称区分 kbn, string cd)
        '{
        '    var keys = keycd.Split(DaStrPool.C_DASHED);
        '    return GetCdNm(db, keys[0], CInt(keys[1]), kbn, cd);
        '}
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        'public static string GetCdNm(DaDbContext db, string maincd, int subcd, Enum名称区分 kbn, string cd)
        '{
        '    //var dtl = GetHanyoDtl(db, maincd, subcd);
        '    return GetCdNm(dtl, kbn, cd);
        '}
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetCdNm(dtl As List(Of tm_afhanyoDto), kbn1 As EnumHanyoKbn, kbn2 As Enum名称区分, cd As String) As String
            Dim maincd = (CLng(kbn1) / 100000000L).ToString()
            Dim subcd = CInt(kbn1 Mod 100000000L)
            Return GetCdNm(dtl, maincd, subcd, kbn2, cd)
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetCdNm(dtl As List(Of tm_afhanyoDto), keycd As String, kbn As Enum名称区分, cd As String) As String
            Dim keys = keycd.Split(C_DASHED)
            Return DaHanyoService.GetCdNm(dtl, keys(0), DaConvertUtil.CInt(keys(1)), kbn, cd)
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetCdNm(dtl As List(Of tm_afhanyoDto), maincd As String, subcd As Integer, kbn As Enum名称区分, cd As String) As String
            Dim lst = dtl.Where(Function(x) Equals(x.hanyomaincd, maincd) AndAlso x.hanyosubcd = subcd).ToList()
            Return GetCdNm(lst, kbn, cd)
        End Function
        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetCdNm(dtl As List(Of tm_afhanyoDto), kbn As Enum名称区分, cd As String) As String
            If String.IsNullOrEmpty(cd) Then Return String.Empty
            Dim dto = dtl.Find(Function(x) Equals(x.hanyocd, cd))
            If dto Is Nothing Then Throw New Exception("汎用データ error")
            Select Case kbn
                Case Enum名称区分.名称
                    Return $"{cd}{DaConst.SELECTOR_DELIMITER}{dto.nm}"
                Case Enum名称区分.カナ
                    Return $"{cd}{DaConst.SELECTOR_DELIMITER}{dto.kananm}"
                Case Enum名称区分.略称
                    Return $"{cd}{DaConst.SELECTOR_DELIMITER}{dto.shortnm}"
                Case Else
                    Throw New Exception("Enum名称区分 error")
            End Select
        End Function
        ''' <summary>
        ''' 名称区分選択
        ''' </summary>
        Public Function GetSelectorList(dtl As List(Of tm_afhanyoDto), kbn As Enum名称区分) As List(Of DaSelectorModel)
            Select Case kbn
                Case Enum名称区分.名称
                    Return dtl.[Select](Function(d) New DaSelectorModel(d.hanyocd, d.nm)).ToList()
                Case Enum名称区分.カナ
                    Return dtl.[Select](Function(d) New DaSelectorModel(d.hanyocd, d.kananm)).ToList()
                Case Enum名称区分.略称
                    Return dtl.[Select](Function(d) New DaSelectorModel(d.hanyocd, d.shortnm)).ToList()
                Case Else
                    Throw New Exception("Enum名称区分 error")
            End Select
        End Function
    End Module
End Namespace
