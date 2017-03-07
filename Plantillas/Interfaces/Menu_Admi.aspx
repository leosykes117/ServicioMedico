<%@ Page Title="Menu Principal" Language="C#" MasterPageFile="~/Menu_Plantilla.master" AutoEventWireup="true" CodeBehind="Menu_Admi.aspx.cs" Inherits="Interfaces.Menu_Admi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoSideNav" runat="server">
    <a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-user-md"></i> Doctores <i class="fa fa-caret-down"></i></a>
    <div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
        <a href="#" class="w3-text-orange">Nuevo Doctor</a>
	  	<a href="#">Editar Doctor</a>
	   	<a href="#">Eliminar Doctor</a>
  	</div>

    <a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-stethoscope"></i> Consultas <i class="fa fa-caret-down"></i></a>
    <div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
        <a href="#">Ver Consultas</a>
	   	<a href="#">Editar Consultas</a>
	   	<a href="#">Eliminar Consulta</a>
  	</div>

    <a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-wheelchair"></i> Pacientes <i class="fa fa-caret-down"></i></a>
    <div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
	   	<a href="#">Ver Pacientes</a>
    	<a href="#">Editar Pacientes</a>	
        <a href="#">Eliminar Pacientes</a>
  	</div>

	<a class="abrirAcordeon w3-hover-white w3-hover-text-deep-orange"><i class="fa fa-list-alt"></i> Reportes <i class="fa fa-caret-down"></i></a>
	<div class="contenido-acordeon w3-pale-yellow w3-card-4 w3-animate-zoom">
    	<a href="#">Reporte del Mes</a>
    	<a href="#">Reportes Anteriores</a>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoArticulos" runat="server">
    <div class="w3-row">
        <div class="w3-half w3-container">
        </div>
        <div class="w3-half w3-container">
            <div class="w3-row w3-section">
                <div class="w3-col" style="width:50px"><i class="w3-xxlarge fa fa-user-md"></i></div>
                <div class="w3-rest">
                    <input type="text" class="w3-input w3-border" id="txtNombreDoctor" placeholder="Nombre del Doctor">
                </div>
            </div>
            <div class="w3-row w3-section">
                <div class="w3-col" style="width:50px"><i class="w3-xxlarge fa fa-user"></i></div>
                <div class="w3-rest">
                    <input type="text" class="w3-input w3-border" id="txtUsuario" placeholder="Usuario">
                </div>
            </div>
            <div class="w3-row w3-section">
                <div class="w3-col" style="width:50px"><i class="w3-xxlarge fa fa-hospital-o"></i></div>
                <div class="w3-rest">
                    <select id="cmbConsultorio" class="w3-input w3-border">
                        <option value="Medicina General Matutino">Medicina General Matutino</option>
                        <option value="Medicina General Vespertino">Medicina General Matutino</option>
                        <option value="Odontologia">Odontolog&iacute;a</option>
                    </select>
                </div>
            </div>
            <div class="w3-row w3-section">
                <div class="w3-col" style="width:50px"><i class="w3-xxlarge fa fa-key"></i></div>
                <div class="w3-rest">
                    <input type="text" class="w3-input w3-border" id="txtContraseña" placeholder="Contraseña">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
