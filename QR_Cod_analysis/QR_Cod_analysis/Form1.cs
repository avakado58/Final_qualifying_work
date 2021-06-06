using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Text;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Collections.Generic;

namespace QR_Cod_analysis
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SQLiteConnection conn;
        SQLiteDataAdapter da;
        SQLiteCommand Command;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        private ZXing.BarcodeReader reader;
        public Form1()
        {
            InitializeComponent();

            surname.Text = "Введите фамилию";
            surname.ForeColor = Color.Gray;

            name.Text = "Введите имя";
            name.ForeColor = Color.Gray;

            middle_name.Text = "Введите отчество";
            middle_name.ForeColor = Color.Gray;

            Loading();
        }
        
        delegate void SetStringDelegate(String parametr);
        ////////////////////////////////////////////////////////
        /// Метод расшифровки QR кода
        void SetResult(string result)
        {
            if (!InvokeRequired)
            {
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                    for (int j = 0; j <= table.ColumnCount - 1; j++)
                        if (table.Rows[i].Cells[j].Value != null && table.Rows[i].Cells[j].Value.ToString() == result)
                        {
                            table.Rows[i].Cells[j].Selected = true;
                            _surname = table.Rows[i].Cells[j].Value.ToString();
                            _name = table.Rows[i].Cells[1].Value.ToString();
                            _middlename = table.Rows[i].Cells[2].Value.ToString();
                            _date = table.Rows[i].Cells[3].Value.ToString();
                        }
               
                Form2 fm2 = new Form2(this._surname, this._name, this._middlename, this._date);
                fm2.Owner = this;
                fm2.ShowDialog();
                
                videoSource.SignalToStop();
            }

            else
                Invoke(new SetStringDelegate(SetResult), new object[] { result });
        }

        private string _surname;
        private string _name;
        private string _middlename;
        private string _date;

        static string path = Path.Combine(Directory.GetCurrentDirectory(), "Journal.db");

        public string ConnectionString = @"Data Source=" + path + ";Version=3; New=True;Compress=True;";

        public void Loading()
        {
            // Настройки таблицы
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            table.RowHeadersWidth = 65;

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold);
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            table.RowHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 13);
            table.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            table.DefaultCellStyle.Font = new Font("Times New Roman", 13);
            //
            string sql = "Select [Фамилия], [Имя], [Отчество], [Дата рождения] From journal"; //Sql запрос (достать все из таблицы ...)

            ds = new DataSet(); //Создаем объект класса DataSet

            conn = new SQLiteConnection(ConnectionString); //Создаем соеденение

            da = new SQLiteDataAdapter(sql, conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            da.Fill(ds, "journal");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        ////////////////////////////////////////////////////////
        ///Фамилия
        private void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "Введите фамилию")
            {
                surname.Text = "";
                surname.ForeColor = Color.Black;
            }
        }
        private void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
            {
                surname.Text = "Введите фамилию";
                surname.ForeColor = Color.Gray;
            }
        }
        ////////////////////////////////////////////////////////
        ///Имя
        private void name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "Введите имя")
            {
                name.Text = "";
                name.ForeColor = Color.Black;
            }
        }
        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Введите имя";
                name.ForeColor = Color.Gray;
            }
        }
        ////////////////////////////////////////////////////////
        ///Отчество
        private void middle_name_Enter(object sender, EventArgs e)
        {
            if (middle_name.Text == "Введите отчество")
            {
                middle_name.Text = "";
                middle_name.ForeColor = Color.Black;
            }
        }
        private void middle_name_Leave(object sender, EventArgs e)
        {
            if (middle_name.Text == "")
            {
                middle_name.Text = "Введите отчество";
                middle_name.ForeColor = Color.Gray;
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // Индексы слева у таблицы
        private void table_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.table.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.table.Rows[index].HeaderCell.Value = indexStr;
        }
        ///////////////////////////////////////////////////////////////////////
        // Кнопка добавить
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bData = imageToByteArray(pictureBox1.Image);
                byte[] qr = imageToByteArray(pictureBox2.Image);

                Command = new SQLiteCommand(conn);
                Command.CommandText = "insert into journal ([Фамилия], [Имя], [Отчество], [Дата рождения], [Фотография], [QR]) VALUES (@Фамилия, @Имя, @Отчество, @Дата_рождения, @Фотография, @QR)";
                Command.Parameters.Add("@Фамилия", DbType.String).Value = surname.Text;
                Command.Parameters.Add("@Имя", DbType.String).Value = name.Text;
                Command.Parameters.Add("@Отчество", DbType.String).Value = middle_name.Text;
                Command.Parameters.Add("@Дата_рождения", DbType.String).Value = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                Command.Parameters.Add("@Фотография", DbType.Binary).Value = bData;
                Command.Parameters.Add("@QR", DbType.Binary).Value = qr;

                conn.Open(); // Открытие соединения с базой данных

                Command.ExecuteNonQuery(); // sql возвращает сколько строк обработано
                conn.Close();

                Loading();
            }
            catch
            {
                MessageBox.Show("Загрузите фотографию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // Кнопка загрузить фото и QR кода
        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG файлы (*,.jpg)|*.jpg|Bitmap файлы (*.bmp)|*.bmp|Все файлы (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
            string qrtext = surname.Text; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext, Encoding.UTF8); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            pictureBox2.Image = qrcode as Image; // pictureBox выводит qrcode как изображение.
        }
        ///////////////////////////////////////////////////////////////////////
        // Метод перевода картики в байты
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        ///////////////////////////////////////////////////////////////////////
        // Программная остановка видео
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // В каком pictureBox отображать видео
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            pictureBox3.Image = bitmap;

            ZXing.Result result = reader.Decode((Bitmap)eventArgs.Frame.Clone());
            if (result != null)
            {
                SetResult(result.Text);
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // Кнопка включения видео
        private void on_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }
        ///////////////////////////////////////////////////////////////////////
        // Загрузка источников видео
        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            reader = new ZXing.BarcodeReader();
            reader.Options.PossibleFormats = new List<ZXing.BarcodeFormat>();
            reader.Options.PossibleFormats.Add(ZXing.BarcodeFormat.QR_CODE);

            List<string> teams = new List<string>(); // создание списка устройств
            if (videoDevices.Count > 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    teams.Add(device.Name);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя, место, в которое он захочет сохранить файл. 
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //если пользователь нажимает в обозревателе кнопку "Сохранить".
            {
                pictureBox2.Image.Save(save.FileName); //изображение из pictureBox'a сохраняется под именем, которое введёт пользователь
            }
        }

        private void table_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.ClearSelection();
        }
    }
}
