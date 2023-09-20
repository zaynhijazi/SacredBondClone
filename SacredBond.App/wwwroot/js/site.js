const tx = document.getElementsByTagName("textarea");
for (let i = 0; i < tx.length; i++) {
    tx[i].setAttribute("style", "height:" + (tx[i].scrollHeight) + "px;overflow-y:hidden;");
    tx[i].addEventListener("input", OnTextareaInput, false);
}

function OnTextareaInput() {
    this.style.height = 0;
    this.style.height = (this.scrollHeight) + "px";
}


(function ($) {
    $.fn.disableInput = function () {
        var ignoreDisableInputClass = "ignore-disable-input";
        $("span.view-input", this).remove();
        $('input[type!="hidden"][type!="button"][type!="submit"][type!="checkbox"]', this).each(function () {
            if (!$(this).hasClass(ignoreDisableInputClass)) {
                var text = this.value;
                if ($(this).hasClass("money")) {
                    try {
                        const formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', minimumFractionDigits: 2 });
                        text = formatter.format(text);
                    }
                    catch (e) { }
                }
                $("<span />", { text: text, "class": "view-input" }).insertAfter(this);
                $(this).hide();
                $(this).parent().addClass("read-only");
            }
        });


        $('input[type="checkbox"]', this).each(function () {
            if (!$(this).hasClass(ignoreDisableInputClass)) {
                $(this).attr('disabled', true);
                $(this).parent().addClass("read-only");
            }
        });

        $('select', this).each(function () {
            if (!$(this).hasClass(ignoreDisableInputClass)) {

                $("<span />", { text: $(this).find('option:selected').text(), "class": "view-input" }).insertAfter(this);

                $(this).attr('disabled', true);
                $(this).hide();
                $(this).parent().addClass("read-only");
            }
        });

        $('textarea', this).each(function () {
            if (!$(this).hasClass(ignoreDisableInputClass)) {
                $("<span />", { text: this.value, "class": "view-input" }).insertAfter(this);
                $(this).hide();
                $(this).parent().addClass("read-only");
            }
        });

        return this;
    }
}(jQuery));