using System;

namespace Typograph.Services
{
    public interface ITypographService
    {
        void Typographify(string text, Action<string, AggregateException> callback);
    }
}