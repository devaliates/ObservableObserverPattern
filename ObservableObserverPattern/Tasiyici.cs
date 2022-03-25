namespace ObservableObserverPattern;

public class Tasiyici : IObserver<Urun>
{
    private List<Urun> urunler = new List<Urun>();

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Urun value)
    {
        this.UrunuYukle(value);
    }

    public void UrunuYukle(Urun urun)
    {
        this.urunler.Add(urun);
        Console.WriteLine($"{urun.Name}, taşıyıcıya yüklendi.");
    }
}
