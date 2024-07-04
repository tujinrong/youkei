namespace BCC.Affect.Service.AWBH00402D
{
    [TestClass]
    public class AWBH00402D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //⑤発育曲線表示処理テスト用
        public void ShowCurveTest()
        {
            var req = new ShowCurveRequest
            {
                userid = "1",                                       //ユーザーID
                regsisyo = "1",
                //token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
                //token = "yyZhazJhfqDgVlho5f1Iog==",               //alertviewflg=true 4083
                token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

                atenano = "800000000000009",                        //宛名番号
            };

            var res = _service.ShowCurve(req);

            var str = res.ToString();
        }
    }
}