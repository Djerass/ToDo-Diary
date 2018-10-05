// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 
var country={
    Name:"Russia",
    Language:"russian",
    Population:147000000,
    Capital:{
        name: "Moscow",
        year: 1147,
        population: 12500000
    },
    display: function(){
      return "Name: "+country.Name+", "+"Language: "+country.Language+", Population: "+country.Population;   
    }
    
};



var popup = window.open('https://microsoft.com', 'Microsoft', 'width=400, height=400, resizable=yes');