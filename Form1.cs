using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GolfScore
{
    public partial class Form1 : Form
    {
        private readonly OleDbConnection _connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=golfData.mdb");

        private OleDbCommand _command;
        private int _gamersNumb = 1;
        private OleDbDataReader _reader;
        private string _request;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set combobox with strokes
            for (var i = 5; i < 30; i++)
            {
                comboBoxP0score.Items.Add(i);
                comboBoxP1score.Items.Add(i);
                comboBoxP2score.Items.Add(i);
                comboBoxP3score.Items.Add(i);
            }

            //set combobox with players
            _request = "Select DISTINCT Имя From score";
            _connection.Open();
            _command = new OleDbCommand(_request, _connection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                comboBox0.Items.Add(_reader.GetValue(0));
                comboBox1.Items.Add(_reader.GetValue(0));
                comboBox2.Items.Add(_reader.GetValue(0));
                comboBox3.Items.Add(_reader.GetValue(0));
            }

            _reader.Close();
            _connection.Close();
        }


        //management of the display and content of the fields associated with the number of selected players
        private void ComboBoxPlayers_TextChanged(object sender, EventArgs e)
        {
            _gamersNumb = 0;
            //1
            if (comboBox0.Text == "")
            {
                comboBoxP0score.Text = @"0";
                comboBoxP0score.Enabled = false;
                comboBox1.Enabled = false;
                comboBox1.SelectedIndex = -1;
                comboBoxP1score.Text = @"0";
                comboBox2.Enabled = false;
                comboBox2.SelectedIndex = -1;
                comboBoxP2score.Text = @"0";
                comboBox3.Enabled = false;
                comboBox3.SelectedIndex = -1;
                comboBoxP3score.Text = @"0";
            }
            else
            {
                comboBoxP0score.Enabled = true;
                comboBox1.Enabled = true;
                _gamersNumb = 1;
                comboBox1.Items.Remove(comboBox0.SelectedItem);
                comboBox2.Items.Remove(comboBox0.SelectedItem);
                comboBox3.Items.Remove(comboBox0.SelectedItem);
            }

            //2
            if (comboBox1.Text == "")
            {
                comboBoxP1score.Text = @"0";
                comboBoxP1score.Enabled = false;
                comboBox2.Enabled = false;
                comboBox2.SelectedIndex = -1;
                comboBoxP2score.Text = @"0";
                comboBox3.Enabled = false;
                comboBox3.SelectedIndex = -1;
                comboBoxP3score.Text = @"0";
            }
            else
            {
                comboBoxP1score.Enabled = true;
                comboBox2.Enabled = true;
                _gamersNumb = 2;
                comboBox2.Items.Remove(comboBox1.SelectedItem);
                comboBox3.Items.Remove(comboBox1.SelectedItem);
            }

            //3
            if (comboBox2.Text == "")
            {
                comboBoxP2score.Text = @"0";
                comboBoxP2score.Enabled = false;
                comboBox3.Enabled = false;
                comboBox3.SelectedIndex = -1;
                comboBoxP3score.Text = @"0";
            }
            else
            {
                comboBoxP2score.Enabled = true;
                comboBox3.Enabled = true;
                _gamersNumb = 3;
                comboBox3.Items.Remove(comboBox2.SelectedItem);
            }

            //4
            if (comboBox3.Text == "")
            {
                comboBoxP3score.Text = @"0";
                comboBoxP3score.Enabled = false;
            }
            else
            {
                comboBoxP3score.Enabled = true;
                _gamersNumb = 4;
            }
        }

        //вывод результатов
        private void OutputResultToDataBase(object sender, EventArgs e) //в базу данных
        {
            for (int i = 0; i < NumberOfPlayer(); i++)
                new Player(PlayerName(i), PlayerGain(i)).Save();
        }
        private void OutputResultToTextBox(object sender, EventArgs e) //в текстовый модуль
        {
            textBox1.Clear();
            List<Player> players = new List<Player>();

            for (int i = 0; i < NumberOfPlayer(); i++)
                players.Add(new Player(PlayerName(i), PlayerGain(i)));
            foreach (Player player in players)
                textBox1.Text += player.ToString();
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

            _request = "SELECT DISTINCTROW score.Имя, Sum(score.Сумма) AS [Sum - Сумма] FROM score WHERE YEAR([Дата])= '" +
                        dateTimePicker1.Value.Year + "'  GROUP BY score.Имя;";
            _connection.Open();
            _command = new OleDbCommand(_request, _connection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
                textBox1.Text += (string) _reader.GetValue(0) + "\t\t" + Convert.ToString(_reader.GetValue(1)) +
                                 Environment.NewLine;
            _reader.Close();
            _connection.Close();
        }

    }


}