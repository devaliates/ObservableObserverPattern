namespace OOPWithService;

using System;

public class UrunService : IUrunService
{
    public record AddUrun(UrunModel model);
    public record DeleteUrun(UrunModel model);

    public void GetAll()
    {
        Console.WriteLine($"Tüm ürünler uzak servisten istendi.");
        Console.WriteLine($"Tüm ürünler getirildi.");
    }

    public void Add(UrunModel urun)
    {
        Console.WriteLine($"{urun.Ad}, Uzak servise gönderildi.");
        Console.WriteLine($"{urun.Ad}, Eklendi");
        this.Notify(new AddUrun(urun));
    }

    public void Remove(UrunModel urun)
    {
        Console.WriteLine($"{urun.Ad}, Uzak servise gönderildi.");
        Console.WriteLine($"{urun.Ad}, Silindi");
        this.Notify(new DeleteUrun(urun));
    }

    private List<IObserver<Object>> observers = new List<IObserver<Object>>();

    public IDisposable Subscribe(IObserver<Object> observer)
    {
        this.observers.Add(observer);
        return null;
    }

    public void Notify(Object obj)
    {
        this.observers.ToList().ForEach(observer => observer.OnNext(obj));
    }
}
