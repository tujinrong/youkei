' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 日本養鶏協会マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8030

    ''' <summary>
    ''' 初期化処理_詳細画面処理
    ''' </summary>
    Public Class InitFuriDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 振込　金融機関
        ''' </summary>
        Public Property FURI_BANK_CD As String = String.Empty

    End Class

    ''' <summary>
    ''' 初期化処理_詳細画面処理
    ''' </summary>
    Public Class InitKofuDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 支払　金融機関
        ''' </summary>
        Public Property KOFU_BANK_CD As String = String.Empty

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 契約者農場情報
        ''' </summary>
        Public Property KYOKAI As DetailVM = New DetailVM

    End Class
End Namespace
