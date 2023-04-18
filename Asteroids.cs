using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    public class Asteroids
    {
        //'Variables needed for all asteroids
        public bool onScreen; // 'boolean for whether the asteroid is on the screen
        public Double aAngle; // 'double for the angle asteroids
        public Double aSpeed; //'integer for the speed of the asteroids
        public double[] xPoints; //  'array for all the x co-ordinates for the points in the asteroid
        public double[] yPoints; // 'array for all the y coordinates for the points in the asteroid
        public Point[] AsteroidPoints; //'array for all points of the asteroid
        //public var AsteroidPoints = new[];
        public Double startX; //'starting x coordinate
        public Double startY; //'starting y coordinate
        public Boolean Asteroidbig; //'boolean for if the asteroid is a large one
        public int numberOfPoints; //'integer for number of points in the asteroid
        public Double[] FixedAngles = new Double[9]; //'array of angles for each asteroid with a maximum of 9 angles
        public string size; //'variable for the size of the asteroid
        public Char innervalue;
        public Asteroids(string asize, string NewOld, char value)
        {
            Random rnd = new Random();
            int innervalue = value;
            bool onScreen = true;
            size = asize;
            double aSpeed = rnd.NextDouble() * 3 + 1; // 'random speed variable between 1 and 4
            numberOfPoints = rnd.Next(5, 10); //'random number of points between 5 and 9
            for (int i = 1; i <= numberOfPoints; i++)
            { //'loop through the number of points and calculate angles between the points based on the number of points and random numbers
                FixedAngles[i - 1] = rnd.NextDouble() * (i * (2 * Math.PI) / numberOfPoints) + (i - 1) * (2 * Math.PI) / numberOfPoints; // check rnd.nextdouble // ask if FixedAngles[] is valid, [] not ()
                //MessageBox.Show("Fixed angle is: " + FixedAngles[i-1].ToString()); //x is anywhere from 16-35, y is always 0
            }
            
            Array.Resize(ref xPoints, (numberOfPoints)); //'define the size of the array of x coordinates  // using array.resize may not work, found on         -----                  ------                https://social.msdn.microsoft.com/Forums/en-US/545e6adb-550f-400c-9a68-a4a5e3125c5d/how-to-use-redim-preserve-in-cnet?forum=aspgettingstarted
            Array.Resize(ref yPoints, (numberOfPoints)); //'define the size of the array of y coordinates
            Array.Resize(ref AsteroidPoints, (numberOfPoints)); //'define the size of the array of points of the asteroid
            Asteroids_Game.Asteroids_array.Add(this); //'add the asteroid to the array
            Asteroids_Game.AsteroidAngle(Asteroids_Game.Asteroids_array.Count - 1); //'call the asteroid angle function to decide where the asteroid should start and the angle it travels at

            for (int i = 0; i <= numberOfPoints - 1; i++)
            {
                int rando;

                if (size == "b")
                {
                    rando = rnd.Next(0, 46) + 35; //'create a random variable to define the distance from the origin point for the points
                    Asteroidbig = true;
                }
                else
                {

                    Asteroidbig = false;
                    if (NewOld == "NewS")
                    {
                        startX = Asteroids_Game.tempAsteroidx;
                        startY = Asteroids_Game.tempAsteroidy;
                    }
                    rando = rnd.Next(0, 26) + 15; //'create a random variable to define the distance from the origin point for the points
                }

                xPoints[i] = Convert.ToInt32(startX + (Math.Cos(FixedAngles[i]) * (rando)));// 'the x points = the origin x + an angle * the random distance
                yPoints[i] = Convert.ToInt32(startY + (Math.Sin(FixedAngles[i]) * (rando))); //'the y points = the origin y + an angle * the random
                //MessageBox.Show("Point 1 is: " + xPoints[i].ToString() + ", " + yPoints[i].ToString() + ", Fixed angle is: " + FixedAngles[i].ToString() ); //x is anywhere from 16-35, y is always 0
                //MessageBox.Show("Point 2 is: " + Asteroids_array[0].AsteroidPoints[1].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[1].Y.ToString()); //x is anywhere from 16-35, y is always 0
                //MessageBox.Show("Point 3 is: " + Asteroids_array[0].AsteroidPoints[2].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[2].Y.ToString()); //x is anywhere from 16-35, y is always 0
                Point OnePoint = new Point(Convert.ToInt32(xPoints[i]), Convert.ToInt32(yPoints[i])); //'make a point variable from the x and y defined
                AsteroidPoints[i] = (OnePoint); //'add the point to an array
            }
        }



        public void Update(int i)
        {
            // 'update the origin point of the asteroids
            //MessageBox.Show("aAngle = " + aAngle.ToString());
            Asteroids_Game.Asteroids_array[i].startX += ((Math.Cos(Asteroids_Game.Asteroids_array[i].aAngle)) * Asteroids_Game.Asteroids_array[i].aSpeed);
            Asteroids_Game.Asteroids_array[i].startY += ((Math.Sin(Asteroids_Game.Asteroids_array[i].aAngle)) * Asteroids_Game.Asteroids_array[i].aSpeed);
            for (int j = 0; j <= Asteroids_Game.Asteroids_array[i].numberOfPoints - 1; j++)//number of points is zero here so loop is not running
            //for (int j = 0; j <= 9; j++)
            { //'loop through the points of the asteroid
                Asteroids_Game.Asteroids_array[i].xPoints[j] += ((Math.Cos(Asteroids_Game.Asteroids_array[i].aAngle)) * Asteroids_Game.Asteroids_array[i].aSpeed); //'update the x coordinates
                Asteroids_Game.Asteroids_array[i].yPoints[j] += ((Math.Sin(Asteroids_Game.Asteroids_array[i].aAngle)) * Asteroids_Game.Asteroids_array[i].aSpeed); //'update the y coordinates
                Point OnePoint = new Point(Convert.ToInt32(Asteroids_Game.Asteroids_array[i].xPoints[j]), Convert.ToInt32(Asteroids_Game.Asteroids_array[i].yPoints[j])); //'combining the coordinates into a point
                Asteroids_Game.Asteroids_array[i].AsteroidPoints[j] = (OnePoint);//'add the point to the array

                // ************* probably delete these two lines ************************
                //Asteroids_Game.Asteroids_array.RemoveAt(i);
                //Asteroids /*Asteroids_Game.*/asteroid = new Asteroids("b", "OldB", Asteroids_Game.Asteroids_array[i].innervalue);
            }
            //'if off-screen change the variable
            if (Asteroids_Game.Asteroids_array[i].startX > Asteroids_Game.formwidth | Asteroids_Game.Asteroids_array[i].startX < 0)
            {
                Asteroids_Game.Asteroids_array[i].onScreen = false;
            }
            if (Asteroids_Game.Asteroids_array[i].startY > Asteroids_Game.formheight | Asteroids_Game.Asteroids_array[i].startY < 0)
            {
                Asteroids_Game.Asteroids_array[i].onScreen = false;
            }
            else
            {
                Asteroids_Game.Asteroids_array[i].onScreen = true;
            }
            //'if off-screen remove all the data from the variables and remove the asteroid from the array, and create a new asteroid
            if (Asteroids_Game.Asteroids_array[i].onScreen == false)
            {
                if (Asteroids_Game.Asteroids_array[i].size == "b")
                {
                    char temp = Asteroids_Game.Asteroids_array[i].innervalue;
                    // ALSO DO THIS ----->   Asteroids_Game.Asteroids_array[i].Finalize();
                    Asteroids_Game.Asteroids_array.RemoveAt(i);
                    Asteroids /*Asteroids_Game.*/asteroid = new Asteroids("b", "OldB", temp);
                }
                if (Asteroids_Game.Asteroids_array[i].size == "s")
                {
                    char temp = Asteroids_Game.Asteroids_array[i].innervalue;
                    // DO THIS ------>  fin(i)
                    Asteroids_Game.Asteroids_array.RemoveAt(i);
                    Asteroids /*Asteroids_Game.*/asteroid = new Asteroids("s", "OldS", temp);
                }
            }
        }
    }
}

