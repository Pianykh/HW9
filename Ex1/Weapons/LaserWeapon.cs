// unset

using System;

namespace Ex1
{
    internal class LaserWeapon : Weapon
    {
        public LaserWeapon()
        {
            Ammo = 10;
        }
        
        public override void Reload()
        {
            Console.WriteLine("Reload Laser weapon");
            Ammo = 10;
        }

        public override void Fire()
        {
            if (Ammo > 0)
            {
                Console.WriteLine("Laser weapon");
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