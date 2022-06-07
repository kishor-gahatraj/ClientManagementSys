
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>


    $(document).ready(function() {

      let currentSN = GenerateSerialNum();

      SetSerialNum(currentSN);
      
      var max_fields = 0;
      var wrapper = $(".row-2");
      var add_button = $(".addbtn");
      var x = 1; //initlal text box count

      $(add_button).click(function(e){
      
          e.preventDefault();
       
         if(x > max_fields){ 
              x++;
              $(wrapper).append('<div class="row-2" id="row_body"> <div class=" column item-1 sn"> </div><div class=" column item-2"><input type="text" name="productname"> </div> <div class=" column item-3"><input type="number"  name="expense"  ></div> <div class=" column item-4"> <input type="number"  name="expense"  > </div><div class="column item-5"><input type="number"> </div> <div class=" column item-6"> <input type="number"> </div> <div class=" column item-6"> <input type="number">  </div> <button style="cursor:pointer;background-color:red;" class="addbtn removebtn" onclick="add(event)" >  &minus; </button>  </div>');
          }
          
          let currentSN = GenerateSerialNum();

          SetSerialNum(currentSN);

      });
      $(wrapper).on("click",".removebtn", function(e){ 
      e.preventDefault();  
      $(this).parent('div').remove(); 
      // debugger
        const rows = document.querySelectorAll('.row-2');
        rows.forEach((row, index)=>{
          row.getElementsByClassName('sn')[0].innerHTML = index + 1
        })
       x--;
      })


      function GenerateSerialNum()
      {
        let currentSN = document.getElementsByClassName('row-2').length;
        return currentSN;
      }

      function SetSerialNum(currentSN)
      {
        const last = Array.from( document.querySelectorAll('.row-2')).pop();
        last.getElementsByClassName('sn')[0].innerHTML = currentSN;
      }
});
