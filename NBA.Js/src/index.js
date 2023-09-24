async function GetNBATeams() {

    const response = await fetch("http://localhost:5285/GetTableInfo");
    const NBATeams = await response.json();
    let table = document.getElementById("nba-teams-table");

    NBATeams.forEach(function (item, i) {
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
        
        const imageUrl = new URL(String.raw`${item.logo}`, import.meta.url);

        let aTag = document.createElement('a');
        aTag.setAttribute("href", item.url);
        aTag.setAttribute("target", "_blank");
        let imgTag = document.createElement('img');
        imgTag.src = imageUrl;
        aTag.appendChild(imgTag)
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


    })

    
}
GetNBATeams();