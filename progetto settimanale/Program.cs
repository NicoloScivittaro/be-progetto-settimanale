
namespace progetto_settimanale
{
    namespace CalcoloImposta
    {
        // Definizione della classe Contribuente
        class Contribuente
        {
            // definisco le Proprietà pubbliche della classe
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataNascita { get; set; }
            public string CodiceFiscale { get; set; }
            public char Sesso { get; set; }
            public string ComuneResidenza { get; set; }
            public decimal RedditoAnnuale { get; set; }

            // Costruttore della classe Contribuente
            public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso,
                string comuneResidenza, decimal redditoAnnuale)
            {
                Nome = nome;
                Cognome = cognome;
                DataNascita = dataNascita;
                CodiceFiscale = codiceFiscale;
                Sesso = sesso;
                ComuneResidenza = comuneResidenza;
                RedditoAnnuale = redditoAnnuale;
            }

            // Metodo per calcolare l'imposta basata sugli scaglioni di reddito
            public decimal CalcolaImposta()
            {
                decimal imposta = 0m;

                if (RedditoAnnuale <= 15000)
                {
                    imposta = RedditoAnnuale * 0.23m; // Aliquota 23% per i primi 15.000€
                }
                else if (RedditoAnnuale <= 28000)
                {
                    imposta = 3450 + ((RedditoAnnuale - 15000) * 0.27m); // 3450€ + 27% sulla parte eccedente i 15.000€
                }
                else if (RedditoAnnuale <= 55000)
                {
                    imposta = 6960 + ((RedditoAnnuale - 28000) * 0.38m); // 6960€ + 38% sulla parte eccedente i 28.000€
                }
                else if (RedditoAnnuale <= 75000)
                {
                    imposta = 17220 + ((RedditoAnnuale - 55000) * 0.41m); // 17220€ + 41% sulla parte eccedente i 55.000€
                }
                else
                {
                    imposta = 25420 + ((RedditoAnnuale - 75000) * 0.43m); // 25420€ + 43% sulla parte eccedente i 75.000€
                }

                return imposta;
            }

            // Override del metodo ToString per fornire una rappresentazione stringa dell'oggetto Contribuente
            public override string ToString()
            {

                return $"Contribuente: {Nome} {Cognome},\n" +
                       $"nato il {DataNascita:dd/MM/yyyy} ({Sesso}),\n" +
                       $"residente in {ComuneResidenza},\n" +
                       $"codice fiscale: {CodiceFiscale}\n" +
                       $"Reddito dichiarato: {RedditoAnnuale:C}\n" +
                       $"IMPOSTA DA VERSARE: {CalcolaImposta():C}";
            }
        }

        // Classe Program contenente il metodo Main
        class Program
        {
            static void Main(string[] args)
            {


                // Richiesta dei dati del contribuente all'utente
                Console.WriteLine("Inserisci il nome:");
                string nome = Console.ReadLine();

                Console.WriteLine("Inserisci il cognome:");
                string cognome = Console.ReadLine();

                Console.WriteLine("Inserisci la data di nascita (dd/MM/yyyy):");
                DateTime dataNascita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.WriteLine("Inserisci il codice fiscale:");
                string codiceFiscale = Console.ReadLine();

                Console.WriteLine("Inserisci il sesso (M/F):");
                char sesso = Char.Parse(Console.ReadLine().ToUpper());

                Console.WriteLine("Inserisci il comune di residenza:");
                string comuneResidenza = Console.ReadLine();

                Console.WriteLine("Inserisci il reddito annuale:");
                decimal redditoAnnuale = Decimal.Parse(Console.ReadLine());

                // Creazione di un'istanza della classe Contribuente con i dati inseriti
                Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

                // Stampa del riepilogo e del calcolo dell'imposta
                Console.WriteLine("***************************************");
                Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
                Console.WriteLine(contribuente);
            }
        }
    }
}