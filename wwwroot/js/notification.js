
var connectionNotification = new signalR.HubConnectionBuilder()
    .withUrl("/hub/notification").build();

document.getElementById("sendButton").disabled = true;

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("notificationInput").value;
    connectionNotification.send("SendMessage", message).then(function () {
        document.getElementById("notificationInput").value = "";
    });
    event.preventDefault();
});
connectionNotification.on("LoadNotification", function (message, counter) {
    console.log({ message, counter });
    document.getElementById("messageList").innerHTML = "";
    var notificationCounter = document.getElementById("notificationCounter");
    notificationCounter.innerHTML = "<span>(" + counter + ")</span>";
    for (let i = message.length - 1; i >= 0; i--) {
        var li = document.createElement("li");
        li.textContent = "Notification - " + message[i];
        document.getElementById("messageList").appendChild(li);
    }
});


connectionNotification.start().then(function () {
    console.log("Notification connected");
    document.getElementById("sendButton").disabled = false;
    connectionNotification.send("LoadMessages");
});
