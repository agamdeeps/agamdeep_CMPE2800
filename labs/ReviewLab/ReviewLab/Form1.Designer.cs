namespace ReviewLab
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
            this.label1 = new System.Windows.Forms.Label();
            this.UI_start_btn = new System.Windows.Forms.Button();
            this.UI_label = new System.Windows.Forms.Label();
            this.UI_Numeric_value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Numeric_value)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hands:";
            // 
            // UI_start_btn
            // 
            this.UI_start_btn.Location = new System.Drawing.Point(321, 53);
            this.UI_start_btn.Name = "UI_start_btn";
            this.UI_start_btn.Size = new System.Drawing.Size(75, 23);
            this.UI_start_btn.TabIndex = 2;
            this.UI_start_btn.Text = "GO!";
            this.UI_start_btn.UseVisualStyleBackColor = true;
            this.UI_start_btn.Click += new System.EventHandler(this.UI_start_btn_Click);
            // 
            // UI_label
            // 
            this.UI_label.Location = new System.Drawing.Point(43, 111);
            this.UI_label.Name = "UI_label";
            this.UI_label.Size = new System.Drawing.Size(353, 40);
            this.UI_label.TabIndex = 3;
            this.UI_label.Text = "label2";
            this.UI_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_Numeric_value
            // 
            this.UI_Numeric_value.Location = new System.Drawing.Point(157, 54);
            this.UI_Numeric_value.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.UI_Numeric_value.Name = "UI_Numeric_value";
            this.UI_Numeric_value.Size = new System.Drawing.Size(120, 22);
            this.UI_Numeric_value.TabIndex = 4;
            this.UI_Numeric_value.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(476, 204);
            this.Controls.Add(this.UI_Numeric_value);
            this.Controls.Add(this.UI_label);
            this.Controls.Add(this.UI_start_btn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UI_Numeric_value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UI_start_btn;
        private System.Windows.Forms.Label UI_label;
        private System.Windows.Forms.NumericUpDown UI_Numeric_value;
    }
}

