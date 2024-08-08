' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通仕様処理
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2023.07.04
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.Common
    Public Class Wraper
        Inherits CmWraperBase


        ''' <summary>
        ''' 支所取得
        ''' </summary>
        Public Shared Function GetSisyoVM(dto As Db.tm_afhanyoDto) As CmSisyoVM
            Dim vm = New CmSisyoVM()
            vm.sisyocd = dto.hanyocd   
            vm.sisyonm = dto.nm        
            Return vm
        End Function


        ''' <summary>
        ''' 個人基本情報(ヘッダー部：画面)
        ''' </summary>
        Public Shared Function GetHeaderVM(db As Db.DaDbContext, vm As GamenHeaderBaseVM, dto As Db.tt_afatenaDto, personalflg As Boolean, publickey As String) As GamenHeaderBaseVM
            ' vm = (GamenHeaderBaseVM)GetHeaderVM(db, vm, dto);

            vm.personalno = If(personalflg AndAlso Not String.IsNullOrEmpty(dto.personalno), Gjs.Db.JbdGjsEncryptUtil.AesDecryptAndRsaEncrypt(dto.personalno, publickey), String.Empty)        '個人番号(暗号化)

            Return vm
        End Function


        ''' <summary>
        ''' 個人基本情報(ヘッダー部：画面)
        ''' </summary>
        Public Shared Function GetHeaderVM(db As Db.DaDbContext, vm As GamenHeaderBase2VM, dto As Db.tt_afatenaDto, personalflg As Boolean, publickey As String, alertviewflg As Boolean, adrsflg As Boolean) As GamenHeaderBase2VM
            vm = CType(GetHeaderVM(db, vm, dto, personalflg, publickey), GamenHeaderBase2VM)

            vm.adrs = GetAdrs(dto.jutokbn, dto.adrs1, dto.adrs2, adrsflg)  '住所
            vm.keikoku = GetKeikoku(db, dto.siensotikbn, alertviewflg)     '警告内容
            Return vm
        End Function

    End Class
End Namespace
