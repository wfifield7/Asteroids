/* create message boxes:
 * outlining the co ordinates of every point in the asteroid
 * do this for every asteroid
 * solve
 */



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;






namespace Asteroids
{
    public partial class Asteroids_Game : Form
    {

        public Asteroids_Game()
        {
            InitializeComponent();
            timer1.Start();

        }
        // 'creating all the objects
        public static Ship mySpaceship = new Ship(); //'ship object
        public Asteroids asteroid = new Asteroids("A", "A", Convert.ToChar(1)); //'asteroid object
        public static List<Asteroids> Asteroids_array = new List<Asteroids>();
        public Bullets bullet = new Bullets(-1, -1, -1); //'bullet object
        public static List<Bullets> bullet_array = new List<Bullets>(); //'array of bullet objects

        //'get the size of the form
        public static int formwidth = 50; //'width of the form given a value once loaded
        public static int formheight; //'height of the form given a value once loaded

        //'asteroid variables
        public int numberOfAsteroids;  //'the number of the asteroids loaded each time the game is loaded, given a value dependant on mode and level later in program

        public static double tempAsteroidx; //'a temporary storage of the centre coordinates of the asteroid used when a big asteroid is destroyed, to give the 'children' asteroids the same start coordinates
        public static double tempAsteroidy;

        public int destroyed = 0; //'integer for number of small asteroids destroyed
        public int lostasteroids = -1; //'stores the position in the array of the asteroid that needs to be removed from the array

        //'bullet variables
        public int counter; //'a counter to decide the spacing between bullets
        public static int numberOfBullets = 0; //'declare a variable that will hold the number of bullets at every moment of hte program
        public bool hit = false; //'boolean for wether an asteroid has been hit, if the asteroid has been hit, then remove it

        //'collision variables
        public double collideangle; //'define a variable for calculating the angles between the asteroids and other objects

        //'boolean for keys
        public bool up = false;
        public bool left = false;
        public bool right = false;
        public bool space = false;

        //'additional function variables
        public int score = 0; //'declare a variable for storing the score of the user
        public int lives = 3; //'declare and define a variable for lives
        public int level = 0; //'declare and define a variable for the level to be changed within the program
        public string PlayerAnswerVariable = ""; //'declare a variable for the string that the user builds up when answering define as "" for checking
        public string answer; //'declare a varaible for the actual answer to be compared against
        public int Decimalanswer; //'declare a variable that is the decimal version of the answer to be converted between number bases and into a string for checking
        public int multiplicationfactor;
        public int questionrandom; //'stores the random number used in the questions
        public int questionType; //'stores the number representing the type of question being generated
        //'booleans for deciding which label to use for storing the characters
        public bool One1Shown = false;
        public bool One2Shown = false;
        public bool Zero1Shown = false;
        public bool Zero2Shown = false;
        public static double timeleft = 600; //'Total number of seconds of the educational modes before game ends
        public TimeSpan iSpan = TimeSpan.FromSeconds(timeleft); //'used to represent the 600 seconds as minutes and seconds
        //'declare the points that represent where the gameover screen will position
        public Point abovecentre;
        public Point belowcentre;
        public Point offscreen = new Point(-1000, -1000);
        public int AnswerSubstringCounter = 0;

        public int testingspace = 0; //'variable deciding the length of time before the screen returns to black after a collision

        //'defining the brush for painting the ship
        public Color brushColor = Color.Black; //'defining the colour of all the objects on screen

        Random rnd = new Random();


        


        private void Form1_Paint(object sender, PaintEventArgs e)
        {                                             // might need "Handles Me.Paint" equivalent

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //'line of code to help make the graphics smooth
            Pen pen = new Pen(brushColor); //'create a pen element

            Brush brush; //'create a brush object
            brush = new SolidBrush(brushColor); //'give the brush a color 
                                                //#Region "ship drawing"
                                                //'define the points for the ship based off the coordinates
            Point SL = new Point(Convert.ToInt32(mySpaceship.SLx), Convert.ToInt32(mySpaceship.SLy));
            Point SR = new Point(Convert.ToInt32(mySpaceship.SRx), Convert.ToInt32(mySpaceship.SRy));
            Point SO = new Point(Convert.ToInt32(mySpaceship.SOx), Convert.ToInt32(mySpaceship.SOy));
            Point SF = new Point(Convert.ToInt32(mySpaceship.SFx), Convert.ToInt32(mySpaceship.SFy));
            Point[] shipPoints = new Point[] { SL, SR, SF, SL }; //'creating an array of points for the ship                               // TRY INSERTING "SO" TO CREATE AN ARROW-ISH SHIP
            e.Graphics.FillPolygon(brush, shipPoints); //'draw the ship
                                                       //#End Region
                                                       // #Region "bullets"
                                                       //'for loop to draw bullets from the two points given
            for (int x = 0; x <= bullet_array.Count - 1; x++)
            {
                Point BR = new Point(bullet_array[x].BFx, bullet_array[x].BFy);
                Point BF = new Point(bullet_array[x].BBx, bullet_array[x].BBy);
                e.Graphics.DrawLine(pen, BR, BF);
            }
            //#End Region

            //#Region "asteroids"
            //  'for loop to draw asteroids from a random number of points given
            for (int i = 0; i <= Asteroids_array.Count - 1; i++)
            {
                if (Asteroids_array[i].onScreen == true)
                {

                        /*
                        for (int k = 0; k == 3; k++)
                        {
                            int q = j;
                            MessageBox.Show(Asteroids_array[0].AsteroidPoints.Length.ToString());
                            MessageBox.Show(Asteroids_array[0].AsteroidPoints[j].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[j].Y.ToString());
                            MessageBox.Show(j.ToString());
                        }
                        */
                        //MessageBox.Show("Point 1 is: " + Asteroids_array[0].AsteroidPoints[0].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[0].Y.ToString()); //x is anywhere from 16-35, y is always 0
                        //MessageBox.Show("Point 2 is: " + Asteroids_array[0].AsteroidPoints[1].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[1].Y.ToString()); //x is anywhere from 16-35, y is always 0
                        //MessageBox.Show("Point 3 is: " + Asteroids_array[0].AsteroidPoints[2].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[2].Y.ToString()); //x is anywhere from 16-35, y is always 0
                        //MessageBox.Show("Point 10 is: " + Asteroids_array[0].AsteroidPoints[7].X.ToString() + ", " + Asteroids_array[0].AsteroidPoints[1].Y.ToString());
                        e.Graphics.DrawPolygon(pen, Asteroids_array[i].AsteroidPoints); //'if the asteroid is on screen then draw it
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //'numberOfAsteroids numbers
            Random rnd = new Random();
            //'put the formatting for the timer into the text box
            /*Timer.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                            iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                            iSpan.Seconds.ToString.PadLeft(2, "0"c)*/
            //'set the starting points for the origin point within the ship
            mySpaceship.SOx = this.Width / 2;
            mySpaceship.SOy = this.Height / 2;
            formwidth = this.Width;
            //'finds the starting size of the form
            formheight = this.Height;
            abovecentre = new Point(this.Width / 2 - 150, this.Height / 2 - 25);
            belowcentre = new Point(this.Width / 2 - 150, this.Height / 2 + 25);
            this.Paint += Form1_Paint;


            if (GameMenu.gamemode != "fun")
            {
                // =---------------------------------= =-------------------------------=ScoreBox.Hide();
                numberOfAsteroids = rnd.Next(10, 16); //'random generates 10 to 15 asteroids
            }
            else
            { //'if fun is chosen then hide the timer,question,playeranswer and the textboxes containing characters
                numberOfAsteroids = (rnd.Next(5, 11)); //'random generates 5 to 10 asteroids
                Zero1.Hide();
                Zero2.Hide();
                One1.Hide();
                One2.Hide();
                /*Timer.Hide();
                Question.Hide();                                PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                Playeranswer.Hide();*/
            }

            //'populating defaults in Asteroids arrays
            ModeLoader();
            //'generating the questions based on the game mode
            //Questions();
        }
        public void ModeLoader()
        {
            for (int i = 0; i < numberOfAsteroids - 1; i++)
            { //'loop through all the asteroids
                if (GameMenu.gamemode == "bincal" | GameMenu.gamemode == "bincon")
                {//if a binary gamemode is chosen, give the asteroids a character value of 1, 0 or z
                    if (i == 0)
                    { //'0,1,2,3 will contain binary digits that will be displayed in the text boxes 4 and above will contain a z which will not be displayed
                        Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToChar(1));
                    }
                    if (i == 1)
                    {
                        Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToChar(1)); ;
                    }
                    if (i == 2)
                    {
                        Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToChar(0));
                    }
                    if (i == 3)
                    {
                        Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToChar("0"));
                    }
                    if (i >= 4)
                    {
                        Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToChar("z"));
                    }
                }
                else if (GameMenu.gamemode == "hexcal" | GameMenu.gamemode == "hexcon")
                { //'if a hex gamemode is chosen then same as binary but with hex characters
                    if (i == 0)
                    {
                  //      Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToHexString(rnd.Next(1, 17)));
                    }
                    else if (i == 1)
                    {
                    //    Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToHexString(rnd.Next(1, 17)));
                    }
                    else if (i == 2) {
                      //  Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToHexString((rnd.Next(1, 17))));
                            }
                    else if (i == 3) {
                        //Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToHexString((rnd.Next(1, 17))));
                            }
                    else if (i >= 4) {
                         Asteroids asteroid = new Asteroids("b", "NewB", Convert.ToChar("z"));
                    }

                }
                        //        ElseIf GameMenu.gamemode = "octcal" Or GameMenu.gamemode = "octcon" Then ' same but octal characters
                        //    If i = 0 Then
                        //        asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8)))
                        //    ElseIf i = 1 Then
                        //        asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8)))
                        //    ElseIf i = 2 Then
                        //        asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8)))
                        //    ElseIf i = 3 Then
                        //        asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8) + 1))
                        //    ElseIf i >= 4 Then
                        //        asteroid = New Asteroids("b", "NewB", "z")
                        //    End If
                        //Else
                        //    asteroid = New Asteroids("b", "NewB", "z") 'all asteroids are given a value of z if fun is chosen
                        //End If
                    }
        }



        public static void AsteroidAngle(int i)
        {
            //MessageBox.Show("I am here...");
            Random rnd = new Random();
            // 'numberOfAsteroids number to decde the starting side
            int side = rnd.Next(1, 5);
            // 'if side is one then start at top

            if (side == 3)
            {
                double rando = rnd.NextDouble() * formwidth;
                //'set the start pos somewhere along the top
                Asteroids_array[i].startX = rando;
                Asteroids_array[i].startY = 0;
                //'if start pos is in upper third of top number then 180 to 270
                if (rando > ((2 / 3) * formwidth))
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (0.5 * Math.PI)) + Math.PI);
                }
                //  'if start pos is in bottom third of top number then bottom 90 to 180
                if (rando < ((1 / 3) * formwidth))
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (0.5 * Math.PI)) + (0.5 * Math.PI));
                    // 'if start pos is in middle thid of top number then bottom 90 to 270
                }
                else
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (Math.PI)) + (0.5 * Math.PI));
                }

            }
            // 'if side is two(four?) then start at right
            if (side == 4)
            {
                double rando = rnd.NextDouble() * formheight;
                //'set the start pos somewhere along the right
                Asteroids_array[i].startX = formwidth;
                Asteroids_array[i].startY = rando;
                // 'if start pos is in upper third of right number then 270 to 360
                if (rando > ((2 / 3) * formheight))
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (0.5 * Math.PI)) + (Math.PI * 1.5));
                    // 'if start pos is in the bottom third of right number then 180 to 270
                }
                if (rando < ((1 / 3) * formheight))
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (0.5 * Math.PI)) + Math.PI);
                    //'if the start pos is in the middle third of the right number then 180 to 360
                }
                else
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (Math.PI)) + (Math.PI));
                }
            }

            if (side == 1)
            {
                double rando = rnd.NextDouble() * formwidth;
                Asteroids_array[i].startX = rando;
                Asteroids_array[i].startY = formheight;
                //'if start pos is in upper third of bottom number then 270 to 360
                if (rando > ((2 / 3) * formwidth))
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (0.5 * Math.PI)) + (Math.PI * 1.5));
                }
                //'if start pos is in the bottom third of bottom number then 0 to 90
                if (rando < ((1 / 3) * formwidth))
                {
                    Asteroids_array[i].aAngle = (rnd.NextDouble() * (0.5 * Math.PI));
                    //   'if the start pos is in the middle third of the bottom number then 270 to 90
                }
                else
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (Math.PI)) + (1.5 * Math.PI));
            }
            if (side == 2)
            {
                double rando = (rnd.NextDouble() * formheight);
                Asteroids_array[i].startX = 0;
                Asteroids_array[i].startY = rando;
                //'if start pos is in upper third of left number then 0 to 90
                if (rando > ((2 / 3) * formheight))
                {
                    Asteroids_array[i].aAngle = (rnd.NextDouble() * (0.5 * Math.PI));
                }
                //'if start pos is in the bottom third of right number then 90 to 180
                if (rando < ((1 / 3) * formheight))
                {
                    Asteroids_array[i].aAngle = ((rnd.NextDouble() * (0.5 * Math.PI)) + (0.5 * Math.PI));
                    //'if the start pos is in the middle third of the right number then 0 to 180
                }
                else
                {
                    Asteroids_array[i].aAngle = (rnd.NextDouble() * (Math.PI));
                }
            }

        }


        /*






        Public Function binaryconvert(x) 'sub for converting numbers into binary, reuse this sub multiple times
            Return Convert.ToString(x, 2).ToString.PadLeft(8, "0")
        End Function
        Public Sub Questions()
    #Region "binary conversions"
            If GameMenu.gamemode = "bincon" Then 'if binary conversion is chosen
                questionType = Rnd() * 2 'find which question type to generate
                If questionType = 0 Then
                    questionrandom = (Rnd() * 255) + 1 'generate a random number less than 256
                    Question.Text = "Convert this decimal number into an 8-bit binary number: " + questionrandom.ToString 'output the random number as a decimal
                    answer = binaryconvert(questionrandom) 'convert the question to binary ans save the answer
                ElseIf questionType = 1 Then
                    questionrandom = (Rnd() * 255) + 1 'generate a random number less than 256
                    Question.Text = "Convert this hexadecimal number into an 8-bit binary number: " + Hex(questionrandom).ToString 'output the random number as a hex number
                    answer = binaryconvert(questionrandom) 'convert the question to binary ans save the answer
                ElseIf questionType = 2 Then
                    questionrandom = (Rnd() * 255) + 1 'generate a random number less than 256
                    Question.Text = "Convert this octal number into an 8-bit binary number: " + Oct(questionrandom).ToString 'output the number as an octal number
                    answer = binaryconvert(questionrandom) 'convert the question to binary ans save the answer
                End If
    #End Region
    #Region "binary calculations"
            ElseIf GameMenu.gamemode = "bincal" Then 'if binary calculations is chosen
                questionType = Rnd() * 1
                If questionType = 0 Then 'add numbers
                    Decimalanswer = (Rnd() * 255) + 1 'generate the decimal answer less than 256
                    answer = binaryconvert(Decimalanswer) 'convert the answer to binary
                    questionrandom = (Rnd() * (Decimalanswer - 1)) + 1 'generate a random number less than the answer
                    Question.Text = "Add these binary numbers together: " + binaryconvert(questionrandom) + " + " + binaryconvert((Decimalanswer - questionrandom)) 'output the random number and calculate the other number in the calculation
                ElseIf questionType = 1 Then 'subtract numbers
                    Decimalanswer = (Rnd() * 127) + 1 'generate the decimal answer less than 127
                    answer = binaryconvert(Decimalanswer) 'convert the answer to binary
                    questionrandom = (Rnd() * 128) + Decimalanswer ' generate a number between the answer and 128 more max of 255
                    Question.Text = "Subtract these binary numbers : " + binaryconvert(questionrandom) + " - " + binaryconvert((questionrandom - Decimalanswer)) 'output the random number and calculate the other half of the calculation
                ElseIf questionType = 2 Then 'multiply numbers
                    multiplicationFactor = (Rnd() * (29)) + 1
                    questionrandom = Math.Floor(255 / multiplicationFactor)
                    answer = binaryconvert(questionrandom * multiplicationFactor)
                    Question.Text = "Multiply these binary numbers together: " + binaryconvert(questionrandom) + " X " + binaryconvert(multiplicationFactor)
                End If
    #End Region
    #Region "hex conversions"
            ElseIf GameMenu.gamemode = "hexcon" Then 'if hexadecimal conversion is chosen - all same as binary except converted to hex
                questionType = Rnd() * 2
                If questionType = 0 Then
                    questionrandom = (Rnd() * 255) + 1
                    Question.Text = "Convert this decimal number into a hex number: " + questionrandom.ToString
                    answer = Hex(questionrandom)
                ElseIf questionType = 1 Then
                    questionrandom = (Rnd() * 255) + 1
                    Question.Text = "Convert this binary number into a hex number: " + binaryconvert(questionrandom)
                    answer = Hex(Int(binaryconvert(questionrandom)))

                ElseIf questionType = 2 Then
                    questionrandom = (Rnd() * 255) + 1
                    Question.Text = "Convert this octal number into a hex number: " + Oct(questionrandom).ToString
                    answer = Hex(Oct(questionrandom))

                End If
    #End Region
    #Region "hex calculations"
            ElseIf GameMenu.gamemode = "hexcal" Then 'if hex calculations is chosen - same as binary calculations but converted to hexadecimal
                questionType = Rnd() * 1
                If questionType = 0 Then 'add numbers
                    Decimalanswer = (Rnd() * 255) + 1
                    answer = Hex(Decimalanswer)
                    questionrandom = (Rnd() * (Decimalanswer - 1)) + 1
                    Question.Text = "Add these hexadecimal numbers together: " + Hex(questionrandom) + " + " + Hex((Decimalanswer - questionrandom))
                ElseIf questionType = 1 Then 'subtract numbers
                    Decimalanswer = (Rnd() * 127) + 1
                    answer = Hex(Decimalanswer)
                    questionrandom = (Rnd() * 255) + Decimalanswer
                    Question.Text = "Subtract these hexadecimal numbers: " + Hex(questionrandom) + " - " + Hex((questionrandom - Decimalanswer))
                ElseIf questionType = 2 Then 'multiply numbers
                    multiplicationFactor = (Rnd() * (29)) + 1
                    questionrandom = Math.Floor(255 / multiplicationFactor)
                    answer = Hex(questionrandom * multiplicationFactor)
                    Question.Text = "Multiply these hexadecimal numbers: " + Hex(questionrandom) + " X " + Hex(multiplicationFactor)
                End If
    #End Region
    #Region "octal conversions"
            ElseIf GameMenu.gamemode = "octcon" Then 'if octal conversion is chosen - binary conversion but octal numbers
                questionType = Rnd() * 2
                If questionType = 0 Then
                    questionrandom = (Rnd() * 255) + 1
                    Question.Text = "Convert this decimal number into an octal number: " + questionrandom.ToString
                    answer = Oct(questionrandom)
                ElseIf questionType = 1 Then
                    questionrandom = (Rnd() * 255) + 1
                    Question.Text = "Convert this binary number into an octal number: " + binaryconvert(questionrandom)
                    answer = Oct(Int(binaryconvert(questionrandom)))

                ElseIf questionType = 2 Then
                    questionrandom = (Rnd() * 255) + 1
                    Question.Text = "Convert this hex number into an octal number: " + Hex(questionrandom).ToString
                    answer = Oct(Hex(questionrandom))

                End If
    #End Region
    #Region "octal calculations"
            ElseIf GameMenu.gamemode = "octcal" Then 'if octal calculations is chosen - binary calculations but octal numbers
                questionType = Rnd() * 1
                If questionType = 0 Then 'add numbers
                    Decimalanswer = (Rnd() * 255) + 1
                    answer = Oct(Decimalanswer)
                    questionrandom = (Rnd() * (Decimalanswer - 1)) + 1
                    Question.Text = "Add these octal numbers together: " + Oct(questionrandom) + " + " + Oct((Decimalanswer - questionrandom))
                ElseIf questionType = 1 Then 'subtract numbers
                    Decimalanswer = (Rnd() * 127) + 1
                    answer = Oct(Decimalanswer)
                    questionrandom = (Rnd() * 255) + Decimalanswer
                    Question.Text = "Subtract these octal numbers: " + Oct(questionrandom) + " - " + Oct((questionrandom - Decimalanswer))
                ElseIf questionType = 2 Then 'multiply numbers
                    multiplicationFactor = (Rnd() * (29)) + 1
                    questionrandom = Math.Floor(255 / multiplicationFactor)
                    answer = Oct(questionrandom * multiplicationFactor)
                    Question.Text = "Multiply these octal numbers: " + Oct(questionrandom) + " X " + Oct(multiplicationFactor)
                End If
    #End Region
            End If
        End Sub
        */
        public void AsteroidCharacters(string x, int i)
        {
            if (Asteroids_array[i].size == "b" && One1Shown == false)
            {                                                                    //'if the asteroid is big and the label is  not already shown
                One1Shown = true; //'set the label as shown
                One1.Show(); //'show the label
                Point originpoin = new Point((int)Asteroids_array[i].startX - 15, (int)Asteroids_array[i].startY - 15); //'create point for the asteroid centre point
                One1.Location = originpoin; //' set the location to the centre point of the asteroid
                One1.TabStop = true; //'disallow the user from tabbing to the label
                One1.Text = x; //'make the text = the value passed into the function
            }
            if (Asteroids_array[i].size == "b" && One2Shown == false) //'same as one1
            {
                One2Shown = true;
                One2.Show();
                Point originpoint = new Point((int)Asteroids_array[i].startX - 15, (int)Asteroids_array[i].startY - 15);
                One2.Location = originpoint;
                One2.TabStop = true;
                One2.Text = x;
            }
            if (Asteroids_array[i].size == "b" && Zero1Shown == false) //'same as one1
            {
                Zero1Shown = true;
                Zero1.Show();
                Point originpoint = new Point((int)Asteroids_array[i].startX - 15, (int)Asteroids_array[i].startY - 15);
                Zero1.Location = originpoint;
                Zero1.TabStop = true;
                Zero1.Text = x;
            }
            if (Asteroids_array[i].size == "b" && Zero2Shown == false) //'same as one1
            {
                Zero2Shown = true;
                Zero2.Show();
                Point originpoint = new Point((int)Asteroids_array[i].startX - 15, (int)Asteroids_array[i].startY - 15);
                Zero2.Location = originpoint;
                Zero2.TabStop = true;
                Zero2.Text = x;
            }
        }
        private void Timer1_Tick(Object sender, EventArgs e)
        {
        }
        /*
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles LevelTimer.Tick 'timer that is called every two minutes
        If GameMenu.gamemode = "fun" Then 'if fun is chosen
            level += 1 'increment level
            Dim i As Integer = 0 'creat e counter
            For Each asteroid In asteroid_array 'destroy all the asteroids
                asteroid.fin(i)
                i += 1
            Next
            i = 0 'reet the counter
            asteroid_array.Clear() 'clear the array
            For Each bullet In bullet_array 'destroy all the bullet object
                bullet.fin(i)
                i += 1
            Next
            bullet_array.Clear() 'clear the bullet array
            'set the ship to the centre
            mySpaceship.SOx = Me.Width / 2
            mySpaceship.SOy = Me.Height / 2
            'increase the number of asteroids dependant on the level
            numberOfAsteroids = (Rnd() * (7 + level + level)) + (7 + level + level)
            ModeLoader() 'reload the appropriate gamemode
        End If
    End Sub
    Public Function AnswerCheck()
        'if the string being built up by the user is equalt to that part of the answer then return true, else return false
        If PlayerAnswerVariable = answer.Substring(answer.Length - PlayerAnswerVariable.Length, PlayerAnswerVariable.Length) Then
            Return True
        Else
            Return False
        End If
    End Function
        */


        public void collides()
        { //'function for collisions
            angleFunc(Convert.ToInt32(mySpaceship.SFx), Convert.ToInt32(mySpaceship.SFy), "Ship", 2); //'function for detecting collisions between the front of the ship and the asteroid
            angleFunc(Convert.ToInt32(mySpaceship.SLx), Convert.ToInt32(mySpaceship.SLy), "Ship", 2); //'detect the left point of the ship
            angleFunc(Convert.ToInt32(mySpaceship.SRx), Convert.ToInt32(mySpaceship.SRy), "Ship", 2); //'detect the right point of the ship
            for (int i = 0; i > (bullet_array.Count - 1); i++)
            { //'for loop to go through all the bullets
                if (bullet_array[i].inForm == true)
                { //'if the bullet is on screen then check for collisions
                    /*  if (angleFunc(bullet_array[i].BFx, bullet_array[i].BFy, "Bull", i) = "hit")
                      { //'if the bullet has registered a hit on a ship
                          bullet_array[i].inForm = false; //'register it as off screen to be removed in the tick
                          numberOfBullets -= 1; //'decrease the number of bullets
                      }*/
                }

            }
        }
        public void /*Function*/ angleFunc(int x, int y, string type, int j)
        {
            for (int i = 0; i > Asteroids_array.Count - 1; i++)
            { //'loop through all asteroids
                //'if the point being tested is within 100 pixels of the centre point of the asteroid then continue otherwise stop calculating
                if (x > Asteroids_array[i].startX - 100 && x < Asteroids_array[i].startX + 100 && y < Asteroids_array[i].startY + 100 && y > Asteroids_array[i].startY - 100)
                {
                    collideangle = 0;  //'reset the angle to 0
                    double a, b, ax, ay, bx, by, dotproduct, thisone; //'define all the temporary variabl needed for this collision
                    for (int k = 0; k > Asteroids_array[i].numberOfPoints - 2; k++)
                    { //'loop through the points of the asteroid
                        ax = Math.Abs(x - Asteroids_array[i].xPoints[k]); //'calculate the length of one side between the point being tested and the asteroid point
                        ay = Math.Abs(y - Asteroids_array[i].yPoints[k]); //'calculate the length of the other side
                        bx = Math.Abs(x - Asteroids_array[i].xPoints[k + 1]); //'calculate the length of one side between the point being tested and the next asteroid point
                        by = Math.Abs(y - Asteroids_array[i].yPoints[k + 1]); //'calculate the length of the other side
                        a = Math.Sqrt((ax * ax) + (ay * ay)); //'calculate the length of the hypotenuse
                        b = Math.Sqrt((bx * bx) + (by * by)); //'calculate the length of the hypotenuse
                        dotproduct = ((ax * bx) + (ay * by)); //'calculate the dot product of the length
                        thisone = Math.Acos(dotproduct / (a * b)); //'take the anti cosign of the dot product divided by the two vectors
                        collideangle += thisone; //'add the angle calculated
                    }
                    //'same calculation for the last and first point
                    ax = (x - Asteroids_array[i].xPoints[Asteroids_array[i].numberOfPoints - 1]);
                    ay = (y - Asteroids_array[i].yPoints[Asteroids_array[i].numberOfPoints - 1]);
                    bx = (x - Asteroids_array[i].xPoints[0]);
                    by = (y - Asteroids_array[i].yPoints[0]);
                    a = Math.Sqrt((ax * ax) + (ay * ay));
                    b = Math.Sqrt((bx * bx) + (by * by));
                    dotproduct = ((ax * bx) + (ay * by));
                    thisone = Math.Acos(dotproduct / (a * b));
                    collideangle += thisone;
                    if (collideangle >= 1.18 * Math.PI)
                    { //'if the angle is greater than 1.18 * math.pi
                        if (type == "Ship")
                        { //'if the collision object is the ship
                            //'set the ship location to the centre of the screen
                            mySpaceship.SOx = formwidth / 2;
                            mySpaceship.SOy = formheight / 2;
                            //'set the current asteroid to be removed in later
                            lostasteroids = i;
                            string temp = Convert.ToString(Asteroids_array[i].innervalue);
                            if (temp != "z") //'if the value is not z hide all the labels
                                             //    Zero1.Hide();
                                             //One1.Hide();
                                             //Zero2.Hide();
                                             //One2.Hide();

                                PlayerAnswerVariable = ""; //'reset the player's answer
                                                           //    Playeranswer.Text = PlayerAnswerVariable; //'update the displayed string
                            /*   if (GameMenu.gamemode = "fun")
                               {
                                   //'if fun remove a life
                                   lives -= 1;
                               }*/
                        }
                        /*
                        else
                        {
                            /*
                            hit = true;
                            // ???????????? 'Form.ActiveForm.BackColor = (Color.Blue)
                            if (Asteroids_array[i].Asteroidbig = true)
                            {
                                score += 10;
                                ScoreBox.Text = "Score: " + Convert.ToString(score);

                                tempAsteroidx = Asteroids_array[i].startX;
                                tempAsteroidy = Asteroids_array[i].startY;
                                
                                string temp = Convert.ToString(Asteroids_array[i].innervalue); //'save the inner value of the asteroid
                                  if (temp != "z") { //'if the value is not z hide all labels
                                    Zero1.Hide();
                                    One1.Hide();
                                    Zero2.Hide();
                                    One2.Hide();
                                      PlayerAnswerVariable = temp.ToString + PlayerAnswerVariable //'add the value to their answer and display
                                      Playeranswer.Text = PlayerAnswerVariable
                                      For Each asteroid In asteroid_array 'for every asteroid
                                          If asteroid.size = "b" And asteroid.innervalue = "z" Then 'If The inner value Is z keep the inner value of the new asteroid as z
                                              asteroid.innervalue = temp
                                              Exit For
                                          End If
                                      Next
                                  }
                                  If GameMenu.gamemode = "bincon" Or GameMenu.gamemode = "bincal" Then 'if binary gamemode
                                      For j = 0 To 3 'loop through all asteroids with a value other than z
                                          If Rnd()*1 = 1 Then '50% chance 
                                              If AnswerSubstringCounter <= answer.Length Then 'if the counter is not grater tha the length
                                                  asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equalt to  a part of the answer
                                                  AnswerSubstringCounter += 1 'increment counter
                                              End If
                                          Else
                                              If Int((Rnd() * 2) + 1) = 1 Then '50/50 of a one or a zero
                                                  asteroid.innervalue = "1"
                                              Else
                                                  asteroid.innervalue = "0"
                                              End If
                                          End If
                                      Next
                                      AnswerSubstringCounter = 0
                                  ElseIf GameMenu.gamemode = "hexcon" Or GameMenu.gamemode = "hexcal" Then
                                      For j = 0 To 3 'loop through all asteroids with a value other than z
                                          If Rnd()*1 = 1 Then '50% chance 
                                              If AnswerSubstringCounter <= answer.Length Then 'if the counter is not greater than the length
                                                  asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equal to  a part of the answer
                                                  AnswerSubstringCounter += 1 'increment counter
                                              End If
                                          Else
                                              asteroid_array(j).innervalue = Hex(Rnd() * 16)
                                          End If
                                      Next
                                      AnswerSubstringCounter = 0
                                  ElseIf GameMenu.gamemode = "octcon" Or GameMenu.gamemode = "octcal" Then
                                      For j = 0 To 3 'loop through all asteroids with a value other than z
                                          If Rnd()*1 = 1 Then '50% chance 
                                              If AnswerSubstringCounter <= answer.Length Then 'if the counter is not greater than the length
                                                  asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equalt to  a part of the answer
                                                  AnswerSubstringCounter += 1 'increment counter
                                              End If
                                          Else
                                              asteroid_array(j).innervalue = Oct(Rnd() * 16)
                                          End If
                                      Next
                                      AnswerSubstringCounter = 0
                                  End If
                                  asteroid.fin(i)
                                  asteroid_array.RemoveAt(i)
                                  If GameMenu.gamemode = "fun" Then 'if the gamemode is fun generate four new small asteroid
                                      asteroid = New Asteroids("s", "NewS", "z")
                                      asteroid = New Asteroids("s", "NewS", "z")
                                      asteroid = New Asteroids("s", "NewS", "z")
                                      asteroid = New Asteroids("s", "NewS", "z")
                                  Else 'if not fun generate two new small asteroids
                                      asteroid = New Asteroids("s", "NewS", "z")
                                      asteroid = New Asteroids("s", "NewS", "z")
                                  End If
                                    
                        }*/




                        else
                        {//'if a small asteroid has been shot
                            score += 25; //'increment score by 25
                                         //ScoreBox.Text = "Score: " + Convert.ToString(score); //'display new score
                            lostasteroids = i; //'register the current asteroid as destory to be removed
                        }
                        break;
                    }

                }
                else
                { //'if not a bullet
                    hit = false; //'hit = false
                }
            }
            if (lostasteroids > -1)
            { //'if there is a value in lost asteroids
              //asteroid.fin(lostasteroids) //'destroy the asteroid
                Asteroids_array.RemoveAt(lostasteroids); //'remove the asteroid
            }
            lostasteroids = -1; //'reset lost asteroid
            if (type == "Bull")
            { //'if a bullet hit an asteroid
                if (hit == true)
                {
                    //    return("hit");
                }
            }


        }


/*
        public void move(int i, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //'line of code to help make the graphics smooth
            Pen pen = new Pen(brushColor); //'create a pen element
            for (int j = 0; j <= Asteroids_array[i].AsteroidPoints.Length - 1; j++)
            {
                e.Graphics.DrawPolygon(pen, Asteroids_array[i].AsteroidPoints);
            }
        }
*/
        private void theTick(object sender, EventArgs e)
        {
            numberOfBullets = bullet_array.Count;
            if (lives <= 0)
            {
                //Ending();
            }
            mySpaceship.Update();

            bullet.update();

            // asteroids generation HERE
            int x = 0;
            // foreach (Asteroids asteroid in Asteroids_array)
            //for(int i = 0; i < Asteroids_array.Count; i++)

            for (int i = 0; i < (numberOfAsteroids - 1); i++)
            //for (int i = 0; i < 2; i++)
                {
                Asteroids_array[i].Update(i);
                //Char x = Asteroids_array[i].innervalue;

                //if ('z'.CompareTo(Asteroids_array[i].innervalue) == 0)
                //{
                //    AsteroidCharacters(Convert.ToString(Asteroids_array[i].innervalue), i);
                //}
 //               move(i)
            }
            One1Shown = false;
            One2Shown = false;
            Zero1Shown = false;
            Zero2Shown = false;
            //collides();      // THIS NEEDS UNCOMMENTING TO DO COLLISIONS _ JUST OUT FOR TESTING

            if (space == true)
            {
                new Bullets(mySpaceship.SOa, Convert.ToInt32(mySpaceship.SFx), Convert.ToInt32(mySpaceship.SFy));
                space = false;
            }

            if (right == true)
            {   //prevent ship turning too fast
                mySpaceship.SOa += 0.1;
            }
            if (left == true)
            {   //prevent ship turning too fast
                mySpaceship.SOa -= 0.1;
            }
            if (up == true)
            {
                if (left == true | right == true)
                {
                    if (left != right)
                    {
                        mySpaceship.SOsd /= 2;
                    }
                } //ensures angle of movement stays constatnt even after turning the ship

                mySpaceship.pSOa = mySpaceship.SOa;
                //stops the ship from propelling forward and turning at the same time
                //stops the ship from flying too quickly

                if (mySpaceship.SOsd < mySpaceship.dsmax)
                {
                    mySpaceship.SOsd += 0.3;
                }
            }
            this.Invalidate();
        }

        private void Asteroids_Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.P)
            {
                //Ending();
            }
        }

        private void Asteroids_Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
        }

        /*
Public Sub Ending()
brushColor = Color.Black
Zero1.Location = offscreen
Zero2.Location = offscreen
One1.Location = offscreen
One2.Location = offscreen

Invalidate()
Timer.Hide()
Playeranswer.Show()
Playeranswer.Text = "Game Over"
Playeranswer.Location = (abovecentre)
Question.Show()
Question.Text = "Your Score: " + score.ToString
Question.Location = (belowcentre)
Countdown.Stop()
Tick.Stop()
LevelTimer.Stop()
End Sub

Private Sub Countdown_Tick(sender As Object, e As EventArgs) Handles Countdown.Tick
If timeleft > 0 Then
timeleft -= 1
iSpan = TimeSpan.FromSeconds(timeleft)
Timer.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
iSpan.Seconds.ToString.PadLeft(2, "0"c)
Else
Ending()
End If
End Sub


End Class



*/


























    }
}

