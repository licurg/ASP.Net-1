using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test
{
    public class HomeController : Controller
    {
        public static string data; // Сюди будемо записуати string, що передається

        // Головний метод. Запускається, коли на сервер звертаються за адресою: http://адреса_сайту
        public string Index()
        {
            // Виводить строку у вікно браузера
            return data;
        }

        // Метод POST-запиту. Запускається, коли на сервер звертаються за адресою: http://адреса_сайту/Home/PostRequest
        [HttpPost]
        public string PostRequest()
        {
            // Зчитуємо тіло запиту 
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                // Записуємо у data
                data = reader.ReadToEnd();
            }
            // Повертаємо ОК у програму wpf, що каже про успішно виконаний запит
            return "OK";
        }

        // Метод GET-запиту. Запускається, коли на сервер звертаються за адресою: http://адреса_сайту/Home/GetRequest
        [HttpGet]
        public string GetRequest()
        {
            // Повертаємо нашу string у програму wpf
            return data;
        }
    }
}
