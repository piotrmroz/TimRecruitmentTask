
function showMore(searchedWord) {

    const elem = document.getElementById("showMoreButton");

    let numRecordsToShow = +elem.value + 25;
    let dataToPost = { "searchedWord": searchedWord, "recordsToShow": numRecordsToShow };

    let newButtonValue = numRecordsToShow.toString();
    elem.value = newButtonValue;

    $.ajax({
        url: "/PublicationService/GetNextPage",
        type: "POST",
        data: dataToPost,
        success: function (result) {
            console.log(result);
            let oldTextValue = document.getElementsByClassName('search-result')[0].innerHTML.slice();
            document.getElementsByClassName('search-result')[0].innerHTML = result.result;

            if (document.getElementsByClassName('search-result')[0].innerHTML === oldTextValue) {
                elem.style.display = "none";
            } else {
                elem.style.display = "block";
            }
        }
    });
}