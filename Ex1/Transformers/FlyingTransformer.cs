// unset

namespace Ex1
{
    internal abstract class FlyingTransformer : Transformer
    {
        protected FlyingTransformer(string name, Weapon weapon, Scanner scanner) : base(name, weapon, scanner) { }

        public abstract void Fly();
    }
}