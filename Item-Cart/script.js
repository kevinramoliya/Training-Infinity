const array = [{
    id: 1,
    productname: "product1",
    price: 100,
    quantity: 1,
    stock:5
    
}, {
    id: 2,
    productname: "product2",
    price: 200,
    quantity: 1,
    stock: 3
}, {
    id: 3,
    productname: "product3",
    price: 300,
    quantity: 1,
    stock:10
}]
var cards = document.getElementById("cards");
const table = document.querySelector('table');
let data = "";
let carddata = array.forEach((item) => {
    data += `<div class="col-sm-4 mb-3 mb-sm-0">
   <div class="card">
     <div class="card-body">
       <h5 class="card-title">product:-${item.productname}</h5>
       <h5 class="card-title">price:-${item.price}</h5>
       <h5 class="card-title">Stock:-${item.stock}</h5>
       <button type="button" class="btn btn-primary" dataid=${item.id}>Add to Cart</button>
     </div>
   </div>
 </div>`

});
cards.innerHTML = data;


let  cart=[];
const tbody  = document.createElement("tbody");
table.appendChild(tbody);

const tFoot = document.createElement("tfoot");
const trow = document.createElement("tr");

const tlabel = document.createElement("td");
tlabel.textContent = "Grand Total";
tlabel.setAttribute("colspan","3");
tlabel.style.fontWeight = "bold";
tlabel.style.textAlign = "center"

const Ttotal = document.createElement("td");
Ttotal.textContent = "0";
Ttotal.style.fontWeight="bold";

trow.appendChild(tlabel);
trow.appendChild(Ttotal);
tFoot.appendChild(trow);
table.appendChild(tFoot);

function TotalPrice(){
    let tprice  = 0;
    tbody.querySelectorAll("tr").forEach((row)=>{
        var totalcell = row.querySelector("td:nth-last-child(2)")
        if(totalcell){
            tprice+= parseInt(totalcell.textContent);
        }
    })

Ttotal.textContent = tprice;
}


cards.addEventListener('click', (e) => {

    

    if (e.target.classList.contains('btn')) {
        const productId = e.target.getAttribute('dataid');
        console.log(productId);
        const item = array.find(item=>item.id==productId);
        const rowExist = document.querySelectorAll("table tbody tr");
        let found = false;

        for(let row of rowExist){
            const rowDetail = row.cells[0]?.textContent;
            if(rowDetail==item.productname){
                let qspan = row.querySelector("span");
                let Totalprice = row.cells[row.cells.length-2];
                let qty = parseInt(qspan.textContent);
                if(qty<item.stock){
                    qty++;
                    qspan.textContent = qty;
                    Totalprice.textContent = qty*item.price;
                    TotalPrice();
                }
                found = true;
                break;
            }
        }

        if(!found){

        

                const tr = document.createElement('tr');
                const arraydata = [item.productname, item.price];
                console.log("hii", arraydata);
                for (var i = 0; i < arraydata.length; i++) {
                    const td = document.createElement('td');
                    td.textContent = arraydata[i];
                    tr.appendChild(td);
                    console.log(arraydata[i]);
                }
                const quantityId = document.createElement("td");
                quantityId.style.display = "flex"
                quantityId.style.justifyContent = "space-between"

                const minusBtn = document.createElement("button");
                minusBtn.textContent = "-";
                minusBtn.classList.add("btn", "btn-danger", style = "width:10px");

                const quantity = document.createElement("span");
                quantity.textContent = item.quantity;
                quantity.style.fontSize = "20px"

                const addBtn = document.createElement("button");
                addBtn.textContent = "+";
                addBtn.classList.add("btn", "btn-success", style = "width:10px");
                


                quantityId.appendChild(minusBtn);
                quantityId.appendChild(quantity);
                quantityId.appendChild(addBtn);
                tr.appendChild(quantityId);

                const totalPrice = document.createElement("td");
                totalPrice.textContent = item.price * item.quantity;
                tr.appendChild(totalPrice);

                const DBtn = document.createElement("td");
                const DeleteBtn = document.createElement("Button");
                DeleteBtn.textContent = "Delete";
                DeleteBtn.className = "DeleteBtn";
              

                DeleteBtn.addEventListener("click",()=>{
                    tr.remove();
                    TotalPrice();
                })

                minusBtn.addEventListener("click",()=>{
                    let qty = parseInt(quantity.textContent);
                    if(qty>1){
                     qty--;
                     quantity.textContent = qty;
                     totalPrice.textContent = qty* item.price;
                    addBtn.disabled = false;
                    TotalPrice();
                    }
                })

                addBtn.addEventListener("click",()=>{
                    let qty = parseInt(quantity.textContent);
                    if(qty<=item.stock){
                        qty++;
                        quantity.textContent = qty;
                        totalPrice.textContent = qty*item.price;
                        
                    TotalPrice();
                    }
                    if(qty==item.stock){
                        addBtn.disabled = true;
                    }
                })


                DBtn.appendChild(DeleteBtn)
                tr.appendChild(DBtn);
                tbody.appendChild(tr);
                TotalPrice();
            }}})

