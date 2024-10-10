' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタメンテナンス
'            サービス処理
' 作成日　　: 2024.09.27
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8041

    ''' <summary>
    ''' 初期化処理_詳細画面
    ''' </summary>
    <DisplayName("初期化処理_詳細画面")>
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

                    '使用区分情報プルダウンリスト
                    Dim dt2 = f_CodeMaster_Data_Select(6, 0)
                    Dim sql = f_Ken_Data_Select()
                    Dim ds = FrmService.f_Select_ODP(db, sql)
                    ds.Tables(0).TableName = "t1"

                    '検索コントロールマスタデータ取得用ＳＱＬ作成
                    sql = FrmGJ8041Service.f_TM_CONTROL_Data_Select()

                    'データSelect 
                    Dim dt3 = FrmService.f_Select_ODP(db, sql).Tables(0)

                    'データ結果判定
                    If dt3.Rows.Count = 0 Then
                        Return New InitDetailResponse("コントロールマスタが設定されていません。")
                    End If
                    Dim cdt3 As DataTable = dt3.Copy()
                    ds.Tables.Add(cdt3)

                    '契約者農場情報処理
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            '検索結果出力用ＳＱＬ作成
                            sql = FrmGJ8041Service.f_SetForm_Data(req)

                            'データSelect 
                            Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                            'データ結果判定
                            If dt.Rows.Count = 0 Then
                                Return New InitDetailResponse("指定された条件に一致するデータは存在しません。")
                            End If
                            Dim cdt As DataTable = dt.Copy()
                            ds.Tables.Add(cdt)

                    End Select

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.InitDetailResponse(ds, dt2, req.EDIT_KBN)

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
                    Dim sReq As New InitDetailRequest()
                    sReq.USERID = req.USER.USERID
                    Dim sql = FrmGJ8041Service.f_SetForm_Data(sReq)

                    'データSelect 
                    Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                    'データの独占性
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            If dt.Rows.Count = 0 Then
                                Return New DaResponseBase("データが存在しないため、データを変更できません。")
                            Else
                                If CDate(dt.Rows(0)("UP_DATE")) > req.USER.UP_DATE Then
                                    Return New DaResponseBase("データを更新できません。他のユーザーによって変更された可能性があります。")
                                End If
                            End If
                        Case EnumEditKbn.Add       '新規入力
                            If dt.Rows.Count > 0 Then
                                Return New DaResponseBase("データは既に登録されています。")
                            End If
                    End Select

                    '保存処理
                    Dim res = FrmGJ8041Service.f_Data_Update(db, req)

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
                    Dim res = FrmGJ8041Service.f_Data_Deleate(db, req)

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
