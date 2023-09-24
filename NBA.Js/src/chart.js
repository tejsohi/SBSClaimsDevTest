import Chart from 'chart.js/auto'

(async function () {
  const response = await fetch("http://localhost:5285/GetTableInfo");
  const data = await response.json();

new Chart(
  document.getElementById('chart'),
  {
    type: 'bar',
    data: {
      labels: data.map(row => row.name),
      datasets: [
        {
          label: 'Wins',
          data: data.map(row => row.won)
        },
        {
          label: "Losses",
          hidden: true,
          data: data.map(row => row.lost)
        }
      ]
    }
  }
);
}) ();