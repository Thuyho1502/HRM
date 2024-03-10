function confirmLockNation(nationId) {
    console.log('a');
    if (confirm("Do you want lock this nation ?")) {
        $.ajax({
            type: "POST",
            url: "/Nation/LockNation?nationId=" + nationId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Lock user successful !");
            }
        });
    }
}
function confirmActiveNation(nationId) {
    console.log('a');
    if (confirm("Do you want active this position ?")) {
        $.ajax({
            type: "POST",
            url: "/Nation/ActiveNation?nationId=" + nationId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Active user successful !");
            }
        });
    }
}
