using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using TaskManagementSystem.Models;
using TaskManagementSystem.DataAccess;
using Newtonsoft.Json;

using TaskModel = TaskManagementSystem.Models.Task;

namespace TaskManagementSystem
{
    public partial class Form1 : Form
    {
        private TaskRepository _taskRepository;
        private UserRepository _userRepository;

        public Form1()
        {
            InitializeComponent();  // Ruft die Methode aus `Form1.Designer.cs` auf
            _taskRepository = new TaskRepository();
            _userRepository = new UserRepository();
            LoadUsers();
            LoadTasks();
            UpdateZurichTime();
        }

        private void LoadTasks()
        {
            dataGridViewTasks.DataSource = _taskRepository.GetTasks();
        }

        private void LoadUsers()
        {
            var users = _userRepository.GetUsers();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.DisplayMember = "UserName";
            comboBoxUsers.ValueMember = "Id";

            // Überprüfen, ob Benutzer vorhanden sind, ansonsten Textfeld leeren
            if (users.Count == 0)
            {
                comboBoxUsers.Text = "";      // Text in der ComboBox leeren
                comboBoxUsers.SelectedIndex = -1; // Auswahl auf "keine" setzen
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedValue != null)
            {
                var newTask = new TaskModel
                {
                    Title = textBoxTitle.Text,
                    Description = textBoxDescription.Text,
                    CreateDate = DateTime.Now,
                    IsCompleted = false,
                    UserId = (int)comboBoxUsers.SelectedValue,
                    User = (User)comboBoxUsers.SelectedItem
                };
                _taskRepository.AddTask(newTask);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer aus.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow != null)
            {
                var selectedTask = (TaskModel)dataGridViewTasks.CurrentRow.DataBoundItem;
                selectedTask.Title = textBoxTitle.Text;
                selectedTask.Description = textBoxDescription.Text;
                _taskRepository.UpdateTask(selectedTask);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe aus der Liste aus.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow != null)
            {
                var selectedTask = (TaskModel)dataGridViewTasks.CurrentRow.DataBoundItem;
                _taskRepository.DeleteTask(selectedTask);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Aufgabe aus der Liste aus.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            var newUser = new User
            {
                UserName = textBoxNewUser.Text
            };
            _userRepository.AddUser(newUser);
            LoadUsers();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedItem != null)
            {
                var selectedUser = (User)comboBoxUsers.SelectedItem;
                _userRepository.DeleteUser(selectedUser);
                LoadUsers();

                // Überprüfen, ob nach dem Löschen keine Benutzer mehr vorhanden sind
                if (comboBoxUsers.Items.Count == 0)
                {
                    comboBoxUsers.Text = ""; // Text in der ComboBox explizit leeren
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Benutzer aus.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCSVExport_Click(object sender, EventArgs e)
        {
            var tasks = _taskRepository.GetTasks();
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                Title = "Speichern als CSV"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("Id,Title,Description,CreateDate,IsCompleted,UserId,UserName");
                    foreach (var task in tasks)
                    {
                        writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.CreateDate},{task.IsCompleted},{task.UserId},{task.User.UserName}");
                    }
                }
            }
        }

        private void buttonCSVImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                Title = "CSV-Datei auswählen"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var reader = new StreamReader(openFileDialog.FileName))
                {
                    reader.ReadLine(); // Header überspringen
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var newTask = new TaskModel
                        {
                            Id = int.Parse(values[0]),
                            Title = values[1],
                            Description = values[2],
                            CreateDate = DateTime.Parse(values[3]),
                            IsCompleted = bool.Parse(values[4]),
                            UserId = int.Parse(values[5]),
                            User = new User { Id = int.Parse(values[5]), UserName = values[6] }
                        };
                        _taskRepository.AddTask(newTask);
                    }
                }
                LoadTasks();
            }
        }

        private async void UpdateZurichTime()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("http://worldtimeapi.org/api/timezone/Europe/Zurich");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        dynamic jsonObj = JsonConvert.DeserializeObject(json);
                        labelZurichTime.Text = jsonObj.datetime.ToString();
                    }
                    else
                    {
                        labelZurichTime.Text = "Zeit nicht verfügbar";
                    }
                }
            }
            catch (Exception ex)
            {
                labelZurichTime.Text = $"Fehler: {ex.Message}";
            }
        }
    }
}
