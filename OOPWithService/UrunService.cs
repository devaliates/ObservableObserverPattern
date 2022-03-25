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
        observers.OfType<IObserver<AddedModel<UrunModel>>>()
            .ToList()
            .ForEach(observer => observer.OnNext(new AddedModel<UrunModel>(urun)));
    }

    public void Remove(UrunModel urun)
    {
        Console.WriteLine($"{urun.Ad}, Uzak servise gönderildi.");
        Console.WriteLine($"{urun.Ad}, Silindi");
        observers.OfType<IObserver<RemovedModel<UrunModel>>>()
            .ToList()
            .ForEach(observer => observer.OnNext(new RemovedModel<UrunModel>(urun)));
    }


    public void Dispose() 
    {
        this.observers.Clear();
    }

    public IDisposable Subscribe(IObserver<AddedModel<UrunModel>> observer)
    {
        this.observers.Add(observer);
        return this;
    }

    public IDisposable Subscribe(IObserver<RemovedModel<UrunModel>> observer)
    {
        this.observers.Add(observers);
        return this;
    }
}
