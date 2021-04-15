// unset

using System;

namespace Ex1
{
    internal class RocketLauncher : Weapon
    {
        public RocketLauncher()
        {
            Ammo = 5;
        }

        public override void Reload()
        {
            Console.WriteLine("Reload Rocket launcher");
            Ammo = 5;
        }

        public override void Fire()
        {
            if (Ammo > 0)
            {
                Console.WriteLine("Rocket launcher");
                Ammo--;
                ChargeCritCounter++;
            }
            else
                Reload();
        }

        public override void ResetChargeCritCounter()
        {
            ChargeCritCounter = 0;
        }

        public override int GetChargeCritCounter()
        {
            return ChargeCritCounter;
        }
    }
}