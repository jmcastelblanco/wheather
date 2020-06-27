using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WeatherA.Class;
using WeatherA.Models;

namespace Weather.Service
{
    public partial class WeatherService : ServiceBase
    {
        /// <summary>
        /// Valor de intervalo de ejecucicón del servicio
        /// </summary>
        private int intervaloEjecucion;

        /// <summary>
        /// Variable que hace referencia al timer del servicio
        /// </summary>
        private Timer timServicio = null;




        public WeatherService()
        {
            InitializeComponent();
            this.intervaloEjecucion = 2 * 60000;
            this.timServicio = new Timer(this.intervaloEjecucion);
            this.timServicio.Elapsed += new ElapsedEventHandler(this.TmServicio_Elapsed);
        }

        private void TmServicio_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.timServicio.Enabled = false;

            try
            {
                WeatherDownload weatherDownload = new WeatherDownload();
                this.intervaloEjecucion = Int32.Parse(weatherDownload.GetParamValue("TimeInterval"));

                weatherDownload.ProcesarDescarga();

                this.intervaloEjecucion = this.intervaloEjecucion * 60000;

                //Si se cambia la configuracion de tiempo de ejecucución del servicio se reasigna el tiempo y se reinicia el timer
                if (this.timServicio.Interval != this.intervaloEjecucion)
                {
                    this.timServicio.Interval = this.intervaloEjecucion;
                    this.timServicio.Stop();
                    this.timServicio.Start();
                }
            }
            catch (Exception ex)
            {
                //Se registra el error si se presenta de manera general
                new ManagerException().RegistrarError(new ReporteError { Fecha = DateTime.Now, Error = ex.Message, Traza = ex.ToString(), Origen = "ServWeatherAServices", Referencia = "ServicioWindows" });
            }
            finally
            {
                this.timServicio.Enabled = true;
            }
        }

        protected override void OnStart(string[] args)
        {
            this.timServicio.Start();
        }

        protected override void OnStop()
        {
            this.timServicio.Stop();
        }

        public void DonwloadData(int intervaloEjecucion)
        {
            this.TmServicio_Elapsed(null, null);
        }
    }

}
