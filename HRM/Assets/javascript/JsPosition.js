function confirmLockPosition(positionId) {
    console.log('a');
    if (confirm("Do you want lock this position ?")) {
        $.ajax({
            type: "POST",
            url: "/Position/LockPosition?positionId=" + positionId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Lock user successful !");
            }
        });
    }
}
function confirmActivePosition(positionId) {
    console.log('a');
    if (confirm("Do you want active this position ?")) {
        $.ajax({
            type: "POST",
            url: "/Position/ActivePosition?positionId=" + positionId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Active user successful !");
            }
        });
    }
}
