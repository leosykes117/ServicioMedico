<%@ Page Title="Menu Principal" Language="C#" MasterPageFile="~/Menu_Plantilla.master" AutoEventWireup="true" CodeBehind="Menu_Usuario.aspx.cs" Inherits="Interfaces.Menu_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoSideNav" runat="server">
    <a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-stethoscope"></i> Consultas <i class="fa fa-caret-down"></i></a>
    <div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
        <a href="#" class="w3-text-orange">Nueva Consulta</a>
	  	<a href="#">Ver Consulta</a>
	   	<a href="#">Editar Consulta</a>
	   	<a href="#">Eliminar Consulta</a>
  	</div>
    <a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-wheelchair"></i> Pacientes <i class="fa fa-caret-down"></i></a>
    <div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
	   	<a href="#">Ver Pacientes</a>
    	<a href="#">Editar Paciente</a>	
        <a href="#">Eliminar Paciente</a>
  	</div>
	<a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-list-alt"></i> Reportes <i class="fa fa-caret-down"></i></a>
	<div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
    	<a href="#">Reporte del Mes</a>
    	<a href="#">Reportes Anteriores</a>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoArticulos" runat="server">

</asp:Content>
