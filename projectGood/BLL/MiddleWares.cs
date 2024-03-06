namespace BLL
{
    public class MiddleWares
    {
        //בדיקת תקינות שם
        public static bool checkName(string name)
        {
           if(name.Length > 1) 
                return true;
            return false;
            
        }
        //בדיקת תקינות טלפון
        public static bool checkPhone(string phone)
        {
            if(phone.Length > 1)
            return true;
            return false;
        }
        //בדיקת תקינות מייל
        public static bool checkMail(string mail)
        {
           if(mail.Length > 1)
            return true;
           return false;
        }
        //בדיקת תקינות סיסמא
        public static bool checkPassword(string password)
        {
           if (password.Length > 1)
            return true;
           return false;
        }
    }
}