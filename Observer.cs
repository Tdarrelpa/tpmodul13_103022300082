﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace tpmodul13_103022300082
{
    public interface IObserver
    {
        // Menerima notifikasi dari subject
        void Update(ISubject subject);
    }

    /*
     * Pengamat memiliki beberapa metode untuk menerima pembaruan dari subjek 
     * karena mereka akan bereaksi terhadap pembaruan yang dikeluarkan oleh Subjek yang telah mereka tautkan.
     */

    public class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is not Subject)
            {
                Console.WriteLine("ConcreteObserverA: Invalid subject type.");
                return;
            }

            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    public class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is not Subject) 
            {
                Console.WriteLine("ConcreteObserverB: Invalid subject type.");
                return;
            }
            if ((subject as Subject).State is 0 or >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}