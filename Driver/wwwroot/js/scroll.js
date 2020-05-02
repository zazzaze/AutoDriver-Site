 $(document).ready(function(){
    $("#menu").on("click","a", function (event) {
        $('.allMenu').animate({
            right: '-700px'
        }, 200);
        event.preventDefault();
        var id  = $(this).attr('href'),
            top = $(id).offset().top;
            top-=90;
        $('body,html').animate({scrollTop: top}, 1500);
    });
});
