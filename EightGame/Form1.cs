using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightGame
{
    public partial class GameEight : Form
    {

        public int[,] lastPosition = new int[3, 3] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
        public int[,] firstPosition = new int[3, 3]{ { 2, 8, 3 }, { 1, 6, 4 }, { 7, 0, 5 } };       
        public List<string> gameWinningPath = new List<string>();
        public List<int[,]> check = new List<int[,]>();
        List<Matrix> list = new List<Matrix>();
        int index = 0;
        public GameEight()
        {
            InitializeComponent();
            button11.Text += char.ConvertFromUtf32(8629);
        }

        private void SolveGameEight_Click(object sender, EventArgs e)
        {
            if (checkIfAvailable())
            {
                Matrix m1 = new Matrix();
                m1.matrixPosition = firstPosition;
                list.Add(m1);
                while (true)
                {
                    if (equalMatrix(list.First().matrixPosition))
                    {
                        gameWinningPath = list.First().path;
                        break;
                    }
                    Matrix m2 = new Matrix();
                    Matrix m3 = new Matrix();
                    Matrix m4 = new Matrix();
                    Matrix m5 = new Matrix();
                    list.First().clone(m2);
                    list.First().clone(m3);
                    list.First().clone(m4);
                    list.First().clone(m5);

                    m2.findZero();
                    m2.availableMoves();
                    if (m2.leftMove)
                    {
                        m2.moveLeft();
                        list.Add(m2);
                    }

                    m3.findZero();
                    m3.availableMoves();
                    if (m3.rightMove)
                    {
                        m3.moveRight();
                        list.Add(m3);
                    }

                    m4.findZero();
                    m4.availableMoves();
                    if (m4.upMove)
                    {
                        m4.moveUp();
                        list.Add(m4);
                    }

                    m5.findZero();
                    m5.availableMoves();
                    if (m5.downMove)
                    {
                        m5.moveDown();
                        list.Add(m5);
                    }
                    list.Remove(list.First());
                }
                printMatrix(firstPosition);
                button10.Text += char.ConvertFromUtf32(8594);
                add(check, firstPosition);
                checkedListBox1.Items.Add("საწყისი მდგომარეობა", true);
                button11.Enabled = true;
                #region properties
                checkedListBox1.Visible = true;
                SolveGameEight.Enabled = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox14.ReadOnly = true;
                textBox15.ReadOnly = true;
                textBox16.ReadOnly = true;
                textBox17.ReadOnly = true;
                textBox18.ReadOnly = true;
                #endregion
            }

        }
        private void button10_Click(object sender, EventArgs e)
        {
            Matrix m = new Matrix();
            m.matrixPosition=firstPosition;          
            switch (gameWinningPath.First())
            {
                case "left":
                    m.moveLeft();
                    add(check,m.matrixPosition);
                    printMatrix(m.matrixPosition);
                    break;
                case "right":
                    m.moveRight();
                    add(check, m.matrixPosition);
                    printMatrix(m.matrixPosition);
                    break;              
                case "down":
                    m.moveDown();
                    add(check, m.matrixPosition);
                    printMatrix(m.matrixPosition);
                    break;
                case  "up":
                    m.moveUp();
                    add(check, m.matrixPosition);
                    printMatrix(m.matrixPosition);
                    break;
                default:
                    break;
            }
            var items=checkedListBox1.Items;
            items.Add(index+1+" ბიჯი",true);
            index++;
            gameWinningPath.Remove(gameWinningPath.First());
            if (gameWinningPath.Count == 0)
            {
                button10.Enabled=false;
                textBox19.Text += index.ToString();
                textBox19.Text += " ბიჯი";
                textBox19.Visible = true;
            }
        }
        #region needFunctions  
        public bool checkIfAvailable()
        {
            for(int i=0;i<3;i++)
                for (int j = 0; j < 3; j++)
                {
                    if(firstPosition[i,j]>8 || lastPosition[i,j]>8)
                        goto foo;
                    if( firstPosition[i,j].GetType()!=typeof(int))
                        goto foo;
                    if (lastPosition[i, j].GetType() != typeof(int))
                        goto foo;
                    int q = firstPosition[i, j];
                    int q2 = lastPosition[i, j];
                    for (int i1 = 0; i1 < 3; i1++)
                        for (int j1 = 0; j1 < 3; j1++)
                            if (i1!=i || j1!=j){
                                if (q == firstPosition[i1, j1])
                                {
                                    goto foo;
                                }
                                if (q2 == lastPosition[i1, j1])
                                    goto foo;
                            }
                }
            return true;
        foo:
            var result = MessageBox.Show("შეცდომაა შეყვანის დროს! გთხოვთ შეიყვანოთ თავიდან!!!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Application.Restart();
            }
            
            return false;
        }
        public void add(List<int[,]> m, int[,] m2)
        {
            int[,] s=new int[3,3];
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++)
            {
                s[i,j]=m2[i,j];
            }
            m.Add(s);
        }
        public void printMatrix(int[,] matrix)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;

            button1.Text = matrix[0, 0].ToString();
            button2.Text = matrix[0, 1].ToString();
            button3.Text = matrix[0, 2].ToString();
            button4.Text = matrix[1, 0].ToString();
            button5.Text = matrix[1, 1].ToString();
            button6.Text = matrix[1, 2].ToString();
            button7.Text = matrix[2, 0].ToString();
            button8.Text = matrix[2, 1].ToString();
            button9.Text = matrix[2, 2].ToString();
        }
        public bool equalMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] != lastPosition[i, j])
                        return false;

                }
            return true;
        }
        #endregion

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                if (i != e.Index) checkedListBox1.SetItemChecked(i, false);
            foreach (int[,] m in check)
            {
                if (check.IndexOf(m) == e.Index)
                {
                    printMatrix(m);
                    break;
                }
            }
        }
        #region sets
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if(t.Text!="")
                firstPosition[0, 0] = int.Parse(t.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[0, 1] = int.Parse(t.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[0, 2] = int.Parse(t.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[1, 0] = int.Parse(t.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[1, 1] = int.Parse(t.Text);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[1, 2] = int.Parse(t.Text);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[2, 0] = int.Parse(t.Text);

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[2, 1] = int.Parse(t.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            firstPosition[2, 2] = int.Parse(t.Text);
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[0, 0] = int.Parse(t.Text);

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[0, 1] = int.Parse(t.Text);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[0, 2] = int.Parse(t.Text);
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[1, 0] = int.Parse(t.Text);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[1, 1] = int.Parse(t.Text);
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[1, 2] = int.Parse(t.Text);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[2, 0] = int.Parse(t.Text);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[2, 1] = int.Parse(t.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text != "")
            lastPosition[2, 2] = int.Parse(t.Text);
        }
        #endregion

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void GameEight_Load(object sender, EventArgs e)
        {
        }
    }
}
