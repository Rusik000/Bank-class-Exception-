using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Program
    {
        class BankCard
        {
            public string Bankname { get; set; }
            public string Username { get; set; }
            public string PAN { get; set; }
            public string PIN { get; set; }
            public string CVC { get; set; }
            public DateTime ExpireDate { get; set; }
            public decimal Balans { get; set; }

            public void ShowBankCard()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("=========BankCard==========");
                Console.WriteLine($"Bankname : {Bankname}");
                Console.WriteLine($"Username : {Username}");
                Console.WriteLine($"PAN : {PAN}");
                //Console.WriteLine($"CVC : {CVC}");    //Random oldugunu yoxlamaq ucun
                Console.WriteLine($"ExpireDate : {ExpireDate}");
                Console.ResetColor();
            }



        }

        class Client
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public double Salary { get; set; }
            public BankCard bankcard { get; set; }

            public void ShowClient()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("=========Client==========");
                Console.WriteLine($"Id : {ID}");
                Console.WriteLine($"Name : {Name}");
                Console.WriteLine($"Surname : {Surname} ");
                Console.WriteLine($"Age : {Age} ");
                Console.WriteLine($"Salary : {Salary} ");
                bankcard.ShowBankCard();
                Console.ResetColor();
            }
        }


        class Bank
        {
            public Client[] clients { get; set; }

            public int CountofClients { get; set; } = 0;


            public void AddClient(ref Client client)
            {
                var temp = new Client[++CountofClients];

                if (clients != null)
                {
                    clients.CopyTo(temp, 0);

                }
                temp[temp.Length - 1] = client;

                clients = temp;
            }

            public void ShowClients()
            {
                if (clients != null)
                {

                    foreach (var c in clients)
                    {
                        if (c.bankcard.PAN.Length == 16 && c.bankcard.PIN.Length == 4 && c.bankcard.CVC.Length == 3)
                        {
                            c.ShowClient();
                        }

                        else if (c.bankcard.PAN.Length > 16 || c.bankcard.PAN.Length < 16)
                        {
                            throw new ArgumentOutOfRangeException("PAN code is written outside the boundaries");
                        }

                        else if (c.bankcard.PIN.Length > 4 || c.bankcard.PIN.Length < 4)
                        {
                            throw new ArgumentOutOfRangeException("PIN code is written outside the boundaries");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no Client in Bank");
                }
            }
        }

        static void Main(string[] args)
        {

            DateTime datetime = DateTime.Now;

            Random random = new Random();

            int CVC1 = random.Next(100, 999);
            int CVC2 = random.Next(100, 999);
            int CVC3 = random.Next(100, 999);



            try
            {
            BankCard bankCard1 = new BankCard
            {
                Bankname = "Kapital",
                Username = "Rusik000",
                PAN = "5103071443178187",
                PIN = "1111",
                CVC = CVC1.ToString(),
                ExpireDate = new DateTime(2021, 10, 30),
                Balans = random.Next(1000, 2000),
            };



            BankCard bankCard2 = new BankCard
            {
                Bankname = "Kapital",
                Username = "Kamran000",
                PAN = "5103071443179021",
                PIN = "2222",
                CVC = CVC2.ToString(),
                ExpireDate = new DateTime(2021, 9, 30),
                Balans = random.Next(1000, 2000),
            };


            BankCard bankCard3 = new BankCard
            {
                Bankname = "Kapital",
                Username = "Huseyn000",
                PAN = "5103071443173245",
                PIN = "3333",
                CVC = CVC3.ToString(),
                ExpireDate = new DateTime(2021, 5, 30),
                Balans = random.Next(1000, 2000),
            };

           


            Client clients1 = new Client
            {
                ID = 1,
                Name = "Ruslan",
                Surname = "Mustafayev",
                Age = 21,
                Salary = 1000,
                bankcard = bankCard1
            };


            Client clients2 = new Client
            {
                ID = 2,
                Name = "Kamran",
                Surname = "Aliyev",
                Age = 23,
                Salary = 500,
                bankcard = bankCard2
            };

            Client clients3 = new Client
            {
                ID = 3,
                Name = "Huseyn",
                Surname = "Rustemli",
                Age = 25,
                Salary = 2000,
                bankcard = bankCard3
            };

            Bank bank = new Bank();

            bank.AddClient(ref clients1);
            bank.AddClient(ref clients2);
            bank.AddClient(ref clients3);

            bank.ShowClients();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
