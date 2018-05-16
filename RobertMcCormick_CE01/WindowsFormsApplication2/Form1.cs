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
using RobertMcCormick_CE1.models;




 
///////////////////////////////////////////////////////////////////////////////////////////////////
//    RobertMccormick_CodeExerciseCE01
//    VisualFrameworks
//    3rd Term

namespace RobertMcCormick_CE1
{




    public partial class Form1 : Form
    {

        private Models _models;

        //Generates random number for color picker
        Random random = new Random();

        //  class level variable
        int Answer;
        private void Init()
        {
            Answer = random.Next(1, 4);
        }
        public Form1()
        {
            InitializeComponent();
            _models = new Models();
        }





        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //Visibility of groupbox



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = (checkBox1.Checked) ? true : false;

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //optionForm.BackColor = Color.GhostWhite;
                ActiveForm.BackColor = Color.Yellow;
                ActiveForm.ForeColor = Color.Purple;



            }
            else if (radioButton2.Checked == true)
            {
                //optionForm.BackColor = Color.GhostWhite;
                ActiveForm.BackColor = Color.Red;
                ActiveForm.ForeColor = Color.Blue;
            }
            else if (radioButton3.Checked == true)
            {
                //optionForm.BackColor = Color.GhostWhite;
                ActiveForm.BackColor = Color.Orange;
                ActiveForm.ForeColor = Color.Green;
            }

        }

        //Refresh the screen
        private void button2_Click(object sender, EventArgs e)
        {
            ///   Application.Restart();
            //  Application.;

            numScroll1.Value = 0;
            richTextBox1.Text = null;
            comboBox1.Text = null;

            if (radioButton1.Checked == true)
            {
                radioButton1.Checked = false;
                ActiveForm.ForeColor = Color.Empty;
                ActiveForm.BackColor = Color.Empty;


            }
            else if (radioButton2.Checked == true)
            {
                radioButton2.Checked = false;
                ActiveForm.ForeColor = Color.Empty;
                ActiveForm.BackColor = Color.Empty;

            }
            else if (radioButton3.Checked == true)
            {
                radioButton3.Checked = false;
                ActiveForm.ForeColor = Color.Empty;
                ActiveForm.BackColor = Color.Empty;
            }




        }






       

        //Internally read a file
        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(@"..\..\Random.txt"))


                while (!reader.EndOfStream)
                {
                    // richTextBox1.AppendText(reader.ReadLine());
                    richTextBox1.AppendText(reader.ReadLine());
                }
        }

        //Rewrite the file
        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\Random.txt"))
            {
                // writer.WriteLine(richTextBox1.Text);
                writer.WriteLine(richTextBox1.Text);
            }

        }

        //Save somewhere else.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();


            if (radioButton1.Checked == true)
            {
                SaveNumericUpDown(savefile);
            }
            else if (radioButton2.Checked == true)
            {
                saveTextBox(savefile);

            }
            else if (radioButton3.Checked == true)
            {

            }



        }




        //Open a different file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {



            OpenFileDialog openfile = new OpenFileDialog();
            //openfile.ShowDialog();
            openfile.Title = "Open Text (.txt) File ";
            openfile.Filter = "Text File |*.txt";
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(openfile.FileName);
                // richTextBox1.AppendText(openfile.FileName);

                using (StreamReader reader = new StreamReader(openfile.FileName))


                    while (!reader.EndOfStream)
                    {
                        richTextBox1.AppendText(reader.ReadLine());
                    }

            }
        }



        private void ApplyView(Models _models)
        {
            numScroll1.Value = _models.numberScroll;
        }

        private void ApplyModel()
        {
            _models.numberScroll = numScroll1.Value;

        }





        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        //Clear richtextbox

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        // opens files
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            //openfile.ShowDialog();
            openfile.Title = "Open Text (.txt) File ";
            openfile.Filter = "Text File |*.txt";
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)

            {
                MessageBox.Show(openfile.FileName);
                // richTextBox1.AppendText(openfile.FileName);

                using (StreamReader reader = new StreamReader(openfile.FileName))


                    while (!reader.EndOfStream)
                    {
                        richTextBox1.AppendText(reader.ReadLine());
                    }

            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            //if (savefile.ShowDialog() == DialogResult.OK)
            //{
            //    using (Stream s = File.Open(savefile.FileName, FileMode.CreateNew))
            //    using (StreamWriter sw = new StreamWriter(s))
            //    {
            //        sw.Write(richTextBox1.Text);
            //        sw.Write(numScroll1.Value);
            //    }

            //}




            if (radioButton1.Checked == true)
            {
                SaveNumericUpDown(savefile);
            }
            else if (radioButton2.Checked == true)
            {
                saveTextBox(savefile);

            }
            else if (radioButton3.Checked == true)
            {
                SaveComboBox(savefile);
            }



        }


        private void SaveNumericUpDown(SaveFileDialog savefile)
        {

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                ApplyModel();
                using (Stream s = File.Open(savefile.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(numScroll1.Value);

                }

            }
        }

        private void saveTextBox(SaveFileDialog savefile)
        {

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                ApplyModel();
                using (Stream s = File.Open(savefile.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(richTextBox1.Text);


                }

            }
        }

        private void SaveComboBox(SaveFileDialog savefile)
        {

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                ApplyModel();
                using (Stream s = File.Open(savefile.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(comboBox1.Text);

                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Answer = random.Next(1, 4);

            if (Answer == 1)
            {

                ActiveForm.BackColor = Color.Blue;
                ActiveForm.ForeColor = Color.Red;
                radioButton1.Enabled = true;
                radioButton1.Checked = true;
            }
            else if (Answer == 2)
            {

                ActiveForm.BackColor = Color.Purple;
                ActiveForm.ForeColor = Color.Yellow;
                radioButton2.Enabled = true;
                radioButton2.Checked = true;
            }
            else if (Answer == 3)
            {

                ActiveForm.BackColor = Color.Green;
                ActiveForm.ForeColor = Color.Blue;
                radioButton3.Enabled = true;
                radioButton3.Checked = true;
            }

        }
    }
}
 
 
  
