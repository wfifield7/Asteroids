using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class Ship
    {

        public double SLx;
        public double SLy;
        public double SRx;
        public double SRy;
        public double SFx;
        public double SFy;
        public double SOx;
        public double SOy;

        //'give the points a value to represent the length from the origin to define the size of the ship
        public int SFl; //    'ship front length
        public int SLl; //'ship left length
        public int SRl;   //  'ship right length

        //'give the points an angle from the origin point of the ship
        public double SOa; //   'ship origin angle
        public double SFa;    //'ship front angle
        public double SLa;   // 'ship left angle
        public double SRa;    //'ship right angle
        public double pSOa;   //'define previous spaceship origin angle

    //'define delta angles (rate of change of angle)
    public double SOad;    //'ship origin delta angle
    public double SOsd;    //'ship origin delta speed
    public double dsmax;    //'maximum delta speed

    //'define drag variables of ship
    public double sdrag;   //'speed drag

        public Ship()
        {

              // 'give the    points a value to represent the length from the origin to define the size of the ship
          SFl = 34;    //'ship front length
          SLl = 23;    //'ship left length
          SRl = 20; //'ship right length
          //'give the points an angle from the origin point of the ship
          SOa = 0.872664626;  // 'ship origin angle
          SFa = 0; //'ship front angle
          SLa = 1.919862177; //  'ship left angle   
          SRa = 4.36332313; //'ship right angle
          pSOa = 0.872664626;  //  'define previous spaceship origin angle

          //'define delta angles (rate of change of angle)
          SOad = 0;//  'ship origin delta angle
          SOsd = 0;//'ship origin delta speed
          dsmax = 4;//'maximum delta speed

          //'define drag variables of ship
          sdrag = 0.07;  //'speed dra 
        }
    public void Update() {
            //MessageBox.Show("updating");
            //'update algorithm:
            //'ship point x/y = ship origin x/y + cos(ship origin angle) * Ship point length
            //'update front point
            Asteroids_Game.mySpaceship.SFx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.SOa) * Asteroids_Game.mySpaceship.SFl);
        Asteroids_Game.mySpaceship.SFy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.SOa) * Asteroids_Game.mySpaceship.SFl);
        //'update left point
        Asteroids_Game.mySpaceship.SLx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SLa) * Asteroids_Game.mySpaceship.SLl);
        Asteroids_Game.mySpaceship.SLy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SLa) * Asteroids_Game.mySpaceship.SLl);
        //'update right point
        Asteroids_Game.mySpaceship.SRx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SRa) * Asteroids_Game.mySpaceship.SRl);
        Asteroids_Game.mySpaceship.SRy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SRa) * Asteroids_Game.mySpaceship.SRl);
        //'update the origin point by the delta of the speed
        Asteroids_Game.mySpaceship.SOx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.pSOa) * Asteroids_Game.mySpaceship.SOsd);
        Asteroids_Game.mySpaceship.SOy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.pSOa) * Asteroids_Game.mySpaceship.SOsd);
        //'if statement for the drag to slow the ship
        if (Asteroids_Game.mySpaceship.SOsd > 0) 
        {
            Asteroids_Game.mySpaceship.SOsd -= Asteroids_Game.mySpaceship.sdrag;
        }
        //'update the angle of the ship
        Asteroids_Game.mySpaceship.SOa += Asteroids_Game.mySpaceship.SOad;
        //'when the ship leaves the form appear on the opposite side
        if (Asteroids_Game.mySpaceship.SOx < 0) 
        {
            Asteroids_Game.mySpaceship.SOx = Asteroids_Game.formwidth;
            }
        if (Asteroids_Game.mySpaceship.SOy < 0) 
        {
            Asteroids_Game.mySpaceship.SOy = Asteroids_Game.formheight;
            }
        if (Asteroids_Game.mySpaceship.SOx > Asteroids_Game.formwidth) 
        {
            Asteroids_Game.mySpaceship.SOx = 0;
            }
        if (Asteroids_Game.mySpaceship.SOy > Asteroids_Game.formheight)
        {
            Asteroids_Game.mySpaceship.SOy = 0;
            }
    }
    }
}
