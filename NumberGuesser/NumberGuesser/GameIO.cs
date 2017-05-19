using System;

namespace NumberGuesser
{
    class GameIO
    {
        private static readonly string[] OATH =
        {
            "�����, %NAME!",
            "�� ��������� �� ��������, ���� %NAME?",
            "%NAME, ��������!"
        };

        public static void WriteResult(int attempts, TimeSpan playedTime)
        {
            Console.WriteLine($"������� �� {attempts} ������� (�� {playedTime}). ����������?");
        }

        public static void WriteNumberIsMore()
        {
            Console.WriteLine("�� ����� ������");
        }

        public static void WriteNumberIsLess()
        {
            Console.WriteLine("�� ����� ������");
        }

        public static void WriteRules(int minNumber, int maxNumber)
        {
            Console.WriteLine($"����� �� ����� ({minNumber}-{maxNumber}).");
        }

        public static string ReadPlayerName()
        {
            WriteInputNameMessage();
            return Console.ReadLine();
        }

        private static void WriteInputNameMessage()
        {
            Console.Write("����� ���: ");
        }

        public static void WriteSwearing(String userName, Random random)
        {
            Console.WriteLine(OATH[random.Next(0, OATH.Length)].Replace("%NAME", userName));
        }

        public static bool ReadYesNo()
        {
            for (;;)
            {
                WriteInputMessage("y/n");
                var input = Console.ReadLine().ToLower();
                if (input.Equals("y"))
                {
                    return true;
                }
                else if (input.Equals("n"))
                {
                    return false;
                }
                else
                {
                    WriteInputError();
                }
            }
        }

        private static void WriteInputError()
        {
            Console.WriteLine("�������� ����.");
        }

        private static void WriteInputMessage(String options = "")
        {
            Console.Write("���� ");
            if (options != "")
            {
                Console.Write($"({options})");
            }
            Console.Write(": ");
        }

        public static int ReadNumber()
        {
            int result = 0;
            bool correctInput = false;
            while (!correctInput)
            {
                WriteInputMessage();
                try
                {
                    result = int.Parse(Console.ReadLine());
                    correctInput = true;
                }
                catch (Exception e)
                {
                    WriteInputError();
                }               
            }                       
            return result;
        }
    }
}