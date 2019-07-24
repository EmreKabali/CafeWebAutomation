function myFunction() {
    var model=@html.raw
    var element = document.getElementById(@item.Id);
    element.classList.toggle("mystyle");
}