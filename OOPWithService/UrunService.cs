namespace OOPWithService;

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
        observers.OfType<IObserver<AddedUrunModel>>()
            .ToList()
            .ForEach(observer => observer.OnNext(new AddedUrunModel(urun)));
    }

    public void Remove(UrunModel urun)
    {
        Console.WriteLine($"{urun.Ad}, Uzak servise gönderildi.");
        Console.WriteLine($"{urun.Ad}, Silindi");
        observers.OfType<IObserver<RemovedUrunModel>>()
            .ToList()
            .ForEach(observer => observer.OnNext(new RemovedUrunModel(urun)));
    }


    public void Dispose() 
    {
        this.observers.Clear();
    }

    public IDisposable Subscribe(IObserver<AddedUrunModel> observer)
    {
        this.observers.Add(observer);
        return this;
    }

    public IDisposable Subscribe(IObserver<RemovedUrunModel> observer)
    {
        this.observers.Add(observers);
        return this;
    }
}
