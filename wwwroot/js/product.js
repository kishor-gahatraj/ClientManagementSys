

let nav_bar= document.querySelector('.nav-bar');
let icon= document.querySelector('.top');
let li= document.getElementsByClassName('nav-item');    


for(let i=0; i < li.length; i++){
    li[i].addEventListener("click", ()=>{
        li[i].classList.toggle("active")
    })
}

let list= document.getElementsByClassName('dot');  
for(let i=0; i < list.length; i++){
    list[i].addEventListener("click", ()=>{
        list[i].classList.toggle("active")
    })
}


let x= document.getElementsByClassName("dot");
for(let i=0; i < x.length; i++){
    x[i].addEventListener("click", ()=>{
        document.getElementById("myDropdown").classList.toggle("show");
    })
}



//


function extend() {
    document.getElementById("nav-bar").style.height = "100vh";
  }


 