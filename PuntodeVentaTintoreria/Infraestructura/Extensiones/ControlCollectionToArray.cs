using System.Windows.Forms;

namespace PuntodeVentaTintoreria.Infraestructura.Extensiones
{
    public static class MyExtensions
    {
        public static Control[] ToArrayControl(this Control.ControlCollection ctrl)
        {
            Control[] controls = new Control[ctrl.Count];
            int index = 0;
            foreach(Control control in ctrl)
            {
                controls[index] = control;
                index++;
            }
            return controls;
        }
    }
}
