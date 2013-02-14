(function() {
  var ViewModel, vm,
    _this = this;

  ViewModel = (function() {
    var _this = this;

    function ViewModel() {
      this.people = ko.observableArray([]);
      this.editingPerson = ko.observable();
    }

    ViewModel.removePerson = function(person) {
      return $.ajax('http://localhost/vivagymfrank/api/people/' + person.Name, {
        type: 'DELETE',
        data: JSON.stringify(person),
        contentType: 'application/json; charset=utf-8',
        success: function(data) {
          return console.log("deleted " + person.Name);
        }
      });
    };

    return ViewModel;

  }).call(this);

  vm = new ViewModel();

  ViewModel.prototype.setEditingPerson = function(person) {
    console.log("setting your sheet to " + person.Name);
    _this.editingPerson = ko.observable(person);
    console.log(_this.editingPerson);
    return _this.getEditingPerson;
  };

  ViewModel.prototype.getEditingPerson = function() {
    console.log("getting your sheet");
    return _this.editingPerson;
  };

  $(function() {
    ko.applyBindings(vm);
    return $.getJSON("http://localhost/vivagymfrank/api/people/", function(people) {
      var person;
      vm.people(people);
      person = function() {
        return {
          Name: "Chris",
          Age: 20
        };
      };
      return vm.editingPerson(person);
    });
  });

}).call(this);
