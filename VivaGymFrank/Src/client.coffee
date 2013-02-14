class ViewModel
  constructor: () ->
    @people = ko.observableArray([])
    @editingPerson = ko.observable()
# edit function that will be used after binding is sorted on editing form
#  editPerson: (person) =>
#    $.ajax 'http://localhost/vivagymfrank/api/people/' + person.Name,
#      type: 'PUT'
#      data: JSON.stringify person
#      contentType: 'application/json; charset=utf-8',
#      success: (data) ->
#        $("#myeditform").trigger('reveal:close')
  @removePerson = (person) =>
    $.ajax 'http://localhost/vivagymfrank/api/people/' + person.Name,
      type: 'DELETE'
      data: JSON.stringify person
      contentType: 'application/json; charset=utf-8',
      success: (data) ->
        console.log("deleted " + person.Name)  
vm = new ViewModel()
#trying to make setEditing externally accessable
ViewModel.prototype.setEditingPerson = (person) =>
  console.log("setting your sheet to " + person.Name)
  @editingPerson = ko.observable(person)
  console.log(@editingPerson)
  return @getEditingPerson
#trying to make getEditing externally accessable
ViewModel.prototype.getEditingPerson = () =>
  console.log("getting your sheet")
  return @editingPerson
$ ->
  ko.applyBindings(vm)
  $.getJSON "http://localhost/vivagymfrank/api/people/", (people) ->
    vm.people(people)
    person = () -> {Name: "Chris", Age: 20}
    vm.editingPerson(person)
#javascript that also does not work :-/
#`function ViewModel() {
#    var self = this;
#    self.people = ko.observable([]);
#    self.editingPerson = ko.observable();
#    
#    self.show = function(person) { 
#    self.editingPerson(person); 
#    console.log(person.Name)
#    };    
#};
#var vm = new ViewModel()
#ko.applyBindings(vm);
#$.getJSON("http://localhost/vivagymfrank/api/people/", function(people) {
#  return vm.people(people);
#  });
#`