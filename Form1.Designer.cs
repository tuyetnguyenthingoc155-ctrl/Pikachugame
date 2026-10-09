namespace Pikachu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBoard = new System.Windows.Forms.Panel();
            this.bxh = new System.Windows.Forms.Button();
            this.choilai = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.diem = new System.Windows.Forms.Label();
            this.diemkyluc = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.Controls.Add(this.bxh);
            this.panelBoard.Controls.Add(this.choilai);
            this.panelBoard.Controls.Add(this.time);
            this.panelBoard.Controls.Add(this.diem);
            this.panelBoard.Controls.Add(this.diemkyluc);
            this.panelBoard.Location = new System.Drawing.Point(4, 4);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(790, 105);
            this.panelBoard.TabIndex = 0;
            // 
            // bxh
            // 
            this.bxh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bxh.Location = new System.Drawing.Point(454, 15);
            this.bxh.Name = "bxh";
            this.bxh.Size = new System.Drawing.Size(177, 75);
            this.bxh.TabIndex = 4;
            this.bxh.Text = "Bảng Xếp Hạng";
            this.bxh.UseVisualStyleBackColor = true;
            // 
            // choilai
            // 
            this.choilai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choilai.Location = new System.Drawing.Point(647, 16);
            this.choilai.Name = "choilai";
            this.choilai.Size = new System.Drawing.Size(126, 74);
            this.choilai.TabIndex = 3;
            this.choilai.Text = "Chơi Lại";
            this.choilai.UseVisualStyleBackColor = true;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.Red;
            this.time.Location = new System.Drawing.Point(257, 20);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(132, 25);
            this.time.TabIndex = 2;
            this.time.Text = "Thời gian: 0";
            // 
            // diem
            // 
            this.diem.AutoSize = true;
            this.diem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.diem.Location = new System.Drawing.Point(10, 67);
            this.diem.Name = "diem";
            this.diem.Size = new System.Drawing.Size(90, 25);
            this.diem.TabIndex = 1;
            this.diem.Text = "Điểm: 0";
            // 
            // diemkyluc
            // 
            this.diemkyluc.AutoSize = true;
            this.diemkyluc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.diemkyluc.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diemkyluc.ForeColor = System.Drawing.Color.Indigo;
            this.diemkyluc.Location = new System.Drawing.Point(8, 15);
            this.diemkyluc.Name = "diemkyluc";
            this.diemkyluc.Size = new System.Drawing.Size(204, 32);
            this.diemkyluc.TabIndex = 0;
            this.diemkyluc.Text = "Điểm Kỷ Lục: 0";
            // 
            // panelMiddle
            // 
            this.panelMiddle.Location = new System.Drawing.Point(6, 121);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(787, 374);
            this.panelMiddle.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelBoard.ResumeLayout(false);
            this.panelBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Button bxh;
        private System.Windows.Forms.Button choilai;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label diem;
        private System.Windows.Forms.Label diemkyluc;
        private System.Windows.Forms.Panel panelMiddle;
    }
}

