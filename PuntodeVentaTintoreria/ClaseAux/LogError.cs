﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PuntodeVentaTintoreria.ClaseAux
{
    public class LogError
    {
        public static void AddExcFileTxt(Exception ex, string funcion)
        {
            try
            {
                string mydocpath = "Resources/Documents/ErrorLog.txt";

                if (File.Exists(mydocpath))
                {
                    using (StreamWriter outputFile = new StreamWriter(mydocpath, true))
                    {
                        outputFile.WriteLine(ex.HResult + " - " + DateTime.Now + " - " + funcion + " - " + ex.Message);
                    }
                }
                else
                {
                    using (StreamWriter outputFile = new StreamWriter(mydocpath))
                    {
                        outputFile.WriteLine(ex.HResult + " - " + DateTime.Now + " - " + funcion + " - " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
