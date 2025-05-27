/**
 * A simple JavaScript module that can be called from Blazor.
 * Demo in \Components\Demo08JsInterop\JsModuleExample.razor 
 * @param {any} message
*/

export function myJsModuleDemo(message) {

    console.log('myJsModuleDemo() called successfully');

    alert(message);

}

export function myJsAnotherModuleDemo() {

    console.log('myJsAnotherModuleDemo() called successfully');

    alert(message);

    myJsInternalModuleDemo("hello world");

}

function myJsInternalModuleDemo(message) {

    console.log('myJsInternalModuleDemo() called successfully');

    alert(message);

}


