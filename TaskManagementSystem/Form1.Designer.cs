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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelSelectUser = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.labelAddUser = new System.Windows.Forms.Label();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();

            // dataGridViewTasks
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.Size = new System.Drawing.Size(776, 230);
            this.dataGridViewTasks.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 258);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(32, 15);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Titel:";

            // textBoxTitle
            this.textBoxTitle.ForeColor = System.Drawing.Color.Gray;
            this.textBoxTitle.Location = new System.Drawing.Point(12, 276);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(150, 23);
            this.textBoxTitle.TabIndex = 2;
            this.textBoxTitle.Text = "Titel eingeben";
            this.textBoxTitle.Enter += new System.EventHandler(this.textBoxTitle_Enter);
            this.textBoxTitle.Leave += new System.EventHandler(this.textBoxTitle_Leave);

            // labelDescription
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(190, 258);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(78, 15);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Beschreibung:";

            // textBoxDescription
            this.textBoxDescription.ForeColor = System.Drawing.Color.Gray;
            this.textBoxDescription.Location = new System.Drawing.Point(190, 276);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(150, 23);
            this.textBoxDescription.TabIndex = 4;
            this.textBoxDescription.Text = "Beschreibung eingeben";
            this.textBoxDescription.Enter += new System.EventHandler(this.textBoxDescription_Enter);
            this.textBoxDescription.Leave += new System.EventHandler(this.textBoxDescription_Leave);

            // labelSelectUser
            this.labelSelectUser.AutoSize = true;
            this.labelSelectUser.Location = new System.Drawing.Point(372, 258);
            this.labelSelectUser.Name = "labelSelectUser";
            this.labelSelectUser.Size = new System.Drawing.Size(92, 15);
            this.labelSelectUser.TabIndex = 5;
            this.labelSelectUser.Text = "Benutzer wählen:";

            // comboBoxUsers
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(372, 276);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(150, 23);
            this.comboBoxUsers.TabIndex = 6;

            // buttonDeleteUser (Moved Below comboBoxUsers)
            this.buttonDeleteUser.Location = new System.Drawing.Point(372, 305);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(150, 23);
            this.buttonDeleteUser.TabIndex = 7;
            this.buttonDeleteUser.Text = "Benutzer löschen";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);

            // labelAddUser
            this.labelAddUser.AutoSize = true;
            this.labelAddUser.Location = new System.Drawing.Point(553, 258);
            this.labelAddUser.Name = "labelAddUser";
            this.labelAddUser.Size = new System.Drawing.Size(89, 15);
            this.labelAddUser.TabIndex = 8;
            this.labelAddUser.Text = "Neuer Benutzer:";

            // textBoxNewUser
            this.textBoxNewUser.ForeColor = System.Drawing.Color.Gray;
            this.textBoxNewUser.Location = new System.Drawing.Point(553, 276);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(150, 23);
            this.textBoxNewUser.TabIndex = 9;
            this.textBoxNewUser.Text = "Neuen Benutzer eingeben";
            this.textBoxNewUser.Enter += new System.EventHandler(this.textBoxNewUser_Enter);
            this.textBoxNewUser.Leave += new System.EventHandler(this.textBoxNewUser_Leave);

            // buttonAddUser
            this.buttonAddUser.Location = new System.Drawing.Point(553, 305);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(150, 23);
            this.buttonAddUser.TabIndex = 10;
            this.buttonAddUser.Text = "Benutzer hinzufügen";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);

            // buttonCreate
            this.buttonCreate.Location = new System.Drawing.Point(12, 326);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 11;
            this.buttonCreate.Text = "Erstellen";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);

            // buttonUpdate
            this.buttonUpdate.Location = new System.Drawing.Point(109, 326);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 12;
            this.buttonUpdate.Text = "Ändern";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);

            // buttonDelete
            this.buttonDelete.Location = new System.Drawing.Point(206, 326);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Löschen";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 400);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.textBoxNewUser);
            this.Controls.Add(this.labelAddUser);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.labelSelectUser);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewTasks);
            this.Name = "Form1";
            this.Text = "Task Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelSelectUser;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label labelAddUser;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
    }
}
