' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通仕様処理
'             ViewModel定義
' 作成日　　: 2023.07.18
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports Newtonsoft.Json

Namespace Jbd.Gjs.Service.Common
    ''' <summary>
    ''' 権限モデル
    ''' </summary>
    Public Class CmAuthVM
        Public Property personalflg As Boolean           '個人番号操作権限フラグ
        Public Property alertviewflg As Boolean          '警告参照フラグ
        Public Property editSisyos As List(Of String)    '更新可能支所一覧
    End Class

    ''' <summary>
    ''' 支所モデル
    ''' </summary>
    Public Class CmSisyoVM
        Public Property sisyocd As String '支所コード
        Public Property sisyonm As String '支所名
    End Class

    ''' <summary>
    ''' ヘッダー基本情報
    ''' </summary>
    Public Class CmHeaderBaseVM
        Public Property name As String            '氏名
        Public Property kname As String           'カナ氏名
        Public Property sex As String             '性別
        Public Property juminkbn As String        '住民区分
        Public Property bymd As String            '生年月日
    End Class

    ''' <summary>
    ''' 共通バー共通基本情報
    ''' </summary>
    Public Class CommonBarHeaderBaseVM
        Inherits CmHeaderBaseVM
        Public Property age As String             '年齢
        Public Property agekijunymd As String     '年齡計算基準日
    End Class

    ''' <summary>
    ''' 共通バー共通基本情報
    ''' </summary>
    Public Class CommonBarHeaderBase2VM
        Inherits CommonBarHeaderBaseVM
        Public Property keikoku As String '警告内容
    End Class

    ''' <summary>
    ''' 共通バー共通基本情報
    ''' </summary>
    Public Class CommonBarHeaderBase3VM
        Inherits CommonBarHeaderBase2VM
        Public Property adrs As String    '住所
    End Class

    ''' <summary>
    ''' 画面共通基本情報
    ''' </summary>
    Public Class GamenHeaderBaseVM
        Inherits CommonBarHeaderBaseVM
        <JsonIgnore>
        Public Property personalno As String  '個人番号
    End Class

    ''' <summary>
    ''' 画面共通基本情報
    ''' </summary>
    Public Class GamenHeaderBase2VM
        Inherits GamenHeaderBaseVM
        Public Property adrs As String    '住所
        Public Property keikoku As String '警告内容
    End Class

    ''' <summary>
    ''' 基準値範囲
    ''' </summary>
    Public Class KjItemVM
        Public Property itemcd As String           '項目コード
        Public Property kijunvaluehyoki As String  '基準値表記
        Public Property alertvaluehyoki As String  '注意値表記
        Public Property errvaluehyoki As String    '異常値表記
        Public Property kijunlist As List(Of KijunVM) '基準値リスト
    End Class

    ''' <summary>
    ''' 基準値(チェック用)
    ''' </summary>
    Public Class KijunVM
        Public Property errvalue1t As Double      '異常値（数値）以下
        Public Property alertvalue1f As Double    '注意値（数値）開始
        Public Property alertvalue1t As Double    '注意値（数値）終了
        Public Property kijunvaluef As Double     '基準値（数値）開始
        Public Property kijunvaluet As Double     '基準値（数値）終了
        Public Property alertvalue2f As Double    '注意値（数値）開始
        Public Property alertvalue2t As Double    '注意値（数値）終了
        Public Property errvalue2f As Double      '異常値（数値）以上
        Public Property hanteicd As String         '基準値（コード）
        Public Property alerthanteicd As String    '注意値（コード）
        Public Property errhanteicd As String      '異常値（コード）
    End Class
    ''' <summary>
    ''' フリー項目モデル(初期化)：フリー
    ''' </summary>
    Public Class FreeItemBaseVM
        Inherits FixFreeItemBaseVM
        Public Property groupid2 As String          'グループID2
    End Class
    ''' <summary>
    ''' フリー項目モデル(初期化)：固定
    ''' </summary>
    Public Class FixFreeItemBaseVM
        Inherits FreeItemUpdBaseVM
        Public Property itemnm As String                      '項目名
        Public Property inputkbn As Enum画面項目入力          '画面項目入力区分
        Public Property cdlist As List(Of Db.DaSelectorModel)       '一覧選択リスト
        Public Property keta1 As Integer                         '入力桁(整数部/文字)
        Public Property keta2 As Integer                         '入力桁(小数部)
        Public Property hissuflg As Boolean                      '必須フラグ
        Public Property hanif As String                       '入力範囲（開始）
        Public Property hanit As String                       '入力範囲（終了）
        Public Property inputflg As Boolean                      '入力フラグ
        Public Property msgkbn As Db.EnumMsgCtrlKbn              'メッセージ区分
        Public Property syokiti As String                     '初期値
        Public Property biko As String                        '備考
    End Class
    ''' <summary>
    ''' フリー項目モデル(更新)
    ''' </summary>
    Public Class FreeItemUpdBaseVM
        Public Property itemcd As String                  '項目コード
        Public Property value As Object                  '値
        Public Property fusyoflg As Boolean                 '不詳フラグ
        Public Property inputtypekbn As Db.Enum入力タイプ    '入力タイプ区分
    End Class
    ''' <summary>
    ''' 一覧列情報
    ''' </summary>
    Public Class ColumnInfoVM
        Public Property title As String   '項目論理名
        Public Property key As String     '項目物理名
    End Class
    ''' <summary>
    ''' 一覧データ
    ''' </summary>
    Public Class DataInfoVM
        Public Property key As String     '項目物理名
        Public Property value As String   '値
    End Class
End Namespace
