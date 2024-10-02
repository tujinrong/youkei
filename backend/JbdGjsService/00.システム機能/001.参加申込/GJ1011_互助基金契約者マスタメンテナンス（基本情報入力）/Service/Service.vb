' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（基本情報入力）
'            サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************



Namespace JBD.GJS.Service.GJ1011

    ''' <summary>
    ''' 互助基金契約者マスタメンテナンス（基本情報入力）
    ''' </summary>
    <DisplayName("互助基金契約者マスタメンテナンス（基本情報入力）")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("初期化処理_詳細画面")>
        Public Shared Function InitDetail(req As InitDetailRequest) As InitDetailResponse
            Return Nolock(req,
                Function(db)

                    '-------------------------------------------------------------
                    '1.初期化
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '2.データ取得
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '3.チェック処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    'データ結果判定
                    If req.KI = -1 Then
                        req.KI = CInt(New Obj_TM_SYORI_NENDO_KI().pKI)
                    End If

                    'データクエリ

                    Dim dt1 = f_CodeMaster_Data_Select(5, 0)
                    Dim dt2 = f_CodeMaster_Data_Select(1, 0)
                    Dim dt3 = f_CodeMaster_Data_Select(2, 1)
                    Dim sql1 = f_Bank_Data_Select()
                    'データSelect 
                    Dim ds5 = FrmService.f_Select_ODP(db, sql1)
                    Dim dt5 = ds5.Tables(0)
                    Dim dt6 As DataTable = Nothing
                    Dim dt7 = f_CodeMaster_Data_Select(4, 0)

                    If Not String.IsNullOrEmpty(req.FURI_BANK_CD) Then
                        Dim sql2 = f_BankShop_Data_Select(req.FURI_BANK_CD)
                        Dim ds6 = FrmService.f_Select_ODP(db, sql2)
                        dt6 = ds6.Tables(0)
                    End If

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.InitDetailResponse(req, dt1, dt2, dt3, dt5, dt6, dt7)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("検索処理_詳細画面")>
        Public Shared Function SearchDetail(req As SearchDetailRequest) As SearchDetailResponse
            Return Nolock(req,
                Function(db)

                    '-------------------------------------------------------------
                    '1.初期化
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '2.データ取得
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '3.チェック処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    Dim ds = New DataSet()
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            '検索結果出力用ＳＱＬ作成
                            Dim sql = FrmGJ1011Service.f_SetForm_Data(req.KI, req.KEIYAKUSYA_CD)

                            'データSelect 
                            Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                            'データ結果判定
                            If dt.Rows.Count = 0 Then
                                Return New SearchDetailResponse("該当データが存在しませんでした。")
                            End If
                            Dim cdt As DataTable = dt.Copy()
                            ds.Tables.Add(cdt)
                    End Select

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.SearchDetailResponse(ds, req.EDIT_KBN)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("保存処理_詳細画面処理")>
        Public Shared Function Save(req As SaveRequest) As DaResponseBase
            Return Transction(req,
                Function(db)

                    '-------------------------------------------------------------
                    '1.初期化
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '2.データ取得
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '3.チェック処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    '検索結果出力用ＳＱＬ作成
                    Dim sql = FrmGJ1011Service.f_SetForm_Data(req.KEIYAKUSYA.KI, req.KEIYAKUSYA.KEIYAKUSYA_CD)

                    'データSelect 
                    Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                    'データの独占性
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            If dt.Rows.Count = 0 Then
                                Return New DaResponseBase("データが存在しないため、データを変更できません。")
                            Else
                                If CDate(dt.Rows(0)("UP_DATE")) > req.KEIYAKUSYA.UP_DATE Then
                                    Return New DaResponseBase("データを更新できません。他のユーザーによって変更された可能性があります。")
                                End If
                            End If
                        Case EnumEditKbn.Add       '新規入力
                            If dt.Rows.Count > 0 Then
                                Return New DaResponseBase("データは既に登録されています。")
                            End If
                    End Select

                    '保存処理
                    Dim res = FrmGJ1011Service.f_Data_Update(db, req)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("削除処理_詳細画面処理")>
        Public Shared Function Delete(req As DeleteRequest) As DaResponseBase
            Return Transction(req,
                Function(db)

                    '-------------------------------------------------------------
                    '1.初期化
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '2.データ取得
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '3.チェック処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    '削除結果出力用ＳＱＬ作成
                    Dim res = FrmGJ1011Service.f_Data_Deleate(db, req)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

    End Class
End Namespace
