let secretNumber = Math.floor(Math.random() * 20) + 1;
let score = 10;
let highscore = 0;
const guessInput = document.getElementById('guess');
const checkbutton = document.getElementById('check');

guessInput.addEventListener('input', function () {
    const valor = guessInput.value;
    const valorLimpio = valor.replace(/[^0-9]/g, '');
    guessInput.value = valorLimpio;
});

function displayMessage(message) {
    document.getElementById('message').textContent = message;
}

checkbutton.addEventListener('click', function () {
    const userGuess = Number(guessInput.value);

    if (isNaN(userGuess) || userGuess < 1 || userGuess > 20) {
        displayMessage('Debe estar entre 1 y 20!');
    } else {
        if (userGuess === secretNumber) {
            displayMessage('¡Número correcto! Has ganado el juego.');
            document.body.style.backgroundColor = '#60b347';
            if (score > highscore) {
                highscore = score;
                document.getElementById('highscore').textContent = highscore;
                checkbutton.disabled = true;
            }
        } else {
            if (userGuess > secretNumber) {
                displayMessage('¡Muy alto! Intenta de nuevo.');
            } else {
                displayMessage('¡Muy bajo! Intenta de nuevo.');
            }
            score--;
            document.getElementById('score').textContent = score;

            if (score <= 0) {
                displayMessage('¡Perdiste!');
                checkbutton.disabled = true;
                document.body.style.backgroundColor = '#ff5754';
            }
        }
    }
});

document.getElementById('reset').addEventListener('click', function () {
    secretNumber = Math.floor(Math.random() * 20) + 1;
    score = 10;
    document.body.style.backgroundColor = '';
    displayMessage('');
    document.getElementById('score').textContent = score;
    guessInput.value = '';
    checkbutton.disabled = false;
});