using System;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class GameMenu : Form
    {
        bool running = false;
        public GameMenu()
        {
            InitializeComponent();
        }
        public static string gamemode;
        private void button1_Click(object sender, EventArgs e)
        {
            

            if (GamemodeBox.Text == "Binary Conversions")
            {
                gamemode = "bincon";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }
            if (GamemodeBox.Text == "Binary Calculations")
            {
                gamemode = "bincal";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }
            if (GamemodeBox.Text == "Hexadecimal Conversions")
            {
                gamemode = "hexcon";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }
            if (GamemodeBox.Text == "Hexadecimal Calculations")
            {
                gamemode = "hexcal";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }
            if (GamemodeBox.Text == "Octal Conversions")
            {
                gamemode = "octcon";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }
            if (GamemodeBox.Text == "Octal Calculations")
            {
                gamemode = "octcal";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }

            if (GamemodeBox.Text == "Fun (Non-Educational)")
            {
                gamemode = "fun";
                Asteroids_Game newAsteroids = new Asteroids_Game();
                newAsteroids.Show();
                running = true;
            }
            else
            {
            }
            
        }

        private void GamemodeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tick_Tick(object sender, EventArgs e)
        {
            if (running == true)
            {
                //5Ship.Update();
            }
        }
    }
}
