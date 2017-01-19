using System;
using System.Configuration;
using System.Threading.Tasks;

namespace RetryHelper
{
    public static class RetryHelper
    {
        private static int _retryHelperAttempts;
        private static int _retryHelperDelay;

        private static void InitializeSettings()
        {
            if (_retryHelperAttempts != default(int) && _retryHelperDelay != default(int)) { return; }  // Already initialized

            const string retryHelperAttempts = "retryHelperAttempts";
            const string retryHelperDelay = "retryHelperDelay";
            const int defaultAttempts = 3;
            const int defaultDelay = 5000;

            var appSettings = ConfigurationManager.AppSettings;

            int attempts;
            int delay;
            _retryHelperAttempts = int.TryParse(appSettings[retryHelperAttempts], out attempts) ? attempts : defaultAttempts;
            _retryHelperDelay = int.TryParse(appSettings[retryHelperDelay], out delay) ? delay : defaultDelay;
        }


        public static async Task<T> CallAndRetry<T, TE>(IRetryHelperOperation operation, Func<IRetryHelperOperation, Task<T>> func)
        {
            InitializeSettings();

            var result = default(T);
            for (var i = 0; i < _retryHelperAttempts; i++)
            {
                try
                {
                    result = await func(operation);
                    break;
                }
                catch (Exception ex)
                {
                    if (ex is TE)
                    {
                        if (i < _retryHelperAttempts)
                        {
                            await Task.Delay(_retryHelperDelay);
                        }
                        else
                        {
                            throw;  // Let this bubble up to GlobalExceptionHandler.
                        }
                    }
                }
            }

            return result;
        }
    }
}
