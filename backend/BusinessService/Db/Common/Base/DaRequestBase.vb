' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ベースロジック
'             リクエストインターフェースベース
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports Newtonsoft.Json
Imports System.Reflection
Imports System.Text.Json.Serialization

Namespace Jbd.Gjs.Db
    Public Class DaRequestBase
        Public Service As String                      '機能ID
        Public ServiceDesc As String                  'サービス日本語名
        Public Method As String                       '処理名
        Public MethodDesc As String                   '処理日本語名
        Public sessionid As Long                      'セッションID
        <JsonIgnore>
        Public ip As String                           'IP
        <JsonIgnore>
        Public os As String                           'OS
        <JsonIgnore>
        Public browser As String                      'ブラウザー
        Public Property USER_ID As String              'ユーザーID
        <JsonIgnore>
        Public token As String                        'トークン
        <JsonIgnore>
        Public kinoid As String                       '機能ID(画面)
        Public Sub SetMethodInfo(method As MethodBase)
            Service = DaUtil.GetKinoid(method) 
            ServiceDesc = DaUtil.GetServiceDesc(method)
            MethodDesc = DaUtil.GetMethodDesc(method)
        End Sub
    End Class
End Namespace
