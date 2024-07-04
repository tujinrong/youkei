namespace BCC.Affect.DataAccess
{
    public class DaBirthdayFilter
    {
        public DaBirthdayModel? Female { get; set; }     //女性

        public DaBirthdayModel? Male { get; set; }     //男性

        public DaBirthdayModel? Both { get; set; }     //両方

        public DaBirthdayModel? Other { get; set; }     //

        public override string ToString()
        {
            if (Female == null && Male == null && Both == null && Other == null) return string.Empty;

            var list = new List<string>();
            var sex = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.sex)}";
            //女性
            if (Female != null) list.Add(Female.GetSQL($"{sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._2}'"));

            //男性
            if (Male != null) list.Add(Male.GetSQL($"{sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._1}'"));

            //両方
            if (Both != null) list.Add(Both.GetSQL($"({sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._1}' OR {sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._2}')"));

            //不明
            if (Other != null) list.Add(Other.GetSQL($"({sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._0}' OR {sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._9}')"));

            return $"({string.Join(" OR ", list)})";
        }
    }

    public class DaBirthdayModel
    {
        public DateTime? DateFrom { get; set; }      //開始日

        public DateTime? DateTo { get; set; }      //終了日

        public bool UnknownY { get; set; }     //不明年

        public bool UnknownM { get; set; }      //不明月

        public bool UnknownD { get; set; }      //不明日

        public string GetSQL(string condition)
        {
            var list = new List<string>();
            var fusyoflg = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.bymd_fusyoflg)}";
            var bymd = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.bymd)}";
            if (DateFrom != null)
            {
                var d = DateFrom.Value;
                var s = $"({fusyoflg} = false AND {bymd} >= '{d.ToString("yyyy-MM-dd")}')";
                list.Add(s);
            }
            if (DateTo != null)
            {
                var d = DateTo.Value;
                var s = $"({fusyoflg} = false AND {bymd} <= '{d.ToString("yyyy-MM-dd")}')";
                list.Add(s);
            }
            if (UnknownY)
            {
                var s = $"(SUBSTRING({bymd}, 1, 4) = '0000')";
                list.Add(s);
            }
            if (UnknownM)
            {
                var s = $"(SUBSTRING({bymd}, 6, 2) IN ('00','A1','A2','A3','A4'))";
                list.Add(s);
            }
            if (UnknownD)
            {
                var s = $"(SUBSTRING({bymd}, 9, 2) IN ('00','A1','A2','A3'))";
                list.Add(s);
            }


            return $"({condition} AND ({string.Join(" OR ", list)}))";
        }
    }
}
