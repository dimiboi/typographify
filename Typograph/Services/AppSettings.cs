using System.ComponentModel;
using System.Threading;
using Typograph.Properties;

namespace Typograph.Services
{
    public class AppSettings : ISettings
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLineBreaks
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return Settings.Default.IsLineBreaks;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
            set
            {
                _lock.EnterWriteLock();
                try
                {
                    if (Settings.Default.IsLineBreaks == value)
                        return;

                    Settings.Default.IsLineBreaks = value;
                    Settings.Default.Save();
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
                RaisePropertyChanged("IsLineBreaks");
            }
        }

        public bool IsParagraphs
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return Settings.Default.IsParagraphs;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
            set
            {
                _lock.EnterWriteLock();
                try
                {
                    if (Settings.Default.IsParagraphs == value)
                        return;

                    Settings.Default.IsParagraphs = value;
                    Settings.Default.Save();
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
                RaisePropertyChanged("IsParagraphs");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}