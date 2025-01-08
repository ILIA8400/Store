function openModal() {
    debugger;
    $(function () {
        $(document).ready(function () {
            // Initialize the dialog
            $("#EditModal").dialog({
                autoOpen: false,
                modal: true,
                buttons: {
                    "بروزرسانی": function () {
                        const phoneNumber = $("#phoneNumber").val();
                        const balance = $("#balance").val();

                        if (phoneNumber && balance) {
                            alert(`شماره موبایل: ${phoneNumber}\nمبلغ موجودی: ${balance}`);
                            $(this).dialog("close");
                        } else {
                            alert("لطفاً همه فیلدها را پر کنید.");
                        }
                    },
                    "بستن": function () {
                        $(this).dialog("close");
                    },
                },
            });

            // Open dialog on button click
            window.openModal = function () {
                $("#EditModal").dialog();
            };
        });
    });
}