using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values = nm.GetList();
            GetNotificationTimeDescription(values);
            return View(values);
        }
        public void GetNotificationTimeDescription(List<Notification> notificationList)
        {
            foreach (var item in notificationList)
            {
                item.NotificationTimeDescription = ToRelativeDate(item.NotificationDate);
            }
        }

        public static string ToRelativeDate(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
                return string.Format("{0} saniye önce", timeSpan.Seconds);

            if (timeSpan <= TimeSpan.FromMinutes(60))
                return String.Format("{0} dakika önce", timeSpan.Minutes);

            if (timeSpan <= TimeSpan.FromHours(24))
                return String.Format("{0} saat önce", timeSpan.Hours);

            if (timeSpan <= TimeSpan.FromDays(30))
                return String.Format("{0} gün önce", timeSpan.Days);

            if (timeSpan <= TimeSpan.FromDays(365))
                return String.Format("{0} ay önce", timeSpan.Days / 30);

            return String.Format("{0} yıl önce", timeSpan.Days / 365);
        }

    }
}
