namespace ObservableObserverPattern.CustomInterface;

public interface IObservable<T>
    : System.IObservable<T>
{
    void UnSubscribe(IObserver<T> observer);
}
