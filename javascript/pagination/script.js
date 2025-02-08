const array = [
  { id: 1, data: "This is 1st Row" },
  { id: 2, data: "This is 2nd Row" },
  { id: 3, data: "This is 3rd Row" },
  { id: 4, data: "This is 4th Row" },
  { id: 5, data: "This is 5th Row" },
  { id: 6, data: "This is 6th Row" },
  { id: 7, data: "This is 7th Row" },
  { id: 8, data: "This is 8th Row" },
  { id: 9, data: "This is 9th Row" },
  { id: 10, data: "This is 10th Row" },
];

let select = document.querySelector("select");
let carddata = document.getElementById("carddata");
let button = document.querySelector(".buttons");
let displaydata = document.getElementById("displaydata");

let itemPerPage = 1;
let currentPage = 1;
let totalPage = Math.ceil(array.length / itemPerPage);

function displayData() {
  let start = (currentPage - 1) * itemPerPage;
  let end = start + itemPerPage;
  let paginationdata = array.slice(start, end);

  carddata.innerHTML = "";
  paginationdata.forEach((item) => {
    carddata.innerHTML += `
      <div class="carddetails">
        <div class="card">
          <div class="card-body">${item.data}</div>
        </div>
      </div>`;
  });

  PageChange(start, end);
}

const PageChange = (start, end) => {
  displaydata.innerHTML = "";
  displaydata.innerHTML += `<h3> Showing ${start + 1} to ${end} of ${
    array.length
  } </h3>`;
};

function GeneratePaginationData() {
  button.innerHTML = "";
  totalPage = Math.ceil(array.length / itemPerPage);

  for (let i = 1; i <= totalPage; i++) {
    let btn = document.createElement("button");
    btn.textContent = i;
    btn.classList.add("pagination-btn");

    btn.addEventListener("click", () => {
      currentPage = i;
      displayData();
    });

    button.appendChild(btn);
  }
}

select.addEventListener("change", (e) => {
  itemPerPage = parseInt(e.target.value, 10);
  currentPage = 1;
  GeneratePaginationData();
  displayData();
});

displayData();
GeneratePaginationData();
