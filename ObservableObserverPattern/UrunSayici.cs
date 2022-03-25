namespace ObservableObserverPattern;
public class UrunSayici : IObserver<Urun>
{
    public Int32 Sayac { get; set; }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();
    public void OnNext(Urun value)
    {
        Sayac++;
        Console.WriteLine($"Toplam üretilen ürün Sayısı: {Sayac}");
    }
}
