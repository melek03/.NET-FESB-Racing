namespace excel_reader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_Load = new Button();
            textBox = new TextBox();
            label1 = new Label();
            data_Grid = new DataGridView();
            btn_Clear = new Button();
            ((System.ComponentModel.ISupportInitialize)data_Grid).BeginInit();
            SuspendLayout();
            // 
            // btn_Load
            // 
            btn_Load.Location = new Point(1232, 72);
            btn_Load.Name = "btn_Load";
            btn_Load.Size = new Size(150, 39);
            btn_Load.TabIndex = 0;
            btn_Load.Text = "Load";
            btn_Load.UseVisualStyleBackColor = true;
            btn_Load.Click += button1_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(248, 72);
            textBox.Name = "textBox";
            textBox.Size = new Size(960, 39);
            textBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 72);
            label1.Name = "label1";
            label1.Size = new Size(90, 32);
            label1.TabIndex = 2;
            label1.Text = "Search:";
            // 
            // data_Grid
            // 
            data_Grid.BackgroundColor = Color.FromArgb(224, 224, 224);
            data_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_Grid.Location = new Point(144, 160);
            data_Grid.Name = "data_Grid";
            data_Grid.RowHeadersWidth = 82;
            data_Grid.Size = new Size(1240, 608);
            data_Grid.TabIndex = 3;
            // 
            // btn_Clear
            // 
            btn_Clear.Location = new Point(144, 792);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(150, 39);
            btn_Clear.TabIndex = 4;
            btn_Clear.Text = "Clear";
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 868);
            Controls.Add(btn_Clear);
            Controls.Add(data_Grid);
            Controls.Add(label1);
            Controls.Add(textBox);
            Controls.Add(btn_Load);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Excel data viewer";
            ((System.ComponentModel.ISupportInitialize)data_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Load;
        private TextBox textBox;
        private Label label1;
        private DataGridView data_Grid;
        private Button btn_Clear;
    }
}
