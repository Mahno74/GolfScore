using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfScore
{
    class Player
    {
        public string Name { get; }
        public double Money { get; }
        public Player(string name, double money)
        {
            Name = name;
            Money = money;
        }
        public override string ToString()
        {
            return Name + " " + Money.ToString("N1") + "\r\n";
        }
        public void Save() //сохранение итогов
        {
            string request = $"INSERT INTO score ([Имя], [Дата], [Сумма])  VALUES ('{Name}', '{DateTime.Now.ToShortDateString()}', '{Money.ToString("N1")}')";
            OleDbConnection _connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=golfData.mdb");
            _connection.Open();
            var command = new OleDbCommand(request, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
