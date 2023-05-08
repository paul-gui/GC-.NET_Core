namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Numere complexe:
            //  -operatii de adunare, scadere, inmultire, ridicarea la putere si afisarea in forma trigonometrica
            //  -se poate initializa in 3 moduri:
            //      1.Complex()
            //      2.Complex(parte_reala);
            //      3.Complex(parte_reala, parte_imaginara)
            Complex a = new(12, 2);
            Complex b = new(10);
            Console.WriteLine(a.ToTrigonometricForm());

            //Numere rationale:
            //  -
        }
    }
}