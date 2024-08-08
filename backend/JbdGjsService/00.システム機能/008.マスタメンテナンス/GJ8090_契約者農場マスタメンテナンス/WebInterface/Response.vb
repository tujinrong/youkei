' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

    ''' <summary>
    ''' 初期化処理_一覧画面処理(成功)
    ''' </summary>
    Public Class InitResponse
        Inherits Db.DaResponseBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 契約者情報プルダウンリスト
        ''' </summary>
        Public Property KEIYAKUSYA_CD_NAME_LIST As List(Of CodeNameModel) = New List(Of CodeNameModel)

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New(ki As Integer)
            KI = ki
        End Sub

    End Class

    ''' <summary>
    ''' ユーザ情報処理(成功)
    ''' </summary>
    Public Class UserInfoResponse
        Inherits Db.DaResponseBase

        'Public UserInfo As UserInfoVM
        ''' <summary>
        ''' ユーザID
        ''' </summary>
        Public Property USER_ID As String = String.Empty

        ''' <summary>
        ''' ユーザー名
        ''' </summary>
        Public Property USER_NAME As String = String.Empty

        ''' <summary>
        ''' 权限
        ''' </summary>
        Public Property ROLES As List(Of String) = New List(Of String)


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
