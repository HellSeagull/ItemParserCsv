using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace itemParserCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Génération
            List<string> DisplayID = new List<string>();
            List<string> Model_1 = new List<string>();
            List<string> Model_2 = new List<string>();
            List<string> Tex_1 = new List<string>();
            List<string> Tex_2 = new List<string>();
            List<string> List_Tex = new List<string>();
            List<string> Name = new List<string>();
            Dictionary<string, string> modelfiledata = new Dictionary<string, string>();
            Dictionary<string, string> texturefiledata = new Dictionary<string, string>();
            Dictionary<string, string> itemapp = new Dictionary<string, string>();
            Dictionary<string, string> itemmodapp = new Dictionary<string, string>();
            Dictionary<string, string> itemsparse = new Dictionary<string, string>();
            Dictionary<string, string> filedata = new Dictionary<string, string>();
            List<string> itemmaterial1 = new List<string>();
            List<string> itemmaterial2 = new List<string>();

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\Filedata.txt"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        if (!line.Contains("item/") || line == null || line == "")
                        {
                            line = null;
                        }
                        else if (line.ToLowerInvariant().Contains("item/") && !line.EndsWith(".phys")
                                    || line.Contains("item/") && !line.EndsWith(".skin")
                                    || line.Contains("item/") && !line.EndsWith(".skel"))
                        {
                            if (line.Contains(".frFR") || line.Contains(".all"))
                            {
                                string id = line.Split(' ')[0].Split('.')[0].TrimStart(new char[] { '0' });
                                string path = line.Split(' ')[2];
                                path = path.Substring(path.LastIndexOf("/") + 1, path.Length - path.LastIndexOf("/") - 1);
                                path = path.Replace(".m2", "").Replace(".blp", "");
                                filedata.Add(id, path);
                            }
                        }
                    }
                }
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\modelfiledata.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        modelfiledata.Add(line.Split(',')[0].Replace("\"", ""), line.Split(',')[3].Replace("\"", ""));
                    }
                }
            }

            var uniqueValues = modelfiledata.GroupBy(pair => pair.Value)
                         .Select(group => group.First())
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            modelfiledata = uniqueValues;

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\texturefiledata.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        texturefiledata.Add(line.Split(',')[0].Replace("\"", ""), line.Split(',')[2].Replace("\"", ""));
                    }
                }
            }

            uniqueValues = texturefiledata.GroupBy(pair => pair.Value)
                         .Select(group => group.First())
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            texturefiledata = uniqueValues;

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\itemDisplayinfo.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        DisplayID.Add(line.Split(',')[0].Replace("\"", ""));
                        Model_1.Add(line.Split(',')[11].Replace("\"", ""));
                        Model_2.Add(line.Split(',')[12].Replace("\"", ""));
                        Tex_1.Add(line.Split(',')[13].Replace("\"", ""));
                        Tex_2.Add(line.Split(',')[14].Replace("\"", ""));
                    }
                }
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\itemappearance.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        itemapp.Add(line.Split(',')[0].Replace("\"", ""), line.Split(',')[2].Replace("\"", ""));
                    }
                }
            }

            uniqueValues = itemapp.GroupBy(pair => pair.Value)
             .Select(group => group.First())
             .ToDictionary(pair => pair.Key, pair => pair.Value);

            itemapp = uniqueValues;

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\itemmodifiedappearance.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        itemmodapp.Add(line.Split(',')[0].Replace("\"", ""), line.Split(',')[3].Replace("\"", ""));
                    }
                }
            }

            uniqueValues = itemmodapp.GroupBy(pair => pair.Value)
             .Select(group => group.First())
             .ToDictionary(pair => pair.Key, pair => pair.Value);

            itemmodapp = uniqueValues;

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\itemsparse.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        itemsparse.Add(line.Split(',')[0].Replace("\"", ""), line.Split(',')[6].Replace("\"", ""));
                    }
                }
            }

            uniqueValues = itemsparse.GroupBy(pair => pair.Value)
             .Select(group => group.First())
             .ToDictionary(pair => pair.Key, pair => pair.Value);

            itemsparse = uniqueValues;

            using (StreamReader sr = new StreamReader(@"C:\Users\HalZo\OneDrive\Bureau\CSV\itemdisplayinfomaterialres.csv"))
            {
                string line = null;
                line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) != null || (line = sr.ReadLine()) != string.Empty)
                    {
                        itemmaterial1.Add(line.Split(',')[3].Replace("\"", ""));
                        itemmaterial2.Add(line.Split(',')[2].Replace("\"", "") + "," + line.Split(',')[3].Replace("\"", ""));
                    }
                }
            }

            for (int i = 0; i < itemmaterial1.Count; i++)
            {
                string value = null;
                for (int j = i; j < itemmaterial2.Count; j++)
                {
                    if (itemmaterial2[j].Split(',')[1] == itemmaterial1[i])
                    {
                        if (i > 0 && itemmaterial1[i] == itemmaterial1[i])
                        {
                            value += itemmaterial2[j].Split(',')[0] + ";";
                        }
                        else if (i == 0)
                        {
                            value += itemmaterial2[j].Split(',')[0] + ";";
                        }
                    }
                    else
                    {
                        value = value.Substring(0, value.Length - 1);
                        i = j - 1;
                        break;
                    }
                }
                List_Tex.Add(itemmaterial1[i] + ";" + value);
            }

            for (int i = 0; i < List_Tex.Count; i++)
            {
                string value = null;
                value += List_Tex[i].Split(';')[0] + ";";
                for (int j = 1; j < List_Tex[i].Split(';').Count(); j++)
                {
                    foreach (KeyValuePair<string, string> tk in texturefiledata)
                    {
                        if (List_Tex[i].Split(';')[j] == tk.Value)
                        {
                            value += tk.Key + ";";
                            break;
                        }
                    }
                    if (j == List_Tex[i].Split(';').Count() - 1)
                    {
                        value = value.Substring(0, value.Length - 1);
                        List_Tex[i] = value;
                        break;
                    }
                }
            }

            for (int i = 0; i < List_Tex.Count; i++)
            {
                string value = null;
                value += List_Tex[i].Split(';')[0] + ";";
                for (int j = 1; j < List_Tex[i].Split(';').Count(); j++)
                {
                    foreach (KeyValuePair<string, string> tk in filedata)
                    {
                        if (List_Tex[i].Split(';')[j] == tk.Key)
                        {
                            value += tk.Value + ";";
                            break;
                        }
                    }
                    if (j == List_Tex[i].Split(';').Count() - 1)
                    {
                        value = value.Substring(0, value.Length - 1);
                        List_Tex[i] = value;
                        break;
                    }
                }
            }

            for (int i = 0; i < DisplayID.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in itemapp)
                {
                    if (DisplayID[i] == tk.Value)
                    {
                        foreach (KeyValuePair<string, string> tk1 in itemmodapp)
                        {
                            if (tk.Key == tk1.Value)
                            {
                                foreach (KeyValuePair<string, string> tk2 in itemsparse)
                                {
                                    if (tk1.Key == tk2.Key)
                                    {
                                        Name.Add(DisplayID[i] + ";" + tk2.Value);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Model_1.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in modelfiledata)
                {
                    if (!Model_1[i].Equals("0"))
                    {
                        if (Model_1[i] == tk.Value)
                        {
                            Model_1[i] = tk.Key;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < Model_1.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in filedata)
                {
                    if (Model_1[i] == tk.Key)
                    {
                        Model_1[i] = tk.Value;
                        break;
                    }
                }
            }

            for (int i = 0; i < Model_2.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in modelfiledata)
                {
                    if (!Model_2[i].Equals("0"))
                    {
                        if (Model_2[i] == tk.Value)
                        {
                            Model_2[i] = tk.Key;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < Model_2.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in filedata)
                {
                    if (Model_2[i] == tk.Key)
                    {
                        Model_2[i] = tk.Value;
                        break;
                    }
                }
            }

            for (int i = 0; i < Tex_1.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in texturefiledata)
                {
                    if (!Tex_1[i].Equals("0"))
                    {
                        if (Tex_1[i] == tk.Value)
                        {
                            Tex_1[i] = tk.Key;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < Tex_1.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in filedata)
                {
                    if (Tex_1[i] == tk.Key)
                    {
                        Tex_1[i] = tk.Value;
                        break;
                    }
                }
            }

            for (int i = 0; i < Tex_2.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in texturefiledata)
                {
                    if (!Tex_2[i].Equals("0"))
                    {
                        if (Tex_2[i] == tk.Value)
                        {
                            Tex_2[i] = tk.Key;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < Tex_2.Count; i++)
            {
                foreach (KeyValuePair<string, string> tk in filedata)
                {
                    if (Tex_2[i] == tk.Key)
                    {
                        Tex_2[i] = tk.Value;
                        break;
                    }
                }
            }

            string[] lines = new string[DisplayID.Count];
            for (int i = 0; i < DisplayID.Count; i++)
            {
                lines[i] = DisplayID[i] + "|" + Model_1[i] + "|" + Model_2[i] + "|" + Tex_1[i] + "|" + Tex_2[i];
            }

            for (int i = 0; i < lines.Count(); i++)
            {
                foreach (string s in Name)
                {
                    if (lines[i].Split('|')[0] == s.Split(';')[0])
                    {
                        lines[i] += "|" + s.Split(';')[1];
                        break;
                    }
                }
            }

            for (int i = 0; i < lines.Count(); i++)
            {
                foreach (string s in List_Tex)
                {
                    if (lines[i].Split('|')[0] == s.Split(';')[0])
                    {
                        string s1 = null;
                        for (int j = 1; j < s.Split(';').Count(); j++)
                        {
                            if (s.Split(';')[j] != null)
                                s1 += s.Split(';')[j] + ";";
                        }
                        if (s1 != null)
                        {
                            s1 = s1.Substring(0, s1.Length - 1);
                            lines[i] += "|" + s1;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < lines.Count(); i++)
            {
                try
                {
                    File.AppendAllText(@"DB_ITEM_BFA.csv", lines[i] + Environment.NewLine);
                }
                catch
                {
                    File.AppendAllText(@"D:\DB_ITEM_BFA.csv", lines[i] + Environment.NewLine);
                }
            }
            #endregion

            #region fix valeurs
            try
            {
                //string[] lines = File.ReadAllLines(@"C:\Users\HalZo\source\repos\Kuretar_Displayer_Searcher\Kuretar_Displayer_Searcher\Resources\DB_ITEM_BFA.csv");
                //for (int i = 0; i < lines.Count(); i++)
                //{
                //    if (lines[i] != "")
                //    {
                //        if (lines[i].Split('|').Count() == 6)
                //        {
                //            if (!lines[i].Split('|')[5].Contains("_"))
                //            {
                //                lines[i] = lines[i].Substring(0, lines[i].Length - (lines[i].Split('|')[5].Length + 1));
                //            }
                //            else
                //            {
                //                string value = null;
                //                value += "typetex:";
                //                for (int j = 0; j < lines[i].Split('|')[5].Split(';').Count(); j++)
                //                {
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_au_"))
                //                    {
                //                        value += "bras haut;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_al_"))
                //                    {
                //                        value += "bras bas;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_ha_"))
                //                    {
                //                        value += "mains;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_tu_"))
                //                    {
                //                        value += "torse haut;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_tl_"))
                //                    {
                //                        value += "torse bas;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_lu_"))
                //                    {
                //                        value += "jambes hautes;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_ll_"))
                //                    {
                //                        value += "jambes basses;";
                //                    }
                //                    if (lines[i].Split('|')[5].Split(';')[j].ToLowerInvariant().Contains("_fo_"))
                //                    {
                //                        value += "pieds;";
                //                    }
                //                }
                //                value = value.Substring(0, value.Length - 1);
                //                string temp = lines[i].Split('|')[5];
                //                lines[i] = lines[i].Replace(lines[i].Split('|')[5], value) + "|" + temp;
                //            }
                //        }
                //        else if (lines[i].Split('|').Count() == 7)
                //        {
                //            string value = null;
                //            value += "typetex:";
                //            for (int j = 0; j < lines[i].Split('|')[6].Split(';').Count(); j++)
                //            {
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_au_"))
                //                {
                //                    value += "bras haut;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_al_"))
                //                {
                //                    value += "bras bas;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_ha_"))
                //                {
                //                    value += "mains;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_tu_"))
                //                {
                //                    value += "torse haut;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_tl_"))
                //                {
                //                    value += "torse bas;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_lu_"))
                //                {
                //                    value += "jambes hautes;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_ll_"))
                //                {
                //                    value += "jambes basses;";
                //                }
                //                if (lines[i].Split('|')[6].Split(';')[j].ToLowerInvariant().Contains("_fo_"))
                //                {
                //                    value += "pieds;";
                //                }
                //            }
                //            value = value.Substring(0, value.Length - 1);
                //            lines[i] = lines[i].Replace(lines[i].Split('|')[5], value);
                //        }
                //    }
                //}
                //File.WriteAllLines(@"C:\Users\HalZo\source\repos\Kuretar_Displayer_Searcher\Kuretar_Displayer_Searcher\Resources\DB_ITEM_BFA.csv", lines);
            }
            catch(Exception exp) { Console.WriteLine("Error at: " + exp.ToString()); }
            #endregion
        }
    }
}
