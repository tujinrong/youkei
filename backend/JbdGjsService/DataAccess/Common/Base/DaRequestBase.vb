' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ベースロジック
'             リクエストインターフェースベース
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service

    ''' <summary>
    ''' リクエストベース
    ''' </summary>
    Public Class DaRequestBase

        ''' <summary>
        ''' 機能ID
        ''' </summary>
        Public Property Service As String = String.Empty

        ''' <summary>
        ''' サービス日本語名
        ''' </summary>
        Public Property ServiceDesc As String = String.Empty                  

        ''' <summary>
        ''' 処理名
        ''' </summary>
        Public Property Method As String = String.Empty                      

        ''' <summary>
        ''' 処理日本語名
        ''' </summary>
        Public Property MethodDesc As String = String.Empty                   

        ''' <summary>
        ''' 編集区分
        ''' </summary>
        Public Property EDIT_KBN As EnumEditKbn? = EnumEditKbn.Add            

        ''' <summary>
        ''' セッションID
        ''' </summary>
        Public Property sessionid As Long?                 

        ''' <summary>
        ''' IP
        ''' </summary>
        <JsonIgnore>
        Public Property ip As String = String.Empty                           

        ''' <summary>
        ''' OS
        ''' </summary>
        <JsonIgnore>
        Public Property os As String = String.Empty                           

        ''' <summary>
        ''' ブラウザー
        ''' </summary>
        <JsonIgnore>
        Public Property browser As String = String.Empty                      

        ''' <summary>
        ''' ユーザーID
        ''' </summary>
        Public Property USER_ID As String = String.Empty                   

        ''' <summary>
        ''' トークン
        ''' </summary>
        Public Property token As String = String.Empty                    

        ''' <summary>
        ''' 機能ID(画面)
        ''' </summary>
        <JsonIgnore>
        Public Property kinoid As String = String.Empty                       

        Public Sub SetMethodInfo(method As MethodBase)
            Service = DaUtil.GetKinoid(method) 
            ServiceDesc = DaUtil.GetServiceDesc(method)
            MethodDesc = DaUtil.GetMethodDesc(method)
        End Sub
    End Class
End Namespace
