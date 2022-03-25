namespace OOPWithService;

public class UrunViewModel : IObserver<Object>
{
    private IList<UrunModel> urunler = new List<UrunModel>();
    private IUrunService urunService = new UrunService();

    public UrunViewModel()
    {
        urunService.GetAll();

        urunService.Subscribe(this);

        Console.WriteLine("Ürünler listeleniyor.");
    }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();
    public void OnNext(Object value) 
    {
        if(value is UrunService.AddUrun addUrun)
        {
            this.urunler.Add(addUrun.model);
            Console.WriteLine($"{addUrun.model.Ad}, Viewe eklendi.");
        }
        if(value is UrunService.DeleteUrun deleteUrun)
        {
            this.urunler.Remove(deleteUrun.model);
            Console.WriteLine($"{deleteUrun.model.Ad}, View den kaldırıl!");
        }
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
