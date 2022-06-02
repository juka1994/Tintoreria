using PuntodeVentaTintoreria.ClaseAux.EventArgsAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVentaTintoreria
{
    public partial class FrmEspera : Form
    {
        public AggregateException Exceptions { get; set; }

        public event DoWorkHandler DoWork;
        public event ProgressChangedHandler ProgressChanged;
        public event RunWorkedCompleteHandler RunWorkedComplete;

        public delegate void DoWorkHandler(FrmEspera m, DoWorkWaitEventArgs e);
        public delegate void ProgressChangedHandler(FrmEspera m, ProgressChangedWaitEventArgs e);
        public delegate void RunWorkedCompleteHandler(FrmEspera m, RunWorkerCompletedWaitEventArgs e);
        
        //public delegate T Ejecutar<T>(params T[] pars);

        private object Argument { get; set; }

        private DoWorkWaitEventArgs argsDoWork { get; set; }

        private Exception ErrorWork { get; set; }

        public FrmEspera(string message, object argument)
        {
            InitializeComponent();
            lblMessage.Text = message;
            argsDoWork = new DoWorkWaitEventArgs { Argument = argument };
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                Task t1 = Task.Run(() => OnDoWork(argsDoWork));
                try
                {
                    //t1.Wait();
                    await t1;
                    OnRunWorkedComplete(new RunWorkerCompletedWaitEventArgs { Cancelled = false, Result = argsDoWork.Result, Error = ErrorWork });
                    DialogResult = DialogResult.OK;
                }
                catch(AggregateException aggEx)
                {
                    Exceptions = aggEx;
                    DialogResult = DialogResult.Abort;
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Abort;
                Exceptions = new AggregateException(new []{ ex });
            }
        }

        protected virtual void OnDoWork(DoWorkWaitEventArgs e)
        {
            try
            {
                DoWork?.Invoke(this, e);
            }
            catch(Exception ex)
            {
                ErrorWork = ex;
            }
        }

        protected virtual void OnProgressChanged(ProgressChangedWaitEventArgs e)
        {
            try
            {
                ProgressChanged?.Invoke(this, e);
            }
            catch(Exception ex)
            {
                ErrorWork = ex;
            }
        }

        protected virtual void OnRunWorkedComplete(RunWorkerCompletedWaitEventArgs e)
        {
            try
            {
                RunWorkedComplete?.Invoke(this, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ReportProgress(int progressPercentage)
        {
            try
            {
                OnProgressChanged(new ProgressChangedWaitEventArgs { ProgressPercentage = progressPercentage });
            }
            catch(Exception ex)
            {
                
            }
        }

    }
}