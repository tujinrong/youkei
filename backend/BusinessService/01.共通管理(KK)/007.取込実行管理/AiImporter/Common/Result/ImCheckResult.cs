// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　結果定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImCheckResult
    {
        public bool Success = true;

        public string ErrMsg = "";

        public List<ImFileErrorRow> FileErrorList { get; set; } = new List<ImFileErrorRow>();

        public List<ImEditErrorRow> EditErrorList { get; set; } = new List<ImEditErrorRow>();

        public List<ImEditDataRow> EditDataList { get; set; } = new List<ImEditDataRow>();

        private int MaxFileError;

        private int MaxEditError;

        public ImCheckResult() { }

        public DataTable Data { get; set; } = new DataTable();

        public ImCheckResult(int maxError)
        {
            MaxFileError = maxError;
            MaxEditError = maxError;
        }

        public void AddFileError(ImFileErrorRow error)
        {
            if (FileErrorList.Count > MaxFileError)
            {
                throw new ImErrorOverExcetion();
            }
            FileErrorList.Add(error);
        }

        public void AddEditError(ImEditErrorRow error)
        {
            if (EditErrorList.Count > MaxEditError)
            {
                throw new ImErrorOverExcetion();
            }
            EditErrorList.Add(error);
        }

    }
}
