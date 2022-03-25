namespace OOPWithService;

using System;

public class UrunService : IUrunService
{
    private IList<Action<UrunModel>> addActions = new List<Action<UrunModel>>();
    private IList<Action<UrunModel>> deleteActions = new List<Action<UrunModel>>();

    public void GetAll()
    {
        Console.WriteLine($"Tüm ürünler uzak servisten istendi.");
        Console.WriteLine($"Tüm ürünler getirildi.");
    }

    public void Add(UrunModel urun)
    {
        Console.WriteLine($"{urun.Ad}, Uzak servise gönderildi.");
        Console.WriteLine($"{urun.Ad}, Eklendi");
        addActions.ToList().ForEach(action => action.Invoke(urun));
    }

    public void Remove(UrunModel urun)
    {
        Console.WriteLine($"{urun.Ad}, Uzak servise gönderildi.");
        Console.WriteLine($"{urun.Ad}, Silindi");
        deleteActions.ToList().ForEach(action => action.Invoke(urun));
    }

    public void SubAddAction(Action<UrunModel> action)
    {
        this.addActions.Add(action);
    }

    public void SubDeleteAction(Action<UrunModel> action)
    {
        this.deleteActions.Add(action);
    }
}
