// unset

using System.Dynamic;

namespace Ex1
{
    internal abstract class Weapon
    {
        protected int Ammo;
        
        protected int ChargeCritCounter{ get; set; }

        public abstract void Reload();

        public abstract void Fire();

        public abstract void ResetChargeCritCounter();

        public abstract int GetChargeCritCounter();

    }
}