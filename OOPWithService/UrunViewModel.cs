namespace OOPWithService;

using OOPWithService.Records;

public class UrunViewModel : IObserver<AddedModel<UrunModel>>, IObserver<RemovedModel<UrunModel>>
{
    private IList<UrunModel> urunler = new List<UrunModel>();
    private IUrunService urunService = new UrunService();

    public UrunViewModel()
    {
        urunService.GetAll();

        urunService.Subscribe((IObserver<AddedModel<UrunModel>>)this);
        urunService.Subscribe((IObserver<RemovedModel<UrunModel>>)this);

        Console.WriteLine("Ürünler listeleniyor.");
    }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();
    public void OnNext(AddedModel<UrunModel> value) 
    {
        this.urunler.Add(value.model);
        Console.WriteLine($"{value.model.Ad}, Viewe eklendi gösteriliyor.");
    }

    public void OnNext(RemovedModel<UrunModel> value)
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

        urunService.Add(model);
        urunService.Remove(model);
    }
}
