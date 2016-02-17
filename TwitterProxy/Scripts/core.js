function SearchTweet() {
    var query = $("#query").val();
    if (query == null || query == "")
    {
        alert("query key is required!");
        return;
    }
       
    $.ajax({
        type: "POST",
        url: "/Home/Twitter/",
        data: {
            HashTag: query
        },
        success: function (viewHTML) {
            $("#tweets").html(viewHTML);
        },
        error: function (errorData) { onError(errorData); }
    });
}