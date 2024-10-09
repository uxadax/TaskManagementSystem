namespace TaskManagementSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonCSVExport = new System.Windows.Forms.Button();
            this.buttonCSVImport = new System.Windows.Forms.Button();
            this.labelZurichTime = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelUserSelection = new System.Windows.Forms.Label();
            this.labelNewUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.Size = new System.Drawing.Size(776, 230);
            this.dataGridViewTasks.TabIndex = 0;

            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 270);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(120, 20);
            this.textBoxTitle.TabIndex = 1;

            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(150, 270);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(120, 20);
            this.textBoxDescription.TabIndex = 2;

            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(12, 340);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(120, 21);
            this.comboBoxUsers.TabIndex = 3;

            // 
            // textBoxNewUser
            // 
            this.textBoxNewUser.Location = new System.Drawing.Point(150, 340);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(120, 20);
            this.textBoxNewUser.TabIndex = 4;

            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(150, 370);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(120, 23);
            this.buttonAddUser.TabIndex = 8;
            this.buttonAddUser.Text = "Benutzer hinzufügen";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);

            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(12, 370);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(120, 23);
            this.buttonDeleteUser.TabIndex = 9;
            this.buttonDeleteUser.Text = "Benutzer löschen";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);

            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(700, 270);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 5;
            this.buttonCreate.Text = "Erstellen";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click); // Event-Zuordnung


            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(700, 300);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Ändern";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click); // Event-Zuordnung

            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(700, 330);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Löschen";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click); // Event-Zuordnung

            // 
            // buttonCSVExport
            // 
            this.buttonCSVExport.Location = new System.Drawing.Point(400, 270);
            this.buttonCSVExport.Name = "buttonCSVExport";
            this.buttonCSVExport.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExport.TabIndex = 10;
            this.buttonCSVExport.Text = "CSV Export";
            this.buttonCSVExport.UseVisualStyleBackColor = true;
            this.buttonCSVExport.Click += new System.EventHandler(this.buttonCSVExport_Click); // Event-Zuordnung

            // 
            // buttonCSVImport
            // 
            this.buttonCSVImport.Location = new System.Drawing.Point(400, 300);
            this.buttonCSVImport.Name = "buttonCSVImport";
            this.buttonCSVImport.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVImport.TabIndex = 11;
            this.buttonCSVImport.Text = "CSV Import";
            this.buttonCSVImport.UseVisualStyleBackColor = true;
            this.buttonCSVImport.Click += new System.EventHandler(this.buttonCSVImport_Click); // Event-Zuordnung


            // 
            // labelZurichTime
            // 
            this.labelZurichTime.AutoSize = true;
            this.labelZurichTime.Location = new System.Drawing.Point(350, 250);  // Position in die Mitte setzen
            this.labelZurichTime.Name = "labelZurichTime";
            this.labelZurichTime.Size = new System.Drawing.Size(70, 13);
            this.labelZurichTime.TabIndex = 12;
            this.labelZurichTime.Text = "Zürich Zeit";

            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 250);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 13;
            this.labelTitle.Text = "Titel";

            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(150, 250);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(75, 13);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "Beschreibung";

            // 
            // labelUserSelection
            // 
            this.labelUserSelection.AutoSize = true;
            this.labelUserSelection.Location = new System.Drawing.Point(12, 320);
            this.labelUserSelection.Name = "labelUserSelection";
            this.labelUserSelection.Size = new System.Drawing.Size(46, 13);
            this.labelUserSelection.TabIndex = 15;
            this.labelUserSelection.Text = "Benutzer";

            // 
            // labelNewUser
            // 
            this.labelNewUser.AutoSize = true;
            this.labelNewUser.Location = new System.Drawing.Point(150, 320);
            this.labelNewUser.Name = "labelNewUser";
            this.labelNewUser.Size = new System.Drawing.Size(78, 13);
            this.labelNewUser.TabIndex = 16;
            this.labelNewUser.Text = "Neuer Benutzer";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNewUser);
            this.Controls.Add(this.labelUserSelection);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelZurichTime);
            this.Controls.Add(this.buttonCSVImport);
            this.Controls.Add(this.buttonCSVExport);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxNewUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.dataGridViewTasks);
            this.Name = "Form1";
            this.Text = "Task Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonCSVExport;
        private System.Windows.Forms.Button buttonCSVImport;
        private System.Windows.Forms.Label labelZurichTime;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelUserSelection;
        private System.Windows.Forms.Label labelNewUser;
    }
}
