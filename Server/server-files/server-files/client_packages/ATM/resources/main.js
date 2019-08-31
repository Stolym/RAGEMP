atm({
    cards: [
        {
            name: "Visa 1",
            model: "visa",
            cardId: "1234 5678 9012 3456",
            backIdCard: "123",
            password: "0000",
            sum: 54321.98,
            exp: "04/20",
			blocked: false,
            eatenByATM: false,
            paymentHistory: [
				{name:"Achat 1", desc:"Courte description", amount:-12}, 
				{name:"Achat 2", desc:"Courte description", amount:-34},
				{name:"Vente 1", desc:"Courte description", amount:56},
				{name:"Achat 3", desc:"Courte description", amount:-78},
				{name:"Vente récente", desc:"Courte description", amount:90} 
			]
        },
        {
            name: "Mastercard 1",
            model: "mastercard",
            cardId: "1234 5678 9012 3456",
            backIdCard: "123",
            password: "0000",
            sum: 54321.98,
            exp: "04/20",
            blocked: false,
            eatenByATM: false,
			paymentHistory: [
				{name:"Achat 1", desc:"Courte description", amount:-12},
				{name:"Achat 2", desc:"Courte description", amount:-34},
				{name:"Vente 1", desc:"Courte description", amount:56},
				{name:"Achat 3", desc:"Courte description", amount:-78},
				{name:"Vente 2", desc:"Courte description", amount:90}
			]
        },
        {
            name: "carte bloquee",
            model: "mastercard",
            cardId: "6666 6666 6666 6666",
            backIdCard: "123",
            password: "0000",
            sum: 54321.98,
            exp: "04/20",
            blocked: true,      // si qqn a déjà essayé 3 codes faux ailleurs que dans un atm
            eatenByATM: false,  // l'atm avale la carte
			paymentHistory: [
				{name:"Achat 1", desc:"Courte description", amount:-12},
				{name:"Achat 2", desc:"Courte description", amount:-34},
				{name:"Vente 1", desc:"Courte description", amount:56},
				{name:"Achat 3", desc:"Courte description", amount:-78},
				{name:"Vente 2", desc:"Courte description", amount:90}
			]
        }
    ]
});






/* Global vars */
var receivedCards, sentCardID, currentSum;



// Transmission de données au menu
function send(flag, payload) {
	document.getElementById("atmScreenIframe").contentWindow.postMessage({
		flag: flag,
		payload: payload
	},'*');
}


// Initialisation
function atm(data) {
    horloge();
	atm_init(data);
}


// Horloge à modifier avec le temps du RP
function horloge() {
    var time = new Date();
    document.getElementById('atmDateTime').innerHTML = time.toLocaleDateString() + "<br/>" + time.toLocaleTimeString();
    setTimeout(horloge, 500);
}
	

// Initialisation de l'ATM
function atm_init(data) {
    receivedCards = data.cards;

    // Affiche les cartes disponibles
    var cardParent = document.getElementById("cardsScrollbox");

    for(var i=0; i<data.cards.length; i++){
        var card = data.cards[i];

        if(!card.eatenByATM){
            var cardElem = document.createElement("div");
            cardElem.setAttribute("id", i);
            cardElem.classList.add("creditCard");
            cardElem.innerHTML += `<div class="cardName">${card.name}</div>
                <img class="cardIcon" src="assets/${card.model}logo.png"></img>
                <div class="cardId">${card.cardId}</div>
                <div class="cardInfo">Exp ${card.exp}</div>`;
    
            cardParent.appendChild(cardElem);
    
            // carte sélectionnée
            cardElem.addEventListener("click", function(e){
                e.stopPropagation();
                if(document.getElementsByClassName("selectedCard").length === 0){

                    e.currentTarget.classList.add("selectedCard");
                    send("card", receivedCards[e.currentTarget.id]);  // envoie la carte à l'atm
                    sentCardID = e.currentTarget.id;
                }
            });
        }
    };


    // enregistrement du clavier
    for(var i=0; i<13; i++){
        var keyNames = ["key0", "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9", "keyX", "keyC", "keyV"]
        var btn = document.getElementById(keyNames[i]);
        btn.addEventListener("click", function(e){
            e.stopPropagation();

            send("key", e.currentTarget.id.substring(3));  // transmission de la touche à l'atm
            
            var audio = new Audio('http://www.soundjay.com/button/beep-07.wav');
            audio.play();
        });

        // pavé numérique
        if(i<10){
            btn.firstElementChild.style = "fill:#303030ff;stroke:none;";
            btn.lastElementChild.style = "fill:#fcfcfcff;stroke:none;";
            
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#414141ff;stroke:none;cursor:pointer;";
                e.currentTarget.lastElementChild.style = "fill:#fcfcfcff;stroke:none;cursor:pointer;";
            }, true);
            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#303030ff;stroke:none;cursor:default;";
                e.currentTarget.lastElementChild.style = "fill:#fcfcfcff;stroke:none;cursor:default;";
            }, true);
        }
        // bouton X
        else if(i==10){
            btn.firstElementChild.style = "fill:#303030ff;stroke:none;";
            btn.lastElementChild.style = "fill:#aa0606ff;stroke:none;";
            
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#aa0606ff;stroke:none;cursor:pointer;";
                e.currentTarget.lastElementChild.style = "fill:#303030ff;stroke:none;cursor:pointer;";
            }, true);
    
            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#303030ff;stroke:none;cursor:default;";
                e.currentTarget.lastElementChild.style = "fill:#aa0606ff;stroke:none;cursor:default;";
            }, true);
        }
        // bouton C
        else if(i==11){
            btn.firstElementChild.style = "fill:#303030ff;stroke:none;";
            btn.lastElementChild.style = "fill:#f6ad1cff;stroke:none;";
            
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#f6ad1cff;stroke:none;cursor:pointer;";
                e.currentTarget.lastElementChild.style = "fill:#303030ff;stroke:none;cursor:pointer;";
            }, true);
    
            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#303030ff;stroke:none;cursor:default;";
                e.currentTarget.lastElementChild.style = "fill:#f6ad1cff;stroke:none;cursor:default;";
            }, true);
        }
        // bouton V
        else if(i==12){
            btn.firstElementChild.style = "fill:#303030ff;stroke:none;";
            btn.lastElementChild.style = "fill:#157527ff;stroke:none;";
            
            btn.addEventListener("mouseenter", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#157527ff;stroke:none;cursor:pointer;";
                e.currentTarget.lastElementChild.style = "fill:#303030ff;stroke:none;cursor:pointer;";
            }, true);

            btn.addEventListener("mouseleave", function(e){
                e.stopPropagation();
                e.currentTarget.firstElementChild.style = "fill:#303030ff;stroke:none;cursor:default;";
                e.currentTarget.lastElementChild.style = "fill:#157527ff;stroke:none;cursor:default;";
            }, true);
        }
    }

    // quitter l'atm
    var leavebtn = document.getElementById("closeButton");
    leavebtn.addEventListener("click", function(e){
        console.log("Kill me pls");
    }, true);
    leavebtn.addEventListener("mouseleave", function(e){e.currentTarget.style = "fill:#ffffff;cursor:pointer;";}, true);
    leavebtn.addEventListener("mouseenter", function(e){e.currentTarget.style = "fill:#9344B4;cursor:pointer;";}, true);
}





// Ajout d'une entrée dans l'historique
function addHistoryEntry(payment) {
    var historyParent = document.getElementById("historyTable");
    historyParent.innerHTML = `<tr class="transaction">
        <td class="transactionDetail">
            <div class="transactionName">${payment.name}</div>
            <div class="transactionDesc">${payment.desc}</div>
        </td>
        <td class="transactionValue ${payment.amount>0?"posval":"negval"}">${payment.amount>0?"+":"-"} $${Math.abs(payment.amount)}</td>
    </tr>` + historyParent.innerHTML;
}




// Affichage des données d'une carte bancaire
function display_card(card){
    // Argent total
    document.getElementById("totalCountValue").innerHTML = `$ ${card.sum.toLocaleString()}`;
    currentSum = card.sum;

    // historique des paiements
    card.paymentHistory.forEach(payment => {
        addHistoryEntry(payment);
    });
	
    var leavebtn = document.getElementById("closeButton");
    
    leavebtn.addEventListener("click", function(e){
        // renvoyer receivedCards au back
        
        // Si on quitte avant que la carte n'ait été retirée de l'atm, aucune modification n'est effectuée
        // (la mise à jour a lieu lorsque la carte est rendue par l'atm)
        console.log("Kill me pls");
    }, true);
    
    leavebtn.addEventListener("mouseleave", function(e){e.currentTarget.style = "fill:#ffffff;cursor:pointer;";}, true);
    leavebtn.addEventListener("mouseenter", function(e){e.currentTarget.style = "fill:#9344B4;cursor:pointer;";}, true);
}


// réception de données du menu
window.addEventListener("message", function(e) {

    // Réception de la carte déverrouillée
    if(e.data.flag === "cardUnlock"){
        display_card(e.data.payload);
    }

    // réception de la carte mise à jour
    if(e.data.flag === "cardEject"){
        receivedCards[sentCardID] = e.data.payload;  // màj de la carte après modifications
        document.getElementById("totalCountValue").innerHTML = "";
        document.getElementById("historyTable").innerHTML = "";
        document.getElementsByClassName("selectedCard")[0].classList.remove("selectedCard");
    }

    // Prise en compte d'une transaction effectuée avec l'atm
    else if(e.data.flag === "transaction") {
        var transaction = e.data.payload;
        // Ajout d'une entrée dans l'historique affiché
        document.getElementById("historyTable").innerHTML = `<tr class="transaction">
            <td class="transactionDetail">
                <div class="transactionName">${transaction.name}</div>
                <div class="transactionDesc">${transaction.desc}</div>
            </td>
            <td class="transactionValue ${transaction.amount>0?"posval":"negval"}">${transaction.amount>0?"+":"-"} $${Math.abs(transaction.amount)}</td>
        </tr>` + document.getElementById("historyTable").innerHTML;

        // Modification du solde total
        currentSum = currentSum + transaction.amount;
        document.getElementById("totalCountValue").innerHTML = `$ ${currentSum.toLocaleString()}`;
    }
    
    // la carte est avalée par l'atm (codes faux)
    else if(e.data.flag === "cardDestruct") {
        receivedCards[sentCardID] = e.data.payload;  // màj de la carte au cas où des modifications ont eu lieu
        receivedCards[sentCardID].eatenByATM = true;
        var currentCard = document.getElementsByClassName("selectedCard")[0];
        currentCard.classList.remove("selectedCard");
        currentCard.classList.add("blockedCard");
    }
});