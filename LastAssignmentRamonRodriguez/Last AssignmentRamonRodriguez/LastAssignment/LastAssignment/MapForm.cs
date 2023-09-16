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

/*

* Ramon Rodriguez

* CPT-230-W37

* Last Assignment

* Summer 2022 

*/

namespace LastAssignment
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        //cd variable store the current directory
        string cd = Environment.CurrentDirectory; 

        General mg = new General();//object from the general class

        //saver method that save the progress of the map
        public void Saver()
        {
            try
            {
                string path = cd + @"\savedfiles\mapi.txt";
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

                if (rb1.Checked)
                {
                    sw.WriteLine("rb1");   
                }
                else if (rb2.Checked)
                {
                    sw.WriteLine("rb2");  
                }
                else if (rb3.Checked)
                {
                    sw.WriteLine("rb3");   
                }
                else if (rb4.Checked)
                {
                    sw.WriteLine("rb4");
                }
                else if (rb5.Checked)
                {
                    sw.WriteLine("rb5");
                }
                else if (rb6.Checked)
                {
                    sw.WriteLine("rb6");
                }
                else if (rb7.Checked)
                {
                    sw.WriteLine("rb7");
                }
                else if (rb8.Checked)
                {
                    sw.WriteLine("rb8");
                }
                sw.Close();
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File not found");
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found");
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }


        //Loader method that load the saved progress of the map
        public void Loader()
        {
            string path = cd + @"\savedfiles\mapi.txt";
            List<string> rbList = new List<string>();

            try
            {
                
                StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));

                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    rbList.Add(line);
                }

                if(rbList.Contains("rb1"))
                {
                    rb1.Checked = true;
                    count = 1;
                    pic1.Visible = true;
                }
                else if(rbList.Contains("rb2"))
                {
                    rb2.Checked = true;
                    count = 2;
                    pic2.Visible = true;
                }
                else if(rbList.Contains("rb3"))
                {
                    rb3.Checked = true;
                    count = 3;
                    pic3.Visible = true;
                }
                else if(rbList.Contains("rb4"))
                {
                    rb5.Checked = true;
                    count = 4;
                    pic5.Visible = true;
                }
                else if (rbList.Contains("rb5"))
                {
                    rb6.Checked = true;
                    count = 5;
                    pic6.Visible = true;
                }
                else if(rbList.Contains("rb6"))
                {
                    rb4.Checked = true;
                    pic4.Visible = true;
                }
                else if(rbList.Contains("rb7"))
                {
                    rb7.Checked = true;
                    pic7.Visible = true;
                }
                else if(rbList.Contains("rb8"))
                {
                    rb8.Checked = true;
                    pic8.Visible = true;
                }
                sr.Close();

            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File not found");
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found");
            }
            catch(IOException er)
            {
                MessageBox.Show(er.Message.ToString());
            }
           


        }

        HVForm hvf = new HVForm();
        int count = 0;

        //button that move the character in the map foward
        private void fowardBtn_Click(object sender, EventArgs e)
        {
            string message = mg.Msg();
            
            if (rb7.Checked || rb8.Checked || rb4.Checked)
            {
                MessageBox.Show(message);
            }
            else
            {
                if(count < 5)
                {
                    count += 1;
                }
                if(count == 1)
                {
                    rb1.Checked = true;
                    pic0.Visible = false;
                    pic1.Visible = true;
                }
                if(count == 2)
                {
                    rb2.Checked = true;
                    pic1.Visible=false;
                    pic2.Visible=true;
                }
                if(count == 3)
                {
                    rb3.Checked = true;
                    pic2.Visible = false;
                    pic3.Visible = true;

                    Saver();
                    hvf.Show();
                    this.Hide();
                }
                if(count == 4)
                {
                    rb5.Checked = true;
                    pic3.Visible=false;
                    pic5.Visible = true;
                }
                if(count == 5)
                {
                    rb6.Checked = true;
                    pic5.Visible=false;
                    pic6.Visible=true;
                }
            }

            
            
        }

        //button that move the character in the map backward
        private void backBtn_Click(object sender, EventArgs e)
        {
            string message = mg.Msg();

            if (rb7.Checked || rb8.Checked || rb4.Checked)
            {
                MessageBox.Show(message);
            }
            else
            {
                if (count > 1)
                {
                    count = count - 1;
                }

                if (count == 4)
                {
                    rb5.Checked = true;
                    pic6.Visible = false;
                    pic5.Visible = true;
                }
                if (count == 3)
                {
                    rb3.Checked = true;
                    pic5.Visible = false;
                    pic3.Visible = true;
                }
                if (count == 2)
                {
                    rb2.Checked = true;
                    pic3.Visible = false;
                    pic2.Visible = true;
                }
                if (count == 1)
                {
                    rb1.Checked = true;
                    pic2.Visible= false;
                    pic1.Visible = true;
                }
            }
            
        }


        //button that move the character in the map upward
        private void upBtn_Click(object sender, EventArgs e)
        {
            string message = mg.Msg();

            if (rb1.Checked || rb3.Checked || rb6.Checked)
            {
                MessageBox.Show(message);
            }
            else
            {
                if (rb5.Checked)
                {
                    rb4.Checked = true;
                    pic5.Visible =false;
                    pic4.Visible = true;
                }
                else if (rb2.Checked)
                {
                    rb4.Checked = true;
                    pic2.Visible = false;
                    pic4.Visible = true;
                }
                else if (rb4.Checked)
                {
                    rb7.Checked = true;
                    pic4.Visible= false;
                    pic7.Visible = true;

                    Saver();
                    hvf.Show();
                    this.Hide();
                }
                else if (rb7.Checked)
                {
                    rb8.Checked = true;
                    pic7.Visible= false;
                    pic8.Visible = true;

                    Saver();
                    hvf.Show();
                    this.Hide();
                }
            }
            
            
        }


        //button that move the character in the map downward
        private void downBtn_Click(object sender, EventArgs e)
        {
            string message = mg.Msg();

            if (rb8.Checked)
            {
                rb7.Checked = true;
                pic8.Visible = false;
                pic7.Visible = true;
            }
            else if(rb7.Checked)
            {
                rb4.Checked= true;
                pic7.Visible = false;
                pic4.Visible = true;
            }
            else if(rb4.Checked && count == 4)
            {
                rb5.Checked = true;
                pic4.Visible = false;
                pic5.Visible= true;

            }
            else if(rb4.Checked && count == 2)
            {
                rb2.Checked = true;
                pic4.Visible = false;
                pic2.Visible= true;
            }
            else if(rb4.Checked && count == 0)
            {
                count = 4;
                rb5.Checked = true;
                pic5.Visible = true;
                pic4.Visible = false;


            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            
            string path = cd + @"\savedfiles\mapi.txt";
            if (File.Exists(path))
            {
                pic0.Visible = false;
                Loader();
            }
            
        }

        
    }
}
