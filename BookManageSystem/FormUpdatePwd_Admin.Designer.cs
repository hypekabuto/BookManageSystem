namespace BookManageSystem
{
    partial class FormUpdatePwd_Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOkPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(213, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPwd.Location = new System.Drawing.Point(345, 106);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(374, 50);
            this.txtOldPwd.TabIndex = 1;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd.Location = new System.Drawing.Point(345, 198);
            this.txtNewPwd.MaxLength = 7;
            this.txtNewPwd.Multiline = true;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(374, 51);
            this.txtNewPwd.TabIndex = 3;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(213, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "新密码";
            // 
            // txtOkPwd
            // 
            this.txtOkPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOkPwd.Location = new System.Drawing.Point(345, 296);
            this.txtOkPwd.MaxLength = 7;
            this.txtOkPwd.Name = "txtOkPwd";
            this.txtOkPwd.Size = new System.Drawing.Size(374, 50);
            this.txtOkPwd.TabIndex = 5;
            this.txtOkPwd.UseSystemPasswordChar = true;
            this.txtOkPwd.TextChanged += new System.EventHandler(this.txtNewPwdTextChangedByUI);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(195, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "确认密码";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(241, 408);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(149, 77);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "修改";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.Location = new System.Drawing.Point(570, 408);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(149, 77);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormUpdatePwd_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 606);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtOkPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUpdatePwd_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormUpdatePwd_Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOkPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
    }
}