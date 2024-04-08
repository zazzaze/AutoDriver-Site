var popup = document.querySelector('.popup');
var description = document.querySelector('.description');
var oneCityDescription = document.querySelectorAll('.city-description');
var cities = document.querySelectorAll('.query-button');
var changeCity = document.querySelectorAll('.open-popup');
var buttonDescription = document.querySelector('.description-button');
var vk = document.querySelector('.vk');
var mail = document.getElementById('forMail');
var mailQuestion = document.querySelector('.question-mail');
var Slutsk = document.querySelector('.for-Slutsk');

function changeCityandCookie(ct, ind){
    ct.addEventListener('click', function(){
        changeCity[0].innerHTML = ct.dataset.name;
        for (var j = 1; j < changeCity.length; j++)
            changeCity[j].style.display = 'none';
        for ( j = 0; j < oneCityDescription.length; j++)
            oneCityDescription[j].style.display = 'none';
        oneCityDescription[ind].style.display = 'flex';
        mailQuestion.href = 'mailto:' + ct.dataset.mail;
        mailQuestion.textContent = ct.dataset.mail;
        mail.value = ct.dataset.mail;
        vk.href = ct.dataset.vk;

        popup.classList.add('popup-close');
        setTimeout(function(){
            popup.style.display='none';
        },500);
    })
}

for (var i = 0; i < cities.length; i++){
    changeCityandCookie(cities[i], i);
};


for (var i = 0; i < changeCity.length; i++){
    changeCity[i].addEventListener('click', function(){
        popup.style.display='flex';
        setTimeout(function(){
            popup.classList.remove('popup-close');
        }, 10);
    });
};

popup.addEventListener('click', function(e){
    if((e.target.closest('.popup-card') == null) || (e.target.closest('.button-close'))){
        popup.classList.add('popup-close');
        setTimeout(function(){
            popup.style.display='none';
        },500);
    }
});