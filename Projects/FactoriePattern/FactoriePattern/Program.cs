using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoriePattern
{
    public abstract class Pizza
    {
        protected string Name = "";
        public void Prepare() => Console.WriteLine($"Preparing {Name}");
        public void Bake() => Console.WriteLine($"Baking {Name}");
        public void Cut() => Console.WriteLine($"Cutting {Name}");
        public void Box() => Console.WriteLine($"Boxing {Name}");
        public string GetName() => Name;
    }

    public class CheesePizza : Pizza
    {
        public CheesePizza() { Name = "Cheese Pizza"; }
    }
    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza() { Name = "Pepperoni Pizza"; }
    }
    public class VeggiePizza : Pizza
    {
        public VeggiePizza() { Name = "Veggie Pizza"; }
    }

    public class PizzaStore
    {
        private readonly SimplePizzaFactory factory;

        public PizzaStore(SimplePizzaFactory _factory)
        {
            this.factory = _factory;
        }
        public Pizza OrderPizza(string type)
        {
            Pizza pizza = factory.CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        
    }
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            // TODO: return the concrete pizza that matches the type.
            switch (type)
            {
                case "cheese":
                    return new CheesePizza();

                case "pepperoni":
                    return new PepperoniPizza();

                case "veggie":
                    return new VeggiePizza();
                default:
                    throw new NotImplementedException(type);
            }
        }
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new PizzaStore(new SimplePizzaFactory());
            store.OrderPizza("cheese");
            Console.WriteLine();
            store.OrderPizza("pepperoni");
        }
    }
}
