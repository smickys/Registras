using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registras.Model;
using Registras.Helpers;
using Spire.Doc;
using Spire.Doc.Documents;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.XSSF;
using NPOI.POIFS.FileSystem;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using System.Text.RegularExpressions;

namespace Registras
{
    public partial class Form1 : Form
    {
        #region Variables
        const string sablonasAtaskaita = "Sablonai\\ataskaitos sablonas.doc";
        const string sablonasExcel = "Sablonai\\nuasmeninimui.xlsx";
        const string save1 = "save1.txt";
        const string save2 = "save2.txt";
        const string save3 = "save3.txt";
        const string dozesF1 = "kDozes1.txt";
        const string dozesF2 = "kDozes2.txt";
        List<Duomenys> DataList = new List<Duomenys>();
        List<Duomenys> CompanyDataList = new List<Duomenys>();
        

        string folderPath1Open = "";
        string folderPath1Save = "";

        string folderPath3Open = "";
        string folferPath3Save = "";

        string[] files1;
        string[] files2;
        string[] files3;
        string[] files4;
        string[] filesT1;
        string[] filesT2;
        string[] filesAll = new string[0];

        List<string> LoadedPathList = new List<string>();
        List<string> SavedPathList = new List<string>();

        Queue<string> badFiles = new Queue<string>();

        List<double> LoadedDozesList1 = new List<double>();
        List<double> SavedDozesList1 = new List<double>();

        List<double> LoadedDozesList2 = new List<double>();
        List<double> SavedDozesList2 = new List<double>();

        DateTime selectedTimePeriodStart = new DateTime();
        DateTime selectedTimePeriodEnd = new DateTime();
        string laikotarpis = "";
        #endregion

        public Form1()
        {
            InitializeComponent();
            LoadedPathList.Add("");
            LoadedPathList.Add("");
            LoadedPathList.Add("");

            LoadedDozesList1.Add(0);
            LoadedDozesList1.Add(0);

            LoadedDozesList2.Add(0);
            LoadedDozesList2.Add(0);

            #region STEP1 direktorijų įvedimas, mygtukai

            menesis_comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            menesis_comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            menesis_comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            generate_button1.Enabled = false;
            metai_radioButton1.Enabled = false;
            ketvirtis1_radioButton2.Enabled = false;
            ketvirtis2_radioButton3.Enabled = false;
            ketvirtis3_radioButton4.Enabled = false;
            ketvirtis4_radioButton5.Enabled = false;
            menesis_radioButton6.Enabled = false;
            menesis_comboBox1.Enabled = false;
            richTextBox1_badFiles.Visible = false;

            if (File.Exists(save1))
            {
                SavedPathList = loadSavedPath(save1);
                if (SavedPathList.Count != 0)
                {
                    folderBrowserDialog1.SelectedPath = SavedPathList[0].ToString();
                }
            }
            #endregion
            

            #region STEP2 direktorijų įvedimas, mygtukai

            imone_comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            imone_comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            imone_comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            imone_comboBox1.Enabled = false;
            generate3_button3.Enabled = false;
            browse3_button3.Enabled = false;
            richTextBox2_badFiles.Visible = false;

            if (File.Exists(save3))
            {
                SavedPathList = loadSavedPath(save3);
                if (SavedPathList.Count != 0)
                {
                    folderBrowserDialog4.SelectedPath = SavedPathList[0];
                }
            }
            #endregion


            #region Doziu failai
            if (File.Exists(dozesF1))
            {
                SavedDozesList1 = loadSavedDoze(dozesF1);
                if (SavedDozesList1.Count != 0)
                {
                    if (SavedDozesList1[0] == 0)
                    {
                        textBox1_doze.Text = "";
                    }
                    else
                    {
                        textBox1_doze.Text = SavedDozesList1[0].ToString();
                    }

                    if (SavedDozesList1[1] == 0)
                    {
                        textBox1_eDoze.Text = "";
                    }
                    else
                    {
                        textBox1_eDoze.Text = SavedDozesList1[1].ToString();
                    }
                }
            }

            if (File.Exists(dozesF2))
            {
                SavedDozesList2 = loadSavedDoze(dozesF2);
                if (SavedDozesList2.Count != 0)
                {
                    if (SavedDozesList2[0] == 0)
                    {
                        textBox2_doze.Text = "";
                    }
                    else
                    {
                        textBox2_doze.Text = SavedDozesList2[0].ToString();
                    }

                    if (SavedDozesList2[1] == 0)
                    {
                        textBox2_eDoze.Text = "";
                    }
                    else
                    {
                        textBox2_eDoze.Text = SavedDozesList2[1].ToString();
                    }
                }
            }
            #endregion
        }



        #region Direktorijos
        public void saveLoadedPath<T>(List<T> sList, string fv)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Create)))
            {
                foreach (var item in sList)
                {
                    fr.WriteLine(item);
                }
            }
        }

        public List<string> loadSavedPath(string fv)
        {
            List<string> sList = new List<string>();
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sList.Add(line);
                }
            }
            return sList;
        }

        public List<double> loadSavedDoze(string fv)
        {
            List<double> sList = new List<double>();
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    double dz = line.DoubleParseAdvanced();
                    sList.Add(dz);
                }
            }
            return sList;
        }


        #endregion


        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataList = new List<Duomenys>();
            label1_pranesimas.Text = "";
            try
            {
                folderBrowserDialog1.Description = "Nurodykite metų protokolo katalogą";
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderPath1Open = folderBrowserDialog1.SelectedPath;
                    LoadedPathList[0] = folderPath1Open;

                    protokolasPath_label1.Text = "Protokolų direktorija: " + folderPath1Open;
                    protokolasPath3_label1.Text = "Protokolų direktorija: " + folderPath1Open;

                    Task task = new Task(() => protokolai(folderPath1Open));

                    task.ContinueWith(t =>
                    {
                        //GUI atnaujinimas is Task'o
                        this.Invoke((MethodInvoker)delegate
                        {
                            metai_radioButton1.Enabled = true;
                            ketvirtis1_radioButton2.Enabled = true;
                            ketvirtis2_radioButton3.Enabled = true;
                            ketvirtis3_radioButton4.Enabled = true;
                            ketvirtis4_radioButton5.Enabled = true;
                            menesis_radioButton6.Enabled = true;
                            browse3_button3.Enabled = true;
                        });
                    });

                    task.Start();
                }
            }
            catch
            {
                MessageBox.Show("Blogai nurodyta metų direktorija ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region STEP1 "Radiacijos centrui"
        private void generate_button1_Click(object sender, EventArgs e)
        {
            if (textBox1_doze.Text.ToString() != "" && textBox1_eDoze.Text.ToString() != "")
            {
                generate_button1.Enabled = false;
                richTextBox1_badFiles.Visible = false;
                metai_radioButton1.Enabled = false;
                ketvirtis1_radioButton2.Enabled = false;
                ketvirtis2_radioButton3.Enabled = false;
                ketvirtis3_radioButton4.Enabled = false;
                ketvirtis4_radioButton5.Enabled = false;
                menesis_radioButton6.Enabled = false;
                menesis_comboBox1.Enabled = false;
                label1_pranesimas.Text = "";
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
                try
                {
                    //selection(folderPath1Open);

                    Task task = new Task(() => selection(folderPath1Open));

                    task.ContinueWith(t =>
                    {
                        //GUI atnaujinimas is Task'o
                        this.Invoke((MethodInvoker)delegate
                        {
                            saveFileDialog1.Title = "Pasirinkite gautą failą iš Radiacijos centro";
                            saveFileDialog1.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                            saveFileDialog1.FileName = "Už " + laikotarpis + " " + DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                            DialogResult result = saveFileDialog1.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                folderPath1Save = saveFileDialog1.FileName;
                                LoadedPathList[1] = folderPath1Save;

                                LoadedDozesList1[0] = textBox1_doze.Text.DoubleParseAdvanced();
                                LoadedDozesList1[1] = textBox1_eDoze.Text.DoubleParseAdvanced();

                                saveLoadedPath(LoadedPathList, save1);
                                saveLoadedPath(LoadedDozesList1, dozesF1);

                                XSSFWorkbook wb1 = null;
                                using (var file = new FileStream(sablonasExcel, FileMode.Open, FileAccess.ReadWrite))
                                {
                                    wb1 = new XSSFWorkbook(file);
                                }

                                loadDataToExcel(DataList, wb1);


                                progressBar1.Style = ProgressBarStyle.Blocks;

                                if (badFiles.Count != 0)
                                {
                                    string note = "";
                                    foreach (var item in badFiles)
                                    {
                                        note = note + Environment.NewLine + item + Environment.NewLine;
                                    }
                                    label1_pranesimas.Text = "Yra keletas nenuskaitytų failų";
                                    MessageBox.Show("Šių failų nepavyko nuskaityti. Sutvarkykite juos rankiniu būdu" + Environment.NewLine + note, "Nepavyko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    richTextBox1_badFiles.Visible = true;
                                    richTextBox1_badFiles.Text = "Šių failų nepavyko nuskaityti. Sutvarkykite juos rankiniu būdu" + Environment.NewLine + note;
                                }
                                else
                                    label1_pranesimas.Text = "Visi duomenys nuskaityti!";

                                using (var file2 = new FileStream(folderPath1Save, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    wb1.Write(file2);
                                    file2.Close();
                                    System.Diagnostics.Process.Start(folderPath1Save);

                                }

                                metai_radioButton1.Enabled = true;
                                ketvirtis1_radioButton2.Enabled = true;
                                ketvirtis2_radioButton3.Enabled = true;
                                ketvirtis3_radioButton4.Enabled = true;
                                ketvirtis4_radioButton5.Enabled = true;
                                menesis_radioButton6.Enabled = true;
                                metai_radioButton1.Checked = false;
                                ketvirtis1_radioButton2.Checked = false;
                                ketvirtis2_radioButton3.Checked = false;
                                ketvirtis3_radioButton4.Checked = false;
                                ketvirtis4_radioButton5.Checked = false;
                                menesis_radioButton6.Checked = false;
                                badFiles = new Queue<string>();
                                DataList = new List<Duomenys>();

                            }
                            else
                            {
                                progressBar1.Style = ProgressBarStyle.Blocks;
                                metai_radioButton1.Enabled = true;
                                ketvirtis1_radioButton2.Enabled = true;
                                ketvirtis2_radioButton3.Enabled = true;
                                ketvirtis3_radioButton4.Enabled = true;
                                ketvirtis4_radioButton5.Enabled = true;
                                menesis_radioButton6.Enabled = true;
                                metai_radioButton1.Checked = false;
                                ketvirtis1_radioButton2.Checked = false;
                                ketvirtis2_radioButton3.Checked = false;
                                ketvirtis3_radioButton4.Checked = false;
                                ketvirtis4_radioButton5.Checked = false;
                                menesis_radioButton6.Checked = false;
                            }
                        });
                    });

                    task.Start();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Įveskite kritines dozes");

        }

        public void protokolai(string kelias)
        {

            files1 = Directory.GetFiles(kelias + "\\1");
            files2 = Directory.GetFiles(kelias + "\\2");
            files3 = Directory.GetFiles(kelias + "\\3");
            files4 = Directory.GetFiles(kelias + "\\4");

            filesT1 = files1.Concat(files2).ToArray();
            filesT2 = files3.Concat(files4).ToArray();

            filesAll = filesT1.Concat(filesT2).ToArray();
        }

        public void readData(string[] files)
        {
            foreach (string fName in files)
            {
                Document doc = new Document();
                try
                {
                    doc.LoadFromFile(fName);

                    if (doc.Sections[0].Tables.Count > 5)
                    {
                        throw new Exception("Faile yra " + doc.Sections[0].Tables.Count + " lentelės(-ių), maksimaliai gali būti 5. Pasinaudokite pagalba");
                    }

                    loadData(DataList, doc, fName);
                }
                catch (Exception ex)
                {                   
                    MessageBox.Show("Blogas failas: " + fName + Environment.NewLine + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    badFiles.Enqueue(ex.Message + Environment.NewLine + fName);
                }
            }

            
        }

        public void selection(string kelias)
        {
            try
            {
                string[] yearParts = kelias.Split('\\');
                string yearsString = "";
                foreach (var yP in yearParts)
                {
                    yearsString = yP;
                }
                int yearsInt = Int32.Parse(yearsString);

                #region Metu skaitymas
                if (metai_radioButton1.Checked == true)
                {
                    laikotarpis = yearsInt + " metus";
                    if (filesAll.Count() != 0)
                    {
                        readData(filesAll);
                        selectedTimePeriodStart = new DateTime(yearsInt, 01, 01);
                        selectedTimePeriodEnd = new DateTime(yearsInt, 12, 31);
                        generate_button1.Enabled = false;
                    }
                    else
                        MessageBox.Show("Metų kataloge nėra atitinkamų protokolų", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                #endregion

                #region 1 ketvircio skaitymas
                if (ketvirtis1_radioButton2.Checked == true)
                {
                    laikotarpis = "1 ketvirtį";
                    if (files1.Count() != 0)
                    {
                        readData(files1);
                        selectedTimePeriodStart = new DateTime(yearsInt, 01, 01);
                        selectedTimePeriodEnd = new DateTime(yearsInt, 03, 31);
                        generate_button1.Enabled = false;
                    }
                    else
                        MessageBox.Show("1 ketvirčio kataloge nėra atitinkamų protokolų", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                #endregion

                #region 2 ketvircio skaitymas
                if (ketvirtis2_radioButton3.Checked == true)
                {
                    if(files2.Count() != 0)
                    {
                        laikotarpis = "2 ketvirtį";
                        readData(files2);
                        selectedTimePeriodStart = new DateTime(yearsInt, 04, 01);
                        selectedTimePeriodEnd = new DateTime(yearsInt, 06, 30);
                        generate_button1.Enabled = false;
                    }
                    else
                        MessageBox.Show("2 ketvirčio kataloge nėra atitinkamų protokolų", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region 3 ketvircio skaitymas
                if (ketvirtis3_radioButton4.Checked == true)
                {
                    if(files3.Count() != 0)
                    {
                        laikotarpis = "3 ketvirtį";
                        readData(files3);
                        selectedTimePeriodStart = new DateTime(yearsInt, 07, 01);
                        selectedTimePeriodEnd = new DateTime(yearsInt, 09, 30);
                        generate_button1.Enabled = false;
                    }
                    else
                        MessageBox.Show("3 ketvirčio kataloge nėra atitinkamų protokolų", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                #endregion

                #region 4 ketvircio skaitymas
                if (ketvirtis4_radioButton5.Checked == true)
                {
                    if(files4.Count() != 0)
                    {
                        laikotarpis = "4 ketvirtį";
                        readData(files4);
                        selectedTimePeriodStart = new DateTime(yearsInt, 10, 01);
                        selectedTimePeriodEnd = new DateTime(yearsInt, 12, 31);
                        generate_button1.Enabled = false;
                    }
                    else
                        MessageBox.Show("4 ketvirčio kataloge nėra atitinkamų protokolų", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                #endregion

                #region Mennesio skaitymas
                if (menesis_radioButton6.Checked == true && menesis_comboBox1.SelectedItem.ToString() != null)
                {
                    laikotarpis = menesis_comboBox1.SelectedItem.ToString();
                    List<string> filesList = new List<string>();

                    DateTime pr = new DateTime();
                    DateTime pb = new DateTime();

                    Document doc = new Document();

                    foreach (var fName in filesAll)
                    {
                        try
                        {
                            doc.LoadFromFile(fName);
                            loadDataCompanyInfo(doc, ref pr, ref pb);
                            if (menesis_comboBox1.SelectedItem.ToString() == "Sausis" && pr.Month.ToString() == "1" && pb.Month.ToString() == "1")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 01, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 01, 31);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Vasaris" && pr.Month.ToString() == "2" && pb.Month.ToString() == "2")
                            {
                                filesList.Add(fName);
                                if(yearsInt % 4 == 0)
                                {
                                    selectedTimePeriodStart = new DateTime(yearsInt, 02, 01);
                                    selectedTimePeriodEnd = new DateTime(yearsInt, 02, 29);
                                }
                                else
                                {
                                    selectedTimePeriodStart = new DateTime(yearsInt, 02, 01);
                                    selectedTimePeriodEnd = new DateTime(yearsInt, 02, 28);
                                }
                                
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Kovas" && pr.Month.ToString() == "3" && pb.Month.ToString() == "3")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 03, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 03, 31);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Balandis" && pr.Month.ToString() == "4" && pb.Month.ToString() == "4")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 04, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 04, 30);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Gegužė" && pr.Month.ToString() == "5" && pb.Month.ToString() == "5")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 05, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 05, 31);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Birželis" && pr.Month.ToString() == "6" && pb.Month.ToString() == "6")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 06, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 06, 30);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Liepa" && pr.Month.ToString() == "7" && pb.Month.ToString() == "7")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 07, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 07, 31);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Rugpjūtis" && pr.Month.ToString() == "8" && pb.Month.ToString() == "8")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 08, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 08, 31);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Rugsėjis" && pr.Month.ToString() == "9" && pb.Month.ToString() == "9")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 09, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 09, 30);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Spalis" && pr.Month.ToString() == "10" && pb.Month.ToString() == "10")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 10, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 10, 31);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Lapkritis" && pr.Month.ToString() == "11" && pb.Month.ToString() == "11")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 11, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 11, 30);
                            }
                            if (menesis_comboBox1.SelectedItem.ToString() == "Gruodis" && pr.Month.ToString() == "12" && pb.Month.ToString() == "12")
                            {
                                filesList.Add(fName);
                                selectedTimePeriodStart = new DateTime(yearsInt, 12, 01);
                                selectedTimePeriodEnd = new DateTime(yearsInt, 12, 31);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Blogas failas " + fName, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            badFiles.Enqueue(fName);
                        }
                    }
                    
                    string[] allMonthfiles = filesList.ToArray();
                    readData(allMonthfiles);

                    if(allMonthfiles.Count() != 0)
                    {
                        generate_button1.Enabled = false;
                    }
                    else
                        MessageBox.Show("Pasirinkto mėnesio \"" + menesis_comboBox1.SelectedItem.ToString() + "\" nėra susijusių failų", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("Blogai nurodyta metų direktorija ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void loadDataCompanyInfo(Document doc, ref DateTime pr, ref DateTime pb)
        {
            Table table = doc.Sections[0].Tables[0] as Table;
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].Cells.Count; j++)
                {
                    if (table.Rows[i].Cells[j].Paragraphs[0].Text == "Dozimetro nešiojimo ")
                    {
                        string line = table.Rows[i].Cells[j + 1].Paragraphs[0].Text;
                        string[] parts = line.Split(' ');
                        string nuo = parts[1];
                        pr = DateTime.Parse(nuo);
                        string line2 = table.Rows[i + 1].Cells[j + 1].Paragraphs[0].Text;
                        string[] parts2 = line2.Split(' ');
                        string iki = parts2[1];
                        pb = DateTime.Parse(iki);
                    }

                }

            }
        }

        public void loadData(List<Duomenys> dataList, Document doc, string fName)
        {
            string imone = "", adresas = "", taikMetodas = "", naudIranga = "", skyrius = "";
            DateTime pradziosData = new DateTime();
            DateTime pabaigosData = new DateTime();
            //Table table = doc.Sections[0].Tables[0] as Table;
            int n = 0;
            try
            {

                #region Skyriaus skaitymas
                for (int i = 0; i < doc.Sections[0].Paragraphs.Count; i++)
                {
                    if (doc.Sections[0].Paragraphs[i].Text.Contains("Bandymo rezultatai:"))
                        n++;
                }
                if (n != 1)
                {
                    throw new Exception("Faile nepavyko nuskaityti padalinio pavadinimo. Pasinaudokite pagalba");
                }
                else if (n == 1)
                {
                    for (int i = 0; i < doc.Sections[0].Paragraphs.Count; i++)
                    {

                        if ((doc.Sections[0].Paragraphs[i].Text == "Bandymo rezultatai:" && doc.Sections[0].Paragraphs[i + 1].Text != "")
                     || (doc.Sections[0].Paragraphs[i].Text == "Bandymo rezultatai: " && doc.Sections[0].Paragraphs[i + 1].Text != ""))
                        {
                            skyrius = doc.Sections[0].Paragraphs[i + 1].Text;
                            if (doc.Sections[0].Paragraphs[i + 1].Text.Contains(" Ketvirtis"))
                            {
                                string tempSkyrius = doc.Sections[0].Paragraphs[i + 1].Text;
                                skyrius = tempSkyrius.Replace(" Ketvirtis", "");
                            }
                            if (doc.Sections[0].Paragraphs[i + 1].Text.Contains("lapas iš"))
                            {
                                skyrius = "";
                            }
                            break;
                        }
                        if (doc.Sections[0].Paragraphs[i].Text.Contains("Bandymo rezultatai:  "))
                        {
                            string tempSkyrius = doc.Sections[0].Paragraphs[i].Text;
                            skyrius = tempSkyrius.Replace("Bandymo rezultatai:  ", "");
                            break;
                        }
                        if (doc.Sections[0].Paragraphs[i].Text.Contains("Bandymo rezultatai: "))
                        {
                            string tempSkyrius = doc.Sections[0].Paragraphs[i].Text;
                            skyrius = tempSkyrius.Replace("Bandymo rezultatai: ", "");
                            break;
                        }
                    }
                }

                #endregion

                #region Imones duomenys
                for (int ti = 0; ti < doc.Sections[0].Tables.Count; ti++)
                {
                    Table table = doc.Sections[0].Tables[ti] as Table;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table.Rows[i].Cells.Count == 2)
                        {
                            for (int j = 0; j < table.Rows[i].Cells.Count; j++)
                            {
                                if (table.Rows[i].Cells[j].Paragraphs[0].Text == "Užsakovas")
                                {
                                    imone = table.Rows[i].Cells[j + 1].Paragraphs[0].Text;
                                    imone = imone.Replace('\u201E', '"');
                                    imone = imone.Replace('\u201C', '"');
                                }
                                if (table.Rows[i].Cells[j].Paragraphs.Count == 2)
                                    if (table.Rows[i].Cells[j].Paragraphs[1].Text == "Užsakovas")
                                    {
                                        imone = table.Rows[i].Cells[j + 1].Paragraphs[1].Text;
                                        imone = imone.Replace('\u201E', '"');
                                        imone = imone.Replace('\u201C', '"');
                                    }
                                if (table.Rows[i].Cells[j].Paragraphs[0].Text == "Užsakovo adresas")
                                {
                                    adresas = table.Rows[i].Cells[j + 1].Paragraphs[0].Text;
                                }
                                if (table.Rows[i].Cells[j].Paragraphs[0].Text == "Taikytas metodas")
                                {
                                    taikMetodas = table.Rows[i].Cells[j + 1].Paragraphs[0].Text;
                                }
                                if (table.Rows[i].Cells[j].Paragraphs[0].Text == "Naudota įranga")
                                {
                                    naudIranga = table.Rows[i].Cells[j + 1].Paragraphs[0].Text;
                                }
                                if (table.Rows[i].Cells[j].Paragraphs[0].Text == "Dozimetro nešiojimo ")
                                {
                                    string line = table.Rows[i].Cells[j + 1].Paragraphs[0].Text;
                                    string[] parts = line.Split(' ');
                                    string nuo = parts[1];
                                    pradziosData = DateTime.Parse(nuo);
                                    string line2 = table.Rows[i + 1].Cells[j + 1].Paragraphs[0].Text;
                                    string[] parts2 = line2.Split(' ');
                                    string iki = parts2[1];
                                    pabaigosData = DateTime.Parse(iki);
                                }

                            }
                        }
                    }
                }
                
                #endregion

                #region Darbuotoju duomenys
                string vardas = "", pavarde = "", pareigos = "", dozNr = "", pastaba = "";
                double doze = 0, eDoze = 0;
                int tCount = doc.Sections[0].Tables.Count;
                //bool yraKlaidingu = false;
                //var tempDataList = new List<Duomenys>();
                for (int ti = 1; ti < doc.Sections[0].Tables.Count; ti++)
                {
                    Table table2 = doc.Sections[0].Tables[ti] as Table;
                    if (table2.Rows[0].Cells.Count == 7 || table2.Rows[0].Cells.Count == 6 || table2.Rows[1].Cells.Count == 7 || table2.Rows[1].Cells.Count == 6)
                    {
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            if (table2.Rows[i].Cells.Count == 7 || table2.Rows[i].Cells.Count == 6)
                            {
                                if(table2.Rows[i].Cells[5].Paragraphs[0].Text.ToLower() == "pastabos")
                                {
                                    i++;
                                }
                            }
                            if (table2.Rows[i].Cells.Count == 1)
                            {
                                skyrius = table2.Rows[i].Cells[0].Paragraphs[0].Text;
                            }
                            if (table2.Rows[i].Cells.Count == 7 || table2.Rows[i].Cells.Count == 6)
                            {
                                for (int j = 0; j < table2.Rows[i].Cells.Count; j++)
                                {
                                    #region skaitymas Po
                                    if (table2.Rows[i].Cells[5].Paragraphs[0].Text.ToLower() == "po")
                                    {
                                        if (j == 1)
                                        {
                                            string line = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            string[] parts = line.Split(' ');
                                            if (parts.Count() == 2)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]);
                                                pavarde = FirstLetterToUpper(parts[1]);
                                            }
                                            else if (parts.Count() == 3)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]);
                                                if (parts[2] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                            else if (parts.Count() == 4)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]) + " " + FirstLetterToUpper(parts[3]);
                                                if (parts[2] == "" && parts[3] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                        }
                                        if (j == 2)
                                        {
                                            pareigos = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 3)
                                        {
                                            if (table2.Rows[i].Cells[j].Paragraphs[0].Text.Contains("-") == false)
                                                dozNr = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            else
                                                pastaba = "Negrąžintas";
                                        }
                                        if (j == 4)
                                        {
                                            if (table2.Rows[i].Cells[j].Paragraphs[0].Text.Contains("-") == false)
                                                doze = table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                            else
                                                pastaba = "Negrąžintas";
                                        }
                                        if (j == 5)
                                        {
                                            if(pastaba != "Negrąžintas")
                                                pastaba = "Po apsiaustu";
                                        }
                                        if (j == 6)
                                        {
                                            if (table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced() != 0)
                                            {
                                                eDoze = table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                            }
                                            else
                                            {
                                                eDoze = table2.Rows[i - 1].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                            }
                                        }

                                    }
                                    #endregion
                                    #region skaitymas Virs
                                    else if (table2.Rows[i].Cells[5].Paragraphs[0].Text.ToLower() == "virš")
                                    {

                                        if (j == 1)
                                        {
                                            string line = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            string[] parts = line.Split(' ');
                                            if (parts.Count() == 2)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]);
                                                pavarde = FirstLetterToUpper(parts[1]);
                                            }
                                            else if (parts.Count() == 3)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]);
                                                if (parts[2] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                            else if (parts.Count() == 4)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]) + " " + FirstLetterToUpper(parts[3]);
                                                if (parts[2] == "" && parts[3] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                        }
                                        if (j == 2)
                                        {
                                            pareigos = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 3)
                                        {
                                            if (table2.Rows[i].Cells[j].Paragraphs[0].Text.Contains("-") == false)
                                                dozNr = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            else
                                                pastaba = "Negrąžintas";
                                        }
                                        if (j == 4)
                                        {
                                            if (table2.Rows[i].Cells[j].Paragraphs[0].Text.Contains("-") == false)
                                                doze = table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                            else
                                                pastaba = "Negrąžintas";
                                        }
                                        if (j == 5)
                                        {
                                            if (pastaba != "Negrąžintas")
                                                pastaba = "Virš apsiausto";
                                        }
                                        if (j == 6)
                                        {
                                            if (table2.Rows[i - 1].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced() != 0)
                                            {
                                                eDoze = table2.Rows[i - 1].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                            }
                                            else
                                            {
                                                eDoze = table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                            }
                                        }
                                    }
                                    #endregion
                                    #region skaitymas kai pastaba tuscia
                                    else if(table2.Rows[i].Cells[5].Paragraphs[0].Text == "")
                                    {
                                        if (j == 1)
                                        {
                                            string line = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            string[] parts = line.Split(' ');
                                            if (parts.Count() == 2)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]);
                                                pavarde = FirstLetterToUpper(parts[1]);
                                            }
                                            else if (parts.Count() == 3)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]);
                                                if (parts[2] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                            else if (parts.Count() == 4)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]) + " " + FirstLetterToUpper(parts[3]);
                                                if (parts[2] == "" && parts[3] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                        }
                                        if (j == 2)
                                        {
                                            pareigos = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 3)
                                        {
                                            dozNr = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 4)
                                        {
                                            doze = table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                        }
                                        if (j == 5)
                                        {
                                            pastaba = "Ant krūtinės";
                                        }
                                        eDoze = 0;
                                    }
                                    #endregion
                                    #region skaitymas negrazinto
                                    else if(table2.Rows[i].Cells[5].Paragraphs[0].Text.ToLower() == "negrąžintas")
                                    {
                                        if (j == 1)
                                        {
                                            string line = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            string[] parts = line.Split(' ');
                                            if (parts.Count() == 2)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]);
                                                pavarde = FirstLetterToUpper(parts[1]);
                                            }
                                            else if (parts.Count() == 3)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]);
                                                if (parts[2] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                            else if (parts.Count() == 4)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]) + " " + FirstLetterToUpper(parts[3]);
                                                if (parts[2] == "" && parts[3] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                        }
                                        if (j == 2)
                                        {
                                            pareigos = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 3)
                                        {
                                            dozNr = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 5)
                                        {
                                            pastaba = table2.Rows[i].Cells[5].Paragraphs[0].Text;
                                        }
                                        doze = -1;
                                        eDoze = 0;
                                    }
                                    #endregion
                                    #region skaitymas nenumatyto
                                    else
                                    {
                                        if (j == 1)
                                        {
                                            string line = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                            string[] parts = line.Split(' ');
                                            if (parts.Count() == 2)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]);
                                                pavarde = FirstLetterToUpper(parts[1]);
                                            }
                                            else if (parts.Count() == 3)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]);
                                                if (parts[2] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                            else if (parts.Count() == 4)
                                            {
                                                vardas = FirstLetterToUpper(parts[0]) + " " + FirstLetterToUpper(parts[1]);
                                                pavarde = FirstLetterToUpper(parts[2]) + " " + FirstLetterToUpper(parts[3]);
                                                if (parts[2] == "" && parts[3] == "")
                                                {
                                                    vardas = FirstLetterToUpper(parts[0]);
                                                    pavarde = FirstLetterToUpper(parts[1]);
                                                }
                                            }
                                        }
                                        if (j == 2)
                                        {
                                            pareigos = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 3)
                                        {
                                            dozNr = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        if (j == 4)
                                        {
                                            doze = table2.Rows[i].Cells[j].Paragraphs[0].Text.DoubleParseAdvanced();
                                        }
                                        if (j == 5)
                                        {
                                            pastaba = table2.Rows[i].Cells[j].Paragraphs[0].Text;
                                        }
                                        eDoze = 0;
                                    }
                                    #endregion
                                }
                                Doze dz = new Doze(pradziosData, pabaigosData, dozNr, doze, pastaba, eDoze);
                                Duomenys duom = new Duomenys(imone, adresas, vardas, pavarde, pareigos, taikMetodas, naudIranga, skyrius, dz, 0);
                                if (duom.Imone == "" || duom.Adresas == "" || duom.TaikytasMetodas == "" || duom.Vardas == "" || duom.Pavarde == "" || duom.Pareigos == "" || duom.Dozes.NesiojimoVieta == "")
                                {
                                    throw new Exception("Faile nepavyko nuskaityti duomenų, blogai surašyti duomenys. Pasinaudokite pagalba");                               
                                }

                                foreach (var d in dataList)
                                {
                                    if (duom.Vardas == d.Pavarde && duom.Pavarde == d.Vardas)
                                    {
                                        throw new Exception("Faile yra surašyti vardas ir pavardė atvirkščiai. Pasinaudokite pagalba");
                                    }
                                }

                                if (duom.Dozes.NesiojimoVieta != "Negrąžintas")
                                {
                                    if (mergeSimilar(dataList, duom) == false)
                                        dataList.Add(duom);
                                }
                                pastaba = "";
                            }
                        }
                    }
                }
                //if (yraKlaidingu == false)
                //{
                //    foreach (var item in tempDataList)
                //    {
                //        if(mergeSimilar(dataList, item) == false)
                //            dataList.Add(item);
                //    }
                //}
                //else
                //{
                //    throw new Exception("Nepavyko nuskaityti duomenų iš failo");
                //}
                #endregion
            }
            catch (Exception ex)
            {
                badFiles.Enqueue(ex.Message + Environment.NewLine + fName);
            }

        }

        public void loadDataToExcel(List<Duomenys> dList, XSSFWorkbook wb)
        {
            XSSFCellStyle hstyle = (XSSFCellStyle)wb.CreateCellStyle();
            XSSFColor color = new XSSFColor(new byte[] { 255, 0, 0 });
            var hfont = (XSSFFont)wb.CreateFont();
            hfont.SetColor(color);
            hstyle.SetFont(hfont);
            int j = 2;
            foreach (var duom in dList)
            {
                var row = wb.GetSheetAt(0).CreateRow(j);
                row.CreateCell(0).SetCellValue("");
                if ((duom.Dozes.NesiojimoVieta.ToLower() == "po apsiaustu" || duom.Dozes.NesiojimoVieta.ToLower() == "virš apsiausto") && row.GetCell(0).ToString() == "")
                {
                    row.CreateCell(0).SetCellValue(selectedTimePeriodStart.ToString("yyyy-MM-dd") + "-" + selectedTimePeriodEnd.ToString("yyyy-MM-dd"));
                    row.CreateCell(1).SetCellValue(duom.TaikytasMetodas);
                    row.CreateCell(2).SetCellValue(duom.Imone);
                    row.CreateCell(3).SetCellValue(duom.Padalinys);
                    row.CreateCell(5).SetCellValue(duom.Vardas);
                    row.CreateCell(6).SetCellValue(duom.Pavarde);
                    row.CreateCell(7).SetCellValue(duom.Pareigos);
                    row.CreateCell(8).SetCellValue(duom.Dozes.GautaDoze);
                    row.CreateCell(12).SetCellValue(duom.Dozes.NesiojimoVieta);
                    row.CreateCell(13).SetCellValue(duom.Dozes.EfektineDoze);
                }
                else
                {
                    row.CreateCell(0).SetCellValue(selectedTimePeriodStart.ToString("yyyy-MM-dd") + "-" + selectedTimePeriodEnd.ToString("yyyy-MM-dd"));
                    row.CreateCell(1).SetCellValue(duom.TaikytasMetodas);
                    row.CreateCell(2).SetCellValue(duom.Imone);
                    row.CreateCell(3).SetCellValue(duom.Padalinys);
                    row.CreateCell(5).SetCellValue(duom.Vardas);
                    row.CreateCell(6).SetCellValue(duom.Pavarde);
                    row.CreateCell(7).SetCellValue(duom.Pareigos);
                    row.CreateCell(8).SetCellValue(duom.Dozes.GautaDoze);
                    row.CreateCell(12).SetCellValue(duom.Dozes.NesiojimoVieta);
                }
                j++;
                if (duom.Dozes.GautaDoze >= textBox1_doze.Text.DoubleParseAdvanced())
                    row.GetCell(8).CellStyle = hstyle;

                if (duom.Dozes.EfektineDoze >= textBox1_eDoze.Text.DoubleParseAdvanced())
                    row.GetCell(13).CellStyle = hstyle;
            }

            for (int i = 2; i <= wb.GetSheetAt(0).LastRowNum; i++)
            {
                if (wb.GetSheetAt(0).GetRow(i).GetCell(12).ToString().ToLower() == "virš apsiausto" && wb.GetSheetAt(0).GetRow(i + 1).GetCell(12).ToString().ToLower() == "po apsiaustu")
                {
                    wb.GetSheetAt(0).GetRow(i + 1).CreateCell(13).SetCellValue("");
                    i++;
                }
                else if (wb.GetSheetAt(0).GetRow(i).GetCell(12).ToString().ToLower() == "po apsiaustu" && wb.GetSheetAt(0).GetRow(i + 1).GetCell(12).ToString().ToLower() == "virš apsiausto")
                {
                    wb.GetSheetAt(0).GetRow(i + 1).CreateCell(13).SetCellValue("");
                    i++;
                }
            }
        }

        public bool mergeSimilar(List<Duomenys> dList, Duomenys naujas)
        {
            foreach (Duomenys d in dList)
            {
                if((naujas.Vardas.ToLower() == d.Vardas.ToLower()) 
                && (naujas.Pavarde.ToLower() == d.Pavarde.ToLower()) 
                && (naujas.Imone.ToLower() == d.Imone.ToLower()) 
                && (naujas.Dozes.NesiojimoVieta.ToLower() == d.Dozes.NesiojimoVieta.ToLower()))
                {
                    d.Dozes.EfektineDoze = d.Dozes.EfektineDoze + naujas.Dozes.EfektineDoze;
                    d.Dozes.GautaDoze = d.Dozes.GautaDoze + naujas.Dozes.GautaDoze;
                    if(d.Dozes.NesiojimoPabaigosData < naujas.Dozes.NesiojimoPabaigosData)
                    {
                        d.Dozes.NesiojimoPabaigosData = naujas.Dozes.NesiojimoPabaigosData;
                    }
                    else
                    {
                        d.Dozes.NesiojimoPradziosData = naujas.Dozes.NesiojimoPradziosData;
                    }
                    return true;

                }
            }
            return false;
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();

            return str.ToUpper();
        }

        #region Mygtukai
        private void metai_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            generate_button1.Enabled = true;
        }

        private void ketvirtis1_radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            generate_button1.Enabled = true;
        }

        private void ketvirtis2_radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            generate_button1.Enabled = true;
        }

        private void ketvirtis3_radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            generate_button1.Enabled = true;
        }

        private void ketvirtis4_radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            generate_button1.Enabled = true;
        }

        private void menesis_radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            menesis_comboBox1.Enabled = true;
            if (menesis_comboBox1.SelectedItem != null)
                generate_button1.Enabled = true;
            else
                generate_button1.Enabled = false;

            if (menesis_radioButton6.Checked == false)
            {
                menesis_comboBox1.Enabled = false;
            }
        }

        private void menesis_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            generate_button1.Enabled = true;
        }

        private void richTextBox1_badFiles_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);

                richTextBox1_badFiles.ContextMenu = contextMenu;
            }
        }

        void CopyAction(object sender, EventArgs e)
        {
            //Graphics objGraphics;
            Clipboard.SetData(DataFormats.Rtf, richTextBox1_badFiles.SelectedRtf);
            Clipboard.Clear();
        }
        #endregion

        #endregion
        
       

        #region STEP2 "Ataskaita įmonei"
        // load mygtukas
        private void browse3_button3_Click(object sender, EventArgs e)
        {
            DataList = new List<Duomenys>();
            progressBar3.Style = ProgressBarStyle.Marquee;
            progressBar3.MarqueeAnimationSpeed = 100;
            metai_radioButton1.Checked = true;

            try
            {
                Task task = new Task(() => selection(folderPath1Open));

                task.ContinueWith(t =>
                {
                    //GUI atnaujinimas is Task'o
                    this.Invoke((MethodInvoker)delegate
                    {
                        loadComboBox(DataList);
                        progressBar3.Style = ProgressBarStyle.Blocks;
                        imone_comboBox1.Enabled = true;

                        if (badFiles.Count != 0)
                        {
                            string note1 = "";
                            foreach (var item in badFiles)
                            {
                                note1 = note1 + Environment.NewLine + item + Environment.NewLine;
                            }
                            label2_pranesimas.Text = "Yra keletas nenuskaitytų failų";
                            MessageBox.Show("Šių failų nepavyko nuskaityti. Sutvarkykite juos rankiniu būdu" + Environment.NewLine + note1, "Nepavyko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            richTextBox2_badFiles.Visible = true;
                            richTextBox2_badFiles.Text = "Šių failų nepavyko nuskaityti. Sutvarkykite juos rankiniu būdu" + Environment.NewLine + note1;
                        }
                        else
                            label2_pranesimas.Text = "Visi duomenys nuskaityti!";


                        badFiles = new Queue<string>();
                    });
                });
                task.Start();
            }
            catch
            {
                MessageBox.Show("Blogai nurodyta metų direktorija", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void generate3_button3_Click(object sender, EventArgs e)
        {
            if (textBox2_doze.Text.ToString() != "" && textBox2_eDoze.Text.ToString() != "")
            {
                progressBar3.Style = ProgressBarStyle.Marquee;
                progressBar3.MarqueeAnimationSpeed = 100;
                string s = imone_comboBox1.SelectedItem.ToString();
                string chosenComp = Regex.Replace(s, "[@,\\.\";'\\\\]", "");  // "[^A-Za-z0-9 _]"
                saveFileDialog3.Title = "Pasirinkite gautą failą iš Radiacijos centro";
                saveFileDialog3.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word Documents (*.docx)|*.docx";
                saveFileDialog3.FileName = "Ataskaita " + chosenComp + " " + DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                if (saveFileDialog3.ShowDialog() == DialogResult.OK)
                {
                    folferPath3Save = saveFileDialog3.FileName;

                    LoadedDozesList2[0] = textBox2_doze.Text.DoubleParseAdvanced();
                    LoadedDozesList2[1] = textBox2_eDoze.Text.DoubleParseAdvanced();

                    saveLoadedPath(LoadedPathList, save1);
                    saveLoadedPath(LoadedDozesList2, dozesF2);

                    //LoadedPathList[1] = folferPath3Save;
                    //saveLoadedPath(LoadedPathList, save3);

                    selectedCompany(DataList, CompanyDataList);
                    var SortedList = CompanyDataList.OrderBy(t => t.Padalinys).ThenBy(t => t.Pavarde).ThenBy(t => t.Vardas).ThenBy(t => t.Dozes.NesiojimoVieta);
                    CompanyDataList = SortedList.ToList();
                    string protokoloMetai = "";
                    string[] parts = folderPath1Open.Split('\\');
                    foreach (var p in parts)
                    {
                        protokoloMetai = p;
                    }

                    Document doc = new Document();
                    doc.LoadFromFile(sablonasAtaskaita);
                    templateFilling(doc, CompanyDataList, protokoloMetai, folferPath3Save);
                    progressBar3.Style = ProgressBarStyle.Blocks;
                    doc.SaveToFile(folferPath3Save, FileFormat.Doc);
                    System.Diagnostics.Process.Start(folferPath3Save);
                    CompanyDataList = new List<Duomenys>();
                }
                else
                    progressBar3.Style = ProgressBarStyle.Blocks;

            }
            else
                MessageBox.Show("Įveskite kritines dozes");
            

        }
        
        public void loadComboBox(List<Duomenys> dList)
        {
            List<string> AllCompanies = new List<string>();
            foreach (var d in dList)
            {
                AllCompanies.Add(d.Imone);
            }
            List<string> Companies = AllCompanies.Distinct().ToList();
            Companies.Sort();
            foreach (var c in Companies)
            {
                imone_comboBox1.Items.Add(c);
            }
        }

        public void selectedCompany(List<Duomenys> dList, List<Duomenys> cList)
        {
            foreach (var d in dList)
            {
                if(d.Imone == imone_comboBox1.SelectedItem.ToString())
                {
                    cList.Add(d);
                }
            }
        }

        public void templateFilling(Document doc, List<Duomenys> dList, string metai, string docPath)
        {
            try
            {
                #region Šablono perdarymas
                DateTime dataSiandien = DateTime.Today;
                doc.Replace("<Metai>", metai, true, true);
                doc.Replace("<DataSiandien>", dataSiandien.ToString("yyyy-MM-dd"), true, true);
                doc.Replace("<NesiojimoMetai>", metai, true, true);
                doc.Replace("<ImonesPavadinimas>", dList.First().Imone, true, true);
                doc.Replace("<ImonesAdresas>", dList.First().Adresas, true, true);
                #endregion

                #region Lentelės užpildymas
                var keys = new List<string>();

                Table tbl = doc.Sections[0].Tables[1] as Table;

                int count = tbl.Rows[1].Cells.Count;

                for (int i = 0; i < count; i++)
                {
                    string clName = tbl.Rows[1].Cells[i].Paragraphs[0].Text;
                    keys.Add(clName);
                }

                TableRow row = tbl.Rows[1];

                for (int i = 1; i < dList.Count; i++)
                {
                    tbl.Rows.Insert(2, row.Clone());
                }

                for (int i = 0; i < dList.Count; i++)
                {
                    for (int j = 0; j < keys.Count; j++)
                    {
                        if (keys[j] != null)
                        {
                            if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<CompanyName>")
                            {
                                tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Imone;
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<Department>")
                            {
                                tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Padalinys;
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<First Name>")
                            {
                                tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Vardas;
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<Last Name>")
                            {
                                tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Pavarde;
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<Duty>")
                            {
                                tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Pareigos;
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<DDE>")
                            {
                                if (dList[i].Dozes.GautaDoze != -1)
                                {
                                    tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Dozes.GautaDoze.ToString();
                                    if (dList[i].Dozes.GautaDoze >= textBox2_doze.Text.DoubleParseAdvanced())
                                        tbl.Rows[i + 1].Cells[j].CellFormat.BackColor = Color.Red;
                                }
                                else
                                    tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = "-";
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<Pastabos>")
                            {
                                tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Dozes.NesiojimoVieta;
                            }
                            else if (tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text == "<EfektineDoze>")
                            {
                                if (dList[i].Dozes.EfektineDoze != 0 && (dList[i].Dozes.NesiojimoVieta == "Po apsiaustu" || dList[i].Dozes.NesiojimoVieta == "Virš apsiausto"))
                                {
                                    tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = dList[i].Dozes.EfektineDoze.ToString();

                                    if (dList[i].Dozes.EfektineDoze >= textBox2_eDoze.Text.DoubleParseAdvanced())
                                        tbl.Rows[i + 1].Cells[j].CellFormat.BackColor = Color.Red;
                                }
                                else
                                    tbl.Rows[i + 1].Cells[j].Paragraphs[0].Text = "";


                            }
                        }
                    }
                }

                for (int i = 0; i < dList.Count; i++)
                {
                    if (tbl.Rows[i + 1].Cells[6].Paragraphs[0].Text == "Po apsiaustu" || tbl.Rows[i + 1].Cells[6].Paragraphs[0].Text == "Virš apsiausto")
                    {
                        if (tbl.Rows[i + 1].Cells[2].Paragraphs[0].Text == tbl.Rows[i + 2].Cells[2].Paragraphs[0].Text && tbl.Rows[i + 1].Cells[3].Paragraphs[0].Text == tbl.Rows[i + 2].Cells[3].Paragraphs[0].Text)
                        {
                            tbl.ApplyVerticalMerge(7, i + 1, i + 2);
                            i++;
                        }
                    }
                }

                HeaderFooter footer = doc.Sections[0].HeadersFooters.Footer;
                Paragraph footerParagraph = footer.AddParagraph();
                footerParagraph.AppendField("page number", FieldType.FieldPage);
                footerParagraph.AppendText(" iš ");
                footerParagraph.AppendField("number of pages", FieldType.FieldSectionPages);
                footerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                #endregion

                try
                {
                    doc.SaveToFile(docPath, FileFormat.Doc);
                }
                catch
                {
                    MessageBox.Show("Uždarykite Word failą ir bandykite dar kartą.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Generavimo klaida:" + System.Environment.NewLine + ex);
            }
            
            
        }

        private void imone_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            generate3_button3.Enabled = true;
        }
        
        #endregion



        #region View Help
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.2" + Environment.NewLine + Environment.NewLine + "Program author" + Environment.NewLine + "© 2016 Simonas Mickys" + Environment.NewLine + "simonas.mickys@gmail.com", "About Registras");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        #endregion
        
    }
}
