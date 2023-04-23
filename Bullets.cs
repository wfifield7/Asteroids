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
            inForm = true;
            bLength = 2; //'bullets length 2
            bSpeed = 10; //'bullet speed 10
            BFx = frontx; //'bullet front x = current ship front x passed into the sub
            BFy = fronty; //'bullet front y = current ship front y passed into the sub
            BBx = BFx + Convert.ToInt32((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength); //'back x = front x + angle times length
            BBy = BFy + Convert.ToInt32((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength); //'back y = front y + angle times length
            bAngle = currentAngle; //'bullet angle = current ship angle passed into the sub
            Asteroids_Game.bullet_array.Add(this); //'add the instantiated bullet object into the array


        }


        public void update()

        {
            for (int i = 0; i <= Asteroids_Game.bullet_array.Count - 1; i++) // starts at i = 1 as the bullet appeared at 0..........
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
                    bulletCollisionChecker(i);
                }

                if (Asteroids_Game.bullet_array[i].inForm == false)
                {
                    fin(i);
                }
            }
        }

        public void bulletCollisionChecker(int i)
        {
            int X = Asteroids_Game.bullet_array[i].BFx;
            int Y = Asteroids_Game.bullet_array[i].BFy;
            double collideAngle;
            for (int x = 0; x < Asteroids_Game.Asteroids_array.Count - 1; x++)
            {
                // check if the bullet is close to the asteroid
                if ((X > Convert.ToInt32(Asteroids_Game.Asteroids_array[x].startX) - 100) && (X < (Asteroids_Game.Asteroids_array[x].startX + 100) && (Y < Asteroids_Game.Asteroids_array[x].startY + 100) && (Y > Asteroids_Game.Asteroids_array[x].startY - 100)))
                {

                    collideAngle = 0;
                    double a, b, c, ax, ay, bx, by, cx, cy, dotproduct, thisone, theta, costheta;

                    for (int k = 0; k < Asteroids_Game.Asteroids_array[i].numberOfPoints - 2; k++)
                    {
                        ax = Math.Abs(X - Asteroids_Game.Asteroids_array[i].xPoints[k]);
                        ay = Math.Abs(Y - Asteroids_Game.Asteroids_array[i].yPoints[k]);
                        bx = Math.Abs(X - Asteroids_Game.Asteroids_array[i].xPoints[k + 1]);
                        by = Math.Abs(Y - Asteroids_Game.Asteroids_array[i].yPoints[k + 1]);
                        cx = Math.Abs(Asteroids_Game.Asteroids_array[i].xPoints[k] - Asteroids_Game.Asteroids_array[i].xPoints[k + 1]);
                        cy = Math.Abs(Asteroids_Game.Asteroids_array[i].yPoints[k] - Asteroids_Game.Asteroids_array[i].yPoints[k + 1]);
                        a = Math.Sqrt((ax * ax) + (ay * ay));
                        b = Math.Sqrt((bx * bx) + (by * by));
                        c = Math.Sqrt((cx * cx) + (cy * cy));

                        costheta = Math.Abs(((a * a) + (b * b) - (c * c)) / (2 * a * b));
                        theta = Math.Cos(costheta);

                        //dotproduct = ((ax * bx) + (ay * by));
                        //thisone = (dotproduct / (a * b));
                        //collideAngle += thisone;

                    }


                    ax = Math.Abs(X - Asteroids_Game.Asteroids_array[i].xPoints[Asteroids_Game.Asteroids_array[i].numberOfPoints - 1]);
                    ay = Math.Abs(Y - Asteroids_Game.Asteroids_array[i].yPoints[Asteroids_Game.Asteroids_array[i].numberOfPoints - 1]);
                    bx = Math.Abs(X - Asteroids_Game.Asteroids_array[i].xPoints[0]);
                    by = Math.Abs(Y - Asteroids_Game.Asteroids_array[i].yPoints[0]);
                    a = Math.Sqrt((ax * ax) + (ay * ay));
                    b = Math.Sqrt((bx * bx) + (by * by));
                    dotproduct = ((ax * bx) + (ay * by));
                    thisone = Math.Acos(dotproduct / (a * b));
                    collideAngle += thisone;
                    if (collideAngle > 2 * Math.PI)
                    {
                        Asteroids_Game.bullet_array[i].inForm = false;
                    }
                }    
            }
        }
    

        public void fin(int i)
        {
            /*
            //////////////////////// Asteroids_Game.bullet_array[i].Finalize(); //DO THIS
            
            int counter = i;
             Bullets[] temp = new Bullets[Asteroids_Game.bullet_array.Count - 1];

            //Array.Copy(Asteroids_Game.bullet_array, 0, temp, 0, i); // write up <----------------------


            while (counter < Asteroids_Game.bullet_array.Count)
            {
                temp[counter - 1] = Asteroids_Game.bullet_array[counter];
                Asteroids_Game.bullet_array[counter - 1] = temp[counter - 1];
                    counter++;
            }

            Asteroids_Game.bullet_array.RemoveAt(counter - 1);
            */

            Bullets[] temp = new Bullets[Asteroids_Game.bullet_array.Count - 1];
            int counter = 0;
            for (int x = 0; x <= Asteroids_Game.bullet_array.Count - 1; x++)
            {
                if (x != i)
                {
                    temp[counter] = (Asteroids_Game.bullet_array[x]);
                    counter++;
                }
            }
            Asteroids_Game.bullet_array.Clear();
            for (int x = 0; x < temp.Length; x++)
            {
                Asteroids_Game.bullet_array.Add(temp[x]);
            }



        }
    }
}
