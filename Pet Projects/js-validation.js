function fName() {
    let x = document.getElementById("fname").value;
    if (x == "") {
      alert("Name must be filled out!!!");
      return false;
    }
  }
function eMail(){
    let x = document.getElementById("email").value;
    if (x == "") {
      alert("Enter your email!!!");
      return false;
    }
}
function passWord(){
    let x = document.getElementById("password").value;
    if (x == "") {
      alert("Enter your password!!!");
      return false;
    }   

}