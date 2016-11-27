using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        // html contendra el codigo descargado.
        private string html;
        // direccion contiene la direccion a apuntar.
        private Uri direccion;

        public delegate void ErrorDelegado();
        public event ErrorDelegado ErrorEvento;

        /// <summary>
        /// Constructor del objeto Descargador
        /// </summary>
        /// <param name="direccion">Direccion de la pagina web que se quiere descargar.</param>
        public Descargador(Uri direccion)
        {
            // vacio, no se descargo nada todavia!
            this.html = "";
            // la direccion de la cual descargar.
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            // metodo que inicia la descarga.
            try
            {
                // crea un WebClient
                WebClient cliente = new WebClient();
               
                // DownloadProgressChanged y DownloadStringCompleted son eventos de la clase WebClient.
                // Registro funciones(manejadores de eventos) para ejecutar cuando ocurran esos eventos
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public delegate void CambioPorcentajeDescargaDelegado(int porcentaje);
        public event CambioPorcentajeDescargaDelegado CambioPorcentajeDescargaEvento;

        /// <summary>
        /// Lanza un evento que actualiza el porcentaje de la descarga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // nombreDadoEnElEjercicio.
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //e.ProgressPercentage contiene el porcentaje en int de lo que se descargo de la pagina.
            // eso se le pasa como parametro a la funcion registrada al evento CambioPorcentajeDescargaEvento.
            // esa funcion que se registro es frmWebBrowser.ProgresoDescarga
            this.CambioPorcentajeDescargaEvento(e.ProgressPercentage);
        }

        public delegate void DescargaFinalizadaDelegado(string html);
        public event DescargaFinalizadaDelegado DescargaFinalizadaEvento;
        /// <summary>
        /// Manejador de evento que se ejecuta cuando la pagina a descargar este completa.
        /// </summary>
        /// <param name="sender">Objeto que lanzo le evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            /*
             * comentario:
             * No se si esto esta bien conceptualmente pero es la forma en la que pude menejar el error 
             * del WebClient cuando no encuentra la pagina. Investigue para entenderlo mejor y poder debuggearlo. Si bien no vimos como debugguear Threads 
             * pero se generan varios threads diferentes y tengo el VisualEstudio express.. No me deja abrir la ventana
             * para debuggear los Threads, y no tengo tiempo suficiente para instalar otra version.
             */
            try
            {
                this.html = e.Result;
                DescargaFinalizadaEvento(this.html);
            }
            catch
            {
                this.ErrorEvento();
            }
        }
    
    }
}
