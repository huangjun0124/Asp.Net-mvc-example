$(function () {
    var ajaxFormSubmit = function () {
        var form = $(this);

        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };

        $.ajax(options).done(function(data) {
            var target = $(form.attr("data-jun-target"));
            target.replaceWith(data);
        });
		
        return false;
    };

    var submitAutoCompleteForm = function(event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutoComplete = function() {
        var $input = $(this);
        var options = {
            source: $input.attr("data-jun-autocomplete"),
            select:submitAutoCompleteForm
        };

        $input.autocomplete(options);
    };


    $("form[data-jun-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-jun-autocomplete]").each(createAutoComplete);
});