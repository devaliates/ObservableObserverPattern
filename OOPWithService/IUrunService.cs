namespace OOPWithService;

using OOPWithService.Records;

public interface IUrunService : IObservable<AddUrun>, IObservable<RemoveUrun>, IDisposable
{
    void Add(UrunModel urun);
    void GetAll();
    void Remove(UrunModel urun);
}