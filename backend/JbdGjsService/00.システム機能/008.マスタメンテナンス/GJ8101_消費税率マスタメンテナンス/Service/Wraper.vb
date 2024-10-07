' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 消費税率マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.10.07
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8101

    ''' <summary>
    ''' 消費税率マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitDetailResponse(dt As DataTable, ek As EnumEditKbn?) As InitDetailResponse
            Dim item As New InitDetailResponse()

            '消費税率情報
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        item.TAX.TAX_DATE_FROM  = DaConvertUtil.CDate(row("TAX_DATE_FROM"))
                        If Not String.IsNullOrEmpty( row("TAX_DATE_TO").ToString())
                            item.TAX.TAX_DATE_TO = DaConvertUtil.CDate(row("TAX_DATE_TO"))
                        End If
                        If Not String.IsNullOrEmpty( row("TAX_RITU").ToString())
                            item.TAX.TAX_RITU = DaConvertUtil.CInt(row("TAX_RITU"))
                        End If
                        If Not String.IsNullOrEmpty( row("UP_DATE").ToString())
                            item.TAX.UP_DATE = DaConvertUtil.CDate(row("UP_DATE"))
                        End If
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
