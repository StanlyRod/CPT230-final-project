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

namespace LastAssignment
{
    public partial class HVForm : Form
    {
        public HVForm()
        {
            InitializeComponent();

            //Initialize the heroes label with the powerlife property value
            lbBatman.Text = batman.PowerLevel;
            lbSuperman.Text = superman.PowerLevel;

            //Initialize the villains label with the powerlife property value
            lbJoker.Text = joker.PowerLevel;
            lbLuthor.Text = luthor.PowerLevel;

            //Initialize the heroes labelname with the heroes names
            lb1Caracter.Text = batman.BatmanName.ToString();
            lb2Caracter.Text = superman.SupermanName.ToString();

            //Initialize the villains labelname with the villains names
            lb3Caracter.Text = luthor.LuthorName.ToString();
            lb4Caracter.Text = joker.JokerName.ToString();
        }

        //cd variable store the current directory
        string cd = Environment.CurrentDirectory;

        //method that save the progress of the rpg
        public void Saver2(string a, string b, string FileName)
        {
            try
            {
                string path = cd + @"\savedfiles\"+FileName;
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
                sw.WriteLine(a);
                sw.WriteLine(b);
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
            catch(IOException en)
            {
                MessageBox.Show(en.Message.ToString());
            }
        }

        //method that load saved progress of the rpg
        public List<string> Loader2(string FileName)
        {
            string path = cd + @"\savedfiles\" + FileName;
            List<string> rbList = new List<string>();

            try
            {

                StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));

                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    rbList.Add(line);
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
            return rbList;
        }

       

        //Create Heroes objects from the heroes class
        DCHeroes batman = new DCHeroes();
        DCHeroes superman = new DCHeroes();

        //Create villains objects from the villains class
        DCVillains luthor = new DCVillains();
        DCVillains joker = new DCVillains();

        //Create attribute object from the caracterAttributes class
        CaracterAttributes attribute = new CaracterAttributes();

        int count2 = 0;

        private void GoodGuyTurn()
        {
            int damage = attribute.Attack(5, 10);
            int BGHP = GetBGHP();
            int BGHP2 = GetBGHP2();

            BGHP -= damage;
            BGHP2 -= damage;

            if (BGHP < 0 && BGHP2 < 0)
            {
                BGHP = 0;
                BGHP2 = 0;
            }
            lbJoker.Text = BGHP.ToString();
            lbLuthor.Text = BGHP2.ToString();

            pbJoker.Value = BGHP2;
            pbLuthor.Value = BGHP;
            textOUTPUT.Text = "the fight hit the imp for" + damage + "!\r\n" + textOUTPUT.Text;
            Saver2("J "+lbJoker.Text.ToString(), "L "+lbLuthor.Text.ToString(), "vs.txt");
        }

        private void BadGuyTurn()
        {
            //generate damage to hero
            int gGHP = GetGGHP();
            int gGHP2 = GetGGHP2();

            int damage = attribute.Attack(3, 7);

            gGHP -= damage;
            gGHP2 -= damage;

            if (gGHP < 0 && gGHP2 < 0)
            {
                gGHP = 0;
                gGHP2 = 0;
            }

            lbBatman.Text = gGHP.ToString();
            lbSuperman.Text = gGHP2.ToString();
            pbBatman.Value = gGHP;
            pbSuperman.Value = gGHP2;
            Saver2("B " + lbBatman.Text.ToString(), "S " + lbSuperman.Text.ToString(), "hs.txt");

        }

        private int GetBGHP()
        {
            return Convert.ToInt32(lbJoker.Text);
        }

        private int GetBGHP2()
        {
            return Convert.ToInt32(lbLuthor.Text);
        }

        private int GetGGHP()
        {
            return Convert.ToInt32(lbBatman.Text);
        }

        private int GetGGHP2()
        {
            return Convert.ToInt32(lbSuperman.Text);
        }

        private bool isBadGuyAlive()
        {
            return GetBGHP() > 0;
        }

        private bool isBadGuy2Alive()
        {
            return GetBGHP2() > 0;
        }

        private bool isGoodGuyAlive()
        {
            return GetGGHP() > 0;
        }

        private bool isGoodGuy2Alive()
        {
            return GetGGHP2() > 0;
        }

        //Display a we lost message
        private void WeLost()
        {
            btnAttack.Enabled = false;
            btnReset.Visible = true;
            btnReset.Text = "retry";
            MessageBox.Show("you lost better luck next time");
            textOUTPUT.Text = "OUR HERO wad defeated by THE VILLIAN" + "\r\n" + textOUTPUT.Text;
        }

        //Display a you won message
        private void YouWon()
        {
            MessageBox.Show("you won good job");
            textOUTPUT.Text = "OUR HERO KILLED THE VILLIAN" + "\r\n" + textOUTPUT.Text;
            btnAttack.Enabled = false;
            btnReset.Visible = true;
            btnReset.Text = "Continue??";
        }

        //reset the game
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Continue();
                if (GetGGHP() == 0 && GetGGHP2() == 0)
                {
                    ResetGGS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetGGS()
        {
            lbBatman.Text = batman.PowerLevel;
            lbSuperman.Text = superman.PowerLevel;
            pbBatman.Value = 100;
            pbSuperman.Value = 100;
        }

        private void Continue()
        {
            lbJoker.Text = joker.PowerLevel;
            lbLuthor.Text = luthor.PowerLevel;
            pbJoker.Value = 100;
            pbLuthor.Value = 100;
            btnReset.Visible = false;
            btnAttack.Enabled = true;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            count2 += 1;
            if (count2 == 5)
            {
                this.Hide();
                MapForm mf = new MapForm();
                mf.Show();
            }

            GoodGuyTurn();
            if (!isBadGuyAlive() && !isBadGuy2Alive())
            {
                //winning
                YouWon();
            }
            else
            {
                BadGuyTurn();
                if (!isGoodGuyAlive() && !isGoodGuy2Alive())
                {
                    WeLost();
                }
            }
        }

        private void HVForm_Load(object sender, EventArgs e)
        {
            string path1 = cd + @"\savedfiles\hs.txt";
            if (File.Exists(path1))
            {
                List<string> hPower = Loader2("hs.txt");
                foreach (var value in hPower)
                {
                    if (value.Contains("S"))
                    {
                        int cs = Convert.ToInt32(value.Substring(1));
                        lbSuperman.Text = value.Substring(1);
                        pbSuperman.Value = cs;
                    }
                    else if (value.Contains("B"))
                    {
                        int cb = Convert.ToInt32(value.Substring(1));
                        lbBatman.Text = value.Substring(1);
                        pbBatman.Value = cb;
                    }

                }
            }

            string path2 = cd + @"\savedfiles\vs.txt";
            if (File.Exists(path2))
            {
                List<string> vPower = Loader2("vs.txt");
                foreach (var value in vPower)
                {
                    if (value.Contains("J"))
                    {
                        int cj = Convert.ToInt32(value.Substring(1));
                        lbJoker.Text = value.Substring(1);
                        pbJoker.Value = cj;
                    }
                    else if (value.Contains("L"))
                    {
                        int cl = Convert.ToInt32(value.Substring(1));
                        lbLuthor.Text = value.Substring(1);
                        pbLuthor.Value = cl;
                    }
                }
            }

        }
    }

}