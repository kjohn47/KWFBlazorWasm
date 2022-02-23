export function addStorageEventListener(dotNetObjectRef, jsInvokableMethodName) {
    window.addEventListener('storage', (event) => {
        dotNetObjectRef.invokeMethodAsync(jsInvokableMethodName);
    });
}