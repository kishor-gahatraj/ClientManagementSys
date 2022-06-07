function validateform(e){
    e.preventDefault();

    var name= document.querySelector('#fname').value;  
    var lname=document.querySelector('#lname').value;  
    var uname=document.querySelector('#uname').value;  
    var email=document.querySelector('#email').value;  
    var password=document.querySelector('#psw').value;
    var firstpassword=document.querySelector('#psw').value;   
    var secondpassword=document.querySelector('#psw-repeat').value; 
    if (name==null || name==""){  
       document.getElementById('errorfname').innerHTML="Please enter a valid name";  
       return false; 
   } 

   if (lname==null || lname==""){  
       document.getElementById('errorlname').innerHTML="Please enter a last name";  
       return false; 
   } 

   if (uname==null || uname==""){  
       document.getElementById('erroruname').innerHTML="Please enter  usernamename";  
       return false; 
   } 

   if (email==null || email==""){  
       document.getElementById('erroremail').innerHTML="Please enter a valid email";  
       return false; 
   } 
    

   var atpos=email.indexOf("@");  
   var dotpos=email.lastIndexOf(".");  
   if (atpos < 1 || ( dotpos - atpos < 2 )) {
       document.getElementById('erroremail').innerHTML= "Please enter a valid e-mail address";  
      
       return false;
    }
    
   
    if(firstpassword!==secondpassword){ 
       document.getElementById('errorconfirm').innerHTML="Password must match";   
    return false;  
    }

//    if(password.length<6){  
       // checking for a specific password pattern
   if (password.match(/[a-z]/g) && password.match(/[A-Z]/g) && password.match(/[0-9]/g) && 
           password.match(/[^a-zA-Z\d]/g) && password.length >= 8 && password.length<6)
           {
           
            return true;  
            }  

                else {
                document.getElementById('errorpw').innerHTML=  "Password must be at least 6 characters long, must contain one uppercase and special character.";  
                    return false; 
            }


   





}