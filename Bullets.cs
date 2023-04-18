using System;

namespace Asteroids
{
    public class Bullets
    {

        // 'variables needed for all bullets
        public bool inForm;  //'boolean to say whether the bullet is within the form
        public int BFx; //'x coordinate of the front of the bullet
        public int BFy; //'y coordinate of the front of the bullet
        public int BBx; //'x coordinate of the back of the bullet
        public int BBy; //'y coordinate of the back of the bullet
        public int bSpeed; //'integer for the speed of the bullets
        public int bLength; //'integer to define the length of the bullets
        public double bAngle; //'double for the angle of the bullet




        public Bullets(double currentAngle, int frontx, int fronty) // void New
        {                                                                        //'sub for instantiating a bullet
            bool inForm = true;
            int bLength = 2; //'bullets length 2
            int bSpeed = 10; //'bullet speed 10
            int BFx = frontx; //'bullet front x = current ship front x passed into the sub
            int BFy = fronty; //'bullet front y = current ship front y passed into the sub
            double BBx = BFx + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength); //'back x = front x + angle times length
            double BBy = BFy + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength); //'back y = front y + angle times length
            double bAngle = currentAngle; //'bullet angle = current ship angle passed into the sub
            Asteroids_Game.bullet_array.Add(this); //'add the instantiated bullet object into the array


        }


        public void update()

        {
            for (int i = 0; i == Asteroids_Game.bullet_array.Count; i++)
            {

                if (Asteroids_Game.bullet_array[i].inForm == true)
                {
                    //'back x = front x + cos(angle)*length
                    Asteroids_Game.bullet_array[i].BBx = Convert.ToInt32(Asteroids_Game.bullet_array[i].BFx + ((Math.Sin(Asteroids_Game.bullet_array[i].bAngle)) * bLength)); //'back x
                    Asteroids_Game.bullet_array[i].BBy = Convert.ToInt32(Asteroids_Game.bullet_array[i].BFy + ((Math.Cos(Asteroids_Game.bullet_array[i].bAngle)) * bLength)); //'back y
                    Asteroids_Game.bullet_array[i].BFx = Convert.ToInt32(Asteroids_Game.bullet_array[i].BFx + ((Math.Cos(Asteroids_Game.bullet_array[i].bAngle)) * (bSpeed + Asteroids_Game.mySpaceship.SOsd))); //'front x
                    Asteroids_Game.bullet_array[i].BFy = Convert.ToInt32(Asteroids_Game.bullet_array[i].BFy + ((Math.Sin(Asteroids_Game.bullet_array[i].bAngle)) * (bSpeed + Asteroids_Game.mySpaceship.SOsd))); //'front y
                    //'if outside the form change the variable
                    if (Asteroids_Game.bullet_array[i].BFx >= Asteroids_Game.formwidth | Asteroids_Game.bullet_array[i].BFx < 0)
                    {
                        Asteroids_Game.bullet_array[i].inForm = false;
                        Asteroids_Game.numberOfBullets -= 1;
                        break;
                    }
                    if (Asteroids_Game.bullet_array[i].BFy >= Asteroids_Game.formheight | Asteroids_Game.bullet_array[i].BFy < 0)
                    {
                        Asteroids_Game.bullet_array[i].inForm = false;
                        Asteroids_Game.numberOfBullets -= 1;
                        break;
                    }
                }
            }
        }


        public void fin(int i) 
        {
   //     Asteroids_Game.bullet_array[i].Finalize() DO THIS
        }
    }
}
