// This is a JavaScript file that is loaded on demand.

// Define the javascript functions within a namespace "exampleJsFunctions" added to the JS Window object
window.exampleJsFunctions = {

    // Define the "showPrompt" function (similar to the one defined in the JS Module file "exampleJsInterop.js")
    showPrompt: (message, answer) => {

        // Provide a default value to the optional parameter "answer"
        //  using the "truthy comparison" operator of JavaScript.
        // The vaule would be "undefined" if the parameter was not passed into the function.
        // The value would be "true" or "not null" if the parameter was passed.
        answer = answer || 'Type anything here';

        return prompt(message, answer);
    }

}
