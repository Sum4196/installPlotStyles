using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallPlotStyles
{
    class Program
    {
        static void Main(string[] args)
        {

            string vaultPLDIR = "";

            //Copies all files from source folder to destination folder.
            void copyFiles(string sourceDirectory, string destDirectory)
            {
                string[] files = Directory.GetFiles(sourceDirectory);

                foreach (var s in files)
                {
                    string filename = Path.GetFileName(s);
                    string destFile = Path.Combine(destDirectory, filename);

                    try
                    {
                        if (filename.Contains("installPlotStyles"))
                        {
                            Console.WriteLine("installPlotStyles.exe found, not copying itself to Plot Styles folder.  Continuing...");
                        }
                        else
                        {
                            File.Copy(s, destFile, false);
                            File.SetAttributes(destFile, FileAttributes.Normal);
                        }
                    }
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                        System.Diagnostics.Debug.WriteLine(copyError.Message);
                    }

                }
            }


            //System.Diagnostics.Debug.WriteLine("CURRENT USER DOCUMENTS FOLDER: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            string vaultPPLWPLPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CW_Vault\\PPLW\\Clearwater Paper\\Plot Styles";
            string vaultCPLWPLPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CW_Vault\\CPLW\\Clearwater Paper\\Plot Styles";
            //System.Diagnostics.Debug.WriteLine("PPLW Fonts folder exists?: " + System.IO.Directory.Exists(vaultPPLWFontsPath));
            //System.Diagnostics.Debug.WriteLine("CPLW Fonts folder exists?: " + System.IO.Directory.Exists(vaultCPLWFontsPath));

            //check for vault fonts and choose PPLW or CPLW fonts folder, else, alert user to download fonts from vault.
            if (Directory.Exists(vaultPPLWPLPath))
            {
                vaultPLDIR = vaultPPLWPLPath;
            }
            else if (Directory.Exists(vaultCPLWPLPath))
            {
                vaultPLDIR = vaultCPLWPLPath;
            }
            else
            {
                MessageBox.Show("This program was unable to find a Plot Styles directory.\nPlease download the Plot Styles from Vault and re-run this program.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string trueview2015Path = appData + "\\Autodesk\\DWG TrueView 2015 - English\\R13\\enu\\Plotters\\Plot Styles";
            string trueview2019Path = appData + "\\Autodesk\\DWG TrueView 2019 - English\\R17\\enu\\Plotters\\Plot Styles";
            string trueview2020Path = appData + "\\Autodesk\\DWG TrueView 2020 - English\\R18\\enu\\Plotters\\Plot Styles";
            string autocad2015Path = appData + "\\Autodesk\\AutoCAD 2015\\R20.0\\enu\\Plotters\\Plot Styles";
            string autocad2019Path = appData + "\\Autodesk\\AutoCAD 2019\\R23.0\\enu\\Plotters\\Plot Styles";

            if (Directory.Exists(trueview2015Path) == true)
            {
                copyFiles(vaultPLDIR, trueview2015Path);
            }
            if (Directory.Exists(trueview2019Path) == true)
            {
                copyFiles(vaultPLDIR, trueview2019Path);
            }
            if (Directory.Exists(trueview2020Path) == true)
            {
                copyFiles(vaultPLDIR, trueview2020Path);
            }
            if (Directory.Exists(autocad2015Path) == true)
            {
                copyFiles(vaultPLDIR, autocad2015Path);
            }
            if (Directory.Exists(autocad2019Path) == true)
            {
                copyFiles(vaultPLDIR, autocad2019Path);
            }
        }
    }
}
