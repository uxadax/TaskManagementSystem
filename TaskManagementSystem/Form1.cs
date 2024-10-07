using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem
{
    public partial class Form1 : Form
    {
        private TaskRepository _taskRepository;
        private UserRepository _userRepository;

        public Form1()
        {
            InitializeComponent();
            _taskRepository = new TaskRepository();
            _userRepository = new UserRepository();
            LoadUsers();
            LoadTasks();
        }

        // Lädt alle Aufgaben aus der Datenbank und zeigt sie im DataGridView an
        private void LoadTasks()
        {
            var taskViewModels = _taskRepository.GetTaskViewModels();
            dataGridViewTasks.DataSource = taskViewModels;
        }

        // Lädt alle Benutzer aus der Datenbank und fügt sie in die ComboBox ein
        private void LoadUsers()
        {
            var users = _userRepository.GetUsers();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.DisplayMember = "UserName";
            comboBoxUsers.ValueMember = "Id";
        }

        // Methode zum Hinzufügen eines neuen Benutzers
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNewUser.Text) && textBoxNewUser.Text != "Neuen Benutzer eingeben")
            {
                User newUser = new User { UserName = textBoxNewUser.Text };
                _userRepository.AddUser(newUser);
                LoadUsers();
                textBoxNewUser.Text = "Neuen Benutzer eingeben";  // Textbox zurücksetzen
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Benutzernamen ein.");
            }
        }

        // Methode zum Löschen eines Benutzers
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                int selectedUserId = (int)comboBoxUsers.SelectedValue;
                _userRepository.DeleteUser(selectedUserId);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer zum Löschen aus.");
            }
        }

        // Methode zum Erstellen einer neuen Aufgabe
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                int selectedUserId = (int)comboBoxUsers.SelectedValue;

                Task task = new Task
                {
                    Title = textBoxTitle.Text,
                    Description = textBoxDescription.Text,
                    IsCompleted = false,
                    CreateDate = DateTime.Now,
                    UserId = selectedUserId
                };

                _taskRepository.AddTask(task);
                LoadTasks();  // Aktualisiere die Liste nach dem Hinzufügen
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer aus.");
            }
        }

        // Methode zum Aktualisieren einer bestehenden Aufgabe
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0 && comboBoxUsers.SelectedValue != null)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                Task task = _taskRepository.GetTasks().Find(t => t.Id == taskId);

                task.Title = textBoxTitle.Text;
                task.Description = textBoxDescription.Text;
                task.UserId = (int)comboBoxUsers.SelectedValue;

                _taskRepository.UpdateTask(task);
                LoadTasks();  // Aktualisiert die Liste nach dem Ändern
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe und einen Benutzer zum Ändern aus.");
            }
        }

        // Methode zum Löschen einer bestehenden Aufgabe
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["Id"].Value);
                _taskRepository.DeleteTask(taskId);
                LoadTasks();  // Aktualisiert die Liste nach dem Löschen
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe zum Löschen aus.");
            }
        }

        // Event-Methode, um Text aus den Textboxen zu entfernen, wenn der Benutzer sie anklickt
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.ForeColor == System.Drawing.Color.Gray)
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.Color.Black;
            }
        }

        // Event-Methode, um Platzhaltertext wieder anzuzeigen, wenn die Textbox leer bleibt
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && string.IsNullOrEmpty(tb.Text))
            {
                if (tb == textBoxTitle) tb.Text = "Titel eingeben";
                else if (tb == textBoxDescription) tb.Text = "Beschreibung eingeben";
                else if (tb == textBoxNewUser) tb.Text = "Neuen Benutzer eingeben";

                tb.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // Methode zum Exportieren der Aufgaben in eine CSV-Datei
        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Speicherort für CSV-Datei auswählen";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("Id,Title,Description,CreateDate,IsCompleted,UserId,UserName");
                    foreach (TaskViewModel task in (List<TaskViewModel>)dataGridViewTasks.DataSource)
                    {
                        writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.CreateDate},{task.IsCompleted},{task.UserId},{task.UserName}");
                    }
                }
                MessageBox.Show("CSV-Datei erfolgreich exportiert.");
            }
        }

        // Methode zum Importieren von Aufgaben aus einer CSV-Datei
        private void buttonImportCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.Title = "CSV-Datei zum Importieren auswählen";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    reader.ReadLine();  // Überspringe die Header-Zeile
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        Task task = new Task
                        {
                            Title = values[1],
                            Description = values[2],
                            CreateDate = DateTime.Parse(values[3]),
                            IsCompleted = bool.Parse(values[4]),
                            UserId = int.Parse(values[5])
                        };

                        _taskRepository.AddTask(task);
                    }
                }
                LoadTasks();
                MessageBox.Show("CSV-Datei erfolgreich importiert.");
            }
        }
    }
}
