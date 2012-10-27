namespace SpookyVision
{
    partial class Spooky
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spooky));
            this.blink = new System.Windows.Forms.Timer(this.components);
            this.topMost = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // blink
            // 
            this.blink.Enabled = true;
            this.blink.Tick += new System.EventHandler(this.blink_Tick);
            // 
            // topMost
            // 
            this.topMost.Enabled = true;
            this.topMost.Interval = 10;
            this.topMost.Tick += new System.EventHandler(this.topMost_Tick);
            // 
            // Spooky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(116, 735);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.Name = "Spooky";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Spooky";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Spooky_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer blink;
        private System.Windows.Forms.Timer topMost;
    }
}