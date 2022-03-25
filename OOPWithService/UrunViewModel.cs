namespace OOPWithService;

using OOPWithService.Records;

public class UrunViewModel : IObserver<AddUrun>, IObserver<RemoveUrun>
{
    private IList<UrunModel> urunler = new List<UrunModel>();
    private IUrunService urunService = new UrunService();

    public UrunViewModel()
    {
        urunService.GetAll();

        this.urunService.Subscribe((IObserver<AddUrun>)this);
        this.urunService.Subscribe((IObserver<RemoveUrun>)this);

        Console.WriteLine("Ürünler listeleniyor.");
    }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();
    public void OnNext(AddUrun value) 
    {
        this.urunler.Add(value.model);
        Console.WriteLine($"{value.model.Ad}, Viewe eklendi gösteriliyor.");
    }

    public void OnNext(RemoveUrun value)
    {
        this.urunler.Remove(value.model);
        Console.WriteLine($"{value.model.Ad}, Viewden kaldırıldı.");
    }

    public void YeniUrunEkleSil()
    {
        UrunModel model = new UrunModel()
        {
            Id = 1,
            Ad = "Ürün 1"
        };

        UrunModel model2 = new UrunModel()
        {
            Id = 2,
            Ad = "Ürün 2"
        };

        urunService.Add(model);
        urunService.Add(model2);
        urunService.Remove(model);
    }
}
