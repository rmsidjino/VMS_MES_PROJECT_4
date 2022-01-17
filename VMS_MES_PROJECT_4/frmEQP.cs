using log4net.Core;
using MESDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS_MES_PROJECT_4
{
    public partial class frmEQP : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<EquipmentVO> eqplist;
        List<CommonVO> com;
        UserVO CurrentUser;

        public frmEQP(UserVO CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private void frmEQP_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvEQP);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "현장ID", "SITE_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "라인ID", "LINE_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "장비ID", "EQP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "장비 모델", "EQP_MODEL", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "장비타입", "EQP_TYPE", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "공정 그룹", "EQP_GROUP", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "시뮬레이션 타입", "SIM_TYPE", DataGridViewContentAlignment.MiddleCenter, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "사전 설정ID", "PRESET_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "비상배치타입", "DISPATCHER_TYPE", DataGridViewContentAlignment.MiddleCenter, colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "장비 가동 상태", "EQP_STATE", DataGridViewContentAlignment.MiddleCenter, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "장비 가동 코드", "EQP_STATE_CODE", DataGridViewContentAlignment.MiddleRight, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "장비 가동 변경 시간", "STATE_CHANGE_TIME", DataGridViewContentAlignment.MiddleRight, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQP, "자동화", "AUTOMATION", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            if (CurrentUser.IsAdmin == "관리자" || CurrentUser.IsAdmin == "마스터관리자")
            {
                btnEdit.Text = "수정";
                btnEdit.Width = 50;
                btnEdit.UseColumnTextForButtonValue = true;
                btnEdit.Name = "Edit";
                editIndex = dgvEQP.Columns.Add(btnEdit);
            }
            else
            {
                btnCreate.Enabled = false;
                btnDelete.Enabled = false;
            }
            LoadData();

        }
        private async void LoadData()
        {
            eqplist = null;
            eqplist = await srv.GetListAsync("api/Equipment/Equipments", eqplist);
            dgvEQP.DataSource = eqplist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            
            CommonUtil.ComboBinding(cboLineID, com, "LINE", blankText: "선택");
            CommonUtil.ComboBinding(cboSiteID, com, "SITE", blankText: "선택");
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupEQP_reg frm = new PopupEQP_reg();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEQP.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 설비를 선택하여 주십시오.");
                return;
            }

            string eqpID = dgvEQP.SelectedRows[0].Cells["EQP_ID"].Value.ToString();

            if (MessageBox.Show("설비 관리 데이터에 영향이 있습니다. 정말 삭제하실겁니까?", "설비 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Equipment/DelEquipment/{eqpID}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
                //_logging.WriteInfo(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string siteID = " ";
            if (cboSiteID.SelectedIndex > 0)
                siteID = cboSiteID.SelectedValue.ToString();

            string lineID = " ";
            if (cboLineID.SelectedIndex > 0)
                lineID = cboLineID.SelectedValue.ToString();

            eqplist = await srv.GetAsync($"api/Equipment/SearchEquipment/{siteID}/{lineID}/", eqplist);
            dgvEQP.DataSource = null;
            dgvEQP.DataSource = eqplist;
        }

        private void dgvEQP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {               
                string eqpID = dgvEQP["EQP_ID", e.RowIndex].Value.ToString();
                EquipmentVO eitem = eqplist.Find((equipment) => equipment.EQP_ID == eqpID);
                PopupEQP_reg frm = new PopupEQP_reg(eitem);             
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadData();
            }         
        }
    }
}
