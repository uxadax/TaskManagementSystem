using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using TaskManagementSystem.Models;
using TaskManagementSystem.DataAccess;
using Newtonsoft.Json;
using System.Timers;

using TaskModel = TaskManagementSystem.Models.Task;

namespace TaskManagementSystem
{
    public partial class Form1 : Form
    {
        private TaskRepository _taskRepository;
        private UserRepository _userRepository;
        private System.Timers.Timer _timer;  // Timer für die Aktualisierung der Uhrzeit

        public Form1()
        {
            InitializeComponent();
            _taskRepository = new TaskRepository();
            _userRepository = new UserRepository();
            LoadUsers();
            LoadTasks();
            StartTimerForTimeUpdate();  // Timer starten
        }

        // Methode zum Starten des Timers
        private void StartTimerForTimeUpdate()
        {
            _timer = new System.Timers.Timer(1000); // Aktualisierung alle 1 Sekunde (1000 Millisekunden)
            _timer.Elapsed += TimerElapsedHandler;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            UpdateZurichTime();  // Uhrzeit initial aktualisieren
        }

        // Ereignis-Handler für den Timer
        private void TimerElapsedHandler(Object source, ElapsedEventArgs e)
        {
            // Invoke verwendet, um sicherzustellen, dass das Label im richtigen Thread aktualisiert wird
            if (labelZurichTime.InvokeRequired)
            {
                labelZurichTime.Invoke(new Action(() => UpdateZurichTime()));
            }
            else
            {
                UpdateZurichTime();
            }
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

            if (users.Count == 0)
            {
                comboBoxUsers.Text = "";
                comboBoxUsers.SelectedIndex = -1;
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

                if (comboBoxUsers.Items.Count == 0)
                {
                    comboBoxUsers.Text = "";
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
                        labelZurichTime.Text = DateTime.Parse(jsonObj.datetime.ToString()).ToString("HH:mm:ss");
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
