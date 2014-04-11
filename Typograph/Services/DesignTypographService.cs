using System;

namespace Typograph.Services
{
    public class DesignTypographService : ITypographService
    {
        public void Typographify(string text, Action<string, AggregateException> callback)
        {
            callback(string.Empty, null);
        }
    }
}