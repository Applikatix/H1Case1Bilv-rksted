
namespace H1Case1Bilværksted;

public struct Besked {

    (Bil, string)[] tilbage = { (new Bil(Bilmaerke.Fiat, "Punto", new DateOnly(2010, 1, 1)), "udstødning"),
                                (new Bil(Bilmaerke.AlfaRomeo, "Giulia", new DateOnly(2019, 8, 1)), "styretøjet")};

    string tekst;

    public Besked(Bil bil) {
        DateOnly dato = DateOnly.FromDateTime(DateTime.Now).AddYears(-5);

        if (bil.Aargang < dato && bil.Synsdate < dato)
            tekst = "Bil skal til syn.";
        else tekst = "Bil skal ikke synes.";

        foreach ( (Bil b, string fejl) in tilbage )
            if (b.Maerke == bil.Maerke
             && b.Model == bil.Model
             && b.Aargang > bil.Aargang) {
                tekst += $"\nBilen har føljende fabriksfejl: {fejl}";
                break;
            }
    }

    public override string ToString() => tekst;
}
