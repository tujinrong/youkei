' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: プレビュー処理
' 　　　　　　レスポンスインターフェースベース
' 作成日　　: 2024.07.09
' 作成者　　: 蔣
' 変更履歴　:
' *******************************************************************
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json

Namespace Jbd.Gjs.Service
    Public Class CmPreviewResponseBase
        Inherits Db.DaResponseBase
        Public Property filenm As String                                          'ファイル名
        <JsonIgnore>
        Public Property data As Byte()                                            'データ
        Public Property contenttype As String                                     'コンテンツタイプ
    End Class
End Namespace
