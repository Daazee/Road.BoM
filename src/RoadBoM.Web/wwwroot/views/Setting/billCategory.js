'use strict';
function BillCategory(permission) {
    debugger;
    let billCategory = Object.create(BillCategory.prototype);
    billCategory.elements = {
        billCategoriesTable: $("#table-billCategories"),
    };

    billCategory.apiURL = {
        getBillCategoriesUrl: baseUrl + "/Setting/PostBillCategories",
    };
    return billCategory;
}

BillCategory.prototype.init = function () {
    this.bindBillCategories();
};

BillCategory.prototype.bindBillCategories = function () {
    try {
        let datatable = this.elements.billCategoriesTable;

        if (datatable.length) {
            var dtUser = datatable.DataTable({
                ajax: {
                    url: this.apiURL.getBillCategoriesUrl,
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
                    { data: 'code', name: 'Code', autoWidth: true },
                    { data: 'description', name: 'Description', autoWidth: true }
                ],
                //columnDefs: [{
                //    targets: [0],
                //    visible: false,
                //    searchable: false
                //}],
            });
        }
    } catch (e) {
        debugger;
    }
};

BillCategory.prototype.reloadConfigurationTable = function () {
    var dataTable = this.elements.billCategoriesTable.DataTable();
    dataTable.ajax.reload();
};

// Other methods like addConfiguration, renderEditConfigView, etc. are still to be implemented or removed.
