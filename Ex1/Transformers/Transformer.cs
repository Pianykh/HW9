
namespace Ex1
{
    internal abstract class Transformer
    {
        public string Name { get; }
        protected bool IsVehicle = false;
        protected readonly Weapon Weapon;
        protected readonly Scanner Scanner;
        public int Armour { get; protected set; }
        protected Transformer EnemyTransformer;

        protected Transformer(string name, Weapon weapon, Scanner scanner)
        {
            Name = name;
            Weapon = weapon;
            Scanner = scanner;
            Armour = 200;
        }
        public abstract void Fire();

        public abstract void ReloadWeapon();

        public abstract void Transform();

        public abstract void Run();

        public abstract void FindEnemy();

        public abstract void ShootAtEnemy();

        public abstract void GetDamage(int damage);

        public abstract void CaptureTheTarget(Transformer transformer);

        public abstract void ShowStatus();

    }
}
