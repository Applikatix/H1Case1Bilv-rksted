using System.ComponentModel.DataAnnotations;

namespace H1Case1Bilværksted;

public enum Bilmaerke {
    None,
    Audi,
    Fiat,
    [Display(Name="Alfa Romeo")]
    AlfaRomeo,
}

public class Bil {

    public Bilmaerke Maerke { get; init; }
    public string Model { get; init; }
    public DateOnly Aargang { get; init; }
    public DateOnly Synsdate { get; init; }

    public Bil (Bilmaerke maerke, string model, DateOnly aargang, DateOnly synsdate) {
        Maerke = maerke;
        Model = model;
        Aargang = aargang;
        Synsdate = synsdate;
    }
    public Bil (Bilmaerke maerke, string model, DateOnly aargang) {
        Maerke = maerke;
        Model = model;
        Aargang = aargang;
        Synsdate = aargang;
    }

    public override string ToString() =>
        $"Mærke: {Maerke}\nModel: {Model}\nÅrgang: {Aargang}\nSidste synsdato: {Synsdate}";
}
