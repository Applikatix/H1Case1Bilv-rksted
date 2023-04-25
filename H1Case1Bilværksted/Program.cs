using static System.Console;
using System.Text.RegularExpressions;

namespace H1Case1Bilværksted;

class Program {

    static Bilmaerke ParseMaerke(string s) {
        switch (Regex.Replace(s.ToLower(), @"\s+", "")) {
            case "audi":
                return Bilmaerke.Audi;
            case "fiat":
                return Bilmaerke.Fiat;
            case "alfaromeo":
                return Bilmaerke.AlfaRomeo;
            default:
                return Bilmaerke.None;
        }
    }

    static void ClearLine(int t) {
        SetCursorPosition(0, t);
        Write(new string(' ', BufferWidth));
        CursorLeft = 0;
    }
    static void ClearLine() {
        CursorLeft = 0;
        Write(new string(' ', BufferWidth));
        CursorLeft = 0;
    }

    static void Ugyldig() {
        ForegroundColor = ConsoleColor.Red;
        Write("(Ugyldigt format) ");
        ResetColor();

        ClearLine(CursorTop - 1);
    }

    static readonly string[] dateFormats =
        { "d-M-yy", "dd-MM-yy", "d-M-yyyy", "dd-MM-yyyy",
          "d/M/yy", "dd/MM/yy", "d/M/yyyy", "dd/MM/yyyy" };

    static Bilmaerke maerke;
    static string model;
    static DateOnly aargang;
    static DateOnly synsdato;

    static void Main() {

        Write("Indtast bilmærke: ");
        maerke = ParseMaerke(ReadLine());

        Write("Indtast model: ");
        model = ReadLine();

        Write("Indtast aargang: ");
        while (true) {
            if (!DateOnly.TryParseExact(ReadLine(), dateFormats, out DateOnly x)) {
                Ugyldig();
                Write("Indtast aargang: ");
            } else {
                ClearLine(CursorTop);
                aargang = x; break;
            }
        }

        if (aargang < DateOnly.FromDateTime(DateTime.Now).AddYears(-5)) {
            Write("Indtast sidste synsdato: ");
            while (true) {
                if (!DateOnly.TryParseExact(ReadLine(), dateFormats, out DateOnly x)) {
                    Ugyldig();
                    Write("Indtast sidste synsdato: ");
                } else {
                    ClearLine();
                    synsdato = x; break;
                }
            }
        }        

        Bil bil = new(maerke, model, aargang, synsdato);
        Besked msg = new(bil);

        ForegroundColor = ConsoleColor.Green;
        WriteLine();
        WriteLine(bil);
        WriteLine();
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine(msg.ToString());
        ResetColor();
    }
}

