using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telegram.Bot;
using Telegram.Helpers;

namespace Telegram.Controllers
{
    public class HomeController : Controller
    {
        const string TOKEN = "805972710:AAHzgJfyoIkn-k_Fw04egjM9ENAE0kj-KuY";
        const string ChatId = "-1001204533607";
        TelegramBotClient bot = new TelegramBotClient(TOKEN);
        public ActionResult Index()
        {
            ViewBag.LstSymbol = Common.GetSymbols();
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SendMessageAsync(string symbol, string type)
        {
            string message = " \n\n\n";
            message += "\n\n\n*" + symbol + "*\n";
            message += "*" + type + "*\n";
            message += "Điều kiện vào lệnh: Sau khi kết thúc nến hiện tại\n";
            message += "_" + DateTime.Now.ToString("dd/MM HH:mm:ss") + "_";
            await bot.SendTextMessageAsync(ChatId, message, Bot.Types.Enums.ParseMode.Markdown);
            return Json(new { Result = true, JsonRequestBehavior.AllowGet });
        }
    }
}