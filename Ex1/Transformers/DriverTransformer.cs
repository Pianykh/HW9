// unset

namespace Ex1
{
    internal abstract class DriverTransformer : Transformer
    {
        protected DriverTransformer(string name, Weapon weapon, Scanner scanner) : base(name, weapon, scanner) { }

        public abstract void Drive();
    }
}