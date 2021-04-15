

using System;
using System.Collections.Generic;

namespace Ex1
{
    public static class Controller
    {
        public static void Start()
        {
            var pairOfTransformers = new List<Transformer>();

            while (pairOfTransformers.Count != 2)
            {
                Console.WriteLine($"Please, create {pairOfTransformers.Count + 1} Transformer");
                Console.WriteLine("Please, enter a name:");
                var name = Console.ReadLine();
                Console.WriteLine("Please, enter a type. 1.OptimusPrime. 2. StarScream");
                var typeNumber = Console.ReadLine();
                Console.WriteLine("Please, choose a weapon. 1. Laser. 2. Rocket");
                var weaponNumber = Console.ReadLine();
                Console.WriteLine("Please, choose a scanner. 1. Optical. 2. Sonar");
                var scannerNumber = Console.ReadLine();
                
                Weapon weapon = weaponNumber switch
                {
                    "1" => new LaserWeapon(),
                    "2" => new RocketLauncher(),
                    _ => throw new Exception()
                };
                
                Scanner scanner = scannerNumber switch
                {
                    "1" => new OpticalScanner(),
                    "2" => new Sonar(),
                    _ => throw new Exception()
                };
                
                switch (typeNumber)
                {
                    case "1":
                        pairOfTransformers.Add(new OptimusPrime(name, weapon, scanner));
                        break;
                    case "2":
                        pairOfTransformers.Add(new StarScream(name, weapon, scanner));
                        break;
                    default: throw new Exception();
                }
            }
            Fighting.Fight(pairOfTransformers[0], pairOfTransformers[1]);
        }
    }
}