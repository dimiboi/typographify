using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
using Typograph.Services;

namespace Typograph.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Dispatcher _dispatcher;
        private readonly ITypographService _service;
        private bool _isSettingsFlyoutOpen = false;
        private bool _isWorking = false;
        private string _text = string.Empty;

        public MainViewModel(ITypographService serivce, ISettings settings)
        {
            _service = serivce;
            Settings = settings;
            _dispatcher = Dispatcher.CurrentDispatcher;

            ShowSettingsFlyout = new RelayCommand(() =>
            {
                _dispatcher.Invoke(() => IsSettingsFlyoutOpen = true);
            });

            Typographify = new RelayCommand(() =>
            {
                _service.Typographify(Text, (result, error) =>
                {
                    if (error != null)
                        _HandleException(error);

                    if (result != null)
                        _dispatcher.Invoke(() => Text = result);
                });
            }
            , () => !string.IsNullOrWhiteSpace(Text) && !IsWorking);
        }

        public bool IsSettingsFlyoutOpen
        {
            get { return _isSettingsFlyoutOpen; }
            set
            {
                if (_isSettingsFlyoutOpen == value)
                    return;

                _isSettingsFlyoutOpen = value;
                RaisePropertyChanged("IsSettingsFlyoutOpen");
            }
        }

        public bool IsWorking
        {
            get { return _isWorking; }
            set
            {
                if (_isWorking == value)
                    return;

                _isWorking = value;
                RaisePropertyChanged("IsWorking");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ISettings Settings { get; private set; }

        public ICommand ShowSettingsFlyout { get; private set; }

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;

                _text = value;
                RaisePropertyChanged("Text");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand Typographify { get; private set; }

        private void _HandleException(AggregateException e)
        {
            e.Handle((ex) =>
            {
                Debug.WriteLine(e);
                return true;
            });
        }
    }
}