function confirmLockDepartment(departmentId) {
    console.log('a');
    if (confirm("Do you want lock this department ?")) {
        $.ajax({
            type: "POST",
            url: "/Department/LockDepartment?departmentId=" + departmentId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Lock user successful !");
            }
        });
    }
}
function confirmActiveDepartment(departmentId) {
    console.log('a');
    if (confirm("Do you want active this department ?")) {
        $.ajax({
            type: "POST",
            url: "/Department/ActiveDepartment?departmentId=" + departmentId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("Active user successful !");
            }
        });
    }
}
