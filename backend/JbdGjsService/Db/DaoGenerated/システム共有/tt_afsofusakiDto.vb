' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             送付先管理テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afsofusakiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afsofusaki"
        Public Property atenano As String                       '宛名番号
        Public Property riyomokuteki As String                  '利用目的
        Public Property adrs_sikucd As String                   '住所_市区町村コード
        Public Property adrs_tyoazacd As String                 '住所_町字コード
        Public Property adrs_todofuken As String                '住所_都道府県
        Public Property adrs_sikunm As String                   '住所_市区郡町村名
        Public Property adrs_tyoaza As String                  '住所_町字
        Public Property adrs_bantihyoki As String              '住所_番地号表記
        Public Property adrs_katagaki As String                '住所_方書
        Public Property adrs_yubin As String                   '住所_郵便番号
        Public Property sofusaki_simei As String                '送付先氏名
        Public Property torokujiyu As String                   '登録事由
        Public Property regsisyo As String                     '登録支所
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
