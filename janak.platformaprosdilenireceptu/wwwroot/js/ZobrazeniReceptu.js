
// Převést řetězec JSON na pole objektů
let jsonStr1 = document.getElementById('seznamSurovin');
let jsonStrValue1 = jsonStr1.value;
let seznamSurovin = JSON.parse(jsonStrValue1);

// Teď můžete pracovat s polem objektů

if (seznamSurovin != null) {
    // Získání reference na div
    var seznamSurovinDiv = document.getElementById('seznamSurovinDiv');

    // Vytvoření tabulky
    var table = document.createElement('table');

    // Nastavení vlastností tabulky
    table.style.backgroundColor = '#000000';
    table.style.borderRadius = '10px';
    table.style.width = '60%';
    table.style.paddingBottom = '200px';

    // Vytvoření řádku pro Header
    var headerRow = table.insertRow(0);
    var headerCell = headerRow.insertCell(0);
    headerCell.colSpan = 2;
    headerCell.innerHTML = '<strong>Seznam Surovin</strong>';
    headerCell.style.textAlign = 'center';
    headerCell.style.padding = '10px';
    headerCell.style.fontSize = '25px';

    for (var i = 0; i < seznamSurovin.length; i++) {
        var surovina = seznamSurovin[i];

        var row = table.insertRow(i + 1);
        var nazevCell = row.insertCell(0);
        var mnozstviCell = row.insertCell(1);

        nazevCell.innerHTML = '&bull; ' + surovina.Nazev;
        nazevCell.style.paddingLeft = '10px';
        nazevCell.style.paddingBottom = '10px';
        mnozstviCell.innerHTML = surovina.Mnozstvi;
        mnozstviCell.style.paddingBottom = '10px';
        //mnozstviCell.style.padding = '8px';
    }

    // Přidání tabulky do divu
    seznamSurovinDiv.appendChild(table);
}


// Převést řetězec JSON na pole objektů
let jsonStr2 = document.getElementById('postupPripravy');
let jsonStrValue2 = jsonStr2.value;
let postupPripravy = JSON.parse(jsonStrValue2);

var postupPripravyDiv = document.getElementById('postupPripravyDiv');

// Vytvoření paragrafových elementů pro každý prvek v postupPripravy
if (postupPripravy != null) {
    postupPripravy.forEach(function (krok, index) {
        var paragraph = document.createElement('p');

        // Nastavení různých parametrů velikosti
        paragraph.style.fontSize = '16px';
        paragraph.style.width = '100%';

        paragraph.textContent = (index + 1) + '. ' + krok;

        // Nastavení textu paragrafu
        //paragraph.textContent = krok;

        // Přidání paragrafu do divu
        postupPripravyDiv.appendChild(paragraph);
    });
}