function confirmLockUser(userName) {
    console.log('a');
    if (confirm("Do you want lock user ?")) {
        $.ajax({
            type: "POST",
            url: "/UserLogin/LockAccount?username=" + userName,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Lock user successful !");
            }
        });
    }
}
function confirmActiveUser(userName) {
    console.log('a');
    if (confirm("Do you want active user ?")) {
        $.ajax({
            type: "POST",
            url: "/UserLogin/ActiveAccount?username=" + userName,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Active user successful !");
            }
        });
    }
}

