// Regex for email
const emailRegex = /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/;

// Field error messages
const errorMessages = {
    "FirstName": 'Please enter your name.',
    "LastName": 'Please enter your last name.',
    "Email": 'Please check your email!',
    "Username": 'Please enter your username.',
    "BirthDate": 'Please enter your birthdate.',
    "Password": 'Please enter your password.',
    "SubmitPassword": 'Please submit your password.'
};

// Email validation
function validateEmail(field, fieldError) {
    if (!emailRegex.test(field.value)) {
        fieldError.textContent = errorMessages[field.id];
    }
}

// PasswordSubmit validation
function validatePasswordSubmit(field, fieldError) {
    const password = document.getElementById("Password");
    if (!field.value) {
        fieldError.textContent = errorMessages[field.id];
    } else if (password.value !== field.value) {
        fieldError.textContent = 'Passwords do not match.';
    }
}

// Event listener for validation field on blur
function validateFieldListener(field) {
    let fieldError = document.getElementById(field.id + 'Error');
    fieldError.textContent = '';

    if (field.id === "Email") {
        validateEmail(field, fieldError);
    } else if (field.id === "SubmitPassword") {
        validatePasswordSubmit(field, fieldError);
    } else {
        if (!field.value) {
            fieldError.textContent = errorMessages[field.id];
        }
    }
}

// Set event listener on form fields 
document.addEventListener('DOMContentLoaded', function () {
    const formFields = document.querySelectorAll('form input');

    formFields.forEach((element) => {
        element.addEventListener('blur', (event) => {
            validateFieldListener(event.target);
        });
    });
});