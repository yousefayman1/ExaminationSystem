function submitAnswers() {
	const selectedAnswers = [];
	// Get all radio buttons that are checked
	const selectedRadioButtons = document.querySelectorAll('input[type="radio"]:checked');
	// Loop through the selected radio buttons and push their values (answer IDs) to the array
	selectedRadioButtons.forEach(function (radio) {
		selectedAnswers.push(radio.value);
	});
	// Join the selected answers into a single comma-separated string
	const answerString = selectedAnswers.join(',');

	// Set the value of the hidden input field with the joined answers
	document.getElementById("selectedAnswers").value = answerString;

	// Now you can submit the form to the server using a standard form submit
	document.getElementById("answerForm").submit();
}