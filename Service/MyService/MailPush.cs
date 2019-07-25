using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.MyService
{
    public static class MailPush
    {
        public static void ToMail(string subject,string bodydescription)
        {


            MailMessage mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
            mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
            mail.To.Add("kabaliemre@hotmail.com"); //Kime mail gönderilecek.
            

            //mail kimden geliyor, hangi ifade görünsün?
            mail.From = new MailAddress("kabalicafe@gmail.com","CafeAutomationTeam");
            mail.Subject = "Konu: " + subject;//mailin konusu

            //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
            mail.Body = "Mesajınız Var:"+bodydescription;
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient();

            //mailin gönderileceği adres ve şifresi
            smp.Credentials = new NetworkCredential("kabalicafe@gmail.com", "deneme");
            //kabalicafe@gmail.com-sifreyi proje yöneticisinden talep ediniz
            smp.Port = 587;
            
            smp.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
            smp.EnableSsl = true;
            smp.Send(mail);//mail isimli mail gönderiliyor.
            

        }



    }
}
