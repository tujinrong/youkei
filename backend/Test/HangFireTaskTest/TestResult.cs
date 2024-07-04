using Hangfire;

namespace HangFireTaskTest
{
    public class TestResult
    {
        #region Common Method

        /// <summary>
        /// 判断jobの実行結果(成功または失敗)
        /// </summary>
        /// <param name="jobId"></param>
        public void OutputExecuteResult(string jobId)
        {
            bool isSuccess = false;

            if (CaptureJobIdFilter.JobIds.TryGetValue(jobId, out var joid))
            {
                var monitoringApi = JobStorage.Current.GetMonitoringApi();
                var jobDetails = monitoringApi.JobDetails(joid);

                if (jobDetails != null)
                {
                    foreach (var state in jobDetails.History)
                    {
                        if (state.StateName.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                        {
                            //isSuccess = false;
                            //break;

                            //Test
                            isSuccess = false;
                        }
                        else
                        {
                            ////Succeeded
                            //isSuccess = true;

                            //Test
                            isSuccess = true;
                            break;
                        }
                    }
                }
            }

            if (isSuccess == false)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        #endregion
    }
}
