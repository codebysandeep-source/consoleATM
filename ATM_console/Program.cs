using ATM.Modal;
using ATM.Services;
using System;

namespace ATM_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            User user = new User(null);
            user.ConsoleATM();

        }
    }
}
