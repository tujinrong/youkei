' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: システム共通
'             区分列挙型
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    ''' <summary>
    ''' レスポンス状態区分
    ''' </summary>
    Public Enum EnumServiceResult
        OK             '正常
        ServiceError   'エラー
        ServiceAlert   'アラート
        Hidden         '非表示
        Exception      '例外
        Forbidden      '利用不可
        AuthError      '権限認証失敗
        ServiceAlert2  'アラート2(はいだけ)
    End Enum

    Public Enum EnumLogStatus
        正常終了 = 0
        異常終了 = 1
        要確認 = 3
        処理停止 = 4
    End Enum

    ''' <summary>
    ''' 操作区分
    ''' </summary>
    Public Enum EnumAtenaActionType
        追加 = 1
        更新 = 2
        削除 = 3
        検索
    End Enum

    ''' <summary>
    ''' 連携区分
    ''' </summary>
    Public Enum EnumGaibuKbn
        FromGaibu = 1  '他システムから取得;
        ToGaibu         '他システムへ出力
    End Enum

    ''' <summary>
    ''' 連携方式		
    ''' </summary>
    Public Enum EnumGaibuDataType
        CSV = 1
        API
    End Enum

    ''' <summary>
    ''' ファイル種類
    ''' </summary>
    Public Enum EnumFileTypeKbn
        Empty = -1
        csv = 1
        doc
        jpg
        jpeg
        png
        pdf
        tif
        txt
        xml
        xls
        xlsm
        xlsx
        zip
    End Enum
End Namespace
