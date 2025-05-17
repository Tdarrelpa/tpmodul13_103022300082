using System;
using System.Collections.Generic;
using System.Threading;

namespace tpmodul13_103022300082
{
    public interface ISubject
    {
        // Menambahkan observer ke dalam subject.
        void Attach(IObserver observer);

        // Menghapus observer dari subject.
        void Detach(IObserver observer);

        // Memberitahu semua observer tentang perubahan pada subject.
        void Notify();
    }

    // Subjek memiliki beberapa status penting dan memberitahukan pengamat ketika status tersebut berubah.
    public class Subject : ISubject
    {
        // Demi kesederhanaan, status Subjek, yang penting bagi semua pelanggan, disimpan dalam variabel ini.
        public int State { get; set; } = -0;

        /*
         * Daftar pelanggan. 
         * Dalam kehidupan sehari-hari, daftar pelanggan dapat disimpan secara lebih komprehensif 
         * (dikategorikan berdasarkan jenis kegiatan, dll.).
         */
        private readonly List<IObserver> _observers = []; // Setara dengan 'new List<IObserver>()'

        // Metode pengelolaan langganan.
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        // Memicu pembaruan pada setiap pelanggan.
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        /*
         * Biasanya, logika berlangganan hanya sebagian kecil dari apa yang dapat dilakukan Subjek. 
         * Subjek biasanya memiliki beberapa logika bisnis penting, 
         * yang memicu metode notifikasi setiap kali sesuatu yang penting akan terjadi (atau setelahnya).
         */
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }
}