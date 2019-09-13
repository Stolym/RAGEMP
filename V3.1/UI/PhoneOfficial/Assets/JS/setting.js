$(() => {
    $('#changeunlocked').change(function(){
        $(".screen_unlocked").attr("src", $(this).val());
    });
    $('#changelocked').change(function(){
        $(".screen_locked").attr("src", $(this).val());
    });
});