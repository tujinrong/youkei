' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: システム共通(業務)
'             区分列挙型
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Service
    Public Enum EnumRuntimeMode
        NORMAL
        DEBUG
        STUB
    End Enum

    Public Enum EnumDownloadType
        File
        Data
    End Enum
End Namespace
