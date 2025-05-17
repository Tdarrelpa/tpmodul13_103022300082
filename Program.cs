// See https://aka.ms/new-console-template for more information
using tpmodul13_103022300082;

public class Program
{
    public static void Main(string[] args)
    {
        // Menggunakan contoh pola Observer di C#
        var subject = new Subject(); // Membuat objek subjek
        var observerA = new ConcreteObserverA(); // Membuat objek pengamat A
        subject.Attach(observerA); // Mendaftarkan pengamat A ke subjek

        var observerB = new ConcreteObserverB(); // Membuat objek pengamat B
        subject.Attach(observerB); // Mendaftarkan pengamat B ke subjek

        // Memicu logika bisnis yang akan memberi tahu pengamat
        subject.SomeBusinessLogic();
        subject.SomeBusinessLogic();

        subject.Detach(observerB); // Menghapus pengamat B dari subjek

        subject.SomeBusinessLogic(); // Memicu logika bisnis lagi

        // Mengimplementasikan pola Observer dalam aplikasi pemantauan saham di C#
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