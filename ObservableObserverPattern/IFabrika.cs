namespace ObservableObserverPattern;

public interface IFabrika : ObservableObserverPattern.CustomInterface.IObservable<Urun>, IDisposable
{
    void UretimeBasla(String urunAdi);
}