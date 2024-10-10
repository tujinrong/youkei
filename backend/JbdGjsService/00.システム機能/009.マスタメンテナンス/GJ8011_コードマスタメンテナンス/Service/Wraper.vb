' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.09.18
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8011

    ''' <summary>
    ''' コードマスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitDetailResponse(dt As DataTable) As InitDetailResponse
            Dim item = New InitDetailResponse()
            'コード情報処理
            item.CODE = New DetailVM
            item.CODE.SYURUI_KBN = DaConvertUtil.Cint(dt.Rows(0)("SYURUI_KBN"))
            item.CODE.MEISYO_CD = DaConvertUtil.Cint(dt.Rows(0)("MEISYO_CD"))
            item.CODE.MEISYO = DaConvertUtil.CNStr(dt.Rows(0)("MEISYO"))
            item.CODE.RYAKUSYO = DaConvertUtil.CNStr(dt.Rows(0)("RYAKUSYO"))
            item.CODE.UP_DATE = DaConvertUtil.CNDate( dt.Rows(0)("UP_DATE"))
            Return item
        End Function

    End Class
End Namespace
