$(function(){
	var header = document.getElementById('header');
	var headroom = new Headroom(header);
	headroom.init();
});

$(document).ready(function(){
	//ABRIR EL SIDE VAR
	$("#abrirNav").click(function(){
		$("#sideVertical").slideToggle("slow");
		$("#Opacar").fadeIn("slow");
		$("#main").css("marginLeft","220px");
	});

	$("#cerrarNav").click(function(){
		$("#sideVertical").slideToggle("slow");
		$("#Opacar").fadeOut("slow");
		$("#main").css("marginLeft","auto");
	});

	$("#Opacar").click(function(){
		$("#sideVertical").slideToggle("slow");
		$("#Opacar").fadeOut("slow");
		$("#main").css("marginLeft","auto");
	});

	$(".contenido-acordeon").hide();
	$(".abrirAcordeon").click(function(){
		var contenido = $(this).next(".contenido-acordeon");
		if(contenido.css("display")=="none"){ //open
			$(contenido).slideDown("slow");
   		} else { //close	
   			$(contenido).addClass("w3-animate-zoom").slideUp("slow");
  		}
	});
});