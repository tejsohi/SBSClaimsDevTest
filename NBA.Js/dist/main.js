var $5830a5d3969f1e37$exports = {};
$5830a5d3969f1e37$exports = new URL("denver_nuggets.e7433fbc.jpeg", "file:" + __filename).toString();


var $928436bb93a650ed$exports = {};
$928436bb93a650ed$exports = new URL("chicago_bulls.5ae393ef.jpeg", "file:" + __filename).toString();


var $b46a32cde7053f2c$exports = {};
$b46a32cde7053f2c$exports = new URL("houston_rockets.a938d1e6.jpeg", "file:" + __filename).toString();


var $474bc66da9f6c74b$exports = {};
$474bc66da9f6c74b$exports = new URL("indiana_pacers.725ca461.jpeg", "file:" + __filename).toString();


var $42e5c2699ef310b5$exports = {};
$42e5c2699ef310b5$exports = new URL("miami_heat.a467fcdf.jpeg", "file:" + __filename).toString();


var $5cdff31d3284d1fa$exports = {};
$5cdff31d3284d1fa$exports = new URL("oklahoma_city_thunder.5548fc18.jpeg", "file:" + __filename).toString();


var $a10d08dc093b3e27$exports = {};
$a10d08dc093b3e27$exports = new URL("san_antonio_spurs.3447f2e6.jpeg", "file:" + __filename).toString();


var $31b3d9316df8bf74$exports = {};
$31b3d9316df8bf74$exports = new URL("toronto_raptors.ab5adc6a.jpeg", "file:" + __filename).toString();


async function $4fa36e821943b400$var$GetNBATeams() {
    const response = await fetch("http://localhost:5285/GetTableInfo");
    const NBATeams = await response.json();
    let table = document.getElementById("nba-teams-table");
    NBATeams.forEach(function(item, i) {
        i++;
        let row = table.insertRow(i);
        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        let cell3 = row.insertCell(2);
        let cell4 = row.insertCell(3);
        let cell5 = row.insertCell(4);
        let cell6 = row.insertCell(5);
        let cell7 = row.insertCell(6);
        let cell8 = row.insertCell(7);
        let cell9 = row.insertCell(8);
        let cell10 = row.insertCell(9);
        let cell11 = row.insertCell(10);
        let cell12 = row.insertCell(11);
        let cell13 = row.insertCell(12);
        cell1.innerHTML = item.name;
        cell2.innerHTML = item.stadium;
        const imageUrl = new URL(item.logo, "file:///src/index.js");
        console.log(imageUrl);
        let aTag = document.createElement("a");
        aTag.setAttribute("href", item.url);
        aTag.setAttribute("target", "_blank");
        let imgTag = document.createElement("img");
        imgTag.setAttribute("src", imageUrl.pathname);
        aTag.appendChild(imgTag);
        cell3.appendChild(aTag);
        cell4.innerHTML = item.mvp;
        cell5.innerHTML = item.played;
        cell6.innerHTML = item.won;
        cell7.innerHTML = item.lost;
        cell8.innerHTML = item.playedHome;
        cell9.innerHTML = item.playedAway;
        cell10.innerHTML = item.biggestWin;
        cell11.innerHTML = item.biggestLoss;
        cell12.innerHTML = item.lastGameStadium;
        cell13.innerHTML = new Date(item.lastGameDate).toLocaleDateString();
    });
}
$4fa36e821943b400$var$GetNBATeams();


//# sourceMappingURL=main.js.map
