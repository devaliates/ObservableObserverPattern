namespace OOPWithService;

using System;

public interface IUrunService
{
    void Add(UrunModel urun);
    void GetAll();
    void Remove(UrunModel urun);
    void SubAddAction(Action<UrunModel> action);
    void SubDeleteAction(Action<UrunModel> action);
}