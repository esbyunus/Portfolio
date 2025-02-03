$(document).ready(function() {
    // URL'den mesaj durumunu kontrol et
    const urlParams = new URLSearchParams(window.location.search);
    const messageStatus = urlParams.get('messageStatus');

    if (messageStatus === 'success') {
        $('.message-success').fadeIn();
        setTimeout(function() {
            $('.message-success').fadeOut();
        }, 3000);
    } else if (messageStatus === 'error') {
        $('.message-warning').fadeIn();
        setTimeout(function() {
            $('.message-warning').fadeOut();
        }, 3000);
    }
}); 