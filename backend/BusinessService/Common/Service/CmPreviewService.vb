' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: プレビュー
' 　　　　　　サービス処理
' 作成日　　: 2024.07.09
' 作成者　　: 蔣
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Service
    Public Module CmPreviewService
        ''' <summary>
        ''' 単一ファイルプレビュー応答
        ''' </summary>
        Public Function GetPreviewResponseBase(file As Db.DaFileModel) As CmPreviewResponseBase
            Dim res = New CmPreviewResponseBase()
            ' ファイルがない場合
            If file Is Nothing Then
                'Throw New FileNotFoundException()
            End If
            res.filenm = $"{file.filenm}{file.filetype}"              'ファイル名
            res.data = file.filedata                                  'ファイルデータ
            'res.contenttype = GetMapping(file.filetype)    'コンテンツタイプ

            Return res
        End Function
    End Module
End Namespace
