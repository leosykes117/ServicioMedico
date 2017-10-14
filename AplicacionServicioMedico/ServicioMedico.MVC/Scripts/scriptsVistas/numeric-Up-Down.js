(function ($) {
	$.fn.NumericUpDown = function (vMin, vMax) {

		var numericUD = this;//Optenemos el control
		//var cant = $(this).val();
	        
    	$(this).val(vMin);//Valor por defecto

		$(".aumentar").click(function () {
			var cant = $(numericUD).val();
	        if (cant >= vMin && cant < vMax) {// EVALUA RANGO DE VALORES
	            cant++;
	            $(numericUD).val(cant);//SI LA CANTIDAD ENTRA EN EL RANGO AUMENTA
	        } else {
	            $(numericUD).val(vMin); // SI LA CANTIDAD NO ESTA EN EL RANGO PONE "1"
	        }
	    });

	    $(".disminuir").click(function () {
	    	var cant = $(numericUD).val();
	        if (cant == vMin || cant == "") {
	            $(numericUD).val(vMax);
	        } else {
	            cant--;
	            $(numericUD).val(cant);
	        }
	    });

	    $(this).keyup(function () {
	    	var cant = $(numericUD).val();
	        if (cant > vMin && cant <= vMax || cant == "") {
	            //$(this).val(cant);
	        }
	        else {
	            $(numericUD).val(vMin);
	        }
	    });

	    $(this).keypress(function (event) {
	    	var ascii = event.which;
	        if (ascii >= 48 && ascii <= 57) {

	        } else {
	            event.preventDefault();
	        }
	    });
	};
}(jQuery));

/*var numericUD = $(".aumentar").parent().prev();//Optenemos el control
    $(numericUD).val(1);//Valor por defecto

    $(".aumentar").click(function () {
        var cant = $(numericUD).val();
        if (cant >= 1 && cant < 5) {// EVALUA RANGO DE VALORES
            cant++;
            $(numericUD).val(cant);//SI LA CANTIDAD ENTRA EN EL RANGO AUMENTA
        } else {
            $(numericUD).val(1); // SI LA CANTIDAD NO ESTA EN EL RANGO PONE "1"
        }
    });

    $(".disminuir").click(function () {
        var cant = $(numericUD).val();
        if (cant == 1 || cant == "") {
            $(numericUD).val(5);
        } else {
            cant--;
            $(numericUD).val(cant);
        }
    });

    $(numericUD).keyup(function () {
        var cant = $(numericUD).val();
        if (cant > 1 && cant <= 5 || cant == "") {
            //$(numericUD).val(cant);
        }
        else {
            $(numericUD).val(1);
        }
    });

    $(numericUD).keypress(function (event) {
        var ascii = event.which;
        if (ascii >= 49 && ascii <= 53) {

        } else {
            event.preventDefault();
        }
    });*/