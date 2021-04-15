// unset

using System;

namespace Ex1
{
    internal class StarScream : FlyingTransformer
    {
        public StarScream(string name, Weapon weapon, Scanner scanner) : base(name, weapon, scanner) { }

        public override void Fire()
        {
            Console.Write($"{Name} fire a ");
            Weapon.Fire();
        }

        public override void ReloadWeapon()
        {
            Console.Write($"{Name} reload a ");
            Weapon.Reload();
        }

        public override void Transform()
        {
            IsVehicle = !IsVehicle;
            Console.WriteLine($"{Name} transform");
        }

        public override void Run()
        {
            Console.WriteLine(IsVehicle ? $"{Name} run" : $"{Name} can not run in current form");
        }

        public override void FindEnemy()
        {
            Console.Write($"{Name} scan with a ");
            Scanner.Scan();
        }

        public override void ShootAtEnemy()
        {
            var currentDamage = GreatRandom.GenerateDamage();

            if (Weapon.GetChargeCritCounter() == 2)
            {
                Fire();
                EnemyTransformer.GetDamage(currentDamage * 4);
                Console.WriteLine($"CRIT! {Name} DEALS {currentDamage * 4} DAMAGE!");
                Weapon.ResetChargeCritCounter();
            }
            else
            {
                Fire();
                EnemyTransformer.GetDamage(currentDamage);
                Console.WriteLine($"{Name} deals {currentDamage} damage!");
            }
        }

        public override void GetDamage(int damage)
        {
            Armour -= damage;
        }

        public override void CaptureTheTarget(Transformer transformer)
        {
            EnemyTransformer = transformer;
        }

        public override void ShowStatus()
        {
            Console.WriteLine($"Armour is {Armour}");
        }

        public override void Fly()
        {
            Console.WriteLine(IsVehicle ? $"{Name} drive" : $"{Name} can not drive in current form");
        }
    }
}