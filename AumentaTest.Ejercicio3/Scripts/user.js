if (!jQuery) { throw new Error("Requires jQuery") }

+function ($) {
    "use strict";

    $("#showPass").change(function () {
        var checked = $(this).is(":checked");
        if (checked) {
            $("#Password").attr("type", "text");
        } else {
            $("#Password").attr("type", "password");
        }
    });

}(window.jQuery);