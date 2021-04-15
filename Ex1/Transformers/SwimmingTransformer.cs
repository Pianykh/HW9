
namespace Ex1
{
    internal abstract class SwimmingTransformer : Transformer
    {
        protected SwimmingTransformer(string name, Weapon weapon, Scanner scanner) : base(name, weapon, scanner) { }

        public abstract void Swim();
    }
}
