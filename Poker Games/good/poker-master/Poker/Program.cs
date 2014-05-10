using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Poker
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// Добалено Alexx для теста
        /// учимся git ^_^ \m/
        /// tell me baby 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
