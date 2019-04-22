namespace NomadAppWf.Admin
{
    partial class FormMain
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
            this.ButtonAddEdition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonAddEdition
            // 
            this.ButtonAddEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonAddEdition.Location = new System.Drawing.Point(68, 51);
            this.ButtonAddEdition.Name = "ButtonAddEdition";
            this.ButtonAddEdition.Size = new System.Drawing.Size(325, 64);
            this.ButtonAddEdition.TabIndex = 0;
            this.ButtonAddEdition.Text = "Добавить новое издание";
            this.ButtonAddEdition.UseVisualStyleBackColor = true;
            this.ButtonAddEdition.Click += new System.EventHandler(this.ButtonAddEditionClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.ButtonAddEdition);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonAddEdition;
    }
}

