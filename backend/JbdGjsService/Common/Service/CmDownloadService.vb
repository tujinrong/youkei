' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ダウンロード
' 　　　　　　サービス処理
' 作成日　　: 2024.07.14
' 作成者　　: 蔣
' 変更履歴　:
' *******************************************************************
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip

Namespace JBD.GJS.Service
    Public Module CmDownloadService
        ''' <summary>
        ''' 単一ファイルのダウンロード応答を取得
        ''' </summary>
        Public Function GetDownloadResponse(files As List(Of Db.DaFileModel), Optional zipFileName As String = Nothing) As CmDownloadResponseBase
            Dim res = New CmDownloadResponseBase()
            ' ファイルがない場合
            If files Is Nothing OrElse Not files.Any() Then
                Throw New FileNotFoundException()
            End If

            Dim singleFile As Db.DaFileModel
            ' 単一ファイルの場合
            If files.Count = 1 Then
                singleFile = files(0)
            Else
                ' 同じ名前のファイルの名前を変更
                RenameSameNameFiles(files)

                ' 複数のファイルを圧縮
                singleFile = ZipFiles(files, zipFileName)
            End If
            res.filenm = $"{singleFile.filenm}{singleFile.filetype}"      'ファイル名
            res.data = singleFile.filedata                                'ファイルデータ
            'res.contenttype = GetMapping(singleFile.filetype)  'コンテンツタイプ

            Return res
        End Function

        ''' <summary>
        ''' 単一ファイルのダウンロード応答を取得
        ''' </summary>
        Public Function GetDownloadResponse(file As Db.DaFileModel) As CmDownloadResponseBase
            Dim res = New CmDownloadResponseBase()
            ' ファイルがない場合
            If file Is Nothing Then
                Throw New FileNotFoundException()
            End If
            res.filenm = $"{file.filenm}{file.filetype}"              'ファイル名
            res.data = file.filedata                                  'ファイルデータ
            'res.contenttype = GetMapping(file.filetype)    'コンテンツタイプ
            Return res
        End Function

        ''' <summary>
        ''' 
        ''' 
        ''' 同じ名前のファイルの名前を変更
        ''' </summary>
        Private Sub RenameSameNameFiles(files As IEnumerable(Of Db.DaFileModel))
            Dim group = files.GroupBy(Function(f) $"{f.filenm}{f.filetype}").ToDictionary(Function(f) f.Key, Function(f) f.ToList())
            For Each g In group
                If g.Value.Count > 1 Then
                    For i = 1 To g.Value.Count - 1
                        Dim file = g.Value(i)
                        file.filenm = $"{file.filenm}({i})"
                    Next
                End If
            Next
        End Sub

        ''' <summary>
        ''' 複数のファイルを1つのzipファイルに圧縮
        ''' </summary>
        Private Function ZipFiles(files As IEnumerable(Of Db.DaFileModel), zipFileName As String) As Db.DaFileModel
            Dim memoryStream = New MemoryStream()
            Dim zos = New ZipOutputStream(memoryStream)
            zos.SetLevel(9)
            zipFileName = If(String.IsNullOrEmpty(zipFileName), Db.DaConst.DEFAULT_ZIP_FILE_NAME, zipFileName)
            Dim now = Db.DaUtil.Now
            For Each file In files
                Dim entry = New ZipEntry($"{zipFileName}{Db.C_SLASH}{file.filenm}{file.filetype}") With {
                .DateTime = now
}
                zos.PutNextEntry(entry)
                zos.Write(file.filedata)
                zos.Flush()
            Next
            zos.Finish()
            Return New Db.DaFileModel(zipFileName, Db.FILE_ZIP_SUFFIX, memoryStream.ToArray())
        End Function
    End Module
End Namespace
