using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GolfScore
{
    public partial class Form1 : Form
    {
        public static string path = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=golfData.mdb"; //путь к базе данных
        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Наполняем комбобоксы с количеством ударов
            for (var i = 5; i < 30; i++)
            {
                comboBoxP0score.Items.Add(i);
                comboBoxP1score.Items.Add(i);
                comboBoxP2score.Items.Add(i);
                comboBoxP3score.Items.Add(i);
            }
            //Наполняем комбобоксы с игроками
            using (OleDbConnection connection = new OleDbConnection(path))
            {
                connection.Open();
                string request = "Select DISTINCT Имя From score";
                OleDbCommand command = new OleDbCommand(request, connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox0.Items.Add(reader.GetValue(0));
                    comboBox1.Items.Add(reader.GetValue(0));
                    comboBox2.Items.Add(reader.GetValue(0));
                    comboBox3.Items.Add(reader.GetValue(0));
                }
                reader.Close();
            }
        }
        //управляем количеством игроков активируя поля
        private void ComboBoxPlayers_Select(object sender, EventArgs e)
        {
            //3 игрока
            if (comboBox1.Text != "")
            {
                PlayerReady(3, true);
            }
            else
            {
                PlayerReady(3, false);
                PlayerReady(4, false);
            }
            //4 игрока
            if (comboBox2.Text != "")
            {
                PlayerReady(4, true);
            }
            else
            {
                PlayerReady(4, false);
            }
        }
        //вывод результатов
        private void OutputResultToDataBase(object sender, EventArgs e) //сохранение в базу данных
        {
            for (int i = 0; i < NumberOfPlayer(); i++)
                new Player(PlayerName(i), PlayerGain(i)).Save();
        }
        private void OutputResultToTextBox(object sender, EventArgs e) //вывод рузультата в текстовый модуль
        {
            textBox1.Clear();
            for (int i = 0; i < NumberOfPlayer(); i++)
                textBox1.Text += new Player(PlayerName(i), PlayerGain(i)).ToString();
        }
        //Включение выключения игрока
        private void PlayerReady(int number, bool ready)
        {
            if (!ready)
            {
                (groupBox2.Controls[$"comboBoxP{number - 1}score"] as ComboBox).Text = @"0"; //сбрасываем количество очков 
                (groupBox1.Controls[$"comboBox{number - 1}"] as ComboBox).SelectedIndex = -1; //убираем имя
            }
            (groupBox2.Controls[$"comboBoxP{number - 1}score"] as ComboBox).Enabled = ready; //отключаем очки
            (groupBox1.Controls[$"comboBox{number - 1}"] as ComboBox).Enabled = ready; //отключаем поле выбора имени
        }
        //получение данных 
        private int NumberOfPlayer() //получаем количество игроков
        {
            int players = 0;
            foreach (var cb in groupBox2.Controls.OfType<ComboBox>())
            {
                double.TryParse(cb.Text, out double score);
                if (score > 0) players++;

            }
            return players;
        }
        private string PlayerName(int i) //получаем имя игрока из комбобокса по его номеру
        {
            return (groupBox1.Controls["comboBox" + i.ToString()] as ComboBox).Text;
        }
        private double PlayerGain(int i) //получаем выигрыш игрока по его номеру
        {
            // среднее количество ударов
            double AverageStroke()
            {
                double summ = 0;
                foreach (var cb in groupBox2.Controls.OfType<ComboBox>())
                {
                    double.TryParse(cb.Text, out double score);
                    summ += score;
                }
                return summ / NumberOfPlayer();
            }
            //цена за удар
            double bet = Convert.ToDouble(TextBoxBet.Text);
            //сумма выигрыша
            return (AverageStroke() - Convert.ToDouble((groupBox2.Controls["comboBoxP" + i.ToString() + "score"] as ComboBox).Text)) * bet;
        }
        private void ToolStripStatButton_Click(object sender, EventArgs e) //получаем статистику
        {
            textBox1.Clear();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            toolStripButtonSave.Enabled = false;
            TextBoxBet.Enabled = false;
            textBox1.Location = new Point(12, 65);
            textBox1.Size = new Size(297, 283);
            dateTimePicker1.Visible = true;

            string request = $"SELECT DISTINCTROW Имя, Sum(Сумма) AS [Sum - Сумма] FROM Score WHERE YEAR(Дата)= '{dateTimePicker1.Value.Year}' GROUP BY Имя";
            using (OleDbConnection _connection = new OleDbConnection(path))
            {
                _connection.Open();
                using (OleDbCommand command = new OleDbCommand(request, _connection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        textBox1.Text += $"{reader.GetValue(0).ToString()}\t\t{reader.GetValue(1).ToString()}\r\n";
                    reader.Close();
                }
            }
        }
    }


}