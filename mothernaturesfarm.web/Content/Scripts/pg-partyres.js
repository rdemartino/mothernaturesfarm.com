(function() {
    $(document).ready(function() {
        $("#PartyDate").fdatepicker({
            format: "mm/dd/yyyy",
            disableDblClickSelection: true
        });
        $("#PartyDate").fdatepicker("update", new Date());

        $("#NumberOfKids").on("blur", function () {
            if (isNaN($(this).val()))
                $(this).val("");
            else if (Number($(this).val()) < 10)
                $(this).val("10");
        });
    });
})();