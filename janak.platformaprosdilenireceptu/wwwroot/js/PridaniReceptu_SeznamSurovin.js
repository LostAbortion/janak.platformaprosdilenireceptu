// Seznam pro ukl�d�n� surovin
let seznamSurovin = [];

function pridatSurovinu() {
    // Na�ten� hodnot z textov�ch pol�
    const nazev = document.getElementById('nazev').value;
    const mnozstvi = document.getElementById('mnozstvi').value;

    // Vytvo�en� objektu pro surovinu
    const novaSurovina = {
        Nazev: nazev,
        Mnozstvi: mnozstvi
    };

    // P�id�n� suroviny do seznamu
    seznamSurovin.push(novaSurovina);

    // Vymaz�n� obsahu textov�ch pol�
    document.getElementById('nazev').value = '';
    document.getElementById('mnozstvi').value = '';

    // Aktualizace skryt�ho pole s JSON seznamem surovin
    const jsonSeznamSurovin = JSON.stringify(seznamSurovin);
    document.getElementById('jsonSeznamSurovin').value = jsonSeznamSurovin;

    // Zobrazen� seznamu surovin v divu pod tla��tkem
    zobrazitSeznamSurovin();
}

function zobrazitSeznamSurovin() {
    const seznamDiv = document.getElementById('seznamSurovin');
    seznamDiv.innerHTML = '';

    const table = document.createElement('table');
    table.classList.add('table'); // P�id�v�me t��du pro Bootstrap

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');

    const headerNazev = document.createElement('th');
    headerNazev.textContent = 'N�zev suroviny';
    headerRow.appendChild(headerNazev);

    const headerMnozstvi = document.createElement('th');
    headerMnozstvi.textContent = 'Mno�stv�';
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