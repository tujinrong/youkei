// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             保健指導管理ビュー
// 作成日　　: 2024.03.07
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 保健指導管理情報
    /// </summary>
    public class SidoView : IFrView
    {
        public const string TABLE_NAME = "vw_kksido";

        //設定可能な項目（ビュー全体項目のみ記載　※サブビュー個別設定可能）
        //ビュー項目
        public const string atenano = nameof(SidoView.atenano);
        public const string hokensidokbn = nameof(SidoView.hokensidokbn);
        public const string gyomukbn = nameof(SidoView.gyomukbn);
        public const string edano = nameof(SidoView.edano);

        //申込項目
        public const string hokensidokbn1 = nameof(SidoView.hokensidokbn1);
        public const string gyomukbn1 = nameof(SidoView.gyomukbn1);
        public const string atenano1 = nameof(SidoView.atenano1);
        public const string edano1 = nameof(SidoView.edano1);
        public const string jigyocd1 = nameof(SidoView.jigyocd1);
        public const string yoteiymd = nameof(SidoView.yoteiymd);
        public const string yoteitm = nameof(SidoView.yoteitm);
        public const string kaijocd1 = nameof(SidoView.kaijocd1);
        public const string regsisyo1 = nameof(SidoView.regsisyo1);
        public const string upddttm1 = nameof(SidoView.upddttm1);

        //結果項目
        public const string hokensidokbn2 = nameof(SidoView.hokensidokbn2);
        public const string gyomukbn2 = nameof(SidoView.gyomukbn2);
        public const string atenano2 = nameof(SidoView.atenano2);
        public const string edano2 = nameof(SidoView.edano2);
        public const string jigyocd2 = nameof(SidoView.jigyocd2);
        public const string jissiymd = nameof(SidoView.jissiymd);
        public const string tmf = nameof(SidoView.tmf);
        public const string tmt = nameof(SidoView.tmt);
        public const string kaijocd2 = nameof(SidoView.kaijocd2);
        public const string syukeikbn = nameof(SidoView.syukeikbn);
        public const string regsisyo2 = nameof(SidoView.regsisyo2);
        public const string upddttm2 = nameof(SidoView.upddttm2);

        //担当者項目
        public const string hokensidokbn3 = nameof(SidoView.hokensidokbn3);
        public const string gyomukbn3 = nameof(SidoView.gyomukbn3);
        public const string atenano3 = nameof(SidoView.atenano3);
        public const string edano3 = nameof(SidoView.edano3);
        public const string mosikomikekkakbn = nameof(SidoView.mosikomikekkakbn);
        public const string staffid = nameof(SidoView.staffid);

        //検索対象となるビュー名の定義
        public const string ViewName_1 = "vw_sidomosikomi";
        public const string ViewName_2 = "vw_sidokekka";
        public const string ViewName_3 = "vw_sidostaff";
        public const string ViewName = "vw_sidofull";

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public SidoView(List<FrConditionItem> conditionList)
        {
            _SQL =
                @$"
                    select distinct
                        v1.atenano
                    from (
                    select
                        {ViewName}.atenano,
                        {ViewName}.hokensidokbn,
                        {ViewName}.gyomukbn,
                        {ViewName}.edano,
                        {ViewName}.hokensidokbn1,
                        {ViewName}.gyomukbn1,
                        {ViewName}.atenano1,
                        {ViewName}.edano1,
                        {ViewName}.jigyocd1,
                        {ViewName}.yoteiymd,
                        {ViewName}.yoteitm,
                        {ViewName}.kaijocd1,
                        {ViewName}.regsisyo1,
                        {ViewName}.upddttm1,
                        {ViewName}.hokensidokbn2,
                        {ViewName}.gyomukbn2,
                        {ViewName}.atenano2,
                        {ViewName}.edano2,
                        {ViewName}.jigyocd2,
                        {ViewName}.jissiymd,
                        {ViewName}.tmf,
                        {ViewName}.tmt,
                        {ViewName}.kaijocd2,
                        {ViewName}.syukeikbn,
                        {ViewName}.regsisyo2,
                        {ViewName}.upddttm2,
                        {ViewName}.hokensidokbn3,
                        {ViewName}.gyomukbn3,
                        {ViewName}.atenano3,
                        {ViewName}.edano3,
                        {ViewName}.mosikomikekkakbn,
                        {ViewName}.staffid
                        from (
                            select
                                coalesce({ViewName_1}.atenano, {ViewName_2}.atenano) atenano,
                                coalesce({ViewName_1}.hokensidokbn, {ViewName_2}.hokensidokbn) hokensidokbn,
                                coalesce({ViewName_1}.gyomukbn, {ViewName_2}.gyomukbn) gyomukbn,
                                coalesce({ViewName_1}.edano, {ViewName_2}.edano) edano,
                                {ViewName_1}.hokensidokbn hokensidokbn1,
                                {ViewName_1}.gyomukbn gyomukbn1,
                                {ViewName_1}.atenano atenano1,
                                {ViewName_1}.edano edano1,
                                {ViewName_1}.jigyocd jigyocd1,
                                {ViewName_1}.yoteiymd yoteiymd,
                                {ViewName_1}.yoteitm yoteitm,
                                {ViewName_1}.kaijocd kaijocd1,
                                {ViewName_1}.regsisyo regsisyo1,
                                {ViewName_1}.upddttm upddttm1,
                                {ViewName_2}.hokensidokbn hokensidokbn2,
                                {ViewName_2}.gyomukbn gyomukbn2,
                                {ViewName_2}.atenano atenano2,
                                {ViewName_2}.edano edano2,
                                {ViewName_2}.jigyocd jigyocd2,
                                {ViewName_2}.jissiymd jissiymd,
                                {ViewName_2}.tmf tmf,
                                {ViewName_2}.tmt tmt,
                                {ViewName_2}.kaijocd kaijocd2,
                                {ViewName_2}.syukeikbn syukeikbn,
                                {ViewName_2}.regsisyo regsisyo2,
                                {ViewName_2}.upddttm upddttm2,
                                {ViewName_3}.hokensidokbn hokensidokbn3,
                                {ViewName_3}.gyomukbn gyomukbn3,
                                {ViewName_3}.atenano atenano3,
                                {ViewName_3}.edano edano3,
                                {ViewName_3}.mosikomikekkakbn mosikomikekkakbn,
                                {ViewName_3}.staffid staffid
                            from {tt_kkhokensido_mosikomiDto.TABLE_NAME} {ViewName_1}           
                            full join {tt_kkhokensido_kekkaDto.TABLE_NAME} {ViewName_2}
                            on {ViewName_1}.hokensidokbn = {ViewName_2}.hokensidokbn
                            and {ViewName_1}.gyomukbn = {ViewName_2}.gyomukbn
                            and {ViewName_1}.atenano = {ViewName_2}.atenano 
                            and {ViewName_1}.edano = {ViewName_2}.edano
                            left join {tt_kkhokensido_staffDto.TABLE_NAME} {ViewName_3}
                            on
                            (
                                {ViewName_3}.mosikomikekkakbn = '1'                                 --申込とスタッフの結合条件
                                and {ViewName_3}.hokensidokbn = {ViewName_1}.hokensidokbn
                                and {ViewName_3}.gyomukbn = {ViewName_1}.gyomukbn
                                and {ViewName_3}.atenano = {ViewName_1}.atenano
                                and {ViewName_3}.edano = {ViewName_1}.edano
                            )
                            or
                            (
                                {ViewName_3}.mosikomikekkakbn = '2'                                 --結果とスタッフの結合条件
                                and {ViewName_3}.hokensidokbn = {ViewName_2}.hokensidokbn 
                                and {ViewName_3}.gyomukbn = {ViewName_2}.gyomukbn
                                and {ViewName_3}.atenano = {ViewName_2}.atenano 
                                and {ViewName_3}.edano = {ViewName_2}.edano
                            )
                            where
                            (
                                1 = 1
                                and {DaFrUtil.GetSql(conditionList, ViewName_1)}                    --申込の検索条件（サブビュー個別設定）
                                and {DaFrUtil.GetSql(conditionList, ViewName_2)}                    --結果の検索条件（サブビュー個別設定）
                            )
                            and
                            (
                                1 = 1
                                and {DaFrUtil.GetSql(conditionList, ViewName_3)}                    --スタッフの検索条件（サブビュー個別設定）
                            )
                        ) {ViewName}
                        where
                            1 = 1
                            and {DaFrUtil.GetSql(conditionList, ViewName)}                          --ビューの検索条件（ビュー全体設定）
                    ) v1
                ".Trim();
        }
    }
}