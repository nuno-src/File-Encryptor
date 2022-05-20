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


        //browse file tab 1
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        // tab1 encriptar
        private void button1_Click(object sender, EventArgs e)
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

                FileStream fsChave = File.Create("chave.key");

                BinaryWriter bw = new BinaryWriter(fsChave);

                bw.Write(cod.Key);
                bw.Write(cod.IV);
                bw.Close();
                fsChave.Close();

                MessageBox.Show("Ficheiro encriptado com sucesso.");

            }
        }
    
        


        //tab2 browse file
        private void buttonBrowseFileDecryptor_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }
        }


        // tab 2 browse key file
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
            }
        }


        // tab2 desencriptar
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox2.Text))
            {
                FileStream fich = File.OpenRead(textBox2.Text);
                FileStream chave = File.OpenRead(textBox3.Text);

                string filepath = textBox2.Text;

                //AesCryptoServiceProvider cod = new AesCryptoServiceProvider();
                Aes cod = Aes.Create();
                BinaryReader brKey = new BinaryReader(chave);
                cod.Key = brKey.ReadBytes(32);
                cod.IV = brKey.ReadBytes(16);


                CryptoStream cs = new CryptoStream(fich, cod.CreateDecryptor(), CryptoStreamMode.Read);

                StreamReader sr = new StreamReader(cs);


                List<string> lines = new List<string>();
                //string[] aux;

                string linha = sr.ReadLine();

                while (linha != null)
                {

                    lines.Add(linha);

                    linha = sr.ReadLine();
                }


                //string filepath = textBox2.Text;

                //string[] lines = File.ReadAllLines(filepath);

                //string linha = sr.ReadLine();

                // List<string> lines = new List<string>();
                //lines = File.ReadAllLines(filepath).ToList();

                sr.Close();
                fich.Close();
                chave.Close();

                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                    //File.WriteAllLines(filepath, line);
                }






                //foreach (string line in lines)
                //{
                //    File.WriteAllLines(filepath,lines);
                //}


               


                MessageBox.Show("Ficheiro desencriptado com sucesso.");

            }
        }

    }
}
