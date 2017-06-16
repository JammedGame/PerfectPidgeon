using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using PerfectPidgeon.Draw;
using PerfectPidgeonGameMechanic.Content;

namespace PerfectPidgeonGameMechanic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BaseDataPool _DataPool = new BaseDataPool();
            Cinematic Intro = new Cinematic();
            MainForm Form = new MainForm();
            DrawForm DForm = new DrawForm();
            Game CurrentGame = new Game(DForm, Form);
            Intro.SetReturnForm(Form);
            Intro.SetCinematic(_DataPool.Cinematics["Intro"]);
            Application.Run(Intro);
        }
    }
}
