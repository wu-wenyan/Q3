using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文彥_Q3
{

    public partial class Form1 : Form
    {
        private const int SquareSize = 60;
        private const int PanelSize = 240;
        private bool s = false;
        private Random random = new Random();
        private Color lastRightSquareColor = Color.White; // 保存上一次右邊大正方形的顏色
        private Color[] rightSquareColors = new Color[16];




        public Form1()
        {
            InitializeComponent();
        }


        private Panel CreatePanel()
        {
            Panel panel = new Panel();
            panel.Size = new Size(240, 240);
            panel.BorderStyle = BorderStyle.FixedSingle;
            return panel;
        }
        private void InitializeSquares(Panel panel, string tag)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ListView square = CreateSquare();
                    square.Location = new Point(j * SquareSize, i * SquareSize);
                    square.Tag = tag;
                    panel.Controls.Add(square);
                }
            }
        }
        private ListView CreateSquare()
        {
            ListView listView = new ListView();
            listView.Size = new Size(SquareSize, SquareSize);
            listView.View = View.Details;
            listView.GridLines = false;
            listView.BorderStyle = BorderStyle.None; // 設置邊框樣式為None
            listView.BackColor = Color.White; // 初始顏色為白色

            return listView;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void Random_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Control control in Right.Controls)
            {
                if (control is ListView square)
                {
                    // 生成隨機的 RGB 值
                    int red = random.Next(256);
                    int green = random.Next(256);
                    int blue = random.Next(256);
                    
                    // 創建隨機顏色
                    Color randomColor = Color.FromArgb(red, green, blue);

                    // 將正方形的背景顏色設置為隨機顏色
                    rightSquareColors[i] = square.BackColor;
                    square.BackColor = randomColor;
                    i++;
                }
            }
            left_colors();
            s = true;
                       
        }
    
        private void left_colors()
        {
            if (s)
            {
                int i = 0;
                foreach (Control control in Left.Controls)
                {
                    if (control is ListView square)
                    {
                        square.BackColor = rightSquareColors[i];
                        i++;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Hor_Flip_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Position = new Point(listView1.Width - item.Position.X - item.Bounds.Width, item.Position.Y);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
