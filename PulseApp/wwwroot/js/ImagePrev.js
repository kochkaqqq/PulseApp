function createBlobUrl(element, mimetype, byteArray) {
    const blob = new Blob([new Uint8Array(byteArray)], { type: mimetype });
    const url = URL.createObjectURL(blob);
    element.src = url;
}