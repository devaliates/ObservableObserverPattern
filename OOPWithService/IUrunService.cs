namespace OOPWithService;

using OOPWithService.Records;

public interface IUrunService : IObservable<AddedModel<UrunModel>>, IObservable<RemovedModel<UrunModel>>, IDisposable
{
    void Add(UrunModel urun);
    void GetAll();
    void Remove(UrunModel urun);
}