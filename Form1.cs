using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace GolfScore
{
    public partial class Form1 : Form
    {
        private readonly OleDbConnection _connection =
            new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=golfData.mdb");

        private readonly DataTable _table = new DataTable();
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
                comboBoxP1score.Items.Add(i);
                comboBoxP2score.Items.Add(i);
                comboBoxP3score.Items.Add(i);
                comboBoxP4score.Items.Add(i);
            }

            //set combobox with players
            _request = "Select DISTINCT Имя From score";
            _connection.Open();
            _command = new OleDbCommand(_request, _connection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                comboBox1.Items.Add(_reader.GetValue(0));
                comboBox2.Items.Add(_reader.GetValue(0));
                comboBox3.Items.Add(_reader.GetValue(0));
                comboBox4.Items.Add(_reader.GetValue(0));
            }

            _reader.Close();
            _connection.Close();
        }


        //management of the display and content of the fields associated with the number of selected players
        private void ComboBoxPlayers_TextChanged(object sender, EventArgs e)
        {
            _gamersNumb = 0;
            //1
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
                comboBox4.Enabled = false;
                comboBox4.SelectedIndex = -1;
                comboBoxP4score.Text = @"0";
            }
            else
            {
                comboBoxP1score.Enabled = true;
                comboBox2.Enabled = true;
                _gamersNumb = 1;
                comboBox2.Items.Remove(comboBox1.SelectedItem);
                comboBox3.Items.Remove(comboBox1.SelectedItem);
                comboBox4.Items.Remove(comboBox1.SelectedItem);
            }

            //2
            if (comboBox2.Text == "")
            {
                comboBoxP2score.Text = @"0";
                comboBoxP2score.Enabled = false;
                comboBox3.Enabled = false;
                comboBox3.SelectedIndex = -1;
                comboBoxP3score.Text = @"0";
                comboBox4.Enabled = false;
                comboBox4.SelectedIndex = -1;
                comboBoxP4score.Text = @"0";
            }
            else
            {
                comboBoxP2score.Enabled = true;
                comboBox3.Enabled = true;
                _gamersNumb = 2;
                comboBox3.Items.Remove(comboBox2.SelectedItem);
                comboBox4.Items.Remove(comboBox2.SelectedItem);
            }

            //3
            if (comboBox3.Text == "")
            {
                comboBoxP3score.Text = @"0";
                comboBoxP3score.Enabled = false;
                comboBox4.Enabled = false;
                comboBox4.SelectedIndex = -1;
                comboBoxP4score.Text = @"0";
            }
            else
            {
                comboBoxP3score.Enabled = true;
                comboBox4.Enabled = true;
                _gamersNumb = 3;
                comboBox4.Items.Remove(comboBox3.SelectedItem);
            }

            //4
            if (comboBox4.Text == "")
            {
                comboBoxP4score.Text = @"0";
                comboBoxP4score.Enabled = false;
            }
            else
            {
                comboBoxP4score.Enabled = true;
                _gamersNumb = 4;
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e) //saving
        {
            var gamersNumb = 0;
            double player1Reward, player2Reward, player3Reward;
            var bet = Convert.ToInt32(TextBoxBet.Text); //get a bet
            if (comboBox1.Text != "") gamersNumb++;
            if (comboBox2.Text != "") gamersNumb++;
            if (comboBox3.Text != "") gamersNumb++;
            if (comboBox4.Text != "") gamersNumb++;
            var avg = (Convert.ToDouble(comboBoxP1score.Text) + Convert.ToDouble(comboBoxP2score.Text) +
                       Convert.ToDouble(comboBoxP3score.Text) + Convert.ToDouble(comboBoxP4score.Text)) /
                      Convert.ToDouble(gamersNumb); //get average strikes

            switch (gamersNumb)
            {
                case 1:
                    break;
                case 2:
                    player1Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP1score.Text)) *
                                    Convert.ToDouble(bet);
                    player2Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP2score.Text)) *
                                    Convert.ToDouble(bet);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox1.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player1Reward) + "')";
                    SaveDate(_request);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox2.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player2Reward) + "')";
                    SaveDate(_request);
                    MessageBox.Show(@"Saving successful");
                    break;
                case 3:
                    player1Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP1score.Text)) *
                                    Convert.ToDouble(bet);
                    player2Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP2score.Text)) *
                                    Convert.ToDouble(bet);
                    player3Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP3score.Text)) *
                                    Convert.ToDouble(bet);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox1.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player1Reward) + "')";
                    SaveDate(_request);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox2.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player2Reward) + "')";
                    SaveDate(_request);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox3.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player3Reward) + "')";
                    SaveDate(_request);
                    MessageBox.Show(@"Saving successful");
                    break;
                case 4:
                    player1Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP1score.Text)) * Convert.ToDouble(bet);
                    player2Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP2score.Text)) * Convert.ToDouble(bet);
                    player3Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP3score.Text)) * Convert.ToDouble(bet);
                    var player4Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP4score.Text)) * Convert.ToDouble(bet);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox1.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player1Reward) + "')";
                    SaveDate(_request);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox2.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player2Reward) + "')";
                    SaveDate(_request);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox3.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player3Reward) + "')";
                    SaveDate(_request);
                    _request = "INSERT INTO score ([Имя], [Дата], [Сумма]) " +
                               " VALUES ('" + comboBox4.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" +
                               Math.Round(player4Reward) + "')";
                    SaveDate(_request);
                    MessageBox.Show(@"Saving successful");
                    break;
                default:
                    break;

                    void SaveDate(string request)
                    {
                        _connection.Open();
                        var command = new OleDbCommand(request, _connection);
                        command.ExecuteNonQuery();
                        _connection.Close();
                    }
            }
        }

        private void ComboBox_score_TextChanged(object sender, EventArgs e)
        {
            double player1Reward, player2Reward, player3Reward;
            var bet = Convert.ToInt32(TextBoxBet.Text); //getting bet
            var avg = (Convert.ToDouble(comboBoxP1score.Text) + Convert.ToDouble(comboBoxP2score.Text) +
                       Convert.ToDouble(comboBoxP3score.Text) + Convert.ToDouble(comboBoxP4score.Text)) /
                      Convert.ToDouble(_gamersNumb);

            switch (_gamersNumb)
            {
                case 1:
                    break;
                case 2:
                    player1Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP1score.Text)) * Convert.ToDouble(bet);
                    player2Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP2score.Text)) * Convert.ToDouble(bet);
                    textBox1.Text = comboBox1.Text + "\t\t" + Math.Round(player1Reward) + Environment.NewLine +
                                    comboBox2.Text + "\t\t" + Math.Round(player2Reward);
                    break;
                case 3:
                    player1Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP1score.Text)) * Convert.ToDouble(bet);
                    player2Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP2score.Text)) * Convert.ToDouble(bet);
                    player3Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP3score.Text)) * Convert.ToDouble(bet);
                    textBox1.Text = comboBox1.Text + "\t\t" + Math.Round(player1Reward) + Environment.NewLine +
                                    comboBox2.Text + "\t\t" + Math.Round(player2Reward) + Environment.NewLine +
                                    comboBox3.Text + "\t\t" + Math.Round(player3Reward);
                    break;
                case 4:
                    player1Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP1score.Text)) * Convert.ToDouble(bet);
                    player2Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP2score.Text)) * Convert.ToDouble(bet);
                    player3Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP3score.Text)) * Convert.ToDouble(bet);
                    var player4Reward = (Convert.ToDouble(avg) - Convert.ToDouble(comboBoxP4score.Text)) * Convert.ToDouble(bet);
                    textBox1.Text = comboBox1.Text + "\t\t" + Math.Round(player1Reward) + Environment.NewLine +
                                    comboBox2.Text + "\t\t" + Math.Round(player2Reward) + Environment.NewLine +
                                    comboBox3.Text + "\t\t" + Math.Round(player3Reward) + Environment.NewLine +
                                    comboBox4.Text + "\t\t" + Math.Round(player4Reward);
                    break;
            }
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