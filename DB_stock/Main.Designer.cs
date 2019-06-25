namespace DB_stock
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetUrl = new System.Windows.Forms.Button();
            this.URL_BOX = new System.Windows.Forms.TextBox();
            this.KOSPI = new System.Windows.Forms.Button();
            this.KOSDAQ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetUrl
            // 
            this.GetUrl.Location = new System.Drawing.Point(515, 28);
            this.GetUrl.Name = "GetUrl";
            this.GetUrl.Size = new System.Drawing.Size(75, 23);
            this.GetUrl.TabIndex = 0;
            this.GetUrl.Text = "Start";
            this.GetUrl.UseVisualStyleBackColor = true;
            this.GetUrl.Click += new System.EventHandler(this.button1_Click);
            // 
            // URL_BOX
            // 
            this.URL_BOX.Location = new System.Drawing.Point(30, 29);
            this.URL_BOX.Name = "URL_BOX";
            this.URL_BOX.Size = new System.Drawing.Size(479, 21);
            this.URL_BOX.TabIndex = 1;
            // 
            // KOSPI
            // 
            this.KOSPI.Location = new System.Drawing.Point(434, 66);
            this.KOSPI.Name = "KOSPI";
            this.KOSPI.Size = new System.Drawing.Size(75, 23);
            this.KOSPI.TabIndex = 2;
            this.KOSPI.Text = "KOSPI";
            this.KOSPI.UseVisualStyleBackColor = true;
            this.KOSPI.Click += new System.EventHandler(this.KOSPI_Click);
            // 
            // KOSDAQ
            // 
            this.KOSDAQ.Location = new System.Drawing.Point(515, 66);
            this.KOSDAQ.Name = "KOSDAQ";
            this.KOSDAQ.Size = new System.Drawing.Size(75, 23);
            this.KOSDAQ.TabIndex = 3;
            this.KOSDAQ.Text = "KOSDAQ";
            this.KOSDAQ.UseVisualStyleBackColor = true;
            this.KOSDAQ.Click += new System.EventHandler(this.KOSDAQ_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 257);
            this.Controls.Add(this.KOSDAQ);
            this.Controls.Add(this.KOSPI);
            this.Controls.Add(this.URL_BOX);
            this.Controls.Add(this.GetUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetUrl;
        private System.Windows.Forms.TextBox URL_BOX;
        private System.Windows.Forms.Button KOSPI;
        private System.Windows.Forms.Button KOSDAQ;
    }
}

