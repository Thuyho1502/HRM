function confirmLockRegion(regionId) {
    console.log('a');
    if (confirm("Do you want lock this region ?")) {
        $.ajax({
            type: "POST",
            url: "/Region/LockRegion?regionId=" + regionId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Lock user successful !");
            }
        });
    }
}
function confirmActiveRegion(regionId) {
    console.log('a');
    if (confirm("Do you want active this region ?")) {
        $.ajax({
            type: "POST",
            url: "/Region/ActiveRegion?regionId=" + regionId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Active user successful !");
            }
        });
    }
}
