/* Global vars */

var screen = 0;
var receivedStr = "";
var receivedCard = {};
var remainingTries = 3;

var screenAssoc = {
	// 0 : Accueil
	// 1 : Déverrouillage
	// 2 : code faux
	// 3 : code bon
	// 4 : carte bloquée
	// 5 : carte mangée
	// 6 : menu principal
	// 7 : éjecter carte
	// 8 : retirer argent (saisie)
	// 9 : retirer argent (validation)
	
	0: {
		html: function(){return `<div>Bienvenue !<br/>Veuillez insérer une carte de crédit</div>`;},
		init: function(){},
		onMessage: function(e){}
	},


	1: {
		html: function(){return `<h1>Carte sélectionnée : ${receivedCard.name}<br/>(${receivedCard.cardId})</h1><div>Entrez le code de déverrouillage</div><h1 id="code"></h1><div onclick="displayScreen(7);" class="option flat">Quitter l'ATM</div>`;},
		init: function(){
			receivedStr = "";
			unlockCard(receivedCard, receivedStr);
		},
		onMessage: function(e){unlockCard(receivedCard, receivedStr)}
	},


	2: {
		html: function(){return `<h1>Code faux<br/>Essais restants : ${remainingTries}</h1>`;},
		init: function(){ setTimeout(function(){displayScreen(1);}, 3000); },
		onMessage: function(e){}
	},


	3: {
		html: function(){return `<h1>Code bon !</h1>`;},
		init: function(){ 
			setTimeout(function(){send("cardUnlock", receivedCard);}, 1000);
			setTimeout(function(){displayScreen(6);}, 3000);
		},
		onMessage: function(e){}
	},


	4: {
		html: function(){return `<div>La carte insérée est bloquée.<br/>Ejection de la carte en cours...</div>`;},
		init: function(){
			setTimeout(ejectCard, 3000);
		},
		onMessage: function(e){}
	},


	5: {
		html: function(){return `<div>Le nombre maximal d'erreurs possibles a été atteint.<br/>Destruction de la carte en cours...</div>`;},
		init: function(){
			setTimeout(eatCard, 5000);
		},
		onMessage: function(e){}
	},


	6: {
		html: function(){return `<div class="optionsContainer">
									<div onclick="displayScreen(8);" class="option">Retirer<br/>de l'argent</div>
									<div onclick="displayScreen(7);" class="option">Quitter<br/>l'ATM</div>
								</div>`;
		},
		init: function(){},
		onMessage: function(e){}
	},


	7: {
		html: function(){return `<div>Merci pour votre confiance en Maze Bank !<br/>Ejection de votre carte...</div>`;},
		init: function(){setTimeout(ejectCard, 3000);},
		onMessage: function(e){}
	},


	8: {
		html: function(){return `<h1>Retirer de l'argent</h1><div>Veuillez saisir la somme à retirer puis valider (V)</div><h1 id="inputField"></h1>`;},
		init: function(){receivedStr = "";},
		onMessage: function(e){
			if(receivedStr.substring(receivedStr.length-1) == 'V'){
				receivedStr = receivedStr.substring(0,receivedStr.length-1)
				displayScreen(9);
			}
			else {
				document.getElementById("inputField").innerHTML = receivedStr;
			}
		}
	},
	
// oui je le zippe et je l'envoie

// faudra le synchro avec le temps RP


	9: {
		html: function(){
			if(parseFloat(receivedStr) <= receivedCard.sum) return `<h1>$ ${receivedStr} retirés !</h1>`;
			return `<h1>Solde insuffisant !</h1><div>La transaction a été annulée</div>`;
		},
		init: function(){
			if(parseFloat(receivedStr) <= receivedCard.sum){
				receivedCard.paymentHistory.push({name:"ATM", desc:"Utilisation de l'ATM pour retirer de l'argent", amount:parseFloat('-'+receivedStr)});
				receivedCard.sum -= parseFloat(receivedStr);
				setTimeout(function(){
					send("transaction", {name:"ATM", desc:"Utilisation de l'ATM pour retirer de l'argent", amount:parseFloat('-'+receivedStr)});
				}, 1000);
			}
			setTimeout(function(){displayScreen(6);}, 3000);
		},
		onMessage: function(e){}
	},
}




/* Utils */
function displayScreen(scr){
	screen = scr;
	document.body.innerHTML = screenAssoc[screen].html();
	screenAssoc[screen].init();
}

function send(flag, payload){
	parent.postMessage({
		flag: flag,
		payload: payload
	},'*');
}

displayScreen(0);	// Initialisation de l'ATM




/* Fonctions */
function unlockCard(card, codeInput){
	if(codeInput.substring(codeInput.length-1) == 'V'){
		if(codeInput.startsWith(card.password)){
			displayScreen(3);
		}
		else{
			remainingTries--;
			if(remainingTries==0){
				displayScreen(5);
			}
			else {
				displayScreen(2);
			}
		}
	}
	else {
		document.getElementById("code").innerHTML = "• ".repeat(codeInput.length) + "_ ".repeat(4-codeInput.length)
	}
}

// éjection de la carte non bloquée
function ejectCard(){
	send("cardEject", receivedCard);
	displayScreen(0);
}

// Destruction de la carte (mangée)
function eatCard(){
	send("cardDestruct", receivedCard);
	displayScreen(0);
}

/* Réception des données de l'atm */
window.addEventListener("message", function(e){
	if(screen==0 && e.data.flag === "card"){
		receivedCard = e.data.payload;
		if(receivedCard.blocked) displayScreen(4);	// carte bloquée
		else displayScreen(1);						// carte à déverrouiller
	}
	else if(e.data.flag === "key"){
		if(e.data.payload=="X") receivedStr="";
		else if(e.data.payload=="C") receivedStr = receivedStr.substring(0,receivedStr.length-1);
		else receivedStr += e.data.payload;
	}
	screenAssoc[screen].onMessage(e);
});