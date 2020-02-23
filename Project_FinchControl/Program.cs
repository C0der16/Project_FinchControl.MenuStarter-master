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
    // Last Modified: 2/22/2020
    //
    // **************************************************

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

                        break;

                    case "d":

                        break;

                    case "e":

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
            bool valid = true;
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
                light = light + 25;
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
            songSpeed = songSpeed * 100;
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
            bool valid = false;
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
