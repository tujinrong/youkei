' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             市区町村マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afsikutyosonDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afsikutyoson"
        Public Property sikucd As String                        '市区町村コード
        Public Property todofukennm As String                   '都道府県名
        Public Property todofukennm_kana As String              '都道府県名_カナ
        Public Property todofukennm_eiji As String              '都道府県名_英字
        Public Property gunnm As String                        '郡名
        Public Property gunnm_kana As String                   '郡名_カナ
        Public Property gunnm_eiji As String                   '郡名_英字
        Public Property sikunm As String                        '市区町村名
        Public Property sikunm_kana As String                   '市区町村名_カナ
        Public Property sikunm_eiji As String                   '市区町村名_英字
        Public Property seireisikunm As String                 '政令市区名
        Public Property seireisikunm_kana As String            '政令市区名_カナ
        Public Property seireisikunm_eiji As String            '政令市区名_英字
        Public Property koryokuhasseiymd As String              '効力発生日
        Public Property haisiymd As String                      '廃止日
        Public Property biko As String                         '備考
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
