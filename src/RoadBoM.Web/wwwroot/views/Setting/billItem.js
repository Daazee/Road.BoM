'use strict';
function BillItem(permission) {
    debugger;
    let billItem = Object.create(BillItem.prototype);
    billItem.elements = {
        billItemsTable: $("#table-billItems"),
    };

    billItem.apiURL = {
        getBillItemsUrl: baseUrl + "/Setting/GetBillItems",
    };
    return billItem;
}

BillItem.prototype.init = function () {
    this.bindBillItems();
};

BillItem.prototype.bindBillItems = function () {
    try {
        let datatable = this.elements.billItemsTable;

        if (datatable.length) {
            var dtUser = datatable.DataTable({
                ajax: {
                    url: this.apiURL.getBillItemsUrl,
                    type: 'POST',
                    dataType: 'json',
                    data: function (data) {
                        // Additional data handling can be done here if needed
                    }
                },
                processing: true,
                serverSide: true,
                filter: true,
                columns: [
                    { data: 'id' },
                    { data: 'code', name: 'Code', autoWidth: true },
                    { data: 'description', name: 'Description', autoWidth: true },
                    { data: 'unit', name: 'Unit', autoWidth: true },
                    {
                        data: 'status', name: 'Status', autoWidth: true, render: function (data) {
                            if (data === 0)
                                return "Active"
                            else
                                return "Inactive"
                        }
                    },
                    {
                        data: 'createdOn', name: 'CreatedOn', autoWidth: true, render: function (data) {
                            var date = new Date(data);
                            var month = date.getMonth() + 1;
                            return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                        }
                    },
                    {
                        data: 'updatededOn', name: 'UpdatededOn', autoWidth: true, render: function (data) {
                            if (data !== "" && data !== null && data !== undefined) {
                                var date = new Date(data);
                                var month = date.getMonth() + 1;
                                return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                            }
                            return "";
                        }
                    },
                    { data: '', autoWidth: true },
                ],
                columnDefs: [{
                    targets: [0],
                    visible: false,
                    searchable: false
                },
                {
                    // Actions
                    targets: -1,
                    title: 'Actions',
                    searchable: false,
                    orderable: false,
                    render: function (data, type, full, meta) {
                        var btnEditConfig = "btnEditConfig" + full.id;
                        var htmlCheckbox = '<input type="checkbox" id="' + full.id + '"  Class="form-check-input" checked onclick="billItem.renderEditConfigView(\'' + full.id + '\')">';
                        var chkConfig = "chkConfig" + full.id;
                        return (
                            '<div class="d-inline-block text-nowrap">' +
                            '<div class="form-check form-switch app-switch camp-switch">' + htmlCheckbox + ' </div>' +
                            '</div>'
                        );
                    }
                }],
            });
        }
    } catch (e) {
        debugger;
    }
};

BillItem.prototype.renderEditConfigView = function (configId) {
    alert("Render Edit View In-Progress");
    //if (configId != null) {

    //    ajaxSetup(POST, billItem.apiURL.renderEditConfigViewUrl, ContentTypeJSON, DataTypeJSON, { "configId": configId }, IsAsync, IsNotCache,
    //        function (response) {
    //            if (response != null) {
    //                var $el = $("#offcanvasEditConfig").offcanvas();
    //                $el.offcanvas("show");
    //                $("#dvEditConfig").html(response);
    //            }
    //            else
    //                Swal.fire(Error("Failed to get config details"))
    //        },
    //        function (error) {
    //            Swal.fire(Error("Internal server error"))
    //        }
    //    );
    //}
}

BillItem.prototype.reloadConfigurationTable = function () {
    var dataTable = this.elements.billItemsTable.DataTable();
    dataTable.ajax.reload();
};

// Other methods like addConfiguration, renderEditConfigView, etc. are still to be implemented or removed.
