using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace WpfSend
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Відправка POST - запиту
        private void HttpPost(object sender, RoutedEventArgs e)
        {
            try
            {
                // Посилання містить http://адреса_сайту/назва_контролеру/метод_що_повинен_спрацювати
                string uri = "http://localhost:53036/Home/PostRequest"; // Посилання на сервер
                string data = dataToSend.Text; // Текст, що будемо відправляти
                WebRequest request = WebRequest.Create(uri); // Створюємо новий запит

                // Назначаємо тип данних, що будемо відправляти. Для звичайної string використовуємо "text/plain"
                // Список всіх заголовків ContentType: https://www.freeformatter.com/mime-types-list.html
                request.ContentType = "text/plain";

                // Встановлюємо тип запиту POST
                request.Method = "POST";

                byte[] bytes = Encoding.UTF8.GetBytes(data);
                // Встановлюємо кількість байт, що будемо відправляти
                request.ContentLength = bytes.Length;

                // Створюємо потік у який записуємо данні
                Stream stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length); // Записуємо данні (відправка)
                stream.Close();

                WebResponse webResponse = request.GetResponse(); // Отримуємо відповідь з сервера
                if (webResponse == null) return; // Перевіряємо чи відповідь існує

                // Зчитуємо данні, що повернув сервер
                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                string response = streamReader.ReadToEnd();
                // Перевіряємо чи сервер повернув "OK" (означає, що все зпрацювало)
                if (response == "OK")
                {
                    MessageBox.Show("Данні відправлено на сервер!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }
        private void HttpGet(object sender, RoutedEventArgs e)
        {
            try
            {
                // GET uri зазвичай містить ще ідентифікатори того, що нам потрібно отримати (id, name, ...)
                // Виглядає так: http://адреса_сайту/назва_контролеру/метод_що_повинен_спрацювати?id=0&name=Bill

                // Посилання містить http://адреса_сайту/назва_контролеру/метод_що_повинен_спрацювати
                string uri = "http://localhost:53036/Home/GetRequest"; // Посилання на сервер
                WebRequest request = WebRequest.Create(uri); // Створюємо новий запит

                WebResponse webResponse = request.GetResponse(); // Отримуємо відповідь з сервера
                if (webResponse == null) return; // Перевіряємо чи відповідь існує

                // Зчитуємо данні, що повернув сервер
                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                // Записуємо текст у TextBox
                dataFromServer.Text = streamReader.ReadToEnd();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }
    }
}
