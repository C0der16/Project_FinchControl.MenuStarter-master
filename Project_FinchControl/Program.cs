using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Thurman, Seth
    // Dated Created: 2/17/2020
    // Last Modified: 3/19/2020
    //
    // **************************************************

    public enum Commmand
    {
        none,
        moveforward,
        movebackward,
        stopmotors,
        wait,
        turnright,
        turnleft,
        ledon,
        ledoff,
        soundon,
        soundoff,
        gettemperature,
        lightsensors,
        customturn,
        zigzag,
        done
    }
    

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorderMenu(finchRobot);
                        break;

                    case "d":
                        DisplayAlarmSystemMenu(finchRobot);
                        break;

                    case "e":
                        DisplayUserProgrammingMenu(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            DisplayScreenHeader("Light and Sound");
            Console.CursorVisible = false;

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent by increasing the light and sound");
            DisplayContinuePrompt();
            //  i.
            for (int lightSoundLevel = 0; lightSoundLevel < 765; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel - 510, lightSoundLevel - 255, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 10);
                finchRobot.wait(1);
            }
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            //  ii. & iii.
            bool valid;
            string userInput;
            int lightBlue;
            int lightRed;
            int lightGreen;
            int soundHertz1;
            int soundHertz2;
            int songSpeed;
            // how much blue
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;


                Console.WriteLine("Okay now lets mix some colors. enter the ammount of each color you want starting with blue 0 - 255");
                userInput = Console.ReadLine();

                valid = DisplayValidCheck(userInput, valid);

            } while (!valid);

            lightBlue = Convert.ToInt32(userInput);
            // how much red
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Now type in how much red 0 - 255");
                userInput = Console.ReadLine();


                valid = DisplayValidCheck(userInput, valid);

            } while (!valid);
            lightRed = Convert.ToInt32(userInput);
            // how much green
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Now type in how much green 0 - 255");
                userInput = Console.ReadLine();


                valid = DisplayValidCheck(userInput, valid);

            } while (!valid);
            lightGreen = Convert.ToInt32(userInput);

            Console.WriteLine("And now your color");
            finchRobot.setLED(lightRed, 0, 0);
            finchRobot.wait(1000);

            finchRobot.setLED(lightRed, lightGreen, 0);
            finchRobot.wait(1000);

            finchRobot.setLED(lightRed, lightGreen, lightBlue);
            finchRobot.wait(1000);

            DisplayContinuePrompt();

            DisplayScreenHeader("Light and Sound");
            Console.CursorVisible = false;

            // asking for the first sound
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Now lets test the sound, please type in the pich in Hertz you want the finch to repeat");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out soundHertz1))
                {
                    valid = false;
                    DisplayInvalidResponse();

                }
                else if (soundHertz1 < 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);
            // asking for the second sound
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Now the second sound");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out soundHertz2))
                {
                    valid = false;
                    DisplayInvalidResponse();

                }
                else if (soundHertz2 < 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);



            Console.WriteLine("and now your sounds going back and forth with the light growing brighter every other note");

            DisplayContinuePrompt();
            int light = 0;
            //custom LED color
            for (int number = 0; number < 10; number++)
            {
                light += 25;
                finchRobot.setLED(light, light, light);

                finchRobot.noteOn(soundHertz1);
                finchRobot.wait(1000);

                finchRobot.noteOn(soundHertz2);
                finchRobot.wait(1000);

            }
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            // asking for the speed at which the song will play
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Okay Now I would like to play you a song please type in a number between 1-10 \nthe smaller the number the quicker the song plays");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out songSpeed))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (songSpeed < 0 || songSpeed > 10)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);
            songSpeed *= 100;
            // Music
            DisplaySong(finchRobot, songSpeed);

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *                    Talent Show > Dance                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDance(Finch finchRobot)
        {
            bool valid;
            string userInput;
            int numberOfSquares;
            DisplayScreenHeader("Dance");

            Console.WriteLine("First a little demonstration");


            DisplayContinuePrompt();

            for (int repeat = 0; repeat < 4; repeat++)
            {
                finchRobot.setMotors(100, 100);
                finchRobot.wait(1000);
                DisplayDanceWait(finchRobot);
                finchRobot.setMotors(-100, -100);
                finchRobot.wait(1000);
                DisplayDanceWait(finchRobot);
                finchRobot.setMotors(100, -100);
                finchRobot.wait(800);
            }

            finchRobot.setMotors(0, 0);

            DisplayContinuePrompt();

            // how many squares are going to be made
            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Now many squares do you want the finch robot to make");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out numberOfSquares))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (numberOfSquares < 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            Console.WriteLine("\tMake Room the finch robot is about to do a little square dance, \n\nPlease keep in mind that the cord attached to the finch may disturb the pattern");
            DisplayContinuePrompt();
            // making the squares
            for (int timeMoving = 0; timeMoving < numberOfSquares * 4; ++timeMoving)
            {

                finchRobot.setMotors(100, 100);
                finchRobot.wait(1000);

                DisplayDanceWait(finchRobot);

                finchRobot.setMotors(100, -100);
                finchRobot.wait(800);

                DisplayDanceWait(finchRobot);

            }

            finchRobot.setMotors(0, 0);

            DisplayContinuePrompt();

            int distance;
            const int INCH_PER_MILISECOND = 222;
            int time;

            do
            {
                valid = true;

                DisplayScreenHeader("Light and Sound");
                Console.CursorVisible = false;

                Console.WriteLine("Okay now type in the distance you want the Finch to travel in inches");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out distance))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (distance < 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
            } while (!valid);

            time = distance * INCH_PER_MILISECOND;
            finchRobot.setMotors(100, 100);
            finchRobot.wait(time);

            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *                    Talent Show > Mixing It Up                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayMixingItUp(Finch finchRobot)
        {
            string keyEntered;
            bool exit;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("Now Watch as the finch robot uses Movement, Sound, and Light at the same time");
            DisplayContinuePrompt();


            DisplayScreenHeader("Mixing It Up");
            do
            {
                exit = true;
                DisplayScreenHeader("Mixing It Up");
                Console.WriteLine("Use the W key to move forward, the S key to move backward, the D key to turn Right , and the A key to turn left. \n\nif you wish to end this proggram enter the E key");

                keyEntered = Console.ReadLine().ToLower();


                //
                // process user menu choice
                //
                switch (keyEntered)
                {
                    case "w":
                        finchRobot.setLED(0, 0, 255);
                        finchRobot.setMotors(100, 100);
                        finchRobot.wait(1000);
                        finchRobot.setMotors(0, 0);
                        finchRobot.noteOn(1500);
                        finchRobot.wait(100);
                        DisplayDanceWait(finchRobot);
                        break;

                    case "s":
                        finchRobot.setLED(255, 0, 0);
                        finchRobot.setMotors(-100, -100);
                        finchRobot.wait(1000);
                        finchRobot.setMotors(0, 0);
                        finchRobot.noteOn(1000);
                        finchRobot.wait(100);
                        DisplayDanceWait(finchRobot);
                        break;

                    case "d":
                        finchRobot.setLED(255, 255, 0);
                        finchRobot.setMotors(100, -100);
                        finchRobot.wait(800);
                        finchRobot.setMotors(0, 0);
                        finchRobot.noteOn(1250);
                        finchRobot.wait(100);
                        DisplayDanceWait(finchRobot);
                        break;

                    case "a":
                        finchRobot.setLED(0, 255, 255);
                        finchRobot.setMotors(-100, 100);
                        finchRobot.wait(800);
                        finchRobot.setMotors(0, 0);
                        finchRobot.noteOn(1250);
                        finchRobot.wait(100);
                        DisplayDanceWait(finchRobot);
                        break;

                    case "e":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (exit);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Valid Color Check                         *
        /// *****************************************************************
        /// </summary>
        public static bool DisplayValidCheck(string userInput, bool valid)
        {
            int output;

            if (!int.TryParse(userInput, out output))
            {
                valid = false;
                DisplayInvalidResponse();
            }
            else if (output > 255 || output < 0)
            {
                valid = false;
                DisplayInvalidResponse();
            }
            return valid;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     LightShow Song                            *
        /// *****************************************************************
        /// </summary>
        static void DisplaySong(Finch finchRobot, int Songspeed)
        {
            //Song

            int C = 523;
            int D = 587;
            int E = 659;
            //int F = 698;
            int G = 784;
            int A = 880;
            int B = 988;

            Console.WriteLine("and now how about a song");
            DisplayContinuePrompt();
            //G
            finchRobot.noteOn(G);
            finchRobot.wait(Songspeed);
            //G
            finchRobot.noteOn(G);
            finchRobot.wait(Songspeed);
            //D
            finchRobot.noteOn(D);
            finchRobot.wait(Songspeed);
            //D
            finchRobot.noteOn(D);
            finchRobot.wait(Songspeed);
            //E
            finchRobot.noteOn(E);
            finchRobot.wait(Songspeed);
            //E
            finchRobot.noteOn(E);
            finchRobot.wait(Songspeed);
            //D
            finchRobot.noteOn(D);
            finchRobot.wait(Songspeed + 250);
            //C
            finchRobot.noteOn(C);
            finchRobot.wait(Songspeed);
            //C
            finchRobot.noteOn(C);
            finchRobot.wait(Songspeed);
            //B
            finchRobot.noteOn(B);
            finchRobot.wait(Songspeed);
            //B
            finchRobot.noteOn(B);
            finchRobot.wait(Songspeed);
            //A
            finchRobot.noteOn(A);
            finchRobot.wait(Songspeed);
            //A
            finchRobot.noteOn(A);
            finchRobot.wait(Songspeed);
            //G
            finchRobot.noteOn(G);
            finchRobot.wait(Songspeed + 250);
            for (int number = 0; number < 2; number++)
            {

                //D
                finchRobot.noteOn(D);
                finchRobot.wait(Songspeed);
                //D
                finchRobot.noteOn(D);
                finchRobot.wait(Songspeed);
                //C
                finchRobot.noteOn(C);
                finchRobot.wait(Songspeed);
                //C
                finchRobot.noteOn(C);
                finchRobot.wait(Songspeed);
                //B
                finchRobot.noteOn(B);
                finchRobot.wait(Songspeed);
                //B
                finchRobot.noteOn(B);
                finchRobot.wait(Songspeed);
                //A
                finchRobot.noteOn(A);
                finchRobot.wait(Songspeed + 250);

            }

            //G
            finchRobot.noteOn(G);
            finchRobot.wait(Songspeed);
            //G
            finchRobot.noteOn(G);
            finchRobot.wait(Songspeed);
            //D
            finchRobot.noteOn(D);
            finchRobot.wait(Songspeed);
            //D
            finchRobot.noteOn(D);
            finchRobot.wait(Songspeed);
            //E
            finchRobot.noteOn(E);
            finchRobot.wait(Songspeed);
            //E
            finchRobot.noteOn(E);
            finchRobot.wait(Songspeed);
            //D
            finchRobot.noteOn(D);
            finchRobot.wait(Songspeed);
            //C
            finchRobot.noteOn(C);
            finchRobot.wait(Songspeed);
            //C
            finchRobot.noteOn(C);
            finchRobot.wait(Songspeed);
            //B
            finchRobot.noteOn(B);
            finchRobot.wait(Songspeed);
            //B
            finchRobot.noteOn(B);
            finchRobot.wait(Songspeed);
            //A
            finchRobot.noteOn(A);
            finchRobot.wait(Songspeed);
            //A
            finchRobot.noteOn(A);
            finchRobot.wait(Songspeed);
            //G
            finchRobot.noteOn(G);
            finchRobot.wait(Songspeed + 250);

            finchRobot.noteOff();
        }

        /// <summary>
        /// *****************************************************************
        /// *                       Dance Wait                              *
        /// *****************************************************************
        /// </summary>
        static void DisplayDanceWait(Finch finchRobot)
        {
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);
            finchRobot.wait(1000);
        }

        #endregion

        #region DATA RECORDER
        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayDataRecorderMenu(Finch myfinch)
        {
            int numberOfDataPoints = 0;
            double frequencyOfDataPoints = 0;
            int[] data = null;
            Console.CursorVisible = true;


            Finch finchRobot = new Finch();

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Display Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        frequencyOfDataPoints = DisplayGetFrequencyOfDataPoints();
                        break;

                    case "c":
                        data = DisplayGetData(numberOfDataPoints, frequencyOfDataPoints, finchRobot);
                        break;

                    case "d":
                        DisplayShowDataTable(data, numberOfDataPoints);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }
        /// <summary>
        /// *****************************************************************
        /// *      Data Recorder Menu > Getting number of Data Points       *
        /// *****************************************************************
        /// </summary>
        static int DisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            bool valid;
            string userInput;
            do
            {
                valid = true;

                DisplayScreenHeader("Getting number of data points");

                Console.WriteLine("Please enter the number of data points you would like to record 0 - 100");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out numberOfDataPoints))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                if (numberOfDataPoints < 0 || numberOfDataPoints > 100)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);


            Console.WriteLine("Okay you want {0} data points", numberOfDataPoints);

            DisplayMenuPrompt("Data Recorder");

            return numberOfDataPoints;
        }
        /// <summary>
        /// *****************************************************************
        /// *     Data Recorder Menu > Getting Frequency of Data Points     *
        /// *****************************************************************
        /// </summary>
        static double DisplayGetFrequencyOfDataPoints()
        {
            double output;
            bool valid;
            string userInput;
            do
            {
                valid = true;

                DisplayScreenHeader("Getting Frequency of Data Points");

                Console.WriteLine("Please enter how long you want the robot to wait before collecting the next tempature in seconds 0 - 5");
                userInput = Console.ReadLine();

                if (!double.TryParse(userInput, out output))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                if (output < 0 || output > 5)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            Console.WriteLine("Okay you want {0} as your frequency", output);
            DisplayMenuPrompt("Data Recorder");

            return output;
        }
        /// <summary>
        /// *****************************************************************
        /// *              Data Recorder Menu > Getting Data                *
        /// *****************************************************************
        /// </summary>
        static int[] DisplayGetData(
            int numberOfDataPoints,
            double frequencyOfDataPoints,
            Finch finchRobot)

        {
            int[] light = new int[numberOfDataPoints];
            int[] temperatureCelsius = new int[numberOfDataPoints];
            int[] temperatureFahrenheit = new int[numberOfDataPoints];
            bool valid;
            string userInput;
            string recorder;
            bool tempUnit;
            bool tempsensor = true;
            //
            // What Sensor to use
            //
            do
            {
                valid = true;

                DisplayScreenHeader("Getting Data");

                Console.WriteLine("what Sensor do you want to use, \"Temp\" or \"Light\"");

                userInput = Console.ReadLine().ToLower();

                if (userInput == "temp")
                {
                    valid = true;
                    tempsensor = true;
                    tempUnit = false;
                    recorder = "Temperature";
                }
                else if (userInput == "light")
                {
                    valid = true;
                    tempsensor = false;
                    tempUnit = false;
                    recorder = "Light";
                }
                else
                {
                    valid = false;
                    tempUnit = false;
                    DisplayInvalidResponse();
                    recorder = "";
                }
            } while (!valid);
            //
            // Convert to Fahrenheit?
            //
            if (tempsensor)
            {
                do
                {
                    valid = true;

                    DisplayScreenHeader("Getting Data");

                    Console.WriteLine("Number of data Points: {0}", numberOfDataPoints);
                    Console.WriteLine("Frequency of data Points taken: {0}", frequencyOfDataPoints);
                    Console.WriteLine("");
                    Console.WriteLine("Would you like your values converted to Fahrenheit?");

                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "yes" || userInput == "sure")
                    {
                        valid = true;
                        tempUnit = true;
                    }
                    else if (userInput == "no")
                    {
                        valid = true;
                        tempUnit = false;
                    }
                    else
                    {
                        valid = false;
                        DisplayInvalidResponse();
                    }

                } while (!valid);
            }
            //
            // using light sensor
            //
            else
            {
                DisplayScreenHeader("Getting Data");

                Console.WriteLine("Number of data Points: {0}", numberOfDataPoints);
                Console.WriteLine("Frequency of data Points taken: {0}", frequencyOfDataPoints);
                Console.WriteLine("");
            }


            Console.WriteLine("The Application is now ready to begin recording the {0}", recorder);

            Console.CursorVisible = false;

            finchRobot.connect();

            DisplayContinuePrompt();
            //
            // Recording Data
            //
            for (int x = 0; x < numberOfDataPoints; x++)
            {
                if (!tempsensor)
                {
                    light[x] = finchRobot.getRightLightSensor();
                    int waitTime = (int)(frequencyOfDataPoints * 1000);
                    finchRobot.wait(waitTime);
                    Console.WriteLine("\t{0}.\t\t{1:N2}", x + 1, light[x]);
                }


                if (tempsensor)
                {
                    temperatureCelsius[x] = (int)finchRobot.getTemperature();

                    if (!tempUnit)
                    {
                        int waitTime = (int)(frequencyOfDataPoints * 1000);
                        finchRobot.wait(waitTime);
                        Console.WriteLine("\t{0}.\t\t{1} C", x + 1, temperatureCelsius[x]);
                    }
                    if (tempUnit)
                    {
                        temperatureFahrenheit[x] = ConvertCelsiusToFahrenheit(temperatureCelsius, x);
                        int waitTime = (int)(frequencyOfDataPoints * 1000);
                        finchRobot.wait(waitTime);
                        Console.WriteLine("\t{0}.\t\t{1} F", x + 1, temperatureFahrenheit[x]);
                    }
                }

            }

            DisplayMenuPrompt("Data Recorder");
            if (!tempsensor)
            {
                return light;
            }
            if (!tempUnit)
            {
                return temperatureCelsius;
            }
            else
            {
                return temperatureFahrenheit;
            }
        }
        /// <summary>
        /// *****************************************************************
        /// *              Data Recorder Menu > Showing Data                *
        /// *****************************************************************
        /// </summary>
        static void DisplayShowDataTable(int[] data, int numberOfDataPoints)
        {
            string userInput;
            bool valid;
            bool sort = true;
            //Title
            DisplayScreenHeader("Displaying data");


            Console.WriteLine("\tTest#\t\tSensorInput");
            Console.WriteLine("");

            for (int testNumber = 0; testNumber < numberOfDataPoints; testNumber++)
            {

                Console.WriteLine("\t{0}.\t\t{1}", testNumber + 1, data[testNumber]);
            }

            do
            {
                DisplayContinuePrompt();

                DisplayScreenHeader("Manipulating the Array");
                Console.WriteLine("would you like to sort and get the average of the data?");
                userInput = Console.ReadLine().ToLower();

                if (userInput == "yes" || userInput == "sure")
                {
                    valid = true;
                    sort = true;
                }
                else if (userInput == "no")
                {
                    valid = true;
                    sort = false;
                }
                else
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            if (sort)
            {
                ManipulatingArray(data, numberOfDataPoints);
            }



            DisplayMenuPrompt("Data Recorder");
        }
        /// <summary>
        /// *****************************************************************
        /// *                      Convert C to F                           *
        /// *****************************************************************
        /// </summary>
        static int ConvertCelsiusToFahrenheit(int[] temperatureCelsius, int x)
        {
            double output = temperatureCelsius[x] * 9 / 5 + 32;

            return (int)output;
        }
        /// <summary>
        /// *****************************************************************
        /// *               Show Data > Manipulating Array                  *
        /// *****************************************************************
        /// </summary>
        static void ManipulatingArray(int[] data, int numberOfDataPoints)
        {
            int sum = 0;
            double average;
            Array.Sort(data);
            Array.Reverse(data);

            DisplayScreenHeader("Manipulating the Array");


            Console.WriteLine("This is the Data from largest to smallest value");
            foreach (int value in data)
            {
                Console.WriteLine("\t{0}", value + "");
            }

            DisplayContinuePrompt();

            DisplayScreenHeader("Manipulating the Array");

            Console.WriteLine("Now lets get an average of the data points");

            foreach (int dataPoint in data)
            {
                sum += dataPoint;
            }
            Console.WriteLine("The Sum of all the data points is {0}", sum);

            DisplayContinuePrompt();

            average = sum / numberOfDataPoints;
            Console.WriteLine("");
            Console.WriteLine("And the Average of all of them is {0}", average);


        }


        #endregion

        #region ALARM SYSTEM
        /// <summary>
        /// *****************************************************************
        /// *                     Alarm System Menu                         *
        /// *****************************************************************
        /// </summary>
        static void DisplayAlarmSystemMenu(Finch myfinch)
        {
            string sensor = "";
            string rangeType = "";
            string minOrMax = "";
            int thresholdMax = 256;
            int thresholdMin = -1;
            int timeMonitoring = 0;
            double minMaxTempThreshold = 0;
            bool useTemp = false;


            Console.CursorVisible = true;


            Finch finchRobot = new Finch();

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {


                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range type");
                Console.WriteLine("\tc) Set Maximum, Minimum, or Both threshold values");
                Console.WriteLine("\td) Set Temperature alarm");
                Console.WriteLine("\te) Set Time to monitor");
                Console.WriteLine("\tf) Start Alarm");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensor = DisplaySensorsToMonitor();
                        break;

                    case "b":
                        rangeType = DisplayGetRangeType();
                        break;

                    case "c":
                        (thresholdMax, thresholdMin) = DisplayThreshold(rangeType, finchRobot, sensor);
                        break;

                    case "d":
                        (minMaxTempThreshold, useTemp, minOrMax) = DisplayTemperature(finchRobot);
                        break;

                    case "e":
                        timeMonitoring = DisplayGetMonitorTime();
                        break;

                    case "f":
                        DisplayBeginMonitoring(finchRobot, sensor, thresholdMax, thresholdMin, timeMonitoring, rangeType, minOrMax, minMaxTempThreshold, useTemp);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Light Sensors to Monitor                        *
        /// *****************************************************************
        /// </summary>
        static string DisplaySensorsToMonitor()
        {
            string sensorType;
            bool valid;

            do
            {
                valid = true;

                DisplayScreenHeader("Select Sensor");

                Console.WriteLine("Okay, What sensor(s) do you want to use either \"Left\", \"Right\" or \"Both\"");
                sensorType = Console.ReadLine().ToLower();

                if (sensorType == "left" || sensorType == "right" || sensorType == "both")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            Console.WriteLine("Okay we will use {0} Sensor", sensorType);

            DisplayMenuPrompt("Alarm System");

            return sensorType;
        }
        /// <summary>
        /// *****************************************************************
        /// *                      Getting Light Range Type                       *
        /// *****************************************************************
        /// </summary>
        static string DisplayGetRangeType()
        {
            string userInput;
            bool valid;
            do
            {
                valid = true;
                DisplayScreenHeader("Getting Threshold");

                Console.WriteLine("would you like a min, max or both");
                userInput = Console.ReadLine().ToLower();

                if (userInput == "max" || userInput == "min" || userInput == "both")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            Console.WriteLine("Okay we will use {0} sensor(s)", userInput);

            DisplayContinuePrompt();

            return userInput;
        }
        /// <summary>
        /// *****************************************************************
        /// *                      Getting Light Threshold                        *
        /// *****************************************************************
        /// </summary>
        static (int, int) DisplayThreshold(string rangeType, Finch finchRobot, string sensor)
        {

            int thresholdMax = 256;
            int thresholdMin = -1;

            if (rangeType == "max")
            {
                thresholdMax = DisplayGetThresholdMax(finchRobot, sensor);
                thresholdMin = -1;
            }
            else if (rangeType == "min")
            {
                thresholdMax = 256;
                thresholdMin = DisplayGetThresholdMin(thresholdMax, finchRobot, sensor);
            }
            else if (rangeType == "both")
            {
                thresholdMax = DisplayGetThresholdMax(finchRobot, sensor);
                thresholdMin = DisplayGetThresholdMin(thresholdMax, finchRobot, sensor);
            }

            DisplayMenuPrompt("Alarm System");


            return (thresholdMax, thresholdMin);
        }

        ///get maximum value
        static int DisplayGetThresholdMax(Finch finchRobot, string sensor)
        {
            int currentLeftLight;
            int currentRightLight;
            int maxThreshold;
            string userInput;
            bool valid;

            do
            {
                valid = true;

                DisplayScreenHeader("Getting Threshold");

                currentLeftLight = DisplayAmbientLightLeft(finchRobot);
                currentRightLight = DisplayAmbientLightRight(finchRobot);

                if (sensor == "left" || sensor == "both")
                {
                    Console.WriteLine("Current Left Light Sensor value: {0}", currentLeftLight);
                }
                if (sensor == "right" || sensor == "both")
                {
                    Console.WriteLine("Current Right Light Sensor value: {0}", currentRightLight);
                }


                Console.WriteLine("okay now enter the maximum integer (0 - 255) you want the alarm to go off at");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out maxThreshold))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (maxThreshold < 0 || maxThreshold > 255)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);


            Console.WriteLine("Okay we will use {0} as your maximum", maxThreshold);


            return maxThreshold;

        }
        ///get minimum value
        static int DisplayGetThresholdMin(int maxThreshold, Finch finchRobot, string sensor)
        {
            int currentLeftLight;
            int currentRightLight;
            int minThreshold;
            string userInput;
            bool valid;

            do
            {
                valid = true;

                DisplayScreenHeader("Getting number of data points");

                currentLeftLight = DisplayAmbientLightLeft(finchRobot);
                currentRightLight = DisplayAmbientLightRight(finchRobot);

                if (sensor == "left" || sensor == "both")
                {
                    Console.WriteLine("Current Left Light Sensor value: {0}", currentLeftLight);
                }
                if (sensor == "right" || sensor == "both")
                {
                    Console.WriteLine("Current Right Light Sensor value: {0}", currentRightLight);
                }

                Console.WriteLine("okay now enter the minimum integer (0 - 255) you want the alarm to go off at");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out minThreshold))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (minThreshold < 0 || minThreshold >= maxThreshold)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
            } while (!valid);


            Console.WriteLine("Okay we will use {0} as your minimum", minThreshold);


            return minThreshold;

        }

        ///getting abmient Light Levels
        static int DisplayAmbientLightLeft(Finch finchRobot)
        {
            int leftSensor;
            finchRobot.connect();

            leftSensor = finchRobot.getLeftLightSensor();


            return leftSensor;
        }
        static int DisplayAmbientLightRight(Finch finchRobot)
        {
            int rightSensor;
            finchRobot.connect();

            rightSensor = finchRobot.getRightLightSensor();


            return rightSensor;

        }

        /// <summary>
        /// *****************************************************************
        /// *                         Temperature                           *
        /// *****************************************************************
        /// </summary>
        
        static (double, bool, string) DisplayTemperature(Finch finchRobot)
        {
            bool useTemp = false;
            bool valid;
            string minOrMax = "";
            string userInput;
            double tempThreshold = 0;

            do
            {
                valid = true;

                DisplayScreenHeader("Temperature");

                Console.WriteLine("Would you also like to monitor the temperature");
                userInput = Console.ReadLine().ToLower();

                if (userInput == "yes" || userInput == "sure")
                {
                    useTemp = true;
                    valid = true;
                }
                else if (userInput == "no")
                {
                    useTemp = false;
                    valid = true;
                }
                else
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            if (useTemp == true)
            {

                minOrMax = DisplayGetTempMaxOrMin();
                tempThreshold = DisplayGetTempThreshold(finchRobot);

            }

            return (tempThreshold, useTemp, minOrMax);
        }
        static string DisplayGetTempMaxOrMin()
        {
            bool valid = true;
            string userInput;
            string minOrMax = "";


            do
            {
                valid = true;

                DisplayScreenHeader("Getting Min or Max");

                Console.WriteLine("Would you like a \"maximum\" or \"minimum\" threshold");
                userInput = Console.ReadLine().ToLower();

                if (userInput == "maximum")
                {
                    minOrMax = "max";
                }
                else if (userInput == "minimum")
                {
                    minOrMax = "min";
                }
                else
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            return minOrMax;
        }

        static double DisplayGetTempThreshold(Finch finchRobot)
        {
            double currentTemp;
            double tempThreshold;
            string userInput;
            bool valid;
            do
            {
                valid = true;

                DisplayScreenHeader("Temperature Threshold");

                finchRobot.connect();

                currentTemp = finchRobot.getTemperature();

                Console.WriteLine("The Current Temp in Celsius is {0:N2}", currentTemp);

                Console.WriteLine("okay now enter the temperature you want the alarm to go off at");
                userInput = Console.ReadLine();

                if (!double.TryParse(userInput, out tempThreshold))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                if (tempThreshold < 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            return tempThreshold;
        }
        /// <summary>
        /// *****************************************************************
        /// *                  Length of time to Monitor                    *
        /// *****************************************************************
        /// </summary>
        static int DisplayGetMonitorTime()
        {
            int monitorTime;
            bool valid;
            string userInput;

            do
            {
                valid = true;

                DisplayScreenHeader("Length of Time to Monitor");

                Console.WriteLine("Okay Now how long do you want to monitor the light in seconds");
                userInput = Console.ReadLine();


                if (!int.TryParse(userInput, out monitorTime))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (monitorTime < 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            Console.WriteLine("Okay we will monitor the light for {0} seconds", monitorTime);

            DisplayMenuPrompt("Alarm System");

            return monitorTime;
        }

        /// <summary>
        /// *****************************************************************
        /// *                       Begin Monitoring                        *
        /// *****************************************************************
        /// </summary>
        static void DisplayBeginMonitoring(Finch finchRobot, 
            string sensor, 
            int thresholdMax, 
            int thresholdMin, 
            int timeMonitoring, 
            string rangeType, 
            string minOrMax, 
            double minMaxTempThreshold, 
            bool useTemp)
        {
            bool doNotAlert;
            double time = 0.00;
            int valueSensedLeft = 0;
            int valueSensedRight = 0;
            double temperatureValueSensed = 0;

            // Replay Information
            DisplayScreenHeader("Begin Monitoring");

            if (rangeType == "max" || rangeType == "both")
            {
                Console.WriteLine("Light Max: {0}", thresholdMax);
            }

            if (rangeType == "min" || rangeType == "both")
            {
                Console.WriteLine("Light Min: {0}", thresholdMin);
            }

            if (useTemp == true)
            {
                Console.WriteLine("Temperature {0}: {1}", minOrMax, minMaxTempThreshold);
            }

            Console.WriteLine("Length of alarm {0}", timeMonitoring);
            Console.WriteLine("\n\nany sensor that you chose that goes above or below maximum or minimum will set the alarm off");
            DisplayContinuePrompt();


            // Begin Monitoring
            do
            {
                doNotAlert = true;

                finchRobot.connect();

                finchRobot.setLED(0, 255, 0);

                // Replay Information
                DisplayScreenHeader("Begin Monitoring");

                if (rangeType == "max" || rangeType == "both")
                {
                    Console.WriteLine("Light Max: {0}", thresholdMax);
                }

                if (rangeType == "min" || rangeType == "both")
                {
                    Console.WriteLine("Light Min: {0}", thresholdMin);
                }

                if (useTemp == true)
                {
                    Console.WriteLine("Temperature {0:N2}: {1}", minOrMax, minMaxTempThreshold);
                }
                Console.WriteLine("Length of alarm {0}", timeMonitoring);


                time = time + 0.1;

                Console.WriteLine("\nTime Passed: {0:N1}", time);


                if (sensor == "left" || sensor == "both")
                {
                    valueSensedLeft = finchRobot.getLeftLightSensor();
                    Console.WriteLine("Current Left Light Sensed: {0}", valueSensedLeft);

                    if (valueSensedLeft <= thresholdMin
                        || valueSensedLeft >= thresholdMax)
                    {
                        doNotAlert = false;
                    }
                }
                if (sensor == "right" || sensor == "both")
                {
                    valueSensedRight = finchRobot.getRightLightSensor();
                    Console.WriteLine("Current Right Light Sensed: {0}", valueSensedRight);

                    if (valueSensedRight <= thresholdMin
                        || valueSensedRight >= thresholdMax)
                    {
                        doNotAlert = false;
                    }
                }
                if (useTemp == true)
                {
                    temperatureValueSensed = finchRobot.getTemperature();
                    Console.WriteLine("Current Temperature Sensed: {0:N2}", temperatureValueSensed);

                    if (minOrMax == "min" && temperatureValueSensed <= minMaxTempThreshold || minOrMax == "max" && temperatureValueSensed >= minMaxTempThreshold)
                    {
                        doNotAlert = false;
                    }
                }
                else
                {
                    Console.WriteLine("I am sorry but it seems you have not entered enough information \nplease return to the menu and enter any missed information");
                    doNotAlert = false;
                }

                finchRobot.wait(100);

                if (time >= timeMonitoring)
                {
                    doNotAlert = false;
                }


            } while (doNotAlert);

            // Responses
            if (time >= timeMonitoring)
            {
                Console.WriteLine("\t ____________________________________________ ");
                Console.WriteLine("\t|                                            |");
                Console.WriteLine("\t|           Alarm Did not Go Off             |");
                Console.WriteLine("\t|           Limit was not broken             |");
                Console.WriteLine("\t|             Situation Normal               |");
                Console.WriteLine("\t|____________________________________________|");

                finchRobot.setLED(0, 0, 255);

                DisplayContinuePrompt();
                finchRobot.setLED(0, 0, 0);
            }
            else
            {
                Console.WriteLine("\t ____________________________________________ ");
                Console.WriteLine("\t|                                            |");
                Console.WriteLine("\t|            WARNING!! WARNING!!             |");
                Console.WriteLine("\t|           LIMIT HAS BEEN BROKEN            |");
                Console.WriteLine("\t|____________________________________________|");

                for (int x = 0; x < 5; ++x)
                {
                    finchRobot.setLED(255, 0, 0);
                    finchRobot.noteOn(700);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                    finchRobot.setLED(0, 0, 0);
                    finchRobot.wait(500);
                }

                DisplayContinuePrompt();
            }


        }
        #endregion

        #region USER PROGRAMMING
        /// <summary>
        /// *****************************************************************
        /// *                     User Programming Menu                     *
        /// *****************************************************************
        /// </summary>
        static void DisplayUserProgrammingMenu(Finch finchRobot)
        {

            (int motorSpeed, int ledBrightness, double waitSeconds, int soundFrequency) commandParameters;

            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            commandParameters.soundFrequency = 0;

            int customTurnTime = 0;
            string customTurnDirection = "";

            List<Commmand> commands = new List<Commmand>();


            Console.CursorVisible = true;


            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {


                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = DisplayGetCommandParameters();
                        break;

                    case "b":
                        (customTurnTime, customTurnDirection) = DisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        DisplayDisplayingCommands(commands);
                        break;

                    case "d":
                        DisplayExecutingCommands(commands, commandParameters, finchRobot, customTurnTime, customTurnDirection);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);


        }
        /// <summary>
        /// *****************************************************************
        /// *         User Programming > Getting Command Parameters         *
        /// *****************************************************************
        /// </summary>
        static (int, int, double, int) DisplayGetCommandParameters ()
        {

            (int motorSpeed, int ledBrightness, double waitSeconds, int soundFrequency) commandParameters;

            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            commandParameters.soundFrequency = 0;

            DisplayScreenHeader("Getting Command Parameters");

            commandParameters.motorSpeed = DisplayGetMotorSpeed();
            commandParameters.ledBrightness = DisplayGetLedBrightness();
            commandParameters.waitSeconds = DisplayGetWaitSeconds();
            commandParameters.soundFrequency = DisplayGetSoundFrequency();

            DisplayScreenHeader("Your Values");

            Console.WriteLine("Motor speed is {0}", commandParameters.motorSpeed);
            Console.WriteLine("LED brightness is {0}", commandParameters.ledBrightness);
            Console.WriteLine("Wait Time is {0} seconds", commandParameters.waitSeconds);
            Console.WriteLine("Frequency of Sound is {0}", commandParameters.soundFrequency);

            DisplayMenuPrompt("User Programming");

            return (commandParameters);

        }
        /// Getting Motor Speed 
        static int DisplayGetMotorSpeed ()
        {
            string userInput;
            int motorSpeed;
            bool valid;
            do
            {
                valid = true;
                DisplayScreenHeader("Getting motor Speed");

                Console.WriteLine("Please select a motor speed (0 - 255)");
                userInput = Console.ReadLine().ToLower();

                if (!int.TryParse(userInput, out motorSpeed))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (motorSpeed < 0 || motorSpeed > 255)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            return motorSpeed;
        }
        /// Getting LED Brightness
        static int DisplayGetLedBrightness()
        {
            string userInput;
            int ledBrightness;
            bool valid;
            do
            {
                valid = true;
                DisplayScreenHeader("Getting Led Brightness");

                Console.WriteLine("Please select a light intensity (0 - 255)");
                userInput = Console.ReadLine().ToLower();

                if (!int.TryParse(userInput, out ledBrightness))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (ledBrightness < 0 || ledBrightness > 255)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            return ledBrightness;
        }
        /// Getting Wait Time
        static double DisplayGetWaitSeconds()
        {
            string userInput;
            double waitSeconds;
            bool valid;
            do
            {
                valid = true;
                DisplayScreenHeader("Getting Wait Time");

                Console.WriteLine("Please enter wait time in seconds");
                userInput = Console.ReadLine().ToLower();

                if (!double.TryParse(userInput, out waitSeconds))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (waitSeconds <= 0)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            return waitSeconds;
        }
        /// Getting Sound Frequency
        static int DisplayGetSoundFrequency()
        {
            string userInput;
            int ledBrightness;
            bool valid;
            do
            {
                valid = true;
                DisplayScreenHeader("Getting Sound Frequency");

                Console.WriteLine("Please enter the number of Hertz you want the sound to be at (20 - 20000)");
                userInput = Console.ReadLine().ToLower();

                if (!int.TryParse(userInput, out ledBrightness))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                else if (ledBrightness < 20 || ledBrightness > 20000)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

            } while (!valid);

            return ledBrightness;
        }

        /// <summary>
        /// *****************************************************************
        /// *           User Programming > Getting Finch Commands           *
        /// *****************************************************************
        /// </summary>
        static (int, string) DisplayGetFinchCommands(List<Commmand> commands)
        {
            int turnTime = 0;
            string turnDirection = "";

            Commmand command = Commmand.none;

            DisplayScreenHeader("Getting Commands");



            int commandCount = 1;

            Console.WriteLine("List of Possible Commands");
            Console.Write("\n\t-");

            // displaying possible commands
            foreach (string commandName in Enum.GetNames(typeof(Commmand)))
            {
                Console.Write("-{0}-", commandName);
                
                if (commandCount % 5 == 0)
                {
                    Console.Write("-\n\t-");
                }
                commandCount++;
            }

            //Collecting Commands
            while (command != Commmand.done)
            {
                Console.WriteLine("\nPlease enter commands from the command list.");

                if (Enum.TryParse(Console.ReadLine().ToLower(), out command))
                {

                    if (command == Commmand.customturn)
                    {
                        (turnTime, turnDirection) = DisplayCustomTurn();
                    }

                    commands.Add(command);
                    
                }
                else
                {
                    Console.WriteLine("_________________________________________________________________________________________");
                    Console.WriteLine("|                                                                                        |");
                    Console.WriteLine("| Sorry but the command you typed does not seem to be on the list of possible commands   |");
                    Console.WriteLine("|                                  Please try again                                      |");
                    Console.WriteLine("|________________________________________________________________________________________|");
                }

            }

            DisplayMenuPrompt("User Programming");


            return (turnTime, turnDirection);
        }


        /// if command is Custom Turn
        static (int, string) DisplayCustomTurn()
        {
            int time;
            int timeTurning;
            string userInput;
            string turnDirection;
            bool valid;

            do
            {
                valid = true;

                Console.WriteLine("Which direction do you want to turn \"Left\" or \"Right\"");
                turnDirection = Console.ReadLine().ToLower();

                if (turnDirection == "left" || turnDirection == "right")
                {
                    valid = true;
                }
                else
                {
                    DisplayInvalidResponse();
                    valid = false;
                }

            } while (!valid);

            do
            {
                valid = true;

                Console.WriteLine("How long do you want the finch robot to turn in seconds");
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out time))
                {
                    valid = false;
                    DisplayInvalidResponse();
                }
                if (time < 0 || time > 50)
                {
                    valid = false;
                    DisplayInvalidResponse();
                }

                timeTurning = 1000 * time;

            } while (!valid);

            return (timeTurning, turnDirection);
        }

        /// <summary>
        /// *****************************************************************
        /// *            User Programming > Displaying Commands             *
        /// *****************************************************************
        /// </summary>
        static void DisplayDisplayingCommands (List<Commmand> commands)
        {

            
            DisplayScreenHeader("Getting Commands");


            foreach (Commmand command in commands)
            {
                Console.Write("- {0}\n", command);
            }

            DisplayMenuPrompt("User Programming");
        
        }

        /// <summary>
        /// *****************************************************************
        /// *             User Programming > Executing Commands             *
        /// *****************************************************************
        /// </summary>
        static void DisplayExecutingCommands(
            List<Commmand> commands, 
            (int motorSpeed, int ledBrightness, double waitSeconds, int soundFrequency) commandParameters,
            Finch finchRobot,
            int customTurnTime,
            string customTurnDirection)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitSeconds = (int)commandParameters.waitSeconds * 1000;
            int soundFrequency = commandParameters.soundFrequency;
            string commandFeedback = "";
            const int TURNING_SPEED = 100;


            DisplayScreenHeader("Executing Commands");

            Console.WriteLine("The Finch robot is now ready to execute your list of commands");
            DisplayContinuePrompt();

            foreach (Commmand command in commands)
            {
                switch (command)
                {
                    case Commmand.none:
                        break;

                    case Commmand.moveforward:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Commmand.moveforward.ToString();
                        break;

                    case Commmand.movebackward:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Commmand.movebackward.ToString();
                        break;

                    case Commmand.stopmotors:
                        finchRobot.setMotors(0, 0);
                        commandFeedback = Commmand.stopmotors.ToString();
                        break;

                    case Commmand.wait:
                        finchRobot.wait(waitSeconds);
                        commandFeedback = Commmand.wait.ToString();
                        break;

                    case Commmand.turnright:
                        finchRobot.setMotors(-TURNING_SPEED, TURNING_SPEED);
                        commandFeedback = Commmand.turnright.ToString();
                        break;

                    case Commmand.turnleft:
                        finchRobot.setMotors(TURNING_SPEED, -TURNING_SPEED);
                        commandFeedback = Commmand.turnleft.ToString();
                        break;

                    case Commmand.ledon:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Commmand.ledon.ToString();
                        break;

                    case Commmand.ledoff:
                        finchRobot.setLED(0, 0, 0);
                        commandFeedback = Commmand.ledoff.ToString();
                        break;

                    case Commmand.soundon:
                        finchRobot.noteOn(soundFrequency);
                        commandFeedback = Commmand.soundon.ToString();
                        break;

                    case Commmand.soundoff:
                        finchRobot.noteOff();
                        commandFeedback = Commmand.soundoff.ToString();
                        break; 

                    case Commmand.gettemperature:
                        commandFeedback = $"Temperature is {finchRobot.getTemperature().ToString("n2")} degrees Celsius";
                        break;

                    case Commmand.lightsensors:

                        DisplayLightSensors(finchRobot);
                        break;

                    case Commmand.customturn:

                        DisplayUseCustomTurn(finchRobot, motorSpeed, customTurnDirection, customTurnTime);

                        commandFeedback = Commmand.customturn.ToString();
                        break;
                    
                    case Commmand.zigzag:

                        DisplayZigZag(finchRobot, soundFrequency, ledBrightness);

                        commandFeedback = Commmand.zigzag.ToString();
                        break;

                    case Commmand.done:
                        commandFeedback = Commmand.done.ToString();
                        break;

                }

                Console.WriteLine("{0}", commandFeedback);
            }

            DisplayMenuPrompt("User Programming");

        }

        /// Custom Turn
        static void DisplayUseCustomTurn(
            Finch finchRobot,
            int motorSpeed,
            string customTurnDirection, 
            int customTurnTime)
        {

            if (customTurnDirection == "left")
            {
                finchRobot.setMotors(-motorSpeed, motorSpeed);
            }
            if (customTurnDirection == "right")
            {
                finchRobot.setMotors(motorSpeed, -motorSpeed);
            }
            finchRobot.wait(customTurnTime);

            finchRobot.setMotors(0, 0);

        }

        /// Zig-Zag
        static void DisplayZigZag(Finch finchRobot, int soundFrequency, int ledBrightness)
        {
            finchRobot.setMotors(100, -100);
            finchRobot.noteOn(soundFrequency);
            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
            finchRobot.wait(450);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);

            finchRobot.setMotors(100, 100);
            finchRobot.noteOn(soundFrequency);
            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);

            finchRobot.setMotors(-100, 100);
            finchRobot.noteOn(soundFrequency);
            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
            finchRobot.wait(900);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);

            finchRobot.setMotors(100, 100);
            finchRobot.noteOn(soundFrequency);
            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
            finchRobot.wait(2000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);

            finchRobot.setMotors(100, -100);
            finchRobot.noteOn(soundFrequency);
            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
            finchRobot.wait(900);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.wait(100);

            finchRobot.setMotors(100, 100);
            finchRobot.noteOn(soundFrequency);
            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);
        }

        /// Light Sensors
        static void DisplayLightSensors(Finch finchRobot)
        {
            int leftLightSensor;
            int rightLightSensor;
            double averageLight;

            leftLightSensor = finchRobot.getLeftLightSensor();

            rightLightSensor = finchRobot.getRightLightSensor();

            Console.WriteLine("Right Light Sensor: {0}  \nLeft Light Sensor: {1}", leftLightSensor, rightLightSensor);

            averageLight = (leftLightSensor + rightLightSensor) / 2;

            Console.WriteLine("\n\n\t\tAverage Light: {0}", averageLight);

        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        
        }
        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                  Invalid Reponse Message                      *
        /// *****************************************************************
        /// </summary>
        static void DisplayInvalidResponse()
        {
            Console.WriteLine("I am sorry but it seems that you have not given a valid answer");
            Console.WriteLine("");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
