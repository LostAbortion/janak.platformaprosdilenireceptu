﻿// Seznam pro ukládání surovin
let seznamSurovin = [];

function pridatSurovinu() {
    // Načtení hodnot z textových polí
    const nazev = document.getElementById('nazev').value;
    const mnozstvi = document.getElementById('mnozstvi').value;

    if (nazev === '') {
        //zobrazování error message pro uživatele
        document.getElementById('errorSurovina').style.display = 'block';
    }

    else {
        //schování error message pro uživatele
        document.getElementById('errorSurovina').style.display = 'none';

        // Vytvoření objektu pro surovinu
        const novaSurovina = {
            Nazev: nazev,
            Mnozstvi: mnozstvi
        };

        // Přidání suroviny do seznamu
        seznamSurovin.push(novaSurovina);

        // Vymazání obsahu textových polí
        document.getElementById('nazev').value = '';
        document.getElementById('mnozstvi').value = '';

        // Aktualizace skrytého pole s JSON seznamem surovin
        const jsonSeznamSurovin = JSON.stringify(seznamSurovin);
        document.getElementById('jsonSeznamSurovin').value = jsonSeznamSurovin;

        // Zobrazení seznamu surovin v divu pod tlačítkem
        zobrazitSeznamSurovin();
    }
}

function zobrazitSeznamSurovin() {
    const seznamDiv = document.getElementById('seznamSurovin');
    seznamDiv.innerHTML = '';

    const table = document.createElement('table');
    table.classList.add('table'); // Přidáváme třídu pro Bootstrap

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

let kroky = {}; // Objekt pro ukládání kroků

document.addEventListener('DOMContentLoaded', function () {
    pridatPrvniKrok();
});

function pridatPrvniKrok() {
    const krokKey = '1'; // Klíč pro první krok

    // Vytvoření první textarea
    const firstTextArea = document.createElement('textarea');
    firstTextArea.classList.add('form-control');
    firstTextArea.style.height = '80px'; // Nastavení výšky textového pole
    firstTextArea.style.marginBottom = '10px'; // Přidání mezery pod textovým polem
    firstTextArea.setAttribute('placeholder', krokKey + '.krok');
    firstTextArea.setAttribute('id', krokKey); // Přidání id odpovídajícímu klíči kroku

    // Přidání první textarea do DOM
    document.getElementById('steps').appendChild(firstTextArea);

    // Uložení prvního kroku do objektu kroky
    kroky[krokKey] = ''; // Prázdný text pro první krok
}

function pridatKrok() {
    const krokCount = Object.keys(kroky).length + 1; // Počítadlo kroků
    const krokKey = `${krokCount}`; // Vytvoření klíče pro nový krok

    // Vytvoření nové textarea
    const newTextArea = document.createElement('textarea');
    newTextArea.classList.add('form-control');
    newTextArea.style.height = '80px'; // Nastavení výšky textového pole
    newTextArea.style.marginBottom = '10px'; // Přidání mezery pod textovým polem
    newTextArea.setAttribute('placeholder', krokKey + '.krok');
    newTextArea.setAttribute('id', krokKey); // Přidání id odpovídajícímu klíči kroku

    // Přidání nové textarea do DOM
    document.getElementById('steps').appendChild(newTextArea);

    // Uložení kroku do objektu kroky
    kroky[krokKey] = ''; // Prázdný text pro nový krok
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
        // Zde zjistím kolik divů existuje

        highestId++; // Inkrementuj ID pro hledání dalšího divu
    }


    for (let i = 1; i < highestId; i++) {  //lze do kroky přidám klíč a value
        const textAreaId = `${i}`;
        const textAreaElement = document.getElementById(textAreaId);
        // getElementById(textAreaId);

        kroky[textAreaId] = textAreaElement.value;
    }


    // Serializace kroků do JSON
    const jsonKroky = JSON.stringify(kroky);  //stringifine proměnou kroky
    console.log('k nicemu ' + jsonKroky);
    const jsonKrok1 = document.getElementById('1'); //vemu si první krok element
    const postupPripravyValue = document.getElementById('jsonKroky');

    if (jsonKroky !== null && jsonKrok1.value !== '') {  //zkontroluju zda je actually něco zadanýho v kroku
                            //pokud ne, tak se hodnota do value nepropíše
        postupPripravyValue.value = jsonKroky;
        console.log(jsonKrok1);
        console.log(jsonKrok1.value);
    }
    /*
    if (jsonKroky !== null) {
        document.getElementById('jsonKroky').value = jsonKroky;
    }*/

    console.log('submitForm skončil');

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

    const inputs = ['ControlErrorMessage1', 'ControlErrorMessage2', 'jsonKroky', 'fileupload'];  // poslední fileupload a je zde
    //protože mi colidujou id v souboru create.cshtml
    const errorMessages = ['ErrorMessage1', 'ErrorMessage2', 'ErrorMessage3', 'ErrorMessage4'];
    let isValid = true;

    for (let i = 0; i < inputs.length; i++) {

        let errorMessage = document.getElementById(errorMessages[i]);

        if (document.getElementById(inputs[i]).value === '') {
            isValid = false;
            errorMessage.style.display = 'inline-block'; // Zobrazit chybu
        }
        else {
            errorMessage.style.display = 'none'; // Skrýt chybu
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
            errorMessage.style.display = 'none'; // Skrýt chybu
        }
    }

    if (isValid == false) {
        event.preventDefault(); // Prevent the form from submitting
    }
});
*/