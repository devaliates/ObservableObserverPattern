namespace OOPWithService;

public class UrunViewModel : IObserver<AddedUrunModel>, IObserver<RemovedUrunModel>
{
    private IList<UrunModel> urunler = new List<UrunModel>();
    private IUrunService urunService = new UrunService();

    public UrunViewModel()
    {
        urunService.GetAll();

        urunService.Subscribe((IObserver<AddedUrunModel>)this);
        urunService.Subscribe((IObserver<RemovedUrunModel>)this);

        Console.WriteLine("Ürünler listeleniyor.");
    }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();
    public void OnNext(AddedUrunModel value) 
    {
        this.urunler.Add(value.urun);
        Console.WriteLine($"{value.urun.Ad}, Viewe eklendi gösteriliyor.");
    }

    public void OnNext(RemovedUrunModel value)
    {
        this.urunler.Remove(value.urun);
        Console.WriteLine($"{value.urun.Ad}, Viewden kaldırıldı.");
    }

    public void YeniUrunEkleSil()
    {
        UrunModel model = new UrunModel()
        {
            Id = 1,
            Ad = "Ürün 1"
        };

        urunService.Add(model);
        urunService.Remove(model);
    }
}
