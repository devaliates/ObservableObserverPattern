namespace OOPWithService;

public interface IUrunService : IObservable<Object>
{
    void Add(UrunModel urun);
    void GetAll();
    void Remove(UrunModel urun);
}