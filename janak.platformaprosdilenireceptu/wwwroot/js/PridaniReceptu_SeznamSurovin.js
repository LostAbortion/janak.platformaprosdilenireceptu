// Seznam pro ukl�d�n� surovin
let seznamSurovin = [];

function pridatSurovinu() {
    // Na�ten� hodnot z textov�ch pol�
    const nazev = document.getElementById('nazev').value;
    const mnozstvi = document.getElementById('mnozstvi').value;

    if (nazev === '') {
        //zobrazov�n� error message pro u�ivatele
        document.getElementById('errorSurovina').style.display = 'block';
    }

    else {
        //schov�n� error message pro u�ivatele
        document.getElementById('errorSurovina').style.display = 'none';

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
}

function zobrazitSeznamSurovin() {
    const seznamDiv = document.getElementById('seznamSurovin');
    seznamDiv.innerHTML = '';

    const table = document.createElement('table');
    table.classList.add('table'); // P�id�v�me t��du pro Bootstrap

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');

    const headerNazev = document.createElement('th');
    headerNazev.textContent = 'Nazev suroviny';
    headerRow.appendChild(headerNazev);

    const headerMnozstvi = document.createElement('th');
    headerMnozstvi.textContent = 'Mnozstvi';
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


////
////
////
////
////
////
////
////
////
////

let kroky = {}; // Objekt pro ukl�d�n� krok�

document.addEventListener('DOMContentLoaded', function() {
    pridatPrvniKrok();
});

function pridatPrvniKrok() {
    const krokKey = '1'; // Kl�� pro prvn� krok

    // Vytvo�en� prvn� textarea
    const firstTextArea = document.createElement('textarea');
    firstTextArea.classList.add('form-control');
    firstTextArea.style.height = '80px'; // Nastaven� v��ky textov�ho pole
    firstTextArea.style.marginBottom = '10px'; // P�id�n� mezery pod textov�m polem
    firstTextArea.setAttribute('placeholder', krokKey + '.krok');
    firstTextArea.setAttribute('id', krokKey); // P�id�n� id odpov�daj�c�mu kl��i kroku

    // P�id�n� prvn� textarea do DOM
    document.getElementById('steps').appendChild(firstTextArea);

    // Ulo�en� prvn�ho kroku do objektu kroky
    kroky[krokKey] = ''; // Pr�zdn� text pro prvn� krok
}

function pridatKrok() {
    const krokCount = Object.keys(kroky).length + 1; // Po��tadlo krok�
    const krokKey = `${krokCount}`; // Vytvo�en� kl��e pro nov� krok

    // Vytvo�en� nov� textarea
    const newTextArea = document.createElement('textarea');
    newTextArea.classList.add('form-control');
    newTextArea.style.height = '80px'; // Nastaven� v��ky textov�ho pole
    newTextArea.style.marginBottom = '10px'; // P�id�n� mezery pod textov�m polem
    newTextArea.setAttribute('placeholder', krokKey + '.krok');
    newTextArea.setAttribute('id', krokKey); // P�id�n� id odpov�daj�c�mu kl��i kroku

    // P�id�n� nov� textarea do DOM
    document.getElementById('steps').appendChild(newTextArea);

    // Ulo�en� kroku do objektu kroky
    kroky[krokKey] = ''; // Pr�zdn� text pro nov� krok
}


////
////
////
////
////
////
////
////
////
////

function submitForm() {
    console.log('submitForm se zavolal');

    let highestId = 1;
    let currentDiv;

    while (currentDiv = document.getElementById(`${highestId}`)) {
        // Zde zjist�m kolik div� existuje

        highestId++; // Inkrementuj ID pro hled�n� dal��ho divu
    }

    
    for (let i = 1; i < highestId; i++) {  //lze do kroky p�id�m kl�� a value
        const textAreaId = `${i}`;
        const textAreaElement = document.getElementById(textAreaId);
        // getElementById(textAreaId);

        kroky[textAreaId] = textAreaElement.value;
    }


    // Serializace krok� do JSON
    const jsonKroky = JSON.stringify(kroky);
    console.log('k nicemu ' + jsonKroky);
    const jsonKrokyElement = document.getElementById('jsonKroky');

    if (jsonKroky !== null && jsonKrokyElement) {
        jsonKrokyElement.value = jsonKroky;
        console.log(jsonKrokyElement);
        console.log(jsonKrokyElement.value);
    }
    /*
    if (jsonKroky !== null) {
        document.getElementById('jsonKroky').value = jsonKroky;
    }*/

    console.log('submitForm skon�il');

    return true;
}


////
////
////
////
////
////
////
////
////
////


document.getElementById('CreateFormular').addEventListener('submit', function (event) {

    let temp = submitForm();

    const inputs = ['ControlErrorMessage1', 'ControlErrorMessage2', 'jsonKroky', 'fileupload'];  // posledn� fileupload a je zde
    //proto�e mi colidujou id v souboru create.cshtml
    const errorMessages = ['ErrorMessage1', 'ErrorMessage2', 'ErrorMessage3', 'ErrorMessage4'];
    let isValid = true;

    for (let i = 0; i < inputs.length; i++) {

        if (document.getElementById(inputs[i]).value === null) {
            isValid = false;
        }
        else {
            let inputValue = document.getElementById(inputs[i]).value;
        }
        let errorMessage = document.getElementById(errorMessages[i]);

        if (inputValue === '') {
            errorMessage.style.display = 'inline-block'; // Zobrazit chybu
            isValid = false;
        }
        else {
            errorMessage.style.display = 'none'; // Skr�t chybu
        }
    }

    if (isValid == false) {
        event.preventDefault(); // Prevent the form from submitting
    }
});

/*
document.getElementById('CreateFormular').addEventListener('submit', function (event) {

    let isValid = submitForm();

    const inputs = ['ControlErrorMessage1', 'ControlErrorMessage2', 'ControlErrorMessage3', 'ControlErrorMessage4'];
    const errorMessages = ['ErrorMessage1', 'ErrorMessage2', 'ErrorMessage3', 'ErrorMessage4'];
    //let isValid = true;

    for (let i = 0; i < inputs.length; i++) {
        let inputValue = document.getElementById(inputs[i]).value;
        let errorMessage = document.getElementById(errorMessages[i]);

        if (inputValue === '') {
            errorMessage.style.display = 'inline-block'; // Zobrazit chybu
            isValid = false;
        }
        else {
            errorMessage.style.display = 'none'; // Skr�t chybu
        }
    }

    if (isValid == false) {
        event.preventDefault(); // Prevent the form from submitting
    }
});
*/