namespace OOPWithService;

public record AddedUrunModel(UrunModel urun);
public record RemovedUrunModel(UrunModel urun);

public interface IUrunService : IObservable<AddedUrunModel>, IObservable<RemovedUrunModel>, IDisposable
{
    void Add(UrunModel urun);
    void GetAll();
    void Remove(UrunModel urun);
}