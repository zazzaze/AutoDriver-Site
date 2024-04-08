window.onload = function loaded() {
    var preloader = document.getElementById('loaderArea');
    var load = document.getElementById('load');
    load.style.opacity=0;
    preloader.style.opacity=0;
    setTimeout(function(){load.style.display='none';preloader.style.display='none'},350);
}