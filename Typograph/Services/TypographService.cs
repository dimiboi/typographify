using ArtLebedevStudio;
using System;
using System.Threading.Tasks;

namespace Typograph.Services
{
    public class TypographService : ITypographService
    {
        private readonly ISettings _settings;

        public  TypographService(ISettings settings)
        {
            _settings = settings;
        }

        public void Typographify(string text, Action<string, AggregateException> callback)
        {
            var remoteTypograf = new RemoteTypograph();

            remoteTypograf.xmlEntities();
            remoteTypograf.br(_settings.IsLineBreaks);
            remoteTypograf.p(_settings.IsParagraphs);

            var task = Task.Factory.StartNew<string>(() => remoteTypograf.ProcessText(text));
            task.ContinueWith((t) => callback(t.Result, null), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((t) => callback(null, t.Exception), TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}