using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Reactive;
using vd.import.lib.constants;
using vd.import.lib.Interface;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using vd.core;
using Microsoft.Extensions.Logging;

namespace vd.import.lib.core.tasks
{
    public class DownloadTask:ITask
    {
        private readonly ILogger<DownloadTask> _logger;

        public DownloadTask(ILogger<DownloadTask> logger)
        {
            _logger=logger;
        }

        public void TaskImplementation()
        {

            //https://stackoverflow.com/questions/41552052/download-file-using-rx-reactive-programming/41552295

            return;
            using (var client = new WebClient())
            {
                var localTemp = "";
                //var left=Console.CursorLeft;
                //var top=Console.CursorTop;
                // fake as if you are a browser making the request.
                client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");

                localTemp=StaticUtilities.GetDataPath();

                //var result=DownloadFileHelper.DownloadFileTaskAsync(ConstUrl.FinancialStatementDataSetBaseUrl + "2017q3.zip", localTemp + "Data\\");
                
                var progressChangedObservable = Observable.FromEventPattern<DownloadProgressChangedEventHandler, DownloadProgressChangedEventArgs>(
                     h => client.DownloadProgressChanged += h,
                     h => client.DownloadProgressChanged -= h
                );

                var downloadCompletedObservable = Observable.FromEventPattern<AsyncCompletedEventHandler, AsyncCompletedEventArgs>(
                     h => client.DownloadFileCompleted += h,
                     h => client.DownloadFileCompleted -= h
                );

                progressChangedObservable.Select(ep => ep.EventArgs)
                .Subscribe(dpcea => 
                {
                    //Console.SetCursorPosition(left,top);
                    //Console.WriteLine($"{dpcea.ProgressPercentage}% complete. {dpcea.TotalBytesToReceive - dpcea.ProgressPercentage} bytes received. {dpcea.TotalBytesToReceive} bytes to receive.");
                });

                downloadCompletedObservable.Select(ep => ep.EventArgs)
                .Subscribe(_ => Console.WriteLine("Download file complete."));

                
                client.DownloadFileAsync(new Uri(ConstUrl.FinancialStatementDataSetBaseUrl +CurrentSessionParams.FileName+".zip"), localTemp + CurrentSessionParams.LocalDirName +"\\" + CurrentSessionParams.FileName + ".zip");
                // // wait for the current thread to complete, since the an async action will be on a new thread.
                while (client.IsBusy) { }
            }
        }
    }
}