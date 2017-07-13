using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace testasynccall
{
    class Program
    {
        static void Main(string[] args)
        {
            IsValidEmail("gbási2003@yahoo.com");
            methode();
            Console.WriteLine("this methode thread call");
            callmethode();
           
            Console.ReadLine();
        }

        public static bool IsValidEmail(string email)
        {
            bool isValidEmail = false;
            try
            {
                var validEmail = new MailAddress(email);
                isValidEmail = true;
            }
            catch (FormatException ex)
            {
                // The email has not a good format
            }
            return isValidEmail;
        }


        public static  async void methode()
        {

            await Task.Run(new Action(longRun));
            Console.WriteLine("this methode finish");  

        }

        public static void longRun()
        {
            Thread.Sleep(10000);  
            
        }

     public static   async void callmethode()
        {

            await Task.Run(new Action(longRun));
            Console.WriteLine("this callmethode finish");  
        }

    }
}
