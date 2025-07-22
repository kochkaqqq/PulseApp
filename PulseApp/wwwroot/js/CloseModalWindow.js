function addClickHandler(dotNetHelper) {
    var modal = document.querySelector('.modal');
    modal.addEventListener('click', function (event) {
        var modalContent = event.target.closest('.modal-content');
        if (!modalContent) {
            dotNetHelper.invokeMethodAsync('CloseModal');
        }
    });
}