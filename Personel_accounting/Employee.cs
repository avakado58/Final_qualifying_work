using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_accounting
{
    public partial class Employee : Form
    {
        SqlConnection my_conn;
        SqlDataAdapter my_data;
        SqlCommand my_command, Command_1, Command_2, Command_3;
        SqlDataReader sqlDataReader;
        string sls1 = "";
        string sls2 = "";
        string connectionString;
        public Employee(int n, string di, string connectionString)
        {
            this.connectionString = connectionString;
            my_conn = new SqlConnection(connectionString); //Создаем соеденение
            InitializeComponent();
            Loading_1();
            this.n = n;
            this.di = di;
            id.Text = di;
        }

        int n;
        string di;
        public void Loading_1()
        {
            // Настройка выпадающего списка должности
            my_data = new SqlDataAdapter("select * from Должность", connectionString);

            DataTable tbl = new DataTable();

            my_data.Fill(tbl);

            post.DataSource = tbl;
            post.DisplayMember = "Должность";// столбец для отображения
            post.ValueMember = "Код должности";//столбец с id

            // Настройка выпадающего списка семейного положения
            my_data = new SqlDataAdapter("select * from [Семейное положение]", connectionString);

            DataTable tb1 = new DataTable();

            my_data.Fill(tb1);

            polog.DataSource = tb1;
            polog.DisplayMember = "Семейное положение";// столбец для отображения
            polog.ValueMember = "Код положения";//столбец с id
        }
        // Кнопка добавить сотрудника
        private void add_Click(object sender, EventArgs e)
        {
            if (FIO.Text == "" || adress.Text == "" || number.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                id.Text = "";

                my_conn.Open(); // Открытие соединения с базой данных

                my_command = my_conn.CreateCommand();

                my_command.CommandText = "Select * from [Семейное положение] where [Семейное положение]  ='" + polog.Text + "';";

                SqlDataReader sdr = my_command.ExecuteReader();

                while (sdr.Read())
                {
                    sls1 = sdr["Код положения"].ToString();
                }

                my_conn.Close();

                my_conn.Open(); // Открытие соединения с базой данных

                my_command = my_conn.CreateCommand();

                my_command.CommandText = "Select * from Должность where Должность  ='" + post.Text + "';";

                SqlDataReader sdr1 = my_command.ExecuteReader();

                while (sdr1.Read())
                {
                    sls2 = sdr1["Код должности"].ToString();
                }

                my_conn.Close();

                string commandText = string.Format("INSERT INTO Сотрудник (ФИО, [Дата рождения], Адрес, [Номер телефона], [Код положения], [Код должности]) VALUES ('{0}', '{1:yyyy.MM.dd}', '{2}', '{3}', '{4}', '{5}')", FIO.Text, dateTimePicker1.Value, adress.Text, number.Text, sls1, sls2); // Cтрока передачи данных

                my_conn = new SqlConnection(connectionString); //Создаем соеденение

                my_command = new SqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении
                
                // Процесс связи таблицы клиенты и логина с паролем
                Command_1 = my_conn.CreateCommand();

                Command_1.CommandText = "Select * from Сотрудник where ФИО ='" + FIO.Text + "'AND [Дата рождения] ='" + dateTimePicker1.Value + "';";

                SqlDataReader sdr3 = Command_1.ExecuteReader();
                while (sdr3.Read())
                {
                    id.Text += sdr3["Код сотрудника"];
                }
                my_conn.Close();

                add_1.Enabled = false;
            }
        }
        // Кнопка добавить образование
        private void Add_2_Click(object sender, EventArgs e)
        {
            AddEducation();
            add_2.Enabled = false;
        }
        private void AddEducation()
        {
            if (study.Text == "" || diplom.Text == "" || qualification.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO Образование ([Учебное заведение], Диплом, [Год окончания], Квалификация, [Код сотрудника]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", study.Text, diplom.Text, year.Text, qualification.Text, id.Text); // Cтрока передачи данных

                my_conn = new SqlConnection(connectionString); //Создаем соеденение

                my_command = new SqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                
            }
        }
        // Кнопка сохранить изменения об образовании
        private void save_2_Click(object sender, EventArgs e)
        {
            bool dateExist = false;
            string strQuery = "select [Код сотрудника] from Образование";
            my_conn.Open();
            my_command = new SqlCommand(strQuery, my_conn);
            sqlDataReader = my_command.ExecuteReader();
            while(sqlDataReader.Read())
            {
               if(Convert.ToString(sqlDataReader["Код сотрудника"])==di)
                {
                    dateExist = true;
                    break;
                }
            }
            sqlDataReader.Close();
            if(dateExist)
            {
                strQuery = string.Format("UPDATE Образование SET [Учебное заведение] = @param1, Диплом = @param2, [Год окончания] = @param3, Квалификация = @param4 WHERE [Код сотрудника] = {0}", id.Text); // Строка передачи данных

                my_command = new SqlCommand(strQuery, my_conn);



                // Обновление соответствующих столбцов
                my_command.Parameters.AddWithValue("@param1", study.Text);
                my_command.Parameters.AddWithValue("@param2", diplom.Text);
                my_command.Parameters.AddWithValue("@param3", year.Text);
                my_command.Parameters.AddWithValue("@param4", qualification.Text);

                my_command.ExecuteNonQuery();
                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении
            }
            else
            {
                AddEducation();
            }


            my_conn.Close();

           
        }
        // Сохранить изменения о семье
        private void save_3_Click(object sender, EventArgs e)
        {
            string strQuery = "SELECT [Код сотрудника] FROM Семья";
            my_conn.Open();
            bool dateExist = false;
            my_command = new SqlCommand(strQuery, my_conn);
            sqlDataReader = my_command.ExecuteReader();
            while(sqlDataReader.Read())
            {
                if(Convert.ToString(sqlDataReader["Код сотрудника"])==di)
                {
                    dateExist = true;
                    break;
                }
            }
            sqlDataReader.Close();
            if(dateExist)
            {
                strQuery = string.Format("UPDATE Семья SET ФИО = @param1, [Дата рождения] = @param2, [Количество детей] = @param3 WHERE [Код сотрудника] = {0}", id.Text); // Строка передачи данных

                my_command = new SqlCommand(strQuery, my_conn);
                // Обновление соответствующих столбцов
                my_command.Parameters.AddWithValue("@param1", FIO_1.Text);
                my_command.Parameters.AddWithValue("@param2", dateTimePicker2.Value);
                my_command.Parameters.AddWithValue("@param3", count_kid.Text);

                my_command.ExecuteNonQuery();

                my_conn.Close();

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении
            }
            else
            {
                AddFamily();
            }

            


           
        }

        // Кнопка добавить семью
        private void Add_3_Click(object sender, EventArgs e)
        {
            AddFamily();
            add_3.Enabled = false;
        }
        private void AddFamily()
        {
            if (FIO_1.Text == "" || count_kid.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO Семья (ФИО, [Дата рождения], [Количество детей], [Код сотрудника]) VALUES ('{0}', '{1:yyyy.MM.dd}', '{2}', '{3}')", FIO_1.Text, dateTimePicker2.Value, count_kid.Text, id.Text); // Cтрока передачи данных

                my_conn = new SqlConnection(connectionString); //Создаем соеденение

                my_command = new SqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                
            }
        }

        // Кнопка сохранить изменения о сотруднике
        private void save_1_Click(object sender, EventArgs e)
        {
            string strQuery = string.Format("UPDATE Сотрудник SET ФИО = @param1, [Дата рождения] = @param2, Адрес = @param3, [Номер телефона] = @param4, [Код должности] = @param5, [Код положения] = @param6 WHERE [Код сотрудника] = {0}", id.Text); // Строка передачи данных

            my_command = new SqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", FIO.Text);
            my_command.Parameters.AddWithValue("@param2", dateTimePicker1.Value);
            my_command.Parameters.AddWithValue("@param3", adress.Text);
            my_command.Parameters.AddWithValue("@param4", number.Text);
            my_command.Parameters.AddWithValue("@param5", post.SelectedIndex + 1);
            my_command.Parameters.AddWithValue("@param6", polog.SelectedIndex + 1);

            my_command.ExecuteNonQuery();

            my_conn.Close();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении
        }

        // Загрузка выпадающих списков
        private void Employee_Load(object sender, EventArgs e)
        {
            for (int n = 1950; n <= 2021; n++)
                year.Items.Add(Convert.ToString(n)); // Заполнение года от 1950 до 2021
            // Проверка кнопки добавить
            if (n == 0)
            {
                save_1.Visible = false;
                save_2.Visible = false;
                save_3.Visible = false;
            }
            // Проверка кнопки редактировать
            if (n == 1)
            {
                add_1.Visible = false;
                add_2.Visible = false;
                add_3.Visible = false;

                my_conn.Open();

                Command_1 = my_conn.CreateCommand();

                Command_1.CommandText = "Select * from Сотрудник where [Код сотрудника] ='" + id.Text + "';";

                SqlDataReader sdr3 = Command_1.ExecuteReader();
                while (sdr3.Read())
                {
                    FIO.Text += sdr3["ФИО"];
                    adress.Text += sdr3["Адрес"];
                    number.Text += sdr3["Номер телефона"];
                    dateTimePicker1.Value = DateTime.Parse(sdr3["Дата рождения"].ToString());
                    int _polog = Convert.ToInt32(sdr3["Код должности"].ToString());
                    post.SelectedIndex = _polog - 1;
                    int famili = Convert.ToInt32(sdr3["Код положения"].ToString());
                    polog.SelectedIndex = famili - 1;
                }

                my_conn.Close();

                my_conn.Open();

                Command_2 = my_conn.CreateCommand();

                Command_2.CommandText = "Select * from Образование where [Код сотрудника] ='" + id.Text + "';";

                SqlDataReader sdr4 = Command_2.ExecuteReader();
                while (sdr4.Read())
                {
                    study.Text += sdr4["Учебное заведение"];
                    diplom.Text += sdr4["Диплом"];
                    qualification.Text += sdr4["Квалификация"];
                    year.Text += sdr4["Год окончания"];
                }
                my_conn.Close();

                my_conn.Open();

                Command_3 = my_conn.CreateCommand();

                Command_3.CommandText = "Select * from Семья where [Код сотрудника] ='" + id.Text + "';";

                SqlDataReader sdr5 = Command_3.ExecuteReader();
                while (sdr5.Read())
                {
                    FIO_1.Text += sdr5["ФИО"];
                    dateTimePicker2.Value = DateTime.Parse(sdr5["Дата рождения"].ToString());
                    count_kid.Text += sdr5["Количество детей"];
                }
                my_conn.Close();
            }
            
        }
    }
}
