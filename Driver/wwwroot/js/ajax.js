$(document).ready(function(){
    $("#form").submit(function() { //устанавливаем событие отправки для формы с id=form
        console.log("test");
        const forMail = $("#forMail")[0].value;
        const name = $("#name")[0].value;
        const phone = $("#phone")[0].value;
        const carName = $("#car-name")[0].value;
        const number = $("#number")[0].value;
        const comment = $("#message")[0].value;
        if(!$("#subscribe-field").is(":checked")){
            setFailedStatus("Нужно согласиться с условиями обработки персональных данных!")
            return false;
        }
        if(forMail === ""){
            setFailedStatus("Необходимо выбрать город!");
            return false;
        }
        if(name === "" || phone === ""){
            setFailedStatus("Нам нужно знать как к вам обратиться и как с вами связаться.");
            return false;
        }
        const sender = new Sender(forMail, name, phone, carName, number, comment);
        $.post("/Site/SendMail", sender, null, "json");
        setSuccessStatus("Сообщение успешно отправлено!");
        return false;
    });
}); 

class Sender{
    constructor(forMail, name, phone, carName, number, comment) {
        this.forMail = forMail;
        this.name = name;
        this.phone = phone;
        if(carName === ""){
            carName = "Клиент не указал модель машины";
        }
        if(number === ""){
            number = "Клиент не указал VIN-номер машины";
        }
        if(comment === ""){
            comment = "Нет комментария";
        }
        this.carName = carName;
        this.number = number;
        this.comment = comment;
    }
}

const message = document.querySelector('.message-send');

function setSuccessStatus(msg){
    message.textContent = msg;
    message.classList.remove("message-send-fail", "message-send-close");
    message.classList.add("message-send", "message-send-success");
    setTimeout(closeStatus, 5000)
}

function setFailedStatus(msg){
    message.textContent = msg;
    message.classList.remove("message-send-success", "message-send-close");
    message.classList.add("message-send", "message-send-fail");
    setTimeout(closeStatus, 5000)
}

function closeStatus(){
    message.classList.add("message-send-close");
}