using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using StashNet.Exceptions;

namespace StashNet.Extensions
{
    public static class AsyncExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static T Response<T>(this Task<T> task)
            where T : IRestResponse
        {
            return task.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static T Data<T>(this Task<T> task)
        {
            return task.Result;
        }

        public static void EnsureSuccessStatusCode(this IRestResponse response)
        {
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new StashboardHttpResponseException(response.StatusDescription, response.ErrorException);
            }
        }


        // <summary>
        // 
        // </summary>
        // <typeparam name = "T" ></ typeparam >
        // < param name="task"></param>
        // <param name = "cancellationToken" ></ param >
        // < returns ></ returns >
        public static Task<T> As<T>(this Task<IRestResponse> task, CancellationToken cancellationToken)
        {
            return task.ContinueWith(t =>
            {
                t.Result.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(t.Result.Content);
            },
            cancellationToken, 
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.Current);
        }

        internal static void RequestCanceled(this CancellationToken cancellationToken, Action<string> logging)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                if (!logging.IsNull())
                    logging(
                        "Cancellation of this task was requested by the caller, therefore, request for resources has been canceled.");

                cancellationToken.ThrowIfCancellationRequested();
            }
        }


    }
}