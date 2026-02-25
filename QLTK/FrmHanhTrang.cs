using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLTK;

public class FrmHanhTrang : Form
{
	private IContainer components = null;

	private DataGridView dgvList;

	public FrmHanhTrang()
	{
		InitializeComponent();
		TaoCot();
	}

	private void TaoCot()
	{
		dgvList.Columns.Clear();
		dgvList.AutoGenerateColumns = false;
		dgvList.RowHeadersVisible = false;
		dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn.DataPropertyName = "Id";
		dataGridViewTextBoxColumn.HeaderText = "ID";
		dataGridViewTextBoxColumn.Width = 40;
		dataGridViewTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dgvList.Columns.Add(dataGridViewTextBoxColumn);
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn2.DataPropertyName = "Name";
		dataGridViewTextBoxColumn2.HeaderText = "Tên Vật Phẩm";
		dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
		dataGridViewTextBoxColumn2.MinimumWidth = 120;
		dgvList.Columns.Add(dataGridViewTextBoxColumn2);
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn3.DataPropertyName = "Quantity";
		dataGridViewTextBoxColumn3.HeaderText = "SL";
		dataGridViewTextBoxColumn3.Width = 60;
		dataGridViewTextBoxColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dgvList.Columns.Add(dataGridViewTextBoxColumn3);
	}

	public void HienThiDuLieu(List<QLTK.ItemDisplay> danhSachItem)
	{
		dgvList.DataSource = null;
		dgvList.DataSource = danhSachItem;
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.dgvList = new System.Windows.Forms.DataGridView();
		((System.ComponentModel.ISupportInitialize)this.dgvList).BeginInit();
		base.SuspendLayout();
		this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvList.Location = new System.Drawing.Point(12, 5);
		this.dgvList.Name = "dgvList";
		this.dgvList.RowHeadersWidth = 51;
		this.dgvList.RowTemplate.Height = 24;
		this.dgvList.Size = new System.Drawing.Size(326, 433);
		this.dgvList.TabIndex = 0;
		this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(351, 450);
		base.Controls.Add(this.dgvList);
		base.Name = "FrmHanhTrang";
		this.Text = "FrmHanhTrang";
		((System.ComponentModel.ISupportInitialize)this.dgvList).EndInit();
		base.ResumeLayout(false);
	}
}
