using System;
using Driver.Service;

namespace Driver.Models
{
    public class Sender: TGMessage
    {
        public String ForMail { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String CarName { get; set; } = "Клиент не указал модель машины";
        public String Number { get; set; } = "Клиент не указал VIN-номер машины";
        public String Comment { get; set; } = "Нет комментария";

        string TGMessage.subject => "Новая заявка с сайта";
        string TGMessage.senderInfoBody => $"""
                                                  Имя: {Name}
                                                  Номер телефона: {Phone}
                                                  Модель машины: {CarName}
                                                  VIN\-номер: {Number}
                                                  Комментарий к заявке: {Comment}
                                                  """;
    }
}