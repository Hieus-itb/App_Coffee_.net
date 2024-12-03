using App_Coffee.controller;
using System.Data.SqlClient;

namespace App_Coffee
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            connection conn = new connection();
            conn.OpenConnection();
            conn.CloseConnection();

            ApplicationConfiguration.Initialize();
            Application.Run(new view.Form1());
            Console.ReadLine();
        }
    }
}