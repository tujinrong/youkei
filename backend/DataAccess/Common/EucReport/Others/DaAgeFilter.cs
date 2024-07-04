namespace BCC.Affect.DataAccess
{
    public class DaAgeFilter
    {
        public DateTime kijunymd { get; set; }   //基準日

        public int[]? Female { get; set; }      //女性年齢

        public int[]? Male { get; set; }     //男性年齢

        public int[]? Both { get; set; }        //両方年齢

        public int[]? Other { get; set; }    //不明その他

        public override string ToString()
        {
            if (Female == null && Male == null && Both == null && Other == null) return string.Empty;

            var list = new List<string>();
            var sex = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.sex)}";
            //女性
            if (Female != null)
            {
                var s = $"{sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._2}'";
                list.Add(GetSQL(s, Female, kijunymd));
            }

            //男性
            if (Male != null)
            {
                var s = $"{sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._1}'";
                list.Add(GetSQL(s, Male, kijunymd));
            }

            //両方
            if (Both != null)
            {
                var s = $"({sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._1}' OR {sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._2}')";
                list.Add(GetSQL(s, Both, kijunymd));
            }

            //不明
            if (Other != null)
            {
                var s = $"({sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._0}' OR {sex} = '{DaCodeConst.名称マスタ.システム.性別_システム共有._9}')";
                list.Add(GetSQL(s, Other, kijunymd));
            }

            return $"({string.Join(" OR ", list)})";
        }

        private string GetSQL(string condition, int[] ages, DateTime kijunymd)
        {
            var bymd = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.bymd)}";

            return $"({condition} AND fn_eugetage({bymd},'{kijunymd.ToString("yyyy-MM-dd")}') IN ({string.Join(",", ages)}))";
        }

    }
}
