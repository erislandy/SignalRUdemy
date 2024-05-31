
// create connection
var connectionDeathlyHallow = new signalR.HubConnectionBuilder().withUrl("/hub/deathlyHallow").build();
var countSpan = document.getElementById("cloakCounter");
var stoneSpan = document.getElementById("stoneCounter");
var wandCount = document.getElementById("wandCounter");

//connect to methods to that hubs invokes aka recive notifications from hub
connectionDeathlyHallow.on("updateDeathlyHallowCount", (cloak, stone, wand) => {  

    countSpan.innerText = cloak.toString();
    stoneSpan.innerText = stone.toString();
    wandCount.innerText = wand.toString();
})
//start connection

connectionDeathlyHallow.start().then(fullFilled, rejected);

function fullFilled() {
    console.log("DeathlyHallow success");
    connectionDeathlyHallow.invoke("GetRaceStatus").then(result => {
        countSpan.innerText = result.cloak.toString();
        stoneSpan.innerText = result.stone.toString();
        wandCount.innerText = result.wand.toString();
    });
}
function rejected() {
    console.error("DeathlyHallow lose ");
}

