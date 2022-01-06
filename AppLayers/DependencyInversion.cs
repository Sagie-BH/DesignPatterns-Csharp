using System;
using System.Collections.Generic;
using System.Text;

namespace AppLayersDIP
{
    /*
     מחלקות ברמה גבוהה לא צריכות להיות תלויות במחלקות ברמה נמוכה.
     שתיהן צריכות להיות תלויות בהפשטות, הפשטות לא צריכות להיות תלויות בפרטים, הפרטים צריכים להיות תלויים בהפשטות.
     מחלקות ברמה הנמוכה - מיישמות פעולות בסיסיות כגון עבודה עם דיסק, העברת נתונים ברשת, התחברות לממסד נתונים וכו'.
     מחלקות ברמה הגבוהה - מכילות היגיון עסקי מורכב שמכוון מחלקות ברמה נמוכה לעשות משהו.

    לפעמים אנחנו מעצבים קודם מחלקות ברמה נמוכה ואחר כך מתחילים לעבוד על הרמה הגבוהה.
    זה נפוץ מאוד כאשר אתה מתחיל לפתח אב טיפוס על מערכת חדשה, ואתה עדיין לא בטוח
    מה אפשרי ברמה הגבוהה כי דברים ברמה הנמוכה עדיין לא מיושמים או ברורים, או במקרים של הוספת התנהגויות חדשות.
    גישה זאת הופכת אותנו לתלויים במחלקות פרימיטיביות.

    עקרון היפוך התלות מציע לשנות את כיוון התלות הזה.
     */

    public class BusinessLogicLayer
    {
        private readonly IRepositoryLayer DAL;

        public BusinessLogicLayer(IRepositoryLayer repositoryLayer)
        {
            DAL = repositoryLayer;
        }

        public void Save(Object details)
        {
            DAL.Save(details);
        }
    }

    public interface IRepositoryLayer
    {
        void Save(Object details);
    }

    public class DataAccessLayer : IRepositoryLayer
    {
        public void Save(Object details)
        {
            //perform save
        }
    }
}
