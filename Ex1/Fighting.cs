

using System;

namespace Ex1
{
    internal static class Fighting
    {
        
        public static void Fight(Transformer firstTransformer, Transformer secondTransformer)
        {
            Console.WriteLine("Fight!!!");
            
            firstTransformer.Transform();
            secondTransformer.Transform();
            firstTransformer.FindEnemy();
            secondTransformer.FindEnemy();
            firstTransformer.Run();
            secondTransformer.Run();
            firstTransformer.CaptureTheTarget(secondTransformer);
            secondTransformer.CaptureTheTarget(firstTransformer);

            while (firstTransformer.Armour > 0 && secondTransformer.Armour > 0)
                if (GreatRandom.GenerateMove() == 0)
                    firstTransformer.ShootAtEnemy();
                else
                    secondTransformer.ShootAtEnemy();
            Console.WriteLine(firstTransformer.Armour > 0 ? $"{firstTransformer.Name} wins!" : $"{secondTransformer.Name} wins!");
                
            
        }
    }
}