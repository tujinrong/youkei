' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ベースロジック
'             レスポンスインターフェースベース
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports System.Text.Json.Serialization

Namespace Jbd.Gjs.Db
    Public Class DaResponseBase
        <JsonPropertyName("RETURN_CODE")>
        Public Property returncode As EnumServiceResult = EnumServiceResult.OK   'レスポンス状態区別
        <JsonPropertyName("MESSAGE")>
        Public Property message As String                                         'メッセージ
        '<JsonIgnore>
        ''Public Property rsaprivatekey As String                                  '秘密キー(復号化用)
        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        Public Sub SetServiceError(msg As String)
            message = msg
            returncode = EnumServiceResult.ServiceError
        End Sub
        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        Public Sub SetServiceError(msgID As EnumMessage, ParamArray param As String())
            message = DaMessageService.GetMsg(msgID, param)
            returncode = EnumServiceResult.ServiceError
        End Sub
        ''' <summary>
        ''' アラートメッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert(msg As String)
            message = msg
            returncode = EnumServiceResult.ServiceAlert
        End Sub
        ''' <summary>
        ''' アラートメッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert(msgID As EnumMessage, ParamArray param As String())
            message = DaMessageService.GetMsg(msgID, param)
            returncode = EnumServiceResult.ServiceAlert
        End Sub

        ''' <summary>
        ''' アラート2メッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert2(msg As String)
            message = msg
            returncode = EnumServiceResult.ServiceAlert2
        End Sub
        ''' <summary>
        ''' アラート2メッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert2(msgID As EnumMessage, ParamArray param As String())
            message = DaMessageService.GetMsg(msgID, param)
            returncode = EnumServiceResult.ServiceAlert2
        End Sub
        ''' <summary>
        ''' メッセージ非表示設定
        ''' </summary>
        Public Sub SetServiceHidden()
            returncode = EnumServiceResult.Hidden
        End Sub
        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        Public Sub SetGjsServiceError(msgID As String, msg As String)
            message = msg & "(" & msgID & ")"
            returncode = EnumServiceResult.ServiceError
        End Sub
    End Class
End Namespace
