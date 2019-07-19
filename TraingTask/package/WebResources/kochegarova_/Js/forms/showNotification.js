var k123 = k123 || {};
k123.forms = k123.forms || {};
k123.forms.kochegarova = k123.forms.kochegarova || {};
k123.forms.kochegarova.notification = k123.forms.kochegarova.notification || {};

(function() {
  this.deleteAllChildren = function() {
    var alertConfig = {
      confirmButtonLabel: "Ok",
      text: "Delete children functionality has not implemented yet."
    };
    var alertOptions = { height: 200, width: 350 };
    var grid = Xrm.Page.getControl("Child").getGrid();
    var rowsData = grid.getRows().getAll();

  
    if (rowsData.length > 0) {
      Xrm.Navigation.openAlertDialog(alertConfig, alertOptions);
    } else {
      console.log("ddd");
      alertConfig.text = "The grid is empty";
      Xrm.Navigation.openAlertDialog(alertConfig, alertOptions);
    }
  };
}.call(k123.forms.kochegarova.notification));

