namespace ObservableObserverPattern;

public class FabrikaManager
{
    Fabrika fabrika; 

    public FabrikaManager()
    {
        fabrika = new Fabrika();
        Tasiyici tasiyici = new Tasiyici();
        UrunSayici usayici = new UrunSayici();

        fabrika.Subscribe(tasiyici);
        fabrika.Subscribe(usayici);
        fabrika.UnSubscribe(tasiyici);
    }

    public void StartProduct()
    {
        fabrika.UretimeBasla("Buzdolabı");
        fabrika.UretimeBasla("Ayakkabı");
        fabrika.UretimeBasla("Bulaşık Makinesi");

        fabrika.Dispose();
    }
}
