$(document).ready(function () {
    $('[data-bs-target="#exampleModal"]').on('click', function () {
        var phoneNumber = $(this).data('phonenumber');

        $('#OldPhoneNumber').val(phoneNumber); 
    });
});
