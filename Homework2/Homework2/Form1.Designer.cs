namespace Homework2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.moveNodeButton = new System.Windows.Forms.Button();
            this.moveLineButton = new System.Windows.Forms.Button();
            this.deleteLineButton = new System.Windows.Forms.Button();
            this.addLineButton = new System.Windows.Forms.Button();
            this.editLineButton = new System.Windows.Forms.Button();
            this.deleteNodeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.editNodeButton = new System.Windows.Forms.Button();
            this.addNodeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.moveNodeButton);
            this.panel1.Controls.Add(this.deleteLineButton);
            this.panel1.Controls.Add(this.addLineButton);
            this.panel1.Controls.Add(this.editLineButton);
            this.panel1.Controls.Add(this.deleteNodeButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.editNodeButton);
            this.panel1.Controls.Add(this.addNodeButton);
            this.panel1.Controls.Add(this.moveLineButton);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6000, 6000);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            //
            // moveLineButton
            //
            this.moveLineButton.Location = new System.Drawing.Point(23, 307);
            this.moveLineButton.Name = "moveLineButton";
            this.moveLineButton.Size = new System.Drawing.Size(100, 23);
            this.moveLineButton.TabIndex = 8;
            this.moveLineButton.Text = "MoveLine";
            this.moveLineButton.UseVisualStyleBackColor = true;
            this.moveLineButton.Click += new System.EventHandler(this.moveLineButton_Click);
            // 
            // moveNodeButton
            // 
            this.moveNodeButton.Location = new System.Drawing.Point(23, 357);
            this.moveNodeButton.Name = "moveNodeButton";
            this.moveNodeButton.Size = new System.Drawing.Size(100, 23);
            this.moveNodeButton.TabIndex = 7;
            this.moveNodeButton.Text = "MoveNode";
            this.moveNodeButton.UseVisualStyleBackColor = true;
            this.moveNodeButton.Click += new System.EventHandler(this.moveNodeButton_Click);
            // 
            // deleteLineButton
            // 
            this.deleteLineButton.Location = new System.Drawing.Point(23, 257);
            this.deleteLineButton.Name = "deleteLineButton";
            this.deleteLineButton.Size = new System.Drawing.Size(100, 23);
            this.deleteLineButton.TabIndex = 6;
            this.deleteLineButton.Text = "DeleteLine";
            this.deleteLineButton.UseVisualStyleBackColor = true;
            this.deleteLineButton.Click += new System.EventHandler(this.deleteLineButton_Click);
            // 
            // addLineButton
            // 
            this.addLineButton.Location = new System.Drawing.Point(23, 207);
            this.addLineButton.Name = "addLineButton";
            this.addLineButton.Size = new System.Drawing.Size(100, 23);
            this.addLineButton.TabIndex = 5;
            this.addLineButton.Text = "AddLine";
            this.addLineButton.UseVisualStyleBackColor = true;
            this.addLineButton.Click += new System.EventHandler(this.addLineButton_Click);
            // 
            // editLineButton
            // 
            this.editLineButton.Location = new System.Drawing.Point(23, 157);
            this.editLineButton.Name = "editLineButton";
            this.editLineButton.Size = new System.Drawing.Size(100, 23);
            this.editLineButton.TabIndex = 4;
            this.editLineButton.Text = "EditLine";
            this.editLineButton.UseVisualStyleBackColor = true;
            this.editLineButton.Click += new System.EventHandler(this.editLineButton_Click);
            // 
            // deleteNodeButton
            // 
            this.deleteNodeButton.Location = new System.Drawing.Point(23, 107);
            this.deleteNodeButton.Name = "deleteNodeButton";
            this.deleteNodeButton.Size = new System.Drawing.Size(100, 23);
            this.deleteNodeButton.TabIndex = 3;
            this.deleteNodeButton.Text = "DeleteNode";
            this.deleteNodeButton.UseVisualStyleBackColor = true;
            this.deleteNodeButton.Click += new System.EventHandler(this.deleteNodeButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 407);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // editNodeButton
            // 
            this.editNodeButton.Location = new System.Drawing.Point(23, 57);
            this.editNodeButton.Name = "editNodeButton";
            this.editNodeButton.Size = new System.Drawing.Size(100, 23);
            this.editNodeButton.TabIndex = 1;
            this.editNodeButton.Text = "EditNode";
            this.editNodeButton.UseVisualStyleBackColor = true;
            this.editNodeButton.Click += new System.EventHandler(this.editNodeButton_Click);
            // 
            // addNodeButton
            // 
            this.addNodeButton.Location = new System.Drawing.Point(23, 7);
            this.addNodeButton.Name = "addNodeButton";
            this.addNodeButton.Size = new System.Drawing.Size(100, 23);
            this.addNodeButton.TabIndex = 0;
            this.addNodeButton.Text = "AddNode";
            this.addNodeButton.UseVisualStyleBackColor = true;
            this.addNodeButton.Click += new System.EventHandler(this.addNodeButton_Click);
 
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addNodeButton;
        private System.Windows.Forms.Button editNodeButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button deleteNodeButton;
        private System.Windows.Forms.Button editLineButton;
        private System.Windows.Forms.Button addLineButton;
        private System.Windows.Forms.Button deleteLineButton;
        private System.Windows.Forms.Button moveNodeButton;
        private System.Windows.Forms.Button moveLineButton;
    }
}

