namespace ObservableObserverPattern;

public interface IFabrika : IObservable<Urun>, IDisposable
{
    void UretimeBasla(String urunAdi);
}