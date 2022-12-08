var j = 0;

function addElement() {
    j++;

    var tblBody = document.getElementById("tbody");
    var hilera = document.createElement("tr");

    var select = document.getElementById("producto");

    for (var i = 1; i < 7; i++) {   
        var celda = document.createElement("td");
        if (i == 1) {
            var textoCelda = document.createTextNode(j)
            celda.appendChild(textoCelda);
        } else {
                  
            if (i != 4 ) {

                var input = document.createElement("input");
                input.setAttribute("id", + j + "" + i);
                input.setAttribute("name", + j + "" + i);
                if (i == 3) {
                    input.setAttribute("readonly", "true");
                    input.value = select.value;
                } else {
                    if (i == 2) {
                        input.setAttribute("Type", "number");
                        input.setAttribute("onchange", "calcular("+j+")");
                        
                    } else if (i == 6) {
                        input.setAttribute("readonly", "false");
                    } else {
                        input.setAttribute("onchange", "calcular(" + j + ")");
                    }

                }
                celda.appendChild(input);
            } else {

                var textoCelda = document.createTextNode(select.options[select.selectedIndex].text)
                    celda.appendChild(textoCelda);
                
            }
 
        }

        hilera.appendChild(celda);
        
        
    }
    tblBody.appendChild(hilera);
    var formulario = document.getElementById("formFactura");
    if (j == 1) {
        var input = document.createElement("input");
        input.setAttribute("Type", "hidden");
        input.setAttribute("id", "fila");
        input.setAttribute("name", "fila");
        input.value = j;
        formulario.appendChild(input);
    } else {
        var input = document.getElementById("fila");
        input.value = j;
        formulario.appendChild(input);
    }
    
    
   

}

function calcular(linea) {
    var total = document.getElementById(linea + "" + 6)
    var cant = document.getElementById(linea + "" + 2).value;
    var price = document.getElementById(linea + "" + 5).value;
    total.value = cant * price;
}

function impresion() {
    alert("Hello! I am an alert box!!");

}