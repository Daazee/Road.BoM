'use strict';
function Road(permission) {
    debugger;
    let road = Object.create(Road.prototype);
    road.elements = {
        roadTable: $("#table-roads"),
    };

    road.apiURL = {
        getRoadsUrl: baseUrl + "/Road/PostRoads",
    };
    return road;
}

Road.prototype.init = function () {
    this.bindRoads();
};

Road.prototype.bindRoads = function () {
        let datatable = this.elements.roadTable;

        if (datatable.length) {
            var dtUser = datatable.DataTable({
                ajax: {
                    url: this.apiURL.getRoadsUrl,
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
                    { data: 'name', name: 'Name', autoWidth: true },
                    { data: 'location', name: 'Location', autoWidth: true },
                    { data: 'width', name: 'Width', autoWidth: true },
                    { data: 'row', name: 'Row', autoWidth: true },
                    { data: 'poles', name: 'Poles', autoWidth: true },
                    { data: 'type', name: 'Type', autoWidth: true },
                    { data: 'culvert', name: 'Culvert', autoWidth: true },
                    { data: 'outfall', name: 'Outfall', autoWidth: true },
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
                        var htmlCheckbox = '<input type="checkbox" id="' + full.id + '"  Class="form-check-input" checked onclick="road.renderEditConfigView(\'' + full.id + '\')">';
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
};

Road.prototype.renderEditConfigView = function (configId) {
    alert("Render Edit View In-Progress");
    //if (configId != null) {

    //    ajaxSetup(POST, billCategory.apiURL.renderEditConfigViewUrl, ContentTypeJSON, DataTypeJSON, { "configId": configId }, IsAsync, IsNotCache,
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

Road.prototype.reloadConfigurationTable = function () {
    var dataTable = this.elements.roadTable.DataTable();
    dataTable.ajax.reload();
};