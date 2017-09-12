(function() {
    $(document).ready(function () {
        $("#TourDate1").fdatepicker({
            format: "mm/dd/yyyy",
            disableDblClickSelection: true
        });
        $("#TourDate2").fdatepicker({
            format: "mm/dd/yyyy",
            disableDblClickSelection: true
        });
        $("#TourDate3").fdatepicker({
            format: "mm/dd/yyyy",
            disableDblClickSelection: true
        });
        $("#PartyDate").fdatepicker("update", new Date());

        $("#NumberOfKids").on("blur", function () {
            if (isNaN($(this).val()))
                $(this).val("");
            else if (Number($(this).val()) < 20)
                $(this).val("20");
        });
    });
})();