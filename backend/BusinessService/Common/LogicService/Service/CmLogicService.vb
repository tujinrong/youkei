' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通仕様処理
'
' 作成日　　: 2023.07.04
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.Common
    <ComponentModel.DisplayName("共通処理")>
    Public Class Service
        Inherits CmServiceBase
        '[DisplayName("初期化処理(パスワードポリシー)")]
        'public CmPwdInitResponse CmPwdInit(DaRequestBase req)
        '{
        '    return Nolock(req, (DaDbContext db) =>
        '    {
        '        var res = new CmPwdInitResponse();
        '        //-------------------------------------------------------------
        '        //１.データ取得
        '        //-------------------------------------------------------------
        '        var ctrInfo = DaControlService.GetList(db, EnumCtrlKbn.パスワード);

        '        //-------------------------------------------------------------
        '        //２.データ加工処理
        '        //-------------------------------------------------------------
        '        //パスワードポリシー設定フラグ
        '        res.pwdflg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._03)!.BoolValue1;

        '        if (res.pwdflg)
        '        {
        '            //半角数字フラグ
        '            res.numflg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._05)!.BoolValue1;

        '            //半角英字フラグ
        '            res.enflg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._06)!.BoolValue1;

        '            //半角記号フラグ
        '            res.symbolflg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._07)!.BoolValue1;

        '            //最大文字数
        '            res.maxlen = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._04).IntValue1;

        '            if (res.symbolflg)
        '            {
        '                //使用可能記号
        '                var symbols = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._09)!.StringValue1;
        '                res.symbolstr = string.IsNullOrEmpty(symbols)  string.Empty : symbols;
        '            }
        '        }

        '        //正常返し
        '        return res;
        '    });
        '}
    End Class
End Namespace
