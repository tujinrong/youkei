' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 排他処理
' 　　　　　　リクエストインターフェースベース
' 作成日　　: 2024.07.03
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Service
    Public Class CmLockRequestBase
        Inherits Db.DaRequestBase
        Public Property timestamp As Date    'タイムスタンプ
    End Class
End Namespace
