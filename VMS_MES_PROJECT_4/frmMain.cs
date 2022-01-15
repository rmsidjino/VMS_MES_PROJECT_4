using MESDTO;
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
        public UserVO CurrentUser { get; set; }
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
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                //메인화면 코딩 시작
                //로그인 성공한 사람의 권한에 따라서 다르게 메뉴를 보여준다.
                this.CurrentUser = login.CurrentUser;
            }
            else
            {
                Application.Exit();
            }

            MenuBinding();
            ucTabControl1.Visible = false;
        }
        private void OpenCreateForm(string prgName)
        {
            // 열려있는 폼들중에서 없으면 새로 만들어서 폼을 보여주고,
            // 이미 열려있는 폼이라면, 활성폼으로 만들어서 제일 앞으로 위치

            string appName = Assembly.GetEntryAssembly().GetName().Name;

            Type frmType = Type.GetType($"{appName}.{prgName}");
            //어셈블리명.클래스명

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == frmType)
                {
                    form.Activate(); //Activate 이벤트
                    form.BringToFront();
                    return;
                }
            }

            Form frm = (Form)Activator.CreateInstance(frmType,CurrentUser);
            frm.MdiParent = this;
            frm.Show(); //Load->Activate 이벤트
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            Button menu = (Button)sender;
            OpenCreateForm(menu.Tag.ToString());
        }
        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                ucTabControl1.Visible = false;
            }
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null)
                {
                    //탭페이지를 추가해서 탭컨트롤에 추가
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "   ");
                    tp.Parent = ucTabControl1;
                    tp.Tag = this.ActiveMdiChild;
                    ucTabControl1.SelectedTab = tp;

                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;

                    this.ActiveMdiChild.Tag = tp;
                }
                else
                {
                    ucTabControl1.SelectedTab = (TabPage)this.ActiveMdiChild.Tag;
                }

                if (!ucTabControl1.Visible)
                    ucTabControl1.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            ((TabPage)frm.Tag).Dispose();
        }

        private void ucTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucTabControl1.SelectedTab != null)
            {
                Form frm = (Form)ucTabControl1.SelectedTab.Tag;
                frm.Select();
            }
        }

       
        private void ucTabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ucTabControl1.TabPages.Count; i++)
            {
                var r = ucTabControl1.GetTabRect(i);
                var closeImage = Properties.Resources.close_grey;
                var closeRect = new Rectangle((r.Right - closeImage.Width), r.Top + (r.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (closeRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();
                    break;
                }
            }
        }
        private Control[] GetControls(Control con)
        {
            var conList = new List<Control>();
            foreach (Control control in con.Controls)
            {
                if (control is DataGridView)
                    conList.Add(control);

                if (control.Controls.Count > 0)
                    conList.AddRange(GetControls(control));
            }
            return conList.ToArray();
        }
        private void MenuBinding()
        {
            dtMenu = db.GetMenuList();

        }


        private void DrawMenuStrip(DataTable dtMenu)
        {
            DataView dv1 = new DataView(dtMenu);
            dv1.RowFilter = "menu_level = 1";
            dv1.Sort = "menu_sort";
            for (int i = 0; i < dv1.Count; i++)
            {
                ToolStripMenuItem p_menu = new ToolStripMenuItem();
                p_menu.Name = $"p_menu{dv1[i]["menu_id"].ToString()}";
                p_menu.Text = dv1[i]["menu_name"].ToString();
                p_menu.Size = new Size(180, 22);

                DataView dv2 = new DataView(dtMenu);
                dv2.RowFilter = "menu_level = 2 and pnt_menu_id = " + dv1[i]["pnt_menu_id"].ToString();
                dv2.Sort = "menu_sort";
                for (int k = 0; k < dv2.Count; k++)
                {
                    ToolStripMenuItem c_menu = new ToolStripMenuItem();
                    c_menu.Name = $"p_menu{dv2[k]["menu_id"].ToString()}";
                    c_menu.Text = dv2[k]["menu_name"].ToString();
                    c_menu.Size = new Size(180, 22);
                    c_menu.Click += Menu_Click;
                    p_menu.DropDownItems.Add(c_menu);
                }

            }
        }

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

           
            panel1.Controls.Clear();

            for (int i = 0; i < dv1.Count; i++)
            {
                Button btnItem = new Button();
                btnItem.BackColor = System.Drawing.Color.Silver;
                btnItem.Dock = System.Windows.Forms.DockStyle.Top;               
                btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                btnItem.ForeColor = System.Drawing.Color.Black;
                btnItem.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btnItem.Location = new System.Drawing.Point(0, 0);
                btnItem.Margin = new System.Windows.Forms.Padding(0);
                btnItem.Name = "button7";
                btnItem.Size = new System.Drawing.Size(218, 36);    
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
             

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "frmMain")
                {
                    Application.OpenForms[i].Close();
                }
            }
        }
    }
}
