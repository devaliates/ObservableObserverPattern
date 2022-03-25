﻿namespace ObservableObserverPattern;

using System;

public class Fabrika : IObservable<Urun>, IDisposable
{
    private IList<IObserver<Urun>> observers = new List<IObserver<Urun>>();

    public void Dispose()
    {
        this.observers.Clear();
    }

    public IDisposable Subscribe(IObserver<Urun> observer)
    {
        this.observers.Add(observer);
        return this;
    }

    public void UretimeBasla(String urunAdi)
    {
        Urun urun = new Urun() { Name = urunAdi };
        this.UretimTamamlandi(urun);
    }

    private void UretimTamamlandi(Urun urun)
    {
        Console.WriteLine($"{urun.Name}, üretimi tamamlandı.");
        this.observers.ToList().ForEach(observer => observer.OnNext(urun));
    }
}
