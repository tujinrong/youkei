' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ファイルモデル
'
' 作成日　　: 2024.07.14
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json

Namespace JBD.GJS.Db
    Public Class DaFileModel
        Public Property filenm As String = String.Empty             'ファイル名
        Public Property filetype As String = String.Empty           'ファイルタイプ
        Public Property filesize As Integer = 0                         'ファイルサイズ
        <JsonIgnore>
        Public Property filedata As Byte() = Array.Empty(Of Byte)()    'ファイルデータ
        Public Sub New(filenm As String, filetype As String, filedata As Byte())
            Me.filenm = filenm
            Me.filetype = filetype
            Me.filedata = filedata
            filesize = filedata.Length
        End Sub
    End Class
End Namespace
