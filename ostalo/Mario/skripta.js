var studijskiProgram = document.getElementById("studijski-program");
studijskiProgram.addEventListener("change", function() {
  var odabraniProgram = studijskiProgram.options[studijskiProgram.selectedIndex].value;
  console.log(odabraniProgram);
});


$(document).ready(function() {
    $("#semestar-select").on("change", function() {
      var semestar = parseInt($(this).val());
      var tabelaPredmeta = $("#tabela-predmeta");
      tabelaPredmeta.empty();
  
      var predmetiZaSemestar = predmeti.filter(function(p) {
        return semestar === 0 || p.semestar === semestar;
      });
  
      predmetiZaSemestar.forEach(function(p, index) {
        var tr = $("<tr/>");
        tr.append($("<td/>").text(index + 1));
        tr.append($("<td/>").text("Semestar " + p.semestar));
        tr.append($("<td/>").text("Izaberite predmet"));
        tr.append($("<td/>"));
        tr.append($("<td/>"));
        tr.append($("<td/>").text("-"));
        tabelaPredmeta.append(tr);
  
        var select = $("<select/>");
        select.append($("<option/>").text("Izaberite predmet"));
  
        p.predmeti.forEach(function(predmet) {
          var option = $("<option/>")
            .text(predmet.naziv + " (" + predmet.sifra + ")")
            .data("predmet", predmet);
          select.append(option);
        });
  
        select.on("change", function() {
          var selectedPredmet = $(this).find(":selected").data("predmet");
          var td = $(this).parent();
          td.next().text(selectedPredmet.sifra);
          td.next().next().text(selectedPredmet.tip);
          td.next().next().next().text(selectedPredmet.bodovi);
        });
      
        var td = tr.children().eq(2);
        td.append(select);
      });
    });
});


function showSmer() {
    var stud_prog = document.getElementById("stud_prog").value;
    var smer = document.getElementById("smer");
    smer.innerHTML = "";
    var smeri;
    if (stud_prog == "racunarstvo-i-informatika") {
      smeri = ["Softversko inženjerstvo", "Računarsko inženjerstvo"];
    } else if (stud_prog == "elektronika-i-telekomunikacije") {
      smeri = ["Elektronika", "Telekomunikacije"];
    } else if (stud_prog == "elektroenergetika-i-automatika") {
      smeri = ["Elektroenergetika", "Automatika"];
    }
    for (var i = 0; i < smeri.length; i++) {
      var option = document.createElement("option");
      option.text = smeri[i];
      option.value = smeri[i];
      smer.add(option);
    }
    document.getElementById("smer_div").style.display = "block";
  }