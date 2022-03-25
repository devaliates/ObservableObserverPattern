namespace OOPWithService;

using OOPWithService.Records;

using System;
using System.Collections;

public class UrunService : IUrunService
{
    private ArrayList observers = new ArrayList();

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
        this.Notify(new RemoveUrun(urun));
    }

    private void Notify<T>(T obj)
    {
        observers.OfType<IObserver<T>>()
            .ToList()
            .ForEach(observer => observer.OnNext(obj));
    }

    public void Dispose() 
    {
        this.observers.Clear();
    }

    public IDisposable Subscribe(IObserver<AddUrun> observer)
    {
        this.observers.Add(observer);
        return this;
    }

    public IDisposable Subscribe(IObserver<RemoveUrun> observer)
    {
        this.observers.Add(observers);
        return this;
    }
}
