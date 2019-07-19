var k123 = k123 || {};
k123.forms = k123.forms || {};
k123.forms.kochegarova = k123.forms.kochegarova || {};

(function() {
  // this handler have 2 fields , when they change than
  this.fieldsOnChange = function(executionContent) {
    var formContext = executionContent.getFormContext();
    var firstNameAttr = formContext.getAttribute("new_firstname");
    var lastNameAttr  = formContext.getAttribute("new_lastname");
    var nameAttr = formContext.getAttribute("new_name");
    var firstName="";
    var lastName ="";
    if (firstNameAttr !== null) {
        firstName = firstNameAttr.getValue();
    }
    if (lastNameAttr !== null) {
        lastName = lastNameAttr.getValue();
    }
    if(nameAttr !== null ) {
        nameAttr.setValue(firstName + " " + lastName);
    }
  };
}.call(k123.forms.kochegarova));
