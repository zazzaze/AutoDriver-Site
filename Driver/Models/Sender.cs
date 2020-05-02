using System;

namespace Driver.Models
{
    public class Sender
    {
        public String ForMail { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String CarName { get; set; }
        public String Number { get; set; }
        public String Comment { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}\n\rНомер телефона: {Phone}\n\rМодель машины: {CarName}\n\rVIN-номер: {Number}" +
                   $"\n\rКомментарий к заявке: {Comment}";
        }
    }
}