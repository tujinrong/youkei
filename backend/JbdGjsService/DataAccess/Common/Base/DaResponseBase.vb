' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ベースロジック
'             レスポンスインターフェースベース
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaResponseBase

        ''' <summary>
        ''' レスポンス状態区別
        ''' </summary>
        Public Property RETURN_CODE As EnumServiceResult = EnumServiceResult.OK

        ''' <summary>
        ''' メッセージ
        ''' </summary>
        Public Property MESSAGE As String = String.Empty

        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        Public Sub SetServiceError(msg As String)
            message = msg
            RETURN_CODE = EnumServiceResult.ServiceError
        End Sub

        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        Public Sub SetServiceError(msgID As EnumMessage, ParamArray param As String())
            message = DaMessageService.GetMsg(msgID, param)
            RETURN_CODE = EnumServiceResult.ServiceError
        End Sub

        ''' <summary>
        ''' アラートメッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert(msg As String)
            message = msg
            RETURN_CODE = EnumServiceResult.ServiceAlert
        End Sub

        ''' <summary>
        ''' アラートメッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert(msgID As EnumMessage, ParamArray param As String())
            message = DaMessageService.GetMsg(msgID, param)
            RETURN_CODE = EnumServiceResult.ServiceAlert
        End Sub

        ''' <summary>
        ''' アラート2メッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert2(msg As String)
            message = msg
            RETURN_CODE = EnumServiceResult.ServiceAlert2
        End Sub

        ''' <summary>
        ''' アラート2メッセージ設定
        ''' </summary>
        Public Sub SetServiceAlert2(msgID As EnumMessage, ParamArray param As String())
            message = DaMessageService.GetMsg(msgID, param)
            RETURN_CODE = EnumServiceResult.ServiceAlert2
        End Sub

        ''' <summary>
        ''' メッセージ非表示設定
        ''' </summary>
        Public Sub SetServiceHidden()
            RETURN_CODE = EnumServiceResult.Hidden
        End Sub

        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        Public Sub SetGjsServiceError(msgID As String, msg As String)
            message = msg & "(" & msgID & ")"
            RETURN_CODE = EnumServiceResult.ServiceError
        End Sub

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            If String.IsNullOrEmpty(msg) = False Then
                MESSAGE = msg
                RETURN_CODE = EnumServiceResult.ServiceError
            End If
        End Sub
    End Class
End Namespace
