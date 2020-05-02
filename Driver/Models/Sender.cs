using System;

namespace Driver.Models
{
    public class Sender
    {
        public String ForMail { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String CarName { get; set; } = "Клиент не указал модель машины";
        public String Number { get; set; } = "Клиент не указал VIN-номер машины";
        public String Comment { get; set; } = "Нет комментария";

        public override string ToString()
        {
            return $"Имя: {Name}\n\rНомер телефона: {Phone}\n\rМодель машины: {CarName}\n\rVIN-номер: {Number}" +
                   $"\n\rКомментарий к заявке: {Comment}";
        }
    }
}