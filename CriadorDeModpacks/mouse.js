document.addEventListener('click', function (event)
{
    let elem = event.target.closest("a");
    let jsonObject =
    {
        Key: 'click',
        Value: elem.href || "Unkown"
    };
    window.chrome.webview.postMessage(jsonObject);
});