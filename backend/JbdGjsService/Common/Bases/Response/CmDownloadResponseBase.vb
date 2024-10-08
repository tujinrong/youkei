﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ダウンロード処理
' 　　　　　　レスポンスインターフェースベース
' 作成日　　: 2024.07.21
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmDownloadResponseBase
        Inherits CmPreviewResponseBase
        Public Property downloadtype As EnumDownloadType = EnumDownloadType.Data 'ファイルタイプ
        Public Property filefullnm As String                                      'ファイル名(パス含む)

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New(recode As EnumServiceResult,msg As String)
            MyBase.New(recode, msg)
        End Sub

    End Class
End Namespace
