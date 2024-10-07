namespace TaskManagementSystem
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Deklaration der Steuerelemente
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelNewUser;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonExportCSV;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Label labelZurichTime;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelNewUser = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.labelZurichTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 40);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(33, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Titel:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 66);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(72, 13);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Beschreibung:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 92);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(54, 13);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "Benutzer:";
            // 
            // labelNewUser
            // 
            this.labelNewUser.AutoSize = true;
            this.labelNewUser.Location = new System.Drawing.Point(12, 118);
            this.labelNewUser.Name = "labelNewUser";
            this.labelNewUser.Size = new System.Drawing.Size(83, 13);
            this.labelNewUser.TabIndex = 3;
            this.labelNewUser.Text = "Neuer Benutzer:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(100, 37);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(200, 20);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(100, 63);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(200, 20);
            this.textBoxDescription.TabIndex = 5;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(100, 89);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(200, 21);
            this.comboBoxUsers.TabIndex = 6;
            // 
            // textBoxNewUser
            // 
            this.textBoxNewUser.Location = new System.Drawing.Point(100, 115);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(200, 20);
            this.textBoxNewUser.TabIndex = 7;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(320, 35);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Erstellen";
            this.buttonCreate.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(320, 61);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Ändern";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(320, 87);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Löschen";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(320, 113);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 11;
            this.buttonAddUser.Text = "Benutzer hinzufügen";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(100, 141);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(200, 23);
            this.buttonDeleteUser.TabIndex = 12;
            this.buttonDeleteUser.Text = "Benutzer löschen";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Location = new System.Drawing.Point(320, 141);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(75, 23);
            this.buttonExportCSV.TabIndex = 13;
            this.buttonExportCSV.Text = "CSV Export";
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(15, 180);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.Size = new System.Drawing.Size(750, 220);
            this.dataGridViewTasks.TabIndex = 14;
            // 
            // labelZurichTime
            // 
            this.labelZurichTime.AutoSize = true;
            this.labelZurichTime.Location = new System.Drawing.Point(400, 10);
            this.labelZurichTime.Name = "labelZurichTime";
            this.labelZurichTime.Size = new System.Drawing.Size(80, 13);
            this.labelZurichTime.TabIndex = 15;
            this.labelZurichTime.Text = "Zurich Time:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.labelZurichTime);
            this.Controls.Add(this.dataGridViewTasks);
            this.Controls.Add(this.buttonExportCSV);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxNewUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelNewUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Task Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
