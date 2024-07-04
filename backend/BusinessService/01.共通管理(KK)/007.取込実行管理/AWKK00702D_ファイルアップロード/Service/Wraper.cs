// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.ファイルアップロード
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.CheckImporter.Define.File;

namespace BCC.Affect.Service.AWKK00702D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// ファイルIF項目を取得する
        /// </summary>
        public static List<AiFileColumnDef> GetFileifDataList(List<tm_kktori_interfaceDto> kkimpfileifDtl)
        {
            var dataList = new List<AiFileColumnDef>();
            foreach (tm_kktori_interfaceDto dto in kkimpfileifDtl)
            {
                var aIFileColmunDef = new AiFileColumnDef();
                aIFileColmunDef.ColumnName = dto.fileitemseq.ToString();    //ファイル項目ID
                aIFileColmunDef.itemnm = dto.itemnm;                        //ファイル項目名
                aIFileColmunDef.datatype = dto.datatype.ToString();         //データ型
                aIFileColmunDef.len = dto.ketasu;                           //桁数
                aIFileColmunDef.len2 = dto.syosuketasu;                     //桁数（小数部）
                aIFileColmunDef.format = dto.format;                        //フォーマット
                aIFileColmunDef.fmtcheck = dto.formatcheck;                 //フォーマットチェック
                aIFileColmunDef.fmtchange = dto.formathenkan;               //フォーマット変換
                dataList.Add(aIFileColmunDef);
            }
            return dataList;
        }

        /// <summary>
        /// マッピング項目を取得する
        /// </summary>
        public static List<AITransferDef> GetMappingDataList(List<tm_kktori_mappingDto> kkimpitemmappingDtl, List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl)
        {
            var dataList = new List<AITransferDef>();
            foreach (tm_kktori_mappingDto dto in kkimpitemmappingDtl)
            {
                var aITransferDef = new AITransferDef();
                aITransferDef.pageitemseq = dto.gamenitemseq;                       //画面項目ID
                var itemDto = kkimppageitemDtl.Find(x => x.gamenitemseq == dto.gamenitemseq);
                if(itemDto != null)
                {
                    aITransferDef.itemnm = itemDto.itemnm;                          //画面項目名
                }
                aITransferDef.fileitemseq = dto.fileitemseq;                        //ファイル項目(ファイル項目ID,カンマ区切り)
                aITransferDef.mappingkbn = dto.mappingkbn;                          //マッピング区分
                aITransferDef.mappingmethod = dto.mappinghoho;                      //マッピング方法
                aITransferDef.substrfrom = DaConvertUtil.CInt(dto.siteiketasufrom); //指定桁数（開始）
                aITransferDef.substrto = DaConvertUtil.CInt(dto.siteiketasuto);     //指定桁数（終了）
                dataList.Add(aITransferDef);
            }
            return dataList;
        }
    }
}
