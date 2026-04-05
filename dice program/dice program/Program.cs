using System.Diagnostics.Metrics;
using System.Text;
using System;
using NAudio.Wave;
Console.OutputEncoding = Encoding.UTF8;
int pleasetry;
string checker;
int repeat = 1;
int counter = 0;
double puntuation = 0;
string filePath = "die.mp3";
string filePath1 = "dice.mp3";
string filePath2 = "Música Clásica Relajante para Estudiar y Concentrarse y Memorizar Instrumental Violin.mp3";
string dice1 = @"
           |||||||||||||||||
           ||             ||
           ||             ||
           ||     ⚪      ||
           ||             ||
           ||             ||
           |||||||||||||||||
        ";
//Console.WriteLine(dice1);

string dice2 = @"
           |||||||||||||||||
           ||             ||
           ||  ⚪         ||
           ||             ||
           ||         ⚪  ||
           ||             ||
           |||||||||||||||||
        ";
//Console.WriteLine(dice2);

string dice3 = @"
           |||||||||||||||||
           ||             ||
           ||   ⚪        ||
           ||      ⚪     ||
           ||         ⚪  ||
           ||             ||
           |||||||||||||||||
        ";
//Console.WriteLine(dice3);

string dice4 = @"
           |||||||||||||||||
           ||             ||
           ||  ⚪     ⚪  ||
           ||             ||
           ||  ⚪     ⚪  ||
           ||             ||
           |||||||||||||||||
        ";
//Console.WriteLine(dice4);

string dice5 = @"
           |||||||||||||||||
           ||             ||
           ||  ⚪    ⚪   ||
           ||     ⚪      ||
           ||  ⚪    ⚪   ||
           ||             ||
           |||||||||||||||||
        ";
//Console.WriteLine(dice5);

string dice6 = @"
           |||||||||||||||||
           ||             ||
           ||  ⚪    ⚪   ||
           ||  ⚪    ⚪   ||
           ||  ⚪    ⚪   ||
           ||             ||
           |||||||||||||||||
        ";
//Console.WriteLine(dice6);
WaveOutEvent musicOutput = null;
AudioFileReader musicFile = null;
bool musicPlaying = false;
Console.WriteLine("Launch your die for play");
Console.WriteLine("Oh, and... remember, the higher your score, the more details this program will present :)");
while (repeat > 0)
{
    try
    {
        Console.WriteLine("how many dice do you want to launch? write the number of dice do you want, remember you're just own you 6 dice max");
        pleasetry = Convert.ToInt32(Console.ReadLine());
        /*if(pleasetry is not int)
        {
            break;
        }*/
        while (pleasetry == 1)
        {
            Random random = new Random();
            int randomnumber = random.Next(1, 7);
            //int previouspuntuation = (int)puntuation;
            if (randomnumber == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber == 6)
            {
                puntuation = puntuation + 6;
            }

            else { Console.WriteLine("That number is not valid or has been surpass amount the dice"); }

            if (puntuation >= 6)
            {
                using (var audioFile = new AudioFileReader(filePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            if (puntuation < 9)
            {
                Console.WriteLine("Your first die landed on " + randomnumber);
            }

            else
            {
                if (randomnumber == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber == 6)
                {
                    Console.WriteLine(dice6);
                }
            }
            counter++;
            break;
        }
        while (pleasetry == 2)
        {
            Random random = new Random();
            int randomnumber1 = random.Next(1, 7);
            int randomnumber2 = random.Next(1, 7);
            //int previouspuntuation = (int)puntuation;
            if (randomnumber1 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber1 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber1 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber1 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber1 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber1 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber2 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber2 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber2 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber2 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber2 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber2 == 6)
            {
                puntuation = puntuation + 6;
            }
            else { Console.WriteLine("That number is not valid or has been surpass amount the dice"); }
            if (puntuation >= 12)
            {
                using (var audioFile = new AudioFileReader(filePath1))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            if (puntuation < 15)
            {
                Console.WriteLine("Your first die landed on " + randomnumber1);
                Console.WriteLine("Your second die landed on " + randomnumber2);
            }

            else
            {
                if (randomnumber1 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber1 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber1 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber1 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber1 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber1 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber2 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber2 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber2 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber2 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber2 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber2 == 6)
                {
                    Console.WriteLine(dice6);
                }
            }


            counter++;
            break;
        }
        while (pleasetry == 3)
        {
            Random random = new Random();
            int randomnumber1 = random.Next(1, 7);
            int randomnumber2 = random.Next(1, 7);
            int randomnumber3 = random.Next(1, 7);
            //int previouspuntuation = (int)puntuation;
            if (randomnumber1 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber1 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber1 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber1 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber1 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber1 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber2 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber2 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber2 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber2 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber2 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber2 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber3 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber3 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber3 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber3 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber3 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber3 == 6)
            {
                puntuation = puntuation + 6;
            }
            else { Console.WriteLine("That number is not valid or has been surpass amount the dice"); }
            if (puntuation >= 12)
            {
                using (var audioFile = new AudioFileReader(filePath1))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            if (puntuation < 21)
            {
                Console.WriteLine("Your first die landed on " + randomnumber1);
                Console.WriteLine("Your second die landed on " + randomnumber2);
                Console.WriteLine("Your third die landed on " + randomnumber3);
            }

            else
            {
                if (randomnumber1 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber1 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber1 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber1 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber1 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber1 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber2 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber2 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber2 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber2 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber2 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber2 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
            }
            counter++;
            break;
        }

        while (pleasetry == 4)
        {
            Random random = new Random();
            int randomnumber1 = random.Next(1, 7);
            int randomnumber2 = random.Next(1, 7);
            int randomnumber3 = random.Next(1, 7);
            int randomnumber4 = random.Next(1, 7);
            //int previouspuntuation = (int)puntuation;
            if (randomnumber1 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber1 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber1 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber1 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber1 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber1 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber2 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber2 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber2 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber2 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber2 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber2 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber3 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber3 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber3 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber3 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber3 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber3 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber4 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber4 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber4 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber4 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber4 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber4 == 6)
            {
                puntuation = puntuation + 6;
            }
            else { Console.WriteLine("That number is not valid or has been surpass amount the dice"); }
            if (puntuation >= 12)
            {
                using (var audioFile = new AudioFileReader(filePath1))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            if (puntuation < 27)
            {
                Console.WriteLine("Your first die landed on " + randomnumber1);
                Console.WriteLine("Your second die landed on " + randomnumber2);
                Console.WriteLine("Your third die landed on " + randomnumber3);
                Console.WriteLine("Your fourth die landed on " + randomnumber4);
            }

            else
            {
                if (randomnumber1 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber1 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber1 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber1 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber1 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber1 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber2 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber2 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber2 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber2 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber2 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber2 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber4 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber4 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber4 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber4 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber4 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber4 == 6)
                {
                    Console.WriteLine(dice6);
                }
            }
            counter++;
            break;
        }
        while (pleasetry == 5)
        {
            Random random = new Random();
            int randomnumber1 = random.Next(1, 7);
            int randomnumber2 = random.Next(1, 7);
            int randomnumber3 = random.Next(1, 7);
            int randomnumber4 = random.Next(1, 7);
            int randomnumber5 = random.Next(1, 7);
            //int previouspuntuation = (int)puntuation;
            if (randomnumber1 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber1 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber1 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber1 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber1 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber1 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber2 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber2 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber2 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber2 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber2 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber2 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber3 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber3 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber3 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber3 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber3 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber3 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber4 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber4 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber4 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber4 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber4 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber4 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber5 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber5 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber5 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber5 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber5 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber5 == 6)
            {
                puntuation = puntuation + 6;
            }

            else { Console.WriteLine("That number is not valid or has been surpass amount the dice"); }
            if (puntuation >= 12)
            {
                using (var audioFile = new AudioFileReader(filePath1))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            if (puntuation < 33)
            {
                Console.WriteLine("Your first die landed on " + randomnumber1);
                Console.WriteLine("Your second die landed on " + randomnumber2);
                Console.WriteLine("Your third die landed on " + randomnumber3);
                Console.WriteLine("Your fourth die landed on " + randomnumber4);
                Console.WriteLine("Your fifth die landed on " + randomnumber5);
            }

            else
            {
                if (randomnumber1 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber1 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber1 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber1 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber1 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber1 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber2 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber2 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber2 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber2 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber2 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber2 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber4 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber4 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber4 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber4 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber4 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber4 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber5 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber5 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber5 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber5 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber5 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber5 == 6)
                {
                    Console.WriteLine(dice6);
                }
            }

            counter++;
            break;
        }
        while (pleasetry == 6)
        {
            Random random = new Random();
            int randomnumber1 = random.Next(1, 7);
            int randomnumber2 = random.Next(1, 7);
            int randomnumber3 = random.Next(1, 7);
            int randomnumber4 = random.Next(1, 7);
            int randomnumber5 = random.Next(1, 7);
            int randomnumber6 = random.Next(1, 7);
            //int previouspuntuation = (int)puntuation;
            if (randomnumber1 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber1 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber1 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber1 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber1 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber1 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber2 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber2 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber2 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber2 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber2 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber2 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber3 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber3 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber3 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber3 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber3 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber3 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber4 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber4 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber4 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber4 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber4 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber4 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber5 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber5 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber5 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber5 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber5 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber5 == 6)
            {
                puntuation = puntuation + 6;
            }
            if (randomnumber6 == 1)
            {
                puntuation = puntuation + 1;
            }
            else if (randomnumber6 == 2)
            {
                puntuation = puntuation + 2;
            }
            else if (randomnumber6 == 3)
            {
                puntuation = puntuation + 3;
            }
            else if (randomnumber6 == 4)
            {
                puntuation = puntuation + 4;
            }
            else if (randomnumber6 == 5)
            {
                puntuation = puntuation + 5;
            }
            else if (randomnumber6 == 6)
            {
                puntuation = puntuation + 6;
            }
            else { Console.WriteLine("That number is not valid or has been surpass amount the dice"); }
            if (puntuation >= 12)
            {
                using (var audioFile = new AudioFileReader(filePath1))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            if (puntuation < 39)
            {
                Console.WriteLine("Your first die landed on " + randomnumber1);
                Console.WriteLine("Your second die landed on " + randomnumber2);
                Console.WriteLine("Your third die landed on " + randomnumber3);
                Console.WriteLine("Your fourth die landed on " + randomnumber4);
                Console.WriteLine("Your fifth die landed on " + randomnumber5);
                Console.WriteLine("Your sixth die landed on " + randomnumber6);
            }
            else
            {
                if (randomnumber1 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber1 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber1 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber1 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber1 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber1 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber2 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber2 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber2 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber2 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber2 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber2 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber3 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber3 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber3 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber3 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber3 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber3 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber4 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber4 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber4 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber4 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber4 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber4 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber5 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber5 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber5 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber5 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber5 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber5 == 6)
                {
                    Console.WriteLine(dice6);
                }
                if (randomnumber6 == 1)
                {
                    Console.WriteLine(dice1);
                }
                else if (randomnumber6 == 2)
                {
                    Console.WriteLine(dice2);
                }
                else if (randomnumber6 == 3)
                {
                    Console.WriteLine(dice3);
                }
                else if (randomnumber6 == 4)
                {
                    Console.WriteLine(dice4);
                }
                else if (randomnumber6 == 5)
                {
                    Console.WriteLine(dice5);
                }
                else if (randomnumber6 == 6)
                {
                    Console.WriteLine(dice6);
                }                
            }
            counter++;
            break;

        }
        Console.WriteLine("That's your actual score: " + puntuation);
        if (puntuation >= 72 && !musicPlaying)
        {
            musicFile = new AudioFileReader(filePath2);
            musicOutput = new WaveOutEvent();
            musicOutput.Init(musicFile);
            musicOutput.Play();

            musicPlaying = true;

        }
        if (puntuation >= 72)
        {
            Console.WriteLine("You are listening a generic music classic? sorry, not my bad it is faul a bro... his last name is Feliz >:(");
        }
        Console.WriteLine("do you want to try again? Yes or No");
        checker = Console.ReadLine();
        if (checker == "Yes")
        {
            repeat++;
        }
        else if (checker == "No")
        {
            repeat = 0;
            Console.WriteLine("Thank you for playing");
            break;
        }
        //else { Console.WriteLine("incorrect... whatever it was you meant to put..."); }

    }

    catch { }
}
Console.WriteLine("Press any number or whatever... for finish and exit program");
Console.ReadLine();

//                    Console.WriteLine(dice1); Console.WriteLine(dice2); 