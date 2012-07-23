using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Diciembre_PomodoroKata
{
    public enum Estado : int
    {
        Parado = 1,
        Terminado = 2,
        Lanzado = 3

    }

    public class Pomodoro
    {
        public TimeSpan Duracion { get; private set; }
        
        public TimeSpan TiempoDisponible { get; private set; }

        public Estado Estado { get; private set; }

        public int Interrupciones { get; private set; }

        protected Thread CountDown { get; private set; }

        public Pomodoro()
        {
            InitPomodoro(new TimeSpan(0, 25, 0));
        }   

        public Pomodoro(TimeSpan duracion)
        {
            InitPomodoro(duracion);
        }

        protected void InitPomodoro(TimeSpan duracion)
        {
            Duracion = duracion;
            Estado = Diciembre_PomodoroKata.Estado.Parado;
            Interrupciones = 0;
        }

        public void Start()
        {
            TiempoDisponible = Duracion;

            CountDown = new System.Threading.Thread(() => InitCount());

            CountDown.Start();

            Estado = Diciembre_PomodoroKata.Estado.Lanzado;
        
        }

        protected void InitCount()
        {
            while (TiempoDisponible > new TimeSpan(0, 0, 0))
            {
                Estado = Diciembre_PomodoroKata.Estado.Lanzado;

                TiempoDisponible = TiempoDisponible.Subtract(new TimeSpan(0, 0, 1));
            }

            Estado = Diciembre_PomodoroKata.Estado.Terminado;
            CountDown = null;
        }

        public void Interrumpir()
        {
            Interrupciones += 1;
            
            if (CountDown != null)
            {
                CountDown.Interrupt();
            }
        }

        public void Reiniciar()
        {
            this.TiempoDisponible = this.Duracion;
            this.Interrupciones = 0;
            Start();

        }

    }
}
