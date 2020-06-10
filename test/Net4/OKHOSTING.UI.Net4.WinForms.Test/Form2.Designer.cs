namespace OKHOSTING.UI.Net4.WinForms.Test
{
	partial class Form2
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
			this.transpCtrl1 = new OKHOSTING.UI.Net4.WinForms.Test.TranspCtrl();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// transpCtrl1
			// 
			this.transpCtrl1.BackColor = System.Drawing.Color.Maroon;
			this.transpCtrl1.Location = new System.Drawing.Point(551, 298);
			this.transpCtrl1.Name = "transpCtrl1";
			this.transpCtrl1.Opacity = 30;
			this.transpCtrl1.Size = new System.Drawing.Size(135, 93);
			this.transpCtrl1.TabIndex = 0;
			this.transpCtrl1.Text = "transpCtrl1";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Turquoise;
			this.button1.Location = new System.Drawing.Point(32, 110);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.transpCtrl1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

		}

		#endregion

		private TranspCtrl transpCtrl1;
		private System.Windows.Forms.Button button1;
	}
}