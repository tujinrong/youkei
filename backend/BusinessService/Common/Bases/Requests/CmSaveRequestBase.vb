' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 登録処理
' 　　　　　　リクエストインターフェースベース
' 作成日　　: 2024.04.08
' 作成者　　: 魏
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmSaveRequestBase
        Inherits Db.DaRequestBase
        Public Property checkflg As Boolean = False         'チェックフラグ
    End Class
End Namespace
