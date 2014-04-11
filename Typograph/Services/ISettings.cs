using System.ComponentModel;

namespace Typograph.Services
{
    public interface ISettings : INotifyPropertyChanged
    {
        bool IsLineBreaks { get; set; }

        bool IsParagraphs { get; set; }
    }
}