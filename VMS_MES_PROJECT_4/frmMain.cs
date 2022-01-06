using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS_MES_PROJECT_4
{
    public partial class frmMain : Form
    {
        MenuDAC db = new MenuDAC();
        DataTable dtMenu;

        //string user ID;
        public frmMain()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MenuBinding();
        }

        private void MenuBinding()
        {
            dtMenu = db.GetMenuList();

            //DataView dv1 = new DataView(dtMenu);
            //dv1.RowFilter = "menu_level=1";
            //dv1.Sort = "menu_sort";

            //for(int i=0; i<dv1.Count; i++)
            //{
            //    TreeNode node = new TreeNode(dv1[i]())
            //}
        }


        //private void DrawMenuStrip(DataTable dtMenu)
        //{
        //    DataView dv1 = new DataView(dtMenu);
        //    dv1.RowFilter = "menu_level = 1";
        //    dv1.Sort = "menu_sort";
        //    for (int i = 0; i < dv1.Count; i++)
        //    {
        //        ToolStripMenuItem p_menu = new ToolStripMenuItem();
        //        p_menu.Name = $"p_menu{dv1[i]["menu_id"].ToString()}";
        //        p_menu.Text = dv1[i]["menu_name"].ToString();
        //        p_menu.Size = new Size(180, 22);

        //        DataView dv2 = new DataView(dtMenu);
        //        dv2.RowFilter = "menu_level = 2 and pnt_menu_id = " + dv1[i]["pnt_menu_id"].ToString();
        //        dv2.Sort = "menu_sort";
        //        for (int k = 0; k < dv2.Count; k++)
        //        {
        //            ToolStripMenuItem c_menu = new ToolStripMenuItem();
        //            c_menu.Name = $"p_menu{dv2[k]["menu_id"].ToString()}";
        //            c_menu.Text = dv2[k]["menu_name"].ToString();
        //            c_menu.Size = new Size(180, 22);
        //            c_menu.Click += Menu_Click;
        //            p_menu.DropDownItems.Add(c_menu);
        //        }

        //    }
        //}

        private void Menu_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            flowLayoutPanel1.Controls.SetChildIndex(panel1, Convert.ToInt32(btn.Tag.ToString().Split('@')[0]) + 1);
            flowLayoutPanel1.Invalidate();

            ShowSecondMenuList(btn);
        }

        private void ShowSecondMenuList(Button btn)
        {
            DataView dv1 = new DataView(dtMenu);
            dv1.RowFilter = "menu_level=2 and pnt_menu_id=" + btn.Tag.ToString().Split('@')[1];
            dv1.Sort = "menu_sort";

            //treeView1.Nodes.Clear();

            //for (int i = 0; i < dv1.Count; i++)
            //{
            //    TreeNode node = new TreeNode(dv1[i]["menu_name"].ToString());
            //    treeView1.Nodes.Add(node);
            //}

            panel1.Controls.Clear();

            for (int i = 0; i < dv1.Count; i++)
            {
                Button btnItem = new Button();
                btnItem.BackColor = System.Drawing.Color.Silver;
                btnItem.Dock = System.Windows.Forms.DockStyle.Top;
                btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                btnItem.ForeColor = System.Drawing.Color.White;
                btnItem.Location = new System.Drawing.Point(0, 0);
                btnItem.Margin = new System.Windows.Forms.Padding(0);
                btnItem.Name = "button7";
                btnItem.Size = new System.Drawing.Size(215, 36);    
                btnItem.TabIndex = 2;
                btnItem.Tag = dv1[i]["program_name"].ToString();
                btnItem.Text = dv1[i]["menu_name"].ToString();
                btnItem.UseVisualStyleBackColor = false;
                btnItem.Click += BtnItem_Click;

                panel1.Controls.Add(btnItem);  
            }
            
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OpenCreateForm(btn.Tag.ToString(), btn.Text);
        }

        private void OpenCreateForm(string pgmName, string formText)
        {
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{appName}.{pgmName}");

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                {
                    frm.Activate();
                    frm.BringToFront();
                    return;
                }
            }

            try
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = formText;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("등록된 프로그램이 존재하지 않습니다.");
            }
        }
    }
}
