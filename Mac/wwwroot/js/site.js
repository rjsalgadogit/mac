// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GotoControllerAsync(url, type, data, includeAntiforgeToken, returnType, successCallback) {
	// type (e.g. post, get etc.)
	// returnType (e.g. json, html etc.)
	// data (json objects)

	const promiseAsync = new Promise((resolve, reject) => {
		resolve('resolve');
	});

	promiseAsync.then((test) => {

		ProcessAsync(url, type, data, includeAntiforgeToken, returnType)
			.then((response) => {

				if (typeof successCallback != 'undefined' && typeof successCallback == 'function') {
					successCallback(response);
				}
			});
	})
}

async function ProcessAsync(url, type, obj, includeAntiforgeToken, returnType) {

	return await $.ajax({
		type: type,
		url: url,
		contentType: includeAntiforgeToken ? 'application/json; charset=utf-8' : 'application/x-www-form-urlencoded; charset=UTF-8',
		data: includeAntiforgeToken ? JSON.stringify(obj) : obj,
		dataType: returnType,
		async: true,
		beforeSend: function (jqXHR, settings) {

			if (includeAntiforgeToken)
				jqXHR.setRequestHeader('RequestVerificationToken', $('.AntiForge' + ' input').val());
		}
	});
}

function loadGrid(readAllRowDataUrl
	, readOneRowDataUrl
	, deleteRowDataUrl
	, gridContainerId
	, pageSize
	, tableObj = { TableId: '', Columns: [{ DataField: '', DataType: '' }] }) {
	/* 
	 * e.g. FORMAT:
	 * tableObj = {
     *      TableId: 'table_name', 
     *      Columns: [
     *          { DataField: 'Id', DataType: 'int', IsKey: true },
     *          { DataField: 'Description', DataType: 'string', IsKey: false }
     *      ]
     *  }
	 *  
	 */

	let gridLayoutLink = '/Home/_GridTable';

	// Assign values to the table object properties
	tableObj.ReadAllRowDataUrl = readAllRowDataUrl;
	tableObj.ReadOneRowDataUrl = readOneRowDataUrl;
	tableObj.DeleteRowDataUrl = deleteRowDataUrl;
	tableObj.PageSize = pageSize;

	GotoControllerAsync(gridLayoutLink, 'POST', tableObj, false, 'html', function (response) {
		$('#' + gridContainerId).html(response);
	});
}