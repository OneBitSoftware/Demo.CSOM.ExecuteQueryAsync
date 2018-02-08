namespace Client.WinForms32.Standard
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
            this.btnSynchronousTask = new System.Windows.Forms.Button();
            this.btnAsynchronousTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSynchronousTask
            // 
            this.btnSynchronousTask.Location = new System.Drawing.Point(79, 62);
            this.btnSynchronousTask.Name = "btnSynchronousTask";
            this.btnSynchronousTask.Size = new System.Drawing.Size(75, 23);
            this.btnSynchronousTask.TabIndex = 0;
            this.btnSynchronousTask.Text = "Sync Work";
            this.btnSynchronousTask.UseVisualStyleBackColor = true;
            this.btnSynchronousTask.Click += new System.EventHandler(this.btnSynchronousTask_Click);
            // 
            // btnAsynchronousTask
            // 
            this.btnAsynchronousTask.Location = new System.Drawing.Point(270, 62);
            this.btnAsynchronousTask.Name = "btnAsynchronousTask";
            this.btnAsynchronousTask.Size = new System.Drawing.Size(75, 23);
            this.btnAsynchronousTask.TabIndex = 1;
            this.btnAsynchronousTask.Text = "Async Task";
            this.btnAsynchronousTask.UseVisualStyleBackColor = true;
            this.btnAsynchronousTask.Click += new System.EventHandler(this.btnAsynchronousTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time:";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.AutoSize = true;
            this.lblTimeValue.Location = new System.Drawing.Point(116, 22);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(0, 13);
            this.lblTimeValue.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 261);
            this.Controls.Add(this.lblTimeValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsynchronousTask);
            this.Controls.Add(this.btnSynchronousTask);
            this.Name = "Form1";
            this.Text = "IO-bound operations and thread blocking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSynchronousTask;
        private System.Windows.Forms.Button btnAsynchronousTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTimeValue;
    }
}

