// Seznam pro ukládání surovin
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

function removeFromSeznam(index) {
    seznamSurovin.splice(index, 1);

    // Aktualizace skrytého pole s JSON seznamem surovin
    const jsonSeznamSurovin = JSON.stringify(seznamSurovin);
    document.getElementById('jsonSeznamSurovin').value = jsonSeznamSurovin;
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

    const headerOdebrat = document.createElement('th');
    headerOdebrat.textContent = 'Odebrat';
    headerRow.appendChild(headerOdebrat);

    thead.appendChild(headerRow);
    table.appendChild(thead);

    const tbody = document.createElement('tbody');


    //seznamSurovin má idčka pro své jednotlivé prvky
    let idSuroviny = 0;

    seznamSurovin.forEach(surovina => {
        //console.log('Jednotlivá surovina' + surovina);
        const row = document.createElement('tr');

        const nazevCell = document.createElement('td');
        nazevCell.textContent = surovina.Nazev;
        row.appendChild(nazevCell);

        const mnozstviCell = document.createElement('td');
        mnozstviCell.textContent = surovina.Mnozstvi;
        row.appendChild(mnozstviCell);

        const actionCell = document.createElement('td');
        const removeButton = document.createElement('button');
        //removeButton.textContent = 'Odebrat';
        removeButton.innerHTML = '&#10006;';
        removeButton.style.backgroundColor = 'transparent'; // Odstranění pozadí
        removeButton.style.border = 'none'; // Odstranění ohraničení
        removeButton.style.cursor = 'pointer'; // Změna kurzoru na ukazatel
        removeButton.type = 'button';
        removeButton.id = 'idButtonSuroviny' + idSuroviny;
        removeButton.onclick = () => {
            let temporary = removeButton.id;
            let temporaryid = parseInt(temporary.replace('idButtonSuroviny', '')); // odstranění textu 'idButtonSuroviny' a získání čísla
            removeFromSeznam(temporaryid);
            zobrazitSeznamSurovin();
        };

        row.appendChild(actionCell);
        actionCell.appendChild(removeButton);

        tbody.appendChild(row);
    });
    //console.log(seznamSurovin);
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
////
////



function zobrazeniParametru() {

    jsonSeznamSurovin = document.getElementById('jsonSeznamSurovin');

    jsonSeznamSurovinValue = jsonSeznamSurovin.value;

    //console.log('SeznamSurovin' + jsonSeznamSurovinValue);

    //SEZNAM SUROVIN
    var seznamSurovinTemp = JSON.parse(jsonSeznamSurovinValue);

    seznamSurovinTemp.forEach(function (surovina) {
        //console.log("Název: " + surovina.Nazev + ", Množství: " + surovina.Mnozstvi);

        seznamSurovin.push(surovina);
    });
    zobrazitSeznamSurovin();



    //POSTUP PRIPRAVY
    jsonPostupPripravy = document.getElementById('jsonKroky');
    jsonPostupPripravyValue = jsonPostupPripravy.value;

    //console.log('PostupPripravy: ' + jsonPostupPripravyValue);

    var postupPripravyTemp = JSON.parse(jsonPostupPripravyValue);
    /*
    postupPripravyTemp.forEach(function (krok) {
        console.log("Krok: " + krok);
    });
    */

    temporaryPocetPoli = postupPripravyTemp.length;

    for (let x = 1; x < temporaryPocetPoli; x++) {
        pridatKrok();
    }

    //Zpočítání všech textových polí postupu pripravy v dokumentu
    //const jsonKrokyInputPole = document.getElementById('jsonKroky');
    const elementsWithSameID = document.querySelectorAll('.textAreaPostupPripravy');
    const count = elementsWithSameID.length;
    //console.log('Hodnota count: ' + count);
    //let prvniKrokProKontrolu;

    for (let i = 0; i < count; i++) {
        const element = elementsWithSameID[i];
        //console.log(`Prvek číslo ${i + 1}:`, element);
        //console.log('Hodnota prvku je: ' + element.value);
        element.value = postupPripravyTemp[i];
        //console.log('Hodnota count je: ' + count);
        //console.log('Hodnota i je: ' + i);
        //console.log('Element value je: ' + element.value);

    }

    //IMAGE

    hodnotaImageSrc = document.getElementById('hodnotaImageSrc');
    hodnotaImageSrcValue = hodnotaImageSrc.value;

    // Vytvoření nového obrázku
    var img = document.createElement('img');
    img.src = hodnotaImageSrcValue; // Nastavení získané hodnoty jako zdroj obrázku
    img.style.maxWidth = '100px'; // Nastavení maximální šířky pro náhled
    img.style.maxHeight = '100px'; // Nastavení maximální výšky pro náhled

    var divProVlozeniObrazku = document.getElementById('divProVlozeniObrazku');

    divProVlozeniObrazku.appendChild(img);

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
////
////

let kroky = []; // Objekt pro ukládání kroků
                // Už to není objekt, ale udělal jsem z toho pole a jdu to předělat

document.addEventListener('DOMContentLoaded', function () {
    //console.log('DOMContentLoaded se spustil');
    const rozhodujiciDiv = document.getElementById('idRozlisujiciCreateAEditFormulare');
    const rozhodujiciDivValue = rozhodujiciDiv.dataset.mode;

    pridatPrvniKrok();

    if (rozhodujiciDivValue === 'edit') {
        zobrazeniParametru();
    }

});

function odstranitKrok(krokKey) {
    kroky.splice(krokKey, 1); // Odstranění kroku z objektu kroky a divu uvnitř "steps"
    const divProOdebratButtonToRemove = document.getElementById('divProOdebratButton' + krokKey);
    divProOdebratButtonToRemove.parentNode.removeChild(divProOdebratButtonToRemove);
}

function pridatPrvniKrok() {
    const krokKey = '0'; // Klíč pro první krok

    //console.log('PridatPrvniKrok se spustilo.');

    //vytvoření divu obsahující button
    const divProOdebratButton = document.createElement('div');
    divProOdebratButton.style.position = 'relative';
    divProOdebratButton.setAttribute('id', 'divProOdebratButton' + krokKey); //Zde bude krokKey 0

    //odebírací button
    const odebiraciButton = document.createElement('button');
    odebiraciButton.type = 'button';
    odebiraciButton.innerHTML = '&#10006;'; // Unicode pro křížek (X)
    odebiraciButton.style.position = 'absolute';
    odebiraciButton.style.top = '0';
    odebiraciButton.style.right = '0';
    odebiraciButton.style.marginTop = '3px'; // Posunutí nahoru
    odebiraciButton.style.marginRight = '-2px'; // Posunutí doprava
    odebiraciButton.style.backgroundColor = 'transparent'; // Průhledné pozadí
    odebiraciButton.style.border = 'none'; // Bez okraje
    //odebiraciButton.setAttribute('id', 'odebiraciButton' + krokKey); //možná ani nemusí mít id
    odebiraciButton.onclick = function () {
        odstranitKrok(krokKey); // Funkce pro odstranění kroku
    };

    // Vytvoření první textarea
    const firstTextArea = document.createElement('textarea');
    firstTextArea.classList.add('form-control');
    firstTextArea.style.height = '80px'; // Nastavení výšky textového pole
    firstTextArea.style.marginBottom = '10px'; // Přidání mezery pod textovým polem
    //firstTextArea.setAttribute('placeholder', placeholderCislo + '.krok');
    //firstTextArea.setAttribute('id', 'textAreaPostupPripravy'); // Přidání id odpovídajícímu klíči kroku
    firstTextArea.classList.add('textAreaPostupPripravy');


    divProOdebratButton.appendChild(odebiraciButton);
    divProOdebratButton.appendChild(firstTextArea);
    document.getElementById('steps').appendChild(divProOdebratButton);

    // Uložení prvního kroku do objektu kroky
    kroky[krokKey] = ''; // Prázdný text pro první krok
}


function pridatKrok() {
    const krokCount = kroky.length; // Počítadlo kroků
    const krokKey = `${krokCount}`; // Vytvoření klíče pro nový krok
    //console.log('Kolik je kroků: ' + krokCount);
    //console.log('Začátek pridatKrok proměnná kroky: ' + kroky);

    //vytvoření divu obsahující button
    const divProOdebratButton = document.createElement('div');
    divProOdebratButton.style.position = 'relative';
    divProOdebratButton.setAttribute('id', 'divProOdebratButton' + krokKey);

    //odebírací button
    const odebiraciButton = document.createElement('button');
    odebiraciButton.type = 'button';
    odebiraciButton.innerHTML = '&#10006;'; // Unicode pro křížek (X)
    odebiraciButton.style.position = 'absolute';
    odebiraciButton.style.top = '0';
    odebiraciButton.style.right = '0';
    odebiraciButton.style.marginTop = '3px'; // Posunutí nahoru
    odebiraciButton.style.marginRight = '-2px'; // Posunutí doprava
    odebiraciButton.style.backgroundColor = 'transparent'; // Průhledné pozadí
    odebiraciButton.style.border = 'none'; // Bez okraje
    //odebiraciButton.setAttribute('id', 'odebiraciButton' + krokKey);
    odebiraciButton.onclick = function () {
        odstranitKrok(krokKey); // Funkce pro odstranění kroku
    };

    // Vytvoření nové textarea
    const newTextArea = document.createElement('textarea');
    newTextArea.classList.add('form-control');
    newTextArea.style.height = '80px'; // Nastavení výšky textového pole
    newTextArea.style.marginBottom = '10px'; // Přidání mezery pod textovým polem
    const placeholderCislo = (parseInt(krokKey) + 1).toString();
    //newTextArea.setAttribute('placeholder', placeholderCislo + '.krok');
    //newTextArea.setAttribute('id', 'textAreaPostupPripravy'); // Přidání id odpovídajícímu klíči kroku
    newTextArea.classList.add('textAreaPostupPripravy');


    divProOdebratButton.appendChild(odebiraciButton);
    divProOdebratButton.appendChild(newTextArea);
    document.getElementById('steps').appendChild(divProOdebratButton);

    // Uložení kroku do objektu kroky
    //kroky[krokKey] = ''; // Prázdný text pro nový krok
    //console.log('Kolik je kroků: ' + krokCount);
    //console.log('Konec pridatKrok proměnná kroky = ' + kroky);
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

function ulozeniKroku() {

    /*let highestId = 0;
    let currentDiv;
    let pocetTextovychPoli = 0;

    while (currentDiv = document.getElementById(`${highestId}`) != null) {
        //zde je to potřeba dynamicky na prohledání celého dokumentu, ne takhle popořadě.
        // Zde zjistím kolik divů existuje
        pocetTextovychPoli++;
        highestId++; // Inkrementuj ID pro hledání dalšího divu
    }


    for (let i = 0; i < highestId; i++) {  //lze do kroky přidám klíč a value
        const textAreaId = `${i}`;
        const textAreaElement = document.getElementById(textAreaId);

        kroky[textAreaId] = textAreaElement.value;
    }*/
    const jsonKrokyInputPole = document.getElementById('jsonKroky');
    const elementsWithSameID = document.querySelectorAll('[id="textAreaPostupPripravy"]');
    const count = elementsWithSameID.length;
    let prvniKrokProKontrolu;

    for (let i = 0; i < count; i++) {
        const element = elementsWithSameID[i];
        //console.log(`Prvek číslo ${i + 1}:`, element);
        //console.log('Hodnota prvku je: ' + element.value);

        if (element.value !== '') {
            kroky[i] = element.value;
        }

        if (i == 0) {
            prvniKrokProKontrolu = element.value;
        }
    }

    //console.log('Proměnná kroky: ' + kroky);
    //console.log(kroky);
    //console.log('Hodnota prvniho kroku je: ' + prvniKrokProKontrolu);

    let jsonKroky;
    // Serializace kroků do JSON
    if (prvniKrokProKontrolu !== '') {
        jsonKroky = JSON.stringify(kroky);  //stringifine proměnou kroky
        //console.log('Vyjebanej typ jsonKroky: ' + typeof(jsonKroky));
    }

    else {
        jsonKroky = null;
    }
    //console.log('k nicemu ' + jsonKroky);
    //const jsonKrok1 = document.getElementById('0'); //vemu si první krok element
    //const postupPripravyValue = document.getElementById('jsonKroky');

    if (jsonKroky !== null && prvniKrokProKontrolu !== '') {  //zkontroluju zda je actually něco zadanýho v kroku
        //pokud ne, tak se hodnota do value nepropíše
        //console.log('Ukládání hodnoty proběhlo.');
        jsonKrokyInputPole.value = jsonKroky;
        //console.log('jsonKrokyInputPoleValue: ' + jsonKrokyInputPole.value);
        //console.log(jsonKrok1.value);
    }

    console.log('ulozeniKroku skončil');

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

    let temp = ulozeniKroku();

    const inputs = ['ControlErrorMessage1', 'ControlErrorMessage2', 'jsonKroky', 'fileupload'];  // poslední fileupload a je zde
    //protože mi colidujou id v souboru create.cshtml
    const errorMessages = ['ErrorMessage1', 'ErrorMessage2', 'ErrorMessage3', 'ErrorMessage4'];
    let isValid = true;

    for (let i = 0; i < inputs.length; i++) {

        let errorMessage = document.getElementById(errorMessages[i]);


        if (document.getElementById(inputs[i]).value === '') {
            console.log('Hodnota při kontrole zobrazování erroru: ' + inputs[i].value);
            isValid = false;
            errorMessage.style.display = 'inline-block'; // Zobrazit chybu
        }
        else {
            console.log('Hodnota při kontrole zobrazování erroru prošla: ' + inputs[i].value);
            errorMessage.style.display = 'none'; // Skrýt chybu
        }
    }

    if (isValid == false) {
        event.preventDefault(); // Prevent the form from submitting
    }
});




/*
document.getElementById('CreateFormular').addEventListener('submit', function (event) {

    let isValid = ulozeniKroku();

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