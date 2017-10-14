using System.Web;
using System.Web.Optimization;

namespace ServicioMedico.MVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //SCRIPT PARA LA VISTA DE INICIO
            bundles.Add(new ScriptBundle("~/LogIn/scripts").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/scriptsVistas/login.js"));

            //SCRIPT PARA LA VISTA DE REGISTRO
            bundles.Add(new ScriptBundle("~/Registro/scripts").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/scriptsVistas/registro.js"));

            //SCRIPTS PARA LA VISTA DE MENU PRINCIPAL
            bundles.Add(new ScriptBundle("~/Menu/scripts").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //ESTILOS PARA LA VISTA DE INICIO
            bundles.Add(new StyleBundle("~/LogIn/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/estilos_login.css"));

            //ESTILOS PARA LA VISTA DE REGISTRO
            bundles.Add(new StyleBundle("~/Registro/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/estilos_registro.css"));

            //ESTILOS DE LA VISTA MENU PRINCIPAL
            bundles.Add(new StyleBundle("~/Menu/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/estilos_menu.css"));
        }
    }
}
