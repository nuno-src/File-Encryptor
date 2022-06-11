using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace File_Encryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButtonEncrypt.Checked = true;
            listBox1.Visible = false;

        }

        private void radioButtonEncrypt_CheckedChanged(object sender, EventArgs e)
        {


            buttonBrowseKey.Enabled = false;
            buttonBrowseKey.Visible = false;
            textBox2.Enabled = false;
            textBox2.Visible = false;


        }

        private void radioButtonDecrypt_CheckedChanged(object sender, EventArgs e)
        {

            buttonBrowseKey.Enabled = true;
            buttonBrowseKey.Visible = true;
            textBox2.Enabled = true;
            textBox2.Visible = true;

        }



        private void buttonBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
            
        }

        // browse key file
        private void buttonBrowseKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (radioButtonEncrypt.Checked == true)
            {

                if (File.Exists(textBox1.Text))
                {


                    string filepath = textBox1.Text;

                    //string[] lines = File.ReadAllLines(filepath);

                    //string linha = sr.ReadLine();

                    List<string> lines = new List<string>();
                    lines = File.ReadAllLines(filepath).ToList();



                    //foreach(string line in lines)
                    //{
                    //    listBox1.Items.Add(line);
                    //}




                    FileStream fs = File.Create(textBox1.Text);
                    //AesCryptoServiceProvider cod = new AesCryptoServiceProvider();

                    Aes cod = Aes.Create();
                    CryptoStream cr = new CryptoStream(fs, cod.CreateEncryptor(), CryptoStreamMode.Write);

                    StreamWriter sw = new StreamWriter(cr);

                    foreach (string line in lines)
                    {
                        sw.WriteLine(line);
                    }

                    sw.Close();
                    fs.Close();

                    string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    //string pathKey = @""+ pathDesktop + "\\chave.key";
                    string pathKey = pathDesktop + "\\chave.key";

                    FileStream fsChave = File.Create(pathKey);
                    

                    BinaryWriter bw = new BinaryWriter(fsChave);

                    bw.Write(cod.Key);
                    bw.Write(cod.IV);
                    bw.Close();
                    fsChave.Close();

                    MessageBox.Show("Ficheiro encriptado com sucesso." + "\nFicheiro chave.key salvo em:" + pathDesktop);
                }

            }
            else if (radioButtonDecrypt.Checked == true)
            {
                if (File.Exists(textBox1.Text) && File.Exists(textBox2.Text))
                {
                    
                    string filepath = textBox1.Text;
                    string filepath_key = textBox2.Text;

                    FileStream fich = File.OpenRead(filepath);
                    FileStream chave = File.OpenRead(filepath_key);



                    //AesCryptoServiceProvider cod = new AesCryptoServiceProvider();
                    Aes cod = Aes.Create();
                    BinaryReader brKey = new BinaryReader(chave);
                    cod.Key = brKey.ReadBytes(32);
                    cod.IV = brKey.ReadBytes(16);


                    CryptoStream cs = new CryptoStream(fich, cod.CreateDecryptor(), CryptoStreamMode.Read);

                    StreamReader sr = new StreamReader(cs);


                    //List<string> lines; // = File.ReadAllLines(sr).ToList();//new List<string>();
                    //string[] aux;

                    string linha = sr.ReadLine();
                    while (linha != null)
                    {
                        
                        listBox1.Items.Add(linha);
                        
                        //lines.Append(linha);
                        linha = sr.ReadLine();
                    }

                    sr.Close();
                    fich.Close();
                    chave.Close();

                    StreamWriter sw = new StreamWriter(filepath);

                    foreach(string i in listBox1.Items)
                    {
                        sw.WriteLine(i);
                    }

                    sw.Close();

                    //while (linha != null)
                    //{
                    //    string[] aux = linha.Split('.');
                    //    lines.Add(linha);
                    //    listBox1.Items.Add(aux);

                    //    linha = sr.ReadLine();
                    //}


                    //string filepath = textBox2.Text;

                    //string[] lines = File.ReadAllLines(filepath);

                    //string linha = sr.ReadLine();

                    // List<string> lines = new List<string>();
                    //lines = File.ReadAllLines(filepath).ToList();

                    sr.Close();
                    fich.Close();
                    chave.Close();

                    //foreach (string line in lines)
                    //{
                    //    listBox1.Items.Add(line);
                    //    //File.WriteAllLines(filepath, line);
                    //}






                    //foreach (string line in lines)
                    //{
                    //    File.WriteAllLines(filepath,lines);
                    //}


                    


                    MessageBox.Show("Ficheiro desencriptado com sucesso.");

                    
                }
            }




            //tab2 browse file
            //private void buttonBrowseFileDecryptor_Click(object sender, EventArgs e)
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        textBox1.Text = ofd.FileName;
            //    }
            //}


            // tab 2 browse key file
            //private void button5_Click(object sender, EventArgs e)
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        textBox2.Text = ofd.FileName;
            //    }
            //}


            //// tab2 desencriptar
            //private void button2_Click(object sender, EventArgs e)
            //{
            //    if (File.Exists(textBox1.Text))
            //    {
            //        string filepath = textBox1.Text;
            //        string filepath_key = textBox2.Text;

            //        FileStream fich = File.OpenRead(filepath);
            //        FileStream chave = File.OpenRead(filepath_key);



            //        //AesCryptoServiceProvider cod = new AesCryptoServiceProvider();
            //        Aes cod = Aes.Create();
            //        BinaryReader brKey = new BinaryReader(chave);
            //        cod.Key = brKey.ReadBytes(32);
            //        cod.IV = brKey.ReadBytes(16);


            //        CryptoStream cs = new CryptoStream(fich, cod.CreateDecryptor(), CryptoStreamMode.Read);

            //        StreamReader sr = new StreamReader(cs);


            //        //List<string> lines = File.ReadAllLines(sr).ToList();//new List<string>();
            //        //string[] aux;

            //        string linha;
            //        do
            //        {
            //            linha = sr.ReadLine();
            //            listBox1.Items.Add(linha);
            //        }while (linha != null);

            //        //while (linha != null)
            //        //{
            //        //    string[] aux = linha.Split('.');
            //        //    lines.Add(linha);
            //        //    listBox1.Items.Add(aux);

            //        //    linha = sr.ReadLine();
            //        //}


            //        //string filepath = textBox2.Text;

            //        //string[] lines = File.ReadAllLines(filepath);

            //        //string linha = sr.ReadLine();

            //        // List<string> lines = new List<string>();
            //        //lines = File.ReadAllLines(filepath).ToList();

            //        sr.Close();
            //        fich.Close();
            //        chave.Close();

            //        //foreach (string line in lines)
            //        //{
            //        //    listBox1.Items.Add(line);
            //        //    //File.WriteAllLines(filepath, line);
            //        //}






            //        //foreach (string line in lines)
            //        //{
            //        //    File.WriteAllLines(filepath,lines);
            //        //}





            //        MessageBox.Show("Ficheiro desencriptado com sucesso.");

            //    }


        }

        
    }
}
