
let count = 0;

const itemsList = document.getElementById("#items");
function addItem(){
    var input = document.getElementById("input");
    if(input.value.length > 0){
    const paragraph = document.createElement("p");
    paragraph.id= "p";
    paragraph.classList.add("myClass")
    
    paragraph.innerHTML = input.value;
    
    document.getElementById("for-item").appendChild(paragraph);
     count++;
    document.getElementById("count").innerText = count;
    }
    
}
function remove(){
    let toRemove = document.getElementById("p");
    toRemove.parentNode.removeChild(toRemove);
    count--;
    document.getElementById("count").innerText = count;
}

  


