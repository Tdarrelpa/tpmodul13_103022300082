// See https://aka.ms/new-console-template for more information
using tpmodul13_103022300082;

public class Program
{
    public static void Main(string[] args)
    {
        Stock sahamA = new("SahamKoperasiJaya", 100.00m); // Setara dengan 'new Stock("SahamKoperasiJaya", 100.00m);'

        // Membuat objek-objek investor (Observer)
        InvestorA investor1 = new("Budi"); // Setara dengan 'new InvestorA("Budi");'
        InvestorB investor2 = new("Siti"); // Setara dengan 'new InvestorB("Siti");'

        // Mendaftarkan investor sebagai observer
        sahamA.AttachInvestor(investor1);
        sahamA.AttachInvestor(investor2);

        // Mengubah harga saham (mengirim notifikasi ke observer)
        sahamA.ChangePrice(105.50m);
        sahamA.ChangePrice(102.30m);

        // Salah satu investor berhenti memantau saham
        sahamA.DetachInvestor(investor1);

        sahamA.ChangePrice(108.75m); // Investor 1 tidak akan menerima notifikasi ini
    }
}