using singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton
{
    using System;
    public sealed class ChocolateBoiler
    {
        // TODO 1: a private static field that holds the one boiler
        private bool _empty = true;
        private bool _boiled = false;
        private static ChocolateBoiler instance;

        private ChocolateBoiler()
        {
            Console.WriteLine("Building the boiler");
        }
        // TODO 2: a public static Instance property that creates the
        // boiler on the first request and returns it ever after
        public static ChocolateBoiler Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChocolateBoiler();
                return instance;
            }
           
        }
        public void Fill()
        {
            if (_empty)
            {
                _empty = false; _boiled = false;
                Console.WriteLine("Filling the boiler");
            }
        }
        public void Boil()
        {
            if (!_empty && !_boiled)
            {
                _boiled = true;
                Console.WriteLine("Boiling the mixture");
            }
        }
        public void Drain()
        {
            if (!_empty && _boiled)
            {
                _empty = true;
                Console.WriteLine("Draining the boiler");
            }
        }
    }
}

    internal class Program
    {
        static void Main(string[] args)
        {
        
            ChocolateBoiler boiler = ChocolateBoiler.Instance;
            boiler.Fill();
            boiler.Boil();
            boiler.Drain();

    }
    }

