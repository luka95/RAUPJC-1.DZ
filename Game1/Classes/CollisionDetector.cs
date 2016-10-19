using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Classes
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            
            //Side walls
            
            if (b.X == -GameConstants.WallDefaultSize)
            {
                if (a.X - a.Width  < b.X + b.Width/2) return true;
            }
            else if (b.X == 500)
            {
                if (a.X + a.Width > b.X ) return true;
            }
            
            //Paddles
            if (a.X < b.X + b.Width 
                   && a.X > b.X 
                   && a.Y + a.Height / 2 > b.Y - b.Height / 2
                   && b.Y == 860) return true;
            else if (a.X < b.X + b.Width
                && a.X > b.X 
                && a.Y - a.Height / 2 < b.Y + b.Height / 2
                && b.Y < 450) return true;
            

            //Goal walls
            if (b.Y == 900)
            {
                if (a.Y + a.Height / 2 > b.Y) return true;
            }
            else if (b.Y == -GameConstants.WallDefaultSize)
            {
                if (a.Y - a.Height / 2 < b.Y + b.Height / 2) return true;
            }
            //Paddles
           // else
           // {

               

           // }
            return false;
        }
    }
}
