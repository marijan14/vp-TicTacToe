using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proekt
{
    public partial class Form2 : Form
    {
        static String p1, p2;
        private Form1 f1;
        int count = 0;
        bool turn = true;

        public Form2()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Marijan Gajdov 131165", "About");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            count = 0;
            a1.Enabled = true;
            a1.Text = "";
            a2.Enabled = true;
            a2.Text = "";
            a3.Enabled = true;
            a3.Text = "";
            b1.Enabled = true;
            b1.Text = "";
            b2.Enabled = true;
            b2.Text = "";
            b3.Enabled = true;
            b3.Text = "";
            c1.Enabled = true;
            c1.Text = "";
            c2.Enabled = true;
            c2.Text = "";
            c3.Enabled = true;
            c3.Text = "";
        }

        public static void setNames(String a, String b)
        {
            p1 = a;
            p2 = b;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void game(object o)
        {
            Button btn = (Button)o;
            if (turn)
                btn.Text = "X";
            else
                btn.Text = "O";
            count++;
            turn = !turn;
            btn.Enabled = false;
        }

        private void check()
        {
            bool flag = false;

            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
                flag = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                flag = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
                flag = true;
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                flag = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                flag = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                flag = true;
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                flag = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
                flag = true;

            if (flag)
            {
                disable();
                String s = "";
                if (turn)
                {
                    s = p2;
                    p2_wins.Text = (Int32.Parse(p2_wins.Text) + 1).ToString();
                }
                else
                {
                    s = p1;
                    p1_wins.Text = (Int32.Parse(p1_wins.Text) + 1).ToString();
                }
                MessageBox.Show(s + " Wins!", "Result");
            }
            else
            {
                if (count == 9)
                {
                    draw.Text = (Int32.Parse(p2_wins.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Result");
                }
            }
        }

        private void disable()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button btn = (Button)c;
                    btn.Enabled = false;
                }
                catch { }
            }
        }

        private void Universal_Click(object sender, EventArgs e)
        {
            game(sender);
            check();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            f1 = new Form1();
            label1.Text = p1;
            label3.Text = p2;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            p1_wins.Text = "0";
            p2_wins.Text = "0";
            draw.Text = "0";
        }
    }
}
