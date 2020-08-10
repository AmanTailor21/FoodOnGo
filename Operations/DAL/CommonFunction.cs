using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Operations.DAL
{
    public class CommonFunction
    {
        public static string GenerateCode(int length)
        {
            string numbers = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string characters = numbers;
            string OTP = string.Empty;
            for(int i=0;i<length;i++)
            {
                string character = string.Empty;
                do
                {
                    int Index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[Index].ToString();
                } while (OTP.IndexOf(character) != -1);
                OTP += character;

            }
            return OTP;
        }

        public static void SendEmail(string toemail, string subject, string details,string OTP)
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("foodongo.service@gmail.com");
            Msg.To.Add(toemail);
            Msg.Subject = subject;
            Msg.Body = "<div style='border:1px solid black;border-radius:25px;padding:20px;'><h2 style='text-align:center;text-decoration:italics;'>Food On Go</h2> <hr><center>"
                             + details + 
                             "<br/> Your Email Id=" 
                             + toemail + 
                             "<br/>Your OTP=" 
                              + OTP + 
                       "</center></div>";
            Msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("foodongo.service@gmail.com", "Keval22np");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
        }

        public static void SendEmailPassword(string toemail, string subject, string details, string password,string OTP)
        {
            //string OTP = CommanFunction.GenerateCode(6);
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("foodongo.service@gmail.com");
            Msg.To.Add(toemail);
            Msg.Subject = subject;
            Msg.Body = "<div style='border:1px solid black;border-radius:25px;padding:20px;'><h2 style='text-align:center;text-decoration:italics;'> Food On Go</h2> <hr><center> "
                                      + details +
                                      "<br/> Your Email Id="
                                      + toemail +
                                      "<br/>Your Password="
                                       + password +
                                       "<br/>Your OTP="
                                       +OTP+
                                "</center></div>";
            Msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("foodongo.service@gmail.com", "Keval22np");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
        }

        public static string Alert_MessageBox(string sMsg)
        {
            return "<div class='alert alert-danger'>" + sMsg + "</div>";
        }
        public static string Success_MessageBox(string sMsg)
        {
            return "<div class='alert alert-success'>" + sMsg + "</div>";
        }
    }
}
