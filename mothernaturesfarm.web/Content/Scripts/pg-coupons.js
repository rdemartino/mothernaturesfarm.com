(function () {
    function imgLoaded(pWin) {
        pWin.print();
        pWin.close();
    }
    function printImage() {
        var imgSrc = $("#imgCpn").attr("src");
        var prnWin = window.open("", "Print Window", "height=400,width=600");
        prnWin.document.write("<html><head><title>Print Window</title>");
        prnWin.document.write("</head><body><img src='");
        prnWin.document.write(imgSrc);
        prnWin.document.write("' /></body></html>");
        var img = prnWin.document.querySelector("img");
        if (img.complete) {
            imgLoaded(prnWin);
        } else {
            img.addEventListener("load", function() {
                imgLoaded(prnWin);
            });
        }
    }
    $(document).ready(function() {
        $("#btnPrnCpn").on("click", function () {
            printImage();
        });    
    });
})();