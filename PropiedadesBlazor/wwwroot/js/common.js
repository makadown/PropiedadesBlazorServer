window.showToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Success", { timeOut: 10000 });
    } else if (type === "info") {
        toastr.info(message, "Info", { timeOut: 10000 });
    } else if (type === "warning") {
        toastr.warning(message, "Warning", { timeOut: 10000 });
    } else if (type === "error") {
        toastr.error(message, "Error", { timeOut: 10000 });
    }
}

window.showSwal = (type, message) => {
    if (type === "success") {
        Swal.fire("Success", message, 'success');
    }
    if (type === "error") {
        Swal.fire("Error", message, 'error');
    }
}