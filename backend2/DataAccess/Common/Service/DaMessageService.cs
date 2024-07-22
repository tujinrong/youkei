// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メッセージ処理
//
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using System.Text;
using System.Text.RegularExpressions;

namespace BCC.Affect.DataAccess
{
    public class DaMessageService
    {
        private static Dictionary<string, MessageModel> MsgDic;
        private static Dictionary<string, MessageModel> MsgNoDic;

        static DaMessageService()
        {
            MsgDic = new Dictionary<string, MessageModel>();
            ReadFile("msg.ts", MsgDic);
            MsgNoDic = MsgDic.Values.ToDictionary(e => e.MsgNo, e => e);
        }

        public static string GetMsg(EnumMessage id, params object[] param)
        {
            string m = GetMsgModel(id).Msg + "(" + GetMsgModel(id).MsgNo + ")";
            return string.Format(m, param);
        }
        public static string GetMsg(string msgNo, params object[] param)
        {
            if (MsgNoDic.ContainsKey(msgNo)==false)
            {
                return "メッセージNoが存在しません";
            }
            var msgModel = MsgNoDic[msgNo];
            string m = msgModel.Msg + "(" + msgModel.MsgNo + ")";
            return string.Format(m, param);
        }

        public static MessageModel GetMsgModel(EnumMessage id)
        {
            ReadFile();
            string key = Enum.GetName(typeof(EnumMessage), id)!;
            if (MsgDic.ContainsKey(key) == false)
            {
                throw new Exception("メッセージファイルは最新ではありません");
            }
            return MsgDic[key];
        }

        public static List<MessageViewModel> GetViewModelList()
        {
            ReadFile();
            return MsgDic.Select(e => new MessageViewModel(e.Key, e.Value.MsgNo, e.Value.Msg)).OrderBy(e => e.MessageNo).ToList();
        }

        private static void ReadFile()
        {
            if (MsgDic is null || MsgDic.Count == 0)
            {
                MsgDic = new Dictionary<string, MessageModel>();
                ReadFile("msg.ts", MsgDic);
                MsgNoDic = MsgDic.Values.ToDictionary(e=>e.MsgNo, e=>e);
            }
        }

        private static void ReadFile(string file, Dictionary<string, MessageModel> dic)
        {
            string loc = AppDomain.CurrentDomain.BaseDirectory + "bin";
            string fPath;
            if (Directory.Exists(loc))
            {
                fPath = Path.Combine(loc, "Resource", file);
            }
            else
            {
                loc = AppDomain.CurrentDomain.BaseDirectory;
                fPath = Path.Combine(loc, "Resource", file);
            }
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var enc = Encoding.GetEncoding("Shift_JIS");
            using (var sr = new StreamReader(fPath, enc))
            {
                while (sr.Peek() >= 0)
                {
                    string s = sr.ReadLine()?? string.Empty;
                    var words = GetWords(s);
                    var model = new MessageModel();
                    model.MsgNo = words[1];
                    model.Msg = words[2];
                    dic.Add(words[0], model);
                }
            }
        }

        private static string[] GetWords(string s)
        {
            var list = new List<string>();

            string ptn = @"const\s([A-Z0-9_]+)\s*\=\s*\{\s*No:\s*\'([A-Z0-9]+)\',\s*Msg:\s*\'([^']+)";
            var gs = Regex.Matches(s, ptn);
            var g = gs[0];

            list.Add(g.Groups[1].Value);
            list.Add(g.Groups[2].Value);
            list.Add(g.Groups[3].Value.Replace("\\n", Environment.NewLine));

            return list.ToArray();
        }
    }

    public class MessageModel
    {
        public string MsgNo { get; set; }
        public string Msg { get; set; }
    }

    public class MessageViewModel
    {
        public string MessageNo { get; set; }
        public string Message { get; set; }
        public string Key { get; set; }

        public MessageViewModel(string desc, string MsgNo, string Msg)
        {
            Key = desc;
            MessageNo = MsgNo;
            Message = Msg;
        }
    }
}