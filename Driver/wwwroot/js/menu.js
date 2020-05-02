var button = document.querySelector('.phone-button');
var menu = document.querySelector('.allMenu');
var ref = document.querySelectorAll('.click');

for (var i = 0; i < ref.length; i++){
    ref[i].addEventListener('click', function(){
        if (button.id == 'menu-open'){
            button.id = 'close';
            menu.classList.remove('all-menu-close');
            menu.classList.remove('menu-open');
            menu.classList.add('open');
            button.classList.add('back');
        }
        else{
            button.id = 'menu-open';
            menu.classList.remove('open');
            button.classList.remove('back');
        }
    })
}