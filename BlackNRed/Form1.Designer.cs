namespace BlackNRed
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.button_Insert = new System.Windows.Forms.Button();
			this.button_Delete = new System.Windows.Forms.Button();
			this.button_Find = new System.Windows.Forms.Button();
			this.textBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox.Location = new System.Drawing.Point(12, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(1024, 350);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// button_Insert
			// 
			this.button_Insert.Location = new System.Drawing.Point(1087, 95);
			this.button_Insert.Name = "button_Insert";
			this.button_Insert.Size = new System.Drawing.Size(120, 40);
			this.button_Insert.TabIndex = 1;
			this.button_Insert.Text = "Добавить";
			this.button_Insert.UseVisualStyleBackColor = true;
			this.button_Insert.Click += new System.EventHandler(this.button_Insert_Click);
			// 
			// button_Delete
			// 
			this.button_Delete.Location = new System.Drawing.Point(1087, 162);
			this.button_Delete.Name = "button_Delete";
			this.button_Delete.Size = new System.Drawing.Size(120, 40);
			this.button_Delete.TabIndex = 2;
			this.button_Delete.Text = "Удалить";
			this.button_Delete.UseVisualStyleBackColor = true;
			this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
			// 
			// button_Find
			// 
			this.button_Find.Location = new System.Drawing.Point(1087, 233);
			this.button_Find.Name = "button_Find";
			this.button_Find.Size = new System.Drawing.Size(120, 40);
			this.button_Find.TabIndex = 3;
			this.button_Find.Text = "Найти";
			this.button_Find.UseVisualStyleBackColor = true;
			this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(312, 217);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(128, 22);
			this.textBox.TabIndex = 4;
			this.textBox.Text = "введите значение";
			this.textBox.Visible = false;
			this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
			this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1250, 442);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.button_Find);
			this.Controls.Add(this.button_Delete);
			this.Controls.Add(this.button_Insert);
			this.Controls.Add(this.pictureBox);
			this.Name = "Form1";
			this.Text = "Красно-чёрные деревья";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button button_Insert;
		private System.Windows.Forms.Button button_Delete;
		private System.Windows.Forms.Button button_Find;
		private System.Windows.Forms.TextBox textBox;
	}
}

