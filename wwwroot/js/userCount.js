
// create connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hub/userCount").build();

//connect to methods to that hubs invokes aka recive notifications from hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
})
connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalViewsUser");
    newCountSpan.innerText = value.toString();
})
//invoke hub methods  aka send notification to hub
function fullFilled() {
    console.log("User hub connection success again");
    connectionUserCount.send("NewWindowsLoaded");
}
function rejected() {
    console.error("connection lose ");
}

//start connection

connectionUserCount.start().then(fullFilled, rejected);


