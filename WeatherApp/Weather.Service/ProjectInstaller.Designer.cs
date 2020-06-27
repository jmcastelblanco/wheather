namespace Weather.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.WeatherDownloadInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.WeatherDowloadData = new System.ServiceProcess.ServiceInstaller();
            // 
            // WeatherDownloadInstaller
            // 
            this.WeatherDownloadInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.WeatherDownloadInstaller.Password = null;
            this.WeatherDownloadInstaller.Username = null;
            this.WeatherDownloadInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // WeatherDowloadData
            // 
            this.WeatherDowloadData.ServiceName = "WeatherConsume";
            this.WeatherDowloadData.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.WeatherDownloadInstaller,
            this.WeatherDowloadData});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller WeatherDownloadInstaller;
        private System.ServiceProcess.ServiceInstaller WeatherDowloadData;
    }
}