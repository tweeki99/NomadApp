namespace NomadAppWf
{
    partial class FormAccount
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
            this.LabelSubscriptionStatus = new System.Windows.Forms.Label();
            this.ButtonSubscribe = new System.Windows.Forms.Button();
            this.LabelDetails = new System.Windows.Forms.Label();
            this.ButtonDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelSubscriptionStatus
            // 
            this.LabelSubscriptionStatus.AutoSize = true;
            this.LabelSubscriptionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSubscriptionStatus.Location = new System.Drawing.Point(25, 26);
            this.LabelSubscriptionStatus.Name = "LabelSubscriptionStatus";
            this.LabelSubscriptionStatus.Size = new System.Drawing.Size(323, 39);
            this.LabelSubscriptionStatus.TabIndex = 4;
            this.LabelSubscriptionStatus.Text = "У вас нет подписки";
            // 
            // ButtonSubscribe
            // 
            this.ButtonSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSubscribe.Location = new System.Drawing.Point(32, 118);
            this.ButtonSubscribe.Name = "ButtonSubscribe";
            this.ButtonSubscribe.Size = new System.Drawing.Size(259, 70);
            this.ButtonSubscribe.TabIndex = 5;
            this.ButtonSubscribe.Text = "Оформить подписку";
            this.ButtonSubscribe.UseVisualStyleBackColor = true;
            this.ButtonSubscribe.Click += new System.EventHandler(this.ButtonSubscribeClick);
            // 
            // LabelDetails
            // 
            this.LabelDetails.AutoSize = true;
            this.LabelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelDetails.Location = new System.Drawing.Point(456, 26);
            this.LabelDetails.Name = "LabelDetails";
            this.LabelDetails.Size = new System.Drawing.Size(332, 80);
            this.LabelDetails.TabIndex = 6;
            this.LabelDetails.Text = "К вам едет очередное издание!\r\n\r\nПожалуйста, подтвердите получение \r\nкак только о" +
    "н окажется у вас";
            // 
            // ButtonDetails
            // 
            this.ButtonDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonDetails.Location = new System.Drawing.Point(460, 118);
            this.ButtonDetails.Name = "ButtonDetails";
            this.ButtonDetails.Size = new System.Drawing.Size(328, 70);
            this.ButtonDetails.TabIndex = 7;
            this.ButtonDetails.Text = "Подробнее";
            this.ButtonDetails.UseVisualStyleBackColor = true;
            this.ButtonDetails.Click += new System.EventHandler(this.ButtonDetailsClick);
            // 
            // FormAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 229);
            this.Controls.Add(this.ButtonDetails);
            this.Controls.Add(this.LabelDetails);
            this.Controls.Add(this.ButtonSubscribe);
            this.Controls.Add(this.LabelSubscriptionStatus);
            this.Name = "FormAccount";
            this.Text = "FormAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelSubscriptionStatus;
        private System.Windows.Forms.Button ButtonSubscribe;
        private System.Windows.Forms.Label LabelDetails;
        private System.Windows.Forms.Button ButtonDetails;
    }
}