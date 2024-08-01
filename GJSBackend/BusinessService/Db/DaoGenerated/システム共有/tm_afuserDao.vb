' *******************************************************************
' 業務名称  : 互助防疫システム
' 機能概要　: テーブルDAO定義
' 　　　　　　ユーザーマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴  :
' *******************************************************************
Imports BusinessService.Jbd.Gjs.Db

Namespace Jbd.Gjs.Db
    Public Class tm_afuserDao
        Inherits DaDaoBase
        ''' <summary>
        ''' テーブル名
        ''' </summary>
        Public Const TABLE_NAME As String = "tm_afuser"

        Public Sub New()

        End Sub

        ''' <summary>
        ''' データ抽出
        ''' </summary>
        'Public ReadOnly Property [SELECT] As AIplus.AIF.DBLib.AiSelectHelper(Of tm_afuserDto)
        '    Get
        '        Dim helper = New AIplus.AIF.DBLib.AiSelectHelper(Of tm_afuserDto)(Session, TABLE_NAME)
        '        Return helper
        '    End Get
        'End Property

        '''' <summary>
        '''' データ削除
        '''' </summary>
        'Public ReadOnly Property DELETE As AIplus.AIF.DBLib.AiDeleteHelper(Of tm_afuserDto)
        '    Get
        '        Dim helper = New AIplus.AIF.DBLib.AiDeleteHelper(Of tm_afuserDto)(Session, TABLE_NAME)
        '        Return helper
        '    End Get
        'End Property

        '''' <summary>
        '''' データ登録
        '''' </summary>
        'Public ReadOnly Property INSERT As AIplus.AIF.DBLib.AiInsertHelper(Of tm_afuserDto)
        '    Get
        '        Dim helper = New AIplus.AIF.DBLib.AiInsertHelper(Of tm_afuserDto)(Session, TABLE_NAME)
        '        Return helper
        '    End Get
        'End Property

        '''' <summary>
        '''' データ更新
        '''' </summary>
        'Public ReadOnly Property UPDATE As AIplus.AIF.DBLib.AiUpdateHelper(Of tm_afuserDto)
        '    Get
        '        Dim helper = New AIplus.AIF.DBLib.AiUpdateHelper(Of tm_afuserDto)(Session, TABLE_NAME)
        '        Return helper
        '    End Get
        'End Property

        '''' <summary>
        '''' グルーピング
        '''' </summary>
        'Public ReadOnly Property GROUP As AIplus.AIF.DBLib.AiGroupHelper(Of tm_afuserDto)
        '    Get
        '        Dim helper = New AIplus.AIF.DBLib.AiGroupHelper(Of tm_afuserDto)(Session, TABLE_NAME)
        '        Return helper
        '    End Get
        'End Property

        ''' <summary>
        ''' 指定キーデータの抽出
        ''' </summary>
        'Public Function GetDtoByKey(userid As String) As tm_afuserDto
        '    Return [SELECT].WHERE.ByKey(userid).GetDto()
        'End Function

        '''' <summary>
        '''' キーを指定して削除
        '''' </summary>
        'Public Sub DeleteByKey(userid As String, timeStamp As Date)
        '    '物理削除
        '    DELETE.WHERE.ByKey(userid).SetLock(timeStamp).Execute()
        'End Sub

        '''' <summary>
        '''' データの更新 
        '''' </summary>
        'Public Sub UpdateDto(dto As tm_afuserDto, timestamp As Date)
        '    '排他更新
        '    UPDATE.SetLock(timestamp).Execute(dto)
        'End Sub
    End Class
End Namespace
