' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: システム共通(業務)
'             区分列挙型
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Module CmFilterVM
        ''' <summary>
        ''' 詳細条件(初期化)
        ''' </summary>
        Public Class CommonFilterVM
            Public Property jyokbn As Enum詳細検索条件区分          '条件区分
            Public Property jyoseq As Integer                           '条件シーケンス
            Public Property hyojinm As String                       '詳細条件表示名
            Public Property placeholder As String                   '入力説明
            Public Property ctrltype As Enumコントローラータイプ    'コントローラータイプ
            Public Property itemkbn As Enum項目区分                '通用項目区分
            Public Property rangeflg As Boolean                        '範囲フラグ
            Public Property manflg As Boolean                          '男性
            Public Property womanflg As Boolean                        '女性
            Public Property bothflg As Boolean                         '両方
            Public Property unknownflg As Boolean                      '不明
            Public Property cdlist As List(Of DaSelectorModel)         '一覧選択リスト
            Public Property searchitemkbn As Enum参照ダイアログ項目区分  '参照ダイアログ項目区分
        End Class
    End Module
End Namespace
