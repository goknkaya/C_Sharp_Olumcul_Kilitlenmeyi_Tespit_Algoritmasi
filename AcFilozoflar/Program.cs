using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcFilozoflar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] max = new int[3];
            int[] allocation = new int[3];
            int[] need = new int[3];
            int i, p0, p1, p2;

            Console.Write("Press an instance value: ");
            int instance = Convert.ToInt32(Console.ReadLine()); //Bellek için ayrılacak örnek alan


            Console.WriteLine("\n///////////////////////////////////////////////////////////\n");

            for (i = 0; i < 3; i++)
            {
                Console.Write("Press a Max value for P{0}: ", i);
                max[i] = Convert.ToInt32(Console.ReadLine()); //Proseslerin alacağı maksimum değer
                Console.Write("Press an Allocation value for P{0}: ", i);
                allocation[i] = Convert.ToInt32(Console.ReadLine()); //Proseslerin tahsis ettiği hali hazırdaki durum
                need[i] = max[i] - allocation[i];
            }

            Console.WriteLine("\n///////////////////////////////////////////////////////////\n");

            Console.WriteLine("Need Matris:\n");

            for (i = 0; i < 3; i++)
            {
                Console.WriteLine("P{0}: {1}", i, need[i]); //Max - Allocation = Need
            }

            i = 0;
            p0 = need[i];
            p1 = need[i + 1];
            p2 = need[i + 2];


            Console.WriteLine("\n///////////////////////////////////////////////////////////\n");

            if (p0 > instance || p1 > instance || p2 > instance) //Dining Philosophers Problem' deki mantığı burada kullanmaya çalıştık. Filozof sayısı çatal sayısından büyük olursa her türlü deadlock oluşur. Deadlock oluşmaması için en az çatal sayısının filozof sayısına eşit olması gerekir. Yani n proses varsa en az n kaynağımız olmalı ki Deadlock oluşmasın.
            {
                Console.WriteLine("Deadlock");
            }
            else
            {
                Console.WriteLine("No Deadlock");
                Console.WriteLine("\n///////////////////////////////////////////////////////////\n");
                sjf(p0, p1, p2);
            }

            Console.ReadKey();
        }

        public static void sjf(int p0, int p1, int p2) //Proseslerin herbirini sjf (Shortest-Job-First) metotuna gönderdik ve metotun içinde Need Matrislerini küçükten büyüğe sıraladık. Küçükten büyüğe sıralanan prosesler zamanlama dizisine aktarıldı ve küçükten büyüğe toplanarak eklenmiş oldu.
        {
            int[] schedulingChart = new int[3];
            int i;
            double averageWT;

            if (p0 < p1 && p0 < p2)
            {
                if (p1 < p2)
                {
                    Console.WriteLine("P0<P1<P2");
                    schedulingChart[0] = p0;
                    schedulingChart[1] = p0 + p1;
                    schedulingChart[2] = p0 + p1 + p2;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
                else if (p2 < p1)
                {
                    Console.WriteLine("P0<P2<P1");
                    schedulingChart[0] = p0;
                    schedulingChart[1] = p0 + p2;
                    schedulingChart[2] = p0 + p2 + p1;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
                else
                {
                    Console.WriteLine("P0<P1=P2");
                    schedulingChart[0] = p0;
                    schedulingChart[1] = p0 + p1;
                    schedulingChart[2] = p0 + p1 + p2;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
            }
            if (p1 < p0 && p1 < p2)
            {
                if (p0 < p2)
                {
                    Console.WriteLine("P1<P0<P2");
                    schedulingChart[0] = p1;
                    schedulingChart[1] = p1 + p0;
                    schedulingChart[2] = p1 + p0 + p2;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
                else if (p2 < p0)
                {
                    Console.WriteLine("P1<P2<P0");
                    schedulingChart[0] = p1;
                    schedulingChart[1] = p1 + p2;
                    schedulingChart[2] = p1 + p2 + p0;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
                else
                {
                    Console.WriteLine("P1<P0=P2");
                    schedulingChart[0] = p1;
                    schedulingChart[1] = p1 + p0;
                    schedulingChart[2] = p1 + p0 + p2;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
            }
            if (p2 < p0 && p2 < p1)
            {
                if (p0 < p1)
                {
                    Console.WriteLine("P2<P0<P1");
                    schedulingChart[0] = p2;
                    schedulingChart[1] = p2 + p0;
                    schedulingChart[2] = p2 + p0 + p1;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
                else if (p1 < p0)
                {
                    Console.WriteLine("P2<P1<P0");
                    schedulingChart[0] = p2;
                    schedulingChart[1] = p2 + p1;
                    schedulingChart[2] = p2 + p1 + p0;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
                else
                {
                    Console.WriteLine("P2<P0=P1");
                    schedulingChart[0] = p2;
                    schedulingChart[1] = p2 + p0;
                    schedulingChart[2] = p2 + p0 + p1;
                    for (i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                    }
                }
            }
            if (p0==p1 && p0==p2 && p1==p2)
            {
                Console.WriteLine("P0=P1=P2");
                schedulingChart[0] = p0;
                schedulingChart[1] = p0 + p1;
                schedulingChart[2] = p0 + p1 + p2;
                for (i = 0; i < 3; i++)
                {
                    Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                }
            }
           
            if (p0==p1 && p2>p1)
            {
                Console.WriteLine("P0=P1<P2");
                schedulingChart[0] = p0;
                schedulingChart[1] = p0 + p1;
                schedulingChart[2] = p0 + p1 + p2;
                for (i = 0; i < 3; i++)
                {
                    Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                }
            }
            if (p0==p2 && p1>p2)
            {
                Console.WriteLine("P0=P2<P1");
                schedulingChart[0] = p0;
                schedulingChart[1] = p0 + p2;
                schedulingChart[2] = p0 + p2 + p1;
                for (i = 0; i < 3; i++)
                {
                    Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                }
            }
            if (p1==p2 && p0>p2)
            {
                Console.WriteLine("P1=P2<P0");
                schedulingChart[0] = p1;
                schedulingChart[1] = p1 + p2;
                schedulingChart[2] = p1 + p2 + p0;
                for (i = 0; i < 3; i++)
                {
                    Console.WriteLine("Execute Time of P{0}: {1}", i, schedulingChart[i]);
                }
            }

            averageWT = (0 + schedulingChart[0] + schedulingChart[1]) / 3;
            Console.WriteLine("Average Waiting Time: ( 0 + {0} + {1} ) / 3 = {2}", schedulingChart[0],schedulingChart[1],averageWT);
        }
    }
}

//Gökhan KAYA - s191210184
//Hami KUMBASAR - s191210355
//Esin Çağla KIRAL - s191210167
//Emrullah ŞEKERCİ - g191210506
//Nezih ÖNAL - s191210077