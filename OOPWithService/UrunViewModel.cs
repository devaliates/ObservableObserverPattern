namespace OOPWithService;

public class UrunViewModel
{
    private readonly IList<UrunModel> urunler = new List<UrunModel>();
    private readonly IUrunService urunService = new UrunService();

    public UrunViewModel()
    {
        this.urunService.GetAll();

        this.urunService.SubAddAction(async (urun) =>
        {
            this.urunler.Add(urun);
            Console.WriteLine($"{urun.Ad} viewde listeye eklendi.");
        });

        this.urunService.SubAddAction((urun) =>
        {
            this.urunler.Add(urun);
            Console.WriteLine($"{urun.Ad} viewde listeye eklendi.");
        });

        this.urunService.SubDeleteAction((urun) =>
        {
            this.urunler.Remove(urun);
            Console.WriteLine($"{urun.Ad} viewde listeden kaldırıldı.");
        });

        Console.WriteLine("Ürünler listeleniyor.");
    }

    public void YeniUrunEkleSil()
    {
        UrunModel model = new UrunModel()
        {
            Id = 1,
            Ad = "Ürün 1"
        };

        this.urunService.Add(model);
        this.urunService.Remove(model);
    }
}
