// Seznam pro ukládání surovin
let seznamSurovin = [];

function pridatSurovinu() {
    // Naètení hodnot z textových polí
    const nazev = document.getElementById('nazev').value;
    const mnozstvi = document.getElementById('mnozstvi').value;

    // Vytvoøení objektu pro surovinu
    const novaSurovina = {
        Nazev: nazev,
        Mnozstvi: mnozstvi
    };

    // Pøidání suroviny do seznamu
    seznamSurovin.push(novaSurovina);

    // Vymazání obsahu textových polí
    document.getElementById('nazev').value = '';
    document.getElementById('mnozstvi').value = '';

    // Aktualizace skrytého pole s JSON seznamem surovin
    const jsonSeznamSurovin = JSON.stringify(seznamSurovin);
    document.getElementById('jsonSeznamSurovin').value = jsonSeznamSurovin;

    // Zobrazení seznamu surovin v divu pod tlaèítkem
    zobrazitSeznamSurovin();
}

function zobrazitSeznamSurovin() {
    const seznamDiv = document.getElementById('seznamSurovin');
    seznamDiv.innerHTML = '';

    const table = document.createElement('table');
    table.classList.add('table'); // Pøidáváme tøídu pro Bootstrap

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');

    const headerNazev = document.createElement('th');
    headerNazev.textContent = 'Název suroviny';
    headerRow.appendChild(headerNazev);

    const headerMnozstvi = document.createElement('th');
    headerMnozstvi.textContent = 'Množství';
    headerRow.appendChild(headerMnozstvi);

    thead.appendChild(headerRow);
    table.appendChild(thead);

    const tbody = document.createElement('tbody');

    seznamSurovin.forEach(surovina => {
        const row = document.createElement('tr');

        const nazevCell = document.createElement('td');
        nazevCell.textContent = surovina.Nazev;
        row.appendChild(nazevCell);

        const mnozstviCell = document.createElement('td');
        mnozstviCell.textContent = surovina.Mnozstvi;
        row.appendChild(mnozstviCell);

        tbody.appendChild(row);
    });

    table.appendChild(tbody);
    seznamDiv.appendChild(table);
}