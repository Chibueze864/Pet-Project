function validateForm() {
    let x = document.getElementById("fname").value;
    if (x == "") {
      alert("Name must be filled out");
      return false;
    }
  }
function radio(){
    let x = document.getElementById("gender1").checked;
    let y = document.getElementById("gender2").checked;
    if(x === false && y === false){
        alert("Select a gender");
        return false;
    }

}
function textArea(){
    var x = document.getElementById("text").value;
    if(x === ""){
        alert("What is your complaint!!!");
        return false;
    }
}
function allDone(){
    if(validateForm() === true && radio() === true && textArea() === true){
        alert("Thank you for filling out this form")
    }

}